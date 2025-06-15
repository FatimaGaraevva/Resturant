using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.Migrations
{
    /// <inheritdoc />
    public partial class Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChefMeals_Chefs_ChefId",
                table: "ChefMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_ChefMeals_Menus_MealId",
                table: "ChefMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Chefs_ChefId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Menus_MenuId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_SosialMedia_Chefs_ChefId",
                table: "SosialMedia");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ChefId",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChefMeals",
                table: "ChefMeals");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ChefMeals",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChefMeals",
                table: "ChefMeals",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChefMeals_ChefId",
                table: "ChefMeals",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefMeals_Chefs_ChefId",
                table: "ChefMeals",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChefMeals_Menus_MealId",
                table: "ChefMeals",
                column: "MealId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Menus_MenuId",
                table: "Ratings",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SosialMedia_Chefs_ChefId",
                table: "SosialMedia",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChefMeals_Chefs_ChefId",
                table: "ChefMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_ChefMeals_Menus_MealId",
                table: "ChefMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Menus_MenuId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_SosialMedia_Chefs_ChefId",
                table: "SosialMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChefMeals",
                table: "ChefMeals");

            migrationBuilder.DropIndex(
                name: "IX_ChefMeals_ChefId",
                table: "ChefMeals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ChefMeals");

            migrationBuilder.AddColumn<int>(
                name: "ChefId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChefMeals",
                table: "ChefMeals",
                columns: new[] { "ChefId", "MealId" });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ChefId",
                table: "Menus",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefMeals_Chefs_ChefId",
                table: "ChefMeals",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChefMeals_Menus_MealId",
                table: "ChefMeals",
                column: "MealId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Chefs_ChefId",
                table: "Menus",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Menus_MenuId",
                table: "Ratings",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SosialMedia_Chefs_ChefId",
                table: "SosialMedia",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
