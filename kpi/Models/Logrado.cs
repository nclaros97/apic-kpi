using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class Logrado
    {
        public int IdCodigoIndiador { get; set; }
        public int IdAreaAgencia { get; set; }
        public string Meta { get; set; }
        public string Logrado1 { get; set; }
        public string PorcentajeCumplimiento { get; set; }
        public string Observacion { get; set; }

        public virtual AreaAgencia IdAreaAgenciaNavigation { get; set; }
    }
}
