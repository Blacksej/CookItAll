using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookItAll.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Category_CategoryId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmount_Ingredient_IngredientId",
                table: "IngredientAmount");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "IngredientAmount",
                newName: "IngredientID");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientAmount_IngredientId",
                table: "IngredientAmount",
                newName: "IX_IngredientAmount_IngredientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ingredient",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Ingredient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Category_CategoryId",
                table: "Ingredient",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmount_Ingredient_IngredientID",
                table: "IngredientAmount",
                column: "IngredientID",
                principalTable: "Ingredient",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Category_CategoryId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmount_Ingredient_IngredientID",
                table: "IngredientAmount");

            migrationBuilder.RenameColumn(
                name: "IngredientID",
                table: "IngredientAmount",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientAmount_IngredientID",
                table: "IngredientAmount",
                newName: "IX_IngredientAmount_IngredientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Ingredient",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Ingredient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Category_CategoryId",
                table: "Ingredient",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmount_Ingredient_IngredientId",
                table: "IngredientAmount",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id");
        }
    }
}
