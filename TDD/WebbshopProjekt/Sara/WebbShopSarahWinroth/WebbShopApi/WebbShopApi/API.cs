using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopApi.Database;
using WebbShopApi.Models;

namespace WebbShopApi
{
    public class API
    {
        /// <summary>
        /// Sätter användarens property IsActive till true.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden kollar om användaren existerar i databasen genom Id.
        /// Om användaren inte är null så sätts användarens property IsActive till sant och sparas.
        /// </summary>
        /// <param name="adminId">Admins Id</param>
        /// <param name="userId">Användarens Id</param>
        /// <returns>Returnerar true om objektet inte är null, annars false</returns>
        public bool Activate(int adminId, int userId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsActive = true;
                        db.Update(user);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Lägger in en eller flera böcker i databasen.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden kollar om boken existerar i databasen genom Titel.
        /// Om boken inte är null så plussas bokens property Amount med det amount/antal som lagts till och sparas. 
        /// Om boken är null så läggs boken till i databasen och sparas.
        /// </summary>
        /// <param name="adminId">Admins Id</param>
        /// <param name="title">Bokens titel</param>
        /// <param name="author">Författare av boken</param>
        /// <param name="price">Bokens pris</param>
        /// <param name="amount">Antalet böcker</param>
        /// <returns>Returnerar false om användarens property IsAdmin är false, annars true</returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Title == title);
                    if (book != null)
                    {
                        book.Amount += amount;
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        db.Books.Add(new Book { Title = title, Author = author, Price = price, Amount = amount });
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Lägger till ett kategori-Id till en bok.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden kollar om boken och kategorin existerar i databasen genom Id.
        /// Om både boken och kategorin inte är null så läggs categoryId till i bokens property categoryId och sparas. 
        /// </summary>
        /// <param name="adminId">Admins Id</param>
        /// <param name="bookId">Bokens Id</param>
        /// <param name="categoryId">Kategorins Id</param>
        /// <returns>Returnerar true om boken och kategorin inte är null, annars false</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    var category = db.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (book != null && category != null)
                    {
                        book.CategoryId = category.Id;
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Lägger till en kategori i databasen.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden kollar om kategorin existerar i databasen genom namn.
        /// Om kategorin är null så läggs kategorin till i databasen och sparas. 
        /// </summary>
        /// <param name="adminId">Admins Id</param>
        /// <param name="name">Namnet på kategorin</param>
        /// <returns>Returnerar true om kategorin är null, annars false</returns>
        public bool AddCategory(int adminId, string name)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.Name == name);
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
            }
            return false;
        }
        /// <summary>
        /// Lägger till en användare i databasen.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden kollar om användaren existerar i databasen genom namn.
        /// Om användaren är null så läggs användaren till i databasen och sparas. 
        /// Är lösenordet är tomt så läggs "Codic2021" till som default-lösenord. Propertyn IsActive sätts till true och IsAdmin till false.
        /// </summary>
        /// <param name="adminId">Admins Id</param>
        /// <param name="name">Användarens namn</param>
        /// /// <param name="password">Användarens lösenord</param>
        /// <returns>Returnerar true om användaren är null, annars false</returns>
        public bool AddUser(int adminId, string name, string password)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Name == name);
                    if (user == null)
                    {
                        if (password == string.Empty)
                        {
                            password = "Codic2021";
                        }
                        db.Users.Add(new User { Name = name, Password = password, IsActive = true, IsAdmin = false });
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Tar fram vilken användare som köpt flest böcker.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden tar fram sålda böcker genom användar-Id och skapar en temporär "form/tabell" i variabeln OrderCounts där användar-Id och antalet köpta böcker läggs in.
        /// Därefter tar man fram vilken av antalet köpta böcker som är högst(Max) ur tabellen och tar fram Id som tillhör det högsta antalet.
        /// Namnet på den användaren hämtas därefter genom Id:t.
        /// </summary>
        /// <param name="adminId">Admins Id</param>
        /// <returns>Returnerar namnet på användaren, annars en tom sträng</returns>
        public string BestCustomer(int adminId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var OrderCounts = db.SoldBooks.GroupBy(
                         o => o.UserId).
                         Select(g => new
                         {
                             UserId = g.Key,
                             TotalOrders = g.Count()
                         });

                    var maxNumOfOrders = OrderCounts.Max(x => x.TotalOrders);
                    var bestInGroup = OrderCounts.FirstOrDefault(x => x.TotalOrders == maxNumOfOrders);
                    var user = db.Users.FirstOrDefault(c => c.Id == bestInGroup.UserId);

                    return $"{user.Name}";
                }
            }
            return "";
        }
        /// <summary>
        /// En användare köper en bok som läggs till i tabellen SoldBooks.
        /// Metoden kollar om boken existerar och inte har ett antal/amount som är lika med 0. 
        /// Om boken inte är null så kopieras/läggs all data in i SoldBooks tabellen plus tiden för köpet och köparen/användarens Id. 
        /// Bokens antal minskas med 1 och ändringarna sparas.
        /// </summary>
        /// <param name="userId">Användarens Id</param>
        /// <param name="bookId">Bokens Id</param>
        /// <returns>Returnerar false om boken är null eller användarId är 0, true om boken inte är null</returns>
        public bool BuyBook(int userId, int bookId)
        {
            bool loggedIn = CheckSessionTimer(userId);
            if(!loggedIn)
            {
                Logout(userId);
                return false;
            }
            if (userId == 0)
            {
                return false;
            }
            using (var db = new WebShopContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId && b.Amount != 0);
                if (book != null)
                {
                    db.SoldBooks.Add(new SoldBook { Title = book.Title, Author = book.Author, Price = book.Price, CategoryId = book.CategoryId, PurchasedDate = DateTime.Now, UserId = userId });
                    book.Amount -= 1;
                    db.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Kolla om användare är Administratör
        /// Metoden tar fram användare genom Id och kollar så att användaren inte är null och IsAdmin returnerar true.
        /// </summary>
        /// <param name="userId">Användarens Id</param>
        /// <returns>Returnerar true om användaren inte är null och IsAdmin returnerar true, annars false</returns>
        public bool CheckIfUserIsAdmin(int userId)
        {
            using (var db = new WebShopContext())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == userId);
                if (user != null && user.IsAdmin)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Kolla om användaren varit inaktiv i mer än 15 minuter.
        /// Metoden tar fram användaren genom Id och kollar om användarens SessionTimer är mer än dateTime.Now -15 minuter.
        /// Om sant så updateras SessionTimer till den aktuella tiden.
        /// </summary>
        /// <param name="userId">Användarens Id</param>
        /// <returns>Returnerar true om användaren inte varit inaktiv i mer än 15 minuter, annars false</returns>
        public bool CheckSessionTimer(int userId)
        {
            using (var db = new WebShopContext())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == userId);
                if (user.SessionTimer > DateTime.Now.AddMinutes(-15))
                {
                    UpdateSessionTimer(user.Id);
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Tar bort en bok.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden tar fram boken genom Id och kollar så att boken inte är null. Bokens antal/amount minskas med 1. 
        /// Om antalet av boken därefter är 0 eller mindre så tas boken bort helt från databasen.
        /// </summary>
        /// <param name="adminId">Användarens/Administratörens Id</param>
        /// <param name="bookId">Användarens/Administratörens Id</param>
        /// <returns>Returnerar true om boken inte är null och om antalet/amount är mindre eller lika med 0, annars false</returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        book.Amount -= 1;
                        if (book.Amount <= 0)
                        {
                            db.Remove(book);
                            db.Update(book);
                            db.SaveChanges();
                            return true;
                        }
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Tar bort en kategori.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden tar fram kategorin genom Id och kollar så att kategorin inte är null. Metoden kollar även om en bok med den kategorin existerar om inte så tas kategorin bort från databasen.
        /// </summary>
        /// <param name="adminId">Användarens/Administratörens Id</param>
        /// <param name="categoryId">Kategorins Id</param>
        /// <returns>Returnerar true om kategorin existerar och ingen bok är kopplad till kategorin, annars false</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.Id == categoryId);
                    var book = db.Books.FirstOrDefault(b => b.CategoryId == categoryId);
                    if (category != null)
                    {
                        if (book != null)
                        {
                            return false;
                        }
                        else
                        {
                            db.Remove(category);
                            db.Update(category);
                            db.SaveChanges();
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Nedgraderar en användare från Administratörs rättigheter till vanlig användare.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden letar upp användaren genom Id och kollar så att användaren inte är null. 
        /// Användarens IsAdmin sätts till false och sparas.
        /// </summary>
        /// <param name="adminId">Användarens/Administratörens Id</param>
        /// <param name="userId">Användarens Id</param>
        /// <returns>Returnerar true om användaren existerar, annars false</returns>
        public bool Demote(int adminId, int userId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsAdmin = false;
                        db.Update(user);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Söker efter användare.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden letar upp användare med namn som matchar den inmatning som skickats in som parameter och lägger in i en lista.
        /// </summary>
        /// <param name="adminId">Användarens/Administratörens Id</param>
        /// <param name="input">Användarens inmatning</param>
        /// <returns>Returnerar en lista med användare vars namn matchar med inmatningen från användaren</returns>
        public List<User> FindUser(int adminId, string input)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    List<User> users = db.Users.Where(u => u.Name.Contains(input)).ToList();
                    return users;
                }
            }
            return null;
        }
        /// <summary>
        /// Hämtar en kategori.
        /// Metoden letar upp en kategori genom Id. 
        /// </summary>
        /// <param name="categoryId">Kategori Id</param>
        /// <returns>Returnerar ett kategori-objekt/returns>
        public Category GetACategory(int categoryId)
        {
            using (var db = new WebShopContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.Id == categoryId);
                return category;
            }
        }
        /// <summary>
        /// Hämtar böcker genom författare.
        /// Metoden letar upp böcker med författare som matchar den inmatning som skickats in som parameter och lägger in i en lista.
        /// </summary>
        /// <param name="input">Användarens inmatning</param>
        /// <returns>Returnerar en lista med böcker vars författare matchar med inmatningen från användaren</returns>
        public List<Book> GetAuthors(string input)
        {
            using (var db = new WebShopContext())
            {
                List<Book> books = db.Books.Where(b => b.Author.Contains(input)).ToList();
                return books;
            }
        }
        /// <summary>
        /// Hämtar tillgängliga böcker som tillhör en kategori.
        /// Metoden letar upp böcker som innehåller en kategori genom Id och böcker som det finns mer än 0 av och lägger in dom i en lista.
        /// </summary>
        /// <param name="categoryId">Kategorins Id</param>
        /// <returns>Returnerar en lista med böcker</returns>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            using (var db = new WebShopContext())
            {
                List<Book> books = db.Books.Where(b => b.CategoryId == categoryId && b.Amount > 0).ToList();
                return books;
            }
        }
        /// <summary>
        /// Hämtar en bok.
        /// Metoden letar upp en bok genom Id och returnerar den.
        /// </summary>
        /// <param name="bookId">Bokens Id</param>
        /// <returns>Returnerar ett bok-objekt</returns>
        public Book GetBook(int bookId)
        {
            using (var db = new WebShopContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                return book;
            }
        }
        /// <summary>
        /// Hämtar en boks Id genom Titel.
        /// Metoden letar upp boken vars titel matchar med vad användaren matat in.
        /// Om boken inte är null så returneras bokens Id.
        /// </summary>
        /// <param name="input">Användarens inmatning</param>
        /// <returns>Returnerar en boks Id om boken inte är null, annars 0</returns>
        public int GetBookId(string input)
        {
            using (var db = new WebShopContext())
            {
                var book = db.Books.FirstOrDefault(c => c.Title == input);
                if (book != null)
                {
                    return book.Id;
                }
                return 0;
            }
        }
        /// <summary>
        /// Metoden letar upp böcker vars Titel innehåller/matchar det användaren matat in och lägger dom i en lista.
        /// </summary>
        /// <param name="input">Användarens inmatning</param>
        /// <returns>Returnerar en lista med böcker</returns>
        public List<Book> GetBooks(string input)
        {
            using (var db = new WebShopContext())
            {
                List<Book> books = db.Books.Where(b => b.Title.Contains(input)).ToList();
                return books;
            }
        }
        /// <summary>
        /// Metoden hämtar alla kategorier, organiserar dom efter namn och lägger in dom i en lista.
        /// </summary>
        /// <returns>Returnerar en lista med alla kategorier</returns>
        public List<Category> GetCategories()
        {
            using (var db = new WebShopContext())
            {
                List<Category> categories = db.Categories.OrderBy(c => c.Name).ToList();
                return categories;
            }
        }
        /// <summary>
        /// Metoden hämtar kategorier vars namn innehåller/matchar det användaren matat in och lägger dom i en lista.
        /// </summary>
        /// <param name="input">Användarens inmatning</param>
        /// <returns>Returnerar en lista med kategorier</returns>
        public List<Category> GetCategories(string input)
        {
            using (var db = new WebShopContext())
            {
                List<Category> categories = db.Categories.Where(c => c.Name.Contains(input)).ToList();
                return categories;
            }
        }
        /// <summary>
        /// Hämtar böcker utifrån samma kategori.
        /// Metoden letar upp böcker vars kategori-Id matchar det kategori-Id som skickats in som parameter och lägger in dom i en lista.
        /// </summary>
        /// <param name="categoryId">Kategori Id</param>
        /// <returns>Returnerar en lista med böcker</returns>
        public List<Book> GetCategory(int categoryId)
        {
            using (var db = new WebShopContext())
            {
                List<Book> books = db.Books.Where(b => b.CategoryId == categoryId).ToList();
                return books;
            }
        }
        /// <summary>
        /// Metoden letar upp kategori vars namn matchar det användaren matat in och returnerar kategorins Id om inte kategorin är null.
        /// </summary>
        /// <param name="input">Användarens inmatning</param>
        /// <returns>Returnerar kategorins Id</returns>
        public int GetCategoryId(string input)
        {
            using (var db = new WebShopContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.Name == input);
                if (category != null)
                {
                    return category.Id;
                }
                return 0;
            }
        }
        /// <summary>
        /// Metoden letar upp användare vars namn matchar det användaren matat in.
        /// Om inte användaren är null returneras användares Id, annars 0.
        /// </summary>
        /// <param name="input">Användarens inmatning</param>
        /// <returns>Returnerar användarens Id</returns>
        public int GetUserId(string input)
        {
            using (var db = new WebShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == input);
                if (user != null)
                {
                    return user.Id;
                }
                return 0;
            }
        }
        /// <summary>
        /// Sätter användarens IsActive till false.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden letar upp användare vars Id matchar användarens Id. Om användaren inte är null så sätts IsActive till false.
        /// </summary>
        /// <param name="adminId">Användarens/administratörens Id</param>
        /// <param name="userId">Användarens Id</param>
        /// <returns>Returnerar true om användaren inte är null, annars false</returns>
        public bool Inactivate(int adminId, int userId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsActive = false;
                        db.Update(user);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Listar alla användare.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden hämtar alla användare och organiserar dom efter namn och lägger in dom i en lista.
        /// </summary>
        /// <param name="adminId">Användarens/administratörens Id</param>
        /// <returns>Returnerar en lista med alla användare</returns>
        public List<User> ListUsers(int adminId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    List<User> users = db.Users.OrderBy(u => u.Name).ToList();
                    return users;
                }
            }
            return null;
        }
        /// <summary>
        /// Metoden kollar om det finns en användare med det namnet och lösenordet som skickas in som parametrar. 
        /// Om användaren inte är null och IsActive är true så sätts LastLogin och SessionTimer till den aktuella tiden.
        /// </summary>
        /// <param name="name">Användarens namn</param>
        /// <param name="password">Användarens lösenord</param>
        /// <returns>Returnerar användarens Id om användaren inte är null och IsActive är true, annars 0</returns>
        public int Login(string name, string password)
        {
            using (var db = new WebShopContext())
            {
                var user = db.Users.FirstOrDefault(user => user.Name == name && user.Password == password);
                if (user != null && user.IsActive == true)
                {
                    user.LastLogin = DateTime.Now;
                    user.SessionTimer = DateTime.Now;
                    db.Update(user);
                    db.SaveChanges();
                    return user.Id;
                }
                return 0;
            }
        }
        /// <summary>
        /// Nollställer användarens SessionTimer.
        /// Metoden letar upp användare vars Id matchar med användarens Id. Om användaren inte är null så sätts SessionTimer till minsta möjliga värdet av DateTime.
        /// </summary>
        /// <param name="userId">Användarens Id</param>
        public void Logout(int userId)
        {
            using (var db = new WebShopContext())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == userId);
                if (user != null)
                {
                    user.SessionTimer = DateTime.MinValue;
                    db.Users.Update(user);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Räknar ihop priset på alla sålda böcker.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden listar alla sålda böcker och organiserar dom efter titel. Utifrån listan plussar man ihop priserna från alla sålda böcker genom en foreach-loop.
        /// </summary>
        /// <param name="adminId">Användarens/administratörens Id</param>
        /// <returns>Returnerar summan av alla sålda böcker, annars 0</returns>
        public int MoneyEarned(int adminId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            int money = 0;
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    List<SoldBook> soldBooks = db.SoldBooks.OrderBy(b => b.Title).ToList();

                    foreach (var item in soldBooks)
                    {
                        money += item.Price;
                    }
                    return money;
                }
            }
            return 0;
        }
        /// <summary>
        /// Uppdaterar användarens SessionTimer om användaren inte varit inaktiverad i mer än 15 minuter.
        /// Metoden kollar om användaren varit inaktiverad i mindre än 15 min och uppdaterar användarens SessionTimer.
        /// </summary>
        /// <param name="userId">Användarens Id</param>
        /// <returns>Returnerar strängen "Pong" om användaren varit inaktiverad i mindre än 15 minuter, annars en tom sträng</returns>
        public string Ping(int userId)
        {
            bool connected = CheckSessionTimer(userId);
            if (connected)
            {
                return "Pong";
            }
            return string.Empty;
        }
        /// <summary>
        /// Uppgraderar en användaren till administratör.
        /// Hämtar användare vars Id matchar med Id:t som skickats in som parameter. Om användare inte är null så sätts IsAdmin till true.
        /// </summary>
        /// /// <param name="adminId">Användarens Id</param>
        /// <param name="userId">Användarens Id</param>
        /// <returns>Returnerar true om användare inte är null, annars false</returns>
        public bool Promote(int adminId, int userId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsAdmin = true;
                        db.Update(user);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Lägger till en ny användare i databasen.
        /// Metoden kollar om det finns en användare med det namnet och lösenordet som skickas in som parametrar. 
        /// Om användaren är null och password matchar passwordVerify så läggs användaren med namn och lösenord in i databasen.
        /// </summary>
        /// <param name="name">Användarens namn</param>
        /// <param name="password">Användarens lösenord</param>
        /// <param name="passwordVerify">Användarens verifierings lösenord</param>
        /// <returns>Returnerar true om användaren inte finns och lösenordet matchar verifierings lösenordet, annars false</returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            using (var db = new WebShopContext())
            {
                var user = db.Users.FirstOrDefault(user => user.Name == name && user.Password == password);
                if (user == null && password == passwordVerify)
                {
                    db.Users.Add(new User { Name = name, Password = password, IsActive = true, IsAdmin = false });
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden hämtar en bok genom Id. Om boken inte är null så sätts Amount till newAmount. 
        /// </summary>
        /// <param name="adminId">Användarens id</param>
        /// <param name="bookId">Bokens id</param>
        /// <param name="newAmount">Det antal böcker som skall läggas till</param>
        public void SetAmount(int adminId, int bookId, int newAmount)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        book.Amount = newAmount;
                        db.Update(book);
                        db.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// Hämtar alla sålda böcker och organiserar dom efter Titel och lägger dom i en lista.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// </summary>
        /// <param name="adminId">Användarens/Administratörens Id</param>
        /// <returns>Returnerar listan med sålda böcker, annars null.</returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    List<SoldBook> soldBooks = db.SoldBooks.OrderBy(b => b.Title).ToList();
                    return soldBooks;
                }
            }
            return null;
        }
        /// <summary>
        /// Uppdaterar en boks värden med det som skickas in.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden hämtar boken genom Id. Om boken inte är null så läggs värdena in i tillhörande variabel/kolumn.  
        /// </summary>
        /// <param name="adminId">Användarens Id</param>
        /// <param name="bookId">Bokens Id</param>
        /// <param name="title">Titeln på boken</param>
        /// <param name="author">Författare av boken</param>
        /// <param name="price">Priset på boken</param>
        /// <returns>Returnerar true om boken inte är null ,annars false</returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        book.Title = title;
                        book.Author = author;
                        book.Price = price;
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Uppdaterar en kategori med namnet som skickas in.
        /// Kollar först om adminId är en administratör genom att anropa metoden CheckIfUserIsAdmin. 
        /// Metoden hämtar kategorin genom Id. Om kategorin inte är null så ersätts namnet som skickats in som parameter av kategorins namn.  
        /// </summary>
        /// <param name="adminId">Användarens Id</param>
        /// <param name="categoryId">Kategorin Id</param>
        /// <param name="name">Namnet på kategorin</param>
        /// <returns>Returnerar true om kategorin inte är null ,annars false</returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            bool userIsAdmin = CheckIfUserIsAdmin(adminId);
            if (userIsAdmin)
            {
                using (var db = new WebShopContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (category != null)
                    {
                        category.Name = name;
                        db.Update(category);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Metoden hämtar användare genom Id och sätter användarens SessionTimer till den aktuella tiden.  
        /// </summary>
        /// <param name="userId">Användarens Id</param>
        public void UpdateSessionTimer(int userId)
        {
            using (var db = new WebShopContext())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == userId);
                user.SessionTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
            }
        }
    }
}
