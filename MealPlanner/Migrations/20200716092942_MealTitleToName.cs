using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Migrations
{
    public partial class MealTitleToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Meal",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Meal",
                newName: "Title");
        }
    }
}
