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
    public class IndexModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public IndexModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        public IList<PlanEntryMealRelation> PlanEntryMealRelation { get;set; }

        public async Task OnGetAsync()
        {
            PlanEntryMealRelation = await _context.PlanEntryMealRelations
                .Include(p => p.Meal)
                .Include(p => p.PlanEntry).ToListAsync();
        }
    }
}
