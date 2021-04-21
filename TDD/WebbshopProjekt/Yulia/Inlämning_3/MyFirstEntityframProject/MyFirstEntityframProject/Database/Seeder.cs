
using MyFirstEntityframProject.Database;
using System.Collections.Generic;
using System.Linq;


namespace MyFirstEntityframProject
{
    public static class Seeder
    {

        public static void Seed()
        {
            using (var db = new WebShopYulia())

                if (db.Categories.Count() == 0)
                {
                    db.AddRange(new Category[]
                    {
                    new Category { Name = "Horror"},
                    new Category { Name = "Humour"},
                    new Category { Name = "Science fiction"},
                    new Category { Name = "Romance"},
                    }
                    );
                    db.SaveChanges();
                }
            using (var db = new WebShopYulia())

                if (db.Users.Count() == 0)
                {
                    db.AddRange(new User[]
                    {
                    new User { Name = "Administrator", Password="CodicRulez", IsAdmin = true, IsActive=true, SoldBooks = new List<SoldBook>()},
                    new User { Name = "TestClient", Password="Codic2021", IsAdmin = false,IsActive=true, SoldBooks = new List<SoldBook>()}
                    }
                    );
                    db.SaveChanges();
                }
            using (var db = new WebShopYulia())

                if (db.Books.Count() == 0)
                {
                  
                    db.AddRange(new Book[]
                    {
                    new Book { Title= "Cabal (Nightbreed)", Author = "Clive Barker", Price= 250, Amount=3, Categories = new List<Category>() {db.Categories.FirstOrDefault(h => h.Name == "Horror")}},
                    new Book { Title= "The Shining", Author = "Stephen King", Price=200, Amount=2, Categories = new List<Category>() {db.Categories.FirstOrDefault(h => h.Name == "Horror")}},
                    new Book { Title = "Doctor Sleep", Author = "Stephen King" , Price = 200, Amount =1, Categories = new List<Category>() {db.Categories.FirstOrDefault(h => h.Name == "Horror")}},
                    new Book { Title = "I Robot", Author = "Isac Asimov" , Price = 150, Amount =4, Categories = new List<Category>() {db.Categories.FirstOrDefault(h => h.Name == "Science fiction")}}
                    }
                    );
                    db.SaveChanges();
                }
        }
    }
}

