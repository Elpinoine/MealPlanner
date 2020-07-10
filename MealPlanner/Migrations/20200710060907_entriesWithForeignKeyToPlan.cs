using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Migrations
{
    public partial class entriesWithForeignKeyToPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanEntry_Plan_PlanID",
                table: "PlanEntry");

            migrationBuilder.RenameColumn(
                name: "PlanID",
                table: "PlanEntry",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanEntry_PlanID",
                table: "PlanEntry",
                newName: "IX_PlanEntry_PlanId");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "PlanEntry",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanEntry_Plan_PlanId",
                table: "PlanEntry",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanEntry_Plan_PlanId",
                table: "PlanEntry");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "PlanEntry",
                newName: "PlanID");

            migrationBuilder.RenameIndex(
                name: "IX_PlanEntry_PlanId",
                table: "PlanEntry",
                newName: "IX_PlanEntry_PlanID");

            migrationBuilder.AlterColumn<int>(
                name: "PlanID",
                table: "PlanEntry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PlanEntry_Plan_PlanID",
                table: "PlanEntry",
                column: "PlanID",
                principalTable: "Plan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
