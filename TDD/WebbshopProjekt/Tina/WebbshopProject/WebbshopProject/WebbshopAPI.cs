using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebbshopProject.Database;
using WebbshopProject.Models;

namespace WebbshopProject
{
    public class WebbshopAPI
    {
        public static WebbshopDatabase db = new WebbshopDatabase();
        /// <summary>
        /// Linq question to database, to see if 
        /// the user with name and password is active.
        /// And sets lastlogin, and sessionTimer
        /// </summary>
        /// <param name="username">User of the programs username.</param>
        /// <param name="password">Password to login.</param>
        /// <returns>int userId</returns>
        public User Login(
            string username,
            string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == username &&
            u.Password == password && u.IsActive);
            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                db.Update(user);
                db.SaveChanges();
                return user;
            }

            return null;
        }

        /// <summary>
        /// Logging out user if sessionTimer has not 
        /// already done it automatically.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        public void Logout(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId &&
            u.SessionTimer > DateTime.Now.AddMinutes(-15));

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.Update(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// A search in database for all book categories in database
        /// </summary>
        /// <returns>List of categories</returns>
        public List<BookCategory> GetCategories()
        {
            List<BookCategory> listOfCategories = new List<BookCategory>();
            var categories = db.BookCategories;
            foreach(var category in categories)
            {
                listOfCategories.Add(category);
            }
            return listOfCategories;
        }

        /// <summary>
        /// A search in database for categories that matches the keyword.
        /// </summary>
        /// <param name="keyword">Keyword used in the search</param>
        /// <returns>list of categories matching keyword</returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            List<BookCategory> categories = new List<BookCategory>();
            if (string.IsNullOrEmpty(keyword))
            {
                return null;
            }

            var hits = db.BookCategories.Where(
                c => c.Name.Contains(keyword));
            foreach (var hit in hits)
            {
                categories.Add(hit);
            }

            return categories;
        }

        /// <summary>
        /// A search for books in a specific category, in database.
        /// </summary>
        /// <param name="categoryId">Id of the category selected</param>
        /// <returns>List of books in a specific category</returns>
        public List<Book> GetCategory(int categoryId)
        {
            List<Book> books = new List<Book>();
            var hits = db.Books.OrderBy(b => b.Title).Where(
                b => b.Category.Id == categoryId);
            foreach (var hit in hits)
            {
                books.Add(hit);
            }

            return books;
        }

        /// <summary>
        /// Search for books in specific category,
        /// database that has amount that is not 0.
        /// </summary>
        /// <param name="categoryid">Id of the category selected</param>
        /// <returns>A list of books in category</returns>
        public List<Book> GetAvailableBooks(int categoryid)
        {
            List<Book> listOfBooks = new List<Book>();
            var books = db.Books.OrderBy(b => b.Title).Where
                (b => b.Amount > 0 && b.Category.Id == categoryid);
            foreach(var book in books) 
            {
                listOfBooks.Add(book);
            }
            return listOfBooks;
        }

        /// <summary>
        /// Get a specific book, and read more info about it.
        /// </summary>
        /// <param name="bookId">Id of the book selected</param>
        /// <returns>Book of choice</returns>
        public Book GetBook(int bookId)
        {
            return db.Books.FirstOrDefault(b => b.Id == bookId);
        }

        /// <summary>
        /// Gets books that contains the keyword from database.
        /// </summary>
        /// <param name="keyword">Keyword used in the search</param>
        /// <returns>List of all books matching search</returns>
        public List<Book> GetBooks(string keyword)
        {
            List<Book> books = new List<Book>();
            var hits = db.Books.Where(b => b.Title.Contains(keyword));
            foreach (var hit in hits)
            {
                books.Add(hit);
            }

            return books;
        }

        /// <summary>
        /// Gets authors that contains the keyword from database.
        /// </summary>
        /// <param name="keyword">Keyword used in the search</param>
        /// <returns>List of authors matching keyword</returns>
        public List<Book> GetAuthors(string keyword)
        {
            List<Book> books = new List<Book>();
            var hits = db.Books.OrderBy(b => b.Author).Where
                (a => a.Author.Contains(keyword));
            foreach (var hit in hits)
            {
                books.Add(hit);
            }

            return books;
        }

        /// <summary>
        /// User can buy book, and then it gets moved
        /// from books till soldbooks.
        /// </summary>
        /// <param name="userId">Id of user using the program</param>
        /// <param name="bookId">Id of the book selected</param>
        /// <returns>true or false</returns>
        public bool BuyBook(int userId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId &&
            u.IsActive && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            if (user != null)
            {
                var book = db.Books.Include(b => b.Category).
                    FirstOrDefault(b => b.Id == bookId);
                if (book != null && book.Amount > 0)
                {
                    db.SoldBooks.Add(new SoldBook
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Category = book.Category,
                        Price = book.Price,
                        PurchaseDate = DateTime.Now,
                        User = user,
                    });

                    book.Amount -= 1;
                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Method that resets SessionTimer.
        /// </summary>
        /// <param name="userId">Id of the user using the program</param>
        /// <returns>Pong-message</returns>
        public bool Ping(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId &&
            u.IsActive && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            if (user != null)
            {
                user.SessionTimer = DateTime.Now;
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that registers a user
        /// to the database.
        /// </summary>
        /// <param name="username">Username of user using program</param>
        /// <param name="password">Password selected</param>
        /// <param name="passwordVerify">Verify of the password</param>
        /// <returns>true if verify matches password,
        /// and false if it does not.</returns>
        public bool Register(
            string username,
            string password,
            string passwordVerify)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            else
            {
                if (string.IsNullOrEmpty(password) &&
                    string.IsNullOrEmpty(passwordVerify))
                {
                    password = "Codic2021";
                    passwordVerify = "Codic2021";
                }

                var user = new User()
                {
                    Name = username,
                    Password = password,
                    IsActive = true,
                };

                if (passwordVerify == password)
                {
                    db.Users.Update(user);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Adds books, if book alredy exist.
        /// Creates and adds book, if it does 
        /// not exist.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <param name="bookId">Id of the book selected, if exists</param>
        /// <param name="bookTitle">Title of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="price">Price of the book</param>
        /// <param name="amount">Amount of the book sent in</param>
        /// <returns>true if books are added, 
        /// and false if user is not admin</returns>
        public bool AddBook(
            int userId,
            int? bookId,
            string bookTitle,
            string author,
            int price,
            int amount)
        {
                var book = db.Books.FirstOrDefault(
                    b => b.Title == bookTitle && b.Author == author);
                if (book == null)
                {
                    db.Books.Add(new Book
                    {
                        Title = bookTitle,
                        Author = author,
                        Price = price,
                        Amount = amount,
                    });

                    db.SaveChanges();
                    return true;
                }

                else 
                {
                    book.Amount += amount;
                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }
        }

        /// <summary>
        /// Search for book with specific book id.
        /// Then adds the amount sent in.
        /// IF user is admin.
        /// </summary>
        /// <param name="userId">Id of user of the program</param>
        /// <param name="bookId">Id of the book selected</param>
        /// <param name="amount">Amount of books to add</param>
        public void SetAmount(int userId,
            int bookId, int amount)
        {
                var book = db.Books.FirstOrDefault(
                    b => b.Id == bookId);
                book.Amount = amount;
                db.Books.Update(book);
                db.SaveChanges();
        }

        /// <summary>
        /// A search for users in database.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <returns>List of all users</returns>
        public List<User> ListUsers(int userId)
        {
            List<User> listOfUsers = new List<User>();
             var users = db.Users;
            foreach(var user in users)
            {
                listOfUsers.Add(user);
            }
            return listOfUsers;
        }

        /// <summary>
        /// Search for user that matches the keyword.
        /// </summary>
        /// <param name="userId">Id of the user using the program</param>
        /// <param name="keyword">The input to use for search</param>
        /// <returns>A list of users matching keyword.</returns>
        public List<User> FindUser(
            int userId, string keyword)
        {
            List<User> listOfUsers = new List<User>();
            var users = db.Users.Where(c => c.Name.Contains(keyword));
            foreach (var user in users)
            {
                listOfUsers.Add(user);
            }
            return listOfUsers;
        }

        /// <summary>
        /// Search for book with specific bookId,
        /// and updates the information about book
        /// with parameters sent in.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <param name="bookId">Id of the book selected</param>
        /// <param name="title">Title sent in</param>
        /// <param name="author">Author sent in</param>
        /// <param name="price">Price sent in</param>
        /// <returns>true if admin is active and logged in
        /// and false if not.</returns>
        public bool UpdateBook(
            int userId,
            int bookId,
            string title,
            string author,
            int price)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
            {
                return false;
            }

            else
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                book.Title = title;
                book.Author = author;
                book.Price = price;

                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Search for book with specific bookId,
        /// and then removes book. If amount is 0, 
        /// the whole book will be removed.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <param name="bookId">Id of the book selected.</param>
        /// <returns>true if admin is active and logged in
        /// and false if not.</returns>
        public bool DeleteBook(int userId, int bookId)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            book.Amount -= 1;
            if (book.Amount <= 0)
            {
                db.Remove(book);
            }
            db.Books.Update(book);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Adds a new category to the database, 
        /// that gets the name sent in parameter.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <param name="name">Name sent in to name the category</param>
        /// <returns>true if admin is active and logged in,
        /// false if not.</returns>
        public bool AddCategory(int userId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                db.BookCategories.Add(new BookCategory
                {
                    Name = name,
                });
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Search for book and category by Id, 
        /// and then adds found book to the found category.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <param name="bookId">Id of the book selected.</param>
        /// <param name="categoryId">Id of the category selected.</param>
        /// <returns>true if admin is active and logged in,
        /// false if not.</returns>
        public bool AddBookToCategory(
            int userId,
            int bookId,
            int categoryId)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            var cat = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);

            book.Category = cat;
            db.Books.Update(book);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Finds the categorie in the database, 
        /// and changes the name of it to the name
        /// sent in.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <param name="categoryId">Id of the category selected.</param>
        /// <param name="name">Name sent in to rename the category</param>
        /// <returns>true if admin is active and logged in,
        /// false if not.</returns>
        public bool UpdateCategory(int userId, int categoryId, string name)
        {
            var cat = db.BookCategories.
                FirstOrDefault(c => c.Id == categoryId);
            cat.Name = name;
            db.BookCategories.Update(cat);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Finds the specific category matcing the 
        /// id sent in and if it contains no books, 
        /// deletes it. Else it returns false.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <param name="categoryId">Id of the category selected.</param>
        /// <returns>true if admin is active and logged in,
        /// false if admin is not, or the category contains
        /// any books.</returns>
        public bool DeleteCategory(int userId, int categoryId)
        {
            var cat = db.BookCategories.
                FirstOrDefault(c => c.Id == categoryId);
            var books = db.Books.Where(b => b.Category == cat);
            if (books.Count() == 0)
            {
                db.Remove(cat);
                db.SaveChanges();
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// Search to see if username and password exists.
        /// If not user is created.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <param name="name">Username selected to add user.</param>
        /// <param name="password">Password selected for the user.</param>
        /// <returns>True if user is created. False if
        /// admin is not active and logged in, or user
        /// alredy exists.</returns>
        public bool AddUser(
            int userId,
            string name,
            string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            var userSearch = db.Users.FirstOrDefault(
                u => u.Name == name && u.Password == password);
            if (userSearch == null && password != " ")
            {
                if (string.IsNullOrEmpty(password))
                {
                    password = "Codic2021";
                }

                db.Users.Add(new User
                {
                    Name = name,
                    Password = password,
                    IsActive = true,
                    IsAdmin = false,
                });

                db.SaveChanges();
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// Searchs after all sold books in the database.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <returns>A list of books.</returns>
        public List<SoldBook> ListSoldBooks(int userId)
        {
            List<SoldBook> soldBooks = new List<SoldBook>();
            var booksSold = db.SoldBooks;
            foreach (var soldBook in booksSold)
            {
                soldBooks.Add(soldBook);
            }

            return soldBooks;
        }

        /// <summary>
        /// Search for soldbooks in database,
        /// and puts price of every book in list.
        /// Then adds the prices together.
        /// </summary>
        /// <returns>A sum of price from every
        /// book sold.</returns>
        public int MoneyEarned()
        {
            var moneyList = new List<int>();
            var soldBooks = db.SoldBooks;
            foreach (var book in soldBooks)
            {
                moneyList.Add(book.Price);
            }

            int moneyEarned = moneyList.Sum();
            return moneyEarned;
        }

        /// <summary>
        /// Sorts out the customers in soldBooks
        /// Then sorts out the customer that has
        /// bought the most books. Only for admins.
        /// </summary>
        /// <param name="userId">Id of the user using the program.</param>
        /// <returns></returns>
        public (User name, int books) BestCustomer(int userId)
        {
            var user = (new User(), 0);
            var list = new List<(User customer, int book)>();
            var customers = db.SoldBooks.
                Select(s => s.User).Distinct().ToList();
            foreach (var customer in customers)
            {
                var book = (db.SoldBooks.Count(b => b.User == customer));
                list.Add((customer, book));
            }
            return user;
        }
        /// <summary>
        /// Finds the user with the specific id.
        /// and promotes it to admin, if a admin is
        /// logged in and active.
        /// </summary>
        /// <param name="adminId">Id of the user using the program.</param>
        /// <param name="userId">Id of the person beeing promoted</param>
        /// <returns>True if changes was successfull.
        /// False if admin is not logged in and active,
        /// or if user does not exist or is active.</returns>

        public bool Promote(int adminId, int userId)
        {
            var user = db.Users.FirstOrDefault(
                u => u.Id == userId && u.IsActive);
            if (user != null)
            {
                user.IsAdmin = true;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds the user with the specific id.
        /// And demotes from admin , if a admin is
        /// logged in and active.
        /// </summary>
        /// <param name="adminId">Id of the user using the program.</param>
        /// <param name="userId">Id of the user beeing demoted</param>
        /// <returns>True if changes was successfull.
        /// False if admin is not logged in and active,
        /// or if user does not exist or is active.</returns>
        public bool Demote(int adminId, int userId)
        {
            var user = db.Users.FirstOrDefault(
                u => u.Id == userId && u.IsActive);
            if (user != null)
            {
                user.IsAdmin = false;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Search for a user with a specific id. 
        /// And then activates the user, if admin is
        /// logged in and active. 
        /// </summary>
        /// <param name="adminId">Id of the user using the program.</param>
        /// <param name="userId">Id of the person beeing activated</param>
        /// <returns>true if changes was successfull. 
        /// False if admin is not logged in and active, 
        /// or if user does not exist or is not active.</returns>
        public bool ActivateUser(int adminId, int userId)
        {
            var user = db.Users.FirstOrDefault(
                u => u.Id == userId);
            if (user != null)
            {
                user.IsActive = true;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Search for a user with a specific id. 
        /// And then inactivates the user, if admin is
        /// logged in and active. 
        /// </summary>
        /// <param name="adminId">Id of the user using the program.</param>
        /// <param name="userId">Id of the person beeing inactivated</param>
        /// <returns>true if changes was successfull. 
        /// False if admin is not logged in and active, 
        /// or if user does not exist</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            var user = db.Users.FirstOrDefault(
                u => u.Id == userId);
            if (user != null)
            {
                user.IsActive = false;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inserts mockdata to the database, to the tables:
        /// Users, BookCategories and Books.
        /// </summary>
        public static void Seed()
        {

            if (db.Users.Count() == 0)
            {
                db.Users.Add(new User
                {
                    Name = "Administrator",
                    Password = "CodicRulez",
                    IsAdmin = true,
                    IsActive = true
                });

                db.Users.Add(new User
                {
                    Name = "TestCustomer",
                    Password = "Codic2021",
                    IsAdmin = false,
                    IsActive = true
                });

                db.SaveChanges();
            }

            if (db.BookCategories.Count() == 0)
            {
                db.BookCategories.Add(new BookCategory
                {
                    Name = "Horror"
                });

                db.BookCategories.Add(new BookCategory
                {
                    Name = "Humor"
                });

                db.BookCategories.Add(new BookCategory
                {
                    Name = "Science Fiction"
                });

                db.BookCategories.Add(new BookCategory
                {
                    Name = "Romance"
                });

                db.SaveChanges();
            }

            if (db.Books.Count() == 0)
            {
                db.Books.Add(new Book
                {
                    Title = "Cabal (Nightbreed)",
                    Author = "Clive Barker",
                    Price = 250,
                    Amount = 3,
                    Category = db.BookCategories.
                    FirstOrDefault(c => c.Name == "Horror")
                });

                db.Books.Add(new Book
                {
                    Title = "The Shining",
                    Author = "Stephen King",
                    Price = 200,
                    Amount = 2,
                    Category = db.BookCategories.
                    FirstOrDefault(c => c.Name == "Horror")
                });

                db.Books.Add(new Book
                {
                    Title = "Doctor Sleep",
                    Author = "Stephen King",
                    Price = 200,
                    Amount = 1,
                    Category = db.BookCategories.
                    FirstOrDefault(c => c.Name == "Horror")
                });

                db.Books.Add(new Book
                {
                    Title = "I Robot",
                    Author = "Isaac Asimov",
                    Price = 150,
                    Amount = 4,
                    Category = db.BookCategories.
                    FirstOrDefault(c => c.Name == "Science Fiction")
                });

                db.SaveChanges();
            }
        }
    }
}
