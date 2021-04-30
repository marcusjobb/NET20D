using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;
using WebbShopAPI.Utils;

namespace WebbShopAPI.View
{
    static class TxtView
    {
        /// <summary>
        /// Prints a message to the console and breaks line
        /// </summary>
        /// <param name="mess"></param>
        public static void MessLine(string mess)
        {
            Console.WriteLine(mess);
        }
        /// <summary>
        /// Prints message to console without breaking line
        /// </summary>
        /// <param name="mess"></param>
        public static void Mess(string mess)
        {
            Console.Write(mess);
        }
        /// <summary>
        /// Lists all categories
        /// </summary>
        /// <param name="categories"></param>
        public static void MessListOfCategories(List<BookCategory> categories)
        {
            foreach (BookCategory b in categories)
            {
                TxtView.MessLine(b.Name);
            }
        }
        /// <summary>
        /// Lists all the books
        /// </summary>
        /// <param name="books"></param>
        public static void MessListOfBook(List<Book> books)
        {
            foreach (Book b in books)
            {
                TxtView.MessLine(b.Title);
            }
        }
    }
}
