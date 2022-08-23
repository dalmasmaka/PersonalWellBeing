using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class DmentalHealth
    {
        public int? DoctorId { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Dappointment Appointment { get; set; }
        public virtual Ddoctor Doctor { get; set; }
    }
}
