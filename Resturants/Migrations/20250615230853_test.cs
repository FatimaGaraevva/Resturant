using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
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
                name: "FK_SosialMedia_Chefs_ChefId",
                table: "SosialMedia");

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "SosialMedia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "ChefMeals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "ChefMeals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefMeals_Chefs_ChefId",
                table: "ChefMeals",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefMeals_Menus_MealId",
                table: "ChefMeals",
                column: "MealId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SosialMedia_Chefs_ChefId",
                table: "SosialMedia",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id");
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
                name: "FK_SosialMedia_Chefs_ChefId",
                table: "SosialMedia");

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "SosialMedia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "ChefMeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "ChefMeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_SosialMedia_Chefs_ChefId",
                table: "SosialMedia",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
