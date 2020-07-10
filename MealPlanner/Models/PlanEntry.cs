using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models {
  public class PlanEntry {
    public int ID { get; set; }

    [ForeignKey("Plan")]
    public int PlanId { get; set; }

    public virtual Plan Plan { get; set; }

    [DataType( DataType.Date )]
    public DateTime Date { get; set; }

    //public ICollection<Food> Foods { get; set; }
    public ICollection<PlanEntryMealRelation> PlanEntryMealRelations { get; set; }

    public string Notes { get; set; }
  }
}
