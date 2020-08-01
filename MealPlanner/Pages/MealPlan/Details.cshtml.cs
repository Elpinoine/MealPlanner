using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.MealPlan
{
  public class DetailsModel : PageModel
  {
    private readonly MealPlanner.Models.MealPlannerContext _context;

    public DetailsModel(MealPlanner.Models.MealPlannerContext context)
    {
      _context = context;
    }

    public Plan Plan { get; set; }

    public ICollection<PlanEntry> PlanEntries { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Plan = await _context.Plan.FirstOrDefaultAsync(m => m.ID == id);

      if (Plan == null)
      {
        return NotFound();
      }
      PlanEntries = _context.PlanEntry.Where(p => p != null && p.PlanId == id).Include("Meal").OrderBy(p => p.Date).ToList();

      return Page();
    }
  }
}
