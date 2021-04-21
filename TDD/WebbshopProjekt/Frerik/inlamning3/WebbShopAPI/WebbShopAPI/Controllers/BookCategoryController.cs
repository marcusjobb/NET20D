using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI.Controllers
{
    /// <summary>
    /// Helper for managing any categories/genres for books
    /// </summary>
    public static class BookCategoryController
    {
        /// <summary>
        /// Get all book categories (no filter).
        /// </summary>
        /// <returns>Every book category in db so far.</returns>
        public static List<BookCategory> GetCategories()
        {
            using var db = new WebbShopAPIContext();
            return db.BookCategories.ToList();
        }

        /// <summary>
        /// Add a new category.
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="name">The name you wish the category to have.</param>
        /// <returns>False if any of these conditions are not met:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The name is either null or empty (nothing is entered but "")
        /// </item>
        /// <item>
        /// The category already exists
        /// </item>
        /// </returns>
        public static bool AddCategory(int adminid, string name)
        {
            if (!UsersController.Ping(adminid) || !UsersController.IsAdmin(adminid) || string.IsNullOrEmpty(name))
                return false;

            using var db = new WebbShopAPIContext();
            if (db.BookCategories.FirstOrDefault(bc => bc.Name == name) == null)
            {
                db.BookCategories.Add(new BookCategory()
                {
                    Name = name
                });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get all categories by a search word (keyword).
        /// </summary>
        /// <param name="keyword">Your needle, what you want to search for. You can search for "rom" for Romance or "ram" for Drama.</param>
        /// <returns>A list of all categories that matches your search word.</returns>
        public static List<BookCategory> GetCategories(string keyword)
        {
            using var db = new WebbShopAPIContext();
            return db.BookCategories.Where(
                bc => bc.Name.Contains(keyword)
            ).ToList();
        }

        /// <summary>
        /// Update a category name.
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="categoryId">Which category you'd like to change name for</param>
        /// <param name="name">What name you want to set.</param>
        /// <returns>Returns false if any of these criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The category id is pointing to a category that doesn't exist.
        /// </item>
        /// <item>
        /// The name is either null or empty (not set (""))
        /// </item>
        /// </list>
        /// </returns>
        public static bool UpdateCategory(int adminid, int categoryId, string name)
        {
            using var db = new WebbShopAPIContext();
            var session = UsersController.Ping(adminid);
            var category = GetCategory(categoryId);
            if (!session || category == null || string.IsNullOrEmpty(name) || !UsersController.IsAdmin(adminid) || db.BookCategories.FirstOrDefault(bc => bc.Name == name) != null)
                return false;

            category.Name = name;
            db.BookCategories.Update(category);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Delete a category, to do this, you must not have any books related to this category.
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="categoryId">What category to delete</param>
        /// <returns>False if any of these criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The category id is pointing to a category that doesn't exist
        /// </item>
        /// <item>
        /// There are books that has this category assigned to it.
        /// </item>
        /// </list>
        /// </returns>
        public static bool DeleteCategory(int adminid, int categoryId)
        {
            var category = GetCategory(categoryId);
            if (!UsersController.Ping(adminid) || !UsersController.IsAdmin(adminid) || category == null)
                return false;

            using var db = new WebbShopAPIContext();
            var books = db.Books
                .Where(b => b.CategoryId == categoryId);
            
            if (books == null)
            {
                db.BookCategories.Remove(category);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get a category based on a search word (keyword). 
        /// </summary>
        /// <param name="keyword">Your needle you want to search with. For example you can use "rom" for Romance or "ram" for Drama</param>
        /// <returns>A single category object that matches your search word</returns>
        public static BookCategory GetCategory(string keyword)
        {
            using var db = new WebbShopAPIContext();
            return db.BookCategories.FirstOrDefault(bc => bc.Name.ToLower().Contains(keyword.ToLower()));
        }

        /// <summary>
        /// Get a category based on its Id.
        /// </summary>
        /// <param name="id">The id of the category you wish to retrieve</param>
        /// <returns>A single category object that matches your id</returns>
        public static BookCategory GetCategory(int id)
        {
            using var db = new WebbShopAPIContext();
            return db.BookCategories.FirstOrDefault(bc => bc.Id == id);
        }
    }
}
