using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShopAssignment.Database;
using WebShopAssignment.Models;

namespace WebShopAssignment.Helpers
{
    public class Seeder
    {
        
        public static void SeedCategories()
        {
            using (var db = new MyDatabase())
            {
                if (db.BookCategories.Count() == 0)
                {
                    db.BookCategories.Add(new Models.BookCategory { Name = "Horror" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Humor" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Science Fiction" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Romance" });
                    db.SaveChanges();
                }
            }
        }

        public static void SeedUsers()
        {
            using (var db = new MyDatabase())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new Models.User { Name = "Administrator", Password = "CodicRulez", IsAdmin = true });
                    db.Users.Add(new Models.User { Name = "TestCustomer", Password = "CodicRulez", IsAdmin = false });
                    db.SaveChanges();
                }
            }
        }

        public static void SeedBookTitles()
        {
            var db = new MyDatabase();
            var horror = db.BookCategories.FirstOrDefault(h => h.Name == "Horror");
            var science = db.BookCategories.FirstOrDefault(s => s.Name == "Science Fiction");
            var romance = db.BookCategories.FirstOrDefault(r => r.Name == "Romance");

            if (db.Books.Count() == 0)
            {
                db.Books.Add(new Models.Book { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, CategoryId = horror.Id });
                db.Books.Add(new Models.Book { Title = "The Shining", Author = "Stephen King", Price = 200, Amount = 2, CategoryId = horror.Id });
                db.Books.Add(new Models.Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, CategoryId = horror.Id });
                db.Books.Add(new Models.Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, CategoryId = science.Id });
                db.SaveChanges();
            }

        }

    }
}
