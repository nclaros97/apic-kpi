using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kpi.Models;
using kpi.Services.Objetivos;
using kpi.Dtos.Objetivos;

namespace kpi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoesController : ControllerBase
    {
        private readonly kpiContext _context;
        private readonly ObjetivosServices _objetivosServices;

        public ObjetivoesController(kpiContext context, ObjetivosServices objetivosServices)
        {
            _context = context;
            _objetivosServices = objetivosServices;
        }

        // GET: api/Objetivoes
        [HttpGet]
        public async Task<ActionResult<List<Objetivo>>> GetObjetivo()
        {
            return await _objetivosServices.GetObjetivos();
        }

        // GET: api/Objetivoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objetivo>> GetObjetivo(int id)
        {
            var objetivo = await _context.Objetivo.FindAsync(id);

            if (objetivo == null)
            {
                return NotFound();
            }

            return objetivo;
        }

        // PUT: api/Objetivoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutObjetivo(int id, Objetivo objetivo)
        {
            if (id != objetivo.IdObjetivo)
            {
                return BadRequest();
            }

            _context.Entry(objetivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetivoExists(id))
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

        // POST: api/Objetivoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<Objetivo>> PostObjetivo(Objetivo objetivo)
        {
            _context.Objetivo.Add(objetivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjetivo", new { id = objetivo.IdObjetivo }, objetivo);
        }

        // DELETE: api/Objetivoes/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Objetivo>> DeleteObjetivo(int id)
        {
            var objetivo = await _context.Objetivo.FindAsync(id);
            if (objetivo == null)
            {
                return NotFound();
            }

            _context.Objetivo.Remove(objetivo);
            await _context.SaveChangesAsync();

            return objetivo;
        }

        private bool ObjetivoExists(int id)
        {
            return _context.Objetivo.Any(e => e.IdObjetivo == id);
        }
    }
}
