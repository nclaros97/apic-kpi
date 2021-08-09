using kpi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Dtos.Objetivos
{
    public class ObjetivosDto
    {
        public int idObjetivo { get; set; }
        public string nombreObjetivo {get;set;}
        public float porcentajeObjetivo { get; set; }
        public List<Subobjetivos> SubObjetivo { get; set; }
    }
}
