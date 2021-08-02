using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class Agencia
    {
        public Agencia()
        {
            AreaAgencia = new HashSet<AreaAgencia>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdAgencia { get; set; }
        public string NombreAgencia { get; set; }

        public virtual ICollection<AreaAgencia> AreaAgencia { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
