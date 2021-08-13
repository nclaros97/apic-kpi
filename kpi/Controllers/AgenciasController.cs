using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kpi.Models;
using kpi.Services.Agencias;
using kpi.Dtos.Agencias;

namespace kpi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly kpiContext _context;
        private readonly AgenciasServices _agenciasServices;

        public AgenciasController(kpiContext context, AgenciasServices agenciasServices)
        {
            _context = context;
            _agenciasServices = agenciasServices;
        }

        // GET: api/Agencias
        [HttpGet]
        public ActionResult<IEnumerable<AgenciaDto>> GetAgencia()
        {
            
            return _agenciasServices.GetAgencias();
        }

        // GET: api/Agencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencia>> GetAgencia(int id)
        {
            var agencia = await _context.Agencia.FindAsync(id);

            if (agencia == null)
            {
                return NotFound();
            }

            return agencia;
        }

        // PUT: api/Agencias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutAgencia(int id, Agencia agencia)
        {
            if (id != agencia.IdAgencia)
            {
                return BadRequest();
            }

            _context.Entry(agencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenciaExists(id))
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

        // POST: api/Agencias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<Agencia>> PostAgencia(Agencia agencia)
        {
            _context.Agencia.Add(agencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgencia", new { id = agencia.IdAgencia }, agencia);
        }

        // DELETE: api/Agencias/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Agencia>> DeleteAgencia(int id)
        {
            var agencia = await _context.Agencia.FindAsync(id);
            if (agencia == null)
            {
                return NotFound();
            }

            _context.Agencia.Remove(agencia);
            await _context.SaveChangesAsync();

            return agencia;
        }

        private bool AgenciaExists(int id)
        {
            return _context.Agencia.Any(e => e.IdAgencia == id);
        }
    }
}
