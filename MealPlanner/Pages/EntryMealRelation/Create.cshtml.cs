using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlanner.Models;

namespace MealPlanner.Pages.EntryMealRelation
{
    public class CreateModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public CreateModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MealId"] = new SelectList(_context.Meal, "ID", "ID");
        ViewData["PlanEntryId"] = new SelectList(_context.PlanEntry, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public PlanEntryMealRelation PlanEntryMealRelation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlanEntryMealRelations.Add(PlanEntryMealRelation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}