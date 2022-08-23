using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalWellBeing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PersonalWellBeing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DappointmentsController : ControllerBase
    {
        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public ActionResult Overview(int? id)
        {
            return Ok(id);
        }
        private readonly PersonalWellBeingContext _context;
        public DappointmentsController(PersonalWellBeingContext context)
        {
            _context = context;
        }
        // GET: api/Dappointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dappointment>>> GetDappointments()
        {
            return await _context.Dappointments.ToListAsync();
        }
        //GET:api/Dappointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dappointment>> GetDappointments(int appointmentID)
        {
            var dappointment = await _context.Dappointments.SingleOrDefaultAsync();
            if(appointmentID == 0)
            {
                return NotFound();
            }
            return dappointment;
        }
        //PUT 
        [HttpPut("{id}")]
        public async Task<ActionResult>PutDappointment(int appointmentID, Dappointment dappointment)
        {
            appointmentID = dappointment.AppointmentId;
            _context.Entry(dappointment).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!DappointmentExists(appointmentID))
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
        //POST : api/Dappointment
        [HttpPost]
        public async Task<ActionResult> PostDappointment(Dappointment dappointment)
        {
            _context.Dappointments.Add(dappointment);   
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDappointment", new { appointmentID = dappointment.AppointmentId }, dappointment);
            
        }
        //DELETE: api/Dappointment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDappointment(int appointmentID)
        {
            var dappointment = await _context.Dappointments.FindAsync(appointmentID);
            if(dappointment==null){
                return NotFound();
            }
            _context.Dappointments.Remove(dappointment);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        private bool DappointmentExists(int appointmentID)
        {
            return _context.Dappointments.Any(a => a.AppointmentId == appointmentID);
        }
    }

}
