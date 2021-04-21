using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI.Database
{
    public class Seeder
    {
        /// <summary>
        /// Method for adding mockdata to the database. Had to use "SaveChanges()" after every insert in order to get them 
        /// in the right order.
        /// </summary>
        public static void AddMockData()
        {
            using (var db = new EFContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User{ Name = "Administrator", Password = "CodicRulez", IsAdmin = true, IsActive = true });
                    db.SaveChanges();
                    db.Users.Add(new User{Name = "TestCustomer", Password = "Codic2021", IsAdmin = false, IsActive = true });
                    db.SaveChanges();
                }
                if(db.Categories.Count() == 0)
                {
                    db.Categories.Add(new BookCategory { Name = "Horror" });
                    db.SaveChanges();
                    db.Categories.Add(new BookCategory { Name = "Humor" });
                    db.SaveChanges();
                    db.Categories.Add(new BookCategory { Name = "Science Fiction" });
                    db.SaveChanges();
                    db.Categories.Add(new BookCategory { Name = "Romance" });
                    db.SaveChanges();
                }
                if(db.Books.Count() == 0)
                {
                    db.Books.Add(new Book { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, CategoryId = 1});
                    db.SaveChanges();
                    db.Books.Add(new Book { Title = "The Shining", Author = "Stephen King", Price = 200, Amount = 2, CategoryId = 1});
                    db.SaveChanges();
                    db.Books.Add(new Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, CategoryId = 1 });
                    db.SaveChanges();
                    db.Books.Add(new Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, CategoryId = 1 });
                    db.SaveChanges();
                }
            }

        }


    }
}
