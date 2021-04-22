using Microsoft.EntityFrameworkCore.Migrations;

namespace InlamningDB2.Migrations
{
    public partial class addedthings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SooldBook_Categories_CategoryId",
                table: "SooldBook");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SooldBook",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SooldBook_Categories_CategoryId",
                table: "SooldBook",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SooldBook_Categories_CategoryId",
                table: "SooldBook");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SooldBook",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SooldBook_Categories_CategoryId",
                table: "SooldBook",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
