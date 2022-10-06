using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class Dappointment
    {
        public int AppointmentId { get; set; }
        public int? DoctorId { get; set; }
        public int? UserId { get; set; }
        public string AName { get; set; }
        public string ASurname { get; set; }
        public string APurpose { get; set; }
        public DateTime? ADoneDate { get; set; }
        public DateTime? ADate { get; set; }
        public string AEmail { get; set; }

        public virtual Ddoctor Doctor { get; set; }
    }
}
