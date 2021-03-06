﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlanner.Models;

namespace MealPlanner.Pages.Entries
{
  public class CreateModel : PageModel
  {
    private readonly MealPlanner.Models.MealPlannerContext _context;

    public CreateModel(MealPlanner.Models.MealPlannerContext context)
    {
      _context = context;
    }

    public IActionResult OnGet(int? planid)
    {

      ViewData["MealId"] = new SelectList(_context.Meal, "ID", "Name").OrderBy(m => m.Text);
      ViewData["PlanId"] = new SelectList(_context.Plan, "ID", "ID",planid);
      ViewData["PlanIdReferer"] = planid;
      return Page();
    }

    [BindProperty]
    public PlanEntry PlanEntry { get; set; }

    public async Task<IActionResult> OnPostAsync(int? planid)
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      if (planid != null)
      {
        PlanEntry.PlanId = planid.GetValueOrDefault(0);
      }
      _context.PlanEntry.Add(PlanEntry);
      await _context.SaveChangesAsync();

      if (planid == null) {
        return RedirectToPage("./Index");

      }
      return RedirectToPage("/MealPlan/Details", new { id = planid });

    }
  }
}