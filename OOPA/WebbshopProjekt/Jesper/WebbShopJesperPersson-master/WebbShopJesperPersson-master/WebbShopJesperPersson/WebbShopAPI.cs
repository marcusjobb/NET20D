using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebbShopJesperPersson.Database;
using WebbShopJesperPersson.Model;

namespace WebbShopJesperPersson
{
    public class WebbShopAPI : APIHelper
    {
        /// <summary>
        /// Buy a book. Effects the amount with one down. Adds data to table Soldbooks.
        /// </summary>
        /// <param name="userId">id in database of user.</param>
        /// <param name="bookId">id in database of book.</param>
        /// <returns>true if transaction succeed, false if failure.</returns>

        public bool BuyBook(int userid, int bookId)
        {
            var user = GetUser(userid);
            if (IsSessionTimeOK(user))
            {
                var book = context.Books.Include("Category").FirstOrDefault(b => b.Id == bookId);
                if (book != null && user != null && book.Amount > 0)
                {
                    var soldbook = new SoldBook()
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Price = book.Price,
                        PurchasedDate = DateTime.Now,
                        User = user,
                        Category = book.Category
                    };

                    book.Amount--;

                    context.SoldBooks.Add(soldbook);

                    if (user.SoldBooks == null) user.SoldBooks = new List<SoldBook>();

                    user.SoldBooks.Add(soldbook);

                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            else return false;
        }

        /// <summary>
        /// Gets all book searching by keyword from authors.
        /// </summary>
        /// <param name="keyword">keyword for authors</param>
        /// <returns>List of books by searched author</returns>

        public List<Book> GetAuthors(string keyword)
        {
            return context.Books.Include("Category").Where(b => b.Author.Contains(keyword)).ToList();
        }

        /// <summary>
        /// Search for availble books by category.
        /// </summary>
        /// <param name="categoryId">the Id of the category</param>
        /// <returns>A list of available books, an empty list if non exist.</returns>
        public List<Book> GetAvailableBooksInCategory(int categoryId)
        {
            var list = context.Categories.Include("Books").Where(b => b.Id == categoryId).ToList();
            var availableBooks = new List<Book>();

            foreach (var category in list)
            {
                foreach (var book in category.Books)
                {
                    if (book.Amount > 0) availableBooks.Add(book);
                }
            }
            return availableBooks;
        }

        /// <summary>
        /// List all books with an amount higher then nr.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>a list of Book.</returns>
        public List<Book> GetAvailableBooks(int nr = 0) => context.Books.Include("Category").Where(b => b.Amount > nr).ToList();

        /// <summary>
        /// Get book by ID, includes Category.
        /// </summary>
        /// <param name="bookId">id in database of the book</param>
        /// <returns>The book or null</returns>
        public Book GetBook(int bookId)
        {
            return context.Books.Include("Category").FirstOrDefault(b => b.Id == bookId);
        }

        /// <summary>
        /// Method to search for books by using keyword.
        /// </summary>
        /// <param name="keyword">a letter or a title</param>
        /// <returns>List of Books containing keyword</returns>
        public List<Book> GetBooks(string keyword)
        {
            return context.Books.Include("Category").Where(b => b.Title.Contains(keyword)).ToList();
        }

        /// <summary>
        /// Method to get all categories in database.
        /// </summary>
        /// <returns>List of BookCategory, sorted by name</returns>
        public List<BookCategory> GetCategories()
        {
            return context.Categories.OrderBy(l => l.Name).ToList();
        }

        /// <summary>
        /// Overloaded method to get categories that contains keyword.
        /// </summary>
        /// <param name="keyword">Any letter or word you search for.</param>
        /// <returns>A list of BookCategory that contains the keyword.</returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            return context.Categories.Where(l => l.Name.Contains(keyword)).OrderBy(l => l.Name).ToList();
        }

        /// <summary>
        /// Get Books in certain category.
        /// </summary>
        /// <param name="categoryId">Id in database of category.</param>
        /// <returns>A list of books in choosen category.</returns>
        public List<Book> GetCategory(int categoryId)
        {
            return context.Books.Include("Category").Where(b => b.Category.Id == categoryId).OrderBy(b => b.Title).ToList();
        }

        /// <summary>
        /// Login a user. Checks if person is active and if password and name is correct.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns>User if succeed. Null if fails.</returns>

        public User Login(string userName, string passWord)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == userName && u.Password == passWord && u.IsActive);
            if (user != null)  // samma sökningar till andra områden. Gör allt i linq
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
                return user;
            }

            return null;// null = user dosen´t exsist.
        }

        /// <summary>
        /// Sets Sessiontimer to default.
        /// </summary>
        /// <param name="id"></param>
        public void LogOut(int userId)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.SessionTimer = DateTime.MinValue;
                    db.Update(user);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// To check if person still logged in.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Pong if still online. Empty string if sessiontime run out.</returns>
        public string Ping(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (IsSessionTimeOK(user))
            {
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
                return "Pong";
            }
            else return string.Empty;
        }

        /// <summary>
        /// To register a new user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns>returns true if succeed to register. False if user already exist or password cant verify.</returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == name);

            if (user == null && password == passwordVerify)
            {
                user = new User() { Name = name, Password = password, IsActive = true };
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}