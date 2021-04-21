using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebbShopApi.Database
{
    public class Seeder
    {
        /// <summary>
        /// Lägger till mockdata i Databasen om tabellerna är tomma (lika med 0).  
        /// </summary>
        public void AddData()
        {
            using (var db = new WebShopContext())
            {
                if (db.Categories.Count() == 0)
                {
                    db.Categories.Add(new Models.Category { Name = "Horror" });
                    db.Categories.Add(new Models.Category { Name = "Science fiction" });
                    db.Categories.Add(new Models.Category { Name = "Romance" });
                    db.Categories.Add(new Models.Category { Name = "Comedy" });
                    db.SaveChanges();
                }
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new Models.User { Name = "Administrator", Password = "CodicRulez", IsActive = true, IsAdmin = true });
                    db.Users.Add(new Models.User { Name = "TestCustomer", Password = "Codic2021", IsActive = true, IsAdmin = false });
                    db.SaveChanges();
                }
                if (db.Books.Count() == 0)
                {
                    var horror = db.Categories.FirstOrDefault(c => c.Name == "Horror");
                    var scifi = db.Categories.FirstOrDefault(c => c.Name == "Science fiction");
                    var romance = db.Categories.FirstOrDefault(c => c.Name == "Romance");
                    var comedy = db.Categories.FirstOrDefault(c => c.Name == "Comedy");
                    db.Books.Add(new Models.Book { Title = "Cabal", Author = "Clive Barker", Price = 250, Amount = 3, CategoryId = horror.Id });
                    db.Books.Add(new Models.Book { Title = "The Shinning", Author = "Stephen King", Price = 200, Amount = 2, CategoryId = horror.Id });
                    db.Books.Add(new Models.Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, CategoryId = horror.Id });
                    db.Books.Add(new Models.Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, CategoryId = scifi.Id });
                    db.Books.Add(new Models.Book { Title = "Pride and Predjudice", Author = "Jane Austen", Price = 150, Amount = 5, CategoryId = romance.Id });
                    db.Books.Add(new Models.Book { Title = "The Idiot", Author = "Elif Batuman", Price = 250, Amount = 4, CategoryId = comedy.Id });
                    db.SaveChanges();
                }
            }
        }
    }
}
