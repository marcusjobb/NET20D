using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopInlamningsUppgift.Database;
using WebbShopInlamningsUppgift.Models;

namespace WebbShopInlamningsUppgift
{
    public class WebbShopAPI
    {
        /// <summary>
        /// Logs in Users
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns>boolean, true if successful, false if not</returns>
        public int Login(string userName, string userPassword)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.Name == userName && u.Password == userPassword);
                    if (user != null)
                    {
                        user.IsActive = true;
                        user.SessionTimer = DateTime.Now;
                        user.LastLogin = DateTime.Now;
                        db.SaveChanges();

                        return user.ID;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return 0;
            }
        }
        /// <summary>
        /// Logs out Users. 
        /// </summary>
        /// <param name="userId"></param>
        public void Logout(int userId)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.ID == userId);
                    if (user != null)
                    {
                        user.IsActive = false;
                        user.SessionTimer = DateTime.MinValue;
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
            }
        }
        /// <summary>
        /// Allows you to get all book categories ordered by genere
        /// </summary>
        /// <returns>List of categories</returns>
        public List<BookCategory> GetCategories()
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var listOfCategories = db.BookCategories.OrderBy(c => c.Genere).ToList();
                    if (listOfCategories.Count > 0)
                    {
                        return listOfCategories;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return new List<BookCategory>();
            }

        }

        /// <summary>
        /// Allows you to get all book categories matching input of keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>list of matching categories</returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var listOfCategories = db.BookCategories.Where(b => b.Genere.Contains(keyword)).ToList();
                    if (listOfCategories.Count > 0)
                    {
                        return listOfCategories;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return new List<BookCategory>();
            }
        }

        /// <summary>
        /// Allows you to get all books with matching category based of category ID.
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns>List of matching books</returns>
        public List<Books> GetCategories(int CategoryId)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var listOfBooks = db.Books.Include(b => b.BookCategory).Where(b => b.BookCategoryId == CategoryId).ToList();
                    if (listOfBooks.Count > 0)
                    {
                        return listOfBooks;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return new List<Books>();
            }
        }

        /// <summary>
        /// Allows you to get all books with an amount lager than 0 in stock.
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns>List of books</returns>
        public List<Books> GetAvailableBooks(int CategoryId)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var listOfAvailableBooks = db.Books.Include(b => b.BookCategory)
                        .Where(b => b.BookCategoryId == CategoryId)
                        .Where(b => b.Amount > 0).ToList();

                    if (listOfAvailableBooks.Count > 0)
                    {
                        return listOfAvailableBooks;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return new List<Books>();
            }
        }

        /// <summary>
        /// Allows you to get information for a book based on the book ID.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>Returns a string of text if successful and an empty string if not</returns>
        public string GetBook(int bookId)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var book = db.Books.Include(b => b.BookCategory)
                        .FirstOrDefault(b => b.ID == bookId);
                    if (book != null)
                    {
                        return $"Title: {book.Title} - Author: {book.Author}\nGenere: {book.BookCategory.Genere}, Price: {book.Price}";
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Allows you to get matching books based on input keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List of books</returns>
        public List<Books> GetBooks(string keyword)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var listOfBooks = db.Books.Where(b => b.Title.Contains(keyword)).ToList();
                    if (listOfBooks.Count > 0)
                    {
                        return listOfBooks;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return new List<Books>();
            }
        }

        /// <summary>
        /// Gets the books where Author matches the input keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List of books if successful, empty list if not</returns>
        public List<Books> GetAuthor(string keyword)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var listOfBooks = db.Books.Where(b => b.Author.Contains(keyword)).ToList();
                    if (listOfBooks.Count > 0)
                    {
                        return listOfBooks;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return new List<Books>();
            }
        }

        /// <summary>
        /// Allows you to buy a book if the user exists, is active and if the book is available in stock
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="bookID"></param>
        /// <returns>boolean true if successful, false if not</returns>
        public bool BuyBook(int userID, int bookID)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.ID == userID);
                    if (user == null)
                    {
                        Console.WriteLine("User does not exist");
                        return false;
                    }

                    bool isActive = CheckSessionTimer(user);
                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }

                    var book = db.Books.Include(b => b.BookCategory).FirstOrDefault(b => b.ID == bookID);
                    if (book != null)
                    {
                        if (book.Amount == 0)
                        {
                            Console.WriteLine("Book not available in stock.");
                            return false;
                        }
                        var soldBook = new SoldBooks
                        {
                            Title = book.Title,
                            Author = book.Author,
                            Price = book.Price,
                            Amount = book.Amount,
                            BookCategory = book.BookCategory,
                            UsersId = userID,
                            PurchaseDate = DateTime.Now
                        };
                        db.SoldBooks.Add(soldBook);
                        book.Amount -= 1;
                        db.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Checks to see if user is still active
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>string if success, empty string if not</returns>
        public string Ping(int userId)
        {
            using (var db = new WebbshopContext())
            {
                try 
                {
                    var user = db.Users.FirstOrDefault(u => u.ID == userId);
                    bool isActive = CheckSessionTimer(user);
                    if (isActive)
                    {
                        return "Pong";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Allows you to register a new user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns>boolean true if successful, false if not</returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            using (var db = new WebbshopContext())
            {
                try 
                {
                    var user = db.Users.FirstOrDefault(u => u.Name == name);
                    if (user == null && password == passwordVerify)
                    {
                        var newlyCreatedUser = new Users
                        {
                            Name = name,
                            Password = password,
                            IsActive = true,
                            IsAdmin = false
                        };
                        db.Users.Add(newlyCreatedUser);
                        db.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        //--------------------------------------------------------------------------------------
        //ADMIN-functionality

        /// <summary>
        /// Allows you to add a new book if book does not exist. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <param name="bookID"></param>
        /// <returns>boolean true if successful, false if not</returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount, int bookID = default)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var book = db.Books.FirstOrDefault(b => b.Title == title);
                        if (book != null)
                        {
                            book.Amount += 1;
                            db.SaveChanges();
                            return true;
                        }

                        var newBook = new Books
                        {
                            Title = title,
                            Author = author,
                            Price = price,
                            Amount = amount
                        };
                        db.Books.Add(newBook);
                        db.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows you to set a new amount to existing book
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="newAmount"></param>
        /// <returns>boolean true if success, false if not</returns>
        //Assumption that this method should return true or false
        public bool SetAmount(int adminId, int bookId, int newAmount)
        {

            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var book = db.Books.FirstOrDefault(b => b.ID == bookId);
                        if (book != null)
                        {
                            book.Amount = newAmount;
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Lists all users
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>list of users if successful, empty list if not</returns>
        public List<Users> ListUsers(int adminId)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return new List<Users>();
                    }
                    if (adminUser.IsAdmin)
                    {
                        var listOfUsers = db.Users.OrderBy(c => c.Name).ToList();
                        if (listOfUsers.Count > 0)
                        {
                            return listOfUsers;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return new List<Users>();
            }
        }

        /// <summary>
        /// Searches for user based on input keyword
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>list of users matching input</returns>
        public List<Users> FindUser(int adminId, string keyword)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return new List<Users>();
                    }
                    if (adminUser.IsAdmin)
                    {
                        var listOfUsers = db.Users.Where(u => u.Name.Contains(keyword)).ToList();
                        if (listOfUsers.Count > 0)
                        {
                            return listOfUsers;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return new List<Users>();
            }
        }

        /// <summary>
        /// Allows you to update an existing book
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns>boolean true if successful, false if not</returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var book = db.Books.FirstOrDefault(b => b.ID == bookId);
                        if (book != null)
                        {
                            book.Title = title;
                            book.Author = author;
                            book.Price = price;
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Removes book, completely if the book amount is 0 or just the amount by 1 if higher
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns>boolean true if successful, false if not.</returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            // would like to add ON DELETE SET NULL (Unsure of correct set up for this one, possibly modelbuilder in context(?))
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var book = db.Books.FirstOrDefault(b => b.ID == bookId);
                        if (book != null)
                        {
                            if (book.Amount > 0)
                            {
                                book.Amount -= 1;
                                db.SaveChanges();
                                return true;
                            }
                            if (book.Amount == 0)
                            {
                                db.Books.Remove(book);
                                db.SaveChanges();
                                return true;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows you to add a new category if category does not exist
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns>boolean true if successful, false if not</returns>
        public bool AddCategory(int adminId, string name)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var category = db.BookCategories.FirstOrDefault(b => b.Genere == name);
                        if (category == null)
                        {
                            var newBookCategory = new BookCategory
                            {
                                Genere = name
                            };
                            db.BookCategories.Add(newBookCategory);
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Sets the relation between book and book category
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns>boolean true if successful, false if not</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var book = db.Books.FirstOrDefault(b => b.ID == bookId);
                        var bookCategory = db.BookCategories.FirstOrDefault(b => b.ID == categoryId);

                        book.BookCategoryId = bookCategory.ID;
                        db.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows you to update the name of a category
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns>boolean true if success, false if not</returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var bookCategory = db.BookCategories.FirstOrDefault(b => b.ID == categoryId);
                        if (bookCategory != null)
                        {
                            bookCategory.Genere = name;
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows you to delete a category as long as the category does not have any relation to books
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns>true if successful, false if not</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            //would like to add ON DELETE SET NULL (Unsure of correct set up for this one, possibly modelbuilder in context(?))
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var category = db.BookCategories.FirstOrDefault(b => b.ID == categoryId);
                        if (category != null)
                        {
                            var categoryRelation = db.Books
                                .Include(b => b.BookCategory)
                                .Where(b => b.BookCategoryId == categoryId).ToList();

                            if (categoryRelation.Count == 0)
                            {
                                db.BookCategories.Remove(category);
                                db.SaveChanges();
                                return true;
                            }
                            if (categoryRelation.Count > 0)
                            {
                                Console.WriteLine("Failed to delete category, there are books related to this category.");
                                return false;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows you to add a new user if user does not already exist
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns>true if success, false if not</returns>
        public bool AddUser(int adminId, string userName, string userPassword = "Codic2021")
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminId);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var user = db.Users.FirstOrDefault(u => u.Name == userName);
                        if (user == null)
                        {
                            var newlyCreatedUser = new Users
                            {
                                Name = userName,
                                Password = userPassword,
                                IsActive = true,
                                IsAdmin = false
                            };
                            db.Users.Add(newlyCreatedUser);
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows you see all sold books
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns>list of sold books if successful</returns>
        public List<SoldBooks> SoldItems(int adminID)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminID);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return new List<SoldBooks>();
                    }
                    if (adminUser.IsAdmin)
                    {
                        var soldBooks = db.SoldBooks.OrderBy(b => b.Title).ToList();
                        if (soldBooks != null)
                        {
                            return soldBooks;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return new List<SoldBooks>();
            }

        }

        /// <summary>
        /// Allows you to get the total price of sold items
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns>integer</returns>
        public int MoneyEarned(int adminID)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminID);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return 0;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var totalAmount = db.SoldBooks.Sum(b => b.Price);
                        if (totalAmount > 0)
                        {
                            return totalAmount;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return 0;
            }

        }

        /// <summary>
        /// Allows you to get the customer that has bought the most number of books
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns>int, customers ID</returns>
        //Retrieving data with group by searched in ISBN 978-1-80056-810-5, page 425 and 431
        //https://stackoverflow.com/questions/16522645/linq-groupby-sum-and-count
        public int BestCustomer(int adminID)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminID);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return 0;
                    }
                    if (adminUser.IsAdmin)
                    {
                        // First create groups of userId for every userId in SoldBooks Table, count number of datarows(sold books) order by highest up top(DESC), select top 1 row.
                        //return "key" which is the userId of that customer(due to grouped by)
                        var customers = db.SoldBooks.AsEnumerable()
                            .GroupBy(u => u.UsersId)
                            .OrderByDescending(u => u.Count())
                            .FirstOrDefault();

                        return customers.Key;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return 0;
            }

        }

        /// <summary>
        /// Allows you to promote a user to Admin user.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns>true if success, false if fail</returns>
        public bool Promote(int adminID, int userID)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminID);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var user = db.Users.FirstOrDefault(u => u.ID == userID);
                        if (user != null)
                        {
                            user.IsAdmin = true;
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows to remove user as admin
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns>true if success, false if fail</returns>
        public bool Demote(int adminID, int userID)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminID);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var user = db.Users.FirstOrDefault(u => u.ID == userID);
                        if (user != null)
                        {
                            user.IsAdmin = false;
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows you to activate user
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns>boolean true if success, false if not</returns>
        public bool ActivateUser(int adminID, int userID)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminID);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var user = db.Users.FirstOrDefault(u => u.ID == userID);
                        if (user != null)
                        {
                            user.IsActive = true;
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows you to inactivate a user
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns>true if success, false if not</returns>
        public bool InactivateUser(int adminID, int userID)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var adminUser = db.Users.FirstOrDefault(u => u.ID == adminID);
                    bool isActive = CheckSessionTimer(adminUser);

                    if (!isActive)
                    {
                        Console.WriteLine("You have to login to proceed");
                        return false;
                    }
                    if (adminUser.IsAdmin)
                    {
                        var user = db.Users.FirstOrDefault(u => u.ID == userID);
                        if (user != null)
                        {
                            user.IsActive = false;
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Allows you to check the users session timer, if non action is made in 15 minutes,
        /// User is considered inactive.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolean true if timer < 15, false if not.</returns>
        public bool CheckSessionTimer(Users user)
        {
            using (var db = new WebbshopContext())
            {
                try
                {
                    var timer = DateTime.Now - user.SessionTimer;
                    var minutes = timer.TotalMinutes;
                    if (minutes < 15)
                    {
                        user.IsActive = true;
                        user.SessionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }

                    user.IsActive = false;
                    db.SaveChanges();
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception was thrown: {e.Message}");
                }
                return false;
            }
        }
    }
}
