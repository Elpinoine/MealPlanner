using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models {
  public class Meal {
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Recipe> Recipes { get; set; }
    public ICollection<PlanEntry> PlanEntries { get; set; }
  }
}