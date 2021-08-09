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
    public class SubObjetivosController : ControllerBase
    {
        private readonly kpiContext _context;

        public SubObjetivosController(kpiContext context)
        {
            _context = context;
        }

        // GET: api/SubObjetivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subobjetivos>>> GetSubobjetivos()
        {
            return await _context.Subobjetivos.ToListAsync();
        }

        // GET: api/SubObjetivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subobjetivos>> GetSubobjetivos(int id)
        {
            var subobjetivos = await _context.Subobjetivos.FindAsync(id);

            if (subobjetivos == null)
            {
                return NotFound();
            }

            return subobjetivos;
        }

        // PUT: api/SubObjetivos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutSubobjetivos(int id, Subobjetivos subobjetivos)
        {
            if (id != subobjetivos.IdSubobjetivos)
            {
                return BadRequest();
            }

            _context.Entry(subobjetivos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubobjetivosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubobjetivos", new { id = subobjetivos.IdSubobjetivos }, subobjetivos);  
        }

        // POST: api/SubObjetivos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<Subobjetivos>> PostSubobjetivos(Subobjetivos subobjetivos)
        {
            _context.Subobjetivos.Add(subobjetivos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubobjetivos", new { id = subobjetivos.IdSubobjetivos }, subobjetivos);
        }

        // DELETE: api/SubObjetivos/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Subobjetivos>> DeleteSubobjetivos(int id)
        {
            var subobjetivos = await _context.Subobjetivos.FindAsync(id);
            if (subobjetivos == null)
            {
                return NotFound();
            }

            _context.Subobjetivos.Remove(subobjetivos);
            await _context.SaveChangesAsync();

            return subobjetivos;
        }

        private bool SubobjetivosExists(int id)
        {
            return _context.Subobjetivos.Any(e => e.IdSubobjetivos == id);
        }
    }
}
