using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.Meals
{
    public class DeleteModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public DeleteModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meal Meal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meal = await _context.Meal.FirstOrDefaultAsync(m => m.ID == id);

            if (Meal == null)
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

            Meal = await _context.Meal.FindAsync(id);

            if (Meal != null)
            {
                _context.Meal.Remove(Meal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
