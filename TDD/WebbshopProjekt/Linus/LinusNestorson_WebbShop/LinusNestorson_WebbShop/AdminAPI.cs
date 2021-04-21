using LinusNestorson_WebbShop.Database;
using LinusNestorson_WebbShop.Helpers;
using LinusNestorson_WebbShop.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinusNestorson_WebbShop
{
    public class AdminAPI
    {
        //Help "pointers" to get access to helpers
        private AdminHelper adminHelp = new AdminHelper();
        private BookHelper bookHelp = new BookHelper();
        private ShopContext context = new ShopContext();
        private UserHelper userHelp = new UserHelper();

        /// <summary>
        /// Allow admin to set user to active.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="userId">Id of user to set to active</param>
        /// <returns>Return true if user was changed to active, false if something fails </returns>
        public bool ActivateUser(int adminId, int userId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsActive = true;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Adds book to database based on input. If book exist, add amount to existing book.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="title">Title of book</param>
        /// <param name="author">Author of book</param>
        /// <param name="price">Price of book</param>
        /// <param name="amount">Amount of book to add to stock</param>
        /// <returns>return true if book was added or stock increased</returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                if (bookHelp.DoesBookExist(title))
                {
                    var book = context.Books.FirstOrDefault(b => b.Title == title);
                    book.Amount = book.Amount + amount;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    var newBook = new Book() { Title = title, Author = author, Price = price, Amount = amount };
                    context.Books.Add(newBook);
                    context.SaveChanges();
                    return true;
                }
            }
            else return false;
        }
        /// <summary>
        /// Add book to chosen category by admin.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="bookId">Id of book to add to category</param>
        /// <param name="categoryId">Id of chosen category</param>
        /// <returns>True if action is successful, false if not</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    book.Category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Allowes admin to add new category to database.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="name">Name of category to add</param>
        /// <returns>True if action is successful, false if not</returns>
        public bool AddCategory(int adminId, string name)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var newCategory = new Category() { Name = name };
                context.Categories.Add(newCategory);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Allows admin to add a new user.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="name">Name of user to add</param>
        /// <param name="password">Password of user to add</param>
        /// <returns>True if action is successful, false if not</returns>
        public bool AddUser(int adminId, string name, string password)
        {
            if (adminHelp.IfAdmin(adminId) && !userHelp.DoesUserExist(name))
            {
                if (password == String.Empty)
                {
                    var user = new User() { Name = name, Password = "Codic2021" };
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
                else
                { 
                    var user = new User() { Name = name, Password = password };
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
            }
            else return false;
        }
        /// <summary>
        /// To search for user that bough most books.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <returns>The user that bought most books or null if person was not admin</returns>
        /// Help for linq-syntax found on stack overflow, post by octavioccl. URL: https://bit.ly/3cJNxMn
        public int BestCustomer(int adminId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                try
                {
                    return context.SoldBooks.GroupBy(u => u.User.Id).OrderByDescending(u => u.Count()).Select(u => u.Key).First();
                }
                catch
                {
                    return 0;
                } 
            }
            else return 0;
        }
        /// <summary>
        /// Allows admin to delete books from database, one at a time.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="bookId">Id of book to delete from database</param>
        /// <returns>Return true or false based on if action was success or fail</returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    book.Amount = book.Amount - 1;
                    if (book.Amount <= 0)
                    {
                        context.Books.Remove(book);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        context.Books.Update(book);
                        context.SaveChanges();
                        return true;
                    }
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Allows admin to delete category from database.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="categoryId">CategoryId of the category to be deleted</param>
        /// <returns>Returns tru if sucessful, else return false</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                var book = context.Books.FirstOrDefault(b => b.Category.Id == categoryId);
                if (category != null && book == null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Allows admin to demote a user from admin to normal user.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="userId">Id of user to demote</param>
        /// <returns>Return true if successful, else return false</returns>
        public bool Demote(int adminId, int userId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsAdmin = false;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Allows admin to search for users with a name with a specific keyword.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="keyword">Specific keyword to serach database for</param>
        /// <returns>List of matching users</returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                return context.Users.Where(u => u.Name.Contains(keyword)).OrderBy(u => u.Name).ToList();
            }
            return null;
        }
        /// <summary>
        /// Allows admin to set an user to inactive.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="userId">Id of user to set to inactive</param>
        /// <returns>True if user is set to inactive, false if not</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsActive = false;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Allows admin to see a list of all users.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <returns>Returns list of user or null if user was not admin </returns>
        public List<User> ListUsers(int adminId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                return context.Users.OrderBy(u => u.Name).ToList();
            }
            return null;
        }
        /// <summary>
        /// Allows admin to see how much money was earned from selling books.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <returns>Return the sum or zero</returns>
        public int MoneyEarned(int adminId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                return context.SoldBooks.Sum(b => b.Price);
            }
            else return 0;
        }
        /// <summary>
        /// Allows admin to promote user to Admin.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="userId">Id of user to promote</param>
        /// <returns>Return true or false based on success of action</returns>
        public bool Promote(int adminId, int userId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsAdmin = true;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Allows admin to set the amount of a book in store.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="bookId">Id of book to change number in stock</param>
        /// <param name="amount">Amount of books to set the stock to</param>
        /// <returns>Return true or false based on success of action</returns>
        public int SetAmount(int adminId, int bookId, int amount)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    book.Amount = amount;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return amount;
                }
                else return 0;
            }
            else return 0;
        }
        /// <summary>
        /// Allows admin to see all sold items.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <returns>REturn list of sold books or null if person wasn't admin</returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                return context.SoldBooks.OrderBy(b => b.Title).ToList();
            }
            else return null;
        }
        /// <summary>
        /// Allows admin to update a specific book with Title, Author and Price.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="bookId">Id of the book to be updated</param>
        /// <param name="title">Title of book to be updated</param>
        /// <param name="author">Author of book to be updated</param>
        /// <param name="price">Price of book to be updated</param>
        /// <returns>True if action was successful, false if not</returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            if (adminHelp.IfAdmin(adminId) && bookHelp.DoesBookExist(bookId))
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    book.Title = title; book.Author = author; book.Price = price;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Allows admin to update.
        /// </summary>
        /// <param name="adminId">AdminId to see if action is allowed</param>
        /// <param name="categoryId">Id of category to be updated</param>
        /// <param name="catName">New name of category</param>
        /// <returns>Return true if successful, false if not</returns>
        public bool UpdateCategory(int adminId, int categoryId, string catName)
        {
            if (adminHelp.IfAdmin(adminId))
            {
                var category = context.Categories.FirstOrDefault(b => b.Id == categoryId);
                if (category != null)
                {
                    category.Name = catName;
                    context.Categories.Update(category);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}

