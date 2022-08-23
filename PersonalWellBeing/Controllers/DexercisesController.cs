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
    public class DexercisesController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        public DexercisesController(PersonalWellBeingContext context)
        {
            _context = context;
        }

        // GET: api/<DexcercisesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dexercise>>> GetDexercises()
        {
            return await _context.Dexercises.ToListAsync();
        }

        // GET api/<DexcercisesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dexercise>> GetDexercises(int id)
        {
            var dexercises = await _context.Dexercises.FindAsync(id);
            if (dexercises == null)
            {
                return NotFound();
            }
            return dexercises;
        }

        // POST api/<DexcercisesController>
        [HttpPost]
        public async Task<ActionResult> PostDexercises(Dexercise dexercise)
        {
            _context.Dexercises.Add(dexercise);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDexercises", new { id = dexercise.ExercisesId }, dexercise);
        }

        // PUT api/<DexcercisesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDexercise(int id, Dexercise dexercise)
        {
            if(id!=dexercise.ExercisesId)
            {
                return BadRequest();
            }
            _context.Entry(dexercise).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!DexerciseExists(id))
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

        // DELETE api/<DexcercisesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDexercise(int id)
        {
            var dexercise = await _context.Dexercises.FindAsync(id);
            if (dexercise == null)
            {
                return NotFound();
            }
            _context.Dexercises.Remove(dexercise);
            await _context.SaveChangesAsync();
;
            return NoContent();
        }
        private bool DexerciseExists(int id)
        {
            return _context.Dexercises.Any(e=>e.ExercisesId==id);
        }
    }
}
