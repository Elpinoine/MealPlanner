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
    public class DeleteModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public DeleteModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlanEntry PlanEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlanEntry = await _context.PlanEntry
                .Include(p => p.Meal)
                .Include(p => p.Plan).FirstOrDefaultAsync(m => m.ID == id);

            if (PlanEntry == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlanEntry = await _context.PlanEntry.FindAsync(id);

            if (PlanEntry != null)
            {
                _context.PlanEntry.Remove(PlanEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
