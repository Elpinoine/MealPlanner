using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class Meal : Food
    {
        public ICollection<Recipe> Recipes{ get; set; }
    }
}
