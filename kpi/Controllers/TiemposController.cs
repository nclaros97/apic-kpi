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
    public class TiemposController : ControllerBase
    {
        private readonly kpiContext _context;

        public TiemposController(kpiContext context)
        {
            _context = context;
        }

        // GET: api/Tiempos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiempo>>> GetTiempo()
        {
            return await _context.Tiempo.ToListAsync();
        }

        // GET: api/Tiempos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tiempo>> GetTiempo(int id)
        {
            var tiempo = await _context.Tiempo.FindAsync(id);

            if (tiempo == null)
            {
                return NotFound();
            }

            return tiempo;
        }

        // PUT: api/Tiempos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutTiempo(int id, Tiempo tiempo)
        {
            if (id != tiempo.IdTiempo)
            {
                return BadRequest();
            }

            _context.Entry(tiempo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiempoExists(id))
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

        // POST: api/Tiempos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<Tiempo>> PostTiempo(Tiempo tiempo)
        {
            _context.Tiempo.Add(tiempo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiempo", new { id = tiempo.IdTiempo }, tiempo);
        }

        // DELETE: api/Tiempos/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Tiempo>> DeleteTiempo(int id)
        {
            var tiempo = await _context.Tiempo.FindAsync(id);
            if (tiempo == null)
            {
                return NotFound();
            }

            _context.Tiempo.Remove(tiempo);
            await _context.SaveChangesAsync();

            return tiempo;
        }

        private bool TiempoExists(int id)
        {
            return _context.Tiempo.Any(e => e.IdTiempo == id);
        }
    }
}
