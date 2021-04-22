using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPIGustafMalmsten.Database;
using WebbShopAPIGustafMalmsten.Model;

namespace WebbShopAPIGustafMalmsten
{
    class Databas : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories {get;set;}
        public DbSet<SoldBook> SoldBooks { get; set; }
        public DbSet<User> Users { get; set; }

        internal Seeder Seeder
        {
            get => default;
            set
            {
            }
        }

        public BookCategory BookCategory
        {
            get => default;
            set
            {
            }
        }

        public Book Book
        {
            get => default;
            set
            {
            }
        }

        public SoldBook SoldBook
        {
            get => default;
            set
            {
            }
        }

        public User User
        {
            get => default;
            set
            {
            }
        }

        public string DatabaseName = "WebbShopAPIGustafMalmsten.db";
        /// <summary>
        /// Configures the Database
        /// </summary>
        /// <param name="optionsBuilder">The builder used to create or modify options</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {         
            optionsBuilder.UseSqlServer(@$"Server=.\SQLEXPRESS; Database={DatabaseName};trusted_connection=true;");
        }
        /// <summary>
        /// The method that seeds some data if none are present
        /// </summary>
        public void Seed()
        {
            if (!BookCategories.Any() && !Books.Any() && !SoldBooks.Any() && !Users.Any())
            {
                Seeder seeder = new(this);
                seeder.Seed();
            }
        }
        /// <summary>
        /// Adds the item to the corresponding table
        /// </summary>
        /// <typeparam name="T">This method takes a generic input. In this case the program handles
        /// types Book, SoldBook, BookCategory and User</typeparam>
        /// <param name="item">The item to add.</param>
        public void Create<T>(T item)
        {
            if (item is Book book) 
            {
                Books.Add(book);
            }
            else if (item is BookCategory bookCategory)
            {
                BookCategories.Add(bookCategory);
            }
            else if (item is SoldBook soldBook)
            {
                SoldBooks.Add(soldBook);
            }
            else if (item is User user) 
            {
                Users.Add(user);
            }
            SaveChanges();
        }
        /// <summary>
        /// Delets an item from the corresponding table
        /// </summary>
        /// <typeparam name="T">This method takes a generic input. In this case the program handles
        /// types Book, SoldBook, BookCategory and User</typeparam>
        /// <param name="item">The item to delete.</param>
        public void Delete<T>(T item)
        {
            if (item is Book book)
            {
                Books.Remove(book);
            }
            else if (item is BookCategory bookCategory)
            {
                BookCategories.Remove(bookCategory);
            }
            else if (item is SoldBook soldBook)
            {
                SoldBooks.Remove(soldBook);
            }
            else if (item is User user)
            {
                Users.Remove(user);
            }
            SaveChanges();
        }
        /// <summary>
        /// Updates the User object in the database
        /// </summary>
        /// <param name="user">The User to update</param>
        public void Update(User user)
        {
            User user1 = Users.FirstOrDefault(u => u.UserID == user.UserID);
            user1.IsActive = user.IsActive;
            user1.IsAdmin = user.IsAdmin;
            user1.LastLogin = user.LastLogin;
            user1.Name = user.Name;
            user1.Password = user.Password;
            user1.SessionTimer = user.SessionTimer;
            Users.Update(user1);
            SaveChanges();
        }
        /// <summary>
        /// Updates the Book object in the database
        /// </summary>
        /// <param name="book">The Book to update</param>
        public void Update(Book book)
        {
            Book book1 = Books.FirstOrDefault(b => b.ID == book.ID);
            book1.Title = book.Title;
            book1.Author = book.Author;
            book1.Price= book.Price;
            book1.Amount= book.Amount;
            book1.BookCategoryID= book.BookCategoryID;
            Books.Update(book1);
            SaveChanges();
        }
        /// <summary>
        /// Updates the BookCategory object in the database
        /// </summary>
        /// <param name="bookCategory">The BookCategory to update</param>
        public void Update(BookCategory bookCategory)
        {
            BookCategory bc1 = BookCategories.FirstOrDefault(bc => bc.BookCategoryID == bookCategory.BookCategoryID);
            bc1.BookCategoryName = bookCategory.BookCategoryName;
            BookCategories.Update(bc1);
            SaveChanges();
        }
        /// <summary>
        /// Updates the SoldBook object in the database
        /// </summary>
        /// <param name="soldBook">The SoldBook to update</param>
        public void Update(SoldBook soldBook)
        {
            SoldBook sb = SoldBooks.FirstOrDefault(b => b.ID == soldBook.ID);
            sb.Title = soldBook.Title;
            sb.Author = soldBook.Author;
            sb.Price = soldBook.Price;
            sb.BookCategoryID = soldBook.BookCategoryID;
            sb.PurchaseDate = soldBook.PurchaseDate;
            sb.UserID= soldBook.UserID;
            SoldBooks.Update(sb);
            SaveChanges();
        }
        /// <summary>
        /// Returns a bookcategory to the corresponding id
        /// </summary>
        /// <param name="id">The id of the BookCategory to retreive</param>
        /// <returns>Bookcategory to the corresponding id</returns>
        public BookCategory ReadBookCategory(int id)
        {
            BookCategory bookCategory = BookCategories.Find(id);
            return bookCategory;
        }
        /// <summary>
        /// Returns all bookcategories
        /// </summary>
        /// <returns>All bookcategories in the database</returns>
        public List<BookCategory> ReadBookCategories()
        {
            return BookCategories.ToList();
        }
        /// <summary>
        /// Returns a list of BookCategory which BookCategory.Name are matching the keyword
        /// </summary>
        /// <param name="keyword">The name to match</param>
        /// <returns>All matching BookCategories</returns>
        public List<BookCategory> ReadBookCategories(string keyword)
        {
            if (Int32.TryParse(keyword, out _)) 
            {
                var query = from categories in BookCategories
                            where categories.BookCategoryName.Contains(keyword) || categories.BookCategoryID.Equals(Convert.ToInt32(keyword))
                            select categories;
                return query.ToList();
            }
            else
            {
                var query = from categories in BookCategories
                            where categories.BookCategoryName.Contains(keyword)
                            select categories;
                return query.ToList();
            }
        }
        /// <summary>
        /// Returns all Books
        /// </summary>
        /// <returns>All Books in the database</returns>
        public List<Book> ReadBooks()
        {
            var query = from books in Books
                        select books;
            return query.ToList();
        }
        /// <summary>
        /// Returns a list of Books that matches the keyword with Title, Author, Price or ID
        /// </summary>
        /// <param name="keyword">The searchstring</param>
        /// <returns>All matching Books</returns>
        public List<Book> ReadBooks(string keyword)
        {
            if (Int32.TryParse(keyword, out _))
            {
                int temp = Convert.ToInt32(keyword);
                double temp2 = Convert.ToDouble(keyword);
                var query = from books in Books
                            where books.Author.Contains(keyword) || books.Title.Contains(keyword) ||
                            books.ID.Equals(temp) || books.Price.Equals(temp2)
                            select books;
                return query.ToList();
            }
            else
            {
                var query = from books in Books
                            where books.Author.Contains(keyword) || books.Title.Contains(keyword)
                            select books;
                return query.ToList();
            }
        }
        /// <summary>
        /// Returns a List of book with matching Category ID (i.e. Horror, Science Fiction etc.)
        /// </summary>
        /// <param name="categoryID">The ID to search for</param>
        /// <returns>A list of book with matching Category ID</returns>
        public List<Book> ReadBooks(int categoryID)
        {
            var query = from books in Books
                        where books.BookCategoryID == categoryID
                        select books;
            return query.ToList();
        }
        /// <summary>
        /// Returns a book with match to the corresponding id
        /// </summary>
        /// <param name="id">The Book.ID to match</param>
        /// <returns>A book with matching ID</returns>
        public Book ReadBook(int id)
        {
            Book book = Books.FirstOrDefault(b => b.ID == id);
            return book;
        }
        /// <summary>
        /// Returns a book with match to the corresponding title
        /// </summary>
        /// <param name="title">The title to match</param>
        /// <returns>A book with matching title</returns>
        public Book ReadBook(string title)
        {
            Book book = Books.FirstOrDefault(b => b.Title.Equals(title));
            return book;
        }
        /// <summary>
        /// Returns a User matching the keyword with User.ID
        /// </summary>
        /// <param name="id">The User.ID to match</param>
        /// <returns>A User with matching ID</returns>
        public User ReadUser(int id)
        {
            User user = Users.FirstOrDefault(u => u.UserID == id);
            return user;
        }
        /// <summary>
        /// Returns a User matching the keyword with User.Name
        /// </summary>
        /// <param name="username">The User.Name to match</param>
        /// <returns>A User with matching name</returns>
        public User ReadUser(string username)
        {
            User user = Users.FirstOrDefault(u => u.Name.Equals( username));
            return user;
        }
        /// <summary>
        /// Returns all Users
        /// </summary>
        /// <returns>All Users in the database</returns>
        public List<User> ReadUsers()
        {
            var query = from users in Users
                        select users;
            return query.ToList();
        }
        /// <summary>
        /// Returns a list of users matching the keyword with User.Name
        /// </summary>
        /// <param name="keyword">The User.Name to match</param>
        /// <returns>A list of Users with matching name</returns>
        public List<User> ReadUsers(string keyword)
        {
            var query = from users in Users
                        where users.Name.Equals(keyword)
                        select users;
            return query.ToList();
        }
        /// <summary>
        /// Returns a list of sold books
        /// </summary>
        /// <returns>A list of sold books</returns>
        public List<SoldBook> ReadSoldBooks()
        {
            var query = from soldBooks in SoldBooks
                        select soldBooks;
            return query.ToList();
        }
    }
}
