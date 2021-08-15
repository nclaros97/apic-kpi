using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Dtos.Indicadores
{
    public class IndicadorDto
    {
        public int IdCodigoIndiador { get; set; }
        public int IdSubobjetivos { get; set; }
        public string NombreIndicador { get; set; }
        public string Proceso { get; set; }
        public string Formula { get; set; }
        public string Detalle { get; set; }
        public int IdTiempo { get; set; }
        public string Estado { get; set; }
        public string Responsables { get; set; }
    }
}
