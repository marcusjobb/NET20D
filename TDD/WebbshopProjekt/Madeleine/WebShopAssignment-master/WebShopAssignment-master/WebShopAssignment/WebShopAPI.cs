using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShopAssignment.Database;
using WebShopAssignment.Helpers;
using WebShopAssignment.Models;


namespace WebShopAssignment
{
    public class WebShopAPI
    {
        private static MyDatabase db = new MyDatabase();
        /// <summary>
        /// Loggar in användaren
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string userName, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == userName && u.Password == password && u.IsActive);

            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                db.SaveChanges();
                return user.Id;
            }

            return 0;
        }
        /// <summary>
        /// Loggar ut användaren och sätter timern till 0
        /// </summary>
        /// <param name="id"></param>
        public void Logout(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id && u.SessionTimer > DateTime.Now.AddMinutes(-15));

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Visar alla kategorier i databasen
        /// </summary>
        /// <returns></returns>
        public List<BookCategory> GetCategories()
        {
            return db.BookCategories.ToList();
        }
        /// <summary>
        /// Visar alla kategorier som innehåller keywordet
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            var search = db.BookCategories.Where(c => c.Name.Contains(keyword));
            return search.ToList();


        }
        /// <summary>
        /// Visar böckerna i en viss kategori, baserat på input
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Book> GetCategory(int id)
        {
            var cat = db.Books.Where(c => c.CategoryId == id);
            return cat.ToList();
        }
        /// <summary>
        /// Visar alla böcker som finns i lager, alla som har antal större än 0
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAvailableBooks()
        {
            var available = db.Books.Where(c => c.Amount > 0);
            return available.ToList();
        }
        /// <summary>
        /// ÄNDRING 1/4. Ändrade från List<Book> till Book
        /// Skriver ut informationen om en specifik bok.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public Book GetBook(int bookId)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            return book;
        }
        /// <summary>
        /// Visar alla böcker som har inputvärdet i titeln
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Book> GetBooks(string keyword)
        {
            var books = db.Books.Where(b => b.Title.Contains(keyword));
            return books.ToList();
        }
        /// <summary>
        /// Visar alla böcker som har en författare som matchar input
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Book> GetAuthors(string keyword)
        {
            var author = db.Books.Where(a => a.Author.Contains(keyword));
            return author.ToList();
        }
        /// <summary>
        /// Kollar om user är inloggad, kopierar infon för en köpt bok till SoldBookstabellen.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool BuyBook(int userId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId && u.SessionTimer > DateTime.Now.AddMinutes(-15));

            if (user == null)
            {
                return false;
            }

            using (var db = new MyDatabase())
            {
                var org = db.Books.Find(bookId);
                var copy = new SoldBook
                {
                    Title = org.Title,
                    Author = org.Author,
                    CategoryId = org.CategoryId,
                    Price = org.Price,
                    PurchaseDate = DateTime.Now,
                    UserId = userId,
                };
                db.SoldBooks.Add(copy);
                org.Amount -= 1;
                db.SaveChanges();
                return true;
            }

        }
        /// <summary>
        /// Kolla om användaren är aktiv
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string Ping(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            if (user == null)
            {
                return string.Empty;
            }

            return "pong";
        }

        /// <summary>
        /// Registrera en ny användare
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="verifyPassword"></param>
        /// <returns></returns>
        public bool Register(string name, string password, string verifyPassword)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
            if (user != null)
            {
                return false;
            }
            if (password == verifyPassword)
            {
                db.Users.Add(new Models.User { Name = name, Password = password });
                db.SaveChanges();
            }
            return true;
        }
        /// <summary>
        /// Kollar om användaren är admin, lägger sedan till en bok i databasen.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);

            if (UserHelper.IsUserAdmin(user) == false)
            {
                return false;
            }

            db.Books.Add(new Book { Title = title, Author = author, Price = price, Amount = amount });
            db.SaveChanges();
            return true;

        }
        /// <summary>
        /// Kollar om admin och sätter sedan ett nytt antal böcker i lager på en specifik bok
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        public void SetAmount(int adminId, int bookId, int amount)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == true)
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                book.Amount = amount;
                db.Books.Update(book);
                db.SaveChanges();
                Console.WriteLine("Uppdaterad");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        /// <summary>
        /// Kollar om admin och skriver sedan ut en lista på användarnas namn
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public List<User> ListUser(int adminId)
        {

            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == true)
            {
                return db.Users.ToList();
            }
            return null;
        }

        /// <summary>
        /// kollar om admin och returnerar en lista med användare som matchar input
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == true)
            {
                var foundUser = db.Users.Where(u => u.Name.Contains(keyword));
                return foundUser.ToList();
            }
            return null;
        }
        /// <summary>
        /// Kollar om admin, uppdaterar sedan bokens uppgifter
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateBook(int adminId, int id, string title, string author, int price)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == false)
            {
                return false;
            }

            var book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return false;
            }

            book.Title = title;
            book.Author = author;
            book.Price = price;

            db.Books.Update(book);
            db.SaveChanges();
            return true;

        }
        /// <summary>
        /// Kollar om admin, minskar antal böcker i lager. Om lager är 0 tas boken bort.ÄNDRING 31/3!! Hade glömt SaveChanges();
        /// och att returnera false vid antal > 0
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="newAmount"></param>
        /// <returns></returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == false)
            {
                return false;
            }

            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                return false;
            }

            if (book.Amount <= 0)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Kollar admin, lägger sedan till en kategori om denna inte redan finns.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddCategory(int adminId, string name)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == false)
            {
                return false;
            }

            var category = db.BookCategories.FirstOrDefault(c => c.Name == name);
            if (category != null)
            {
                return false;
            }

            db.BookCategories.Add(new BookCategory { Name = name });
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Kollar admin, lägger till en kategori på en specifik bok.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == false)
            {
                return false;
            }

            var book = db.Books.FirstOrDefault(b => b.Id == bookId);

            book.CategoryId = categoryId;
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Kolla om admin, uppdatera sedan namnet på en specifik kategori
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == false)
            {
                return false;
            }
            var cat = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);

            if (cat == null)
            {
                return false;
            }

            cat.Name = name;
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// kollar om admin, tar bort kategorin om den inte har några böcker kopplade
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == false)
            {
                return false;
            }

            var cat = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);

            if (cat == null)
            {
                return false;
            }

            var book = db.Books.Where(b => b.CategoryId == cat.Id);
            if (book.Count() > 0)
            {
                return false;
            }

            db.BookCategories.Remove(cat);
            db.SaveChanges();

            return true;
        }
        /// <summary>
        /// Kollar om admin, lägger sedan till en användare om denna inte redan finns
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AddUser(int adminId, string name, string password)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == false)
            {
                return false;
            }

            var newUser = db.Users.FirstOrDefault(u => u.Name == name);

            if (newUser != null)
            {
                return false;
            }

            db.Users.Add(new User { Name = name, Password = password });
            db.SaveChanges();

            return true;
        }
        /// <summary>
        /// NY METOD I INLÄMNING 3!!! Skriver ut en lista på alla böcker i databasen
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }
        /// <summary>
        /// NY METOD I INLÄMNING 3!!! Skriver ut alla böcker som inte finns i lager
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public List<Book> BooksWithoutAmount(int adminId)
        {
            var user = db.Users.FirstOrDefault(a => a.Id == adminId);
            if (UserHelper.IsUserAdmin(user) == false)
            {
                return null;
            }
            var notAvailable = db.Books.Where(n => n.Amount <= 0);
            return notAvailable.ToList();
        }
    }
}
