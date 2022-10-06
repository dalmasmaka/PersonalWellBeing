using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class Dyoga
    {
        public Dyoga()
        {
            DyogaItems = new HashSet<DyogaItem>();
        }

        public int YogaId { get; set; }
        public int? MenuListId { get; set; }
        public string YogaType { get; set; }

        public virtual DmenuList MenuList { get; set; }
        public virtual ICollection<DyogaItem> DyogaItems { get; set; }
    }
}
