using AssignmentTwo.Database;
using AssignmentTwo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AssignmentTwo
{
    /// <summary>
    /// The class where all the methods regarding the database are located.
    /// </summary>
    public class WebbShopAPI
    {
        private MyContext context = new MyContext();

        /// <summary>
        /// Increases the amount of the specified book if it already exists, otherwise sets the amount to the value of the parameter.
        /// </summary>

        public bool AddBook(int adminId, int bookId, string title, string author, int price, int amount)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var book = context.Books.FirstOrDefault(b => b.Id == bookId && b.Title == title && b.Author == author && b.Price == price);

            try
            {
                if (user.IsAdmin)
                {
                    if (book.Amount <= 0)
                    {
                        book.Amount = amount;
                        context.Books.Update(book);
                        context.SaveChanges();
                    }
                    else
                    {
                        book.Amount += amount;
                        context.Books.Update(book);
                        context.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Adds the specified book to the specified category.
        /// </summary>

        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);

            try
            {
                if (user.IsAdmin)
                {
                    book.CategoryId = categoryId;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>

        public bool AddCategory(int adminId, string name)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);

            try
            {
                if (user.IsAdmin && string.IsNullOrEmpty(name) == false)
                {
                    context.BookCategories.Add(new Models.BookCategory { Name = name });
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Creates a new user, fails if the user already exists or if the password is empty.
        /// </summary>

        public bool AddUser(int adminId, string name, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var newUser = context.Users.FirstOrDefault(u => u.Name == name && u.Password == password);

            try
            {
                if (user.IsAdmin && newUser == null && string.IsNullOrEmpty(password) == false)
                {
                    context.Users.Add(new Models.User { Name = name, Password = password, IsActive = true, IsAdmin = false });
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Checks if the user exists and is active. Copies the data of the book being bought,
        /// and adds the data to SoldBooks along with the date and the userId of the buyer.
        /// </summary>

        public bool BuyBook(int userId, int bookId)
        {
            Ping(userId);
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);

            try
            {
                if (user != null & user.IsActive)
                {
                    user.SessionTimer = DateTime.Now;

                    if (book.Amount > 0)
                    {
                        context.SoldBooks.Add(new SoldBook
                        {
                            Title = book.Title,
                            Author = book.Author,
                            Price = book.Price,
                            CategoryId = book.CategoryId,
                            PurchasedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                            UserId = userId
                        });
                        book.Amount--;
                        context.Books.Update(book);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Deletes one copy of the specified book, if the amount gets to 0 it will get removed from the database.
        /// </summary>

        public bool DeleteBook(int adminId, int bookId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);

            try
            {
                if (user.IsAdmin)
                {
                    if (book.Amount > 0)
                    {
                        book.Amount--;
                    }
                    if (book.Amount == 0)
                    {
                        context.Books.Remove(book);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Deletes the specified category if there are no books attached to it.
        /// </summary>

        public bool DeleteCategory(int adminId, int categoryId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var category = context.BookCategories.FirstOrDefault(c => c.Id == categoryId);
            var book = context.Books.FirstOrDefault(b => b.CategoryId == categoryId);

            try
            {
                if (user.IsAdmin && book == null)
                {
                    context.BookCategories.Remove(category);

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// List of all users matching the keyword.
        /// </summary>

        public List<User> FindUser(int adminId, string keyword)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);

            try
            {
                if (user.IsAdmin)
                {
                    return context.Users.Where(u => u.Name.Contains(keyword)).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// List of books by authors who matches the keyword.
        /// </summary>

        public List<Book> GetAuthors(string keyword)
        {
            return context.Books.Where(b => b.Author.Contains(keyword)).ToList();
        }

        /// <summary>
        /// List of all the books in the specified category, which have atleast one copy available in the database.
        /// </summary>

        public List<Book> GetAvailableBooks(int categoryId)
        {
            return context.Books.Where(b => b.CategoryId == categoryId && context.Books.Count() > 0).ToList();
        }

        /// <summary>
        /// List of information about the specified book. For example title, author and price.
        /// </summary>

        public List<Book> GetBook(int bookId)
        {
            return context.Books.Where(b => b.Id == bookId).ToList();
        }

        /// <summary>
        /// List of books that matches the keyword.
        /// </summary>

        public List<Book> GetBooks(string keyword)
        {
            return context.Books.Where(b => b.Title.Contains(keyword)).ToList();
        }

        /// <summary>
        /// List of all the categories.
        /// </summary>

        public List<BookCategory> GetCategories()
        {
            return context.BookCategories.OrderBy(c => c.Name).ToList();
        }

        /// <summary>
        /// List of categories that matches the keyword.
        /// </summary>

        public List<BookCategory> GetCategories(string keyword)
        {
            return context.BookCategories.Where(c => c.Name.Contains(keyword)).ToList();
        }

        /// <summary>
        /// List of books in the specified category.
        /// </summary>

        public List<Book> GetCategory(int categoryId)
        {
            return context.Books.Where(b => b.CategoryId == categoryId).ToList();
        }

        /// <summary>
        /// List of all the users.
        /// </summary>

        public List<User> ListUsers(int adminId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            try
            {
                if (user.IsAdmin)
                {
                    return context.Users.Where(u => u.Name != null).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Let's the user login, sets LastLogin and SessionTimer to DateTime.Now and IsActive to true.
        /// </summary>

        public int Login(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                user.IsActive = true;
                context.Users.Update(user);
                context.SaveChanges();
                return user.Id;
            }

            return 0;
        }

        /// <summary>
        /// Let's the user logout, sets SessionTimer to DateTime.MinValue and sets IsActive to false.
        /// </summary>

        public void Logout(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                user.IsActive = false;
                context.Users.Update(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if the user is active and if so returns "Pong" and sets the SessionTimer to DateTime.Now.
        /// If the user isn't active, it returns empty.string.
        /// </summary>

        public string Ping(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null && DateTime.Now <= user.SessionTimer.AddMinutes(15))
            {
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
                return "Pong";
            }
            else if (user != null && DateTime.Now >= user.SessionTimer.AddMinutes(15))
            {
                user.IsActive = false;
                return string.Empty;
            }

            return string.Empty;
        }

        /// <summary>
        /// Let's the user register if the user doesn't exist already, and if password and passwordVerify are equal.
        /// </summary>

        public bool Register(string name, string password, string passwordVerify)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == name && u.Password == password);

            if (user == null)
            {
                if (password == passwordVerify && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(name))
                {
                    context.Users.Add(new Models.User { Name = name, Password = password, IsActive = true, IsAdmin = false });

                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sets the amount of available books, specified by the parameters.
        /// </summary>

        public void SetAmount(int adminId, int bookId, int amount)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);

            try
            {
                if (user.IsAdmin)
                {
                    book.Amount = amount;
                    context.Books.Update(book);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Updates the information about the book, according to the parameters.
        /// </summary>

        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);

            try
            {
                if (user.IsAdmin)
                {
                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Updates the name of the specified category according to the name parameter.
        /// </summary>

        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var category = context.BookCategories.FirstOrDefault(c => c.Id == categoryId);

            try
            {
                if (user.IsAdmin && string.IsNullOrEmpty(name) == false)
                {
                    category.Name = name;
                    context.BookCategories.Update(category);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }
    }
}