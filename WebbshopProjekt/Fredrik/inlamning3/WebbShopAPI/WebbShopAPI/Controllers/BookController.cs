using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI.Controllers
{
    /// <summary>
    /// Helper for managing any books
    /// </summary>
    public static class BookController
    {
        /// <summary>
        /// Get book by id number
        /// </summary>
        /// <param name="bookId">Book id</param>
        /// <returns>Book object</returns>
        public static Books GetBook(int bookId)
        {
            using var db = new WebbShopAPIContext();
            return db.Books.FirstOrDefault(
                b => b.Id == bookId
            );
        }

        /// <summary>
        /// Return any book with a certain keyword in it.
        /// </summary>
        /// <param name="keyword">Your needle for the haystack. You may search for any part of a title, such as "shi" from Stephen Kings book "The Shining".</param>
        /// <returns>A list of books matching your critera.</returns>
        public static List<Books> GetBooks(string keyword)
        {
            using var db = new WebbShopAPIContext();
            return db.Books.Where(
                b => b.Title.ToLower().Contains(keyword.ToLower())
            ).ToList();
        }

        /// <summary>
        /// Get a book by its exact title
        /// </summary>
        /// <param name="title">The exact title name, you can't use keywords to search.</param>
        /// <returns>A book</returns>
        public static Books GetBook(string title)
        {
            using var db = new WebbShopAPIContext();
            return db.Books.FirstOrDefault(
                b => b.Title.ToLower() == title.ToLower()
            );
        }

        /// <summary>
        /// Get all books in a certain category, independent of other criterias.
        /// </summary>
        /// <param name="categoryId">What category id to browse books by.</param>
        /// <returns>Returns any books that contains a category id matching the parameter.</returns>
        public static List<Books> GetCategory(int categoryId)
        {
            using var db = new WebbShopAPIContext();
            return db.Books.Where(
                b => b.CategoryId == categoryId
                ).ToList();
        }

        /// <summary>
        /// List books with a certain author.
        /// </summary>
        /// <param name="keyword">Your needle for the haystack. You may search for any part of a author, such as "ki" from Stephen King.</param>
        /// <returns>A list of books matching the search criteria.</returns>
        public static List<Books> GetAuthors(string keyword)
        {
            using var db = new WebbShopAPIContext();
            return db.Books.Where(
                b => b.Author.ToLower().Contains(keyword.ToLower())
            ).ToList();
        }

        /// <summary>
        /// Returns available books for a specific category
        /// </summary>
        /// <param name="categoryId">Category id</param>
        /// <returns>List of books</returns>
        public static List<Books> GetAvailableBooks(int categoryId)
        {
            using var db = new WebbShopAPIContext();
            return db.Books.Where(
                b => b.CategoryId == categoryId
            ).ToList();
        }

        /// <summary>
        /// Set the amount of copies of a certain book
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <param name="amount">The amount of copies to add</param>
        /// <returns>False if any of these conditions are not met:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The id is pointing to a book that doesn't exist
        /// </item>
        /// <item>
        /// The amount is less than 0
        /// </item>
        /// </list>
        /// </returns>
        public static bool SetAmount(int adminid, int bookId, int amount)
        {
            var book = GetBook(bookId);
            if (!UsersController.Ping(adminid) || !UsersController.IsAdmin(adminid) || book == null || amount < 0)
                return false;

            using var db = new WebbShopAPIContext();
            book.Amount = amount;
            db.Books.Update(book);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Add a book to your inventory. If the book already exists, the amount will automatically be added to that book instead.
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <param name="title">The original full title of the book</param>
        /// <param name="author">The author of the book</param>
        /// <param name="price">The price for each copy</param>
        /// <param name="amount">The amount of copies to add</param>
        /// <returns>Returns true if any modifications or additions was made, if any of these conditions are not met, false is returned:
        /// <list type="bullet">
        /// <item>
        ///  2 The book exists and was updated with the amount
        /// </item>
        /// <item>
        ///  1 The book didn't exist and was therefor created
        /// </item>
        /// <item>
        /// -1 The user is not an administrator
        /// </item>
        /// <item>
        /// -2 The title is empty
        /// </item>
        /// <item>
        /// -3 The author is empty
        /// </item>
        /// </list>
        /// </returns>
        public static bool AddBook(int adminid, int categoryId, string title, string author, double price, int amount)
        {
            if (!UsersController.Ping(adminid) || !UsersController.IsAdmin(adminid) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
                return false;

            var book = GetBook(title);
            using var db = new WebbShopAPIContext();

            if (book == null)
            {
                db.Books.Add(new Books()
                {
                    Amount = 1,         //Öka book.amount om boken redan  finns, annars sätt book.amount till  1
                    Title = title,
                    Author = author,
                    CategoryId = categoryId,
                    Price = price
                });
                db.SaveChanges();

                if(AddBookToCategory(adminid, GetBook(title).Id, categoryId))
                    return true;
                return false;
            }
            else
            {
                book.Amount += amount;
                db.Books.Attach(book);
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Update a book with new information. Any field left empty will not be set ("" or 0).
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <param name="title">New title, if left empty, no title will be updated</param>
        /// <param name="author">New author, if left empty, no new author will be set</param>
        /// <param name="price">New price, if set to 0, no new price will be set</param>
        /// <returns>Returns true if all conditions are met, if any of these are not met, false is returned:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The id is pointing to a book that doesn't exist
        /// </item>
        /// </list>
        /// </returns>
        public static bool UpdateBook(int adminid, int bookId, string title, string author, double price)
        {
            var book = GetBook(bookId);
            if (!UsersController.Ping(adminid) || !UsersController.IsAdmin(adminid) || book == null)
                return false;

            using var db = new WebbShopAPIContext();
            if (db.Books.FirstOrDefault(b => b.Title == title) == null)
            {
                if(title.Length > 0)
                    book.Title = title;
                if(author.Length > 0)
                    book.Author = author;
                if(price > 0)
                    book.Price = price;
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete one specific copy of a book
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <returns>Returns true if all conditions are met, if any of these are not met, false is returned:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The id is pointing to a book that doesn't exist
        /// </item>
        /// </list>
        /// </returns>
        public static bool DeleteBook(int adminid, int bookId)
        {
            if (!UsersController.IsAdmin(adminid))
                return false;
            return RemoveBook(bookId);
        }

        /// <summary>
        /// Just like delete book, it's just internal use
        /// </summary>
        /// <param name="bookId">The specific book to modify</param>
        /// <returns>Returns true if all conditions are met, if any of these are not met, false is returned:
        /// <list type="bullet">
        /// <item>
        /// The id is pointing to a book that doesn't exist
        /// </item>
        /// </list></returns>
        private static bool RemoveBook(int bookId)
        {
            var book = GetBook(bookId);
            if (book == null)
                return false;

            using var db = new WebbShopAPIContext();
            if (book.Amount > 0)
            {
                book.Amount -= 1;
                db.Update(book);
            }
            else
                db.Books.Remove(book);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Adds a category to the book.
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <param name="categoryId">Which category to add the book to</param>
        /// <returns>Returns true if all conditions are met, if any of these are not met, false is returned:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The id is pointing to a book that doesn't exist
        /// </item>
        /// <item>
        /// The id is pointing to a category that doesn't exist
        /// </item>
        /// <item>
        /// The book already has the category
        /// </item>
        /// </list></returns>
        public static bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            using var db = new WebbShopAPIContext();
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);

            if (!UsersController.Ping(adminId) || book == null || BookCategoryController.GetCategory(categoryId) == null || book.CategoryId == categoryId || !UsersController.IsAdmin(adminId))
                return false;

            book.CategoryId = categoryId;
            db.Books.Update(book);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Buy a book
        /// </summary>
        /// <param name="uid">User id who bought it</param>
        /// <param name="bookId">The specific book to modify</param>
        public static bool BuyBook(int uid, int bookId)
        {
            using var db = new WebbShopAPIContext();
            var book = GetBook(bookId);
            if (!UsersController.Ping(uid) || book == null)
                return false;

            if (book.Amount > 0)
            {
                book.Amount -= 1;
                db.Books.Update(book);

                SoldBooks soldBook = new SoldBooks()
                {
                    Author = book.Author,
                    CategoryId = book.CategoryId,
                    Price = book.Price,
                    PurchasedDate = DateTime.Now,
                    Title = book.Title,
                    UserId = uid
                };

                db.SoldBooks.Attach(soldBook);
                db.SoldBooks.Add(soldBook);
                db.SaveChanges();
                if (book.Amount <= 0)
                    RemoveBook(bookId);

                return true;
            }
            else
            {
                if(book.Amount <= 0)
                {
                    RemoveBook(bookId);
                    return false;
                }
            }
            return false;
        }
    }
}
