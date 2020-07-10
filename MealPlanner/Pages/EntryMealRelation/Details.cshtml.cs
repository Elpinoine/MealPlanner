using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.EntryMealRelation
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public DetailsModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        public PlanEntryMealRelation PlanEntryMealRelation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlanEntryMealRelation = await _context.PlanEntryMealRelations
                .Include(p => p.Meal)
                .Include(p => p.PlanEntry).FirstOrDefaultAsync(m => m.PlanEntryId == id);

            if (PlanEntryMealRelation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
