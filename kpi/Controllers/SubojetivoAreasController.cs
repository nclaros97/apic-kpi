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
    public class SubojetivoAreasController : ControllerBase
    {
        private readonly kpiContext _context;

        public SubojetivoAreasController(kpiContext context)
        {
            _context = context;
        }

        // GET: api/SubojetivoAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubojetivoArea>>> GetSubojetivoArea()
        {
            return await _context.SubojetivoArea.ToListAsync();
        }

        // GET: api/SubojetivoAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubojetivoArea>> GetSubojetivoArea(int id)
        {
            var subojetivoArea = await _context.SubojetivoArea.FindAsync(id);

            if (subojetivoArea == null)
            {
                return NotFound();
            }

            return subojetivoArea;
        }

        // PUT: api/SubojetivoAreas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutSubojetivoArea(int id, SubojetivoArea subojetivoArea)
        {
            if (id != subojetivoArea.IdSubobjetivos)
            {
                return BadRequest();
            }

            _context.Entry(subojetivoArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubojetivoAreaExists(id))
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

        // POST: api/SubojetivoAreas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<SubojetivoArea>> PostSubojetivoArea(SubojetivoArea subojetivoArea)
        {
            _context.SubojetivoArea.Add(subojetivoArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubojetivoArea", new { id = subojetivoArea.IdSubobjetivos }, subojetivoArea);
        }

        // DELETE: api/SubojetivoAreas/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<SubojetivoArea>> DeleteSubojetivoArea(int id)
        {
            var subojetivoArea = await _context.SubojetivoArea.FindAsync(id);
            if (subojetivoArea == null)
            {
                return NotFound();
            }

            _context.SubojetivoArea.Remove(subojetivoArea);
            await _context.SaveChangesAsync();

            return subojetivoArea;
        }

        private bool SubojetivoAreaExists(int id)
        {
            return _context.SubojetivoArea.Any(e => e.IdSubobjetivos == id);
        }
    }
}
