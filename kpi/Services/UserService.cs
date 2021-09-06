using kpi.Dtos;
using kpi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kpi.Services.UserService
{
    public interface IUserService
    {
        ResponseModel<Usuario> Get(long UserId);
    }
    public class UserService : IUserService
    {
        private readonly kpiContext _context;

        public UserService(kpiContext context)
        {
            _context = context;
        }
        public ResponseModel<Usuario> Get(long UserId)
        {
            ResponseModel<Usuario> response = new ResponseModel<Usuario>();

            try
            {
                Usuario user = (from UM in _context.Usuario
                                  where UM.IdUsuario == UserId
                                  select UM).FirstOrDefault();
                
                if (user != null)
                {
                    response.Data = user;
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "User Not Found!";
                    return response;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
