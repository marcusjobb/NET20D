using System.Collections.Generic;
using WebshopAPI.Models;

namespace WebshopMVC.UtilsMVC
{
    /// <summary>
    /// Class for converting List of Book objects/Book objects to List of List of base class objects.
    /// </summary>
    internal class BookConverters
    {
        /// <summary>
        /// Converts List of Book objects to List of List of base class objects.
        /// </summary>
        /// <param name="bookList"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> BookConverter(List<Book> bookList)
        {
            List<List<object>> bookListData = new List<List<object>>();
            foreach (var item in bookList)
            {
                bookListData.Add(new List<object> { item.Id, item.Title, item.Author, item.Price, item.Amount, item.CategoryId });
            }
            return bookListData;
        }

        /// <summary>
        /// Converts a Book object to List of List of base class objects.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> BookConverter(Book book)
        {
            List<List<object>> bookData = new List<List<object>>();
            if (book != null)
            {
                { new List<object>() { book.Id, book.Title, book.Author, book.Price, book.Amount, book.CategoryId }; }

                return bookData;
            }
            else
            {
                return bookData;
            }
        }
    }
}