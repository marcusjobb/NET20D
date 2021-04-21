using Inlämning2WebbShop.Helpers;
using Inlämning2WebbShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning2WebbShop
{
    public class WebbShopAPI
    {
        private HelperMethods helper = new HelperMethods();

        /// <summary>
        /// aktiverar en användare. (sätter IsActive till true)
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool ActivateUser(int adminId, int userId)
        {
            var user = new User();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                if (helper.DoesUserExists(userId, out user) && !user.IsActive)
                {
                    user.IsActive = true;
                    helper.db.Users.Update(user);
                    helper.db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Skapar en ny bok (ifall man är admin). Ifall boken finns, ökas amount.
        /// Annars skapas en ny bok.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddBook(int adminId, int bookId, string title, string author, int price, int amount)
        {
            var book = new Book();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                if (helper.DoesBookExists(bookId, out book))
                {
                    book.Amount++;
                    helper.db.SaveChanges();
                    return true;
                }
                else if (!helper.DoesBookExists(title))
                {
                    helper.db.Books.Add(new Book
                    {
                        Title = title,
                        Author = author,
                        Price = price,
                        Amount = amount,
                        Category = null
                    });
                    helper.db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// lägger till en kategori till en bok (om man är admin)
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var book = new Book();
            var category = new BookCategory();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                if (helper.DoesCategoryExists(categoryId, out category) && helper.DoesBookExists(bookId, out book))
                {
                    book.Category = category;
                    helper.db.Books.Update(book);
                    helper.db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// adderar en ny kategori vars namn skickas in som parameter(om man är admin)
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddCategory(int adminId, string name)
        {
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                if (!string.IsNullOrEmpty(name) && !helper.DoesCategoryExists(name))
                {
                    helper.db.Categories.Add(new BookCategory
                    {
                        Name = name
                    });
                    helper.db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// lägger till en användare, ifall inget lösenord skikcas in anges "Codic2021" som default lösen.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AddUser(int adminId, string name, string password = "Codic2021")
        {
            if (helper.IsAdminAndLoggedIn(adminId) && !helper.DoesUserExists(name, password))
            {
                helper.db.Users.Add(new User
                {
                    Name = name,
                    Password = password,
                    IsAdmin = false,
                    IsActive = true
                });

                helper.db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// letar upp den kund som har köpt flest böcker och returnerar denne.
        /// </summary>
        /// <returns></returns>
        public User BestCustomer(int adminId)
        {
            var user = new User();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                var listofSoldBook = helper.db.SoldBooks.ToList();
                var listOfSoldBookUserIds = new List<int>();
                foreach (var soldBook in listofSoldBook)
                {
                    listOfSoldBookUserIds.Add(soldBook.User.Id);
                }
                int bestcustomerId = listOfSoldBookUserIds.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First(); // hittar det id som förekommer flest gånger i listan
                user = helper.db.Users.FirstOrDefault(u => u.Id == bestcustomerId);
            }
            return user;
        }

        /// <summary>
        /// tillåter användaren att köpa en bok ifall inloggad och aktiv, samt att boken finns och amount > 0.
        /// kopierar även över informationen till SoldBooks.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool BuyBook(int userId, int bookId)
        {
            var book = new Book();
            var user = new User();

            if (helper.IsUserAbleToPurchase(userId, out user) && helper.IsBookAvaliableForSale(bookId, out book))
            {
                helper.db.SoldBooks.Add(new SoldBook
                {
                    Title = book.Title,
                    Author = book.Author,
                    Price = book.Price,
                    PurchasedDate = DateTime.Now,
                    User = user,
                    Category = helper.db.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == book.Id).Category
                });
                book.Amount--;
                helper.db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// tar bort en bok ifall det endast finns 1, eller tar bort ett från amount. (endast om admin)
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            var book = new Book();
            if (helper.IsAdminAndLoggedIn(adminId) && helper.DoesBookExists(bookId, out book))
            {
                book.Amount--;
                if (book.Amount < 1)
                {
                    helper.db.Books.Remove(book);
                    helper.db.SaveChanges();
                    return true;
                }
                else if (book.Amount > 0)
                {
                    helper.db.Books.Update(book);
                    helper.db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// tar bort en kategori, går endast om man är admin och ifall det inte finns en bok kopplad till kategorin
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            var category = new BookCategory();
            var book = helper.db.Books.FirstOrDefault(b => b.Category.Id == categoryId);
            var soldBook = helper.db.Books.FirstOrDefault(b => b.Category.Id == categoryId);
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                if (helper.DoesCategoryExists(categoryId, out category) && book == null && soldBook == null)
                {
                    helper.db.Categories.Remove(category);
                    helper.db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// nedgraderar en admin till en vanlig användare.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Demote(int adminId, int userId)
        {
            var user = new User();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                if (helper.DoesUserExists(userId, out user) && user.IsAdmin)
                {
                    user.IsAdmin = false;
                    helper.db.Users.Update(user);
                    helper.db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// returnerar en lista på användare som matchar sökord (på användarens namn). (admin metod)
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<User> FindUsers(int adminId, string keyword)
        {
            var userList = new List<User>();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                userList = helper.db.Users.Where(u => u.Name.Contains(keyword)).OrderBy(u => u.Name).ToList();
            }
            return userList;
        }

        /// <summary>
        /// hämtar en lista på de böcker som är skrivna av en viss författare.(baserat på ett sökord).
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Book> GetAuthors(string keyword)
        {
            return helper.db.Books.Where(b => b.Author == keyword).OrderBy(b => b.Title).ToList();
        }

        /// <summary>
        /// rturnerar en lista på alla tillgängliga böcker(amount > 0) i en viss kategori
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            return helper.db.Books.Where(b => b.Category.Id == categoryId && b.Amount > 0).OrderBy(b => b.Title).ToList();
        }

        /// <summary>
        /// hämtar en specifik bok baserat på Id.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public Book GetBook(int bookId)
        {
            return helper.db.Books.FirstOrDefault(b => b.Id == bookId);
        }

        /// <summary>
        /// hämtar en lista av böcker baserat på ett sökord på böckernas titel.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Book> GetBooks(string keyword)
        {
            return helper.db.Books.Where(b => b.Title.Contains(keyword)).OrderBy(b => b.Title).ToList();
        }

        /// <summary>
        /// Hämtar (och sorterar) en lista på alla bokkategorier
        /// </summary>
        /// <returns></returns>
        public List<BookCategory> GetCategories()
        {
            return helper.db.Categories.OrderBy(c => c.Name).ToList();
        }

        /// <summary>
        /// Hämtar (och sorterar) en lista på alla bokkategorier baserat på sökord
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            return helper.db.Categories.Where(c => c.Name.Contains(keyword)).OrderBy(c => c.Name).ToList();
        }

        /// <summary>
        /// returnerar en lista av böcker i en specifik kategori baserat på kategori Id.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Book> GetCategory(int categoryId)
        {
            return helper.db.Books.Where(b => b.Category.Id == categoryId).OrderBy(b => b.Title).ToList();
        }

        /// <summary>
        /// inaktiverar en användare(sätter IsActive till false)
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool InactivateUser(int adminId, int userId)
        {
            var user = new User();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                if (helper.DoesUserExists(userId, out user) && user.IsActive)
                {
                    user.IsActive = false;
                    Logout(userId);
                    helper.db.Users.Update(user);
                    helper.db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// LA TILL EFTER INLÄMNING 2.
        /// kollar ifall en användare är admin.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsUserAdmin(int userId)
        {
            var user = helper.db.Users.FirstOrDefault(u => u.Id == userId);
            return user.IsAdmin;
            
        }

        /// <summary>
        /// listar alla användare i databasen (ifall man är admin och inloggad)
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public List<User> ListUsers(int adminId)
        {
            var userList = new List<User>();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                userList = helper.db.Users.OrderBy(u => u.Name).ToList();
            }
            return userList;
        }

        /// <summary>
        /// Metod för att logga in användare. Returnerar 0 om inloggning misslyckas.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string username, string password)
        {
            var user = new User();
            if (helper.UserAbleToLogIn(username, password, out user))
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                helper.db.Users.Update(user);
                helper.db.SaveChanges();
                return user.Id;
            }
            return 0; // 0 = användaren finns inte
        }

        /// <summary>
        /// metod för att logga ut användare via Id
        /// </summary>
        /// <param name="id"></param>
        public void Logout(int id)
        {
            var user = new User();
            if (helper.DoesUserExists(id, out user))
            {
                user.SessionTimer = DateTime.MinValue;
                helper.db.Users.Update(user);
                helper.db.SaveChanges();
            }
        }
        /// <summary>
        /// returnerar en double på hur mycket pengar man tjänat genom att addera priset på alla sålda böcker.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public double MoneyEarned(int adminId)
        {
            double moneyEarned = 0;
            var soldBooks = helper.db.SoldBooks.ToList();
            if (helper.IsAdminAndLoggedIn(adminId) && soldBooks.Count > 0)
            {
                foreach (var book in soldBooks)
                {
                    moneyEarned += book.Price;
                }
            }
            return moneyEarned;
        }

        /// <summary>
        /// kollar ifall användaren fortf är inloggad, och uppdaterar värdet på SessionTimer till nuvarande klockslag.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string Ping(int userId)
        {
            var user = new User();
            if (helper.IsUserLoggedIn(userId, out user))
            {
                user.SessionTimer = DateTime.Now;
                helper.db.Users.Update(user);
                return "Pong";
            }
            Logout(userId);
            return string.Empty;
        }

        /// <summary>
        /// uppgraderar en vanlig användare till en admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Promote(int adminId, int userId)
        {
            var user = new User();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                if (helper.DoesUserExists(userId, out user) && !user.IsAdmin)
                {
                    user.IsAdmin = true;
                    helper.db.Users.Update(user);
                    helper.db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Användare registreras (skapas) om användaren inte redan finns.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            if (helper.IsUserAbleToRegister(name, password, passwordVerify))
            {
                helper.db.Users.Add(new User
                {
                    Name = name,
                    Password = password,
                    IsAdmin = false,
                    IsActive = true
                });
                helper.db.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// sätter en bok till ett visst amount (ifall man är admin och boken existerar)
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        public void SetAmount(int adminId, int bookId, int amount)
        {
            var book = new Book();
            if (helper.IsAdminAndLoggedIn(adminId) && helper.DoesBookExists(bookId, out book))
            {
                book.Amount = amount;
                helper.db.Books.Update(book);
                helper.db.SaveChanges();
            }
        }
        /// <summary>
        /// returnerar en lista på alla sålda böcker. (om man är admin)
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            var listOfSoldBooks = new List<SoldBook>();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                listOfSoldBooks = helper.db.SoldBooks.OrderBy(sb => sb.Title).ToList();
            }
            return listOfSoldBooks;
        }

        /// <summary>
        /// uppdaterar en bok(om man är admin och om boken finns) baserat på inskickade parametrar.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            var book = new Book();
            if (helper.IsAdminAndLoggedIn(adminId) && helper.DoesBookExists(bookId, out book))
            {
                book.Title = title;
                book.Author = author;
                book.Price = price;
                helper.db.Books.Update(book);
                helper.db.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// uppdaterar en kategori med namn inskickad som parameter.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            var category = new BookCategory();
            if (helper.IsAdminAndLoggedIn(adminId))
            {
                if (helper.DoesCategoryExists(categoryId, out category) && !string.IsNullOrEmpty(name))
                {
                    category.Name = name;
                    helper.db.Categories.Update(category);
                    helper.db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}