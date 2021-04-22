using Microsoft.EntityFrameworkCore.Migrations;

namespace WebbShopAPI.Migrations
{
    public partial class finishedWithAllFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActibve",
                table: "Users",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "IsActibve");
        }
    }
}
