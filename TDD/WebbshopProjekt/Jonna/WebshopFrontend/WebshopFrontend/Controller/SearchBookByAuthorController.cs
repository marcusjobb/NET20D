using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class SearchBookByAuthorController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that will search for books based on the Author and then return a result(If book was found)
        /// Else there will just be an error message saying no books was found containing searched keyword
        /// </summary>
        public static void DisplayResultBookLogic()
        {
            string bookAuthorSearch;
            bookAuthorSearch = Console.ReadLine();
            Console.Clear();
            var bookResult = api.GetAuthors(bookAuthorSearch);

            var tableData = new List<List<object>>();
            tableData.Add(new List<object>() { "Id", "Title", "Author", "Price", "Amount" });
            int count = 0;

            foreach (var book in bookResult)
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
                .ExportAndWriteLine(TableAligntment.Center);
            }
        }
    }
 }

