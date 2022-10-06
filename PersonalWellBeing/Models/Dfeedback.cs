using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class Dfeedback
    {
        public int FeedbackId { get; set; }
        public int? UserId { get; set; }
        public string FeedbackText { get; set; }
    }
}
