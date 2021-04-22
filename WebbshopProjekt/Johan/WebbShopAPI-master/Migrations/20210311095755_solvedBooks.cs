using Microsoft.EntityFrameworkCore.Migrations;

namespace WebbShopAPI.Migrations
{
    public partial class solvedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "SoldBooks",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SoldBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SoldBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SoldBooks_CategoryId",
                table: "SoldBooks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldBooks_UserId",
                table: "SoldBooks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldBooks_Categories_CategoryId",
                table: "SoldBooks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldBooks_Users_UserId",
                table: "SoldBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldBooks_Categories_CategoryId",
                table: "SoldBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldBooks_Users_UserId",
                table: "SoldBooks");

            migrationBuilder.DropIndex(
                name: "IX_SoldBooks_CategoryId",
                table: "SoldBooks");

            migrationBuilder.DropIndex(
                name: "IX_SoldBooks_UserId",
                table: "SoldBooks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SoldBooks",
                newName: "UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "SoldBooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SoldBooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
