using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class UpdateYogaItemDTO
    {
        public int YogaItemId { get; set; }
        [Required]
        public string YogaItemTitle { get; set; }
        [Required]
        public string YogaItemDescription { get; set; }
       
        public IFormFile File { get; set; }
    }
}
