using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class Dexercise
    {
        public Dexercise()
        {
            DexercisesItems = new HashSet<DexercisesItem>();
        }

        public int ExercisesId { get; set; }
        public string ExercisesType { get; set; }
        public int? MenuListId { get; set; }

        public virtual DmenuList MenuList { get; set; }
        public virtual ICollection<DexercisesItem> DexercisesItems { get; set; }
    }
}
