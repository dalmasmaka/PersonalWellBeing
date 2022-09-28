using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class DnutritionFooodItem
    {
        public int? NutritionFoodId { get; set; }
        public int NutritionFoodItemId { get; set; }
        public string NutritionFoodItemTitle { get; set; }
        public string NutritionFoodItemDescription { get; set; }
        public string NutritionFoodItemImg { get; set; }
        public string PublicId { get; set; }
        public virtual DnutritionFood NutritionFood { get; set; }
    }
}
