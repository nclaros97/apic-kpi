using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Dtos.Indicadores
{
    public class MetaDto
    {
        public int IdCodigoIndiador { get; set; }
        public int IdAreaAgencia { get; set; }
        public AreaAgenciaDto AreaAgenciaDto { get; set; }
        public LogradoDto LogradoDto { get; set; }
    }
}
