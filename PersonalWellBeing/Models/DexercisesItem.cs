using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class DexercisesItem
    {
        public int? ExercisesId { get; set; }
        public int ExerciseItemId { get; set; }
        public string ExerciseItemTitle { get; set; }
        public string ExerciseItemDescription { get; set; }
        public string ExerciseItemImg { get; set; }

        public virtual Dexercise Exercises { get; set; }
    }
}
