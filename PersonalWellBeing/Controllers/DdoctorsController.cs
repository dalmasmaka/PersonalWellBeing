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
    public class DdoctorsController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        public DdoctorsController(PersonalWellBeingContext context)
        {
            _context = context;
        }
        // GET: api/<DdoctorsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ddoctor>>> GetDdoctors()
        {
            return await _context.Ddoctors.ToListAsync();
        }

        // GET api/<DdoctorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ddoctor>> GetDdoctors(int id)
        {
            var ddoctors = await _context.Ddoctors.FindAsync(id);
            if(ddoctors == null)
            {
                return NotFound();
            }
            return ddoctors;
        }

        // POST api/<DdoctorsController>
        [HttpPost]
        public async Task<ActionResult<Ddoctor>> PostDdoctors(Ddoctor ddoctor)
        {
            _context.Ddoctors.Add(ddoctor);
            _context.SaveChanges();
            return CreatedAtAction("GetDdoctors", new { id = ddoctor.DoctorId }, ddoctor);
        }   

        // PUT api/<DdoctorsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDdoctor(int id, Ddoctor ddoctor)
        {
            if(id!=ddoctor.DoctorId)
            {
                return BadRequest();
            }
            _context.Entry(ddoctor).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!DdoctorExists(id))
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

        // DELETE api/<DdoctorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDdoctors(int id)
        {
            var ddoctors = await _context.Ddoctors.FindAsync(id);
            if (ddoctors == null)
            {
                return NotFound();
            }
            _context.Ddoctors.Remove(ddoctors);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool DdoctorExists(int id)
        {
            return _context.Ddoctors.Any(e => e.DoctorId == id);
        }
    }
}
