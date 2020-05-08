using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevOpsTests.Data;
using DevOpsTests.Models;

namespace DevOpsTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeichlesController : ControllerBase
    {
        private readonly DevOpsTestsContext _context;

        public VeichlesController(DevOpsTestsContext context)
        {
            _context = context;
        }

        // GET: api/Veichles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veichle>>> GetVeichle()
        {
            return await _context.Veichle.ToListAsync();
        }

        // GET: api/Veichles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veichle>> GetVeichle(int id)
        {
            var veichle = await _context.Veichle.FindAsync(id);

            if (veichle == null)
            {
                return NotFound();
            }

            return veichle;
        }

        // PUT: api/Veichles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeichle(int id, Veichle veichle)
        {
            if (id != veichle.Id)
            {
                return BadRequest();
            }

            _context.Entry(veichle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeichleExists(id))
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

        // POST: api/Veichles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Veichle>> PostVeichle(Veichle veichle)
        {
            _context.Veichle.Add(veichle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeichle", new { id = veichle.Id }, veichle);
        }

        // DELETE: api/Veichles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Veichle>> DeleteVeichle(int id)
        {
            var veichle = await _context.Veichle.FindAsync(id);
            if (veichle == null)
            {
                return NotFound();
            }

            _context.Veichle.Remove(veichle);
            await _context.SaveChangesAsync();

            return veichle;
        }

        private bool VeichleExists(int id)
        {
            return _context.Veichle.Any(e => e.Id == id);
        }
    }
}
