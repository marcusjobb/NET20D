using Microsoft.EntityFrameworkCore.Migrations;

namespace Inlamn2WebbShop_MLarsson.Migrations
{
    public partial class addedLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SoldBooks_SoldBookId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SoldBookId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "SoldBooks");

            migrationBuilder.DropColumn(
                name: "SoldBookId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BooksId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorySoldBook",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    SoldBooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySoldBook", x => new { x.CategoriesId, x.SoldBooksId });
                    table.ForeignKey(
                        name: "FK_CategorySoldBook_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySoldBook_SoldBooks_SoldBooksId",
                        column: x => x.SoldBooksId,
                        principalTable: "SoldBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldBookUser",
                columns: table => new
                {
                    SoldBooksId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldBookUser", x => new { x.SoldBooksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SoldBookUser_SoldBooks_SoldBooksId",
                        column: x => x.SoldBooksId,
                        principalTable: "SoldBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoldBookUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoriesId",
                table: "BookCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySoldBook_SoldBooksId",
                table: "CategorySoldBook",
                column: "SoldBooksId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldBookUser_UsersId",
                table: "SoldBookUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "CategorySoldBook");

            migrationBuilder.DropTable(
                name: "SoldBookUser");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "SoldBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoldBookId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SoldBookId",
                table: "Categories",
                column: "SoldBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_SoldBooks_SoldBookId",
                table: "Categories",
                column: "SoldBookId",
                principalTable: "SoldBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
