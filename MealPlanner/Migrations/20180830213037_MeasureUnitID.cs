using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Migrations
{
    public partial class MeasureUnitID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Ingredient_IngredientID",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_MeasureUnit_MeasureUnitID",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "MeasureUnitID",
                table: "RecipeIngredient",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IngredientID",
                table: "RecipeIngredient",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Ingredient_IngredientID",
                table: "RecipeIngredient",
                column: "IngredientID",
                principalTable: "Ingredient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_MeasureUnit_MeasureUnitID",
                table: "RecipeIngredient",
                column: "MeasureUnitID",
                principalTable: "MeasureUnit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Ingredient_IngredientID",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_MeasureUnit_MeasureUnitID",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "MeasureUnitID",
                table: "RecipeIngredient",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IngredientID",
                table: "RecipeIngredient",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Ingredient_IngredientID",
                table: "RecipeIngredient",
                column: "IngredientID",
                principalTable: "Ingredient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_MeasureUnit_MeasureUnitID",
                table: "RecipeIngredient",
                column: "MeasureUnitID",
                principalTable: "MeasureUnit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
