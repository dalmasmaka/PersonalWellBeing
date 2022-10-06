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
    public class DsleepHygieneController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        private readonly IMapper _mapper;
        private readonly ImageService _imageService;
        public DsleepHygieneController(PersonalWellBeingContext context, IMapper mapper, ImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
        }

        // GET: api/<DsleepHygieneController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DsleepHygiene>>> GetDsleepHygiene()
        {
            return await _context.DsleepHygienes.ToListAsync();
        }

        // GET api/<DsleepHygieneController>/5
        [HttpGet("{id}", Name = " GetDsleepHygiene")]
        public async Task<ActionResult<DsleepHygiene>> GetDsleepHygiene(int id)
        {
            var dsleepHygiene = await _context.DsleepHygienes.FindAsync(id);
            if (dsleepHygiene == null)
            {
                return NotFound();
            }
            return dsleepHygiene;
        }

        // POST api/<DsleepHygieneController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<DsleepHygiene>> CreateSleepForm([FromForm] CreateSleepDTO sleepDTO)
        {
            var dsleep = _mapper.Map<DsleepHygiene>(sleepDTO);
            if (sleepDTO != null)
            {
                var imageResult = await _imageService.AddImageAsync(sleepDTO.File);
                if (imageResult.Error != null) 
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });
                dsleep.SleepingHygieneImg = imageResult.SecureUrl.ToString();
                dsleep.PublicId = imageResult.PublicId;
            }
            _context.DsleepHygienes.Add(dsleep);
            var result = await _context.SaveChangesAsync()>0;
            if(result)return CreatedAtAction("GetDsleepHygiene", new { id=dsleep.SleepHygieneId }, dsleep);
            return BadRequest(new ProblemDetails { Title = "Problem creating new data"});
        }

        // PUT api/<DsleepHygieneController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<DsleepHygiene>> PutDsleepHygiene([FromForm]UpdateSleepDTO sleepDTO)
        {
            var dsleep = await _context.DsleepHygienes.FindAsync(sleepDTO.SleepHygieneId);
            if (dsleep == null) return NotFound();
            _mapper.Map(sleepDTO, dsleep);
            if (sleepDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(sleepDTO.File);

                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message }); 

                if(!string.IsNullOrEmpty(dsleep.PublicId))
                    await _imageService.DeleteImageAsync(dsleep.PublicId);

                dsleep.SleepingHygieneImg = imageResult.SecureUrl.ToString();
                dsleep.PublicId = imageResult.PublicId;
            }
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok(dsleep);
            return BadRequest(new ProblemDetails { Title = "Problem updating the data" });
        }

        // DELETE api/<DsleepHygieneController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDsleepHygiene(int id)
        {
            var dsleephygiene = await _context.DsleepHygienes.FindAsync(id);
            if (dsleephygiene == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(dsleephygiene.PublicId))
                await _imageService.DeleteImageAsync(dsleephygiene.PublicId);
            _context.DsleepHygienes.Remove(dsleephygiene);
            var result= await _context.SaveChangesAsync()>0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "Problem deleting the data" });
        }
    }
}
