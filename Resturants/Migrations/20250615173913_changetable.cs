using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.Migrations
{
    /// <inheritdoc />
    public partial class changetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Chefs_ChefId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Menus_MealId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ChefId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_MealId",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_ChefId",
                table: "Image",
                column: "ChefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_MealId",
                table: "Image",
                column: "MealId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Chefs_ChefId",
                table: "Image",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Menus_MealId",
                table: "Image",
                column: "MealId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Chefs_ChefId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Menus_MealId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ChefId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_MealId",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Chefs_ChefId",
                table: "Image",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Menus_MealId",
                table: "Image",
                column: "MealId",
                principalTable: "Menus",
                principalColumn: "Id");
        }
    }
}
