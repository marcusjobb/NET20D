using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik;

namespace Bookshop.Views.Book
{
    public static class BookInfo
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Buy book", "Back" };

        static Layout layout = new Layout();
        static WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Prints the information of a book.
        /// </summary>
        /// <param name="bookId">The id of the book.</param>
        public static void PrintBookInfo(int bookId)
        {

            layout.ClearMainContent();

            Console.SetCursorPosition(25, 9);
            Console.Write("Title: ");
            Console.CursorLeft = 40;
            Console.WriteLine(api.GetBook(bookId).Title);

            Console.CursorLeft = 25;
            Console.Write("Author: ");
            Console.CursorLeft = 40;
            Console.WriteLine(api.GetBook(bookId).Author.Name);

            Console.CursorLeft = 25;
            Console.Write("Category: ");
            Console.CursorLeft = 40;
            Console.WriteLine(api.GetBook(bookId).Category.Name);

            Console.CursorLeft = 25;
            Console.Write("Amount: ");
            Console.CursorLeft = 40;
            Console.WriteLine(api.GetBook(bookId).Amount);

            Console.CursorLeft = 25;
            Console.Write("Price: ");
            Console.CursorLeft = 40;
            Console.WriteLine(api.GetBook(bookId).Price);
        }
    }
}
