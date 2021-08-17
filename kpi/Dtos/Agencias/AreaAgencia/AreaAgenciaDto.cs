using kpi.Dtos.Agencias;
using kpi.Dtos.Areas;
using kpi.Dtos.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Dtos
{
    public class AreaAgenciaDto
    {
        public int IdAreaAgencia { get; set; }
        public int IdArea { get; set; }
        public int IdAgencia { get; set; }
        public int IdCodigoIndiador { get; set; }
        public AreaDto AreaDto { get; set; }
        public AgenciaDto AgenciaDto { get; set; }
        public IndicadorDto IndicadorDto { get; set; }
    }
}
