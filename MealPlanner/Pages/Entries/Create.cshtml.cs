using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlanner.Models;

namespace MealPlanner.Pages.Entries {
  public class CreateModel : PageModel {
    private readonly MealPlanner.Models.MealPlannerContext _context;

    public CreateModel( MealPlanner.Models.MealPlannerContext context ) {
      _context = context;
    }

    public IActionResult OnGet( int? planId ) {
      var id = planId;
      return Page();
    }

    [BindProperty] public PlanEntry PlanEntry { get; set; }

    public async Task<IActionResult> OnPostAsync(int planId) {
      if ( !ModelState.IsValid ) {
        return Page();
      }

      PlanEntry.PlanId = planId;
      _context.PlanEntry.Add( PlanEntry );
      await _context.SaveChangesAsync();

      return RedirectToPage( "./Index" );
    }
  }
}