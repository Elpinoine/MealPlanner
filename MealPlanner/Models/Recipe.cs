using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models {
  public class Recipe {
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }
    public ICollection<Category> Categories { get; set; }
    public string Reference { get; set; }
  }
}