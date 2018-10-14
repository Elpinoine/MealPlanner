using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.Recipes
{
    public class EditModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public EditModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
            RecipeIngredients = _context.RecipeIngredient.Select(x => new  { Value = x.ID.ToString(), Text = x. }).ToList();

        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id = null)
        {
            if (id == null)
            {
                Recipe = new Recipe();
                Recipe.Title = "New Recipe";
                _context.Recipe.Add(Recipe);
                await _context.SaveChangesAsync(); // ID will be created and set here
 //               return NotFound();
            }
            else {
                Recipe = await _context.Recipe.FirstOrDefaultAsync(m => m.ID == id);
            }
            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(Recipe.ID))
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

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.ID == id);
        }
    }
}
