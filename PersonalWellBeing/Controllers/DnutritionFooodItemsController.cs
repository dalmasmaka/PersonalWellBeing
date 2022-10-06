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
    public class DnutritionFooodItemsController : ControllerBase
    {
        private readonly PersonalWellBeingContext _context;
        private readonly IMapper _mapper;
        private readonly ImageService _imageService;


        public DnutritionFooodItemsController(PersonalWellBeingContext context, IMapper mapper, ImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
        }

        // GET: api/DnutritionFooodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DnutritionFooodItem>>> GetDnutritionFooodItems()
        {
            return await _context.DnutritionFooodItems.ToListAsync();
        }

        // GET: api/DnutritionFooodItems/5
        [HttpGet("{id}", Name = "GetDnutritionFooodItem")]
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
        [Authorize (Roles ="Admin")]
        [HttpPut]
        public async Task<ActionResult<DnutritionFooodItem>> UpdateFoodItem([FromForm]UpdateFoodItemDTO foodItemDTO)
        {
            var dfood = await _context.DnutritionFooodItems.FindAsync(foodItemDTO.NutritionFoodItemId);
            if (dfood == null) return NotFound();
            _mapper.Map(foodItemDTO, dfood);
            if( foodItemDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(foodItemDTO.File);
                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                if (!string.IsNullOrEmpty(dfood.PublicId))
                    await _imageService.DeleteImageAsync(dfood.PublicId);

                dfood.NutritionFoodItemImg = imageResult.SecureUrl.ToString();
                dfood.PublicId = imageResult.PublicId;

            }
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok(dfood);
            return BadRequest(new ProblemDetails { Title = "Problem updating the data" });
        }

        // POST: api/DnutritionFooodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<DnutritionFooodItem>> PostDnutritionFooodItem([FromForm]CreateFoodItemDTO foodItemDTO)
        {
            var dfood = _mapper.Map<DnutritionFooodItem>(foodItemDTO);
            if (foodItemDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(foodItemDTO.File);
                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                dfood.NutritionFoodItemImg = imageResult.SecureUrl.ToString();
                dfood.PublicId = imageResult.PublicId;

            }

            _context.DnutritionFooodItems.Add(dfood);
            var result = await _context.SaveChangesAsync()>0;
            if(result) return CreatedAtAction("GetDnutritionFooodItem", new { id = dfood.NutritionFoodItemId }, dfood);
            return BadRequest(new ProblemDetails { Title = "Problem creating new data" });
        }

        // DELETE: api/DnutritionFooodItems/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDnutritionFooodItem(int id)
        {
            var dfood = await _context.DnutritionFooodItems.FindAsync(id);
            if (dfood == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(dfood.PublicId))
                await _imageService.DeleteImageAsync(dfood.PublicId);
            _context.DnutritionFooodItems.Remove(dfood);
            var result= await _context.SaveChangesAsync()>0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "Problem deleting the data" });
        }
    }
}
