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
    public class DyogaItemsController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;

        public DyogaItemsController(PersonalWellBeingContext context)
        {
            _context = context;
        }

        // GET: api/DyogaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DyogaItem>>> GetDyogaItems()
        {
            return await _context.DyogaItems.ToListAsync();
        }

        // GET: api/DyogaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DyogaItem>> GetDyogaItem(int id)
        {
            var dyogaItem = await _context.DyogaItems.FindAsync(id);

            if (dyogaItem == null)
            {
                return NotFound();
            }

            return dyogaItem;
        }

        // PUT: api/DyogaItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDyogaItem(int id, DyogaItem dyogaItem)
        {
            if (id != dyogaItem.YogaItemId)
            {
                return BadRequest();
            }

            _context.Entry(dyogaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DyogaItemExists(id))
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

        // POST: api/DyogaItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DyogaItem>> PostDyogaItem(DyogaItem dyogaItem)
        {
            _context.DyogaItems.Add(dyogaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDyogaItem", new { id = dyogaItem.YogaItemId }, dyogaItem);
        }

        // DELETE: api/DyogaItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDyogaItem(int id)
        {
            var dyogaItem = await _context.DyogaItems.FindAsync(id);
            if (dyogaItem == null)
            {
                return NotFound();
            }

            _context.DyogaItems.Remove(dyogaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DyogaItemExists(int id)
        {
            return _context.DyogaItems.Any(e => e.YogaItemId == id);
        }
    }
}
