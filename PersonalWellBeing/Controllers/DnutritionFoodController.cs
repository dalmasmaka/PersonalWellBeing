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
    public class DnutritionFoodController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        public DnutritionFoodController(PersonalWellBeingContext context)
        {
            _context = context;
        }
        

        // GET: api/<DnutritionFoodController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DnutritionFood>>> GetDnutritionFood()
        {
            return await _context.DnutritionFoods.ToListAsync();
        }

        // GET api/<DnutritionFoodController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DnutritionFood>> GetDnutritionFood(int id)
        {
            var dnutritionFood = await _context.DnutritionFoods.FindAsync(id);
            if (dnutritionFood == null)
            {
                return NotFound();
            }
            return dnutritionFood;
        }

        // POST api/<DnutritionFoodController>
        [HttpPost]
        public async Task<ActionResult<DnutritionFood>> PostDnutritionFood(DnutritionFood dnutritionFood)
        {
            _context.DnutritionFoods.Add(dnutritionFood);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDnutritionFood", new { id = dnutritionFood.NutritionFoodId }, dnutritionFood);
        }

        // PUT api/<DnutritionFoodController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDnutritionFood(int id, DnutritionFood dnutritionFood)
        {
            if (id != dnutritionFood.NutritionFoodId)
            {
                return BadRequest();
            }
            _context.Entry(dnutritionFood).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DnutritionFoodExists(id))
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
        private bool DnutritionFoodExists(int id)
        {
            return _context.DnutritionFoods.Any(e=>e.NutritionFoodId==id);
        }

        // DELETE api/<DnutritionFoodController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDnutritionFood(int id)
        {
            var dnutritionFood = await _context.DnutritionFoods.FindAsync(id);
            if (dnutritionFood == null)
            {
                return NotFound();
            }
            _context.DnutritionFoods.Remove(dnutritionFood);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
