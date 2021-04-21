using Microsoft.EntityFrameworkCore.Migrations;

namespace InlamningDB2.Migrations
{
    public partial class togbort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Categories_Categoryid",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Categoryid",
                table: "Book",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Categoryid",
                table: "Book",
                newName: "IX_Book_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Categories_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Categories_CategoryId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Book",
                newName: "Categoryid");

            migrationBuilder.RenameIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                newName: "IX_Book_Categoryid");

            migrationBuilder.AlterColumn<int>(
                name: "Categoryid",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Categories_Categoryid",
                table: "Book",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
