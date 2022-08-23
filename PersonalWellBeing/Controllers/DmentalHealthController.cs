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
    public class DmentalHealthController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        public DmentalHealthController(PersonalWellBeingContext context)
        {
            _context = context;
        }
        // GET: api/<DmentalHealthController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmentalHealth>>> GetDmentalHealth()
        {
            return await _context.DmentalHealths.ToListAsync();
        }

        // GET api/<DmentalHealthController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmentalHealth>> GetDmentalHealth(int id)
        {
            var dmentalHealth = await _context.DmentalHealths.FindAsync(id);
            if(dmentalHealth == null){
                return NotFound();
            }
            return dmentalHealth;
        }

        // POST api/<DmentalHealthController>
        [HttpPost]
        public async Task<ActionResult<DmentalHealth>> PostDmentalHealth(DmentalHealth dmentalHealth)
        {
            _context.DmentalHealths.Add(dmentalHealth);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDmentalHealth", new { id = dmentalHealth.DoctorId }, dmentalHealth);
        }

        // PUT api/<DmentalHealthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DmentalHealthController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDmentalHealth(int id)
        {
            var dmentalHealth=await _context.DmentalHealths.FindAsync(id);
            if (dmentalHealth == null)
            {
                return NotFound();
            }
            _context.DmentalHealths.Remove(dmentalHealth);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        private bool DmentalhealthExists(int id)
        {
            return _context.DmentalHealths.Any(e=>e.DoctorId == id);
        }
    }
}
