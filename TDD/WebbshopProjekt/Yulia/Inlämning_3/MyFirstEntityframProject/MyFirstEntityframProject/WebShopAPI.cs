using Microsoft.EntityFrameworkCore;
using MyFirstEntityframProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstEntityframProject
{
    public class WebShopAPI
    {
        public WebShopYulia db = new WebShopYulia();

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == username.Trim() && u.Password == password && u.IsActive);
            if (user != null)
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
        /// Logs out a user.
        /// </summary>
        /// <param name="id"></param>
        public void Logout(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.Users.Update(user);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Returns a list of book categories available in the webshop database.
        /// </summary>
        public List<Category> GetCategories()
        {
            Console.WriteLine("Book categories:");
            var category = db.Categories.ToList();
            return category;
        }
        /// <summary>
        /// Returns a list of book categories available in the webshop database that match keyword search.
        /// </summary>
        /// <param name="keyword"></param>
        public List<Category> GetCategories(string keyword)
        {
            var category = db.Categories.Where(k => k.Name.Contains(keyword)).ToList();
            if (category != null)
            {
                return category;
            }
            return new List<Category>();
        }
        /// <summary>
        /// Returns book category that match id number search.
        /// </summary>
        /// <param name="Id"></param>
        public List<Category> GetCategory(int Id)
        {
            Console.WriteLine($"Book category with Id [{Id}]");
            var category = db.Categories.Where(k => k.Id == Id).ToList();
            if (category != null)
            {
                return category;
            }
            return new List<Category>();
        }
        /// <summary>
        /// Returns a list of books available in stock on the webshop.
        /// </summary>
        public List<Book> GetAvailableBooks()
        {
            Console.WriteLine($"Books available in webshop");
            var books = db.Books.Where(k => k.Amount > 0).ToList();
            if (books != null)
            {
                return books;
            }
            return new List<Book>();
        }
        /// <summary>
        /// Returns a books available in the webshop database that match Id number search.
        /// </summary>
        /// <param name="Id"></param>

        public List<Book> GetBook(int Id)
        {
            Console.WriteLine($"Book details for book with Id [{Id}]");
            var book = db.Books.Where(k => k.Id == Id).ToList();
            if (book != null)
            {
                return book;
            }
            return new List<Book>();
        }
        // <summary>
        // Returns a list of books available in the webshop database that match keyword search.
        // </summary>
        // <param name="keyword"></param>
        public List<Book> GetBooks(string keyword)
        {
            Console.WriteLine($"All books that contain \"{keyword}\"");
            var book = db.Books.Where(k => k.Title.Contains(keyword) && k.Amount > 0).ToList();
            if (book != null)
            {
                return book;
            }
            return new List<Book>();
        }
        /// <summary>
        /// Returns a list of authors for books available in the webshop database 
        /// </summary>
        /// <param name="keyword"></param>
        public List<Book> GetAuthors(string keyword)
        {
            var book = db.Books.Where(k => k.Author.Contains(keyword) && k.Amount > 0).ToList();
            if (book != null)
            {
                return book;
            }
            return new List<Book>();
        }
        /// <summary>
        /// Registers a book purchase.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool BuyBook(int userId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            var book = db.Books.Include(c => c.Categories).FirstOrDefault(b => b.Id == bookId);

            if (user != null && user.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                user.SessionTimer = DateTime.Now;

                if (book.Amount > 0)
                {
                    book.Amount -= 1;

                    if (book.Amount == 1)
                    {
                        book.Amount = 0;
                    }
                    var soldBook = new SoldBook() { Title = book.Title, Author = book.Author, Price = book.Price, PurchasedDate = DateTime.Now, Categories = new List<Category>(), Users = new List<User>() };
                    soldBook.Users.Add(user);

                    foreach (var cat in book.Categories)
                    {
                        soldBook.Categories.Add(cat);
                    }
                    db.SoldBooks.Add(soldBook);
                    db.Update(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///  Checks if user is logged in and active in the webshop catalogue/database.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string Ping(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null && user.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                return "Pong";
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Registers a new user in the webshop catalogue/database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            var user = db.Users.FirstOrDefault(i => i.Name == name);
            if (user == null)
            {
                if (password == passwordVerify)
                {
                    db.Users.Add(new User { Name = name, Password = password });
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        //============ functions available to admin ============
        /// <summary>
        /// Updates existing book details in the webshop catalogue/database with given number of items. If book does not exist, creates a new book with provided details.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddBook(int adminId, int bookId, string title, string author, int price, int amount)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == adminId);
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            if (user.IsAdmin == true)
            {
                if (book == null)
                {
                    db.Books.Add(new Book { Title = title, Author = author, Price = price, Amount = amount });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    book.Amount += amount;
                    db.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Updates existing book details in the webshop catalogue/database with new item amount.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SetAmount(int adminId, int id)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == adminId);
            var book = db.Books.FirstOrDefault(c => c.Id == id);
            if (book != null)
            {
                if (user.IsAdmin == true)
                {
                    var running = true;
                    while (running)
                    {
                        Console.WriteLine("Change the stock to [enter new number]:");
                        string value = Console.ReadLine();
                        if (int.TryParse(value, out int num))
                        {
                            book.Amount = num;
                            db.Update(book);
                            db.SaveChanges();
                            running = false;
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Not a number");
                            running = true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Returns a list of users/customers registered in the webshop database 
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public List<User> ListUsers(int adminId)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == adminId);
            if (user.IsAdmin == true)
            {
                var customer = db.Users.OrderBy(u => u.Name).ToList();
                if (customer != null)
                {
                    return customer;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Returns a list of users/customers registered in the webshop database that match given search keyword
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        public List<User> FindUser(int adminId, string keyword)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == adminId);
            if (user.IsAdmin == true)
            {
                var customer = db.Users.Where(k => k.Name.Contains(keyword)).ToList();
                if (customer != null)
                {
                    return customer;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Updates existing book details in the webshop catalogue/database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UpdateBook(int adminId, int id, string title, string author, int price, int amount)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == adminId);
            var book = db.Books.FirstOrDefault(c => c.Id == id);
            if (book != null)
            {
                if (user.IsAdmin == true)
                {
                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    book.Amount = amount;
                    db.Update(book);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("You need to be logged in as administrator to use this function.");
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Deletes book from the webshop catalogue/database
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == adminId);
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {                
                if (user.IsAdmin == true)
                {
                    while (book.Amount > 0)
                    {
                        book.Amount -= 1;
                    }
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }          
            return false;
        }
        /// <summary>
        /// Adds a new book category to the webshop catalogue/database
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddCategory(int adminId, string name)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == adminId);
            var category = db.Categories.FirstOrDefault(b => b.Name == name);
            if (user.IsAdmin == true)
            {
                if (category == null)
                {
                    db.Categories.Add(new Category { Name = name });
                    db.SaveChanges();                  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("You need to be logged in as administrator to user this function");
                return false;
            }
        }
        /// <summary>
        /// Adds existing book to an existing category in the catalogue/database. If book/category does not exist, suggest to create book/category first.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            var book = db.Books.Include("Categories").FirstOrDefault(b => b.Id == bookId);
            var category = db.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (user.IsAdmin == true)
            {
                if (book == null)
                {
                    Console.WriteLine("Book does not exist. You need to create the book in the catalogue first.");

                    if (category == null)
                    {
                        Console.WriteLine("Category does not exist. You need to create it in the catalogue first.");
                        return false;
                    }
                    return false;
                }
                book.Categories.Add(category);
                db.Update(category);
                db.Update(book);
                db.SaveChanges();
                return true;
            }
            Console.WriteLine("You need to be logged in as administrator to user this function");
            return false;
        }
        /// <summary>
        /// Updates book category in the webshop catalogue/database
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == adminId);
            var category = db.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                if (user.IsAdmin == true)
                {
                    category.Name = name;
                    db.Update(category);
                    db.SaveChanges();           
                    return true;
                }
                else
                {
                    Console.WriteLine("You need to be logged in as administrator to use this function.");
                    return false;
                }
            }         
            return false;
        }
        /// <summary>
        /// Deletes book category from the webshop catalogue/database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == adminId);
            var category = db.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {              
                if (user.IsAdmin == true)
                {            
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("You need to be logged in as administrator to user this function");
                    return false;
                }
            }          
            return false;
        }
        /// <summary>
        /// Creates a new user in the webshop database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AddUser(int id, string name, string password)
        {
            var user = db.Users.FirstOrDefault(i => i.Id == id);
            var newUser = db.Users.FirstOrDefault(n => n.Name == name);
            if (user.IsAdmin == true && password.Trim() != "")
            {
                if (newUser == null)
                {
                    db.Users.Add(new User { Name = name, Password = password, IsAdmin = false });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            Console.WriteLine("You need to be logged in as administrator to user this function");
            return false;
        }
    }
}