using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.Migrations
{
    /// <inheritdoc />
    public partial class newTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Chefs");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChefId = table.Column<int>(type: "int", nullable: true),
                    MealId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_Menus_MealId",
                        column: x => x.MealId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SosialMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosialMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SosialMedia_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ChefId",
                table: "Image",
                column: "ChefId",
                unique: true,
                filter: "[ChefId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_MealId",
                table: "Image",
                column: "MealId",
                unique: true,
                filter: "[MealId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SosialMedia_ChefId",
                table: "SosialMedia",
                column: "ChefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "SosialMedia");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Chefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
