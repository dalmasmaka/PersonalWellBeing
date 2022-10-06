using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class CreateFoodItemDTO
    {
        [Required]
        public string NutritionFoodItemTitle { get; set; }
        [Required]
        public string NutritionFoodItemDescription { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
