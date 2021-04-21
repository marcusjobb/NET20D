using Microsoft.EntityFrameworkCore.Migrations;

namespace Inlämning2.Migrations
{
    public partial class addCatList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoldBookId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SoldBookId",
                table: "Categories",
                column: "SoldBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_SoldBooks_SoldBookId",
                table: "Categories",
                column: "SoldBookId",
                principalTable: "SoldBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SoldBooks_SoldBookId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SoldBookId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SoldBookId",
                table: "Categories");
        }
    }
}
