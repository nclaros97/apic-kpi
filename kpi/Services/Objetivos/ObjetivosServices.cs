using kpi.Dtos.Areas;
using kpi.Dtos.Objetivos;
using kpi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Services.Objetivos
{
    public class ObjetivosServices
    {
        private readonly kpiContext _context;
        public ObjetivosServices(kpiContext context) {
            _context = context;
        }

        public async Task<List<ObjetivosDto>> GetObjetivos()
        {
            var objetivosDb = await _context.Objetivo.ToListAsync();

            var objetivos = (from ob in objetivosDb
                             select new ObjetivosDto
                             {
                                 IdObjetivo = ob.IdObjetivo,
                                 NombreObjetivo = ob.NombreObjetivo,
                                 PorcentajeObjetivo = ob.PorcentajeObjetivo,
                                 SubObjetivosDto = (from subOb in _context.Subobjetivos
                                                    where subOb.IdObjetivo == ob.IdObjetivo
                                                    select new SubObjetivoDto
                                                    {
                                                        IdArea = subOb.IdArea,
                                                        IdObjetivo = subOb.IdObjetivo,
                                                        AreaDto = (from a in _context.Area
                                                                   where a.IdArea == subOb.IdArea 
                                                                   select new AreaDto { 
                                                                       IdArea = a.IdArea,
                                                                       NombreArea = a.NombreArea
                                                                   }).FirstOrDefault(),
                                                        IdSubobjetivos = subOb.IdSubobjetivos,
                                                        NombreSubobjetivo = subOb.NombreSubobjetivo,
                                                        SubObjetivo = subOb.SubObjetivo
                                                    }).ToList()
                             }).ToList();
            return  objetivos;
        }

    }
}
