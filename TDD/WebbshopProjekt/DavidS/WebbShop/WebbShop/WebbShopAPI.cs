using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebbShop.Models;
using static WebbShop.Helpers.HelperMethods;

namespace WebbShop
{
    public class WebbShopAPI
    {
        /// <summary>
        /// An admin method that acitvates a specidfied <see cref="User"/>. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns><see langword="true"/> if the user is activated,
        /// otherwise <see langword="false"/>.</returns>
        public bool ActivateUser(int adminId, int userId)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && UserExists(userId, out var user))
            {
                user.IsActive = true;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that adds a <see cref="Book"/> to the database.
        /// If the book already exists the amount will be increased instead.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns><see langword="true"/> if the book was added,
        /// otherwise <see langword="false"/>.</returns>
        public bool AddBook(
            int adminId,
            int bookId,
            string title,
            string author,
            double price,
            int amount)
        {
            if (title.IsNullOrEmpty()
                || author.IsNullOrEmpty()
                || price < 0
                || amount < 0)
            {
                return false;
            }

            if (UserIsAdminAndLoggedIn(adminId))
            {
                if (BookExists(bookId, out Book book))
                {
                    book.Amount += amount;
                    db.Books.Update(book);
                }
                else
                {
                    db.Books.Add(new Book
                    {
                        Title = title,
                        Author = author,
                        Price = price,
                        Amount = amount
                    });
                }

                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that adds a specified <see cref="Book"/>
        /// to a specified <see cref="BookCategory"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns><see langword="true"/> if the book was added
        /// to the category, otherwise <see langword="false"/>.</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && BookExists(bookId, out var book)
                && CategoryExists(categoryId, out var category))
            {
                book.Category = category;
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that adds a new
        /// <see cref="BookCategory"/> to the database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns><see langword="true"/> if the category
        /// was added, otherwise <see langword="false"/>.</returns>
        public bool AddCategory(int adminId, string name)
        {
            if (name.IsNullOrEmpty())
            {
                return false;
            }

            if (UserIsAdminAndLoggedIn(adminId)
                && !CategoryExists(name))
            {
                db.BookCategories.Add(new BookCategory { Name = name });
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that adds a new
        /// <see cref="User"/> to the database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns><see langword="true"/> if the user
        /// is added, otherwise <see langword="false"/></returns>
        public bool AddUser(int adminId, string name, string password)
        {
            if (name.IsNullOrEmpty())
            {
                return false;
            }

            if (UserIsAdminAndLoggedIn(adminId)
                && !UserExists(name))
            {
                if (password.IsNullOrEmpty())
                {
                    password = "Codic2021";
                }

                db.Users.Add(new User
                {
                    Name = name,
                    Password = password,
                    IsActive = true,
                    IsAdmin = false
                });
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that retrieves the <see cref="User"/>
        /// that has bought the most books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>The <see cref="User"/> who has
        /// bought the most books.</returns>
        public (User customer, int books) BestCustomer(int adminId)
        {
            var customersWithBooks = new List<(User customer, int books)>();
            if (UserIsAdminAndLoggedIn(adminId)
                && db.SoldBooks.Count() > 0)
            {
                foreach (var customer in db.SoldBooks
                    .Select(s => s.User)
                    .Distinct()
                    .ToList())
                {
                    var booksBought = db.SoldBooks.Count(s => s.User == customer);
                    customersWithBooks.Add((customer, booksBought));
                }
            }

            return customersWithBooks
                   .OrderByDescending(c => c.books)
                   .FirstOrDefault();
        }

        /// <summary>
        /// Lets a logged in user buy a
        /// specified available <see cref="Book"/>.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns><see langword="true"/> if the book was
        /// purchased, otherwise <see langword="false"/>.</returns>
        public bool BuyBook(int userId, int bookId)
        {
            if (UserExists(userId, out var user)
                && user.IsActive
                && user.IsLoggedIn()
                && BookExists(bookId, out var book)
                && book.IsAvailable())
            {
                book.Amount--;
                db.SoldBooks.Add(new SoldBook
                {
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category,
                    Price = book.Price,
                    PurchasedDate = DateTime.Now,
                    User = user
                });
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that reduces the amount
        /// of a <see cref="Book"/> by one. If the amount
        /// is reduced to 0 the book will be removed from
        /// the databse.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns><see langword="true"/> if the book was deleted,
        /// otherwise <see langword="false"/>.</returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && BookExists(bookId, out Book book))
            {
                book.Amount--;
                if (book.Amount < 1)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return true;
                }
                db.Books.Update(book);
                db.SaveChanges();
            }

            return false;
        }

        /// <summary>
        /// An admin method that removes a <see cref="BookCategory"/>
        /// from the database if no books are connected to it.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns><see langword="true"/> if the category was deleted,
        /// otherwise <see langword="false"/>.</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && CategoryExists(categoryId, out var category))
            {
                var books = db.Books.Where(b => b.Category == category);
                if (books.Count() == 0)
                {
                    db.BookCategories.Remove(category);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// An admin method that demotes an specified admin into a user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns><see langword="true"/> if the admin was demoted,
        /// otherwise <see langword="false"/>.</returns>
        public bool Demote(int adminId, int userId)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && UserExists(userId, out var user))
            {
                user.IsAdmin = false;
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that searches the database for users
        /// that match the <paramref name="keyword"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>An ordered <see cref="List{T}"/> of
        /// <see cref="User"/> that match the
        /// <paramref name="keyword"/>.</returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            var users = new List<User>();
            if (UserIsAdminAndLoggedIn(adminId))
            {
                users = db.Users
                    .Where(u => u.Name.Contains(keyword))
                    .OrderBy(u => u.Name)
                    .ToList();
            }

            return users;
        }

        /// <summary>
        /// Seraches the database for books with authors that
        /// match <paramref name="keyword"/>.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>A list of books that with authors that match
        /// <paramref name="keyword"/>.</returns>
        public List<Book> GetAuthors(string keyword)
        {
            return db.Books
                .Include(b => b.Category)
                .Where(b => b.Author.Contains(keyword))
                .OrderBy(b => b.Title)
                .ToList();
        }

        /// <summary>
        /// Gets all available books of a specified <see cref="BookCategory"/>.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>An ordered <see cref="List{T}"/> of available books
        /// of the specified <see cref="BookCategory"/>.</returns>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            return db.Books
                .Where(b => b.Category.Id == categoryId && b.Amount > 0)
                .OrderBy(b => b.Title)
                .ToList();
        }

        /// <summary>
        /// Searches the database for a book that
        /// matches the <paramref name="bookId"/>.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>A <see cref="Book"/> that matches <paramref name="bookId"/>
        /// or <see langword="null"/> if there was no match.</returns>
        public Book GetBook(int bookId)
        {
            return db.Books
                .Include(b => b.Category)
                .FirstOrDefault(b => b.Id == bookId);
        }

        /// <summary>
        /// Searches the database for all books that match the
        /// <paramref name="keyword"/>.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>An ordered <see cref="List{T}"/> of books
        /// that match the <paramref name="keyword"/>.</returns>
        public List<Book> GetBooks(string keyword)
        {
            return db.Books
                .Include(b => b.Category)
                .Where(b => b.Title.Contains(keyword))
                .OrderBy(b => b.Title)
                .ToList();
        }

        /// <summary>
        /// Gets all book categories from the database sorted by name.
        /// </summary>
        /// <returns>An ordered <see cref="List{T}"/>
        /// of all book categories.</returns>
        public List<BookCategory> GetCategories()
        {
            return db.BookCategories
                .OrderBy(c => c.Name)
                .ToList();
        }

        /// <summary>
        /// Gets the book categories that match the <paramref name="keyword"/>.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>An ordered <see cref="List{T}"/>
        /// of matching book categories.</returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            return db.BookCategories
                .Where(c => c.Name.Contains(keyword))
                .OrderBy(c => c.Name)
                .ToList();
        }

        /// <summary>
        /// Gets all books that belong to a
        /// specific <see cref="BookCategory"/>. 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>An ordered <see cref="List{T}"/> of
        /// books that belong to the specified
        /// <see cref="BookCategory"/>.</returns>
        public List<Book> GetCategory(int categoryId)
        {
            return db.Books
                .Where(b => b.Category.Id == categoryId)
                .OrderBy(b => b.Title)
                .ToList();
        }

        /// <summary>
        /// An admin method that inactivates
        /// a specified <see cref="User"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns><see langword="true"/> if the user was
        /// inactivated, otherwise <see langword="false"/>.</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && UserExists(userId, out var user))
            {
                user.IsActive = false;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that gets
        /// all the users in the database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>An ordered <see cref="List{T}"/>
        /// of all the users in the database.</returns>
        public List<User> ListUsers(int adminId)
        {
            var users = new List<User>();
            if (UserIsAdminAndLoggedIn(adminId))
            {
                users = db.Users.OrderBy(u => u.Name).ToList();
            }

            return users;
        }

        /// <summary>
        /// Takes the <paramref name="username"/> and the
        /// <paramref name="password"/> and searches the
        /// database for a match. If there is a match
        /// LastLogIn and SessionTimer is set.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>The id of the <see cref="User"/> or 0.</returns>
        public int Login(string username, string password)
        {
            if (username.IsNullOrEmpty()
                || password.IsNullOrEmpty())
            {
                return 0;
            }

            if (UserExists(username, password, out var user)
                && user.IsActive)
            {
                user.LastLogIn = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return user.Id;
            }

            return 0;
        }

        /// <summary>
        /// Sets a specified users session timer to a
        /// minimum value which loggs out the user.
        /// </summary>
        /// <param name="userId"></param>
        public void Logout(int userId)
        {
            if (UserExists(userId, out var user))
            {
                user.SessionTimer = DateTime.MinValue;
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves the total sum
        /// of all earnings from sold books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>The sum of all earnings.</returns>
        public double MoneyEarned(int adminId)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && db.SoldBooks.Count() > 0)
            {
                return db.SoldBooks.Sum(s => s.Price);
            }

            return 0;
        }

        /// <summary>
        /// Updates a specified users Session timer.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Pong if the ping was successfull,
        /// otherwise an empty string.</returns>
        public string Ping(int userId)
        {
            if (UserExists(userId, out var user)
                && user.IsActive
                && user.IsLoggedIn())
            {
                user.SessionTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return "Pong";
            }

            return string.Empty;
        }

        /// <summary>
        /// An admin method that promotes
        /// a user to admin status.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns><see langword="true"/> if user is
        /// promoted, otherwise <see langword="false"/>.</returns>
        public bool Promote(int adminId, int userId)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && UserExists(userId, out var user))
            {
                user.IsAdmin = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Registers a new user to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns><see langword="true"/> if user was
        /// registered, otherwise <see langword="false"/>.</returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            if (name.IsNullOrEmpty()
                || password.IsNullOrEmpty()
                || passwordVerify.IsNullOrEmpty())
            {
                return false;
            }

            if (!UserExists(name)
                && password.Equals(passwordVerify)
                && password != string.Empty)
            {
                db.Users.Add(new User
                {
                    Name = name,
                    Password = password,
                    IsActive = true,
                    IsAdmin = false
                });
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that sets the <paramref name="amount"/>
        /// of a specified <see cref="Book"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        public void SetAmount(int adminId, int bookId, int amount)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && BookExists(bookId, out var book))
            {
                book.Amount = amount;
                db.Books.Update(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// An admin method that retrieves
        /// a list of all sold books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>An ordered <see cref="List{T}"/>
        /// of all sold books.</returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            if (UserIsAdminAndLoggedIn(adminId)
                && db.SoldBooks.Count() > 0)
            {
                return db.SoldBooks
                    .Include(s => s.Category)
                    .Include(s => s.User)
                    .OrderBy(s => s.Title).ToList();
            }

            return null;
        }

        /// <summary>
        /// An admin method that updates the <paramref name="title"/>,
        /// <paramref name="author"/> and <paramref name="price"/>
        /// of a specified book.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns><see langword="true"/> if update is successfull.
        /// otherwise <see langword="false"/>.</returns>
        public bool UpdateBook(
            int adminId,
            int bookId,
            string title,
            string author,
            double price)
        {
            if (title.IsNullOrEmpty()
                || author.IsNullOrEmpty()
                || price < 0)
            {
                return false;
            }

            if (UserIsAdminAndLoggedIn(adminId)
                && BookExists(bookId, out Book book))
            {
                book.Title = title;
                book.Author = author;
                book.Price = price;
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// An admin method that updates the <paramref name="name"/>
        /// of a specified <see cref="BookCategory"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns><see langword="true"/> if the update is successfull,
        /// otherwise <see langword="false"/>.</returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            if (name.IsNullOrEmpty() || CategoryExists(name))
            {
                return false;
            }

            if (UserIsAdminAndLoggedIn(adminId)
                && CategoryExists(categoryId, out BookCategory category))
            {
                category.Name = name;
                db.BookCategories.Update(category);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the user is an admin based on the <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns><see langword="true"/> if the user is an admin,
        /// otherwise <see langword="false"/>.</returns>
        public bool UserIsAdmin(int userId)
        {
            return UserExists(userId, out var user) && user.IsAdmin;
        }
    }
}
