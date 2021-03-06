using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kpi.Models;
using kpi.Dtos;
using kpi.Dtos.Areas;
using kpi.Dtos.Agencias;

namespace kpi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaAgenciasController : ControllerBase
    {
        private readonly kpiContext _context;

        public AreaAgenciasController(kpiContext context)
        {
            _context = context;
        }

        // GET: api/AreaAgencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaAgencia>>> GetAreaAgencia()
        {
            return await _context.AreaAgencia.ToListAsync();
        }

        // GET: api/AreaAgencias/selectBox
        [HttpGet("selectBox")]
        public async Task<ActionResult<IEnumerable<AreaAgenciaDto>>> GetAreaAgenciaSelectBox()
        {
            var areaAgenciasDb = await _context.AreaAgencia.ToListAsync();
            var areasAgencias = (from x in areaAgenciasDb.ToList()
                                 where x.IdAreaAgencia == x.IdAreaAgencia
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
                                 }).ToList();

            return areasAgencias;
        }

        // GET: api/AreaAgencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaAgencia>> GetAreaAgencia(int id)
        {
            var areaAgencia = await _context.AreaAgencia.FindAsync(id);

            if (areaAgencia == null)
            {
                return NotFound();
            }

            return areaAgencia;
        }

        // PUT: api/AreaAgencias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutAreaAgencia(int id, AreaAgencia areaAgencia)
        {
            if (id != areaAgencia.IdAreaAgencia)
            {
                return BadRequest();
            }

            _context.Entry(areaAgencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaAgenciaExists(id))
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

        // POST: api/AreaAgencias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<AreaAgencia>> PostAreaAgencia(AreaAgencia areaAgencia)
        {
            _context.AreaAgencia.Add(areaAgencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAreaAgencia", new { id = areaAgencia.IdAreaAgencia }, areaAgencia);
        }

        // DELETE: api/AreaAgencias/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AreaAgencia>> DeleteAreaAgencia(int id)
        {
            var areaAgencia = await _context.AreaAgencia.FindAsync(id);
            if (areaAgencia == null)
            {
                return NotFound();
            }

            _context.AreaAgencia.Remove(areaAgencia);
            await _context.SaveChangesAsync();

            return areaAgencia;
        }

        private bool AreaAgenciaExists(int id)
        {
            return _context.AreaAgencia.Any(e => e.IdAreaAgencia == id);
        }
    }
}
