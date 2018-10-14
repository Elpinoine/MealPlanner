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
    [Migration("20180830175832_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MealPlanner.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FoodID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("FoodID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MealPlanner.Models.Food", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("Favourite");

                    b.Property<string>("Notes");

                    b.Property<int?>("PlanID");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("PlanID");

                    b.ToTable("Food");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Food");
                });

            modelBuilder.Entity("MealPlanner.Models.Ingredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("MealPlanner.Models.MeasureUnit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("MeasureUnit");
                });

            modelBuilder.Entity("MealPlanner.Models.Plan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Notes");

                    b.HasKey("ID");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("MealPlanner.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int?>("IngredientID");

                    b.Property<int?>("MeasureUnitID");

                    b.Property<int?>("RecipeID");

                    b.HasKey("ID");

                    b.HasIndex("IngredientID");

                    b.HasIndex("MeasureUnitID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("MealPlanner.Models.Meal", b =>
                {
                    b.HasBaseType("MealPlanner.Models.Food");


                    b.ToTable("Meal");

                    b.HasDiscriminator().HasValue("Meal");
                });

            modelBuilder.Entity("MealPlanner.Models.Recipe", b =>
                {
                    b.HasBaseType("MealPlanner.Models.Food");

                    b.Property<int?>("MealID");

                    b.Property<string>("Steps");

                    b.HasIndex("MealID");

                    b.ToTable("Recipe");

                    b.HasDiscriminator().HasValue("Recipe");
                });

            modelBuilder.Entity("MealPlanner.Models.Category", b =>
                {
                    b.HasOne("MealPlanner.Models.Food")
                        .WithMany("Categories")
                        .HasForeignKey("FoodID");
                });

            modelBuilder.Entity("MealPlanner.Models.Food", b =>
                {
                    b.HasOne("MealPlanner.Models.Plan")
                        .WithMany("Foods")
                        .HasForeignKey("PlanID");
                });

            modelBuilder.Entity("MealPlanner.Models.RecipeIngredient", b =>
                {
                    b.HasOne("MealPlanner.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID");

                    b.HasOne("MealPlanner.Models.MeasureUnit", "MeasureUnit")
                        .WithMany()
                        .HasForeignKey("MeasureUnitID");

                    b.HasOne("MealPlanner.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID");
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
