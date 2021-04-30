using Inlamning2TrialRunHE.Models;
using static Inlamning2TrialRunHE.Helper.HelperMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Inlamning2TrialRunHE
{
    /* Many of these methods contains tips and help from 
       David Ström and Emil Örjes. */

    public class WebbShopAPI
    {
        /// <summary>
        /// Adds a book to the database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns>True if a book is added, 
        /// false if no book is added.</returns>
         
        public bool Addbook(
            int adminId,
            int id,
            string title,
            string author,
            int price,
            int amount)
        {
            if (UserIsAdminAndLoggedIn(adminId))
            {
                var book = (from b 
                            in db.Books 
                            where b.Id == id 
                            select b).FirstOrDefault();
                if (book != null)
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
        /// Adds a book to the choosen category.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns>True if a book is added to the category,
        /// false if it fails.</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {

            if (UserIsAdminAndLoggedIn(adminId))
            {
                if (BookExists(bookId, out var book))
                {
                    if (CategoryExists(categoryId, out var category))
                    {
                        book.Category = category;
                        db.Books.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Adds a category to the database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns>True if a category is added, 
        /// false if it fails to add a category.</returns>
        public bool AddCategory(int adminId, string name)
        {
            if (UserIsAdminAndLoggedIn(adminId))
            {
                var category = (from c in db.BookCategories 
                                where c.Name == name 
                                select c).FirstOrDefault();
                if (category == null)
                {
                    db.BookCategories.Add(new BookCategory { Name = name });
                }
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds a user to the database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>Returns true if user is added, 
        /// false if it fails to add a user.</returns>
        public bool AddUser(int adminId, string name, string password)
        {
            if (UserIsAdminAndLoggedIn(adminId))
            {
                var user = (from u in db.Users 
                            where u.Name == name && u.Password == password 
                            select u).FirstOrDefault();
                if (user == null && password != "")
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
            }

            return false;
        }

        /// <summary>
        /// Checks if the choosen book exists in stock.
        /// If the book exists the user can buy it and
        /// 1 book is removed from the amount.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns>True if a book has been bought,
        /// false if the purchase failed.</returns>
        public bool BuyBook(int userId, int bookId)
        {
            var user = (from u in db.Users 
                        where u.Id == userId && u.IsActive && u.SessionTimer 
                        > DateTime.Now.AddMinutes(-MaxTime) 
                        select u).FirstOrDefault();

            if (user != null 
                && BookExists(bookId, out var book) 
                && book.Amount > 0)
            {
                db.SoldBooks.Add(new SoldBook
                {
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category,
                    Price = book.Price,
                    PurchaseDate = DateTime.Now,
                    User = user
                });
                book.Amount--;
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// DeleteBook is used to check if the book that is beeing deleted
        /// exists and if so deletes one book.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns>true if success, false if fail</returns>
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
        /// Checks if the user is admin and the category exits.
        /// If they are correct and there is no book in the category,
        /// the category is deleted.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            if (UserIsAdminAndLoggedIn(adminId) 
                && CategoryExists(categoryId, out var category))
            {
                var books = (from b 
                             in db.Books 
                             where b.Category == category 
                             select b);
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
        /// Checks if the user is a admin and logged in.
        /// If so checks if the users name contains the keyword.
        /// And adds it to a list that then is returned.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>A list of users matching the contains keyword.
        /// null if there is no match for the contains keyword.</returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            if (UserIsAdminAndLoggedIn(adminId))
            {
                var users = (from u in db.Users 
                             where u.Name.Contains(keyword) 
                             select u).ToList();
                return users;
            }

            return null;
        }

        /// <summary>
        /// Search a keyword to see if
        /// any Author contains the keyword.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>A list of books containing the author search.</returns>
        public List<Book> GetAuthors(string keyword)
        {
            var books = (from b 
                         in db.Books 
                         where b.Author.Contains(keyword) 
                         select b).ToList();

            return books;
        }

        /// <summary>
        /// Search the categoryId and if there is more then 0
        /// books in the category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>A list of books that has a value 
        /// above amount 0 if any.</returns>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            var books = (from b 
                         in db.Books 
                         where b.Amount > 0 && b.Category.Id == categoryId 
                         select b).ToList();
            return books;
        }

        /// <summary>
        /// Searches for a book with the users given bookId.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>The book object if it exists, 
        /// default if it does not exist.</returns>
        public Book GetBook(int bookId)
        {
            var book = (from b 
                        in db.Books 
                        where b.Id == bookId 
                        select b).Include(b => b.Category).FirstOrDefault();

            return book;
        }

        /// <summary>
        /// Gets a list of books that matches the users keyword.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>A list of books that contains
        /// the users keyword.</returns>
        public List<Book> GetBooks(string keyword)
        {
            var books = (from b 
                         in db.Books
                         where b.Title.Contains(keyword) 
                         select b).ToList();
            return books;
        }

        /// <summary>
        /// GetCategories gets all the categories in the database.
        /// </summary>
        /// <returns>A list of the categories in
        /// the database.</returns>
        public List<BookCategory> GetCategories()
        {
            var categories = (from c 
                              in db.BookCategories 
                              orderby c.Name 
                              descending select c).ToList();

            return categories;
        }

        /// <summary>
        /// This Overloaded method GetCategories gets all the categories 
        /// in the database that matches the users keyword..</summary>
        /// <param name="keyword"></param>
        /// <returns>A list of categories that contains
        /// the users keyword.</returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            var categories = (from c 
                              in db.BookCategories 
                              where c.Name.Contains(keyword) 
                              orderby c.Name 
                              select c).ToList();

            return categories;
        }

        /// <summary>
        /// Lists all the books that matches the users
        /// chosen categoryId.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>A list of books that matches
        /// the users chosen categoryId.</returns>
        public List<Book> GetCategory(int categoryId)
        {
            var book = (from b 
                        in db.Books 
                        where b.Category.Id == categoryId
                        select b).ToList();

            return book;
        }

        /// <summary>
        /// Puts every user in the database in the user list.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>All the users if the 
        /// user doing the search is admin,
        /// false if the user is not admin.</returns>
        public List<User> ListUsers(int adminId)
        {
            var users = new List<User>();
            if (UserIsAdminAndLoggedIn(adminId))
            {
                users = (from u in db.Users select u).ToList();
                return users;
            }

            return users;
        }

        /// <summary>
        /// If username and password matches the user is logged in.
        /// That sets the sessiontimer do DateTime.now.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>user id if success, 0 if fail.</returns>
        public User Login(string userName, string password)
        {
            var user = (from u 
                        in db.Users 
                        where u.Name == userName && u.Password == password 
                        select u).FirstOrDefault();
            if (user != null)
            {
                user.SessionTimer = DateTime.Now;
                user.LastLogin = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return user;
            }

            return new User { };
        }

        /// <summary>
        /// Logs out the user with the matching userId.
        /// </summary>
        /// <param name="userId"></param>
        public void Logout(int userId)
        {
            var user = (from u in db.Users 
                        where u.Id == userId 
                        select u).FirstOrDefault();

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.Users.Update(user);
                db.SaveChanges();  
            }
        }

        /// <summary>
        /// Tar in ett user id och kollar om userns sessiontimer
        /// har passerat 15 minuter eller ej. 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Pong om det inte gått 15 minuter. 
        /// Annars returneras String.Empty </returns>
        public string Ping(int userId)
        {
            if (UserExists(userId, out User user) 
                && user.IsLoggedIn() 
                && user.IsActive)
            {
                user.SessionTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return "Pong";
            }

            return string.Empty;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns>true if the user is registered,
        /// false if the user allready exists.</returns>
        public bool Register(
            string name, 
            string password, 
            string passwordVerify)
        {
            var user = (from u 
                        in db.Users 
                        where u.Name == name && u.Password == password 
                        select u).FirstOrDefault();

            if (user == null && password == passwordVerify)
            {
                db.Add(new User
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
        /// Sets the amount of the book with a certain book in stock.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        public void SetAmount(int adminId, int bookId, int amount)
        {
            if (UserIsAdminAndLoggedIn(adminId) 
                && BookExists(bookId, out Book book))
            {
                book.Amount = amount;
                db.Books.Update(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a book based on its id.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="Id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns>true if success, false if the update fails.</returns>
        public bool UpdateBook(
            int adminId, 
            int Id, 
            string title, 
            string author, 
            int price)
        {
            if (UserIsAdminAndLoggedIn(adminId))
            {
                var book = (from b 
                            in db.Books 
                            where b.Id == Id 
                            select b).FirstOrDefault();

                if (book != null)
                {
                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Updates a category with a new name.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns>true if success, false if the update fails.</returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            if (UserIsAdminAndLoggedIn(adminId))
            {
                var category = (from c 
                                in db.BookCategories 
                                where c.Id == categoryId 
                                select c).FirstOrDefault();

                if (category != null)
                {
                    category.Name = name;
                    db.BookCategories.Update(category);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Lists all books in stock and returns them descending.
        /// </summary>
        /// <returns>List of books.</returns>
        public List<Book> GetAllBooks()
        {
            return (from q in db.Books where q.Amount > 0 orderby q.Id select q).ToList();
        }
    }
}
