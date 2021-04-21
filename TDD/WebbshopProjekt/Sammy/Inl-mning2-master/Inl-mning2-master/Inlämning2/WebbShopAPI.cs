using Inlämning2.Database;
using Inlämning2.Models;
using Inlämning2.Utils;
using Inlämning2.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning2
{
    public class WebbShopAPI
    {
        private WSContext context = new WSContext();

        /// <summary>
        /// Admin lägger in en bok.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns>True om det lyckas, annars false.</returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            try
            {
                var book = context.Books.FirstOrDefault(b => b.Title == title);
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    if (book != null)
                    {
                        SetAmount(adminId, book.BookId, amount);
                        context.SaveChanges();
                        Console.WriteLine($"Boken {book.Title} har lagt in i shoppen med antal {amount}");
                        return true;
                    }
                    else
                    {
                        context.Books.Add(new Book() 
                        { Title = title, Author = author, Price = price, Amount = amount });
                        context.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    Error.NotAdmin();
                    return false;
                }
            }
            catch (Exception) 
            {
                Error.ErrorUnknown();
                return false; 
            }
        }

        // <summary>
        /// Admin lägger till en bok i kategoriet.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddBookToCategory(int adminId, int bookId, int catId)
        {
            try
            {
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                    var cat = context.Categories.Include(b => b.Books).FirstOrDefault(c => c.Id == catId);
                    if (cat == null || book == null)
                    {
                        Console.WriteLine("Hittade inte boken eller kategori.");
                    }
                    cat.Books.Add(book);
                    context.Update(cat);
                    context.SaveChanges();
                    Console.WriteLine("Boken är uppdaterad.");
                    return true;
                }
                else
                {
                    Error.NotAdmin();
                    return false;
                }
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return false;
            }
        }

        /// <summary>
        /// Admin lägger till en kategori.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns>True om det lyckas, annars false.</returns>
        public bool AddCategory(int adminId, string name)
        {
            try
            {
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    var cat = context.Categories.FirstOrDefault(c => c.Name == name);
                    if (cat == null)
                    {
                        context.Categories.Add(new Category() { Name = name });
                        context.SaveChanges();
                        Console.WriteLine($"Du har lagt till {name} i kategoriet.");
                        return true;
                    }
                    else
                    {
                        Error.ErrorUnknown();
                        return false;
                    }
                } 
                else
                {
                    Error.NotAdmin();
                    return false;
                }
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return false;
            }
        }

        /// <summary>
        /// Admin lägger in en användare.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AddUser(int adminId, string name, string password = "Codic2021")
        {
            try
            {
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    if (Check.ExistUser(context.Users.FirstOrDefault(u => u.Name == name)))
                    {
                        Console.WriteLine("Det finns redan en användare registerad.");
                        return false;
                    }
                    else
                    {
                        context.Users.Add(new User() 
                            { Name = name, Password = password, SoldBooks = new List<SoldBook>() });
                        context.SaveChanges();
                        Console.WriteLine("Du har lagt en ny användare.");
                        return true;
                    }
                }
                else
                {
                    Error.NotAdmin();
                    return false;
                }
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return false;
            }
        }

        /// <summary>
        /// Metod för att köpa en bok.Kolla om användaren är inloggad eller om den existerar.
        /// Kopiera bokdata till soldbooks, fyller på med datum och userId.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="book"></param>
        /// <returns>True om köpet är ok, annars false.</returns>
        public bool BuyBook(int userId, int bookId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            var book = context.Books.Include(c => c.Categories).FirstOrDefault(b => b.BookId == bookId);
           try
           {
               if (user != null && user.SessionTimer !> DateTime.Now.AddMinutes(-15) && book != null && book.Amount > 0)
               {
                    user.SessionTimer = DateTime.Now;
                    book.Amount--;
                    if(book.Amount < 1) { book.Amount = 0; }
                    var soldbook = new SoldBook()
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Price = book.Price,
                        PurchasedDate = DateTime.Now,
                        Categories = new List<Category>(),
                        Users = new List<User>()
                    };
                    soldbook.Users.Add(user);

                    foreach (var cat in book.Categories)
                    {
                        soldbook.Categories.Add(cat);
                    }
                    context.SoldBooks.Add(soldbook);
                    context.Update(user);
                    context.SaveChanges();
                    Console.WriteLine($"Köpet genomfört, du har köpt {soldbook.Title}");
                    return true;
               }
               else 
               {
                    Console.WriteLine("Nåt gick fel, köpet var inte genomfört!");
                    return false; 
               }
           }
           catch (Exception) 
           {
                Error.ErrorUnknown();
               return false; 
           }
        }

        /// <summary>
        /// Admin tar bort en bok.
        /// Om antalet blir 0, raderar boken.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns>True om det lyckas, annars false.</returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            try
            {
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                    if (book != null)
                    {
                        if (book.Amount > 0) 
                        { 
                            book.Amount--;
                            context.SaveChanges();
                            Console.WriteLine($"Du har minskar antalet av boken {book.Title} med 1.");
                            return true;
                        }
                        else 
                        { 
                            context.Books.Remove(book);
                            context.SaveChanges();
                            Console.WriteLine($"Du har tagit bort boken {book.Title}"); ;
                            return true;
                        }
                    }
                    else 
                    {
                        Console.WriteLine("Kan inte boken.");
                        return false; ;
                    }
                }
                else
                {
                    Error.NotAdmin();
                    return false;
                }
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return false;
            }
        }

        /// <summary>
        /// Admin listar alla användare som matchar sökordet.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>Lista på användare</returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            try
            {
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    return context.Users.Include(s => s.SoldBooks).Where(u => u.Name.Contains(keyword)).OrderBy(u => u.Name).ToList();
                }
                else
                {
                    Console.WriteLine("Hitta ingen som matchar.");
                    return null;
                }
            }
            catch (Exception) 
            {
                Error.ErrorUnknown();
                return null; 
            }
        }

        /// <summary>
        /// Ta bort en kategori.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="catId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int adminId, int catId)
        {
            try
            {
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    var cat = context.Categories.Include(b => b.Books).FirstOrDefault(c => c.Id == catId);
                    if (cat != null && cat.Books.Count() <= 0)
                    {
                        context.Categories.Remove(cat);
                        context.SaveChanges();
                        Console.WriteLine($"Kategorier {cat.Name} är borttagen.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Det finns böcker som är kopplad till kategoriet.");
                        return false;
                    }
                }
                else
                {
                    Error.NotAdmin();
                    return false;
                }
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return false;
            }
        }

        /// <summary>
        /// Lista alla böcker som har en viss författare.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>En lista av böcker.</returns>
        public List<Book> GetAuthor(string keyword)
        {
            try
            {
                return context.Books.Include(c => c.Categories).Where(b => b.Author.Contains(keyword)).OrderBy(b => b.Title).ToList();
            }
            catch (Exception) 
            {
                Error.ErrorUnknown();
                return null; 
            }
        }

        /// <summary>
        /// Lista alla böcker som har antal>0.
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public List<Book> GetAvaliableBooks(int catId)
        {
            try
            {
                List<Book> bookList = new List<Book>();
                foreach (var cat in context.Categories.Include(b => b.Books).Where(c => c.Id == catId))
                {
                    foreach(var book in cat.Books.Where(b => b.Amount > 0))
                    {
                        bookList.Add(book);
                    }
                }
                return bookList;
            }
            catch (Exception) 
            {
                Error.ErrorUnknown();
                return null; 
            }
        }

        /// <summary>
        /// Detailjer om en bok.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public Book GetBook(int bookId)
        {
            try
            {
                return context.Books.Include(c => c.Categories).FirstOrDefault(b => b.BookId == bookId);
            }
            catch (Exception) 
            {
                Error.ErrorUnknown();
                return null; 
            }
        }

        /// <summary>
        /// Lista alla böcker som matchar keyword som skickas in.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Book> GetBooks(string keyword)
        {
            try
            {
                return context.Books.Where(b => b.Title.Contains(keyword)).OrderBy(b => b.Title).ToList();
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return null;
            }
        }

        /// <summary>
        /// Metod för att lista samtliga kategorier.
        /// </summary>
        /// <returns>Lista av kategorier</returns>
        public List<Category> GetCategories()
        {
            try
            {
                return context.Categories.OrderBy(c => c.Name).ToList();
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return null;
            }
        }

        /// <summary>
        /// Lista alla kategorier som matchar sökordet.
        /// </summary>
        /// <param name = "keyword" ></ param >
        /// < returns >Lista av kategorier.</ returns >
        public List<Category> GetCategories(string keyword)
        {
            try
            {
                return context.Categories.Where(c => c.Name.Contains(keyword)).OrderBy(c => c.Name).ToList();
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return null;
            }
        }

        /// <summary>
        /// Lista alla böcker som finns i det kategoriet som söker..
        /// </summary>
        /// <param name="catId"></param>
        /// <returns>Lista av böcker.</returns>
        public List<Book> GetCategory(int catId)
        {
            try
            {
                List<Book> bookList = new List<Book>();
                var catList = context.Categories.Include(b => b.Books).FirstOrDefault(c => c.Id == catId);
                foreach(var book in catList.Books)
                {
                    bookList.Add(book);
                }
                return bookList;
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return null;
            }
        }

        /// <summary>
        /// Admin listar alla användare som är registerad.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>Lista på användare</returns>
        public List<User> ListUsers(int adminId)
        {
            try
            {
                var list = new List<User>();
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    return context.Users.OrderBy(u => u.Name).ToList();
                }
                else
                {
                    Error.NotAdmin();
                    return null;
                }
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return null;
            }
        }

        /// <summary>
        /// Logga in användare och sätta SessionTimer.
        /// Returnera en nolla om användare inte finns.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>AnvändareId, annars 0</returns>
        public int LogIn(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive);

            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
                return user.Id;
            }

            return 0;
        }

        /// <summary>
        /// Loggar ut användaren och nollställa SessionTimer.
        /// </summary>
        /// <param name="id"></param>
        public void LogOut(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id && u.SessionTimer > DateTime.Now.AddMinutes(-15));

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                context.Users.Update(user);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Pinga för att hålla anslutningen vid liv.
        /// Returnera "Pong" om användare är online,
        /// annars returnera en tom sträng om offline.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Pong om det inte gått 15 minuter, annars en tom sträng.</returns>
        public string Ping(int userId)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user.SessionTimer!>DateTime.Now.AddMinutes(-15))
                {
                    return "Pong!\n";
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception) 
            { 
                Error.ErrorUnknown();
                return string.Empty;
            }
        }

        /// <summary>
        /// Skap en ny kund.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="pwVerify"></param>
        /// <returns>True om registering lyckas, annars false.</returns>
        public bool Register(string name, string password, string pwVerify)
        {
            try
            {
                if (password != pwVerify && password.Length>5)
                {
                    Console.WriteLine("Ogiltigt lösenord, det måste vara längre än 5 bokstäver.");
                    return false;
                }

                if (Check.ExistUser(context.Users.FirstOrDefault(u => u.Name == name)))
                {
                    Console.WriteLine("Användarnamn är upptagen, var god ange ett annat.");
                    return false;
                }
                else
                {
                    context.Users.Add(new User()
                    { Name = name, Password = password, IsActive = true, IsAdmin = false, SoldBooks = new List<SoldBook>() });
                    context.SaveChanges();
                    Console.WriteLine("Du är registerad nu som kund, var god och logga in för att handla.");
                    return true;
                }
            }
            catch (Exception) 
            {
                Error.ErrorUnknown();
                return false;
            }
        }

        /// <summary>
        /// Admin sätter book.amount för tillgängliga böcker.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        public void SetAmount(int adminId, int bookId, int amount)
        {
            var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
            try
            {
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    if (book != null)
                    {
                        book.Amount += amount;
                        context.SaveChanges();
                        Console.WriteLine($"Lagret är fylld med {amount} böcker av {book.Title}.");
                    }
                    else
                    {
                        Console.WriteLine("Boken är inte med på listan.");
                    }
                }
                else { Error.NotAdmin(); }
            }
            catch (Exception) { Error.ErrorUnknown(); }
        }

        /// <summary>
        /// Admin uppdaterar info om en existerad bok.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns>True om det lyckas, annars false.</returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            try
            {
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                    if (book != null)
                    {
                        if (title != "") book.Title = title;
                        if (author != "") book.Author = author;
                        if (price != 0) book.Price = price;
                        context.Update(book);
                        context.SaveChanges();
                        Console.WriteLine("Nu är boken uppdaterad!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Uppdatering var inte genomfört.");
                        return false;
                    }
                }
                else
                {
                    Error.NotAdmin();
                    return false;
                }
            }
            catch (Exception) 
            {
                Error.ErrorUnknown();
                return false;
            }
        }

        /// <summary>
        /// Byter namn på en kategori.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="catId"></param>
        /// <param name="name"></param>
        /// <returns>True om det lyckas, annars false.</returns>
        public bool UpdateCategory(int adminId, int catId, string name)
        {
            try
            {
                if (Check.ExistAdmin(context.Users.FirstOrDefault(u => u.Id == adminId)))
                {
                    var cat = context.Categories.FirstOrDefault(c => c.Id == catId);
                    if (cat != null)
                    {
                        cat.Name = name;
                        context.Update(cat);
                        context.SaveChanges();
                        Console.WriteLine("Du har uppdaterat en kategori");
                        return true;
                    }
                    else
                    {
                        Error.ErrorUnknown();
                        return false;
                    }
                }
                else
                {
                    Error.NotAdmin();
                    return false;
                }
            }
            catch (Exception)
            {
                Error.ErrorUnknown();
                return false;
            }
        }
    }
}
