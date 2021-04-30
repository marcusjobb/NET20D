using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebbShopAPI.Models;

namespace WebbShopAPI.Database
{
    public static class Seeder
    {
        /// <summary>
        /// Handels the insertion of initial data to the database tables
        /// </summary>
        public static void Seed()
        {
            using (var db = new MyContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.AddRange(new List<User>
                    {
                        new User{Name="Administrator", Password="CodicRulez", IsAdmin=true, IsActive=true},
                        new User{Name="TestClient", Password="Codic2021", IsAdmin=false, IsActive=true},
                    });
                    db.SaveChanges();
                }

                if (db.Books.Count() == 0)
                {
                    db.Books.AddRange(new List<Books>
                    {
                        new Books {Title="Cabal (Nightbreed)", Author="Clive Barker", Price=250, Amount=3, Category = 1},
                        new Books {Title="The Shining", Author="Stephen King", Price=200, Amount=2, Category=1},
                        new Books {Title="Doctor Sleep", Author="Stephen King", Price=200, Amount=1, Category=1},
                        new Books {Title="I Robot", Author="Isaac Asimov", Price=150, Amount=4, Category=3}
                    });
                    db.SaveChanges();
                }

                if (db.Category.Count() == 0)
                {
                    db.Category.AddRange(new List<BookCategory>
                    {
                        new BookCategory { Name="Horror" },
                        new BookCategory { Name="Humor" },
                        new BookCategory { Name="Science Fiction" },
                        new BookCategory { Name="Romance" }
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
