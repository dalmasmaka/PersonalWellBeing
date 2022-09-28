using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable

namespace PersonalWellBeing.Models
{
    public class Ddoctor
    {
        public Ddoctor()
       {
           Dappointments = new HashSet<Dappointment>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string DoctorSummary { get; set; }
        public string DoctorImg { get; set; }
        public string PublicId { get; set; }

        public virtual ICollection<Dappointment> Dappointments { get; set; }
    }
}
