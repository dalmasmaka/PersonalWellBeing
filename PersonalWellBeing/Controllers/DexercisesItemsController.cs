using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWellBeing.Models;

namespace PersonalWellBeing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DexercisesItemsController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;

        public DexercisesItemsController(PersonalWellBeingContext context)
        {
            _context = context;
        }

        // GET: api/DexercisesItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DexercisesItem>>> GetDexercisesItems()
        {
            return await _context.DexercisesItems.ToListAsync();
        }

        // GET: api/DexercisesItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DexercisesItem>> GetDexercisesItem(int id)
        {
            var dexercisesItem = await _context.DexercisesItems.FindAsync(id);

            if (dexercisesItem == null)
            {
                return NotFound();
            }

            return dexercisesItem;
        }

        // PUT: api/DexercisesItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDexercisesItem(int id, DexercisesItem dexercisesItem)
        {
            if (id != dexercisesItem.ExerciseItemId)
            {
                return BadRequest();
            }

            _context.Entry(dexercisesItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DexercisesItemExists(id))
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

        // POST: api/DexercisesItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DexercisesItem>> PostDexercisesItem(DexercisesItem dexercisesItem)
        {
            _context.DexercisesItems.Add(dexercisesItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDexercisesItem", new { id = dexercisesItem.ExerciseItemId }, dexercisesItem);
        }

        // DELETE: api/DexercisesItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDexercisesItem(int id)
        {
            var dexercisesItem = await _context.DexercisesItems.FindAsync(id);
            if (dexercisesItem == null)
            {
                return NotFound();
            }

            _context.DexercisesItems.Remove(dexercisesItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DexercisesItemExists(int id)
        {
            return _context.DexercisesItems.Any(e => e.ExerciseItemId == id);
        }
    }
}
