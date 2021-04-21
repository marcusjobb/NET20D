namespace WebbShopAPI.Database
{
    using System.Collections.Generic;
    using System.Linq;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="Seeder" />.
    /// </summary>
    public static class Seeder
    {
        /// <summary>
        /// Database seeding.
        /// </summary>
        public static void Seed()
        {
            using (var db = new WebbShopContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.AddRange(new List<User>
                    {
                        new User {Name="Administrator",Password="CodicRulez",IsAdmin=true},
                        new User {Name="TestCustomer",Password="Codic2021",IsAdmin=false}
                    });
                    db.SaveChanges();
                }

                if (db.BookCategories.Count() == 0)
                {
                    db.BookCategories.AddRange(new List<BookCategory>
                    {
                        new BookCategory { Name="Horror"},
                        new BookCategory {Name="Humor"},
                        new BookCategory {Name="Science Fiction"},
                        new BookCategory {Name="Romance"}
                    });
                    db.SaveChanges();
                }

                if (db.Books.Count() == 0)
                {
                    db.Books.AddRange(new List<Book>
                    {
                        new Book {Title="Cabal (Nightbreed)",Author="Clive Barker",Price=250,Amount=3,CategoryId="Horror"},
                        new Book {Title="The Shinng",Author="Stephen King",Price=200,Amount=2,CategoryId="Horror"},
                        new Book {Title="Doctor Sleep",Author="Stephen King",Price=200,Amount=1,CategoryId="Horror"},
                        new Book {Title="I Robot",Author="Isaac Asimov",Price=150,Amount=4,CategoryId="Science Fiction"},
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
