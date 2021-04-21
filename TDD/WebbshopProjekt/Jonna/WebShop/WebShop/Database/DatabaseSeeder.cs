using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Models;

namespace WebShop.Database
{
    public class DatabaseSeeder
    {
        /// <summary>
        /// Method that collects all the three tables seeds we need
        /// Categories,books and users
        /// </summary>
        public static void SeedDatabase()
        {
            SeedCategories();
            SeedBooks();
            SeedUsers();
        }

        /// <summary>
        /// This method seeds default values for categories in the database
        /// </summary>
        private static void SeedCategories()
        {
            AddCategory("Horror");
            AddCategory("Humor");
            AddCategory("Science Fiction");
            AddCategory("Romance");
        }

        /// <summary>
        /// This method seeds default values for books in the database
        /// </summary>
        private static void SeedBooks()
        {
            CreateBook("Cabal (Nightbreed)", "Clive Barker", 250, 3, "Horror");
            CreateBook("The Shinng", "Stephen King", 200, 2, "Horror");
            CreateBook("Doctor Sleep", "Stephen King", 200, 1, "Horror");
            CreateBook("I Robot", "Isaac Asimov", 150, 4, "Science Fiction");
        }

        /// <summary>
        /// This method seeds default values for users in the database
        /// </summary>
        private static void SeedUsers()
        {
            AddUser("Administrator", "CodicRulez");
            AddUser("TestCustomer ", "Codic2021");

            //Updating the administrator account to admin
            using (var db = new DatabaseContext())
            {
                var admin = db.Users.FirstOrDefault(a => a.Name == "Administrator");
                if (admin != null)
                {
                    admin.IsAdmin = true;
                }
                db.Update(admin);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Overload CreateBook method that lets us create book without admin permission for seed functionality
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <param name="bookcategories"></param>
        private static void CreateBook(string title, string author, int price, int amount, params string[] bookcategories)
        {
            using (var db = new DatabaseContext())
            {
                var book = db.Books.Include("BookCategories").FirstOrDefault(b => b.Title == title);
                var bookExist = db.Books.FirstOrDefault(b => b.Title == title);
                if (bookExist != null) { 
                    if (book == null)
                    {
                        book = new Book
                        {
                            Title = title,
                            Author = author,
                            Price = price,
                            Amount = amount
                        };
                    }

                    if (book.BookCategories == null)
                    {
                        book.BookCategories = new List<BookCategory>();
                    }

                    foreach (var bookcategory in bookcategories)
                    {
                        var cat = db.BookCategories.FirstOrDefault(c => c.Name == bookcategory);
                        if (cat == null)
                        {
                            cat = new BookCategory
                            {
                                Name = bookcategory
                            };
                        }
                        book.BookCategories.Add(cat);
                    }
                    db.Update(book);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// AddCategory method overload without admin permission for seed functionality
        /// </summary>
        /// <param name="name"></param>
        private static void AddCategory(string name)
        {
            using (var db = new DatabaseContext())
            {
                var book = db.BookCategories.FirstOrDefault(c => c.Name == name);
                if (book == null)
                {
                    db.BookCategories.Add(new BookCategory
                    {
                        Name = name
                    });
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// AddUser method without Admin Permission for seed functionality
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        private static void AddUser(string Name, string Password)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == Name);
                if (user == null)
                {
                    if (Password == "")
                    {
                        db.Users.Add(new User
                        {
                            Name = Name,
                            Password = "Codic2021",
                            IsActive = true
                        });
                    }
                    else
                    {
                        db.Users.Add(new User
                        {
                            Name = Name,

                            Password = Password,
                            IsActive = true
                        });
                    }
                }
                db.SaveChanges();
            }
        }
    }
}