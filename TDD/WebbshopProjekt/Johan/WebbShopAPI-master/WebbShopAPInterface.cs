using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI
{
    public class WebbShopAPInterface
    {
        EFContext db = new EFContext();


        /// <summary>
        /// Method for logging in.
        /// </summary>
        /// <param name="username">Username of the specific user</param>
        /// <param name="password">Password of the user</param>
        /// <returns></returns>
        public int Login(string username, string password)
        {
            using (var db = new EFContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive);
                if (user != null)
                {
                    user.LastLogin = DateTime.Now;
                    user.SessionTimer = DateTime.Now;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return user.Id;
                }
            }

            return 0; // 0 = user doesn't exist.
        }


        /// <summary>
        /// Method for logging out.
        /// </summary>
        /// <param name="id">Id of the user</param>
        public void LogOut(int id)
        {
            using (var db = new EFContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    user.SessionTimer = DateTime.MinValue;
                    db.Users.Update(user);
                    db.SaveChanges();
                }

            }

        }


        /// <summary>
        /// Method that will check if the user is online and not afk/logged out.
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns></returns>
        public string Ping(int id)
        {
            using (var db = new EFContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {

                    if (user.SessionTimer > DateTime.Now.AddMinutes(-15))
                    {
                        user.SessionTimer = DateTime.Now;
                        db.Update(user);
                        db.SaveChanges();
                        Console.WriteLine("Pong");
                    }
                }

                return string.Empty;
            }
            
        }

        /// <summary>
        /// Method that will return the names of all the categories in the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookCategory> GetCategories()
        {
            return db.Categories.OrderBy(c => c.Id);
        }

        /// <summary>
        /// Method that returns a list of categories where the name contains the keyword.
        /// </summary>
        /// <param name="keyword">Chosen word/letter that the user wants to search for</param>
        /// <returns></returns>
        public IEnumerable<BookCategory> GetCategories(string keyword)
        {
            return db.Categories.Where(c => c.Name.Contains(keyword)).OrderBy(c => c.Name);

        }

        /// <summary>
        /// Method that will return a specific category.
        /// </summary>
        /// <param name="categoryId">Id of the specific category</param>
        /// <returns></returns>
        public IEnumerable<Book> GetCategory(int categoryId)
        {
            return db.Books.Where(b => b.CategoryId == categoryId);
        }

        /// <summary>
        /// Method that will return books in the specific category.
        /// </summary>
        /// <param name="categoryId">Id of the specific category</param>
        /// <returns></returns>
        public IEnumerable<Book> GetAvailableBooks(int categoryId)
        {
            return db.Books.Where(b => b.Amount > 0 && b.CategoryId == categoryId);
        }

        /// <summary>
        /// Method that returns a specific book.
        /// </summary>
        /// <param name="bookId">Id of the specific book searched for</param>
        /// <returns></returns>
        public IEnumerable<Book> GetBook(int bookId)
        {
            return db.Books.Where(b => b.Id == bookId);

        }

        /// <summary>
        /// Method that returns a list of books where the names of the books contains the keyword.
        /// </summary>
        /// <param name="keyword">Chosen word/letter that the user wants to search for</param>
        /// <returns></returns>
        public IEnumerable<Book> GetBooks(string keyword)
        {
            return db.Books.Where(b => b.Title.Contains(keyword)).OrderBy(b => b.Title);

        }

        /// <summary>
        /// Method that returns authors that have the keyword in their name.
        /// </summary>
        /// <param name="keyword">Chosen word/letter that the user wants to search for</param>
        /// <returns></returns>
        public IEnumerable<Book> GetAuthors(string keyword)
        {
            return db.Books.Where(b => b.Author.Contains(keyword)).OrderBy(b => b.Title);

        }


        /// <summary>
        /// Method for buying a book.
        /// </summary>
        /// <param name="userId">Id of the user that is buying the book</param>
        /// <param name="bookId">Id of the chosen book</param>
        /// <returns></returns>
        public bool BuyBook(int userId, int bookId)
        {
            using (var db = new EFContext())
            { 
                var online = Ping(userId);
                if (online != null)
                {
                    var book = GetBook(bookId);
                    foreach(var b in book)
                    {
                        if(b.Amount != 0)
                        {

                            db.SoldBooks.Add(new SoldBook { Author = b.Author, PurchasedDate = DateTime.Now, Price = b.Price, Title = b.Title, CategoryId = b.CategoryId, UserId = userId });
                            b.Amount--;
                            db.Update(b);
                            db.SaveChanges();

                        }
                        if(b.Amount < 1)
                        {
                            db.Books.Remove(b);
                            db.SaveChanges();
                        }
                    }
                    return true;
                }
                return false;
            }
            
        }


        /// <summary>
        /// Method that registers a new user.
        /// </summary>
        /// <param name="name">Name for the new user</param>
        /// <param name="password">Password for the new user</param>
        /// <param name="passwordVerify">Verify the chosen password</param>
        /// <returns></returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
            if(user == null && password == passwordVerify)
            {
                var newUser = db.Users.Add(new User { Name = name, Password = password, IsActive = true, IsAdmin = false});
                db.SaveChanges();
                return true;
            }
            if(user != null || password != passwordVerify)
            {
                return false;
            }
            return false;
        }

        // ADMIN METHODS ------------------------


        /// <summary>
        /// Method that handles the addition of a book into the database.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="bookId">Id to check if the book exists already</param>
        /// <param name="title">Title of the new book</param>
        /// <param name="author">Author of the new book</param>
        /// <param name="price">Price of the new book</param>
        /// <param name="amount">Amount of books of the new book</param>
        /// <returns></returns>
        public bool AddBook(int adminId, int bookId, string title, string author, int price, int amount)
        {
            using(var db = new EFContext())
            {
                var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
                if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
                {
                    var verifyBook = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (verifyBook != null)
                    {
                        verifyBook.Amount++;
                        db.Update(verifyBook);
                        db.SaveChanges();
                        
                        
                    }
                    if (verifyBook == null)
                    {
                        db.Books.Add(new Book { Title = title, Author = author, Price = price, Amount = amount, CategoryId = null });
                        db.SaveChanges();
                    }
                    
                    return true;
                }


            }
            
            return false;
        }

        /// <summary>
        /// Method that makes it possible for admins to set the inventory of the books.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="bookId">Id to check if the book exists already</param>
        /// <param name="amount">Amount to be updated with</param>
        /// <returns></returns>
        public string SetAmount(int adminId, int bookId, int amount)
        {
            using (var db = new EFContext())
            {
                var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
                if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
                {
                    var verifyBook = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (verifyBook != null)
                    {
                        verifyBook.Amount = amount;
                        db.Update(verifyBook);
                        db.SaveChanges();
                        return $"New amount has been set to {amount}!";

                    }
                    if (verifyBook == null)
                    {
                        return "No such book was found!";
                    }
                }
                return "No such book was found!";
            }

        }

        /// <summary>
        /// Method to get a list of the systems users.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <returns></returns>
        public IEnumerable<User> ListUsers(int adminId)
        {
            var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
            if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
            {
                return db.Users.OrderBy(u => u.Name);
            }
            return null;
        }

        /// <summary>
        /// Method that search for users that have a name like the keyword.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="keyword">Keyword that the users name should contain</param>
        /// <returns></returns>
        public IEnumerable<User> FindUser(int adminId, string keyword)
        {
            var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
            if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
            {
                return db.Users.Where(u => u.Name.Contains(keyword)).OrderBy(u => u.Name);
            }
            return null;
            
        }

        /// <summary>
        /// Method that updates an existing book with new information.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="bookId">Id of the book that will be updated</param>
        /// <param name="title">Updated title</param>
        /// <param name="author">Updated author</param>
        /// <param name="price">Updated price</param>
        /// <returns></returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            using (var db = new EFContext())
            {
                var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
                if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
                {
                    var verifyBook = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (verifyBook != null)
                    {
                        verifyBook.Title = title;
                        verifyBook.Author = author;
                        verifyBook.Price = price;
                        db.Update(verifyBook);
                        db.SaveChanges();
                        return true;

                    }
                    if (verifyBook == null)
                    {
                        return false;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Method that deletes one unit of a book amount until it is out, at which point it will remove the book from the database.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="bookId">Id of the book that will be updated</param>
        /// <returns></returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            using (var db = new EFContext())
            {
                var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
                if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
                {
                    var verifyBook = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (verifyBook != null && verifyBook.Amount != 0)
                    {
                        verifyBook.Amount--;
                        db.Update(verifyBook);
                        db.SaveChanges();
                        return true;

                    }
                    if (verifyBook != null && verifyBook.Amount == 0)
                    {
                        db.Remove(verifyBook);
                        db.SaveChanges();
                        return true;
                    }

                }
                return false;
            }

        }

        /// <summary>
        /// Method to add a new category to the database.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="name">Name of the new category</param>
        /// <returns></returns>
        public bool AddCategory(int adminId, string name)
        {
            using (var db = new EFContext())
            {
                var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
                if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
                {
                    var verifyCategory = db.Categories.FirstOrDefault(c => c.Name == name);
                    if (verifyCategory != null)
                    {
                        return false;
                    }
                    if (verifyCategory == null)
                    {
                        db.Categories.Add(new BookCategory { Name = name });
                        db.SaveChanges();
                        return true;
                    }

                }
                return false;
            }

        }

        /// <summary>
        /// Method to change the category of an existing book.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="bookId">Id of the book that will be updated</param>
        /// <param name="categoryId">Id of the new category</param>
        /// <returns></returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            using (var db = new EFContext())
            {
                var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
                if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
                {
                    var verifyBook = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (verifyBook != null && verifyBook.CategoryId != categoryId)
                    {
                        verifyBook.CategoryId = categoryId;
                        db.Update(verifyBook);
                        db.SaveChanges();
                        return true;

                    }
                    if(verifyBook == null)
                    {
                        return false;
                    }

                }
                return false;
            }

        }

        /// <summary>
        /// Method to update an existing category in the database.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="categoryId">Id of the category that is going to be updated</param>
        /// <param name="name">New name for the category</param>
        /// <returns></returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            using (var db = new EFContext())
            {
                var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
                if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
                {
                    var verifyCategory = db.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (verifyCategory != null && verifyCategory.Name != name)
                    {
                        verifyCategory.Name = name;
                        db.Update(verifyCategory);
                        db.SaveChanges();
                        return true;

                    }

                }
                return false;
            }
        }


        /// <summary>
        /// Method that enables the deletion of a category.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="categoryId">Id of the category that is going to be checked and/or deleted</param>
        /// <returns></returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            using (var db = new EFContext())
            {
                var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
                if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
                {
                    var verifyCategory = db.Categories.FirstOrDefault(c => c.Id == categoryId);
                    var verifyBookCateId = db.Books.FirstOrDefault(b => b.CategoryId == categoryId);

                    if(verifyCategory != null && verifyBookCateId == null)
                    {
                        db.Categories.Remove(verifyCategory);
                        db.SaveChanges();
                        return true;
                    }

                }
            }
            return false;
        }

        /// <summary>
        /// Method that enables the admin to add a user to the database.
        /// </summary>
        /// <param name="adminId">Parameter to check if the user is in fact an admin</param>
        /// <param name="name">Name of the user to be added</param>
        /// <param name="password">Password of the user to be added</param>
        /// <returns></returns>
        public bool AddUser(int adminId, string name, string password)
        {
            using (var db = new EFContext())
            {
                var isUserAdmin = db.Users.FirstOrDefault(u => u.Id == adminId);
                if (isUserAdmin != null && isUserAdmin.IsAdmin == true)
                {
                    var verifyUser = db.Users.FirstOrDefault(u => u.Name == name);
                    if(verifyUser == null && password != string.Empty)
                    {
                        db.Users.Add(new User { Name = name, Password = password, IsActive = true, IsAdmin = false });
                        db.SaveChanges();
                        return true;

                    }
                    if(verifyUser == null && password == string.Empty)
                    {
                        db.Users.Add(new User { Name = name, Password = "Codic2021" , IsActive = true, IsAdmin = false });
                        db.SaveChanges();
                        return true;

                    }
                    
                }
                return false;
            }
        }



    }
}
