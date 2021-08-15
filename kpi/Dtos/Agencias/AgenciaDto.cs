using kpi.Dtos.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Dtos.Agencias
{
    public class AgenciaDto
    {
        public int IdAgencia { get; set; }
        public string NombreAgencia { get; set; }
        public List<AreaAgenciaDto> AreaAgenciaDtos { get; set; }
    }
}
