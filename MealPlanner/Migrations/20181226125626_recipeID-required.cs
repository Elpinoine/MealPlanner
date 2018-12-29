using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Migrations
{
    public partial class recipeIDrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Food_RecipeID",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "RecipeIngredient",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Food_RecipeID",
                table: "RecipeIngredient",
                column: "RecipeID",
                principalTable: "Food",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Food_RecipeID",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "RecipeIngredient",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Food_RecipeID",
                table: "RecipeIngredient",
                column: "RecipeID",
                principalTable: "Food",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
