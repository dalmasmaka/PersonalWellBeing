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
    public class DmenuListController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        public DmenuListController(PersonalWellBeingContext context)
        {
            _context = context;
        }

        // GET: api/<DmenuListController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmenuList>>> GetDmenuList()
        {
            return await _context.DmenuLists.ToListAsync();
        }

        // GET api/<DmenuListController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmenuList>> GetDmenuList(int id)
        {
            var dmenuList=await _context.DmenuLists.FindAsync(id);
            if(dmenuList == null)
            {
                return NotFound();
            }
            return dmenuList;
        }

        // POST api/<DmenuListController>
        [HttpPost]
        public async Task<ActionResult<DmenuList>> PostDmenuList(DmenuList dmenuList)
        {
            _context.DmenuLists.Add(dmenuList);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDmenuList", new { id = dmenuList.MenuListId }, dmenuList);
        }

        // PUT api/<DmenuListController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDmenuList(int id, DmenuList dmenuList)
        {
            if(id!=dmenuList.MenuListId)
            {
                return BadRequest();
            }
            _context.Entry(dmenuList).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!DmenuListExists(id))
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
        private bool DmenuListExists(int id)
        {
            return  _context.DmenuLists.Any(e => e.MenuListId == id);
        }

        // DELETE api/<DmenuListController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDmenuList(int id)
        {
            var dmenuList = await _context.DmenuLists.FindAsync(id);
            if (dmenuList == null)
            {
                return NoContent();
            }
            _context.DmenuLists.Remove(dmenuList);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
