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
        public MealPlannerContext (DbContextOptions<MealPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<MealPlanner.Models.Category> Category { get; set; }

        public DbSet<MealPlanner.Models.Recipe> Recipe { get; set; }

        public DbSet<MealPlanner.Models.Meal> Meal { get; set; }

        public DbSet<MealPlanner.Models.Plan> Plan { get; set; }

        public DbSet<MealPlanner.Models.PlanEntry> PlanEntry { get; set; }

        public DbSet<MealPlanner.Models.PlanEntryMealRelation> PlanEntryMealRelations { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder ) {
          modelBuilder.Entity<PlanEntryMealRelation>().ToTable( "PlanEntryMealRelation" );
          modelBuilder.Entity<PlanEntryMealRelation>().HasKey( c => new { c.PlanEntryId, c.MealId } );
        }
    }
}
