using Microsoft.EntityFrameworkCore.Migrations;

namespace WebbShopAPI.Migrations
{
    public partial class changeDataSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_soldBooks",
                table: "soldBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookCategories",
                table: "bookCategories");

            migrationBuilder.RenameTable(
                name: "soldBooks",
                newName: "SoldBooks");

            migrationBuilder.RenameTable(
                name: "bookCategories",
                newName: "BookCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoldBooks",
                table: "SoldBooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoldBooks",
                table: "SoldBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories");

            migrationBuilder.RenameTable(
                name: "SoldBooks",
                newName: "soldBooks");

            migrationBuilder.RenameTable(
                name: "BookCategories",
                newName: "bookCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_soldBooks",
                table: "soldBooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookCategories",
                table: "bookCategories",
                column: "Id");
        }
    }
}
