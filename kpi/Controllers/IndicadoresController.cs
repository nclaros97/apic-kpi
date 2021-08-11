using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kpi.Models;

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
        public async Task<ActionResult<IEnumerable<Indicadores>>> GetIndicadores()
        {
            return await _context.Indicadores.ToListAsync();
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
