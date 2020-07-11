using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Models;

namespace MealPlanner.Models
{
  public class MealPlannerContext : DbContext
  {
    public MealPlannerContext(DbContextOptions<MealPlannerContext> options)
        : base(options)
    {
    }


    public DbSet<MealPlanner.Models.Category> Category { get; set; }

    public DbSet<MealPlanner.Models.Recipe> Recipe { get; set; }

    public DbSet<MealPlanner.Models.Meal> Meal { get; set; }

    public DbSet<MealPlanner.Models.Plan> Plan { get; set; }

    public DbSet<MealPlanner.Models.PlanEntry> PlanEntry { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Meal>().ToTable("Meal");
//      modelBuilder.Entity<PlanEntry>().HasKey(c => new { c.PlanId, c.MealId, c.Date });
    }

  }
}
