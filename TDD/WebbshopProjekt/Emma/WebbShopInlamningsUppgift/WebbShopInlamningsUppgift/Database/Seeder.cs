using System.Collections.Generic;
using System.Linq;
using WebbShopInlamningsUppgift.Models;

namespace WebbShopInlamningsUppgift.Database
{
    /// <summary>
    /// Seeder allows you to add mock-data
    /// </summary>
    public class Seeder
    {
        /// <summary>
        /// Adds mock-data to database
        /// </summary>
        public static void Seed()
        {
            using (var db = new WebbshopContext())
            {
                var exists = db.Users.Any();
                if (exists)
                {
                    return;
                }
                if (!exists)
                {
                    List<Users> users = new List<Users>
                    {
                        new Users{Name = "TestCustomer", Password = "Codic2021", IsActive = true, IsAdmin = false },
                        new Users{Name = "Administrator", Password = "CodicRulez", IsActive = true, IsAdmin = true }
                    };
                    db.Users.AddRange(users);
                    db.SaveChanges();
                }

                exists = db.BookCategories.Any();
                if (exists)
                {
                    return;
                }
                if (!exists)
                {
                    List<BookCategory> categories = new List<BookCategory>
                    {
                        new BookCategory{Genere = "Horror" },
                        new BookCategory{Genere = "Comedy" },
                        new BookCategory{Genere = "Science Fiction" },
                        new BookCategory{Genere = "Romance" }
                    };
                    db.BookCategories.AddRange(categories);
                    db.SaveChanges();
                }

                exists = db.Books.Any();
                if (exists)
                {
                    return;
                }
                if (!exists)
                {
                    List<Books> books = new List<Books>
                    {
                        new Books{ Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3},
                        new Books{ Title = "The Shining", Author = "Stephen King", Price = 200, Amount = 2 },
                        new Books{ Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1 },
                        new Books{ Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4 },
                    };
                    db.Books.AddRange(books);
                    db.SaveChanges();
                }

                SetBookGenere(db, "The Shining", "Horror");
                SetBookGenere(db, "Doctor Sleep", "Horror");
                SetBookGenere(db, "Cabal (Nightbreed)", "Horror");
                SetBookGenere(db, "I Robot", "Science Fiction");
                db.SaveChanges();

            }
        }

        /// <summary>
        /// Allows you to set the relation between Books and BookCategory
        /// </summary>
        /// <param name="db"></param>
        /// <param name="bookTitle"></param>
        /// <param name="bookGenere"></param>
        public static void SetBookGenere(WebbshopContext db, string bookTitle, string bookGenere)
        {
            var book = db.Books.FirstOrDefault(b => b.Title == bookTitle);
            if (book != null)
            {
                var genere = db.BookCategories.FirstOrDefault(g => g.Genere == bookGenere);
                if (genere != null)
                {
                    book.BookCategory = genere;
                }
            }
        }
    }
}
