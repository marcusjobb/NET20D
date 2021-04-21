using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Webbutik.Database
{
    public static class Seeder
    {
        /// <summary>
        /// Creates mockdata.
        /// </summary>
        public static void Seed()
        {
            using (var db = new ShopContext())
            {
                if (db.Users.Count() == 0) // Creates the users.
                {
                    db.Users.Add(new Models.User
                    {
                        Name = "Administrator",
                        Password = "CodicRulez",
                        IsAdmin = true
                    });
                    db.Users.Add(new Models.User
                    {
                        Name = "TestCustomer",
                        Password = "Codic2021",
                        IsAdmin = false
                    });
                    db.SaveChanges();
                }

                if (db.BookCategories.Count() == 0) // Creates the categories.
                {
                    db.BookCategories.Add(new Models.BookCategory { Name = "No Category" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Horror" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Humor" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Science Fiction" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Romance" });
                    db.SaveChanges();
                }

                if (db.Authors.Count() == 0) // Creates the authors.
                {
                    db.Authors.Add(new Models.Author { Name = "Clive Barker" });
                    db.Authors.Add(new Models.Author { Name = "Stephen King" });
                    db.Authors.Add(new Models.Author { Name = "Isaac Asimov" });
                    db.SaveChanges();
                }

                if (db.Books.Count() == 0) // Creates the books.
                {
                    db.Books.Add(new Models.Book
                    {
                        Title = "Cabal (Nightbreed)",
                        AuthorId = db.Authors.FirstOrDefault(a => a.Name == "Clive Barker").Id,
                        Price = 250,
                        Amount = 3,
                        CategoryId = db.BookCategories.FirstOrDefault(c => c.Name == "Horror").Id
                    });

                    db.Books.Add(new Models.Book
                    {
                        Title = "The Shining",
                        AuthorId = db.Authors.FirstOrDefault(a => a.Name == "Stephen King").Id,
                        Price = 200,
                        Amount = 2,
                        CategoryId = db.BookCategories.FirstOrDefault(c => c.Name == "Horror").Id
                    });

                    db.Books.Add(new Models.Book
                    {
                        Title = "Doctor Sleep",
                        AuthorId = db.Authors.FirstOrDefault(a => a.Name == "Stephen King").Id,
                        Price = 200,
                        Amount = 1,
                        CategoryId = db.BookCategories.FirstOrDefault(c => c.Name == "Horror").Id
                    });

                    db.Books.Add(new Models.Book
                    {
                        Title = "I Robot",
                        AuthorId = db.Authors.FirstOrDefault(a => a.Name == "Isaac Asimov").Id,
                        Price = 150,
                        Amount = 4,
                        CategoryId = db.BookCategories.FirstOrDefault(
                            c => c.Name == "Science Fiction").Id
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
