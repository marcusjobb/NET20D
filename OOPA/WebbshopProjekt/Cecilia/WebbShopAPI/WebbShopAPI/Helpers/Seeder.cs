using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI.Helpers
{
    public class Seeder
    {
        public void AddData()
        {
            bool admin = true;
            bool notAdmin = false;
            string defaultPassword = "Codic2021";
            using (var db = new WScontext())
            {
                CreateUser("Administrator", "CodicRulez", admin);
                CreateUser("TestCustomer", defaultPassword, notAdmin);

                CreateCategory("Horror");
                CreateCategory("Humor");
                CreateCategory("Science Fiction");
                CreateCategory("Romance");

                CreateBook("Cabal (Nightbreed)", "Clive Barker", 250, 3, "Horror");
                CreateBook("The Shinning", "Stephen King", 200, 2, "Horror");
                CreateBook("Doctor Sleep", "Stephen King", 200, 1, "Horror");
                CreateBook("I Robot", "Isaac Asimov", 150, 4, "Science Fiction");
            }

        }

        public static Users CreateUser(string name, string password, bool adminCheck)
        {

            using (var db = new WScontext())
            {
                var user = db.Users.
                    FirstOrDefault(
                    u => u.Name == name
                    );

                if (user == null)
                {
                    user = new Users { 
                        Name = name, 
                        Password = password, 
                        IsAdmin = adminCheck 
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return user;
            }
        }

        public static BookCategory CreateCategory(string name)
        {

            using (var db = new WScontext())
            {
                var category = db.BookCategories.
                    FirstOrDefault(
                    c => c.Name == name
                    );

                if (category == null)
                {
                    category = new BookCategory { Name = name };
                    db.BookCategories.Add(category);
                    db.SaveChanges();
                }
                return category;
            }

        }

        public static Books CreateBook(string title, string author, int price, int amount, string category)
        {

            using (var db = new WScontext())
            {
                var book = db.Books.
                    FirstOrDefault(
                    b => b.Title == title
                    );

                if (book == null)
                {
                    book = new Books
                    {
                        Title = title,
                        Author = author,
                        Price = price,
                        Amount = amount,
                        Category = db.BookCategories.FirstOrDefault(c => c.Name == category)
                };
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                return book;
            }

        }


    }
}
