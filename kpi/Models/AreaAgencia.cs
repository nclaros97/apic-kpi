using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class AreaAgencia
    {
        public AreaAgencia()
        {
            Logrado = new HashSet<Logrado>();
            Meta = new HashSet<Meta>();
        }

        public int IdAreaAgencia { get; set; }
        public int IdArea { get; set; }
        public int IdAgencia { get; set; }
        public int IdCodigoIndiador { get; set; }

        public virtual Agencia IdAgenciaNavigation { get; set; }
        public virtual Area IdAreaNavigation { get; set; }
        public virtual Indicadores IdCodigoIndiadorNavigation { get; set; }
        public virtual ICollection<Logrado> Logrado { get; set; }
        public virtual ICollection<Meta> Meta { get; set; }
    }
}
