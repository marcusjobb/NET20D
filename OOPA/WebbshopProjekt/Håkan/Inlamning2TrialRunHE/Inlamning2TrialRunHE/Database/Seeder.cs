using Inlamning2TrialRunHE.Models;
using System.Linq;

namespace Inlamning2TrialRunHE.Db
{
    public class Seeder
    {
        public static void Seed()
        {
            using (var db = new Database())
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
                    db.BookCategories.Add(
                        new BookCategory { Name = "Horror" });
                    db.BookCategories.Add(
                        new BookCategory { Name = "Humor" });
                    db.BookCategories.Add(
                        new BookCategory { Name = "Science Fiction" });
                    db.BookCategories.Add(
                        new BookCategory { Name = "Romance" });
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
                        Category = db.BookCategories.FirstOrDefault(
                            c => c.Name == "Horror")
                    });
                    db.Books.Add(new Book
                    {
                        Title = "The Shining",
                        Author = "Steven King",
                        Price = 200,
                        Amount = 2,
                        Category = db.BookCategories.FirstOrDefault(
                            c => c.Name == "Horror")
                    });
                    db.Books.Add(new Book
                    {
                        Title = "Doctor sleep",
                        Author = "Steven King",
                        Price = 200,
                        Amount = 1,
                        Category = db.BookCategories.FirstOrDefault(
                            c => c.Name == "Horror")
                    });
                    db.Books.Add(new Book
                    {
                        Title = "I Robot",
                        Author = "Isaac Asimov",
                        Price = 150,
                        Amount = 4,
                        Category = db.BookCategories.FirstOrDefault(
                            c => c.Name == "Science Fiction")
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}