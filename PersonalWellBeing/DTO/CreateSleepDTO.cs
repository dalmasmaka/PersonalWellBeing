using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class CreateSleepDTO
    {
        [Required]
        public string SleepHygieneTitle { get; set; }

        [Required]
        public string SleepHygieneDescription { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
