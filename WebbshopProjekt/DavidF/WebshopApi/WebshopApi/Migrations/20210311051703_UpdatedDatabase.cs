using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopApi.Migrations
{
    public partial class UpdatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SoldBooks");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "SoldBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoldBooks_CategoryID",
                table: "SoldBooks",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldBooks_Categories_CategoryID",
                table: "SoldBooks",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldBooks_Categories_CategoryID",
                table: "SoldBooks");

            migrationBuilder.DropIndex(
                name: "IX_SoldBooks_CategoryID",
                table: "SoldBooks");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "SoldBooks");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "SoldBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}