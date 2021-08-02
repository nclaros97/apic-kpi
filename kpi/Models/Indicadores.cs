using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class Indicadores
    {
        public Indicadores()
        {
            AreaAgencia = new HashSet<AreaAgencia>();
        }

        public int IdCodigoIndiador { get; set; }
        public int IdSubobjetivos { get; set; }
        public string NombreIndicador { get; set; }
        public string Proceso { get; set; }
        public string Formula { get; set; }
        public string Detalle { get; set; }
        public int IdTiempo { get; set; }
        public string Estado { get; set; }
        public string Responsables { get; set; }

        public virtual Subobjetivos IdSubobjetivosNavigation { get; set; }
        public virtual Tiempo IdTiempoNavigation { get; set; }
        public virtual ICollection<AreaAgencia> AreaAgencia { get; set; }
    }
}
