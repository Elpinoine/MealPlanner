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
    [Migration("20200708093610_AddedPlanEntry")]
    partial class AddedPlanEntry
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

                    b.Property<string>("Notes");

                    b.Property<int?>("PlanEntryID");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("PlanEntryID");

                    b.ToTable("Food");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Food");
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

                    b.Property<string>("Notes");

                    b.Property<int?>("PlanID");

                    b.HasKey("ID");

                    b.HasIndex("PlanID");

                    b.ToTable("PlanEntry");
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

                    b.Property<string>("Reference");

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
                    b.HasOne("MealPlanner.Models.PlanEntry")
                        .WithMany("Foods")
                        .HasForeignKey("PlanEntryID");
                });

            modelBuilder.Entity("MealPlanner.Models.PlanEntry", b =>
                {
                    b.HasOne("MealPlanner.Models.Plan")
                        .WithMany("PlanEntries")
                        .HasForeignKey("PlanID");
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
