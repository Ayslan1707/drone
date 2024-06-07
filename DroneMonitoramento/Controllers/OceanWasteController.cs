using DroneMonitoramento.Data;
using DroneMonitoramento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DroneMonitoramento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OceanWasteController : ControllerBase
    {
        private readonly DroneContext _context;

        public OceanWasteController(DroneContext context)
        {
            _context = context;
        }

        // GET: api/OceanWaste
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OceanWaste>>> GetOceanWastes()
        {
            return await _context.OceanWastes.ToListAsync();
        }

        // GET: api/OceanWaste/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OceanWaste>> GetOceanWaste(int id)
        {
            var oceanWaste = await _context.OceanWastes.FindAsync(id);

            if (oceanWaste == null)
            {
                return NotFound();
            }

            return oceanWaste;
        }

        // PUT: api/OceanWaste/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOceanWaste(int id, OceanWaste oceanWaste)
        {
            if (id != oceanWaste.Id)
            {
                return BadRequest();
            }

            _context.Entry(oceanWaste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OceanWasteExists(id))
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

        // POST: api/OceanWaste
        [HttpPost]
        public async Task<ActionResult<OceanWaste>> PostOceanWaste(OceanWaste oceanWaste)
        {
            _context.OceanWastes.Add(oceanWaste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOceanWaste", new { id = oceanWaste.Id }, oceanWaste);
        }

        // DELETE: api/OceanWaste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOceanWaste(int id)
        {
            var oceanWaste = await _context.OceanWastes.FindAsync(id);
            if (oceanWaste == null)
            {
                return NotFound();
            }

            _context.OceanWastes.Remove(oceanWaste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OceanWasteExists(int id)
        {
            return _context.OceanWastes.Any(e => e.Id == id);
        }
    }
}
