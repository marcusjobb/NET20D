using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPIGustafMalmsten.Model;

namespace WebbShopAPIGustafMalmsten.Database
{
    class Seeder
    {
        Databas Db { get; set; }
        public Seeder (Databas db) { Db = db; }
        public void Seed()
        {
            Db.Users.AddRange
            (
                new User[]
                {
                    new User{Name = "Administrator", IsAdmin = true, Password = "CodicRulez" },
                    new User{Name = "TestCustomer", Password = "Codic2021", IsAdmin = false},
                }
            );
            Db.BookCategories.AddRange
            ( 
                new BookCategory[]
                {
                    new BookCategory{BookCategoryName = "Horror"},
                    new BookCategory{BookCategoryName = "Humor"},
                    new BookCategory{BookCategoryName = "Science Fiction"},
                    new BookCategory{BookCategoryName = "Romance"},
                }
            );
            Db.Books.AddRange
            (
                new Book[]
                {
                    new Book{Title = "Cabal (Nightbreed)", Amount = 3, Author = "Clive Barker", Price = 250, BookCategoryID = 1, BookCategory = Db.BookCategories.FirstOrDefault(x => x.BookCategoryName.Equals("Horror")) },
                    new Book{Title = "The Shining", Amount = 2, Author = "Stephen King", Price = 200, BookCategoryID = 1, BookCategory = Db.BookCategories.FirstOrDefault(x => x.BookCategoryName.Equals("Horror"))},
                    new Book{Title = "Doctor Sleep", Amount = 1, Author = "Stephen King", Price = 200, BookCategoryID = 1, BookCategory = Db.BookCategories.FirstOrDefault(x => x.BookCategoryName.Equals("Horror"))},
                    new Book{Title = "I Robot", Amount = 4, Author = "Isaac Asimov", Price = 150, BookCategoryID = 2, BookCategory = Db.BookCategories.FirstOrDefault(x => x.BookCategoryName.Equals("Science Fiction"))},
                }
            );
            Db.SaveChanges();
        }
    }
}
