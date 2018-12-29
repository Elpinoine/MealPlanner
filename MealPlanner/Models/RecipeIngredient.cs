using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class RecipeIngredient
    {
        public int ID { get; set; }
        [Required]
        public Recipe Recipe { get; set; }

        [Required]
        public int IngredientID { get; set; }
        [Display(Name = "Ingredient")]
        [Required]
        public virtual Ingredient Ingredient { get; set; }
        //       public Ingredient Ingredient { get; set; }
        //        [Display(Name = "Ingredient")]
        //        public int IngredientID { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Unit")]
        public int MeasureUnitID { get; set; }
        public virtual MeasureUnit MeasureUnit { get; set; }
    }
}