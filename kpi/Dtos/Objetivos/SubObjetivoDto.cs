using kpi.Dtos.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Dtos.Objetivos
{
    public class SubObjetivoDto
    {
        public int IdSubobjetivos { get; set; }
        public string NombreSubobjetivo { get; set; }
        public int IdArea { get; set; }
        public int IdObjetivo { get; set; }
        public ObjetivosDto ObjetivosDto { get; set; }
        public string SubObjetivo { get; set; }
        public AreaDto AreaDto { get; set; }
    }
}
