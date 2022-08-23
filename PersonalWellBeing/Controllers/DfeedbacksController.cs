using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWellBeing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalWellBeing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DfeedbacksController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        public DfeedbacksController(PersonalWellBeingContext context)
        {
            _context = context;
        }

        // GET: api/<DfeedbacksController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dfeedback>>> GetDfeedback()
        {
            return await _context.Dfeedbacks.ToListAsync();
        }

        // GET api/<DfeedbacksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dfeedback>> GetDfeedback(int id)
        {
            var dfeedback = await _context.Dfeedbacks.FindAsync(id);
            if(dfeedback == null)
            {
                return NotFound();
            }
            return dfeedback;
        }

        // POST api/<DfeedbacksController>
        [HttpPost]
        public async Task<ActionResult<Dfeedback>> PostDfeedback(Dfeedback dfeedback)
        {
            _context.Dfeedbacks.Add(dfeedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDfeedback", new { id = dfeedback.FeedbackId }, dfeedback);
        }

        // PUT api/<DfeedbacksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDfeedback(int id, Dfeedback dfeedback)
        {
            if (id != dfeedback.FeedbackId)
            {
                return BadRequest();
            }
            _context.Entry(dfeedback).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DfeedbackExists(id))
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

        private  bool DfeedbackExists(int id)
        {
            return _context.Dfeedbacks.Any(e => e.FeedbackId == id);
        }

        // DELETE api/<DfeedbacksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDfeedback(int id)
        {
            var dfeedback = await _context.Dfeedbacks.FindAsync(id);
            if (dfeedback == null)
            {
                return NotFound();
            }
            _context.Remove(dfeedback);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
