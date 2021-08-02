using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class Subobjetivos
    {
        public Subobjetivos()
        {
            Indicadores = new HashSet<Indicadores>();
        }

        public int IdSubobjetivos { get; set; }
        public string NombreSubobjetivo { get; set; }
        public int IdArea { get; set; }
        public int IdObjetivo { get; set; }
        public string SubObjetivo { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual Objetivo IdObjetivoNavigation { get; set; }
        public virtual ICollection<Indicadores> Indicadores { get; set; }
    }
}
