using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Xml.Xsl;
using Inlamn2WebbShop_MLarsson.Controllers;
using Inlamn2WebbShop_MLarsson.Database;
using Inlamn2WebbShop_MLarsson.Models;
using Inlamn2WebbShop_MLarsson.Views;
using Microsoft.EntityFrameworkCore;

namespace Inlamn2WebbShop_MLarsson
{
    public static class WebbShopAPI
    {
        /// <summary>
        /// Öpnnar en koppling till databasen, för att kunna använda i hela klassen.
        /// </summary>
        private static WebbShopContext db = new WebbShopContext();

        /// <summary>
        /// Lägg till ny bok.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns>true om boken redan finns eller lades till korrekt, annars false.</returns>
        public static bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            try
            {
                var book = db.Books.FirstOrDefault(b => b.Title == title);
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    if (book != null)
                    {
                        SetAmount(adminId, book.Id, amount);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        db.Books.Add(new Book() { Title = title, Author = author, Price = price, Amount = amount });
                        db.SaveChanges();
                        if (Helper.DoesBookExist(db.Books.FirstOrDefault(b => b.Title == title)))
                        {
                            return View.AddBook(title);
                        }
                        else
                        {
                            return View.SomethingWentWrong();
                        }
                    }
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }

        /// <summary>
        /// tittar om användare är admin, lägger till bok i kategori,
        /// eller skapar kategori och sedan lägger till.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryName"></param>
        /// <returns>true om bok är tillagd i kategori, annars false</returns>
        public static bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var book = (from b in db.Books
                                where b.Id == bookId
                                select b).FirstOrDefault();
                    var cat = (from c in db.Categories.Include(b => b.Books)
                               where c.Id == categoryId
                               select c).FirstOrDefault();

                    if (cat == null || book == null)
                    {
                        return View.SomethingWentWrong();
                    }
                    cat.Books.Add(book);
                    db.Update(cat);
                    db.SaveChanges();
                    return View.AddBookToCategory(cat);
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Tittar om användare är admin, lägger till ny kategori om den inte redan finns.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns>true om kategori är tillagd, annars false</returns>
        public static bool AddCategory(int adminId, string name)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    //Testar på LINQ-Query istället för lambda...
                    var cat = (from c in db.Categories
                               where c.Name == name
                               select c).FirstOrDefault();
                    if (cat == null)
                    {
                        db.Categories.Add(new Category() { Name = name });
                        db.SaveChanges();
                        cat = (from c in db.Categories
                               where c.Name == name
                               select c).FirstOrDefault();
                        if (Helper.DoesCategoryExist((from c in db.Categories
                                                      where c.Name == name
                                                      select c).FirstOrDefault()))
                        {
                            return View.AddCategory(name);
                        }
                        return View.SomethingWentWrong();
                    }
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }
        /// <summary>
        /// Tittar om användare är admin, lägger till användare
        /// om lösenord inte saknas eller användarnamn inte är upptaget.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>true om ny användare är tillagd, annars false</returns>
        public static bool AddUser(int adminId, string name, string password = "Codic2021")
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    if (Helper.DoesUserExist(db.Users.FirstOrDefault(u => u.Name == name.Trim())))
                    {
                        return View.AddUser("user", name, password);
                    }
                    else
                    {
                        db.Users.Add(new User() { Name = name.Trim(), Password = password, SoldBooks = new List<SoldBook>() });
                        db.SaveChanges();
                        if (Helper.DoesUserExist(db.Users.FirstOrDefault(u => u.Name == name.Trim())))
                        {
                            return View.AddUser("add", name, password);
                        }
                        return View.SomethingWentWrong();
                    }
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }
        /// <summary>
        /// Metod för att köpa en bok. Kollar om användaren är inloggad och att boken finns.
        /// Kopierar boken till tabellen SoldBooks och skapar koppling mellan den och användaren.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static User BuyBook(int userId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            var book = db.Books.Include(c => c.Categories).FirstOrDefault(b => b.Id == bookId);

            try
            {
                if (user != null && user.SessionTimer! > DateTime.Now.AddMinutes(-10)
                    && book?.Amount > 0)
                {
                    user.SessionTimer = DateTime.Now;
                    book.Amount--;
                    if (book.Amount < 1)
                    {
                        book.Amount = 0;
                    }
                    var soldBook = new SoldBook()
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Price = book.Price,
                        PurchasedDate = DateTime.Now,
                        Categories = new List<Category>(),
                        Users = new List<User>()
                    };
                    soldBook.Users.Add(user);

                    foreach (var cat in book.Categories)
                    {
                        soldBook.Categories.Add(cat);
                    }
                    db.SoldBooks.Add(soldBook);
                    db.Update(user);
                    db.SaveChanges();
                    View.BuyBook(soldBook.Title);
                    return user;
                }
                else
                {
                    View.SomethingWentWrong();
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///  Tittar om användare är admin, tar bort bok om den finns.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns>true om boken är borttagen, annars false.</returns>
        public static bool DeleteBook(int adminId, int bookId)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        while (book.Amount > 0)
                        {
                            book.Amount--;
                        }
                        db.Books.Remove(book);
                        db.SaveChanges();

                        if (!Helper.DoesBookExist(db.Books.FirstOrDefault(b => b.Id == bookId)))
                        {
                            return View.DeleteBook(book.Title);
                        }
                    }
                    return View.SomethingWentWrong();
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }

        /// <summary>
        ///  Tittar om användare är admin, tar bort kategori om den finns.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns>true om kategorin är borttagen, annars false.</returns>
        public static bool DeleteCategory(int adminId, int categoryId)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var cat = db.Categories.Include(b => b.Books).FirstOrDefault(c => c.Id == categoryId);

                    if (cat?.Books.Count() <= 0)
                    {
                        db.Categories.Remove(cat);
                        db.SaveChanges();
                        if (!Helper.DoesCategoryExist(db.Categories.FirstOrDefault(c => c.Id == categoryId)))
                        {
                            Console.WriteLine($"You have deleted category {cat.Name}");
                            return true;
                        }
                    }
                    return View.SomethingWentWrong();
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Tittar om användare är admin,
        /// och listar alla användare som har keyword in sitt namn.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>Lista på användare</returns>
        public static List<User> FindUser(int adminId, string keyword)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    return db.Users.Include(s => s.SoldBooks).Where(u => u.Name.Contains(keyword)).OrderBy(o => o.Name).ToList();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hämtar böcker där författarens namn innenhåller
        /// valt nyckelord.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>Lista på böcker</returns>
        public static List<Book> GetAuthors(string keyword)
        {
            try
            {
                return db.Books.Include(c => c.Categories).Where(b => b.Author.Contains(keyword)).OrderBy(a => a.Author).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hämtar böcker in en viss kategori baserad på kategori-id,
        /// och antal böcker fler än 0.
        /// </summary>
        /// <param name="categoryId"></param>
        public static List<Book> GetAvailableBooks(int categoryId)
        {
            try
            {
                List<Book> books = new List<Book>();
                foreach (var cat in db.Categories.Include(b => b.Books).Where(c => c.Id == categoryId))
                {
                    if (cat != null)
                    {
                        foreach (var book in cat.Books.Where(b => b.Amount > 0))
                        {
                            books.Add(book);
                        }
                    }
                }
                return books;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Hämtar en bok baserad på bok-id.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>ett Book object. </returns>
        public static Book GetBook(int bookId)
        {
            try
            {
                return db.Books.Include(c => c.Categories).FirstOrDefault(b => b.Id == bookId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hämtar alla böcker som hinnehåller valt nyckelord.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>En lista med böcker.</returns>
        public static List<Book> GetBooks(string keyword)
        {
            try
            {
                return db.Books.Include(c => c.Categories).Where(b => b.Title.Contains(keyword)).OrderBy(o => o.Title).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hämtar kategorier som innehåller valt nyckelord.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>En lista med kategorier</returns>
        public static List<Category> GetCategories(string keyword)
        {
            try
            {
                return db.Categories.Where(c => c.Name.Contains(keyword)).OrderBy(c => c.Name).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hämtar alla kategorier.
        /// </summary>
        /// <returns>En lista med kategorier</returns>
        public static List<Category> GetCategories()
        {
            try
            {
                return db.Categories.OrderBy(c => c.Name).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hämtar böcker i en kategori
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Lista på böcker i en kategori</returns>
        public static List<Book> GetCategory(int categoryId)
        {
            List<Book> bookList = new List<Book>();
            var catList = db.Categories.Include(b => b.Books).FirstOrDefault(c => c.Id == categoryId);
            try
            {
                if (catList != null)
                {
                    foreach (var book in catList.Books)
                    {
                        bookList.Add(book);
                    }
                    return bookList;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Tittar om användare är admin,
        /// och listar alla användare som finns.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>Lista på användare</returns>
        public static List<User> ListUsers(int adminId)
        {
            try
            {
                var userList = new List<User>();
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    return db.Users.OrderBy(u => u.Name).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// Metod som kollar om en användare och lösenord finns. Loggar in genom att starta två DateTime varav den ena stängs av vid utlogg.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Användar-id. 0 om ingen användare finns.</returns>
        public static User LogInUser(string userName, string password)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.Name == userName.Trim() && u.Password == password && u.IsActive == true);
                if (user != null)
                {
                    user.LastLogin = DateTime.Now;
                    user.SessionTimer = DateTime.Now;
                    db.Users.Update(user);
                    db.SaveChanges();
                    View.LogInLogOut("login");
                    return user;
                }
                View.SomethingWentWrong();
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Metod för att logga ut användare. Stoppar en DateTime för att se hur länge användaren varit aktiv.
        /// </summary>
        /// <param name="id"></param>
        public static void LogOutUser(int id)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id && u.SessionTimer > DateTime.Now.AddMinutes(-10));
                if (user != null)
                {
                    user.SessionTimer = DateTime.MinValue;
                    db.Users.Update(user);
                    db.SaveChanges();
                    View.LogInLogOut("logout");
                }
            }
            catch (Exception)
            {
                View.SomethingWentWrong();
            }
        }
        /// <summary>
        /// KOllar om användaren är inloggad, baserad på SessionTimer.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>"Pong" om användaren är inloggad, annars string.Empty/returns>
        public static string Ping(int userId)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null && user.SessionTimer! > DateTime.Now.AddMinutes(-10))
                {
                    return "Pong";
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                View.SomethingWentWrong();
                return string.Empty;
            }
        }

        /// <summary>
        /// Skapa ny användare.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns>True om användaren är skapad, annars false.</returns>
        public static bool Register(string name, string password, string passwordVerify)
        {
            Console.WriteLine();
            try
            {
                if (password != passwordVerify && password.Length > 3)
                {
                    return View.Register("password");
                }

                if (Helper.DoesUserExist(db.Users.FirstOrDefault(u => u.Name == name.Trim())))
                {
                    return View.Register("name");
                }
                else
                {
                    db.Users.Add(new User() { Name = name.Trim(), Password = password, IsActive = true, IsAdmin = false, SoldBooks = new List<SoldBook>() });
                    db.SaveChanges();
                    if (Helper.DoesUserExist(db.Users.FirstOrDefault(u => u.Name == name.Trim())))
                    {
                        return View.Register("new");
                    }
                    return View.SomethingWentWrong();
                }
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }
        /// <summary>
        /// Tittar om användare är admin, och lägger till antal böcker till bok.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        public static void SetAmount(int adminId, int bookId, int amount)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    if (book != null)
                    {
                        book.Amount += amount;
                        View.SetAmount(amount);
                        db.SaveChanges();
                    }
                    else
                    {
                        View.SetAmount(amount = 0);
                    }
                }
            }
            catch (Exception)
            {
                View.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Tittar om användare är admin, updaterar bok med ifylld info.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns>true om boken är uppdaterad, annars false</returns>
        public static bool UpdateBook(int adminId, int bookId, string title = "", string author = "", int price = 0)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        if (title != "") book.Title = title;
                        if (author != "") book.Author = author;
                        if (price != 0) book.Price = price;
                        db.Update(book);
                        db.SaveChanges();
                        Console.WriteLine("You have updated a book.");
                        return true;
                    }
                    else
                    {
                        return View.SomethingWentWrong();
                    }
                }
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
            return View.SomethingWentWrong();
        }
        /// <summary>
        /// Kollar om användare är admin, byter namn på kategori om id finns.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="newName"></param>
        /// <returns>true om namnet är ändrat, annars false.</returns>
        public static bool UpdateCategory(int adminId, int categoryId, string newName)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var cat = db.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (cat != null)
                    {
                        cat.Name = newName;
                        db.Update(cat);
                        db.SaveChanges();
                        if (Helper.DoesCategoryExist(db.Categories.FirstOrDefault(c => c.Name == newName && c.Id == categoryId)))
                        {
                            Console.WriteLine("You have updated a category.");
                            return true;
                        }
                    }
                    return View.SomethingWentWrong();
                }
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
            return View.SomethingWentWrong();
        }
    }
}
