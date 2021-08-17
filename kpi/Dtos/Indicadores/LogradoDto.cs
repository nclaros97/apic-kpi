using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Dtos.Indicadores
{
    public class LogradoDto
    {
        public int IdCodigoIndiador { get; set; }
        public int IdAreaAgencia { get; set; }
        public string Meta { get; set; }
        public string Logrado1 { get; set; }
        public string PorcentajeCumplimiento { get; set; }
        public string Observacion { get; set; }
    }
}
