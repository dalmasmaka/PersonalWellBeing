using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class UpdateExercisesItemsDTO
    {
        public int ExerciseItemId { get; set; }

        [Required]
        public string ExerciseItemTitle { get; set; }

        [Required]
        public string ExerciseItemDescription { get; set; }


        public IFormFile File { get; set; }
    }
}
