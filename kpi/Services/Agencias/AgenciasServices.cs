using kpi.Dtos;
using kpi.Dtos.Agencias;
using kpi.Dtos.Areas;
using kpi.Dtos.Indicadores;
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
                                   AreaAgenciaDtos = (from ag in _context.AreaAgencia.ToList()
                                                      where ag.IdAgencia == a.IdAgencia
                                                      select new AreaAgenciaDto
                                                      {
                                                          IdArea = ag.IdArea,
                                                          IdAreaAgencia = ag.IdAreaAgencia,
                                                          IdCodigoIndiador = ag.IdCodigoIndiador,
                                                          IdAgencia = ag.IdAgencia,
                                                          IndicadorDto = (from i in _context.Indicadores.Where(x => x.IdCodigoIndiador == ag.IdCodigoIndiador)
                                                                          select new IndicadorDto {
                                                                              Detalle = i.Detalle,
                                                                              Estado = i.Estado,
                                                                              IdCodigoIndiador = i.IdCodigoIndiador,
                                                                              Formula = i.Formula,
                                                                              IdSubobjetivos = i.IdSubobjetivos,
                                                                              IdTiempo = i.IdTiempo,
                                                                              NombreIndicador = i.NombreIndicador,
                                                                              Proceso = i.Proceso,
                                                                              Responsables = i.Responsables
                                                                          }).FirstOrDefault(),
                                                          AreaDto = (from a in _context.Area.Where(x => x.IdArea == ag.IdArea)
                                                                     select new AreaDto
                                                                     {
                                                                         IdArea = a.IdArea,
                                                                         NombreArea = a.NombreArea
                                                                     }).FirstOrDefault()
                                                      }).ToList()
                               }).ToList();


            return agenciasDto;
        }
    }
}
