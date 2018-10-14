using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
