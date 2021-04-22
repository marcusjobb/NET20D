using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Inlamn2WebbShop_MLarsson.Database;
using Inlamn2WebbShop_MLarsson.Models;

namespace Inlamn2WebbShop_MLarsson.Controllers
{/// <summary>
/// En klass som skapar användare, kategorier och böcker.
/// </summary>
    public static class Seeder
    {
        public static void Seed()
        {
            
            using (var db = new WebbShopContext())
            {

                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User() { Name = "Administrator", Password = "CodicRulez", IsAdmin = true, IsActive = true, SoldBooks = new List<SoldBook>()});
                    db.Users.Add(new User() { Name = "TestClient", SoldBooks = new List<SoldBook>() });
                    db.SaveChanges();
                }

                if(db.Categories.Count() == 0)
                {
                    db.Categories.Add(new Category() { Name = "Horror" });
                    db.Categories.Add(new Category() { Name = "Humor" });
                    db.Categories.Add(new Category() { Name = "Science Fiction" });
                    db.Categories.Add(new Category() { Name = "Romance" });
                    db.SaveChanges();
                }
                
                if (db.Books.Count() == 0)
                {
                    var horror = db.Categories.FirstOrDefault(h => h.Name == "Horror");
                    var scienceFiction = db.Categories.FirstOrDefault(h => h.Name == "Science Fiction");
                    var humor = db.Categories.FirstOrDefault(h => h.Name == "Humor");

                    db.Books.Add(new Book() { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, Categories = new List<Category>() { horror } });
                    db.Books.Add(new Book() { Title = "The Shining", Author = "Stephen King", Price = 200, Amount = 2, Categories = new List<Category>() { horror } });
                    db.Books.Add(new Book() { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, Categories = new List<Category>() { horror } });
                    db.Books.Add(new Book() { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, Categories = new List<Category>() { scienceFiction } });
                    db.Books.Add(new Book() { Title = "Hitchhiker's guide to the galaxy", Author = "Douglas Adams", Price = 350, Amount = 3, Categories = new List<Category>() { humor, scienceFiction } });
                    db.SaveChanges();
                }
            }

        }
   

    }
      
}
