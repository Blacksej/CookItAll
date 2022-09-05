using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookItAll.Data.Migrations
{
    public partial class newtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Step_Recipe",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Step_Step",
                table: "Step");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_Recipe",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Recipe",
                table: "Recipe");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Step",
                table: "Step",
                column: "Step",
                unique: true,
                filter: "[Step] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Step_Step",
                table: "Step");

            migrationBuilder.AddColumn<int>(
                name: "Recipe",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Step_Step",
                table: "Step",
                column: "Step");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Recipe",
                table: "Recipe",
                column: "Recipe");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Step_Recipe",
                table: "Recipe",
                column: "Recipe",
                principalTable: "Step",
                principalColumn: "Id");
        }
    }
}
