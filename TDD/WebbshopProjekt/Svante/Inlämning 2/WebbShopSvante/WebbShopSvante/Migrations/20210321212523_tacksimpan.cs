using Microsoft.EntityFrameworkCore.Migrations;

namespace WebbShop.Migrations
{
    public partial class tacksimpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_SoldBooks_SoldBookId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_SoldBookId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "SoldBookId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "BookGenreSoldBook",
                columns: table => new
                {
                    GenresGenreId = table.Column<int>(type: "int", nullable: false),
                    SoldBooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenreSoldBook", x => new { x.GenresGenreId, x.SoldBooksId });
                    table.ForeignKey(
                        name: "FK_BookGenreSoldBook_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenreSoldBook_SoldBooks_SoldBooksId",
                        column: x => x.SoldBooksId,
                        principalTable: "SoldBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenreSoldBook_SoldBooksId",
                table: "BookGenreSoldBook",
                column: "SoldBooksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenreSoldBook");

            migrationBuilder.AddColumn<int>(
                name: "SoldBookId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_SoldBookId",
                table: "Genres",
                column: "SoldBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_SoldBooks_SoldBookId",
                table: "Genres",
                column: "SoldBookId",
                principalTable: "SoldBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
