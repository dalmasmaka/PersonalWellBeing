using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class DmenuList
    {
        public DmenuList()
        {
            Dexercises = new HashSet<Dexercise>();
            DnutritionFoods = new HashSet<DnutritionFood>();
            DsleepHygienes = new HashSet<DsleepHygiene>();
            Dyogas = new HashSet<Dyoga>();
        }

        public int MenuListId { get; set; }
        public string MenuListItem { get; set; }
        public string MenuListImg { get; set; }

        public virtual ICollection<Dexercise> Dexercises { get; set; }
        public virtual ICollection<DnutritionFood> DnutritionFoods { get; set; }
        public virtual ICollection<DsleepHygiene> DsleepHygienes { get; set; }
        public virtual ICollection<Dyoga> Dyogas { get; set; }
    }
}
