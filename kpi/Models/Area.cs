using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class Area
    {
        public Area()
        {
            AreaAgencia = new HashSet<AreaAgencia>();
            Subobjetivos = new HashSet<Subobjetivos>();
            SubojetivoArea = new HashSet<SubojetivoArea>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdArea { get; set; }
        public string NombreArea { get; set; }

        public virtual ICollection<AreaAgencia> AreaAgencia { get; set; }
        public virtual ICollection<Subobjetivos> Subobjetivos { get; set; }
        public virtual ICollection<SubojetivoArea> SubojetivoArea { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
