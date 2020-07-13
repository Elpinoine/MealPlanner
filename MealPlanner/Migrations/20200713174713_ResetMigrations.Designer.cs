﻿// <auto-generated />
using System;
using MealPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MealPlanner.Migrations
{
    [DbContext(typeof(MealPlannerContext))]
    [Migration("20200713174713_ResetMigrations")]
    partial class ResetMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MealPlanner.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MealID");

                    b.Property<string>("Name");

                    b.Property<int?>("RecipeID");

                    b.HasKey("ID");

                    b.HasIndex("MealID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MealPlanner.Models.Meal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("MealPlanner.Models.Plan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("MealPlanner.Models.PlanEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("MealId");

                    b.Property<int>("PlanId");

                    b.HasKey("ID");

                    b.HasIndex("MealId");

                    b.HasIndex("PlanId");

                    b.ToTable("PlanEntry");
                });

            modelBuilder.Entity("MealPlanner.Models.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("MealID");

                    b.Property<string>("Notes");

                    b.Property<string>("Reference");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("MealID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("MealPlanner.Models.Category", b =>
                {
                    b.HasOne("MealPlanner.Models.Meal")
                        .WithMany("Categories")
                        .HasForeignKey("MealID");

                    b.HasOne("MealPlanner.Models.Recipe")
                        .WithMany("Categories")
                        .HasForeignKey("RecipeID");
                });

            modelBuilder.Entity("MealPlanner.Models.PlanEntry", b =>
                {
                    b.HasOne("MealPlanner.Models.Meal", "Meal")
                        .WithMany("PlanEntries")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MealPlanner.Models.Plan", "Plan")
                        .WithMany("PlanEntries")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MealPlanner.Models.Recipe", b =>
                {
                    b.HasOne("MealPlanner.Models.Meal")
                        .WithMany("Recipes")
                        .HasForeignKey("MealID");
                });
#pragma warning restore 612, 618
        }
    }
}