using System;
using System.Collections.Generic;

#nullable disable
 
namespace PersonalWellBeing.Models
{
    public partial class DsleepHygiene
    {
        public int? MenuListId { get; set; }
        public int SleepHygieneId { get; set; }
        public string SleepHygieneTitle { get; set; }
        public string SleepHygieneDescription { get; set; }
        public string SleepingHygieneImg { get; set; }
        public string PublicId { get; set; }

        public virtual DmenuList MenuList { get; set; }
    }
}
