using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.EntryMealRelation
{
    public class EditModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public EditModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["MealId"] = new SelectList(_context.Meal, "ID", "ID");
           ViewData["PlanEntryId"] = new SelectList(_context.PlanEntry, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlanEntryMealRelation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanEntryMealRelationExists(PlanEntryMealRelation.PlanEntryId))
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

        private bool PlanEntryMealRelationExists(int id)
        {
            return _context.PlanEntryMealRelations.Any(e => e.PlanEntryId == id);
        }
    }
}
