using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class UpdateFoodItemDTO
    {
      
        public int NutritionFoodItemId { get; set; }
        [Required]
        public string NutritionFoodItemTitle { get; set; }
        [Required]
        public string NutritionFoodItemDescription { get; set; }
        
        public IFormFile File { get; set; }
    }
}
