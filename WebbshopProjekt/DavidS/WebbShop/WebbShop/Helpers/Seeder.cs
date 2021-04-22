using System.Collections.Generic;
using System.Linq;
using WebbShop.Database;
using WebbShop.Models;

namespace WebbShop.Helpers
{
    public static class Seeder
    {
        /// <summary>
        /// Seeds the database with users, books and book categories
        /// if the database is lacking in any of these areas.
        /// </summary>
        public static void Seed()
        {
            using var db = new Context();
            if (!db.Users.Any())
            {
                db.Users.AddRange(new List<User>
                {
                    new User { Name = "Administrator", Password = "CodicRulez", IsActive = true, IsAdmin = true},
                    new User { Name = "TestClient", Password = "Codic2021", IsActive = true, IsAdmin = false }
                });

                db.SaveChanges();
            }

            if (!db.BookCategories.Any())
            {
                db.BookCategories.AddRange(new List<BookCategory>
                {
                    new BookCategory { Name = "Horror" },
                    new BookCategory { Name = "Humor" },
                    new BookCategory { Name = "Science Fiction" },
                    new BookCategory { Name = "Romance" }
                });

                db.SaveChanges();
            }

            if (!db.Books.Any())
            {
                db.Books.AddRange(new List<Book>
                {
                    new Book { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, Category = db.BookCategories.FirstOrDefault(c => c.Name == "Horror") },
                    new Book { Title = "The Shining", Author = "Stephen King", Price = 200, Amount = 2, Category = db.BookCategories.FirstOrDefault(c => c.Name == "Horror") },
                    new Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, Category = db.BookCategories.FirstOrDefault(c => c.Name == "Horror") },
                    new Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, Category = db.BookCategories.FirstOrDefault(c => c.Name == "Science Fiction") }
                });

                db.SaveChanges();
            }
        }
    }
}
