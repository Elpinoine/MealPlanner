using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.RecipeIngredients
{
    public class DeleteModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public DeleteModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeIngredient RecipeIngredient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeIngredient = await _context.RecipeIngredient.FirstOrDefaultAsync(m => m.ID == id);

            if (RecipeIngredient == null)
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

            RecipeIngredient = await _context.RecipeIngredient.FindAsync(id);

            if (RecipeIngredient != null)
            {
                _context.RecipeIngredient.Remove(RecipeIngredient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
