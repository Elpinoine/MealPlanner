using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models {
  public class PlanEntry {
    public int ID { get; set; }

    [DataType( DataType.Date )]
    public DateTime Date { get; set; }

    public List<Food> Foods { get; set; }

    public string Notes { get; set; }
  }
}
