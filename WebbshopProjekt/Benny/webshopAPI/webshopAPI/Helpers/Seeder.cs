using System.Linq;
using webshopAPI.Db;
using webshopAPI.Models;

namespace webshopAPI.Helpers
{
    public static class Seeder
    {
        /// <summary>
        /// A mockdata seeder that adds information to the database.
        /// </summary>
        public static void Seed()
        {
            using (var db = new Database())
            {
                if (db.BookCategories.Count() == 0)
                {
                    db.BookCategories.Add(new BookCategory("Horror"));
                    db.BookCategories.Add(new BookCategory("Humor"));
                    db.BookCategories.Add(new BookCategory("Science Fiction"));
                    db.BookCategories.Add(new BookCategory("Romance"));
                    db.SaveChanges();
                }

                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User(
                        "Administrator",
                        "CodicRulez",
                        true, //Is active
                        true)); // Is Admin
                    db.Users.Add(new User(
                        "TestCustomer",
                        "Codic2021",
                        true,
                        false));
                    db.Users.Add(new User(
                        "InactiveCustomer",
                        "Codic2021",
                        false,
                        false));
                    db.SaveChanges();
                }

                if (db.Books.Count() == 0)
                {
                    db.Books.Add(new Book()
                    {
                        Title = "Cabal (Nightbreed)",
                        Author = "Clive Barker",
                        Price = 250,
                        Amount = 3,
                        Category = (
                        from bookCat in db.BookCategories
                        where bookCat.Name == "Horror"
                        select bookCat).FirstOrDefault()
                    });

                    db.Books.Add(new Book()
                    {
                        Title = "Sunes sommar",
                        Author = "Sören Olsson",
                        Price = 149,
                        Amount = 7,
                        Category = (
                        from bookCat in db.BookCategories
                        where bookCat.Name == "Humor"
                        select bookCat).FirstOrDefault()
                    });

                    db.Books.Add(new Book()
                    {
                        Title = "Legenden om Star Wars: imperiets arvinge",
                        Author = "Timothy Zahn",
                        Price = 279,
                        Amount = 2,
                        Category = (
                        from bookCat in db.BookCategories
                        where bookCat.Name == "Science Fiction"
                        select bookCat).FirstOrDefault()
                    });

                    db.Books.Add(new Book()
                    {
                        Title = "Notting Hill",
                        Author = "Richard Curtis",
                        Price = 99,
                        Amount = 4,
                        Category = (
                        from bookCat in db.BookCategories
                        where bookCat.Name == "Romance"
                        select bookCat).FirstOrDefault()
                    });

                    db.Books.Add(new Book()
                    {
                        Title = "The Shining",
                        Author = "Stephen King",
                        Price = 200,
                        Amount = 2,
                        Category = (
                        from bookCat in db.BookCategories
                        where bookCat.Name == "Horror"
                        select bookCat).FirstOrDefault()
                    });
                    db.Books.Add(new Book()
                    {
                        Title = "Doctor Sleep",
                        Author = "Stephen King",
                        Price = 200,
                        Amount = 1,
                        Category = (
                        from bookCat in db.BookCategories
                        where bookCat.Name == "Horror"
                        select bookCat).FirstOrDefault()
                    });
                    db.Books.Add(new Book()
                    {
                        Title = "iRobot",
                        Author = "Isaac Asimov",
                        Price = 150,
                        Amount = 4,
                        Category = (
                        from bookCat in db.BookCategories
                        where bookCat.Name == "Science Fiction"
                        select bookCat).FirstOrDefault()
                    });

                    db.SaveChanges();
                }
            }
        }
    }
}