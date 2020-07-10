namespace MealPlanner.Models {
  public class PlanEntryMealRelation {

    public int PlanEntryId { get; set; }
    public PlanEntry PlanEntry { get; set; }
    public int MealId { get; set; }
    public Meal Meal { get; set; }
  }
}