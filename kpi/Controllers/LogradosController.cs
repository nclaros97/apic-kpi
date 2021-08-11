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
    public class LogradosController : ControllerBase
    {
        private readonly kpiContext _context;

        public LogradosController(kpiContext context)
        {
            _context = context;
        }

        // GET: api/Logrados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Logrado>>> GetLogrado()
        {
            return await _context.Logrado.ToListAsync();
        }

        // GET: api/Logrados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Logrado>> GetLogrado(int id)
        {
            var logrado = await _context.Logrado.FindAsync(id);

            if (logrado == null)
            {
                return NotFound();
            }

            return logrado;
        }

        // PUT: api/Logrados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutLogrado(int id, Logrado logrado)
        {
            if (id != logrado.IdCodigoIndiador)
            {
                return BadRequest();
            }

            _context.Entry(logrado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogradoExists(id))
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

        // POST: api/Logrados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<Logrado>> PostLogrado(Logrado logrado)
        {
            _context.Logrado.Add(logrado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogrado", new { id = logrado.IdCodigoIndiador }, logrado);
        }

        // DELETE: api/Logrados/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Logrado>> DeleteLogrado(int id)
        {
            var logrado = await _context.Logrado.FindAsync(id);
            if (logrado == null)
            {
                return NotFound();
            }

            _context.Logrado.Remove(logrado);
            await _context.SaveChangesAsync();

            return logrado;
        }

        private bool LogradoExists(int id)
        {
            return _context.Logrado.Any(e => e.IdCodigoIndiador == id);
        }
    }
}
