using System.Linq;
using WebbShopIvoNazlic.Models;

namespace WebbShopIvoNazlic.Database
{

    /// <remarks>
    /// Handles mock data to be added to the database
    /// </remarks>
    public static class MockData
    {
        /// <summary>
        /// Adds mock data to the database
        /// </summary>
        public static void AddData()
        {
            using (var db = new BookDatabase())
            {
                //Add data for users
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User { Name = "Administrator", Password = "CodicRulez", IsAdmin = true });
                    db.Users.Add(new User { Name = "TestCustomer", Password = "Codic2021" });
                    db.SaveChanges();
                }

                //Add data for book categories
                if (db.BookCategories.Count() == 0)
                {
                    db.BookCategories.Add(new Category { Name = "Horror" });
                    db.BookCategories.Add(new Category { Name = "Humor" });
                    db.BookCategories.Add(new Category { Name = "Science Fiction" });
                    db.BookCategories.Add(new Category { Name = "Romance" });
                    db.SaveChanges();
                }

                //Add data for books
                if (db.Books.Count() == 0)
                {
                    db.Books.Add(new Book
                    {
                        Title = "Cabal (Nightbreed)",
                        Author = "Clive Barker",
                        Amount = 3,
                        Price = 250,
                        BookCategory = db.BookCategories.FirstOrDefault(c => c.Name == "Horror") //Code to add BookCategory copied from Discord - Bästkusten code from David Ström
                    });

                    db.Books.Add(new Book
                    {
                        Title = "The Shining",
                        Author = "Stephen King",
                        Amount = 2,
                        Price = 200,
                        BookCategory = db.BookCategories.FirstOrDefault(c => c.Name == "Horror")
                    });

                    db.Books.Add(new Book
                    {
                        Title = "Doctor Sleep",
                        Author = "Stephen King",
                        Amount = 1,
                        Price = 200,
                        BookCategory = db.BookCategories.FirstOrDefault(c => c.Name == "Horror")
                    });

                    db.Books.Add(new Book
                    {
                        Title = "I Robot",
                        Author = "Isaac Asimov",
                        Amount = 4,
                        Price = 150,
                        BookCategory = db.BookCategories.FirstOrDefault(c => c.Name == "Science Fiction")
                    });
                    db.SaveChanges();
                }
            }
        }
    
    }
}
