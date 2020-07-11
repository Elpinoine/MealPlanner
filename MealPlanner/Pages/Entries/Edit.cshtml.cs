using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.Entries
{
    public class EditModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public EditModel(MealPlanner.Models.MealPlannerContext context)
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
           ViewData["MealId"] = new SelectList(_context.Meal, "ID", "ID");
           ViewData["PlanId"] = new SelectList(_context.Plan, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlanEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanEntryExists(PlanEntry.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlanEntryExists(int id)
        {
            return _context.PlanEntry.Any(e => e.ID == id);
        }
    }
}
