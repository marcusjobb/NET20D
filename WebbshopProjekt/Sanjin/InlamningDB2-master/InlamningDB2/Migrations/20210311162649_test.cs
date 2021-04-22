using Microsoft.EntityFrameworkCore.Migrations;

namespace InlamningDB2.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Book_Categoryid",
                table: "Book",
                column: "Categoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Categories_Categoryid",
                table: "Book",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Categories_Categoryid",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_Categoryid",
                table: "Book");
        }
    }
}
