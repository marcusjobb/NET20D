using Inlämning2WebbShop.Models;
using System.Linq;

namespace Inlämning2WebbShop.Database
{
    public static class Seeder
    {
        /// <summary>
        /// lägger till mockdata
        /// </summary>
        public static void Seed()
        {
            using (var db = new WebbShopContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User { Name = "Administrator", Password = "CodicRulez", IsAdmin = true, IsActive = true });
                    db.Users.Add(new User { Name = "TestCustomer", Password = "Codic2021", IsAdmin = false, IsActive = true });
                    db.SaveChanges();
                }
                if (db.Categories.Count() == 0)
                {
                    db.Categories.Add(new BookCategory { Name = "Horror" });
                    db.Categories.Add(new BookCategory { Name = "Humor" });
                    db.Categories.Add(new BookCategory { Name = "Science Fiction" });
                    db.Categories.Add(new BookCategory { Name = "Romance" });
                    db.SaveChanges();
                }
                if (db.Books.Count() == 0)
                {
                    db.Books.Add(new Book { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, Category = db.Categories.FirstOrDefault(c => c.Name == "Horror") });
                    db.Books.Add(new Book { Title = "The shining", Author = "Stephen King", Price = 200, Amount = 2, Category = db.Categories.FirstOrDefault(c => c.Name == "Horror") });
                    db.Books.Add(new Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, Category = db.Categories.FirstOrDefault(c => c.Name == "Horror") });
                    db.Books.Add(new Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, Category = db.Categories.FirstOrDefault(c => c.Name == "Science Fiction") });
                    db.SaveChanges();
                }
            }
        }
    }
}