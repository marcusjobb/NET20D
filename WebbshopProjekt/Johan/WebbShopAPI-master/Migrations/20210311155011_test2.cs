using Microsoft.EntityFrameworkCore.Migrations;

namespace WebbShopAPI.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Categories",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Categories",
                table: "Books",
                column: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_Categories",
                table: "Books",
                column: "Categories",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Categories",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Categories",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
