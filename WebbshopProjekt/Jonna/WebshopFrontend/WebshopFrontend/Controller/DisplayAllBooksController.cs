using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class DisplayAllBooksController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that will display all books that currently are in the database in a nice table view
        /// Thanks to ConsoleTablExt
        /// If theres no books to show a error message will be shown
        /// </summary>
        public static void DisplayAllBooksLogic()
        {
            var bookList = api.DisplayAllBooks();
            var tableData = new List<List<object>>();
            tableData.Add(new List<object>() { "Id", "Title", "Author", "Price", "Amount" });
            int count = 0;

            foreach (var book in bookList)
            {
                tableData.Add(new List<object>() { book.Id, book.Title, book.Author, book.Price, book.Amount });
                count++;
            }
            if (count == 0)
            {
                CenterText.PrintLinesInCenter(
                "╔════════════════════════════════════════════╗",
                "║  No books matched with your search keyword ║",
                "╚════════════════════════════════════════════╝");
            }
            else
            {
                ConsoleTableBuilder.From(tableData)
                .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
                .ExportAndWriteLine();
            }
        }
    }
}
