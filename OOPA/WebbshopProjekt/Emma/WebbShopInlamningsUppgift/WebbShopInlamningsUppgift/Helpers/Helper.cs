using System.Linq;
using WebbShopInlamningsUppgift.Database;
using WebbShopInlamningsUppgift.Models;

namespace WebbShopInlamningsUppgift.Helpers
{
    /// <summary>
    /// Helper is used mainly to get ID's of user-object, category-object and book-object 
    /// </summary>
    class Helper
    {
        /// <summary>
        /// Allows you to get the Id of an user
        /// </summary>
        /// <param name="name"></param>
        /// <returns>int ID if successful, 0 if not.</returns>
        public static int GetUserID(string name)
        {
            using (var db = new WebbshopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == name);
                if (user != null)
                {
                    return user.ID;
                }
                return 0;
            }
        }

        /// <summary>
        /// Allows you to get the ID of a book
        /// </summary>
        /// <param name="title"></param>
        /// <returns>int ID if successful, 0 if not</returns>
        public static int GetBookID(string title)
        {
            using (var db = new WebbshopContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Title == title);
                if (book != null)
                {
                    return book.ID;
                }
                return 0;
            }
        }

        /// <summary>
        /// Allows you to get an book-object based on title
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Book</returns>
        public static Books GetBookObject(string title)
        {
            using (var db = new WebbshopContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Title == title);
                if (book != null)
                {
                    return book;
                }
                return null;
            }
        }

        /// <summary>
        /// Allows you get the ID of a category based on genere
        /// </summary>
        /// <param name="genere"></param>
        /// <returns>int ID if successful, 0 if not.</returns>
        public static int GetCategoryId(string genere)
        {
            using (var db = new WebbshopContext())
            {
                var category = db.BookCategories.FirstOrDefault(b => b.Genere == genere);
                if (category != null)
                {
                    return category.ID;
                }
                return 0;
            }
        }
    }
}
