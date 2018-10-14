using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlanner.Models;

namespace MealPlanner.Pages.RecipeIngredientsPartial
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
        ViewData["IngredientID"] = new SelectList(_context.Ingredient, "ID", "ID");
        ViewData["MeasureUnitID"] = new SelectList(_context.MeasureUnit, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public RecipeIngredient RecipeIngredient { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecipeIngredient.Add(RecipeIngredient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}