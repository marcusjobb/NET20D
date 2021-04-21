using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Model;

namespace WebbShopAPI.Database
{
    public static class SeederClass
    {
        /// <summary>
        /// Pupulates the default values of the table
        /// </summary>
        public static bool FillUserTable()
        {
            using (var db = new WebbShopLeeContext())
            {
                try
                {
                    var u = db.Users.Where(_ => _.ID > 0).ToList();
                    if (u.Count == 0)
                    {
                        Console.WriteLine("Adding default users");
                        db.Users.AddRange(new List<User>
                        {
                        new User { Name = "Administrator", Password = "CodicRulez", IsAdmin = true, IsActive = true },
                    new User { Name = "TestCustomer", Password = "Codic2021", IsAdmin = false, IsActive = true }
                    });
                        db.SaveChanges();
                    };
                    return true;
                }
                catch (Exception e)
                {
                    string a = e.ToString();
                    Console.WriteLine("No user added");
                }
            }
            return false;
        }

        /// <summary>
        /// Pupulates the default values of the table
        /// </summary>
        public static bool FillCategoryTable()
        {
            using (var db = new WebbShopLeeContext())
            {
                try
                {
                    var c = db.BookCategories.Where(_ => _.ID > 0).ToList();
                    if (c.Count == 0)
                    {
                        Console.WriteLine("Adding default categories");
                        db.BookCategories.AddRange(new List<BookCategory>
                    {

                    new BookCategory { Name = "Horror" },
                    new BookCategory { Name = "Comedy" },
                    new BookCategory { Name = "Sci-fi" },
                    new BookCategory { Name = "Romance" },
                    });

                        db.SaveChanges();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return false;
        }
        /// <summary>
        /// Pupulates the default values of the table
        /// </summary>
        public static bool FillBooksTable()
        {
            using (var db = new WebbShopLeeContext())
            {
                try
                {
                    var t = db.Books.Where(_ => _.ID > 0).ToList();
                    if (t.Count == 0)
                    {
                        Console.WriteLine("Adding default tables");
                        var horror = db.BookCategories.FirstOrDefault(_ => _.Name == "Horror");
                        var sciFi = db.BookCategories.FirstOrDefault(_ => _.Name == "Sci-fi");
                        db.Books.AddRange(new List<Book>
                            {
                                new Book { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3,
                                    CategoryID = horror.ID},
                                new Book { Title = "The Shining", Author = "Stephen King", Price = 200, Amount = 2,
                                    CategoryID = horror.ID},
                                new Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1,
                                    CategoryID = horror.ID},
                                new Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4,
                                    CategoryID = sciFi.ID},
                            }
                        );
                        db.SaveChanges();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return false;
        }
    }

    
}

