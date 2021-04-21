using Inlämning2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning2.Database
{
    public static class Seeder
    {
        /// <summary>
        /// Metod för att skapa grunddata i databasen.
        /// </summary>
        public static void Seed()
        {
            using (var db = new WSContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User() { Name = "Adminstrator", Password = "CodicRulez", IsActive = true, IsAdmin = true });
                    db.Users.Add(new User() { Name = "TestCustomer", Password = "Codic2021", IsActive = true, IsAdmin = false });
                    db.SaveChanges();
                }

                if (db.Categories.Count() == 0)
                {
                    db.Categories.Add(new Category() { Name = "Horror" });
                    db.Categories.Add(new Category() { Name = "Humor" });
                    db.Categories.Add(new Category() { Name = "Science Fiction" });
                    db.Categories.Add(new Category() { Name = "Romance" });
                    db.SaveChanges();
                }

                if (db.Books.Count() == 0)
                {
                    var horror = db.Categories.FirstOrDefault(c => c.Name == "Horror");
                    var sf = db.Categories.FirstOrDefault(c => c.Name == "Science Fiction");

                    db.Books.Add(new Book()
                    {
                        Title = "Cabal (Nightbreed)",
                        Author = "Clive Barker",
                        Price = 250,
                        Amount = 3,
                        Categories = new List<Category>() { horror }
                    });
                    db.Books.Add(new Book()
                    {
                        Title = "The Shining",
                        Author = "Stephen King",
                        Price = 200,
                        Amount = 2,
                        Categories = new List<Category>() { horror }
                    });
                    db.Books.Add(new Book()
                    {
                        Title = "Doctor Sleep",
                        Author = "Stephen King",
                        Price = 200,
                        Amount = 1,
                        Categories = new List<Category>() { horror }
                    });
                    db.Books.Add(new Book()
                    {
                        Title = "I Robot",
                        Author = "Isaac Asimov",
                        Price = 150,
                        Amount = 4,
                        Categories = new List<Category>() { sf }
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
