using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kpi.Models;
using kpi.Dtos.Indicadores;
using kpi.Dtos.Objetivos;
using kpi.Dtos.Areas;
using kpi.Dtos;
using kpi.Dtos.Agencias;
using kpi.Dtos.Tiempos;

namespace kpi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicadoresController : ControllerBase
    {
        private readonly kpiContext _context;

        public IndicadoresController(kpiContext context)
        {
            _context = context;
        }

        // GET: api/Indicadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndicadorDto>>> GetIndicadores()
        {
            var indicadoresDb = await _context.Indicadores.ToListAsync();
            var indicadores = (from i in indicadoresDb.ToList()
                               select new IndicadorDto
                               {
                                   Detalle = i.Detalle,
                                   Estado = i.Estado,
                                   Formula = i.Formula,
                                   IdCodigoIndiador = i.IdCodigoIndiador,
                                   IdSubobjetivos = i.IdSubobjetivos,
                                   SubObjetivoDto = (from so in _context.Subobjetivos.ToList()
                                                     where so.IdSubobjetivos == i.IdSubobjetivos
                                                     select new SubObjetivoDto {
                                                         AreaDto = (from a in _context.Area.ToList()
                                                                    where a.IdArea == so.IdArea
                                                                    select new AreaDto {
                                                                        IdArea = a.IdArea,
                                                                        NombreArea = a.NombreArea
                                                                    }).FirstOrDefault(),
                                                         IdArea = so.IdArea,
                                                         IdObjetivo = so.IdObjetivo,
                                                         ObjetivosDto = (from o in _context.Objetivo.ToList()
                                                                         where o.IdObjetivo == so.IdObjetivo
                                                                         select new ObjetivosDto { 
                                                                             IdObjetivo = o.IdObjetivo,
                                                                             NombreObjetivo = o.NombreObjetivo,
                                                                             PorcentajeObjetivo = o.PorcentajeObjetivo
                                                                         }).FirstOrDefault(),
                                                         IdSubobjetivos = so.IdSubobjetivos,
                                                         NombreSubobjetivo = so.NombreSubobjetivo,
                                                         SubObjetivo = so.SubObjetivo
                                                     }).FirstOrDefault(),
                                   IdTiempo = i.IdTiempo,
                                   TiempoDto = (from t in _context.Tiempo.ToList()
                                                where t.IdTiempo == i.IdTiempo
                                                select new TiempoDto {
                                                    IdTiempo = t.IdTiempo,
                                                    NombrePeriodo = t.NombrePeriodo
                                                }).FirstOrDefault(),
                                   MetaDto = (from m in _context.Meta.ToList()
                                              where m.IdCodigoIndiador == i.IdCodigoIndiador
                                              select new MetaDto {
                                                  IdAreaAgencia = m.IdAreaAgencia,
                                                  IdCodigoIndiador = m.IdCodigoIndiador,
                                                  AreaAgenciaDto = (from x in _context.AreaAgencia.ToList()
                                                                    where x.IdAreaAgencia == m.IdAreaAgencia
                                                                    select new AreaAgenciaDto {
                                                                        IdAgencia = x.IdAgencia,
                                                                        IdAreaAgencia = x.IdAreaAgencia,
                                                                        IdArea = x.IdArea,
                                                                        IdCodigoIndiador = x.IdCodigoIndiador,
                                                                        AgenciaDto = (from a in _context.Agencia.ToList()
                                                                                      where a.IdAgencia == x.IdAgencia
                                                                                      select new AgenciaDto {
                                                                                          IdAgencia = a.IdAgencia,
                                                                                          NombreAgencia = a.NombreAgencia
                                                                                      }).FirstOrDefault(),
                                                                        AreaDto = (from a in _context.Area.ToList()
                                                                                   where a.IdArea == x.IdArea
                                                                                   select new AreaDto
                                                                                   {
                                                                                       IdArea = a.IdArea,
                                                                                       NombreArea = a.NombreArea
                                                                                   }).FirstOrDefault()
                                                                    }).FirstOrDefault(),
                                                  LogradoDto = (from l in _context.Logrado.ToList()
                                                                where l.IdCodigoIndiador == i.IdCodigoIndiador
                                                                select new LogradoDto {
                                                                    Meta = l.Meta,
                                                                    IdCodigoIndiador = l.IdCodigoIndiador,
                                                                    IdAreaAgencia = l.IdAreaAgencia,
                                                                    Logrado1 = l.Logrado1,
                                                                    Observacion = l.Observacion,
                                                                    PorcentajeCumplimiento = l.PorcentajeCumplimiento
                                                                }).FirstOrDefault()
                                              }).FirstOrDefault(),
                                   NombreIndicador = i.NombreIndicador,
                                   Proceso = i.Proceso,
                                   Responsables = i.Responsables
                               }).ToList();
            return indicadores;
        }

        [HttpGet("indicadoresEvaluados")]
        public async Task<ActionResult<IEnumerable<IndicadorDto>>> GetIndicadoresEvaluados()
        {
            var indicadoresDb = await _context.Indicadores.Where(x=>x.Estado == "Evaluado").ToListAsync();
            var indicadores = (from i in indicadoresDb.ToList()
                               select new IndicadorDto
                               {
                                   Detalle = i.Detalle,
                                   Estado = i.Estado,
                                   Formula = i.Formula,
                                   IdCodigoIndiador = i.IdCodigoIndiador,
                                   IdSubobjetivos = i.IdSubobjetivos,
                                   SubObjetivoDto = (from so in _context.Subobjetivos.ToList()
                                                     where so.IdSubobjetivos == i.IdSubobjetivos
                                                     select new SubObjetivoDto
                                                     {
                                                         AreaDto = (from a in _context.Area.ToList()
                                                                    where a.IdArea == so.IdArea
                                                                    select new AreaDto
                                                                    {
                                                                        IdArea = a.IdArea,
                                                                        NombreArea = a.NombreArea
                                                                    }).FirstOrDefault(),
                                                         IdArea = so.IdArea,
                                                         IdObjetivo = so.IdObjetivo,
                                                         ObjetivosDto = (from o in _context.Objetivo.ToList()
                                                                         where o.IdObjetivo == so.IdObjetivo
                                                                         select new ObjetivosDto
                                                                         {
                                                                             IdObjetivo = o.IdObjetivo,
                                                                             NombreObjetivo = o.NombreObjetivo,
                                                                             PorcentajeObjetivo = o.PorcentajeObjetivo
                                                                         }).FirstOrDefault(),
                                                         IdSubobjetivos = so.IdSubobjetivos,
                                                         NombreSubobjetivo = so.NombreSubobjetivo,
                                                         SubObjetivo = so.SubObjetivo
                                                     }).FirstOrDefault(),
                                   IdTiempo = i.IdTiempo,
                                   TiempoDto = (from t in _context.Tiempo.ToList()
                                                where t.IdTiempo == i.IdTiempo
                                                select new TiempoDto
                                                {
                                                    IdTiempo = t.IdTiempo,
                                                    NombrePeriodo = t.NombrePeriodo
                                                }).FirstOrDefault(),
                                   MetaDto = (from m in _context.Meta.ToList()
                                              where m.IdCodigoIndiador == i.IdCodigoIndiador
                                              select new MetaDto
                                              {
                                                  IdAreaAgencia = m.IdAreaAgencia,
                                                  IdCodigoIndiador = m.IdCodigoIndiador,
                                                  AreaAgenciaDto = (from x in _context.AreaAgencia.ToList()
                                                                    where x.IdAreaAgencia == m.IdAreaAgencia
                                                                    select new AreaAgenciaDto
                                                                    {
                                                                        IdAgencia = x.IdAgencia,
                                                                        IdAreaAgencia = x.IdAreaAgencia,
                                                                        IdArea = x.IdArea,
                                                                        IdCodigoIndiador = x.IdCodigoIndiador,
                                                                        AgenciaDto = (from a in _context.Agencia.ToList()
                                                                                      where a.IdAgencia == x.IdAgencia
                                                                                      select new AgenciaDto
                                                                                      {
                                                                                          IdAgencia = a.IdAgencia,
                                                                                          NombreAgencia = a.NombreAgencia
                                                                                      }).FirstOrDefault(),
                                                                        AreaDto = (from a in _context.Area.ToList()
                                                                                   where a.IdArea == x.IdArea
                                                                                   select new AreaDto
                                                                                   {
                                                                                       IdArea = a.IdArea,
                                                                                       NombreArea = a.NombreArea
                                                                                   }).FirstOrDefault()
                                                                    }).FirstOrDefault(),
                                                  LogradoDto = (from l in _context.Logrado.ToList()
                                                                where l.IdCodigoIndiador == i.IdCodigoIndiador
                                                                select new LogradoDto
                                                                {
                                                                    Meta = l.Meta,
                                                                    IdCodigoIndiador = l.IdCodigoIndiador,
                                                                    IdAreaAgencia = l.IdAreaAgencia,
                                                                    Logrado1 = l.Logrado1,
                                                                    Observacion = l.Observacion,
                                                                    PorcentajeCumplimiento = l.PorcentajeCumplimiento
                                                                }).FirstOrDefault()
                                              }).FirstOrDefault(),
                                   NombreIndicador = i.NombreIndicador,
                                   Proceso = i.Proceso,
                                   Responsables = i.Responsables
                               }).ToList();
            return indicadores;
        }

        // GET: api/Indicadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Indicadores>> GetIndicadores(int id)
        {
            var indicadores = await _context.Indicadores.FindAsync(id);

            if (indicadores == null)
            {
                return NotFound();
            }

            return indicadores;
        }

        // PUT: api/Indicadores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutIndicadores(int id, Indicadores indicadores)
        {
            if (id != indicadores.IdCodigoIndiador)
            {
                return BadRequest();
            }

            _context.Entry(indicadores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndicadoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Indicadores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<Indicadores>> PostIndicadores(Indicadores indicadores)
        {
            _context.Indicadores.Add(indicadores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndicadores", new { id = indicadores.IdCodigoIndiador }, indicadores);
        }

        // DELETE: api/Indicadores/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Indicadores>> DeleteIndicadores(int id)
        {
            var indicadores = await _context.Indicadores.FindAsync(id);
            if (indicadores == null)
            {
                return NotFound();
            }

            _context.Indicadores.Remove(indicadores);
            await _context.SaveChangesAsync();

            return indicadores;
        }

        private bool IndicadoresExists(int id)
        {
            return _context.Indicadores.Any(e => e.IdCodigoIndiador == id);
        }
    }
}
