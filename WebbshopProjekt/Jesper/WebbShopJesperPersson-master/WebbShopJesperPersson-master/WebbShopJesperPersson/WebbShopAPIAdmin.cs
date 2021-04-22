using System.Collections.Generic;
using System.Linq;
using WebbShopJesperPersson.Model;

namespace WebbShopJesperPersson
{
    public class WebbShopAPIAdmin : WebbShopAPI
    {
        /// <summary>
        /// Activate a user that been inactive.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true if user is active. False if not admin or user dosen´t exist.</returns>
        public bool ActivateUser(int adminId, int userId)
        {
            var user = GetUser(userId);
            if (IsAdmin(adminId) && user != null)
            {
                user.IsActive = true;
                context.Update(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a new book in database. If book already exists the amount will update.
        /// </summary>
        /// <param name="adminID">to succeed to add a new bok.</param>
        /// <param name="title">of the book.</param>
        /// <param name="author">of the book.</param>
        /// <param name="price">for the book.</param>
        /// <param name="amount">of the book.</param>
        /// <param name="id">to see if book already exist.</param>
        /// <returns>true if amount increases or a new book is added. False if nothing of theese works.</returns>
        public bool AddBook(int adminID, string title, string author, double price, int amount, int id = 0)
        {
            if (IsAdmin(adminID))
            {
                var book = GetBook(id);

                if (book != null)
                {
                    book.Amount += amount;
                    context.Update(book);
                    context.SaveChanges();
                    return true;
                }
                else if (book == null)
                {
                    book = new Book() { Title = title, Author = author, Price = price, Amount = amount };
                    context.Books.Add(book);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            return false;
        }

        /// <summary>
        /// Connect a category to a book, the category needs to exist in database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns>true if succeed. False if failure.</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var book = GetBook(bookId);
            var bookCategory = GetCategoryById(categoryId);
            if (bookCategory != null && IsAdmin(adminId))
            {
                book.Category = bookCategory;
                context.Update(book);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// To add a category in database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name">of the category.</param>
        /// <returns>true if succeed. False if failure.</returns>
        public bool AddCategory(int adminId, string name)
        {
            var bookCategory = context.Categories.FirstOrDefault(c => c.Name == name);
            if (bookCategory == null && IsAdmin(adminId))
            {
                context.Categories.Add(new BookCategory { Name = name });
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Add a new user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name">Must contain a value.</param>
        /// <param name="password">Must contain a value.</param>
        /// <returns>True if user i added. False if failure.</returns>
        public bool AddUser(int adminId, string name, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == name);

            if (IsAdmin(adminId) && user == null && password != string.Empty && name != string.Empty) // name or password can´t be null.
            {
                context.Users.Add(new User { Name = name, Password = password });
                context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the user that bought most books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>Object of the user that bought most. If none is sold or non-admnin it returns null.</returns>
        public User BestCustomer(int adminId)
        {
            var anySoldBooks = context.SoldBooks.FirstOrDefault();
            if (anySoldBooks != null && IsAdmin(adminId))
            {
                var bestcustommer = context.SoldBooks.GroupBy(s => s.User.Id).OrderByDescending(u => u.Count()).Select(s => s.Key).First();

                return GetUser(bestcustommer);
            }
            else return null;
        }

        /// <summary>
        /// Gets all book that a user bought.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userid"></param>
        /// <returns>A list of Sold Books conected to a user. If not admin null.</returns>
        public List<SoldBook> BoughtBooks(int adminId, int userid) // Var inte med i uppgiften men trevligt att se sin köphistorik.
        {
            if (IsAdmin(adminId))
                return context.SoldBooks.Where(u => u.User.Id == userid).ToList();
            else return null;
        }

        /// <summary>
        /// Reduce amount with 1 or deletes book if amount is 0. .
        /// </summary>
        /// <param name="admninId"></param>
        /// <param name="bookId"></param>
        /// <returns>true if succeed. False if failure.</returns>
        public bool DeleteBook(int admninId, int bookId)
        {
            var book = GetBook(bookId);
            if (book != null && IsAdmin(admninId))
            {
                book.Amount--;
                if (book.Amount < 1)
                    context.Books.Remove(book);

                context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteCategory(int adminId, int categoryId)
        {
            var bookCategory = context.Categories.FirstOrDefault(c => c.Id == categoryId);
            var book = context.Books.FirstOrDefault(c => c.Category.Id == categoryId);

            if (IsAdmin(adminId) && bookCategory != null && book == null)
            {
                context.Categories.Remove(bookCategory);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Downgrade an user to non-admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>True if succeeded. False if non admin or user dosen´t exist.</returns>
        public bool Demote(int adminId, int userId)
        {
            var user = GetUser(userId);
            if (IsAdmin(adminId) && user != null)
            {
                user.IsAdmin = false;
                context.Update(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets users by searching with keyword.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword">in the username.</param>
        /// <returns>A list of users where usernames contains the keyword</returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            if (IsAdmin(adminId))
                return context.Users.Where(u => u.Name.Contains(keyword)).OrderBy(u => u.Name).ToList();
            else return null;
        }

        /// <summary>
        /// Set user to inactive.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true if suceed. False if not admin or user dosen´t exist.</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            var user = GetUser(userId);
            if (IsAdmin(adminId) && user != null)
            {
                user.IsActive = false;
                context.Update(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>A list of Users. Sorted by name.</returns>
        public List<User> ListUsers(int adminId)
        {
            if (IsAdmin(adminId))
                return context.Users.Select(row => row).OrderBy(u => u.Name).ToList();
            else return null;
        }

        /// <summary>
        /// Sums up earned money from sold books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>the sum of sold books. 0 if not admin.</returns>
        public double MoneyEarned(int adminId)
        {
            if (IsAdmin(adminId))
                return context.SoldBooks.Select(s => s.Price).Sum();
            else return 0; // returns 0 for non admins.
        }

        /// <summary>
        /// Upgrade an user to admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>True if succeed. False if non-admin or user dosen´t exist.</returns>
        public bool Promote(int adminId, int userId)
        {
            var user = GetUser(userId);
            if (IsAdmin(adminId) && user != null)
            {
                user.IsAdmin = true;
                context.Update(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Manage the amounts of book. The value you send in will be the new amount.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount">the new amount of the book.</param>
        /// <returns>True if succeed. False if failure.</returns>
        public bool SetAmount(int adminId, int bookId, int amount)
        {
            var book = GetBook(bookId);
            if (book != null && IsAdmin(adminId))
            {
                book.Amount = amount;
                context.Update(book);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all registreted books that been sold.
        /// </summary>
        /// <param name="admindId"></param>
        /// <returns>A List of sold books. Can be empty if none is sold. Returns new empty list if not admin.</returns>
        public List<SoldBook> SoldItems(int admindId)
        {
            if (IsAdmin(admindId))
                return context.SoldBooks.Select(row => row).ToList();
            else return new List<SoldBook>() { };  // To avoid null-error. Could use null aswell, and null-check in controller.
        }

        /// <summary>
        /// Update information about a book. Updates all info.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns>True if succeed. False if failure.</returns>
        public bool UpdateBook(int adminId, int id, string title, string author, double price)
        {
            var book = GetBook(id);
            if (book != null && IsAdmin(adminId))
            {
                book.Title = title;
                book.Author = author;
                book.Price = price;
                context.Update(book);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the name of the category..
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="newCategoryName"></param>
        /// <returns>True if succeed. False if failure.</returns>
        public bool UpdateCategory(int adminId, int categoryId, string newCategoryName)
        {
            var bookCategory = GetCategoryById(categoryId);
            if (bookCategory != null && IsAdmin(adminId))
            {
                bookCategory.Name = newCategoryName;
                context.Categories.Update(bookCategory);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}