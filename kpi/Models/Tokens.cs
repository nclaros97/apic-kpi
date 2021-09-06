using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class Tokens
    {
        public int RefreshTokenId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? Used { get; set; }
        public int? IdUsuario { get; set; }
    }
}
