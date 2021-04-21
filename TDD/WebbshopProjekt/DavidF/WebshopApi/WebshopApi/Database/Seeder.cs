using System.Linq;
using WebshopApi.Models;

namespace WebshopApi.Database
{
    public static class Seeder
    {
        /// <summary>
        /// Seedar tabellerna Categories, Books och Users
        /// </summary>
        public static void Seed()
        {
            SeedCategories();
            SeedBooks();
            SeedUsers();
        }

        /// <summary>
        /// Seedar tabellen Categories
        /// </summary>
        private static void SeedCategories()
        {
            using (var db = new MyContext())
            {
                if (db.Categories.Count() == 0)
                {
                    db.Categories.AddRange
                        (
                        new Category[]
                        {
                            new Category {Name = "Horror"},
                            new Category {Name = "Humor"},
                            new Category {Name = "Science Fiction"},
                            new Category {Name = "Romance"}
                        }
                        );
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Seedar tabellen Books
        /// </summary>
        private static void SeedBooks()
        {
            using (var db = new MyContext())
            {
                if (db.Books.Count() == 0)
                {
                    db.Books.AddRange
                        (
                        new Book[]
                        {
                            new Book{Title = "Cabal (Nightbreed", Author = "Clive Barker", Price = 250,
                                Amount = 3, Category = db.Categories.FirstOrDefault(c=> c.Name == "Horror") },
                            new Book{Title = "The Shinning", Author = "Stephen King", Price = 200,
                                Amount = 2, Category = db.Categories.FirstOrDefault(c=> c.Name == "Horror")},
                            new Book{Title = "Doctor Sleep", Author = "Stephen King", Price = 200,
                                Amount = 1, Category = db.Categories.FirstOrDefault(c=> c.Name == "Horror")},
                            new Book{Title = "I Robot", Author = "Isaac Asimov", Price = 150,
                                Amount = 4, Category = db.Categories.FirstOrDefault(c=> c.Name == "Science Fiction")}
                        }
                        );
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Seedar tabellen Users
        /// </summary>
        private static void SeedUsers()
        {
            using (var db = new MyContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.AddRange
                        (
                        new User[]
                        {
                            new User {Name = "Administrator", Password = "CodicRulez", IsAdmin = true,
                                IsActive = true },
                            new User {Name = "TestClient", Password = "Codic2021", IsAdmin = false,
                                IsActive = true },
                        }
                        );
                    db.SaveChanges();
                }
            }
        }
    }
}