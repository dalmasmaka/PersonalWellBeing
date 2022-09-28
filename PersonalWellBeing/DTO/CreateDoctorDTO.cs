using Microsoft.AspNetCore.Http;
using PersonalWellBeing.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class CreateDoctorDTO
    {
        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string DoctorSurname { get; set; }

        [Required]
        public string DoctorSummary { get; set; }

        [Required]
        public IFormFile File { get; set; }

    }
}
