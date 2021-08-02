using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class Tiempo
    {
        public Tiempo()
        {
            Indicadores = new HashSet<Indicadores>();
        }

        public int IdTiempo { get; set; }
        public string NombrePeriodo { get; set; }

        public virtual ICollection<Indicadores> Indicadores { get; set; }
    }
}
