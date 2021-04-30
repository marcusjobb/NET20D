using Inlämning_API.Database;
using Inlämning_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Inlämning_API.Helper.HelperMethods;

namespace Inlämning_API
{
    public class WebbShopAPI
    {
        public StoreContext db = new StoreContext();

        /// <summary>
        /// Login for users and admins which is active
        /// </summary>
        /// <param name="userName">Name</param>
        /// <param name="password">Password</param>
        /// <returns>Int id if succes else int 0</returns>
        public User Login(string userName, string password)
        {
            var user = (from u in db.Users
                        where u.Name == userName
                        && u.Password == password
                        && u.IsActive
                        select u).FirstOrDefault();

            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return user;
            }
            return new User { };
        }

        /// <summary>
        /// Method for logout
        /// </summary>
        /// <param name="id">Userid</param>
        public void LogOut(int id)
        {
            var user = (from u in db.Users
                        where u.ID == id && u.SessionTimer > DateTime.Now.AddMinutes(-15)
                        select u).FirstOrDefault();

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get all BookCategories
        /// </summary>
        /// <returns>List of Categories</returns>
        public IEnumerable<BookCategories> GetCategories()
        {
            return from c in db.BookCategory
                   orderby c.Id
                   select c;
        }

        /// <summary>
        /// Gets a list of categories based on the keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List</returns>
        public IEnumerable<BookCategories> GetCategories(string keyword)
        {
            return from c in db.BookCategory
                   where c.Name.Contains(keyword)
                   select c;
        }

        /// <summary>
        /// Gets a list of book in a specific category
        /// </summary>
        /// <param name="id">Cat Id</param>
        /// <returns>List</returns>
        public IEnumerable<Book> GetCategory(int id)
        {
            return from b in db.Books
                   where b.Category.Id == id
                   orderby b.Id
                   select b;
        }

        /// <summary>
        /// Gets a list of all books
        /// </summary>
        /// <returns>List of books</returns>
        public IEnumerable<Book> GetAllBooks()
        {
            return (from b in db.Books
                    orderby b.Id
                    select b).Include(b => b.Category);
        }

        /// <summary>
        /// Gets books by catId where book amount > 0
        /// </summary>
        /// <param name="id">CatId</param>
        /// <returns>List</returns>
        public IEnumerable<Book> GetAvailableBooks(int catId)
        {
            return from b in db.Books
                   where b.Category.Id == catId && b.Amount > 0
                   select b;
        }

        /// <summary>
        /// Get Book by ID
        /// </summary>
        /// <param name="id">BookId</param>
        /// <returns>List</returns>
        public Book GetBook(int id)
        {
            return (from b in db.Books
                    where b.Id == id
                    select b).Include(b => b.Category).FirstOrDefault();
        }

        /// <summary>
        /// Get books which contains a the keyword parameter
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List</returns>
        public IEnumerable<Book> GetBooks(string keyword)
        {
            return (from b in db.Books
                    where b.Title.Contains(keyword)
                    select b).Include(b => b.Category);
        }

        /// <summary>
        /// Get books by Author
        /// </summary>
        /// <param name="keyword">Namn på författare</param>
        /// <returns>List</returns>
        public IEnumerable<Book> GetAuthors(string keyword)
        {
            return (from b in db.Books
                    where b.Author.Contains(keyword)
                    select b).Include(b => b.Category);
        }

        /// <summary>
        /// Checks if the user can buy a book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns>Bool</returns>
        public bool BuyBooks(int userId, int bookId)
        {
            if (IsUserOnline(userId))
            {
                var book = (from b in db.Books.Include(b => b.Category)
                            where b.Id == bookId
                            select b).FirstOrDefault();

                if (book != null && book.Amount > 0)
                {
                    db.SoldBooks.Add(new SoldBooks
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Category = book.Category,
                        Price = book.Price,
                        PurchasedDate = DateTime.Now,
                        User = (from u in db.Users
                                where u.ID.Equals(userId)
                                select u).FirstOrDefault()
                    });
                    book.Amount--;
                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  Ping to keep the user online
        /// </summary>
        /// <param name="id">userId</param>
        /// <returns>string</returns>
        public string Ping(int id)
        {
            var user = (from u in db.Users
                        where u.ID == id &&
                        u.SessionTimer > DateTime.Now.AddMinutes(-15)
                        select u).FirstOrDefault();

            if (user != null)
            {
                user.SessionTimer = DateTime.Now;
                db.SaveChanges();
                return "Pong";
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Creates a new user/customer
        /// </summary>
        /// <param name="name">Användarnamn</param>
        /// <param name="password">lösenord</param>
        /// <param name="passwordVerify">verifiera lösenord</param>
        /// <returns>bool</returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
                {
                    return false;
                }

                var user = (from u in db.Users
                            where u.Name == name
                            select u).FirstOrDefault();

                if (user == null && password.Equals(passwordVerify))
                {
                    db.Users.Add(new User
                    {
                        Name = name,
                        Password = password,
                        IsActive = true,
                        LastLogin = DateTime.Now
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Adds a book if book exist it will add up the amount
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount, int id = 0)
        {
            try
            {
                if (IsUserAdmin(adminId) && !string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
                {
                    var book = (from b in db.Books
                                where b.Title == title && b.Author == author
                                select b).FirstOrDefault();

                    if (book == null)
                    {
                        db.Books.Add(new Book { Title = title, Author = author, Price = price, Amount = amount });
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        book.Amount += amount;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Increases book amount
        /// </summary>
        /// <param name="adminId">Admin ID</param>
        /// <param name="bookId">Book ID</param>
        /// <param name="amount">Amount</param>
        public void SetAmount(int adminId, int bookId, int amount)
        {
            if (IsUserAdmin(adminId))
            {
                var book = (from b in db.Books where b.Id == bookId select b).FirstOrDefault();
                if (book != null)
                {
                    book.Amount += amount;
                    db.Books.Update(book);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// List Users
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>List</returns>
        public IEnumerable<User> ListUsers(int adminId)
        {
            if (IsUserAdmin(adminId))
            {
                return from u in db.Users orderby u.ID select u;
            }
            return Array.Empty<User>();
        }

        /// <summary>
        /// Search users based on a keyword
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>List</returns>
        public IEnumerable<User> FindUser(int adminId, string keyword)
        {
            if (IsUserAdmin(adminId))
            {
                return from u in db.Users where u.Name.Contains(keyword) orderby u.Name select u;
            }
            return Array.Empty<User>();
        }

        /// <summary>
        /// Update books that already exists
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns>Bool</returns>
        public bool UpdateBook(int adminId, int id, string title, string author, int price)
        {
            try
            {
                if (IsUserAdmin(adminId) && !string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
                {
                    var book = (from b in db.Books where b.Id == id select b).SingleOrDefault();
                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    db.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Delete a book if the amount is 0 else decreases the amount by 1
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        public bool DeleteBook(int adminId, int id)
        {
            if (IsUserAdmin(adminId))
            {
                var book = (from b in db.Books
                            where b.Id == id
                            select b).Include(b => b.Category).SingleOrDefault();
                if (book != null)
                {
                    book.Amount--;
                    db.Update(book);
                    if (book.Amount <= 0)
                    {
                        db.Remove(book);
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Add a new Category
        /// </summary>
        /// <param name="adminId">Admin ID</param>
        /// <param name="catName">Namn på kategori</param>
        /// <returns>Bool</returns>
        public bool AddCategory(int adminId, string catName)
        {
            try
            {
                if (IsUserAdmin(adminId))
                {
                    if (string.IsNullOrWhiteSpace(catName))
                    {
                        return false;
                    }
                    var cat = (from c in db.BookCategory where c.Name == catName select c).FirstOrDefault();
                    if (cat == null)
                    {
                        db.BookCategory.Add(new BookCategories { Name = catName });
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Adds a category to a book
        /// </summary>
        /// <param name="adminId">Admin Id</param>
        /// <param name="bookId">Bok Id</param>
        /// <param name="catId">Kategori Id</param>
        /// <returns>Bool</returns>
        public bool AddBookToCategory(int adminId, int bookId, int catId)
        {
            if (IsUserAdmin(adminId))
            {
                var book = (from b in db.Books where b.Id == bookId select b).FirstOrDefault();
                if (book != null)
                {
                    book.Category = (from c in db.BookCategory where c.Id == catId select c).FirstOrDefault();
                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// If category exists update category
        /// </summary>
        /// <param name="adminId">Admin Id</param>
        /// <param name="catId">Categori Id</param>
        /// <param name="catName">Category Name</param>
        /// <returns>Bool</returns>
        public bool UpdateCategory(int adminId, int catId, string catName)
        {
            try
            {
                if (IsUserAdmin(adminId) && !string.IsNullOrEmpty(catName))
                {
                    var cat = (from c in db.BookCategory where c.Id == catId select c).FirstOrDefault();
                    if (cat != null)
                    {
                        cat.Name = catName;
                        db.BookCategory.Update(cat);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Delete category if no books in category
        /// </summary>
        /// <param name="adminId">Admin Id</param>
        /// <param name="catId">Kategori Id</param>
        /// <returns>Bool</returns>
        public bool DeleteCategory(int adminId, int catId)
        {
            if (IsUserAdmin(adminId))
            {
                var books = (from b in db.Books where b.Category.Id == catId select b).FirstOrDefault();
                if (books == null)
                {
                    var cat = (from c in db.BookCategory where c.Id == catId select c).FirstOrDefault();
                    if (cat != null)
                    {
                        db.BookCategory.Remove(cat);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Add user as Admin
        /// </summary>
        /// <param name="adminId">Admin Id</param>
        /// <param name="userName">UserName</param>
        /// <param name="passWord">Password</param>
        /// <returns>Bool</returns>
        public bool AddUser(int adminId, string userName, string passWord)
        {
            try
            {
                if (IsUserAdmin(adminId) && !string.IsNullOrWhiteSpace(passWord) && !string.IsNullOrEmpty(userName))
                {
                    var user = (from u in db.Users where u.Name == userName select u).FirstOrDefault();
                    if (user == null)
                    {
                        db.Users.Add(new User { Name = userName, Password = passWord, IsActive = true });
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Get list of sold books
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>List</returns>
        public IEnumerable<SoldBooks> SoldItems(int adminId)
        {
            if (IsUserAdmin(adminId))
            {
                return from sb in db.SoldBooks select sb;
            }
            return new SoldBooks[0];
        }

        /// <summary>
        /// Checks the sum of sold book
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>The sum of soldbooks</returns>
        public int MoneyEarned(int adminId)
        {
            if (IsUserAdmin(adminId))
            {
                var sum = (from s in db.SoldBooks select s.Price).Sum();
                return sum;
            }
            return 0;
        }

        /// <summary>
        /// Checks who has bougth the most books
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>User</returns>
        public User BestCustomer(int adminId)
        {
            if (IsUserAdmin(adminId))
            {
                var mostBooks = (from b in db.SoldBooks
                                 group b.User.ID by b.User.ID into b
                                 orderby b.Count()
                                 descending
                                 select b.Key).FirstOrDefault();

                var user = (from u in db.Users where u.ID == mostBooks select u).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
            }
            return new User { };
        }

        /// <summary>
        /// Upgrade user to admin
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        public bool Promote(int adminId, int userId)
        {
            if (IsUserAdmin(adminId))
            {
                var user = (from u in db.Users where u.ID == userId select u).FirstOrDefault();
                if (user != null)
                {
                    user.IsAdmin = true;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Downgrade a admin to user
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        public bool Demote(int adminId, int userId)
        {
            if (IsUserAdmin(adminId))
            {
                var user = (from u in db.Users where u.ID == userId select u).FirstOrDefault();
                if (user != null)
                {
                    user.IsAdmin = false;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Activates a user
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        public bool ActiveUser(int adminId, int userId)
        {
            if (IsUserAdmin(adminId))
            {
                var user = (from u in db.Users where u.ID == userId select u).FirstOrDefault();

                if (user != null)
                {
                    user.IsActive = true;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Inactivate a user
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        public bool InactiveUser(int adminId, int userId)
        {
            if (IsUserAdmin(adminId))
            {
                var user = (from u in db.Users
                            where u.ID == userId
                            select u).FirstOrDefault();

                if (user != null)
                {
                    user.IsActive = false;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}