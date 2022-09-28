using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PersonalWellBeing.DTO
{
    public class UpdateDoctorDTO
    {
        public int DoctorId { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string DoctorSurname { get; set; }

        [Required]
        public string DoctorSummary { get; set; }

        public IFormFile File { get; set; }
    }
}
