using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebbShopApi.Models;

namespace WebbShopApi.Database
{
    /// <summary>
    /// Defines the <see cref="Seeder" />.
    /// </summary>
    public static class Seeder
    {
        /// <summary>
        /// Create basic data
        /// </summary>
        public static void Seed()
        {
            using (var db = new MyContext())
            {
                if (db.BookCategories.Count() == 0)
                {
                    // create categories
                    db.BookCategories.Add(new BookCategory { Name = "Horror" });
                    db.BookCategories.Add(new BookCategory { Name = "Humor" });
                    db.BookCategories.Add(new BookCategory { Name = "Science Fiction" });
                    db.BookCategories.Add(new BookCategory { Name = "Romance" });
                    db.SaveChanges();


                    if (db.Users.Count() == 0)
                    {
                        // add users
                        db.Users.Add(new User { Name = "CodicRulez", IsAdmin = true });
                        db.Users.Add(new User { Name = "Codic2021", IsAdmin = false });
                        db.SaveChanges();
                    }

                    // get categories id
                    var horrorId = db.BookCategories.Single(c => c.Name == "Horror").BookCategoryId;
                    var scienceId = db.BookCategories.Single(c => c.Name == "Science Fiction").BookCategoryId;

                    if (db.Books.Count() == 0)
                    {
                        // add books
                        db.Books.Add(new Book { Name = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, BookCategoryId = horrorId });
                        db.Books.Add(new Book { Name = "The Shining", Author = "Stephen King", Price = 200, Amount = 2, BookCategoryId = horrorId });
                        db.Books.Add(new Book { Name = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, BookCategoryId = horrorId });
                        db.Books.Add(new Book { Name = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, BookCategoryId = scienceId });
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}