using kpi.Dtos.Agencias;
using kpi.Dtos.Areas;
using kpi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Services.Agencias
{
    public class AgenciasServices
    {
        private readonly kpiContext _context;
        public AgenciasServices(kpiContext context)
        {
            _context = context;
        }

        public List<AgenciaDto> GetAgencias()
        {
            var agencias = _context.Agencia.ToList();
            var agenciasDto = (from a in agencias
                               select new AgenciaDto
                               {
                                   IdAgencia = a.IdAgencia,
                                   NombreAgencia = a.NombreAgencia,
                                   Areas = (from ag in _context.AreaAgencia.ToList() 
                                            where ag.IdAgencia == a.IdAgencia
                                            select new AreaDto 
                                            { 
                                                IdArea = (from a in _context.Area.ToList().Where(x=>x.IdArea == ag.IdArea) select a.IdArea).FirstOrDefault(),
                                                NombreArea = (from a in _context.Area.ToList().Where(x => x.IdArea == ag.IdArea) select a.NombreArea).FirstOrDefault(),
                                                IdAreaAgencia = ag.IdAreaAgencia
                                            }).ToList()    
                               }).ToList();


            return agenciasDto;
        }
    }
}
