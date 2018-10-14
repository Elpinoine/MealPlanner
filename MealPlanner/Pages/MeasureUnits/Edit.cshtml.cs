using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Pages.MeasureUnits
{
    public class EditModel : PageModel
    {
        private readonly MealPlanner.Models.MealPlannerContext _context;

        public EditModel(MealPlanner.Models.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MeasureUnit MeasureUnit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeasureUnit = await _context.MeasureUnit.FirstOrDefaultAsync(m => m.ID == id);

            if (MeasureUnit == null)
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

            _context.Attach(MeasureUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasureUnitExists(MeasureUnit.ID))
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

        private bool MeasureUnitExists(int id)
        {
            return _context.MeasureUnit.Any(e => e.ID == id);
        }
    }
}
