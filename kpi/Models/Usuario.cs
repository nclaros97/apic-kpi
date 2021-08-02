using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int IdArea { get; set; }
        public string UsuarioTipo { get; set; }
        public int IdAgencia { get; set; }

        public virtual Agencia IdAgenciaNavigation { get; set; }
        public virtual Area IdAreaNavigation { get; set; }
    }
}
