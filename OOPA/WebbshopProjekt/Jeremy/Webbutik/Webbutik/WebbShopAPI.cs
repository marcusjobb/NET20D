using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Webbutik.Database;
using Webbutik.Models;

namespace Webbutik
{
    public class WebbShopAPI
    {
        /// <summary>
        /// Defines the context.
        /// </summary>
        private ShopContext shopContext = new ShopContext();

        /// <summary>
        /// Allows the user to log in.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>Returns the user if success and null if it fails.</returns>
        public User Login(string userName, string password)
        {
            var user = shopContext.Users.FirstOrDefault(
                u => u.Name == userName && u.Password == password && u.IsActive == false);

            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                user.IsActive = true;
                shopContext.Users.Update(user);
                shopContext.SaveChanges();

                return user;
            }

            return null; // return null if the user does not exist.
        }

        /// <summary>
        /// Allows the user to log out.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        public void Logout(int userId)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue; // Resets the Sessiontimer.
                user.IsActive = false;
                shopContext.Users.Update(user);
                shopContext.SaveChanges();
            }
        }

        /// <summary>
        /// Lists all categories.
        /// </summary>
        /// <returns>Returns a list of all categories.</returns>
        public List<BookCategory> GetCategories()
        {
            return shopContext.BookCategories.ToList();
        }

        /// <summary>
        /// Lists all categories with the matching keyword.
        /// </summary>
        /// <param name="keyword">A keyword to find a specific or all matching categories.</param>
        /// <returns>Returns all categories with the matching keyword.</returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            return shopContext.BookCategories.Where(c => c.Name.Contains(keyword)).ToList();
        }

        /// <summary>
        /// Gets all books with the same category.
        /// </summary>
        /// <param name="categoryId">The id of the category.</param>
        /// <returns>List of books with the same category.</returns>
        public List<Book> GetCategory(int categoryId)
        {
            return shopContext.Books.Include("Category").Include("Author").Where(
                b => b.CategoryId == categoryId).ToList();
        }

        /// <summary>
        /// Gets all the available books in a specific category and with at least 1 book left.
        /// </summary>
        /// <param name="categoryId">The id of the category.</param>
        /// <returns>All available books in the specific category.</returns>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            return shopContext.Books.Include("Author").Where(
                b => b.Amount > 0 && b.CategoryId == categoryId).ToList();
        }

        /// <summary>
        /// Gets the specified book.
        /// </summary>
        /// <param name="bookId">The id of the book.</param>
        /// <returns>Returns the specified book.</returns>
        public Book GetBook(int bookId)
        {
            var book = shopContext.Books.Include("Author").Include("Category").FirstOrDefault(
                b => b.Id == bookId);

            if (book != null)
            {
                return shopContext.Books.Include("Author").Include("Category").FirstOrDefault(
                    b => b.Id == bookId);
            }

            return new Book
            {
                Title = "No value",
                Category = new BookCategory { Name = "No value" },
                Author = new Author { Name = "No value" },
                Amount = 0,
                Price = 0
            };
        }

        /// <summary>
        /// Gets all matching books.
        /// </summary>
        /// <param name="keyword">The keyword to search for matching books.</param>
        /// <returns>A list with all matching books.</returns>
        public List<Book> GetBooks(string keyword)
        {
            return shopContext.Books.Include("Category").Include("Author").Where(
                b => b.Title.Contains(keyword)).ToList();
        }

        /// <summary>
        /// Gets all matching matching books with the matching author.
        /// </summary>
        /// <param name="keyword">A keyword to search for an author.</param>
        /// <returns>A list with all books of the matching author.</returns>
        public List<Book> GetAuthors(string keyword)
        {
            return shopContext.Books.Include("Author").Include("Category").Where(
                b => b.Author.Name.Contains(keyword))
                .ToList();
        }

        /// <summary>
        /// Allows the user to buy a book.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="bookId">The id of the book.</param>
        /// <returns>Returns true if the user exists, the user is not inactive and the book does 
        /// exist and the books amount is at least 1. Returns false if the user does not exists or 
        /// the user is inactive or the book does not exists or the amount is 0.</returns>
        public bool BuyBook(int userId, int bookId)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == userId);
            var book = shopContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (user != null && user.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                if (book != null && book.Amount > 0)
                {
                    shopContext.SoldBooks.Add(new SoldBook
                    {
                        Title = book.Title,
                        AuthorId = book.AuthorId,
                        CategoryId = book.CategoryId,
                        Price = book.Price,
                        UserId = user.Id,
                        PurchasedDate = DateTime.Now
                    });
                    shopContext.SaveChanges();

                    book.Amount -= 1;
                    shopContext.Update(book);
                    shopContext.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the user is still active. If the user is inactive he will get logged out.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>"pong" if the user is still active and an empty string if the user is 
        /// inactive.</returns>
        public string Ping(int userId)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == userId);

            if (user.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                user.SessionTimer = DateTime.Now;
                shopContext.Update(user);
                shopContext.SaveChanges();
                return "pong";
            }

            Logout(userId);
            return string.Empty;
        }

        /// <summary>
        /// Lets the user create a new account. 
        /// </summary>
        /// <param name="name">The name of the new user.</param>
        /// <param name="password">The password.</param>
        /// <param name="passwordVerify">The password.</param>
        /// <returns>true if the account is successfully created and false if the account could not 
        /// be created.</returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Name == name);

            if (user == null && password == passwordVerify)
            {
                shopContext.Users.Add(new User
                {
                    Name = name,
                    Password = password,
                    IsAdmin = false,
                    IsActive = false
                });
                shopContext.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Lets the admin add a new book.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The name of the author.</param>
        /// <param name="price">The price of the book.</param>
        /// <param name="amount">The amount of the book.</param>
        /// <returns></returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            var book = shopContext.Books.FirstOrDefault(b => b.Title == title);
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);
            var category = shopContext.BookCategories.FirstOrDefault(c => c.Name == "No Category");

            if (user.IsAdmin == true)
            {
                if (book != null)
                {
                    book.Amount += amount;
                    shopContext.Update(book);
                    shopContext.SaveChanges();
                    return true;
                }
                else
                {
                    shopContext.Books.Add(new Book
                    {
                        Title = title,
                        AuthorId = AddAuthor(author),
                        Price = price,
                        Amount = amount,
                        CategoryId = category.Id
                    });
                    shopContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Creates a new author.
        /// </summary>
        /// <param name="name">The name of the author.</param>
        /// <returns>The id of the author.</returns>
        private int AddAuthor(string name)
        {
            var author = shopContext.Authors.FirstOrDefault(a => a.Name == name);

            if (author == null)
            {
                shopContext.Authors.Add(new Author { Name = name });
                shopContext.SaveChanges();
            }

            author = shopContext.Authors.FirstOrDefault(a => a.Name == name);

            return author.Id;
        }

        /// <summary>
        /// Sets a new amount of the specifies book.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="bookId">The id of the book.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>The amount of the book if the book exist and changed successfully, returns 0 
        /// if the book does not exist.</returns>
        public int SetAmount(int adminId, int bookId, int amount)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);
            var book = shopContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                book.Amount = amount;
                shopContext.Update(book);
                shopContext.SaveChanges();
                return book.Amount;
            }

            return 0;
        }

        /// <summary>
        /// Lists all users.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <returns>A list with all users exclusive admins.</returns>
        public List<User> ListUsers(int adminId)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);

            if (user.IsAdmin == true)
            {
                return shopContext.Users.Where(u => u.IsAdmin == false).ToList();
            }

            return new List<User>();
        }

        /// <summary>
        /// Find a specific or matching users.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="keyword">The keyword to search for a user with.</param>
        /// <returns>A list with the user or all matching users.</returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);

            if (user.IsAdmin == true)
            {
                return shopContext.Users.Where(u => u.IsAdmin == false && u.Name.Contains(keyword))
                    .ToList();
            }

            return new List<User>();
        }

        /// <summary>
        /// Updates the information of the book.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="bookId">The id of the book.</param>
        /// <param name="title">The title of the book.</param>
        /// <param name="authorName">The name of the author.</param>
        /// <param name="price">The price of the book.</param>
        /// <returns>true if successfully updated the book, false if the book doesn't exist.
        /// </returns>
        public bool UpdateBook(int adminId, int bookId, string title, string authorName, int price)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);
            var book = shopContext.Books.FirstOrDefault(b => b.Id == bookId);
            var author = shopContext.Authors.FirstOrDefault(a => a.Name == authorName);

            if (user.IsAdmin == true)
            {
                if (book != null)
                {
                    book.Title = title;
                    book.AuthorId = author.Id;
                    book.Price = price;
                    shopContext.Update(book);
                    shopContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes one book at a time and if the amount is 0 the book is deleted.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="bookId">The id of the book.</param>
        /// <returns>true if the book is successfully deleted and false if the book does not exist.
        /// </returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);
            var book = shopContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (user.IsAdmin == true)
            {
                if (book != null)
                {
                    if (book.Amount > 0)
                    {
                        book.Amount -= 1;
                        shopContext.Update(book);
                        shopContext.SaveChanges();
                    }
                    else
                    {
                        shopContext.Remove(book);
                        shopContext.SaveChanges();
                    }
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Add a new category.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="categoryName">The name of the category.</param>
        /// <returns>true of the category is created successfully, false if the category already 
        /// exist.</returns>
        public bool AddCategory(int adminId, string categoryName)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);
            var category = shopContext.BookCategories.FirstOrDefault(c => c.Name == categoryName);

            if (user.IsAdmin == true)
            {
                if (category == null)
                {
                    shopContext.BookCategories.Add(new BookCategory { Name = categoryName });
                    shopContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Adds a book to the specified category.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="bookId">The id of the book.</param>
        /// <param name="categoryId">The id of the category.</param>
        /// <returns>true if the book is successfully added to the category, false if the book does 
        /// not exist of the category does not exist.</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);
            var book = shopContext.Books.FirstOrDefault(b => b.Id == bookId);
            var category = shopContext.BookCategories.FirstOrDefault(c => c.Id == categoryId);

            if (user.IsAdmin == true)
            {
                if (book != null && category != null)
                {
                    book.CategoryId = category.Id;
                    shopContext.Update(book);
                    shopContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Update a specified category.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="categoryId">The id of the category.</param>
        /// <param name="categoryName">The new name of the category.</param>
        /// <returns>true if the category is successfully updated, false if the category does not 
        /// exists.</returns>
        public bool UpdateCategory(int adminId, int categoryId, string categoryName)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);
            var category = shopContext.BookCategories.FirstOrDefault(c => c.Id == categoryId);

            if (user.IsAdmin == true)
            {
                if (category != null)
                {
                    category.Name = categoryName;
                    shopContext.Update(category);
                    shopContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Deletes a category if no book has the specified category.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="categoryId">The id of the category.</param>
        /// <returns>true if the category is successfully deleted, false if the category is still 
        /// in use or the category does not exist.</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);
            var category = shopContext.BookCategories.FirstOrDefault(c => c.Id == categoryId);
            var booksWithCategory = shopContext.Books.Where(b => b.CategoryId == categoryId);

            if (user.IsAdmin == true)
            {
                if (category != null && booksWithCategory.Count() == 0)
                {
                    shopContext.BookCategories.Remove(category);
                    shopContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The admin creates a new user.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="username">The name of the new user.</param>
        /// <param name="password">The password of the new user.</param>
        /// <returns>true if the user is successfully created, false if the username is taken by an 
        /// existing user.</returns>
        public bool AddUser(int adminId, string username, string password = "Codic2021")
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Name == username);
            var admin = shopContext.Users.FirstOrDefault(a => a.Id == adminId);

            if (admin.IsAdmin == true && user == null)
            {
                shopContext.Users.Add(new User
                {
                    Name = username,
                    Password = password,
                    IsActive = false,
                    IsAdmin = false
                });
                shopContext.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all sold items.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <returns>A list of all sold items. If no item is sold, it will return an empty list.
        /// </returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);

            if (user.IsAdmin == true)
            {
                return shopContext.SoldBooks.ToList();
            }

            return new List<SoldBook>();
        }

        /// <summary>
        /// Gets the money earned.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <returns>The money earned. Returns 0 if no money is earned.</returns>
        public int MoneyEarned(int adminId)
        {
            var user = shopContext.Users.FirstOrDefault(u => u.Id == adminId);

            if (user.IsAdmin == true)
            {
                var money = shopContext.SoldBooks.Where(s => s.Price > 0).ToList();
                int moneyEarned = 0;
                foreach (var item in money)
                {
                    moneyEarned += item.Price;
                }

                return moneyEarned;
            }

            return 0;
        }

        /// <summary>
        /// Gets the customer who purchased most books.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <returns>a string with the name of the best customer, returns an empty string if there 
        /// is no customer.</returns>
        public string BestCustomer(int adminId)
        {
            var admin = shopContext.Users.FirstOrDefault(u => u.Id == adminId);

            if (admin.IsAdmin == true)
            {
                return shopContext.Users.Where(u => u.SoldBooks.Count() > 0)
                    .OrderByDescending(u => u.Id)
                    .FirstOrDefault().Name;
            }

            return string.Empty;
        }

        /// <summary>
        /// Promotes a user to admin.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="userId">The id of the user.</param>
        /// <returns>true if the user is successfully promoted, false if the user does not exist.
        /// </returns>
        public bool Promote(int adminId, int userId)
        {
            var admin = shopContext.Users.FirstOrDefault(a => a.Id == adminId);
            var user = shopContext.Users.FirstOrDefault(u => u.Id == userId);

            if (admin.IsAdmin == true && user != null)
            {
                user.IsAdmin = true;
                shopContext.Update(user);
                shopContext.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Demotes an admin to user.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="userId">The id of the admin who should be demoted.</param>
        /// <returns>true if the user is successfully demoted, false if the user does not exist.
        /// </returns>
        public bool Demote(int adminId, int userId)
        {
            var admin = shopContext.Users.FirstOrDefault(a => a.Id == adminId);
            var user = shopContext.Users.FirstOrDefault(u => u.Id == userId);

            if (admin.IsAdmin == true && user != null)
            {
                user.IsAdmin = false;
                shopContext.Update(user);
                shopContext.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Set a users status to active.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="userId">The id of the user.</param>
        /// <returns>true if the user is successfully updated to active, false if the user does not 
        /// exist.</returns>
        public bool ActivateUser(int adminId, int userId)
        {
            var admin = shopContext.Users.FirstOrDefault(a => a.Id == adminId);
            var user = shopContext.Users.FirstOrDefault(u => u.Id == userId);

            if (admin.IsAdmin == true && user != null)
            {
                user.IsActive = true;
                shopContext.Update(user);
                shopContext.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Set a users status to inactive.
        /// </summary>
        /// <param name="adminId">The id of the admin.</param>
        /// <param name="userId">The id of the user.</param>
        /// <returns>true if the user is successfully updated to inactive, false if the user does 
        /// not exist.</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            var admin = shopContext.Users.FirstOrDefault(a => a.Id == adminId);
            var user = shopContext.Users.FirstOrDefault(u => u.Id == userId);

            if (admin.IsAdmin == true && user != null)
            {
                user.IsActive = false;
                shopContext.Update(user);
                shopContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
