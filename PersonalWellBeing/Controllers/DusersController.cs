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
    public class DusersController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        public DusersController(PersonalWellBeingContext context)
        {
            _context = context;
        }

        // GET: api/<DusersController>
        [HttpGet]
 
        public async Task<ActionResult<IEnumerable<Duser>>> GetDuser()
        {
            return await _context.Dusers.ToListAsync();
        }

        // GET api/<DusersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Duser>>GetDuser(int id)
        {
            var duser = await _context.Dusers.FindAsync(id);
            if (duser == null)
            {
                return NotFound();
            }
            return duser;
        }

        // POST api/<DusersController>
        [HttpPost]
        public async Task<ActionResult<Duser>> PostDuser(Duser duser)
        {
            _context.Dusers.Add(duser);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDuser", new { id = duser.UserId }, duser);
        }

        // PUT api/<DusersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuser(int id, Duser duser)
        {
            if (id != duser.UserId)
            {
                return BadRequest();
            }
            _context.Entry(duser).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuserExists(id))
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

        // DELETE api/<DusersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuser(int id)
        {
            var duser = await _context.Dusers.FindAsync(id);
            if(duser == null)
            {
                return NotFound();
            }
            _context.Dusers.Remove(duser);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool DuserExists(int id)
        {
            return _context.Dusers.Any(e => e.UserId == id);
        }
    }
}
