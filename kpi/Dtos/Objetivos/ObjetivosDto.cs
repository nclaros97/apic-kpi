using kpi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Dtos.Objetivos
{
    public class ObjetivosDto
    {
        public int IdObjetivo { get; set; }
        public string NombreObjetivo {get;set;}
        public float PorcentajeObjetivo { get; set; }
        public List<SubObjetivoDto> SubObjetivosDto { get; set; }
    }
}
