﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.Meals
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public DetailsModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

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
    }
}
