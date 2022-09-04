using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class Duser
    {
        public Duser()
        {
            Dappointments = new HashSet<Dappointment>();
            Dfeedbacks = new HashSet<Dfeedback>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }

        public virtual ICollection<Dappointment> Dappointments { get; set; }
        public virtual ICollection<Dfeedback> Dfeedbacks { get; set; }
    }
}
