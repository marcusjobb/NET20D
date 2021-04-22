using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebShop.Database;
using WebShop.Models;

namespace WebShop
{
    public class WebShopApi
    {
        public bool IsUserAdmin;
        /// <summary>
        /// Login method that will check if records match with the database
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int Login(string Username, string Password)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == Username && u.Password == Password);
                if (user != null)
                {
                    user.LastLogin = DateTime.Now;
                    user.SessionTimer = DateTime.Now;
                    db.Users.Update(user);
                    db.SaveChanges();
                    var admin = db.Users.Where(a => a.Id == user.Id).Select(a => a.IsAdmin).FirstOrDefault();
                    if (admin == true)
                    {
                        IsUserAdmin = true;
                    }
                    else
                    {
                        IsUserAdmin = false;
                    }
                    return user.Id;
                }
            }
            return 0;
        }

        /// <summary>
        /// Register method that will register a new user
        /// If user allready exists it wont be created
        /// Passwords needs to be verified as well
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <param name="PasswordVerify"></param>
        public void Register(string Name, string Password, string PasswordVerify)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == Name);
                if(Name == "")
                {
                    Console.Clear();
                    PrintLinesInCenter(
                    "╔════════════════════════════╗",
                    "║  Username cannot be empty  ║",
                    "╚════════════════════════════╝"
                    );
                }
                else { 
                    if (user != null)
                    {
                        Console.Clear();
                        UserAllreadyExists();
                    }
                    else if (user == null)
                    {
                        if (Password == PasswordVerify)
                        {
                            db.Users.Add(new User
                            {
                                Name = Name,
                                Password = Password,
                                IsActive = true
                            });
                            Console.Clear();
                            PrintLinesInCenter(
                            "╔═══════════════════════════════════════════╗",
                            "║  You sucessfully registered your account  ║",
                            "╚═══════════════════════════════════════════╝"
                            );
                        }
                        else
                        {
                            Console.Clear();
                            PrintLinesInCenter(
                            "╔═══════════════════════════════════════════╗",
                            "║  Password doesnt match, please try again  ║",
                            "╚═══════════════════════════════════════════╝"
                            );
                        }
                    }
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Logout method that logouts the user and resets the session timer
        /// </summary>
        /// <param name="Id"></param>
        public void Logout(int Id)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == Id);
                if (user != null)
                {
                    user.SessionTimer = DateTime.MinValue;
                    db.Users.Update(user);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// PING method that will check if user is still active and update their sessiontimer
        /// </summary>
        /// <param name="userId"></param>
        private static void Ping(int userId)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId && u.SessionTimer > DateTime.Now.AddMinutes(-15));
                string pong = "pong";

                if (user != null)
                {
                    Console.Clear();
                    PrintLinesInCenter(
                    "──────",
                    " " + pong,
                    "──────"
                    );
                    Console.ReadKey();
                    user.SessionTimer = DateTime.Now;
                    db.Update(user);
                    db.SaveChanges();
                    Console.Clear();
                }
                else
                {
                //It felt redundant to just display an empty string, it will ruin the frontend experience
                }
            }
        }

        /// <summary>
        /// AddUser Method This is the method that admin can use to create new users
        /// </summary>
        /// <param name="AdminId"></param>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        public void AddUser(int AdminId, string Name, string Password)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
                if (admin == true)
                {
                    var user = db.Users.FirstOrDefault(u => u.Name == Name);
                    if(Name == "")
                    {
                        Console.Clear();
                        PrintLinesInCenter(
                        "╔════════════════════════════╗",
                        "║  Username cannot be empty  ║",
                        "╚════════════════════════════╝"
                        );
                    }
                    else { 
                        if (user != null)
                        {
                            UserAllreadyExists();
                        }
                        else if (user == null)
                        {
                            if (Password == "")
                            {
                                db.Users.Add(new User
                                {
                                    Name = Name,
                                    Password = "Codic2021",
                                    IsActive = true
                                });
                            }
                            else
                            {
                                db.Users.Add(new User
                                {
                                    Name = Name,
                                    Password = Password,
                                    IsActive = true
                                });
                            }
                            Console.Clear();
                            PrintLinesInCenter(
                            "╔══════════════════╗",
                            "║  New user added  ║",
                            "╚══════════════════╝"
                            );
                        }
                        db.SaveChanges();
                    }
                }
                else
                {
                    Console.Clear();
                    NotAdminErrorMessage();
                }
            }
        }

        /// <summary>
        /// ListUser Method that with help of AdminId will display all the current users, else method will not be deployed
        /// </summary>
        /// <param name="AdminId"></param>
        /// <returns></returns>
        public IEnumerable<User> ListUsers(int AdminId)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
                if (admin == true)
                {
                    var GetUsers = db.Users.OrderBy(c => c.Id).ToList();
                    foreach (var user in GetUsers)
                    {
                        yield return user;
                    }
                }
                yield break;
            }
        }

        /// <summary>
        /// FindUser Method that with help of Admin ID will find users based on keyword search
        /// </summary>
        /// <param name="AdminId"></param>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        public IEnumerable<User> FindUser(int AdminId, string Keyword)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
                if (admin == true)
                {
                    var FindUser = db.Users.Where(u => u.Name.Contains(Keyword)).OrderBy(u => u.Name).ToList();
                    foreach (var item in FindUser)
                    {
                        yield return item;
                    }
                }
                yield break;
            }
        }

        /// <summary>
        /// GetCategories method will display all the current categories of books
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookCategory> GetCategories()
        {
            using (var db = new DatabaseContext())
            {
                var GetCat = db.BookCategories.OrderBy(c => c.Id).ToList();
                return GetCat;
            }
        }

        /// <summary>
        /// GetCategories will display all categories based on search keyword
        /// </summary>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        public IEnumerable<BookCategory> GetCategories(string Keyword)
        {
            using (var db = new DatabaseContext())
            {
                var GetCat = db.BookCategories.Where(c => c.Name.Contains(Keyword)).OrderBy(c => c.Name).ToList();
                return GetCat;
            }
        }

        /// <summary>
        /// AddCategory Method that will let the admin to add new categories for the books
        /// </summary>
        /// <param name="AdminId"></param>
        /// <param name="name"></param>
        public void AddCategory(int AdminId, string name)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
                if (admin == true)
                {
                    var book = db.BookCategories.FirstOrDefault(c => c.Name == name);
                    if (book == null)
                    {
                        db.BookCategories.Add(new BookCategory
                        {
                            Name = name
                        });
                        db.SaveChanges();
                        Console.Clear();
                        PrintLinesInCenter(
                       "╔══════════════════════╗",
                       "║  New category added  ║",
                       "╚══════════════════════╝"
                       );
                    } 
                    else
                    {
                        Console.Clear();
                        CategoryAllreadyExists();
                    }
                }
                else
                {
                    Console.Clear();
                    NotAdminErrorMessage();
                }
            }
        }

        /// <summary>
        /// UpdateCategory method that will let us rename a specific category
        /// </summary>
        /// <param name="AdminId"></param>
        /// <param name="CategoryId"></param>
        /// <param name="Name"></param>
        public void UpdateCategory(int AdminId, int CategoryId, string Name)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();

                if (admin == true)
                {
                    var cat = db.BookCategories.SingleOrDefault(c => c.Id == CategoryId);
                    if (cat != null)
                    {
                        cat.Name = Name;
                        db.Update(cat);
                        db.SaveChanges();
                        Console.Clear();
                        PrintLinesInCenter(
                        "╔════════════════════╗",
                        "║  Category updated  ║",
                        "╚════════════════════╝"
                        );
                    }
                    else
                    {
                        Console.Clear();
                        CategoryDoesNotExistErrorMessage();
                    }
                }
                else
                {
                    Console.Clear();
                    NotAdminErrorMessage();
                }
            }
        }

        /// <summary>
        /// AddCategory Method that will display all books in a specific category
        /// </summary>
        /// <param name="CategoryId"></param>
        public void GetCategory(int CategoryId)
        {
            using (var db = new DatabaseContext())
            {
                var catExist = db.BookCategories.SingleOrDefault(c => c.Id == CategoryId);
                if(catExist != null) { 
                    foreach (var cat in db.BookCategories.Include("Books").Where(c => c.Id == CategoryId))
                    {
                        Console.WriteLine("──────────────────────────");
                        Console.WriteLine($"Category name - {cat.Name}");
                        Console.WriteLine("Id - Title");
                        foreach (var book in cat.Books)
                        {
                            Console.Write($"{book.Id} - {book.Title}");
                            Console.WriteLine();
                        }
                        Console.WriteLine("──────────────────────────");
                    }
                }
                else
                {
                    Console.Clear();
                    CategoryDoesNotExistErrorMessage();
                }
            }
        }

        /// <summary>
        /// DeleteCategory method that lets us delete a category, as long as it doesnt have any books connected to it
        /// There is also a check that you have to have adminid to be able to execute this method
        /// </summary>
        /// <param name="AdminId"></param>
        /// <param name="CategoryId"></param>
        public void DeleteCategory(int AdminId, int CategoryId)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();

                if (admin == true)
                {
                    var checkIfCatExists = db.BookCategories.FirstOrDefault(c => c.Id == CategoryId);

                    if(checkIfCatExists != null)
                    {
                        foreach (var cat in db.BookCategories.Include("Books").Where(c => c.Id == CategoryId).ToList())
                        {
                            if (cat.Books.Count != 0)
                            {
                                Console.Clear();
                                PrintLinesInCenter(
                                "╔════════════════════════════════════════╗",
                                "║      Category cannot be deleted        ║",
                                "║  ──────────────────╬─────────────────  ║",
                                "║ There are still books connected to it  ║",
                                "║ ──────────────────╬─────────────────   ║",
                                "║  You have to remove the books first    ║",
                                "╚════════════════════════════════════════╝"
                                );
                            }
                            else
                            {
                                db.Attach(cat);
                                db.Remove(cat);
                                db.SaveChanges();
                                Console.Clear();
                                PrintLinesInCenter(
                                "╔════════════════════╗",
                                "║  Category Removed  ║",
                                "╚════════════════════╝"
                                );
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        CategoryDoesNotExistErrorMessage();
                    }
                }
                else
                {
                    Console.Clear();
                    NotAdminErrorMessage();
                }
            }
        }

        /// <summary>
        /// GetAvailableBooks method that displays all books that are currently in stock in a category
        /// </summary>
        /// <param name="CategoryId"></param>
        public void GetAvailableBooks(int CategoryId)
        {
            using (var db = new DatabaseContext())
            {
                var catExist = db.BookCategories.SingleOrDefault(c => c.Id == CategoryId);
                if(catExist != null) { 
                    foreach (var cat in db.BookCategories.Include("Books").Where(c => c.Id == CategoryId))
                    {
                        Console.WriteLine("──────────────────────────");
                        Console.WriteLine($"Category name - {cat.Name}");
                        Console.WriteLine("Id - Title");
                        foreach (var book in cat.Books.Where(b => b.Amount > 0))
                        {
                            Console.Write($"{book.Id} - {book.Title}");
                            Console.WriteLine();
                        }
                        Console.WriteLine("──────────────────────────");
                    }
                }
                else
                {
                    Console.Clear();
                    CategoryDoesNotExistErrorMessage();
                }
            }
        }

        /// <summary>
        /// GetBook Method that will give us information about a specific book with help of the id of the book
        /// </summary>
        /// <param name="Bookid"></param>
        public void GetBook(int userId, int Bookid)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(userId);
                var book = db.Books.FirstOrDefault(b => b.Id == Bookid);
                if (book != null)
                {
                    foreach (var bookwithcat in db.Books.Include("BookCategories").Where(b => b.Id == Bookid))
                    {
                        foreach (var cat in bookwithcat.BookCategories)
                        {
                            var catname = cat.Name;
                            Console.Clear();
                            Console.WriteLine("──────────────────────────");
                            Console.WriteLine(" Book information");
                            Console.WriteLine($" Title | {book.Title}");
                            Console.WriteLine($" Author | {book.Author}");
                            Console.WriteLine($" Price | {book.Price}");
                            Console.WriteLine($" Ammount | {book.Amount}");
                            Console.WriteLine($" Category | {catname}");
                            Console.WriteLine("──────────────────────────");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    BookIdDoesNotExistErrorMessage();
                }
            }
        }

        /// <summary>
        /// Method that displays books based on searching for title
        /// </summary>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        public IEnumerable<Book> GetBooks(string Keyword)
        {
            using (var db = new DatabaseContext())
            {
                var GetBooks = db.Books.Where(b => b.Title.Contains(Keyword)).OrderBy(b => b.Title).ToList();
                return GetBooks;
            }
        }

        /// <summary>
        /// Get Authors method returns book based on searching with keyword for the author
        /// </summary>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        public IEnumerable<Book> GetAuthors(string Keyword)
        {
            using (var db = new DatabaseContext())
            {
                var GetAuthors = db.Books.Where(a => a.Author.Contains(Keyword)).OrderBy(a => a.Author).ToList();
                return GetAuthors;
            }
        }

        /// <summary>
        /// BuyBook Method will let an user buy a book and the records of the user and the book will be copied to the table SoldBooks
        /// Will only be possible if the user been active for the last 15 minutes
        /// UPDATE ASSIGNMENT NR3
        /// I had to add some error handling either if the book is not in stock, or if wrong book id was entered
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="BookId"></param>
        public void BuyBook(int UserId, int BookId)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == UserId && u.SessionTimer > DateTime.Now.AddMinutes(-15));
                var bookIdExists = db.Books.FirstOrDefault(b => b.Id == BookId);
                WebShopApi.Ping(UserId);
                if (user != null)
                {
                    if (bookIdExists != null) 
                    {
                        if(bookIdExists.Amount >= 1) { 

                            foreach (var book in db.Books.Include("BookCategories").Where(b => b.Id == BookId).ToList())
                            {
                                foreach (var cat in book.BookCategories)
                                {
                                    var catid = cat.Id;

                                    db.SoldBooks.Add(new SoldBook
                                    {
                                        Title = book.Title,
                                        Author = book.Author,
                                        Price = book.Price,
                                        PurchaseDate = DateTime.Now,
                                        CategoryId = catid,
                                        UserId = UserId
                                    });
                                    db.SaveChanges();
                                    book.Amount = book.Amount - 1;
                                    db.Update(book);
                                    db.SaveChanges();

                                    Console.Clear();
                                    PrintLinesInCenter(
                                    "╔══════════════════════════╗",
                                    "║  A new book was bought!  ║",
                                    "╚══════════════════════════╝"
                                    );
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            PrintLinesInCenter(
                            "╔══════════════════════════════════╗",
                            "║  The book you are trying to buy  ║",
                            "║    Is currently out of stock     ║",
                            "╚══════════════════════════════════╝"
                            );
                        }
                    }
                    else
                    {
                        Console.Clear();
                        BookIdDoesNotExistErrorMessage();
                    }
                }
                else
                {
                    Console.Clear();
                    PrintLinesInCenter(
                    "╔════════════════════════════════════════════════════╗",
                    "║  You have not been active for the last 15 minutes  ║",
                    "║    To be able to buy a book, please login again    ║",
                    "╚════════════════════════════════════════════════════╝"
                    );
                }
            }
        }

        /// <summary>
        /// AddBookToCategory method lets us add a book based on id to be connected to a category based on their id
        /// To create a relation between them
        /// </summary>
        /// UPDATE
        /// I had to add some more code to this to get it to work with the frontend part
        /// So that it wont add more than 1 category to a book
        /// <param name="AdminId"></param>
        /// <param name="BookId"></param>
        /// <param name="CategoryId"></param>
        public void AddBookToCategory(int AdminId, int BookId, int CategoryId)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();

                if (admin == true)
                {
                    var bookId = db.Books.Include("BookCategories").FirstOrDefault(b => b.Id == BookId);
                    int count = 0;
                    foreach (var book in db.Books.Include("BookCategories").Where(c=>c.Id == BookId))
                    {
                        foreach (var cat in book.BookCategories)
                        {
                            count++;
                        }
                    }
                    var checkIfCategoryExists = db.BookCategories.FirstOrDefault(c => c.Id == CategoryId);
                    var bookIdExist = db.Books.SingleOrDefault(b => b.Id == BookId);

                    if(bookIdExist != null) { 
                        if(checkIfCategoryExists != null)
                        {
                            if (count == 0)
                            {
                                if (bookId.BookCategories.FirstOrDefault(c => c.Id == CategoryId) == null)
                                {
                                    foreach (var bookcategory in db.BookCategories.ToList())
                                    {
                                        var cat = db.BookCategories.FirstOrDefault(c => c.Id == CategoryId);
                                        if (cat == null)
                                        {
                                            cat = new BookCategory
                                            {
                                                Id = CategoryId
                                            };
                                        }
                                        bookId.BookCategories.Add(cat);
                                    }
                                    db.Update(bookId);
                                    db.SaveChanges();
                                    Console.Clear();
                                    PrintLinesInCenter(
                                    "╔══════════════════════════╗",
                                    "║  Category added to book  ║",
                                    "╚══════════════════════════╝"
                                    );
                                }
                            }
                            else
                            {
                                Console.Clear();
                                PrintLinesInCenter(
                                "╔══════════════════════════════════╗",
                                "║  Book is allready in a category  ║",
                                "╚══════════════════════════════════╝"
                                );
                            }
                        }
                        else
                        {
                            Console.Clear();
                            CategoryDoesNotExistErrorMessage();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        BookIdDoesNotExistErrorMessage();
                    }
                }
                else
                {
                    Console.Clear();
                    NotAdminErrorMessage();
                }
            }
        }

        /// <summary>
        /// AddBook Method that will let us add either more of the same book which will increase the amount
        /// Or if book currently doesnt exist, it will be created
        /// NOTE - in the spec it was said that we should set the ID of the book. But in my opinion its better for EF
        /// To generate the Id's on their own so that we dont mess something up
        /// </summary>
        /// <param name="AdminId"></param>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        /// <param name="Price"></param>
        /// <param name="Amount"></param>
        public void AddBook(int AdminId, string Title, string Author, int Price, int Amount)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();

                if (admin == true)
                {
                    var book = db.Books.SingleOrDefault(b => b.Title == Title);
                    
                    if (book != null)
                    {
                        book.Amount = book.Amount + Amount;
                        db.Update(book);
                        db.SaveChanges();
                        Console.Clear();
                        PrintLinesInCenter(
                        "╔═════════════════════════════╗",
                        "║  More books added to stock  ║",
                        "╚═════════════════════════════╝"
                        );
                    }
                    else
                    {
                        book = new Book
                        {
                            Title = Title,
                            Author = Author,
                            Price = Price,
                            Amount = Amount
                        };
                        db.Books.Add(book);
                        db.SaveChanges();
                        Console.Clear();
                        PrintLinesInCenter(
                        "╔═════════════════════════════════╗",
                        "║  New book added to the webshop  ║",
                        "╚═════════════════════════════════╝"
                        );
                    }
                }
                else
                {
                    Console.Clear();
                    NotAdminErrorMessage();
                }
            }
        }

        /// <summary>
        /// SetAmount Method that lets the admin change the amount of books for a certain book
        /// </summary>
        /// <param name="AdminId"></param>
        /// <param name="BookId"></param>
        /// <param name="BookAmount"></param>
        public void SetAmount(int AdminId, int BookId, int BookAmount)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
                if (admin == true)
                {
                    var result = db.Books.SingleOrDefault(b => b.Id == BookId);
                    if (result != null)
                    {
                        result.Amount = BookAmount;
                        db.Update(result);
                        db.SaveChanges();
                        Console.Clear();
                        PrintLinesInCenter(
                        "╔═══════════════════════╗",
                        "║  Book amount updated  ║",
                        "╚═══════════════════════╝"
                        );
                    }
                    else
                    {
                        Console.Clear();
                        BookIdDoesNotExistErrorMessage();
                    }
                }
                else
                {
                    Console.Clear();
                    NotAdminErrorMessage();
                }
            }
        }

        /// <summary>
        /// UpdateBook Method that will let the admin update information about a specific book
        /// </summary>
        /// <param name="AdminId"></param>
        /// <param name="Bookid"></param>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        /// <param name="Price"></param>
        public void UpdateBook(int AdminId, int Bookid, string Title, string Author, int Price)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
                if (admin == true)
                {
                    var book = db.Books.SingleOrDefault(b => b.Id == Bookid);
                    if (book != null)
                    {
                        book.Title = Title;
                        book.Author = Author;
                        book.Price = Price;
                        db.Update(book);
                        db.SaveChanges();
                        Console.Clear();
                        PrintLinesInCenter(
                        "╔════════════════╗",
                        "║  Book updated  ║",
                        "╚════════════════╝"
                        );
                    }
                    else
                    {
                        Console.Clear();
                        BookIdDoesNotExistErrorMessage();
                    }
                }
                else
                {
                    Console.Clear();
                    NotAdminErrorMessage();
                }
            }
        }

        /// <summary>
        /// DeleteBook Method that will let admin remove 1 amount of book, if its 0 the book will be removed from the database
        /// </summary>
        /// <param name="AdminId"></param>
        /// <param name="BookId"></param>
        public void DeleteBook(int AdminId, int BookId)
        {
            using (var db = new DatabaseContext())
            {
                WebShopApi.Ping(AdminId);
                var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
                if (admin == true)
                {
                    var book = db.Books.SingleOrDefault(b => b.Id == BookId);
                    if (book != null)
                    {
                        book.Amount = book.Amount - 1;
                        db.Update(book);
                        db.SaveChanges();

                        if (book.Amount <= 0)
                        {
                            db.Attach(book);
                            db.Remove(book);
                            db.SaveChanges();
                        }
                        Console.Clear();
                        PrintLinesInCenter(
                        "╔════════════════╗",
                        "║  Book removed  ║",
                        "╚════════════════╝"
                        );
                    }
                    else
                    {
                        Console.Clear();
                        BookIdDoesNotExistErrorMessage();
                    }
                }
                else
                {
                    Console.Clear();
                    NotAdminErrorMessage();
                }
            }
        }

        /// <summary>
        /// I had to add this method to display all the books for making my frontend work
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> DisplayAllBooks()
        {
            using(var db = new DatabaseContext())
            {
                var getBooks = db.Books.OrderBy(c => c.Id).ToList();
                return getBooks;
            }
        }

        /// <summary>
        /// I put this method here too use it within the API, its merely for displaying the error handling
        /// from the API functions to look like the error handling in the frontend
        ///  Code taken from --->
        /// https://stackoverflow.com/questions/61378701/i-want-to-center-the-text-in-console-both-horizontally-and-vertically-using-c-sh
        /// </summary>
        /// <param name="lines"></param>
        private static void PrintLinesInCenter(params string[] lines)
        {
            int verticalStart = (Console.WindowHeight - lines.Length) / 2;
            int verticalPosition = verticalStart;
            foreach (var line in lines)
            {
                int horizontalStart = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(horizontalStart, verticalPosition);
                Console.Write(line);
                ++verticalPosition;
            }
        }

        /// <summary>
        /// Repeated error message if method fails to execute because user dont have admin privileges
        /// </summary>
        private static void NotAdminErrorMessage()
        {
            PrintLinesInCenter(
            "╔══════════════════════════════════╗",
            "║    Method cannot be executed     ║",
            "║  ──────────────╬───────────────  ║",
            "║    Because User is NOT Admin     ║",
            "╚══════════════════════════════════╝"
            );
        }

        /// <summary>
        /// Repeated error message if entered username allready exists in the database
        /// </summary>
        private static void UserAllreadyExists()
        {
            PrintLinesInCenter(
            "╔═══════════════════════════════════╗",
            "║     The username you entered      ║",
            "║  ──────────────╬────────────────  ║",
            "║  Allready exists in the database  ║",
            "╚═══════════════════════════════════╝"
            );
        }

        /// <summary>
        /// Repeated error message if entered category id allready exists in the database
        /// </summary>
        private static void CategoryAllreadyExists()
        {
            PrintLinesInCenter(
            "╔═══════════════════════════════════╗",
            "║   The category name you entered   ║",
            "║  ──────────────╬────────────────  ║",
            "║  Allready exists in the database  ║",
            "╚═══════════════════════════════════╝"
            );
        }
        /// <summary>
        /// Repeated error message if entered category id does not exist in the database
        /// </summary>
        private static void CategoryDoesNotExistErrorMessage()
        {
            PrintLinesInCenter(
            "╔═══════════════════════════════════╗",
            "║    The category id you entered    ║",
            "║  ──────────────╬────────────────  ║",
            "║  Does not exists in the database  ║",
            "╚═══════════════════════════════════╝"
            );
        }

        /// <summary>
        /// Repeated error message if entered book id does not exist in the database
        /// </summary>
        private static void BookIdDoesNotExistErrorMessage()
        {
            PrintLinesInCenter(
            "╔══════════════════════════════════╗",
            "║     The book id you entered      ║",
            "║  ──────────────╬───────────────  ║",
            "║  Does not exist in the database  ║",
            "╚══════════════════════════════════╝"
            );
        }
    }
}