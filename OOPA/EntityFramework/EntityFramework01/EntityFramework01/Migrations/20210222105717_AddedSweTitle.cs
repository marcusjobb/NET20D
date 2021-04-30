using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework01.Migrations
{
    public partial class AddedSweTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitelSwe",
                table: "Filmer",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitelSwe",
                table: "Filmer");
        }
    }
}
