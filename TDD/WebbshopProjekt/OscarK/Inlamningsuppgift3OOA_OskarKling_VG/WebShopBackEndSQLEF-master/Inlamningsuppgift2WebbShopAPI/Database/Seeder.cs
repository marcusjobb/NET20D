using System;
using System.Collections.Generic;
using System.Text;
using Inlamningsuppgift2WebbShopAPI.Models;
using System.Linq;

namespace Inlamningsuppgift2WebbShopAPI.Database
{
    /// <summary>
    /// A class that seeds the database with fictional data.
    /// </summary>
    public static class Seeder
    {
        /// <summary>
        /// Method seeds the database with fictional data if there are no data in the database
        /// </summary>
        public static void SeedDatabase()
        {
            using(var db = new WebbShopContext())
            {
                if(db.BookCategories.Count() == 0)
                {
                    db.BookCategories.Add(new BookCategory { Category = "Horror" });
                    db.BookCategories.Add(new BookCategory { Category = "Humor" });
                    db.BookCategories.Add(new BookCategory { Category = "Science Fiction" });
                    db.BookCategories.Add(new BookCategory { Category = "Romance" });
                    Console.WriteLine("Added book categories from seed");
                    db.SaveChanges();
                }

                if(db.Users.Count() == 0)
                {
                    db.Users.Add(new User
                    {
                        Name = "Administrator",
                        Password = "CodicRulez",
                        IsAdmin = true
                    });

                    db.Users.Add(new User { Name = "TestCustomer", Password = "Codic2021", IsAdmin = false });
                    db.SaveChanges();
                    Console.WriteLine("Added users from seed");
                }

                if(db.Books.Count() == 0)
                {
                    db.Books.Add(
                        new Book 
                        { 
                            Title = "Cabal (Nightbreed)", 
                            Author = "Clive Barker", 
                            Price = 250,
                            Amount = 3,
                            Category = db.BookCategories.FirstOrDefault(b => b.Category == "Horror")
                        });
                    db.Books.Add(
                        new Book 
                        { 
                            Title = "The Shining", 
                            Author = "Stephen King", 
                            Price = 200,
                            Amount = 2,
                            Category = db.BookCategories.FirstOrDefault(b => b.Category == "Horror")
                        });
                    db.Books.Add(
                        new Book
                        {
                            Title = "Doctor Sleep",
                            Author = "Stephen King",
                            Price = 200,
                            Amount = 1,
                            Category = db.BookCategories.FirstOrDefault(b => b.Category == "Horror")
                        });
                    db.Books.Add(
                        new Book
                        {
                            Title = "I Robot",
                            Author = "Isaac Asimov",
                            Price = 150,
                            Amount = 4,
                            Category = db.BookCategories.FirstOrDefault(b => b.Category == "Science Fiction")
                        });

                    db.SaveChanges();
                    Console.WriteLine("Added books from seed");
                }
            }
        }
    }
}
