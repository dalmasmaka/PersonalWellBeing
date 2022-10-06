using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class DyogaItem
    {
        public int YogaItemId { get; set; }
        public int? YogaId { get; set; }
        public string YogaItemTitle { get; set; }
        public string YogaItemDescription { get; set; }
        public string PublicId { get; set; }
        public string YogaItemImg { get; set; }

        public virtual Dyoga Yoga { get; set; }
    }
}
