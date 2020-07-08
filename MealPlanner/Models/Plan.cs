using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models {
  public class Plan {
    public int ID { get; set; }

    public string Name { get; set; }

    public List<PlanEntry> PlanEntries { get; set; }
  }
}