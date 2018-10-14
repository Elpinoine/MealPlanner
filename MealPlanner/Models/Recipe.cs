using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class Recipe : Food
    {
        public List<RecipeIngredient> Ingredients { get; set; }
        public string Steps { get; set; }
    }
}
