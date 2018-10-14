using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlanner.Models;

namespace MealPlanner.Pages.RecipeIngredients
{
    public class CreateModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public CreateModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
            MeasureUnits = _context.MeasureUnit.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Abbreviation }).ToList();
            Ingredients = _context.Ingredient.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name }).ToList();

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecipeIngredient RecipeIngredient { get; set; }

        public List<SelectListItem> MeasureUnits { get; set; }
        public List<SelectListItem> Ingredients { get; set; }

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