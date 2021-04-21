using Bookshop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class BookInfo
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Change amount", "Update book",
            "Remove book", "Change category", "Back"};

        /// <summary>
        /// Prints the information of the book.
        /// </summary>
        public static void PrintBookInfo()
        {
            Console.SetCursorPosition(25, 9);
            Console.Write("Id:");
            Console.CursorLeft = 40;
            Console.WriteLine(GlobalVariables.Api.GetBook(GlobalVariables.BookId).Id);

            Console.CursorLeft = 25;
            Console.Write("Title:");
            Console.CursorLeft = 40;
            Console.WriteLine(GlobalVariables.Api.GetBook(GlobalVariables.BookId).Title);

            Console.CursorLeft = 25;
            Console.Write("Author:");
            Console.CursorLeft = 40;
            Console.WriteLine(GlobalVariables.Api.GetBook(GlobalVariables.BookId).Author.Name);

            Console.CursorLeft = 25;
            Console.Write("Category:");
            Console.CursorLeft = 40;
            Console.WriteLine(GlobalVariables.Api.GetBook(GlobalVariables.BookId).Category.Name);

            Console.CursorLeft = 25;
            Console.Write("Amount:");
            Console.CursorLeft = 40;
            Console.WriteLine(GlobalVariables.Api.GetBook(GlobalVariables.BookId).Amount);

            Console.CursorLeft = 25;
            Console.Write("Price:");
            Console.CursorLeft = 40;
            Console.WriteLine(GlobalVariables.Api.GetBook(GlobalVariables.BookId).Price);
        }
    }
}
