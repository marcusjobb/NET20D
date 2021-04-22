using Microsoft.EntityFrameworkCore.Migrations;

namespace WebbShop.Migrations
{
    public partial class SoldBookedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldBookUser_Users_UserIdId",
                table: "SoldBookUser");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "SoldBooks");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "SoldBookUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_SoldBookUser_UserIdId",
                table: "SoldBookUser",
                newName: "IX_SoldBookUser_UsersId");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "SoldBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldBookUser_Users_UsersId",
                table: "SoldBookUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldBookUser_Users_UsersId",
                table: "SoldBookUser");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "SoldBooks");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "SoldBookUser",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_SoldBookUser_UsersId",
                table: "SoldBookUser",
                newName: "IX_SoldBookUser_UserIdId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "SoldBooks",
                type: "int",
                maxLength: 200,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldBookUser_Users_UserIdId",
                table: "SoldBookUser",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
