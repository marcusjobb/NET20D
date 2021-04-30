using BookShop.Data;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Controllers
{
    /// <summary>
    /// Class to fill database tables with initial information. 
    /// </summary>
   public class Seeder
    {
        /// <summary>
        /// Adds initial books to table "Books".
        /// </summary>
        public void AddInitialBooks()
        {
            AddBooks("Cabal (Nightbreed)", "Clive Barker", 250, 3, "Horror");
            AddBooks("The Shining", "Stephen King", 200, 2, "Horror");
            AddBooks("Doctor Sleep", "Doctor Sleep", 200,1,"Horror");
            AddBooks("I Robot", "Isaac Asimov", 150,4,"Science Fiction");        
        }
        /// <summary>
        /// Adds book to table books if it doesn't exist, otherwhise it increases stock. Very similar to Addbook() in WebbShopAPI but doesn't require admin id and is only thought as a seeder function. 
        /// It also sets category id right away. 
        /// </summary>
        public void AddBooks(string title, string author, double price, int amount, string category)
        {
            using (var context = new BookShopContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Title == title && b.Author == author);
                if (book == null)
                {
                    Book newBook = new Book()
                    {
                        Title = title,
                        Author = author,
                        Price = price,
                        Amount = amount,
                        CategoryId = DetermineCategoryId(category)
                    };
                    context.Books.Add(newBook);
                    context.SaveChanges();
                }
                else if (book != null)
                {
                    book.Amount = book.Amount + amount;
                    context.Books.Update(book);
                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Adds initial users to table "Users".
        /// </summary>
        public void AddInitialUsers()
        {
            AddUser("Administrator", "CodicRulez", true);
            AddUser("TestClient", "Codic2021", false);
        }
        /// <summary>
        /// Adds user to table "Users". Admin id not required. Only thought as a seeder funtion.
        /// </summary>
        public void AddUser(string userName, string passWord, bool isAdmin)
        {
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == userName);
                if (user==null)
                {
                    user = new User()
                    {
                        Name = userName,
                        Password = passWord,
                        IsAdmin=isAdmin
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Adds initial categories to table "Categories". 
        /// </summary>
        public void AddInitialCategories()
        {
            AddCategory("Horror");
            AddCategory("Humor");
            AddCategory("Science Fiction");
            AddCategory("Romance");
        }
        /// <summary>
        /// Adds category to table "Categories". Admin id not required. Only thought as a seeder funtion.
        /// </summary>
        public void AddCategory(string categoryName)
        {                       
                using (var context = new BookShopContext())
                {
                    var category = context.BookCategories.FirstOrDefault(c=>c.Name==categoryName);
                    if (category == null)
                    {
                        category = new BookCategory()
                        {
                            Name = categoryName
                        };
                        context.Add(category);
                        context.SaveChanges();
                    }                    
                }                     
        }
        /// <summary>
        /// Determines category id of a specific category name. 
        /// </summary>
        /// <param name="category">Category name</param>
        /// <returns></returns>
        public int DetermineCategoryId(string category)
        {
            using (BookShopContext context = new BookShopContext())
            {
                var categoryId = 0;
                if (category == "Horror")
                {
                    var categoryType = context.BookCategories
                        .Where(c => c.Name == "Horror");
                    foreach (BookCategory c in categoryType)
                    {
                        categoryId = c.Id;
                    }
                }
                else if (category == "Humor")
                {
                    var categoryType = context.BookCategories
                        .Where(c => c.Name == "Humor");
                    foreach (BookCategory c in categoryType)
                    {
                        categoryId = c.Id;
                    }
                }
                else if (category == "Science Fiction")
                {
                    var categoryType = context.BookCategories
                        .Where(c => c.Name == "Science Fiction");
                    foreach (BookCategory c in categoryType)
                    {
                        categoryId = c.Id;
                    }
                }
                else if (category == "Romance")
                {
                    var categoryType = context.BookCategories
                        .Where(c => c.Name == "Romance");
                    foreach (BookCategory c in categoryType)
                    {
                        categoryId = c.Id;
                    }
                }
                return categoryId;
            }

        }
    }

}

