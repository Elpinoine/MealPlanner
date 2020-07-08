using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealPlanner.Migrations
{
    public partial class ReducedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "MeasureUnit");

            migrationBuilder.DropColumn(
                name: "Favourite",
                table: "Food");

            migrationBuilder.RenameColumn(
                name: "Steps",
                table: "Food",
                newName: "Reference");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "Food",
                newName: "Steps");

            migrationBuilder.AddColumn<bool>(
                name: "Favourite",
                table: "Food",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MeasureUnit",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    IngredientID = table.Column<int>(nullable: false),
                    MeasureUnitID = table.Column<int>(nullable: false),
                    RecipeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_MeasureUnit_MeasureUnitID",
                        column: x => x.MeasureUnitID,
                        principalTable: "MeasureUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Food_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Food",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_IngredientID",
                table: "RecipeIngredient",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_MeasureUnitID",
                table: "RecipeIngredient",
                column: "MeasureUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeID",
                table: "RecipeIngredient",
                column: "RecipeID");
        }
    }
}
