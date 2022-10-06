using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class CreateYogaItemDTO
    {
        [Required]
        public string YogaItemTitle { get; set; }
        [Required]
        public string YogaItemDescription { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
