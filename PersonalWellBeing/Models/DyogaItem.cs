﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class DyogaItem
    {
        public int? YogaId { get; set; }
        public int YogaItemId { get; set; }
        public string YogaItemTitle { get; set; }
        public string YogaItemDescription { get; set; }

        public virtual Dyoga Yoga { get; set; }
    }
}
