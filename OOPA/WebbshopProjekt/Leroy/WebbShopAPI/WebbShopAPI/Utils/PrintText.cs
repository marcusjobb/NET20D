using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;
using WebbShopAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace WebbShopAPI.Utils
{
    static class PrintText
    {
        /// <summary>
        /// Returns title, author price and category of a book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static string GetInformationAboutBook(Book book)
        {
            string category;
            using (var db = new WebbShopLeeContext())
            {
                var cat = db.BookCategories.FirstOrDefault(_ => _.ID == book.ID);
                category = cat.Name;
                return $"Title: {book.Title}\nAuthor: {book.Author}\nPrice: {book.Price}\nCategory: {category}";
            }
        }
    }
}
