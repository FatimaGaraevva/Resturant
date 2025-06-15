using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.Migrations
{
    /// <inheritdoc />
    public partial class TableChefMeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChefMeal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChefId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefMeal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChefMeal_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChefMeal_Menus_MealId",
                        column: x => x.MealId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChefMeal_ChefId",
                table: "ChefMeal",
                column: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_ChefMeal_MealId",
                table: "ChefMeal",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChefMeal");
        }
    }
}
