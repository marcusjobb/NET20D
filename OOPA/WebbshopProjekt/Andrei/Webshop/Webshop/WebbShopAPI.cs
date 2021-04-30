using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopApi.Database;
using WebbShopApi.Models;

namespace WebbShopApi
{
    /// <summary>
    /// Defines the <see cref="WebbShopAPI" />.
    /// </summary>
    public static class WebbShopAPI
    {
        /// <summary>
        /// Defines the context[<see cref="MyContext"/>]
        /// </summary>
        private static MyContext context = new MyContext();

        /// <summary>
        /// Defines the temporary <see cref="User"/>
        /// </summary>
        private static User tempUser;



        /// <summary>
        /// Login the <see cref="User"/>
        /// </summary>
        /// <param name="username">used to specify username <see cref="User.Name"/></param>
        /// <param name="password">used to specify password <see cref="User.Password"/></param>
        /// <returns>user id if success; 0 if user doesn't exist [<see cref="int"/>]</returns>
        public static int Login(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            tempUser = user;
            try
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
                return user.UserId;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("[Login] Can't find the user.");
            }
            return 0;
        }

        /// <summary>
        /// Logout the <see cref="User"/>
        /// </summary>
        /// <param name="userId">used to specify user id <see cref="User.UserId"/></param>
        public static void Logout(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == userId && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            try
            {
                user.SessionTimer = DateTime.MinValue;
                context.Users.Update(user);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("[Logout] Can't find the user.");
            }

        }

        /// <summary>
        /// Get all books in store sorted by name
        /// </summary>
        public static List<Book> GetAllBooks() => context.Books.OrderBy(b => b.Name).ToList();

        /// <summary>
        /// Get all users sorted by name
        /// </summary>
        public static List<User> GetAllUsers() => context.Users.OrderBy(u => u.Name).ToList();


        /// <summary>
        /// List all <see cref="BookCategory"/>
        /// </summary>
        /// <returns><see cref="List{BookCategory}"/></returns>
        public static List<BookCategory> GetCategories() => context.BookCategories.OrderBy(c => c.BookCategoryId).ToList();


        /// <summary>
        /// List of <see cref="BookCategory"/>s matching keyword
        /// </summary>
        /// <param name="keyword">used to specifie keyword <see cref="string"/></param>
        /// <returns><see cref="List{BookCategory}"/></returns>
        public static List<BookCategory> GetCategories(string keyword) => context.BookCategories.Where(c => c.Name.Contains(keyword)).OrderBy(c => c.Name).ToList();


        /// <summary>
        /// List of <see cref="Book"/>s in <see cref="BookCategory"/>
        /// </summary>
        /// <param name="categoryId">Category Id <see cref="int"/></param>
        /// <returns><see cref="List{Book}"/></returns>
        public static List<Book> GetCategory(int userId, int categoryId)
        {
            UpdateSession(userId);
            return context.Books.Where(b => b.BookCategoryId == categoryId).OrderBy(b => b.Name).ToList();
        }

        /// <summary>
        /// List of <see cref="Book"/>s in <see cref="BookCategory"/>
        /// </summary>
        /// <param name="categoryId">Category Id <see cref="int"/></param>
        /// <returns><see cref="List{Book}"/></returns>
        public static BookCategory GetCategoryById(int userId, int categoryId)
        {
            if (IsAdmin(userId)) {
                UpdateSession(userId);
                return context.BookCategories.FirstOrDefault(c => c.BookCategoryId == categoryId);
            }
            return new BookCategory();
        }

        /// <summary>
        /// List of <see cref="Book"/>s with amount>0
        /// </summary>
        /// <param name="categoryId">used to specify category id <see cref="int"/></param>
        /// <returns><see cref="List{Book}"/></returns>
        public static List<Book> GetBooksFromCategory(int userId, int categoryId)
        {
            UpdateSession(userId);
            return context.Books.Where(b => b.BookCategoryId == categoryId).OrderBy(b => b.Name).ToList();
        }

        /// <summary>
        /// Get information about  <see cref="Book"/>
        /// </summary>
        /// <param name="bookId">used to specify book id <see cref="int"/></param>
        /// <returns>Book object <see cref="Book"/></returns>
        public static Book GetBook(int userId, int bookId)
        {
            UpdateSession(userId);
            return context.Books.FirstOrDefault(b => b.BookId == bookId);
        }

        /// <summary>
        /// List of <see cref="Book"/>s matching keyword
        /// </summary>
        /// <param name="keyword">used to specifie keyword <see cref="string"/></param>
        /// <returns><see cref="List{Book}"/></returns>
        public static List<Book> GetBooks(int userId, string keyword)
        {
            UpdateSession(userId);
            return context.Books.Where(b => b.Name.Contains(keyword)).OrderBy(b => b.Name).ToList();
        }

        /// <summary>
        /// List of <see cref="Book"/>s matching keyword in author
        /// </summary>
        /// <param name="keyword">used to specify keyword <see cref="string"/></param>
        /// <returns><see cref="List{Book}"/></returns>
        public static List<Book> GetAuthors(int userId, string keyword)
        {
            UpdateSession(userId);
            return context.Books.Where(b => b.Author.Contains(keyword)).OrderBy(b => b.Name).ToList();
        }

        /// <summary>
        /// Buy a <see cref="Book"/> from the store. 
        /// </summary>
        /// <param name="userId">user id <see cref="int"/></param>
        /// <param name="bookId">book id <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool BuyBook(int userId, int bookId)
        {
            
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) { return false; };
            var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book == null) { return false; }
            if (book.Amount <= 0) { return false; }

            UpdateSession(userId);
            context.SoldBooks.Add(
                new SoldBook
                {
                    Author = book.Author,
                    BookCategoryId = book.BookCategoryId,
                    Price = book.Price,
                    PurchaseDate = DateTime.Now,
                    Title = book.Name,
                    UserId = userId
                });
            book.Amount--;
            context.Books.Update(book);
            context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Check if <see cref="User"/> is online
        /// </summary>
        /// <param name="userId">user id <see cref="int"/></param>
        /// <returns><see cref="string"/></returns>
        public static string Ping(int userId)
        {
            UpdateSession(userId);
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                return String.Empty;
            }
            return "Pong";
        }

        /// <summary>
        /// Get <see cref="User"/> object by Id
        /// </summary>
        /// <param name="userId">user id <see cref="int"/></param>
        /// <returns><see cref="User"/></returns>
        public static User GetUserById(int userId)
        {
            return context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        /// <summary>
        /// Register a new <see cref="User"/>
        /// </summary>
        /// <param name="name">Customer name <see cref="string"/></param>
        /// <param name="password">Password <see cref="string"/></param>
        /// <param name="passwordVerify">Repeat password  <see cref="string"/></param>
        /// <returns> <see cref="bool"/></returns>
        public static bool Register(string name, string password, string passwordVerify)
        {
            if (password == passwordVerify)
            {
                context.Users.Add(new User { Name = name, Password = password });
                context.SaveChanges();
                return true;
            }
            return false;
        }

        // ADMIN FUNCTIONS BELOW

        /// <summary>
        /// Add a new <see cref="Book"/>.
        /// Change the amount if the <see cref="Book"/> exist.
        /// </summary>
        /// <param name="adminId">user id  <see cref="int"/></param>
        /// <param name="Id">book id  <see cref="int"/></param>
        /// <param name="title">book title  <see cref="string"/></param>
        /// <param name="author">author  <see cref="string"/></param>
        /// <param name="price">price <see cref="int"/></param>
        /// <param name="amount">amount <see cref="int"/></param>
        /// <returns> <see cref="bool"/></returns>
        public static bool AddBook(int adminId, int Id, string title, string author, int price, int amount, int bookCategoryId)
        {
            var book = context.Books.FirstOrDefault(b => b.BookId == Id && b.Name == title);
            if (IsAdmin(adminId))
            {
                UpdateSession(adminId);
                if (book == null)
                {
                    context.Books.Add(new Book { Name = title, Author = author, Price = price, Amount = amount, BookCategoryId = bookCategoryId });
                    context.SaveChanges();
                    return true;
                }
                else if (book != null)
                {
                    Console.WriteLine("ADD BOOK NOT OK");
                    book.Amount += amount;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Set amount of available <see cref="Book"/>s
        /// </summary>
        /// <param name="adminId">user id  <see cref="int"/></param>
        /// <param name="bookId">book id  <see cref="int"/></param>
        /// <param name="amount">amount  <see cref="int"/></param>
        public static void SetAmount(int adminId, int bookId, int amount)
        {
            if (IsAdmin(adminId))
            {
                try
                {
                    UpdateSession(adminId);
                    var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                    book.Amount = amount;
                    context.Books.Update(book);
                    context.SaveChanges();
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("[SetAmount] Can't find the book");
                }
                catch (Exception e)
                {
                    Console.WriteLine("[SetAmount] Something went wrong ...");
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        /// List all <see cref="User"/>s by name
        /// </summary>
        /// <param name="adminId">user id  <see cref="int"/></param>
        /// <returns> <see cref="List{User}"/></returns>
        public static List<User> ListUsers(int adminId)
        {
            if (IsAdmin(adminId))
            {
                UpdateSession(adminId);
                return context.Users.OrderBy(u => u.Name).ToList();
            }
            return new List<User>();
        }

        /// <summary>
        /// Find <see cref="User"/> by keyword
        /// </summary>
        /// <param name="adminId">user(admin) id <see cref="int"/></param>
        /// <param name="keyword">kyword used to find users <see cref="string"/></param>
        /// <returns><see cref="List{User}"/></returns>
        public static List<User> FindUser(int adminId, string keyword)
        {
            if (IsAdmin(adminId))
            {
                UpdateSession(adminId);
                return context.Users.Where(u => u.Name.Contains(keyword)).OrderBy(u => u.Name).ToList();
            }
            return new List<User>();
        }

        /// <summary>
        /// Update the <see cref="Book"/>
        /// </summary>
        /// <param name="adminId">user id <see cref="int"/></param>
        /// <param name="title">new book title <see cref="string"/></param>
        /// <param name="author">new author <see cref="string"/></param>
        /// <param name="price">new price <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool UpdateBook(int adminId, int bookId, string title, string author, int price, int amount, int bookCategoryId)
        {
            try
            {
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    var book = context.Books.FirstOrDefault(b => b.BookId == bookId);

                    book.Name = title;
                    book.Author = author;
                    book.Price = price;
                    book.Amount = amount;
                    book.BookCategoryId = bookCategoryId;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("[UpdateBook] Can't find the book");
            }
            catch (Exception e)
            {
                Console.WriteLine("[UpdateBook] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Delete the <see cref="Book"/>
        /// </summary>
        /// <param name="adminId">user id <see cref="int"/></param>
        /// <param name="bookId">book id <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool DeleteBook(int adminId, int bookId)
        {
            try
            {
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                    context.Books.Remove(book);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("[DeleteBook] Can't find the book");
            }
            catch (Exception e)
            {
                Console.WriteLine("[DeleteBook] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Add a new <see cref="BookCategory"/>
        /// </summary>
        /// <param name="adminId">user id <see cref="int"/></param>
        /// <param name="name">category name <see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool AddCategory(int adminId, string name)
        {
            try
            {
                var category = context.BookCategories.FirstOrDefault(c => c.Name == name);
                if (IsAdmin(adminId) && category == null)
                {
                    UpdateSession(adminId);
                    context.BookCategories.Add(new BookCategory { Name = name });
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Category already exist");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[AddCategory] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Add <see cref="Book"/> to <see cref="BookCategory"/>
        /// </summary>
        /// <param name="adminId">user id <see cref="int"/></param>
        /// <param name="bookId">book id <see cref="int"/></param>
        /// <param name="categoryId">category id <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            try
            {
                var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                var category = context.BookCategories.FirstOrDefault(c => c.BookCategoryId == categoryId);
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    // make sure that the category exists
                    book.BookCategoryId = category.BookCategoryId;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("[AddBookToCategory] Can't find the book or category");
            }
            catch (Exception e)
            {
                Console.WriteLine("[AddBookToCategory] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Update <see cref="BookCategory"/> name
        /// </summary>
        /// <param name="adminId">user id <see cref="int"/></param>
        /// <param name="categoryId">category id <see cref="int"/></param>
        /// <param name="name">category name <see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool UpdateCategory(int adminId, int categoryId, string name)
        {
            try
            {
                var category = context.BookCategories.FirstOrDefault(c => c.BookCategoryId == categoryId);
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    category.Name = name;
                    context.BookCategories.Update(category);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("[UpdateCategory] Can't find user or category");
            }
            catch (Exception e)
            {
                Console.WriteLine("[UpdateCategory] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Delete <see cref="BookCategory"/>
        /// </summary>
        /// <param name="adminId">admin id <see cref="int"/></param>
        /// <param name="categoryId">category id <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool DeleteCategory(int adminId, int categoryId)
        {
            try
            {
                var category = context.BookCategories.FirstOrDefault(c => c.BookCategoryId == categoryId);
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    context.BookCategories.Remove(category);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("[DeleteCategory] Can't find your category");
            }
            catch (Exception e)
            {
                Console.WriteLine("[DeleteCategory] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Add a new <see cref="User"/>
        /// </summary>
        /// <param name="adminId">admin id <see cref="int"/></param>
        /// <param name="name">new user name <see cref="string"/></param>
        /// <param name="password">new user password <see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool AddUser(int adminId, string name, string password)
        {
            try
            {
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    context.Users.Add(new User { Name = name, Password = password });
                    context.SaveChanges();
                }
            }
            catch { Console.WriteLine("[AddUser] Something went wrong ..."); }
            return false;
        }

        /// <summary>
        /// List all <see cref="SoldBook"/>s sorted by title
        /// </summary>
        /// <param name="adminId">user id <see cref="int"/></param>
        /// <returns><see cref="List{SoldBook}"/></returns>
        public static List<SoldBook> SoldItems(int adminId)
        {
            if (IsAdmin(adminId))
            {
                UpdateSession(adminId);
                return context.SoldBooks.OrderBy(b => b.Title).ToList();
            }
            return new List<SoldBook>();
        }

        /// <summary>
        /// Check how much maney was earned
        /// </summary>
        /// <param name="adminId">user id <see cref="int"/></param>
        /// <returns><see cref="int"/></returns>
        public static int MoneyEarned(int adminId)
        {
            if (IsAdmin(adminId))
            {
                UpdateSession(adminId);
                if(context.SoldBooks.Count() > 0)
                {
                    return context.SoldBooks.Sum(b => b.Price);
                }
            }
            return 0;
        }

        /// <summary>
        /// Get <see cref="User"/> that bought most <see cref="Book"/>s
        /// </summary>
        /// <param name="adminId">user id <see cref="int"/></param>
        /// <returns>User ID: <see cref="int"/></returns>
        public static int BestCustomer(int adminId)
        {
            if (IsAdmin(adminId))
            {
                if (context.SoldBooks.Count() > 0)
                {
                    UpdateSession(adminId);
                    return context.SoldBooks.GroupBy(u => u.UserId).OrderByDescending(u => u.Count()).Select(u => u.Key).First();
                }
            }
            return 0;
        }

        /// <summary>
        /// Make a <see cref="User"/> an administrator
        /// </summary>
        /// <param name="adminId">admin id <see cref="int"/></param>
        /// <param name="userId">user id <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool Promote(int adminId, int userId)
        {
            try
            {
                var userToPromote = context.Users.FirstOrDefault(c => c.UserId == userId);
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    userToPromote.IsAdmin = true;
                    context.Users.Update(userToPromote);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("[Promote] Can't find the user");
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine("[Promote] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Demote admin
        /// </summary>
        /// <param name="adminId">admin id <see cref="int"/></param>
        /// <param name="secondAdminId">second admin id <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool Demote(int adminId, int secondAdminId)
        {
            try
            {
                var adminToDemote = context.Users.FirstOrDefault(c => c.UserId == secondAdminId);
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    adminToDemote.IsAdmin = false;
                    context.Users.Update(adminToDemote);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("[Demote] Can't find the user");
            }
            catch (Exception e)
            {
                Console.WriteLine("[Demote] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }


        /// <summary>
        /// Activate <see cref="User"/>
        /// </summary>
        /// <param name="adminId">admin id <see cref="int"/></param>
        /// <param name="userId">user id <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool ActivateUser(int adminId, int userId)
        {
            try
            {
                var user = context.Users.FirstOrDefault(c => c.UserId == userId);
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    user.IsActiove = true;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("[ActivateUser] Can't find the user");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ActivateUser] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Inactivate <see cref="User"/>
        /// </summary>
        /// <param name="adminId">admin id <see cref="int"/></param>
        /// <param name="userId">user id <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool InactivateUser(int adminId, int userId)
        {   
            try
            {
                var user = context.Users.FirstOrDefault(c => c.UserId == userId);
                if (IsAdmin(adminId))
                {
                    UpdateSession(adminId);
                    user.IsActiove = false;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("[InactivateUser] Can't find the user");
            }
            catch (Exception e)
            {
                Console.WriteLine("[InactivateUser] Something went wrong ...");
                Console.WriteLine(e);
            }
            return false;
        }


        /// <summary>
        /// Checks if a <see cref="User"/> with a given id is an administrator
        /// </summary>
        /// <param name="adminId">used to specify user id <see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        private static bool IsAdmin(int adminId)
        {
            try
            {
                if (context.Users.FirstOrDefault(u => u.UserId == adminId).IsAdmin)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Sorry. You don't have permissions!");
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("[IsAdmin] Can't find the user ...");
            }
            return false;
        }

        /// <summary>
        /// Updates user session.
        /// Logout if the session more than 15 min old.
        /// </summary>
        private static void UpdateSession(int id)
        {
            //Console.WriteLine($"[UpdateSession] Before {tempUser.Name} : {tempUser.SessionTimer}");
            var user = GetUserById(id);

            if ((DateTime.Now - user.SessionTimer).TotalMinutes >=15)
            {
                Logout(user.UserId);
            }
            else
            {
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
            }
            //Console.WriteLine($"[UpdateSession] After {tempUser.Name} : {context.Users.FirstOrDefault(u => u.UserId == tempUser.UserId).SessionTimer}");
        }

        /// <summary>
        /// Generate DB 
        /// </summary>
        public static void GenerateDB()
        {
            Seeder.Seed();
        }
    }
}
