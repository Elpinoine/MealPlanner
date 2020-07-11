using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public IndexModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        public IList<PlanEntry> PlanEntry { get;set; }

        public async Task OnGetAsync()
        {
            PlanEntry = await _context.PlanEntry
                .Include(p => p.Meal)
                .Include(p => p.Plan).ToListAsync();
        }
    }
}
