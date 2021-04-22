using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShop.Database
{
    public static class Seeder
    {
        public static void Seed()
        {
            using (var db = new EFContext())
            {
                if (db.Genres.Count() == 0)
                {
                    db.Genres.AddRange(new List<BookGenre>
                    {
                        new BookGenre{Genre = "Horror"},
                        new BookGenre{Genre = "Humor"},
                        new BookGenre{Genre = "Science Fiction"},
                        new BookGenre{Genre = "Romance"}
                    });
                    db.SaveChanges();
                }

                if (db.Users.Count() == 0)
                {
                    db.Users.AddRange(new List<User>
                    {
                        new User{Name="Administrator", Password="CodicRulez", IsAdmin = true,IsActive = true ,SoldBooks = new List<SoldBook>()},
                        new User{Name="TestCustomer", Password="Codic2021", IsAdmin = false,IsActive = true ,SoldBooks = new List<SoldBook>()}
                    });
                    db.SaveChanges();
                }

                if (db.Books.Count() == 0)
                {
                    var horror = db.Genres.FirstOrDefault(h => h.Genre == "Horror");
                    var scienceFiction = db.Genres.FirstOrDefault(h => h.Genre == "Science Fiction");
                    var humor = db.Genres.FirstOrDefault(h => h.Genre == "Humor");
                    db.Books.AddRange(new List<Book>
                    { //CategoryId = BookCategory{Genre horror och sånt} 
                        new Book{Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Quantity = 3, Genres = new List<BookGenre>(){horror} },
                        new Book{Title = "The Shinng", Author = "Stephen King", Price = 200, Quantity = 2, Genres = new List<BookGenre>(){horror}},
                        new Book{Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Quantity = 1, Genres = new List<BookGenre>(){horror}},
                        new Book{Title = "I Robot", Author = "Isaac Asimov", Price = 150, Quantity = 4, Genres = new List<BookGenre>(){scienceFiction}}

                    });
                    db.SaveChanges();
                }
            }
        }
    }
}