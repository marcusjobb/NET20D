using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI
{
    public static class WebbShopApi
    {
        private static EFContext db = new EFContext();
        private static List<Book> booklist;

        public static void Seed()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Kopierar bok till SoldBooks med användaren samt tar bort bok från Book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>

        public static bool AddBook(int userId, string title, string author, int price, int quantity)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            var book = db.Books.FirstOrDefault(b => b.Title == title);
            if (user.IsAdmin)
            {
                if (book == null)
                {
                    db.Books.Add(new Book()
                    {
                        Title = title,
                        Author = author,
                        Price = price,
                        Quantity = quantity
                    });
                }
                else
                {
                    SetQuantity(userId, book.Id, quantity);
                }
            }
            else
            {
                return false;
            }
            user.SessionTimer = DateTime.Now;
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// return true om user är admin
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool AccesFrontEnd(int userId)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    if (user.IsAdmin)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddBookToCategory(int adminId, int bookId, int genreId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                var genre = db.Genres.Include(b => b.Books).FirstOrDefault(g => g.GenreId == genreId);
                if (book != null && genre != null)
                {
                    genre.Books.Add(book);
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

        public static bool AddCategory(int adminId, string genreName)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                var genre = db.Genres.FirstOrDefault(h => h.Genre == genreName);
                if (genre == null)
                {
                    db.Genres.Add(new BookGenre() { Genre = genreName });
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

        public static bool AddUser(int adminId, string name, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                var newUser = db.Users.FirstOrDefault(u => u.Name == name);
                if (newUser != null)
                {
                    return false;
                }
                else
                {
                    db.Users.Add(new User() { Name = name, Password = password, IsAdmin = false, IsActive = true, SoldBooks = new List<SoldBook>() });
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public static bool BuyBook(int userId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            var book = db.Books.Include(c => c.Genres).FirstOrDefault(b => b.Id == bookId);

            if (user != null && user.SessionTimer > DateTime.Now.AddMinutes(-15)
                && book != null && book.Quantity > 0)
            {
                user.SessionTimer = DateTime.Now;
                book.Quantity--;
                if (book.Quantity < 0)
                    book.Quantity = 0;

                var soldBook = new SoldBook()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Price = book.Price,
                    PurchasedDate = DateTime.Now,
                    Genres = book.Genres
                };
                soldBook.Users = new List<User>();
                soldBook.Genres = new List<BookGenre>();
                soldBook.Users.Add(user);

                foreach (var cat in book.Genres)
                {
                    soldBook.Genres.Add(cat);
                }
                db.SoldBooks.Add(soldBook);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// subtraherar en från book.Quantity tar bort hela boken om saldot är noll
        /// returnerar true eller false
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static bool DeleteBook(int adminId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            if (user.IsAdmin)
            {
                if (book != null)
                {
                    book.Quantity--;
                    if (book.Quantity <= 0)
                    {
                        db.Books.Remove(book);
                    }
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

        public static bool DeleteCategory(int adminId, int genreId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                var genre = db.Genres.Include(b => b.Books).FirstOrDefault(g => g.GenreId == genreId);
                if (genre != null && genre.Books.Count == 0)
                {
                    db.Genres.Remove(genre);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Skickar en Lista på första användaren som matchar keyword
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<User> FindUsers(int adminId, string keyword)
        {
            var isAdmin = db.Users
                        .Where(u => u.Id == adminId)
                        .FirstOrDefault();
            if (isAdmin.IsAdmin)
            {
                try
                {
                    var user = db.Users
                           .Where(u => u.Name.Contains(keyword))
                           .ToList();
                    return user;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// returnerar lista med böcker
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<Book> GetAuthors(string keyword)
        {
            try
            {
                return db.Books.Include(c => c.Genres).Where(b => b.Author.Contains(keyword)).OrderBy(a => a.Author).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Book> GetAvailableBooks(int genreId)
        {
            try
            {
                List<Book> bookList = new List<Book>();
                foreach (var genre in db.Genres.Include(b => b.Books).Where(c => c.GenreId == genreId))
                {
                    foreach (var book in genre.Books.Where(b => b.Quantity > 0))
                    {
                        bookList.Add(book);
                    }
                }
                return bookList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returnerar Boken som stämmer överens med Id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static Book GetBook(int bookId)
        {
            try
            {
                return db.Books.SingleOrDefault(g => g.Id == bookId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Book> GetBooks(string categoryName)
        {
            List<Book> books = new List<Book>();

            categoryName = categoryName.ToLower();
            BookGenre bookGenre = db.Genres.Include(c => c.Books).SingleOrDefault(g => g.Genre.ToLower().Contains(categoryName));
            var genre = bookGenre;

            if (genre != null)
            {
                books = genre.Books.ToList();
            }
            return books;
        }

        public static string GetBookTitle(int bookId)
        {
            var book = GetBook(bookId);

            if (book != null)
                return book.Title;
            else
                return null;
            //"[NOT FOUND]";
        }

        /// <summary>
        /// Skriver ut alla Genres/Categories
        /// </summary>
        public static List<BookGenre> GetCategories()
        {
            var genres = from g in db.Genres
                         select g;

            return genres.ToList();
        }

        /// <summary>
        /// Skriver ut alla Genres/Categories som matchar string keyword
        /// </summary>
        public static List<BookGenre> GetCategories(string keyword)
        {
            var genres = from g in db.Genres
                         where g.Genre.Contains(keyword) //= keyword
                         select g;
            if (genres != null)
            {
                return genres.ToList();
            }
            else
            {
                return null;
            }
        }

        public static List<Book> GetCategory(int genreId)
        {
            List<Book> bookList = new List<Book>();
            var genreList = db.Genres.Include(b => b.Books).FirstOrDefault(c => c.GenreId == genreId);
            foreach (var book in genreList.Books)
            {
                bookList.Add(book);
            }

            return bookList;
        }

        public static List<User> ListUsers(int adminId)
        {
            var users = from u in db.Users select u;
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                List<User> userList = users.ToList();
                return userList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Loggar in användare
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive == true);
            if (user != null)
            {
                user.LastLogIn = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return user.Id;
            }
            else
            {
                Console.WriteLine("[Login Failed]");
                return default;
            }
        }

        /// <summary>
        /// Loggar ut användaren
        /// </summary>
        /// <param name="userId"></param>
        public static void LogOut(int userId)
        {
            var user = db.Users.FirstOrDefault(ui => ui.Id == userId);
            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.Update(user);
                db.SaveChanges();
                Console.WriteLine(user.Name + "Loging Out");
            }
            else
            {
                Console.WriteLine("Logout Failed");
            }
        }

        /// <summary>
        /// skickar string "Pong" om användaren finns, string empty annars
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string Ping(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null && user.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                user.SessionTimer = DateTime.Now;
                return "Pong";
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/19463453/check-if-username-already-exists-in-database-using-linq
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        public static bool Register(string name, string password, string passwordVerify)
        {
            var result = (from row in db.Users
                          where row.Name == name
                          select row).ToList();
            if (result.Count() > 0)
            {
                // Console.WriteLine("ANVÄNDARNAMN UPPTAGET");
                return false;
            }
            else if (password == passwordVerify)
            {
                db.Users.Add(new User() { Name = name, Password = password, IsAdmin = false, IsActive = true, SoldBooks = new List<SoldBook>() });
                db.SaveChanges();
                return true;
            }
            else
            {
                //Console.WriteLine("Your password dosn't match");
                return false;
            }
        }

        /// <summary>
        /// lägger till antal böcker
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <param name="quantity"></param>
        public static void SetQuantity(int userId, int bookId, int quantity)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            if (user.IsAdmin)
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                book.Quantity += quantity;
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("[Admin status requierd]");
            }
        }

        public static bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            if (user.IsAdmin)
            {
                book.Title = title;
                book.Author = author;
                book.Price = price;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateGenre(int adminId, int genreId, string updatedName)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                var genre = db.Genres.FirstOrDefault(u => u.GenreId == genreId);
                if (genre != null)
                {
                    genre.Genre = updatedName;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}