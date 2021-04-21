using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

// Påminnelse, kom ihåg att allt ska vara public i denna klassen.
// Påminnelse, programmet behöver inte ha en Meny. Alla metoder körs i main.
// TODO: Gör om så att alla API metoder returnerar ett värde.

namespace WebbShopAPI
{
    public class WebbShopAPI
    {
        /// <summary>
        /// Denna metoden Loggar in användaren i 15 minuter.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string username, string password)
        {
            int ID = 0;
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == username);

                if (user != null && username == user.Name && password == user.Password && user.IsActive)
                {
                    user.SessionTimer = DateTime.Now;
                    DateTime newTime = user.SessionTimer.AddMinutes(15);
                    user.SessionTimer = newTime;
                    ID = user.ID;
                }
                db.SaveChanges();
            }
            return ID;
        }

        /// <summary>
        /// Denna metod loggar ut användaren.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Logout(int ID)
        {
            using (var db = new DatabaseContext())
            {
                bool logout = false;
                var user = db.Users.FirstOrDefault(u => u.ID == ID);
                if (user != null)
                {
                    logout = true;
                    user.SessionTimer = DateTime.Now;
                }
                db.SaveChanges();
                return logout;
            }
        }

        /// <summary>
        /// Denna metoden kollar ifall användaren har IsAdmin satt till true eller false.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsAdmin(string username)
        {
            bool admin = false;
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == username);

                if (user != null && user.IsAdmin == true)
                {
                    admin = true;
                }
                return admin;
            }
        }

        /// <summary>
        /// Denna metod listar upp alla bokkategorier.
        /// </summary>
        public List<BookCategory> GetCategories()
        {
            using (var db = new DatabaseContext())
            {
                List<BookCategory> categoryList = new List<BookCategory>();
                foreach (var book in db.BookCategory)
                {
                    categoryList.Add(book);
                }
                return categoryList;
            }
        }

        /// <summary>
        /// Denna metod listar upp alla bokkategorier som matchar parametern som skrivs in.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            using (var db = new DatabaseContext())
            {
                List<BookCategory> bookList = new List<BookCategory>();
                foreach (BookCategory book in db.BookCategory)
                {
                    if (book.Name.Contains(keyword))
                    {
                        bookList.Add(book);
                    }
                }
                return bookList;
            }
        }

        /// <summary>
        /// Denna metod listar upp den kategori som matchar med det ID som matas in.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Book> GetCategory(int ID)
        {
            using (var db = new DatabaseContext())
            {
                List<Book> bookList = new List<Book>();
                var category = db.BookCategory.FirstOrDefault(c => c.ID == ID);
                if (category != null)
                {
                    foreach (var book in db.Books)
                    {
                        if (book.CategoryID == category.ID)
                        {
                            bookList.Add(book);
                        }
                    }
                }
                return bookList;
            }
        }

        /// <summary>
        /// Denna metod tar in ett kategori ID och returnerar en lista av alla böcker som finns inom just den bokkategorin.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Book> GetAvailableBooks(int ID)
        {
            using (var db = new DatabaseContext())
            {
                List<Book> bookList = new List<Book>();
                var category = db.BookCategory.FirstOrDefault(c => c.ID == ID);
                if (category != null)
                {
                    foreach (var book in db.Books)
                    {
                        if (book.Amount > 0 && book.CategoryID == ID)
                        {
                            bookList.Add(book);
                        }
                    }
                }
                return bookList;
            }
        }

        /// <summary>
        /// Denna metod tar in ID och returnerar en bok om den finns i databasen.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Book GetBook(int ID)
        {
            using (var db = new DatabaseContext())
            {
                var book = db.Books.FirstOrDefault(b => b.ID == ID);
                return book;
            }
        }

        /// <summary>
        /// Denna metod listar upp alla böcker som matchar med parametern som skrivs in.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Book> GetBooks(string keyword)
        {
            using (var db = new DatabaseContext())
            {
                List<Book> booklist = new List<Book>();
                foreach (Book book in db.Books)
                {
                    if (book.Title.Contains(keyword))
                    {
                        booklist.Add(book);
                    }
                }
                return booklist;
            }
        }

        /// <summary>
        /// Denna metod listar upp alla författare som matchar med parametern som skrivs in.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Book> GetAuthors(string keyword)
        {
            using (var db = new DatabaseContext())
            {
                List<Book> booklist = new List<Book>();
                foreach (Book book in db.Books)
                {
                    if (book.Author.Contains(keyword))
                    {
                        booklist.Add(book);
                    }
                }
                return booklist;
            }
        }

        /// <summary>
        /// Denna metod används för att användare ska kunna köpa böcker. Om användaren inte är inloggad så går det inte att köpa något.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public bool BuyBook(int userID, int bookID)
        {
            using (var db = new DatabaseContext())
            {
                {
                    bool sold = false;
                    var user = db.Users.FirstOrDefault(u => u.ID == userID);
                    var book = db.Books.FirstOrDefault(u => u.ID == bookID);

                    if (user != null && book != null && book.Amount > 0 && user.SessionTimer > DateTime.Now)
                    {
                        db.SoldBooks.Add(new SoldBooks
                        {
                            Title = book.Title,
                            Author = book.Author,
                            Price = book.Price,
                            PurchasedDate = user.SessionTimer,
                            CategoryId = book.CategoryID,
                            UserID = user.ID
                        });
                        book.Amount--;
                        sold = true;
                        Ping(userID);
                        db.SaveChanges();
                    }
                    return sold;
                }
            }
        }

        /// <summary>
        /// Denna metoden kollar om en användare är inloggad, och ifall användaren är inloggad så ökar SessionTimer med 15 minuter.
        /// Denna metoden finns inuti andra metoder som kräver ett ID ifrån användaren. Detta är till för att hålla anslutningen vid liv.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string Ping(int ID)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.ID == ID);
                string pong = "";
                if (user != null)
                {
                    if (user.SessionTimer > DateTime.Now)
                    {
                        pong = "Pong";
                        user.SessionTimer = DateTime.Now;
                        DateTime newTime = user.SessionTimer.AddMinutes(15);
                        user.SessionTimer = newTime;
                    }
                }
                db.SaveChanges();
                return pong;
            }
        }

        /// <summary>
        /// Denna metod registrerar en ny användare. Om användaren matar in ett tomt värde så sätts ett defaultlösenord.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        public bool Register(string username, string password, string passwordVerify)
        {
            using (var db = new DatabaseContext())
            {
                bool create = false;
                var user = db.Users.FirstOrDefault(u => u.Name == username);
                if (user == null && String.IsNullOrEmpty(password) == true)
                {
                    db.Users.Add(new User
                    {
                        Name = username
                    });
                    db.SaveChanges();
                    create = true;
                }
                else if (user == null && password == passwordVerify)
                {
                    db.Users.Add(new User
                    {
                        Name = username,
                        Password = password,
                    });
                    db.SaveChanges();
                    create = true;
                }
                return create;
            }
        }

        /// <summary>
        /// Denna metod lägger till en bok i databasen om den inte finns. Om boken redan finns så fylls det på med nya böcker istället.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddBook(int adminID, int bookID, string title, string author, int price, int amount)
        {
            using (var db = new DatabaseContext())
            {
                bool addBook = false;
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);
                var book = db.Books.FirstOrDefault(b => b.ID == bookID);

                if (book != null && user != null && user.IsAdmin == true && user.SessionTimer > DateTime.Now)
                {
                    book.Amount += amount;
                    addBook = true;
                    db.SaveChanges();
                    Ping(adminID);
                }
                else if (book == null && user != null && user.IsAdmin == true && user.SessionTimer > DateTime.Now)
                {
                    db.Books.Add(new Book
                    {
                        Title = title,
                        Author = author,
                        Price = price,
                        Amount = amount
                    });
                    addBook = true;
                    db.SaveChanges();
                    Ping(adminID);
                }
                return addBook;
            }
        }

        /// <summary>
        /// Denna metod ställer in hur många kopior av angedd bok som ska finnas.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool SetAmount(int adminID, int bookID, int amount)
        {
            using (var db = new DatabaseContext())
            {
                bool newAmount = false;
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);
                var book = db.Books.FirstOrDefault(b => b.ID == bookID);

                if (book != null && user != null && user.IsAdmin == true && user.SessionTimer > DateTime.Now)
                {
                    book.Amount = amount;
                    newAmount = true;
                    db.SaveChanges();
                    Ping(adminID);
                }
                return newAmount;
            }
        }

        /// <summary>
        /// Denna metod returnerar en lista av alla användare i databasen.
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public List<User> ListUsers(int adminID)
        {
            using (var db = new DatabaseContext())
            {
                List<User> userList = new List<User>();
                var admin = db.Users.FirstOrDefault(u => u.ID == adminID);
                if (admin != null && admin.IsAdmin == true && admin.SessionTimer > DateTime.Now)
                {
                    foreach (User user in db.Users)
                    {
                        userList.Add(user);
                    }
                    Ping(adminID);
                }
                return userList;
            }
        }

        /// <summary>
        /// Denna metod söker efter användare som matchar parametern och returnerar en lista.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<User> FindUser(int adminID, string keyword)
        {
            using (var db = new DatabaseContext())
            {
                List<User> userList = new List<User>();
                var admin = db.Users.FirstOrDefault(u => u.ID == adminID);
                if (admin != null && admin.IsAdmin == true && admin.SessionTimer > DateTime.Now)
                {
                    foreach (User user in db.Users)
                    {
                        if (user.Name.Contains(keyword))
                        {
                            userList.Add(user);
                        }
                    }
                    Ping(adminID);
                }
                return userList;
            }
        }

        /// <summary>
        /// Denna metoden uppdaterar värden hos en bok med hjälp av parametrar.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateBook(int adminID, int bookID, string title, string author, int price)
        {
            using (var db = new DatabaseContext())
            {
                bool bookUpdate = false;
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);
                var book = db.Books.FirstOrDefault(b => b.ID == bookID);

                if (book != null && user != null && user.IsAdmin == true && user.SessionTimer > DateTime.Now)
                {
                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    bookUpdate = true;
                    Ping(adminID);
                    db.SaveChanges();
                }
                return bookUpdate;
            }
        }

        /// <summary>
        /// Denna metod tar bort en bok ifrån databasen.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public bool DeleteBook(int adminID, int bookID)
        {
            using (var db = new DatabaseContext())
            {
                bool bookDelete = false;
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);
                var book = db.Books.FirstOrDefault(b => b.ID == bookID);

                if (book != null && user != null && user.IsAdmin == true && user.SessionTimer > DateTime.Now)
                {
                    bookDelete = true;
                    db.Books.Remove(book);
                    Ping(adminID);
                    db.SaveChanges();
                }
                return bookDelete;
            }
        }

        /// <summary>
        /// Denna metod lägger till en kategori.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool AddCategory(int adminID, string category)
        {
            using (var db = new DatabaseContext())
            {
                bool categoryAdd = false;
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);
                var book = db.BookCategory.FirstOrDefault(b => b.Name == category);

                if (book == null && user != null && user.IsAdmin == true && user.SessionTimer > DateTime.Now)
                {
                    db.BookCategory.Add(new BookCategory
                    {
                        Name = category
                    });
                    categoryAdd = true;
                    Ping(adminID);
                    db.SaveChanges();
                }
                return categoryAdd;
            }
        }

        /// <summary>
        /// Denna metod lägger till en bok till en kategori.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool AddBookToCategory(int adminID, int bookID, string category)
        {
            using (var db = new DatabaseContext())
            {
                bool bookAdd = false;
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);
                var book = db.Books.FirstOrDefault(b => b.ID == bookID);
                var bookCategory = db.BookCategory.FirstOrDefault(b => b.Name == category);

                if (book != null && user != null && bookCategory != null && user.IsAdmin == true && user.SessionTimer > DateTime.Now)
                {
                    book.CategoryID = bookCategory.ID;
                    bookAdd = true;
                    Ping(adminID);
                    db.SaveChanges();
                }
                return bookAdd;
            }
        }

        /// <summary>
        /// Denna metod tar bort en kategori.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public bool DeleteCategory(int adminID, int categoryID)
        {
            using (var db = new DatabaseContext())
            {
                bool categoryDelete = false;
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);
                var category = db.BookCategory.FirstOrDefault(b => b.ID == categoryID);

                if (category != null && user != null && user.IsAdmin && user.SessionTimer > DateTime.Now)
                {
                    db.BookCategory.Remove(category);
                    categoryDelete = true;
                    Ping(adminID);
                    db.SaveChanges();
                }
                return categoryDelete;
            }
        }

        /// <summary>
        /// Denna metod lägger till en användare. Om användaren matar in ett tomt värde så sätts ett defaultlösenord.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AddUser(int adminID, string username, string password)
        {
            using (var db = new DatabaseContext())
            {
                bool addUser = false;
                var admin = db.Users.FirstOrDefault(u => u.ID == adminID);
                var user = db.Users.FirstOrDefault(u => u.Name == username);

                if (user == null && admin != null && String.IsNullOrEmpty(password) == false && admin.IsAdmin && admin.SessionTimer > DateTime.Now)
                {
                    db.Users.Add(new User
                    {
                        Name = username,
                        Password = password
                    });
                    addUser = true;
                    Ping(adminID);
                    db.SaveChanges();
                }

                // Om lösenordet är tomt så sätts ett defaultlösenordet som är "CodicRulez", notera String.IsNullOrEmpty(password) i if satsen.
                else if (user == null && admin != null && String.IsNullOrEmpty(password) == true && admin.IsAdmin && admin.SessionTimer > DateTime.Now)
                {
                    db.Users.Add(new User
                    {
                        Name = username
                    });
                    addUser = true;
                    Ping(adminID);
                    db.SaveChanges();
                }
                return addUser;
            }
        }

        /// <summary>
        /// Denna metod returnerar en lista på alla böcker som har sålts.
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public List<SoldBooks> SoldItems(int adminID)
        {
            using (var db = new DatabaseContext())
            {
                List<SoldBooks> soldBooks = new List<SoldBooks>();
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);

                if (user != null && user.IsAdmin && user.SessionTimer > DateTime.Now)
                {
                    foreach (var book in db.SoldBooks)
                    {
                        soldBooks.Add(book);
                    }
                    Ping(adminID);
                }
                return soldBooks;
            }
        }

        /// <summary>
        /// Denna metod returnerar summan av alla pengar som bokaffären har tjänat.
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public int MoneyEarned(int adminID)
        {
            using (var db = new DatabaseContext())
            {
                int sum = 0;
                List<SoldBooks> soldBooks = new List<SoldBooks>();
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);

                if (user != null && user.IsAdmin && user.SessionTimer > DateTime.Now)
                {
                    foreach (var book in db.SoldBooks)
                    {
                        sum += book.Price;
                    }
                    Ping(adminID);
                }
                return sum;
            }
        }

        /// <summary>
        /// Denna metoden returnerar användaren som har handlat flest böcker.
        /// Kod inspirerad av https://stackoverflow.com/a/355977 vid rad 660.
        /// </summary>
        /// <param name="adminID"></param>
        public User BestCustomer(int adminID)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.ID == adminID);
                List<int> customerList = new List<int>();

                if (user != null && user.IsAdmin && user.SessionTimer > DateTime.Now)
                {
                    foreach (var book in db.SoldBooks)
                    {
                        customerList.Add(book.UserID);
                    }
                    Ping(adminID);
                }
                var bestCustomerID = customerList.GroupBy(c => c).OrderByDescending(c => c.Count()).Select(c => c.Key).First();
                var bestCustomer = db.Users.FirstOrDefault(u => u.ID == bestCustomerID);
                return bestCustomer;
            }
        }

        /// <summary>
        /// Denna metoden uppgraderar en användare till adminstatus.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Promote(int adminID, int userID)
        {
            using (var db = new DatabaseContext())
            {
                bool promote = false;
                var admin = db.Users.FirstOrDefault(u => u.ID == adminID);
                var user = db.Users.FirstOrDefault(u => u.ID == userID);

                if (user != null && admin != null && admin.IsAdmin && admin.SessionTimer > DateTime.Now)
                {
                    user.IsAdmin = true;
                    promote = true;
                    Ping(adminID);
                    db.SaveChanges();
                }
                return promote;
            }
        }

        /// <summary>
        /// Denna metoden demotar en användare till vanlig user status.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Demote(int adminID, int userID)
        {
            using (var db = new DatabaseContext())
            {
                bool demote = false;
                var admin = db.Users.FirstOrDefault(u => u.ID == adminID);
                var user = db.Users.FirstOrDefault(u => u.ID == userID);

                if (user != null && admin != null && admin.IsAdmin && admin.SessionTimer > DateTime.Now)
                {
                    user.IsAdmin = false;
                    demote = true;
                    Ping(adminID);
                    db.SaveChanges();
                }
                return demote;
            }
        }

        /// <summary>
        /// Denna metoden aktiverar en användares konto.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ActivateUser(int adminID, int userID)
        {
            using (var db = new DatabaseContext())
            {
                bool activate = false;
                var admin = db.Users.FirstOrDefault(u => u.ID == adminID);
                var user = db.Users.FirstOrDefault(u => u.ID == userID);

                if (user != null && admin != null && admin.IsAdmin && admin.SessionTimer > DateTime.Now)
                {
                    user.IsActive = true;
                    activate = true;
                    Ping(adminID);
                    db.SaveChanges();
                }
                return activate;
            }
        }

        /// <summary>
        /// Denna metoden inaktiverar en användares konto. Om en användares konto är inaktiverat så fungerar inte Login() metoden.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool InactivateUser(int adminID, int userID)
        {
            using (var db = new DatabaseContext())
            {
                bool inactivate = false;
                var admin = db.Users.FirstOrDefault(u => u.ID == adminID);
                var user = db.Users.FirstOrDefault(u => u.ID == userID);

                if (user != null && admin != null && admin.IsAdmin && admin.SessionTimer > DateTime.Now)
                {
                    user.IsActive = false;
                    inactivate = true;
                    Ping(adminID);
                    db.SaveChanges();
                }
                return inactivate;
            }
        }
    }
}