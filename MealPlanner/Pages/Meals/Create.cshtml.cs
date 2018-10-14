using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlanner.Models;

namespace MealPlanner.Pages.Meals
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
            return Page();
        }

        [BindProperty]
        public Meal Meal { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Meal.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}