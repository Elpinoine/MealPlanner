using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Migrations
{
    public partial class AddedPlanEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Plan_PlanID",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Plan",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PlanID",
                table: "Food",
                newName: "PlanEntryID");

            migrationBuilder.RenameIndex(
                name: "IX_Food_PlanID",
                table: "Food",
                newName: "IX_Food_PlanEntryID");

            migrationBuilder.CreateTable(
                name: "PlanEntry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PlanID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanEntry", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlanEntry_Plan_PlanID",
                        column: x => x.PlanID,
                        principalTable: "Plan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanEntry_PlanID",
                table: "PlanEntry",
                column: "PlanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_PlanEntry_PlanEntryID",
                table: "Food",
                column: "PlanEntryID",
                principalTable: "PlanEntry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_PlanEntry_PlanEntryID",
                table: "Food");

            migrationBuilder.DropTable(
                name: "PlanEntry");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Plan",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "PlanEntryID",
                table: "Food",
                newName: "PlanID");

            migrationBuilder.RenameIndex(
                name: "IX_Food_PlanEntryID",
                table: "Food",
                newName: "IX_Food_PlanID");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Plan",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Plan_PlanID",
                table: "Food",
                column: "PlanID",
                principalTable: "Plan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
