using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebbShop.Models;
namespace WebbShop.Data
{
    public class SeedData
    {

        /// <summary>
        /// Adding items to database
        /// </summary>
        public void Seed()
        {
            using (var db = new WebbContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User { Name = "Administrator", Password = "CodicRulez", IsActive = true, IsAdmin = true });
                    db.SaveChanges();
                    db.Users.Add(new User { Name = "TestCustomer", Password = "Codic2021", IsActive = true, IsAdmin = false });
                    db.SaveChanges();
                }

                if (db.BookCategories.Count() == 0)
                {
                    db.BookCategories.Add(new BookCategory { Name = "Horror" });
                    db.SaveChanges();
                    db.BookCategories.Add(new BookCategory { Name = "Humor" });
                    db.SaveChanges();
                    db.BookCategories.Add(new BookCategory { Name = "Science Fiction" });
                    db.SaveChanges();
                    db.BookCategories.Add(new BookCategory { Name = "Romance" });
                    db.SaveChanges();
                }

                if (db.Books.Count() == 0)
                {
                    db.Books.Add(new Book { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Ammount = 3, CategoryID = 1});
                    db.SaveChanges();
                    db.Books.Add(new Book { Title = "The Shinng", Author = "Stephen King", Price = 200, Ammount = 2, CategoryID = 1 });
                    db.SaveChanges();
                    db.Books.Add(new Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Ammount = 1, CategoryID=1  });
                    db.SaveChanges();
                    db.Books.Add(new Book { Title = "I Roobot", Author = "Isaac Asimov", Price = 150, Ammount = 4, CategoryID=1  });
                    db.SaveChanges();



                }
            }

        }
    }
}
