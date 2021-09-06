using kpi.Dtos;
using kpi.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace kpi.Services.IdentityService
{
    public interface IIdentityService
    {
        Task<ResponseModel<TokenModel>> LoginAsync(LoginModel login);
        Task<ResponseModel<TokenModel>> RefreshTokenAsync(TokenModel request);


    }

    public class IdentityService : IIdentityService
    {
        private readonly kpiContext _context;
        private readonly ServiceConfiguration _appSettings;

        private readonly TokenValidationParameters _tokenValidationParameters;
        public IdentityService(kpiContext context,
            IOptions<ServiceConfiguration> settings,
            TokenValidationParameters tokenValidationParameters)
        {
            _context = context;
            _appSettings = settings.Value;
            _tokenValidationParameters = tokenValidationParameters;
        }


        public async Task<ResponseModel<TokenModel>> LoginAsync(LoginModel login)
        {
            ResponseModel<TokenModel> response = new ResponseModel<TokenModel>();
            try
            {
                Usuario loginUser = _context.Usuario.FirstOrDefault(c => c.Email == login.Email && c.Contraseña == login.Password);

                if (loginUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Username And Password";
                    return response;
                }


                AuthenticationResult authenticationResult = await AuthenticateAsync(loginUser);
                if (authenticationResult != null && authenticationResult.Success)
                {
                    response.Data = new TokenModel() { Token = authenticationResult.Token, RefreshToken = authenticationResult.RefreshToken };
                }
                else
                {
                    response.Message = "Something went wrong!";
                    response.IsSuccess = false;

                }

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //private List<RolesMaster> GetUserRole(long UserId)
        //{
        //    try
        //    {
        //        List<RolesMaster> rolesMasters = (from UM in _context.UsersMaster
        //                                          join UR in _context.UserRoles on UM.UserId equals UR.UserId
        //                                          join RM in _context.RolesMaster on UR.RoleId equals RM.RoleId
        //                                          where UM.UserId == UserId
        //                                          select RM).ToList();
        //        return rolesMasters;
        //    }
        //    catch (Exception)
        //    {

        //        return new List<RolesMaster>();
        //    }
        //}

        public async Task<AuthenticationResult> AuthenticateAsync(Usuario user)
        {
            // authentication successful so generate jwt token
            AuthenticationResult authenticationResult = new AuthenticationResult();
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.JwtSettings.Secret);

                ClaimsIdentity Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("userId", user.IdUsuario.ToString()),
                    new Claim("email",user.Email==null?"":user.Email),
                    new Claim("agenciaId",user.IdAgencia.ToString()),
                    new Claim("areaId",user.IdArea.ToString()),
                    new Claim("tipo",user.UsuarioTipo),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    });
                //foreach (var item in GetUserRole(user.UserId))
                //{
                //    Subject.AddClaim(new Claim(ClaimTypes.Role, item.RoleName));
                //}

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = Subject,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Expires = DateTime.UtcNow.Add(_appSettings.JwtSettings.TokenLifetime)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                authenticationResult.Token = tokenHandler.WriteToken(token);


                var refreshToken = new Tokens
                {
                    Token = Guid.NewGuid().ToString(),
                    JwtId = token.Id,
                    IdUsuario = user.IdUsuario,
                    CreationDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddMonths(6)
                };
                await _context.Tokens.AddAsync(refreshToken);
                await _context.SaveChangesAsync();
                authenticationResult.RefreshToken = refreshToken.Token;
                authenticationResult.Success = true;
                return authenticationResult;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<ResponseModel<TokenModel>> RefreshTokenAsync(TokenModel request)
        {

            ResponseModel<TokenModel> response = new ResponseModel<TokenModel>();
            try
            {
                var authResponse = await GetRefreshTokenAsync(request.Token, request.RefreshToken);
                if (!authResponse.Success)
                {

                    response.IsSuccess = false;
                    response.Message = string.Join(",", authResponse.Errors);
                    return response;
                }
                TokenModel refreshTokenModel = new TokenModel();
                refreshTokenModel.Token = authResponse.Token;
                refreshTokenModel.RefreshToken = authResponse.RefreshToken;
                response.Data = refreshTokenModel;
                return response;
            }
            catch (Exception ex)
            {


                response.IsSuccess = false;
                response.Message = "Something went wrong!";
                return response;
            }
        }

        private async Task<AuthenticationResult> GetRefreshTokenAsync(string token, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(token);

            if (validatedToken == null)
            {
                return new AuthenticationResult { Errors = new[] { "Invalid Token" } };
            }

            var expiryDateUnix =
                long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return new AuthenticationResult { Errors = new[] { "This token hasn't expired yet" } };
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = _context.Tokens.FirstOrDefault(x => x.Token == refreshToken);

            if (storedRefreshToken == null)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token does not exist" } };
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token has expired" } };
            }

            if (storedRefreshToken.Used.HasValue && storedRefreshToken.Used == true)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token has been used" } };
            }

            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token does not match this JWT" } };
            }

            storedRefreshToken.Used = true;
            _context.Tokens.Update(storedRefreshToken);
            await _context.SaveChangesAsync();
            string strUserId = validatedToken.Claims.Single(x => x.Type == "UserId").Value;
            long userId = 0;
            long.TryParse(strUserId, out userId);
            var user = _context.Usuario.FirstOrDefault(c => c.IdUsuario == userId);
            if (user == null)
            {
                return new AuthenticationResult { Errors = new[] { "User Not Found" } };
            }

            return await AuthenticateAsync(user);
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValidationParameters = _tokenValidationParameters.Clone();
                tokenValidationParameters.ValidateLifetime = false;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                       StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
