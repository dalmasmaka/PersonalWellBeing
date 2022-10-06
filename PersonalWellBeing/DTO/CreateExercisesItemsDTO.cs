using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class CreateExercisesItemsDTO
    {
        [Required]
        public string ExerciseItemTitle { get; set; }

        [Required]
        public string ExerciseItemDescription { get; set; }


        [Required]
        public IFormFile File { get; set; }
    }
}
