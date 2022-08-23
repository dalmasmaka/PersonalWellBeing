using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class DnutritionFood
    {
        public DnutritionFood()
        {
            DnutritionFooodItems = new HashSet<DnutritionFooodItem>();
        }

        public int? MenuListId { get; set; }
        public int NutritionFoodId { get; set; }
        public string NutritionFoodType { get; set; }

        public virtual DmenuList MenuList { get; set; }
        public virtual ICollection<DnutritionFooodItem> DnutritionFooodItems { get; set; }
    }
}
