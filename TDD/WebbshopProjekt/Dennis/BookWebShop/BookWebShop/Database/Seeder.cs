using BookWebShop.Models;
using System.Linq;

namespace BookWebShop.Database
{
    public static class Seeder
    {
        /// <summary>
        /// Class to add mockdata.
        /// </summary>

        public static void Seed()
        {
            using (var db = new WebbShopContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User { Name = "a", Password = "a", IsActive = true, IsAdmin = true });
                    db.Users.Add(new User { Name = "c", Password = "c", IsActive = true, IsAdmin = false });
                    db.Users.Add(new User { Name = "Administrator", Password = "CodicRulez", IsActive = true, IsAdmin = true });
                    db.Users.Add(new User { Name = "TestCustomer", Password = "Codic2021", IsActive = true, IsAdmin = false });
                    db.SaveChanges();
                }

                if (db.BookCategories.Count() == 0)
                {
                    db.BookCategories.Add(new BookCategory { Name = "Horror" });
                    db.BookCategories.Add(new BookCategory { Name = "Humor" });
                    db.BookCategories.Add(new BookCategory { Name = "Science Fiction" });
                    db.BookCategories.Add(new BookCategory { Name = "Romance" });
                    db.SaveChanges();
                }

                if (db.Books.Count() == 0)
                {
                    db.Books.Add(new Book { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, Category = db.BookCategories.FirstOrDefault(bc => bc.Name == "Horror") });
                    db.Books.Add(new Book { Title = "The Shining", Author = "Stephen King", Price = 200, Amount = 2, Category = db.BookCategories.FirstOrDefault(bc => bc.Name == "Horror") });
                    db.Books.Add(new Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, Category = db.BookCategories.FirstOrDefault(bc => bc.Name == "Horror") });
                    db.Books.Add(new Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, Category = db.BookCategories.FirstOrDefault(bc => bc.Name == "Science Fiction") });
                    db.SaveChanges();
                }
            }
        }
    }
}