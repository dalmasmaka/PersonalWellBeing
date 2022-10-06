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
    public class DexercisesItemsController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        private readonly IMapper _mapper;
        private readonly ImageService _imageService;

        public DexercisesItemsController(PersonalWellBeingContext context, IMapper mapper, ImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
        }

        // GET: api/DexercisesItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DexercisesItem>>> GetDexercisesItems()
        {
            return await _context.DexercisesItems.ToListAsync();
        }

        // GET: api/DexercisesItems/5
        [HttpGet("{id}", Name = "GetDexercisesItem")]
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
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<DexercisesItem>> UpdateExercises([FromForm] UpdateExercisesItemsDTO exercisesItemsDTO)
        {
            var dexercises = await _context.DexercisesItems.FindAsync(exercisesItemsDTO.ExerciseItemId);
            if (dexercises == null) return NotFound();
            _mapper.Map(exercisesItemsDTO, dexercises);
            if( exercisesItemsDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(exercisesItemsDTO.File);
                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                if (!string.IsNullOrEmpty(dexercises.PublicId))
                    await _imageService.DeleteImageAsync(dexercises.PublicId);

                dexercises.ExerciseItemImg = imageResult.SecureUrl.ToString();
                dexercises.PublicId = imageResult.PublicId;

            }
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok(dexercises);
            return BadRequest(new ProblemDetails { Title = "Problem updating the data" });
        }

        // POST: api/DexercisesItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<DexercisesItem>> PostDexercisesItem([FromForm]CreateExercisesItemsDTO exercisesItemsDTO)
        {
            var dexercisesItem = _mapper.Map<DexercisesItem>(exercisesItemsDTO);
            if (exercisesItemsDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(exercisesItemsDTO.File);
                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });
                dexercisesItem.ExerciseItemImg = imageResult.SecureUrl.ToString();
                dexercisesItem.PublicId = imageResult.PublicId;
            }
            _context.DexercisesItems.Add(dexercisesItem);
            var result= await _context.SaveChangesAsync()>0;
            if (result) return CreatedAtRoute("GetDexercisesItem", new { id = dexercisesItem.ExerciseItemId }, dexercisesItem);
            return BadRequest(new ProblemDetails { Title = "Problem creating new data" });
        }

        // DELETE: api/DexercisesItems/5
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDexercisesItem(int id)
        {
            var dexercisesItem = await _context.DexercisesItems.FindAsync(id);
            if (dexercisesItem == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(dexercisesItem.PublicId))
                await _imageService.DeleteImageAsync(dexercisesItem.PublicId);

            _context.DexercisesItems.Remove(dexercisesItem);
            var result = await _context.SaveChangesAsync()>0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "Problem deleting the data" });
        }
    }
}
