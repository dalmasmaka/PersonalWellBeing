using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class UpdateSleepDTO
    {
        public int SleepHygieneId { get; set; }
        [Required]
        public string SleepHygieneTitle { get; set; }
        [Required]
        public string SleepHygieneDescription { get; set; }
     
        public IFormFile File { get; set; }
    }
}
