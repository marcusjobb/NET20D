using System.Linq;
using WebshopAPI.Database;

namespace WebshopAPI.Utils
{
    /// <summary>
    /// Class for creating seed(s)
    /// </summary>
    public static class Seed
    {
        /// <summary>
        /// Generates data in tables for testing purposes
        /// </summary>
        public static void Seeder()
        {
            using (var db = new EFContext())
            {
                if (!db.Users.Any())
                {
                    db.Users.Add(new Models.User
                    {
                        Name = "Administrator",
                        Password = "Codicrulez",
                        IsAdmin = true,
                        IsActive = true
                    });
                    db.Users.Add(new Models.User
                    {
                        Name = "TestCostumer",
                        Password = "Codic2021",
                        IsAdmin = false,
                        IsActive = true
                    });
                    db.SaveChanges();
                }
                if (!db.BookCategories.Any())
                {
                    db.BookCategories.Add(new Models.BookCategory
                    {
                        Name = "Horror"
                    });
                    db.BookCategories.Add(new Models.BookCategory
                    {
                        Name = "Humor"
                    });
                    db.BookCategories.Add(new Models.BookCategory
                    {
                        Name = "Sci-Fi"
                    });
                    db.BookCategories.Add(new Models.BookCategory
                    {
                        Name = "Romance"
                    });
                    db.SaveChanges();
                }
                if (!db.Books.Any())
                {
                    var getBookCategory1 = db.BookCategories.FirstOrDefault(c => c.Name == "Horror");
                    db.Books.Add(new Models.Book
                    {
                        Title = "Cabal (Nightbreed)",
                        Author = "Clive Barker",
                        Price = 250,
                        Amount = 3,
                        CategoryId = getBookCategory1.Id
                    });
                    var getBookCategory2 = db.BookCategories.FirstOrDefault(c => c.Name == "Horror");
                    db.Books.Add(new Models.Book
                    {
                        Title = "The Shining",
                        Author = "Stephen King",
                        Price = 200,
                        Amount = 2,
                        CategoryId = getBookCategory2.Id
                    });
                    var getBookCategory3 = db.BookCategories.FirstOrDefault(c => c.Name == "Horror");
                    db.Books.Add(new Models.Book
                    {
                        Title = "Doctor Sleep",
                        Author = "Stephen King",
                        Price = 200,
                        Amount = 1,
                        CategoryId = getBookCategory3.Id
                    });
                    var getBookCategory4 = db.BookCategories.FirstOrDefault(c => c.Name == "Sci-Fi");
                    db.Books.Add(new Models.Book
                    {
                        Title = "I, Robot",
                        Author = "Isaac Asimov",
                        Price = 150,
                        Amount = 4,
                        CategoryId = getBookCategory4.Id
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}