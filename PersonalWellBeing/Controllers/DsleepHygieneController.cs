using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWellBeing.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalWellBeing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DsleepHygieneController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        public DsleepHygieneController(PersonalWellBeingContext context)
        {
            _context = context;
        }

        // GET: api/<DsleepHygieneController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DsleepHygiene>>> GetDsleepHygiene()
        {
            return await _context.DsleepHygienes.ToListAsync();
        }

        // GET api/<DsleepHygieneController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DsleepHygiene>> GetDsleepHygiene(int id)
        {
            var dsleepHygiene = await _context.DsleepHygienes.FindAsync(id);
            if (dsleepHygiene == null)
            {
                return NotFound();
            }
            return dsleepHygiene;
        }

        // POST api/<DsleepHygieneController>
        [HttpPost]
        public async Task<ActionResult<DsleepHygiene>> PostDsleepHygiene(DsleepHygiene dsleepHygiene)
        {
            _context.DsleepHygienes.Add(dsleepHygiene);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDsleepHygiene", new { id = dsleepHygiene.SleepHygieneId }, dsleepHygiene);
        }

        // PUT api/<DsleepHygieneController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDsleepHygiene(int id, DsleepHygiene dsleephygiene)
        {
            if (id != dsleephygiene.SleepHygieneId)
            {
                return BadRequest();
            }
            _context.Entry(dsleephygiene).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!DsleepHygieneExists(id))
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

        // DELETE api/<DsleepHygieneController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDsleepHygiene(int id)
        {
            var dsleephygiene = await _context.DsleepHygienes.FindAsync(id);
            if (dsleephygiene == null)
            {
                return NotFound();
            }
            _context.DsleepHygienes.Remove(dsleephygiene);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool DsleepHygieneExists(int id)
        {
            return _context.DsleepHygienes.Any(e => e.SleepHygieneId == id);
        }
    }
}
