using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebshopApi.Database;
using WebshopApi.Models;

namespace WebshopApi
{
    public class WebbShopAPI
    {
        private MyContext context = new MyContext();

        /// <summary>
        /// Loggar in en användare och sätter DateTime till nu.
        /// </summary>
        /// <param name="username">Användarens username i databasen </param>
        /// <param name="password">Användarens password i databasen </param>
        /// <returns>användarens Id (int)</returns>
        public int Login(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive);
            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
                return user.ID;
            }

            return 0; // user does not exist
        }

        /// <summary>
        /// Loggar ut en användare och nollställer DateTime
        /// </summary>
        /// <param name="userID">Användarens ID </param>
        public void Logout(int userID)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == userID);

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                context.Users.Update(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retunerar alla kategorier i bokstavsordning
        /// </summary>
        /// <returns> IEnumerable med alla kategorier</returns>
        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.OrderBy(c => c.Name);
        }

        /// <summary>
        /// Retunerar alla kategorier i bokstavsordning som innehåller ett nyckelord
        /// </summary>
        /// <param name="keyword">nyckelordet för sökningen</param>
        /// <returns> IEnumerable med alla kategorier som innehåller nyckelordet </returns>
        public IEnumerable<Category> GetCategories(string keyword)
        {
            return context.Categories.Where(c => c.Name.Contains(keyword)).OrderBy(c => c.Name);
        }

        /// <summary>
        /// Retunerar alla böcker som har ett visst categoryID
        /// </summary>
        /// <param name="categoryID">Böcker med vars kategorier vi söker</param>
        /// <returns> IEnumerable med alla böcker som har kategorin </returns>
        public IEnumerable<Book> GetCategory(int categoryID)
        {
            return context.Books.Where(b => b.Category.ID == categoryID);
        }

        /// <summary>
        /// Retunerar alla böcker
        /// </summary>
        /// <returns> IEnumerable med alla böcker </returns>
        public IEnumerable<Book> GetAvailableBooks()
        {
            return context.Books.Where(b => b.Amount > 0);
        }

        /// <summary>
        /// Retunerar en book objekt baserat på bookID
        /// </summary>
        /// <returns> IEnumerable med alla böcker </returns>
        /// <param name="bookID">Bokens ID </param>
        /// <returns>Book Object av boken om den finns</returns>
        public IEnumerable<Book> GetBook(int bookID)
        {
            return context.Books.Where(b => b.ID == bookID);
        }

        /// <summary>
        /// Retunerar books baserat på om titeln innehåller ett nyckelord
        /// </summary>
        /// <param name="keyword">nyckelord</param>
        /// <returns>IEnumerable med alla böcker utifrån kriterium</returns>
        public IEnumerable<Book> GetBooks(string keyword)
        {
            return context.Books.Where(c => c.Title.Contains(keyword)).OrderBy(c => c.Title);
        }

        /// <summary>
        /// Retunerar books baserat på om de innehåller en specifik författare
        /// </summary>
        /// <param name="keyword">nyckelord</param>
        /// <returns>IEnumerable med alla böcker utifrån kriterium</returns>
        public IEnumerable<Book> GetAuthors(string keyword)
        {
            return context.Books.Where(c => c.Author == keyword);
        }

        /// <summary>
        /// Köper en bok om en Users session timer inte överstiger 15 min. Boken skickas till tabellen Soldbooks och raderas
        /// om amount == 0;
        /// </summary>
        /// <param name="userID">Användarens ID</param>
        /// <param name="bookID">Bokens ID</param>
        /// <returns>Bool true om den blir sold, false om något steg inte fungerar; user inte finns, book inte finns, etc. </returns>
        public bool BuyBook(int userID, int bookID)
        {
            if (UserExist(userID) && BookExist(bookID))
            {
                var user = context.Users.FirstOrDefault(u => u.ID == userID);
                var book = context.Books.Include(b => b.Category).FirstOrDefault(b => b.ID == bookID);
                if (CheckTimer(user) && book.Amount > 0)
                {
                    context.SoldBooks.Add(new SoldBook
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Category = book.Category,
                        Price = book.Price,
                        PurchasedDate = DateTime.Now,
                        User = user
                    });
                    context.SaveChanges();
                    DeleteBookVoid(bookID);

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Pingar "Pong" om användarens Session Timer är under 15 min
        /// </summary>
        /// <param name="userID">Användarens ID</param>
        /// <returns> string "pong" om användarens session timer är OK annars string.Empty </returns>
        public string Ping(int userID)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == userID);
            if (user != null && CheckTimer(user))
            {
                return "pong";
            }

            return string.Empty;
        }

        /// <summary>
        /// Registrerar en användare till databasen
        /// </summary>
        /// <param name="name">Användarens namn</param>
        /// <param name="password">Användarens lösen</param>
        /// <param name="passwordVer">Användarens lösen Verifierat</param>
        /// <returns>Bool true om användaren inte finns, annars false </returns>
        public bool Register(string name, string password, string passwordVer)
        {
            if (!UserExist(name) && password == passwordVer)
            {
                context.Users.Add(new User
                {
                    Name = name,
                    Password = password,
                    IsActive = true,
                    IsAdmin = false
                });
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Lägger till en book i databasen, om titeln redan finnns ökas Amount med 1.
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="title">Bokens titel</param>
        /// <param name="author">Bokens författare</param>
        /// <param name="price">Bokens pris</param>
        /// <param name="amount">Antal böcker</param>
        /// <returns>Bool true om det funkar, annars false </returns>
        public bool AddBook(int adminID, string title, string author, int price, int amount)
        {
            if (VerifyAdmin(adminID))
            {
                if (BookExist(title))
                {
                    var book = context.Books.FirstOrDefault(b => b.Title == title);
                    book.Amount++;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    context.Books.Add(new Book
                    {
                        Title = title,
                        Author = author,
                        Price = price,
                        Amount = amount
                    });
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Ändrar amount i en specifik book
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="bookID">Bokens titel</param>
        /// <param name="amount">Antal böcker</param>
        /// <returns>Bool true om det funkar, annars false </returns>
        public bool SetAmount(int adminID, int bookID, int amount)
        {
            if (VerifyAdmin(adminID) && BookExist(bookID))
            {
                var book = context.Books.FirstOrDefault(b => b.ID == bookID);
                book.Amount = amount;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// IEnumerable med alla användare
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <returns>IEnumerable med alla användare om admin != admin returneras tom IEnumerable</returns>
        public IEnumerable<User> ListUsers(int adminID)
        {
            if (VerifyAdmin(adminID))
            {
                return context.Users;
            }

            return Enumerable.Empty<User>();
        }

        /// <summary>
        /// En IEnumerable baserat på vad som matchar ett nyckelord
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="keyword">nyckelordet</param>
        /// <returns>IEnumerable med alla användare utifrån kriterium, om admin != admin returneras tom IEnumerable</returns>
        public IEnumerable<User> FindUser(int adminID, string keyword)
        {
            var admin = context.Users.FirstOrDefault(a => a.ID == adminID);

            if (VerifyAdmin(adminID))
            {
                return context.Users.Where(u => u.Name.Contains(keyword));
            }

            return Enumerable.Empty<User>();
        }

        /// <summary>
        /// Uppdaterar en book med paramterarna
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="title">Bokens titel</param>
        /// <param name="author">Bokens författare</param>
        /// <param name="price">Bokens pris</param>
        /// <returns>bool true om allt funkar, annars false</returns>
        public bool UpdateBook(int adminID, int bookID, string title, string author, int price)
        {
            if (VerifyAdmin(adminID) && BookExist(bookID))
            {
                var book = context.Books.FirstOrDefault(b => b.ID == bookID);
                book.Title = title;
                book.Author = author;
                book.Price = price;
                context.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Raderar en bok i databasen om amount == 0, annars minskas amount med 1
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="bookID">Bokens ID</param>
        /// <returns>bool true om allt funkar, annars false</returns>
        public bool DeleteBook(int adminID, int bookID)
        {
            if (VerifyAdmin(adminID) && BookExist(bookID))
            {
                DeleteBookVoid(bookID);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Lägger till en kategori om den inte redan finns
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="name">kategorins namn</param>
        /// <returns>bool true om allt funkar, annars false</returns>
        public bool AddCategory(int adminID, string name)
        {
            var category = context.Categories.FirstOrDefault(c => c.Name == name);

            if (VerifyAdmin(adminID) && category == null)
            {
                context.Categories.Add(new Category { Name = name });
                context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lägger till en bok till en kategori
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="bookID">Bokens ID</param>
        /// <param name="categoryID">kategorins ID</param>
        /// <returns>bool true om allt funkar, annars false</returns>
        public bool AddBookToCategory(int adminID, int bookID, int categoryID)
        {
            if (VerifyAdmin(adminID) && BookExist(bookID) && CategoryExist(categoryID))
            {
                var book = context.Books.FirstOrDefault(b => b.ID == bookID);
                book.Category = context.Categories.FirstOrDefault(c => c.ID == categoryID);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Uppdaterar namnet på en existerande kategori
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="categoryID">Kategorins ID</param>
        /// <param name="name">Det nya namnet</param>
        /// <returns>bool true om allt funkar, annars false</returns>
        public bool UpdateCategory(int adminID, int categoryID, string name)
        {
            if (VerifyAdmin(adminID) && CategoryExist(categoryID))
            {
                var category = context.Categories.FirstOrDefault(c => c.ID == categoryID);
                category.Name = name;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Lägger till en användare om den inte redan finns
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="name">Användarens namn</param>
        /// <param name="password">Användarens lösenord</param>
        /// <returns>bool true om allt funkar, annars false</returns>
        public bool AddUser(int adminID, string name, string password)
        {
            if (VerifyAdmin(adminID) && !UserExist(name))
            {
                context.Users.Add(
                new User
                {
                    Name = name,
                    Password = password,
                    IsAdmin = false,
                    IsActive = true
                });
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Raderar en kategori om den inte är kopplat till någon bok
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="categoryID">Kategorins ID</param>
        /// <returns>bool true om allt funkar, annars false</returns>
        public bool DeleteCategory(int adminID, int categoryID)
        {
            if (VerifyAdmin(adminID))
            {
                var category = context.Categories.FirstOrDefault(c => c.ID == categoryID);
                var books = context.Books.Where(b => b.Category == category);
                if (books.Count() == 0)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Listar alla sålda böcker
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <returns>IEnumerable med alla böcker om admin == admin</returns>
        public IEnumerable<SoldBook> SoldItems(int adminID)
        {
            if (VerifyAdmin(adminID))
            {
                return context.SoldBooks;
            }
            return Enumerable.Empty<SoldBook>();
        }

        /// <summary>
        /// Listar summan av alla sålda böckers pris
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <returns>int</returns>
        public int MoneyEarned(int adminID)
        {
            int moneyEarned = 0;

            if (VerifyAdmin(adminID))
            {
                return moneyEarned = context.SoldBooks.Sum(b => b.Price);
            }
            return moneyEarned; // noll om admin inte är admin
        }

        /// <summary>
        ///  Visar UserID som har köpt flest böcker (till antal, inte pris)
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <returns>int customerID, 0 om admin != admin </returns>
        public int BestCustomer(int adminID)
        {
            int customerID = 0;

            if (VerifyAdmin(adminID))
            {
                var soldItems = context.SoldBooks.GroupBy(
                                  u => u.User.ID).
                                  Select(g => new
                                  {
                                      UserID = g.Key,
                                      TotalOrders = g.Count()
                                  });

                int maxOrder = soldItems.Max(o => o.TotalOrders);
                var customer = soldItems.FirstOrDefault(o => o.TotalOrders == maxOrder);
                customerID = customer.UserID;

                return customerID;
            }

            return customerID;
        }

        /// <summary>
        ///  Gör en användare till admin
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="userID">Användarens ID</param>
        /// <returns>bool true om allt funkar </returns>
        public bool Promote(int adminID, int userID)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == userID);

            if (VerifyAdmin(adminID) && user != null)
            {
                user.IsAdmin = true;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        ///  Gör en användare till user (om den var admin)
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="userID">Användarens ID</param>
        /// <returns>bool true om allt funkar </returns>
        public bool Demote(int adminID, int userID)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == userID);

            if (VerifyAdmin(adminID) && user != null)
            {
                user.IsAdmin = false;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        ///  Gör en användare aktiv
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="userID">Användarens ID</param>
        /// <returns>bool true om allt funkar </returns>
        public bool ActivateUser(int adminID, int userID)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == userID);

            if (VerifyAdmin(adminID) && user != null)
            {
                user.IsActive = true;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        ///  Gör en användare inaktiv
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <param name="userID">Användarens ID</param>
        /// <returns>bool true om allt funkar </returns>
        public bool InactivateUser(int adminID, int userID)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == userID);

            if (VerifyAdmin(adminID) && user != null)
            {
                user.IsActive = false;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        ///  Kollar om användaren är admin och finns
        /// </summary>
        /// <param name="adminID">Användarens ID</param>
        /// <returns>bool true om admin finns </returns>
        private bool VerifyAdmin(int adminID)
        {
            var admin = context.Users.FirstOrDefault(u => u.ID == adminID);
            if (admin != null && admin.IsAdmin)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///  Raderar en bok om amount == noll, annars minskas amount med -1.
        /// </summary>
        /// <param name="bookID">Bokens ID</param>
        private void DeleteBookVoid(int bookID)
        {
            var book = context.Books.FirstOrDefault(b => b.ID == bookID);

            if (book.Amount > 0)
            {
                book.Amount--;
                context.SaveChanges();
            }
            if (book.Amount == 0)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Kollar om en användare finns genom dess ID
        /// </summary>
        /// <param name="userID">Användarens ID</param>
        /// <returns>bool true om användaren finns </returns>
        private bool UserExist(int userID)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == userID);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kollar om en användare finns genom dess namn
        /// </summary>
        /// <param name="userName">Användarens namn</param>
        /// <returns>bool true om användaren finns </returns>
        private bool UserExist(string userName)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == userName);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kollar om en bok finns genom dess ID
        /// </summary>
        /// <param name="bookID">Bokens ID</param>
        /// <returns>bool true om boken finns </returns>
        private bool BookExist(int bookID)
        {
            var book = context.Books.FirstOrDefault(b => b.ID == bookID);

            if (book != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kollar om en bok finns genom dess titel
        /// </summary>
        /// <param name="title">Bokens titel</param>
        /// <returns>bool true om boken finns </returns>
        private bool BookExist(string title)
        {
            var book = context.Books.FirstOrDefault(b => b.Title == title);

            if (book != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kollar om en kategori finns genom dess ID
        /// </summary>
        /// <param name="categoryID">kategorins id</param>
        /// <returns>bool true om kategorin finns </returns>
        private bool CategoryExist(int categoryID)
        {
            var category = context.Categories.FirstOrDefault(b => b.ID == categoryID);

            if (category != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kollar om users SessionTimer inte överstigit 15 min
        /// </summary>
        /// <param name="user">objekt av användaren</param>
        /// <returns>bool true om den inte överstigit, annars false </returns>
        private bool CheckTimer(User user)
        {
            if (user.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                return true;
            }
            return false;
        }
    }
}