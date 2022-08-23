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
    public class DnutritionFooodItemsController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;

        public DnutritionFooodItemsController(PersonalWellBeingContext context)
        {
            _context = context;
        }

        // GET: api/DnutritionFooodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DnutritionFooodItem>>> GetDnutritionFooodItems()
        {
            return await _context.DnutritionFooodItems.ToListAsync();
        }

        // GET: api/DnutritionFooodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DnutritionFooodItem>> GetDnutritionFooodItem(int id)
        {
            var dnutritionFooodItem = await _context.DnutritionFooodItems.FindAsync(id);

            if (dnutritionFooodItem == null)
            {
                return NotFound();
            }

            return dnutritionFooodItem;
        }

        // PUT: api/DnutritionFooodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDnutritionFooodItem(int id, DnutritionFooodItem dnutritionFooodItem)
        {
            if (id != dnutritionFooodItem.NutritionFoodItemId)
            {
                return BadRequest();
            }

            _context.Entry(dnutritionFooodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DnutritionFooodItemExists(id))
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

        // POST: api/DnutritionFooodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DnutritionFooodItem>> PostDnutritionFooodItem(DnutritionFooodItem dnutritionFooodItem)
        {
            _context.DnutritionFooodItems.Add(dnutritionFooodItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDnutritionFooodItem", new { id = dnutritionFooodItem.NutritionFoodItemId }, dnutritionFooodItem);
        }

        // DELETE: api/DnutritionFooodItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDnutritionFooodItem(int id)
        {
            var dnutritionFooodItem = await _context.DnutritionFooodItems.FindAsync(id);
            if (dnutritionFooodItem == null)
            {
                return NotFound();
            }

            _context.DnutritionFooodItems.Remove(dnutritionFooodItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DnutritionFooodItemExists(int id)
        {
            return _context.DnutritionFooodItems.Any(e => e.NutritionFoodItemId == id);
        }
    }
}
