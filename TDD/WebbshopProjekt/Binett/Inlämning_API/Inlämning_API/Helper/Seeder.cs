using Inlämning_API.Database;
using Inlämning_API.Models;
using System.Linq;

namespace Inlämning_API.Helper
{
    public static class Seeder
    {
        /// <summary>
        /// Creates objects to the database
        /// </summary>
        public static void Seed()
        {
            using (var db = new StoreContext())
            {
               
                if (db.BookCategory.Count() == 0)
                {
                    db.BookCategory.Add(new BookCategories { Name = "Horror" });
                    db.BookCategory.Add(new BookCategories { Name = "Humor" });
                    db.BookCategory.Add(new BookCategories { Name = "Science Fiction" });
                    db.BookCategory.Add(new BookCategories { Name = "Romance" });
                    db.SaveChanges();
                }
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User { Name = "Administrator", Password = "CodicRulez", IsAdmin = true, IsActive = true });
                    db.Users.Add(new User { Name = "TestCustomer", Password = "Codic2021", IsActive = true, IsAdmin = false });
                    db.SaveChanges();
                }

                if (db.Books.Count() == 0)
                {
                    db.Books.Add(new Book { Title = "Cabal(Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, Category = db.BookCategory.FirstOrDefault(c => c.Name == "Horror") });
                    db.Books.Add(new Book { Title = "The Shining", Author = "Stephen King", Price = 200, Amount = 2, Category = db.BookCategory.FirstOrDefault(c => c.Name == "Horror") });
                    db.Books.Add(new Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, Category = db.BookCategory.FirstOrDefault(c => c.Name == "Horror") });
                    db.Books.Add(new Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, Category = db.BookCategory.FirstOrDefault(c => c.Name == "Science Fiction") });
                    db.SaveChanges();
                }

            }
        }

    }
}
