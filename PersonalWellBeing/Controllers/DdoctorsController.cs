using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWellBeing.DTO;
using PersonalWellBeing.Models;
using PersonalWellBeing.Services;
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
        private readonly IMapper _mapper;
        private readonly ImageService _imageService;

        public DdoctorsController(PersonalWellBeingContext context, IMapper mapper, ImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
        }
        // GET: api/<DdoctorsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ddoctor>>> GetDdoctors()
        {
            return await _context.Ddoctors.ToListAsync();
        }

        // GET api/<DdoctorsController>/5
        [HttpGet("{id}", Name="GetDdoctors")]
        public async Task<ActionResult<Ddoctor>> GetDdoctors(int id)
        {
            var ddoctors = await _context.Ddoctors.FindAsync(id);
            if(ddoctors == null)
            {
                return NotFound();
            }
            return ddoctors;
        }

      
        // PUT api/<DdoctorsController>/5
        [Authorize(Roles ="Admin")]
        [HttpPut]
        public async Task<ActionResult<Ddoctor>> UpdateDdoctor([FromForm]UpdateDoctorDTO doctorDTO)
        {
            var ddoctor = await _context.Ddoctors.FindAsync(doctorDTO.DoctorId);
            if (ddoctor == null) return NotFound();
            _mapper.Map(doctorDTO, ddoctor);
            if (doctorDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(doctorDTO.File);
                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                if (!string.IsNullOrEmpty(ddoctor.PublicId)) 
                    await _imageService.DeleteImageAsync(ddoctor.PublicId);

                ddoctor.DoctorImg = imageResult.SecureUrl.ToString();
                ddoctor.PublicId = imageResult.PublicId;

            }
            var result=await _context.SaveChangesAsync()>0;
            if(result) return Ok(ddoctor);
            return BadRequest(new ProblemDetails { Title = "Problem updating the data" });
        }

        // DELETE api/<DdoctorsController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDdoctors(int id)
        {
            var ddoctor = await _context.Ddoctors.FindAsync(id);
            if (ddoctor == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(ddoctor.PublicId))
                await _imageService.DeleteImageAsync(ddoctor.PublicId);
            _context.Ddoctors.Remove(ddoctor);
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "Problem deleting the data" });
        }

        [Authorize(Roles  = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Ddoctor>>CreateProduct([FromForm]CreateDoctorDTO doctorDTO)
        {

            var ddoctor = _mapper.Map<Ddoctor>(doctorDTO);
            if (doctorDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(doctorDTO.File);
                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                ddoctor.DoctorImg = imageResult.SecureUrl.ToString();
                ddoctor.PublicId=imageResult.PublicId;

            }
            _context.Ddoctors.Add(ddoctor);
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return CreatedAtRoute("GetDdoctors", new { Id=ddoctor.DoctorId }, ddoctor);
            return BadRequest(new ProblemDetails { Title = "Problem creating new data" });
        }

    }
}
