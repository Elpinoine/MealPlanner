using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Migrations
{
    public partial class EntryMealRelationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Food_FoodID",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_PlanEntry_PlanEntryID",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Food_MealID",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_PlanEntryID",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "PlanEntryID",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Recipe");

            migrationBuilder.RenameColumn(
                name: "FoodID",
                table: "Category",
                newName: "RecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_Category_FoodID",
                table: "Category",
                newName: "IX_Category_RecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_Food_MealID",
                table: "Recipe",
                newName: "IX_Recipe_MealID");

            migrationBuilder.AddColumn<int>(
                name: "MealID",
                table: "Category",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanEntryMealRelation",
                columns: table => new
                {
                    PlanEntryId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanEntryMealRelation", x => new { x.PlanEntryId, x.MealId });
                    table.ForeignKey(
                        name: "FK_PlanEntryMealRelation_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanEntryMealRelation_PlanEntry_PlanEntryId",
                        column: x => x.PlanEntryId,
                        principalTable: "PlanEntry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_MealID",
                table: "Category",
                column: "MealID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanEntryMealRelation_MealId",
                table: "PlanEntryMealRelation",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Meal_MealID",
                table: "Category",
                column: "MealID",
                principalTable: "Meal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Recipe_RecipeID",
                table: "Category",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Meal_MealID",
                table: "Recipe",
                column: "MealID",
                principalTable: "Meal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Meal_MealID",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Recipe_RecipeID",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Meal_MealID",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "PlanEntryMealRelation");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropIndex(
                name: "IX_Category_MealID",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "MealID",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "Food");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "Category",
                newName: "FoodID");

            migrationBuilder.RenameIndex(
                name: "IX_Category_RecipeID",
                table: "Category",
                newName: "IX_Category_FoodID");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_MealID",
                table: "Food",
                newName: "IX_Food_MealID");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Food",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlanEntryID",
                table: "Food",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Food_PlanEntryID",
                table: "Food",
                column: "PlanEntryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Food_FoodID",
                table: "Category",
                column: "FoodID",
                principalTable: "Food",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_PlanEntry_PlanEntryID",
                table: "Food",
                column: "PlanEntryID",
                principalTable: "PlanEntry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Food_MealID",
                table: "Food",
                column: "MealID",
                principalTable: "Food",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
