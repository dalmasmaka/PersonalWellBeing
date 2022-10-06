using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWellBeing.DTO;
using PersonalWellBeing.Models;
using PersonalWellBeing.Services;

namespace PersonalWellBeing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DyogaItemsController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        private readonly IMapper _mapper;
        private readonly ImageService _imageService;

        public DyogaItemsController(PersonalWellBeingContext context, IMapper mapper, ImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
        }

        // GET: api/DyogaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DyogaItem>>> GetDyogaItems()
        {
            return await _context.DyogaItems.ToListAsync();
        }

        // GET: api/DyogaItems/5
        [HttpGet("{id}", Name = "GetDyogaItems")]
        public async Task<ActionResult<DyogaItem>> GetDyogaItems(int id)
        {
            var dyogaItem = await _context.DyogaItems.FindAsync(id);

            if (dyogaItem == null)
            {
                return NotFound();
            }

            return dyogaItem;
        }

        // PUT: api/DyogaItems/5
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<DyogaItem>> UpdateYoga([FromForm]UpdateYogaItemDTO yogaItemDTO)
        {
            var dyoga = await _context.DyogaItems.FindAsync(yogaItemDTO.YogaItemId);
            if (dyoga == null) return NotFound();
            _mapper.Map(yogaItemDTO, dyoga);
            if (yogaItemDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(yogaItemDTO.File);
                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                if (!string.IsNullOrEmpty(dyoga.PublicId))
                    await _imageService.DeleteImageAsync(dyoga.PublicId);

                dyoga.YogaItemImg = imageResult.SecureUrl.ToString();
                dyoga.PublicId = imageResult.PublicId;

            }
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok(dyoga);
            return BadRequest(new ProblemDetails { Title = "Problem updating the data" });

        }

        // POST: api/DyogaItems

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<DyogaItem>> PostDyogaItem([FromForm] CreateYogaItemDTO yogaItemDTO)
        {
            var dyoga = _mapper.Map<DyogaItem>(yogaItemDTO);
            if (yogaItemDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(yogaItemDTO.File);
                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                dyoga.YogaItemImg = imageResult.SecureUrl.ToString();
                dyoga.PublicId = imageResult.PublicId;

            }
            _context.DyogaItems.Add(dyoga);
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return CreatedAtRoute("GetDyogaItems", new { Id = dyoga.YogaItemId }, dyoga);
            return BadRequest(new ProblemDetails { Title = "Problem creating new data" });
        }

        // DELETE: api/DyogaItems/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDyogaItem(int id)
        {
            var dyogaItem = await _context.DyogaItems.FindAsync(id);
            if (dyogaItem == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(dyogaItem.PublicId))
                await _imageService.DeleteImageAsync(dyogaItem.PublicId);

            _context.DyogaItems.Remove(dyogaItem);
            var result = await _context.SaveChangesAsync()>0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "Problem deleting data" });
        }
    }
}
