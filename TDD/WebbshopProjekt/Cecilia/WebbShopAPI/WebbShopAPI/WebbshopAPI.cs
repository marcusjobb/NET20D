using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WebbShopAPI.Database;
using WebbShopAPI.Helpers;
using WebbShopAPI.Models;

namespace WebbShopAPI
{
    public class WebbshopAPI
    {
        /// <summary>
        /// Method to login user.
        /// </summary>
        /// <returns>
        /// User int.
        /// </returns>
        public int Login(string userName, string password)
        {
            using (var db = new WScontext())
            {
                var user = db.Users.
                    FirstOrDefault(
                    c => c.Name == userName
                    );

                if (user != null && user.Password == password)
                {
                    
                        user.SessionTimer = DateTime.Now;
                        user.IsActive = true;
                        db.Users.Update(user);
                        db.SaveChanges();
                        return user.Id;
                }

                return 0;
            }
        }

        /// <summary>
        /// Method to logout user.
        /// </summary>
        public void Logout(int userID)
        {
            using (var db = new WScontext())
            {
                var user = db.Users.
                    FirstOrDefault(
                    c => c.Id == userID
                    );

                if (user != null)
                {
                        user.SessionTimer = DateTime.MinValue;
                        user.LastLogin = DateTime.Now;
                        user.IsActive = false;
                        db.Users.Update(user);
                        db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to list all categories.
        /// </summary>
        public void GetCategories()
        {
            using (var db = new WScontext())
            {
                var categories = db.BookCategories.ToArray();

                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id}. {category.Name}");
                }
            }
        }

        /// <summary>
        /// Method to list all categories where category-name match keyword.
        /// </summary>
        public void GetCategories(string keyword)
        {
            using (var db = new WScontext())
            
            {
                var categories = db.BookCategories.
                    Where(
                    c => c.Name.Contains(keyword)).ToArray(
                    );

                if (categories != null)
                {
                    foreach (var category in categories)
                    {
                        Console.WriteLine($"{category.Name}");
                    }
                }
            }
        }

        /// <summary>
        /// Method to list all books in category.
        /// </summary>
        public void GetCategory(int categoryID)
        {
            using (var db = new WScontext())
            
            {
                var category = db.Books.
                    Where(
                    c => c.Category == db.BookCategories.
                    FirstOrDefault(c=> c.Id == categoryID)).
                    ToArray();

                if (category != null)
                {
                    foreach (var book in category)
                    {
                        Console.WriteLine($"{book.Id}.{book.Title}");
                    }
                }
            }
        }

        /// <summary>
        /// Method to list all books in specific category where book-amount > 0.
        /// </summary>
        public void GetAvailableBooks(int categoryID)
        {
            using (var db = new WScontext())
            {
                var category = db.Books.
                    Where(
                    c => c.Category == db.BookCategories.
                    FirstOrDefault(
                    c => c.Id == categoryID) 
                    && c.Amount > 0).
                    ToArray();

                if (category != null)
                {
                    foreach (var book in category)
                    {
                        Console.WriteLine($"{book.Id}.{book.Title}");
                    }
                }
            }
        }

        /// <summary>
        /// Method to list all information of a book.
        /// </summary>
        public void GetBook(int bookID)
        {
            using (var db = new WScontext())
            {
                var book = db.Books.Include(
                    b => b.Category).
                    FirstOrDefault(
                    b => b.Id == bookID
                    );

                if (book != null)
                {
                    Console.WriteLine($"Title: {book.Title}" +
                        $"\nAuthor: {book.Author}" +
                        $"\nCategory: {book.Category.Name}" +
                        $"\nPrice: { book.Price}" +
                        $"\nAmount: { book.Amount}");
                }      
            }
        }

        /// <summary>
        /// Method to list all books where booktitle contains keyword.
        /// </summary>
        public void GetBooks(string keyword)
        {
            using (var db = new WScontext())
            {
                var books = db.Books.
                    Where(
                    b => b.Title.Contains(keyword)).
                    ToArray(
                    );

                if (books != null)
                {
                    foreach (var info in books)
                    {
                        Console.WriteLine($"{info.Title}");
                    }
                }
                
            }
        }

        /// <summary>
        /// Method to return the first books ID where booktitle contains keyword.
        /// </summary>
        public int GetBookId(string keyword)
        {
            using (var db = new WScontext())
            {
                var books = db.Books.
                    Where(
                    b => b.Title.Contains(keyword)).
                    FirstOrDefault(
                    );

                if (books != null)
                {
                    return books.Id;
                }
                else
                {
                    Console.WriteLine("Tyvärr ingen träff");
                    return 0;
                }
            }
        }

        /// <summary>
        /// Method to list all books where author contains keyword.
        /// </summary>
        public void GetAuthors(string keyword)
        {
            using (var db = new WScontext())
            {
                var books = db.Books.
                    Where(
                    b => b.Author.Contains(keyword)).
                    ToArray(
                    );
                if (books != null)
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine($"{book.Title}");
                    }
                }
            }
        }

        /// <summary>
        /// Method to check if user is active and copies book-data to SoldBook.
        /// </summary>
        public bool BuyBook(int userID, int bookID)
        {
            using (var db = new WScontext())
            {
                var user = db.Users.
                    FirstOrDefault(
                    u => u.Id == userID &&
                    DateTime.Now <= u.SessionTimer.AddMinutes(15)
                    );

                var book = db.Books.Include(
                    b => b.Category).
                    FirstOrDefault(
                    b => b.Id == bookID
                    );

                var soldBook = db.SoldBooks.
                    FirstOrDefault(
                    s => s.Title == book.Title
                    );

                if (user != null && book != null && book.Amount > 0)
                {
                    soldBook = new SoldBooks { Title = book.Title, 
                        Author = book.Author, 
                        CategoryId = book.Category.Id, 
                        Price = book.Price,
                        PurchasedDate = DateTime.Now,
                        UserId = userID};

                    book.Amount--;

                    db.SoldBooks.Add(soldBook);
                    db.Users.Update(user);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

        }

        /// <summary>
        /// Method to check if user is active.
        /// </summary>
        /// <returns>
        /// String "pong" if user is active, nothing if inactive
        /// </returns>
        public string Ping(int userID)
        {
            using (var db = new WScontext())
            {
                var user = db.Users.
                    FirstOrDefault(
                    u => u.Id == userID && u.IsActive == true
                    );

                if (user != null)
                {
                        Console.WriteLine("pong");
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Method for user to register.
        /// </summary>
        /// <returns>
        /// True if user is added, else false.
        /// </returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            using (var db = new WScontext())
            {
                var user = db.Users.
                    FirstOrDefault(
                    u => u.Name == name
                    );

                if (user == null && passwordVerify == password)
                {
                    user = new Users
                    {
                        Name = name,
                        Password = password
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
            
        }

        /// <summary>
        /// Admin-Method, adds book.
        /// </summary>
        /// <returns>
        /// True if book is added, else false.
        /// </returns>
        public bool AddBook(int adminID, string title, string author, int price, int amount)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var book = db.Books.
                    FirstOrDefault(
                    b => b.Title == title
                    );

                if (book == null && hm.AdminCheck(adminID) == true)
                {
                    book = new Books
                    {
                        Title = title,
                        Author = author,
                        Amount = amount,
                        Price = price
                    };
                    db.Books.Add(book);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Admin-Method, sets bookamount.
        /// </summary>
        public bool SetAmount(int adminID, int bookID, int amount)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var book = db.Books.
                    FirstOrDefault(
                    b => b.Id == bookID
                    );

                if (book != null && hm.AdminCheck(adminID) == true)
                {
                    book.Amount = amount;
                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Admin-Method, list of users.
        /// </summary>
        public void ListUsers(int adminID)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var users = db.Users.ToArray();

                if (users != null && hm.AdminCheck(adminID))
                {
                    foreach (var user in users)
                    {
                        if (user.IsAdmin == false)
                        {
                            Console.WriteLine($"{user.Id}. {user.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"{user.Id}. {user.Name} (Admin)");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Admin-Method, list of users where users name contains keyword.
        /// </summary>
        public void FindUser(int adminID, string keyword)
        {
            var hm = new HelperMethods();

            using (var db = new WScontext())
            {
                var users = db.Users.
                    Where(
                    u => u.Name.Contains(keyword)).ToArray(
                    );

                if (users != null && hm.AdminCheck(adminID))
                {
                    foreach (var user in users)
                    {
                        if (user.IsAdmin == false)
                        {
                            Console.WriteLine($"{user.Id}. {user.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"{user.Id}. {user.Name} (Admin)");
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Admin-Method, update book information.
        /// </summary>
        /// <returns>
        /// True if book is updated, else false.
        /// </returns>
        public bool UpdateBook(int adminID, int bookID, string title, string author, int price)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var book = db.Books.
                    FirstOrDefault(
                    b => b.Id == bookID
                    );

                if (book != null && hm.AdminCheck(adminID))
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
        }

        /// <summary>
        /// Admin-Method, remove book from database.
        /// </summary>
        /// <returns>
        /// True if book is deleted, else false.
        /// </returns>
        public bool DeleteBook(int adminID, int bookID)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var book = db.Books.
                    FirstOrDefault(
                    b => b.Id == bookID
                    );

                if (book != null && hm.AdminCheck(adminID))
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Admin-Method, adds category.
        /// </summary>
        /// <returns>
        /// True if category is added, else false.
        /// </returns>
        public bool AddCategory(int adminID, string name)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var category = db.BookCategories.
                    FirstOrDefault(
                    c => c.Name == name
                    );

                if (category == null && hm.AdminCheck(adminID))
                {
                    category = new BookCategory { Name = name };
                    db.BookCategories.Add(category);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Admin-Method, adds book to category.
        /// </summary>
        /// <returns>
        /// True if book is added, else false.
        /// </returns>
        public bool AddBookToCategory(int adminID, int bookID, int categoryID)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var book = db.Books.
                    FirstOrDefault(
                    b => b.Id == bookID
                    );

                var category = db.BookCategories.
                    FirstOrDefault(
                    c => c.Id == categoryID
                    );

                if (category != null && book != null && hm.AdminCheck(adminID))
                {
                    book.Category = category;

                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Admin-Method, update category.
        /// </summary>
        /// <returns>
        /// True if category is updated, else false.
        /// </returns>
        public bool UpdateCategory(int adminID, int categoryID, string name)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var category = db.BookCategories.
                    FirstOrDefault(
                    c => c.Id == categoryID
                    );

                if (category != null && hm.AdminCheck(adminID))
                {
                    category.Name = name;

                    db.BookCategories.Update(category);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Admin-Method, removes category from database.
        /// </summary>
        /// <returns>
        /// True if category is deleted, else false.
        /// </returns>
        public bool DeleteCategory(int adminID, int categoryID)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var category = db.BookCategories.
                    FirstOrDefault(
                    c => c.Id == categoryID
                    );

                if (category != null && hm.AdminCheck(adminID))
                {
                    db.BookCategories.Remove(category);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Admin-Method, adds user.
        /// </summary>
        /// <returns>
        /// True if user is added, else false.
        /// </returns>
        public bool AddUser(int adminID, string name, string password)
        {
            var hm = new HelperMethods();

            using (var db = new WScontext())
            {
                var user = db.Users.
                    FirstOrDefault(
                    u => u.Name == name
                    );

                if (user == null && hm.AdminCheck(adminID))
                {
                    user = new Users
                    {
                        Name = name,
                        Password = password,
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public int CheckUser(int userID)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var user = db.Users.
                    FirstOrDefault(
                    u => u.Id == userID
                    );

                hm.SessionCheck(userID);

                if (user != null && user.IsActive)
                {
                    return user.Id;
                }

                else { return 0; }
            }
        }

        public int GetAdminID(int userID)
        {
            using (var db = new WScontext())
            {
                var hm = new HelperMethods();

                var user = db.Users.
                    FirstOrDefault(
                    u => u.Id == userID && u.IsAdmin == true
                    );

                if (user != null)
                {
                    return user.Id;
                }

                else { return 0; }
            }
        }
    }
}
