using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.Migrations
{
    /// <inheritdoc />
    public partial class FixChefMenuCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChefMeal_Chefs_ChefId",
                table: "ChefMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_ChefMeal_Menus_MealId",
                table: "ChefMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Menus_MenuId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_SosialMedia_Chefs_ChefId",
                table: "SosialMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChefMeal",
                table: "ChefMeal");

            migrationBuilder.DropIndex(
                name: "IX_ChefMeal_ChefId",
                table: "ChefMeal");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ChefMeal");

            migrationBuilder.RenameTable(
                name: "ChefMeal",
                newName: "ChefMeals");

            migrationBuilder.RenameIndex(
                name: "IX_ChefMeal_MealId",
                table: "ChefMeals",
                newName: "IX_ChefMeals_MealId");

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

            migrationBuilder.RenameTable(
                name: "ChefMeals",
                newName: "ChefMeal");

            migrationBuilder.RenameIndex(
                name: "IX_ChefMeals_MealId",
                table: "ChefMeal",
                newName: "IX_ChefMeal_MealId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ChefMeal",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChefMeal",
                table: "ChefMeal",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChefMeal_ChefId",
                table: "ChefMeal",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefMeal_Chefs_ChefId",
                table: "ChefMeal",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChefMeal_Menus_MealId",
                table: "ChefMeal",
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
    }
}
