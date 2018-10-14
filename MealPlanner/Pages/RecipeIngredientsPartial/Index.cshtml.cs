using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.RecipeIngredientsPartial
{
    public class IndexModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public IndexModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        public IList<RecipeIngredient> RecipeIngredient { get;set; }

        public async Task OnGetAsync()
        {
            RecipeIngredient = await _context.RecipeIngredient
                .Include(r => r.Ingredient)
                .Include(r => r.MeasureUnit).ToListAsync();
        }
    }
}
