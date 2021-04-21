using WebbShopAPI.Data;
using WebbShopAPI.Models;
using System.Linq;

namespace WebbShopAPI.Seeder
{
    public class Seed
    {        
        /// <summary>
        /// Seeds the database with 1 admin.
        /// </summary>
        /// <returns>True if passed.</returns>
        public static bool AdminSeed()
        {
            using (var db = new DBContext())
            {
                var admin = new User
                {
                    FirstName = "Admin",
                    Surname = "Admin",
                    Username = "CodicRulez",
                    Password = "Codic2021",
                    Admin = true
                };

                var user = db.Users.FirstOrDefault(u => admin.Username == u.Username && admin.Password == u.Password);

                if (user == null)
                {
                    db.Update(admin);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Seeds the database with 8 categories.
        /// </summary>
        /// <returns>True if passed.</returns>
        public static bool CategorySeed()
        {
            using (var db = new DBContext())
            {
                try
                {
                    db.Categories.AddRange
                    (
                        new Category { Title = "Science Fiction" },
                        new Category { Title = "Horror" },
                        new Category { Title = "Action" },
                        new Category { Title = "Comedy" },
                        new Category { Title = "Novel" },
                        new Category { Title = "Thriller" },
                        new Category { Title = "Biography" },
                        new Category { Title = "Romance" }
                    );
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Seeds the database with 4 authors.
        /// </summary>
        /// <returns>True if passed.</returns>
        public static bool AuthorSeed()
        {
            using (var db = new DBContext())
            {
                try
                {
                    db.Authors.AddRange
                    (
                    new Author { FirstName = "Clive", Surname = "Barker" },
                    new Author { FirstName = "Stephen", Surname = "King" },
                    new Author { FirstName = "Lee", Surname = "Child" },
                    new Author { FirstName = "Isaac", Surname = "Asimov" }
                    );
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Seeds the database with some books, mostly books by Lee Child's Jack Reacher-series.
        /// </summary>
        /// <returns>True if passed.</returns>
        public static bool BookSeed()
        {
            var api = new WebShopAPI();
            using (var db = new DBContext())
            {
                try
                {
                    #region Books from Marcus
                    db.Books.AddRange
                    (
                        new Book
                        {
                            Title = "Cabal (Nightbreed)",
                            Author = api.GetAuthors("Clive", "Barker", db),
                            Categories = WebShopAPI.GetCategory("Horror", db),
                            Price = 250,
                            Stock = 3
                        },
                    new Book
                    {
                        Title = "The Shining",
                        Author = api.GetAuthors("Stephen", "King", db),
                        Categories = WebShopAPI.GetCategory("Horror", db),
                        Price = 200,
                        Stock = 2
                    },
                    new Book
                    {
                        Title = "Doctor Sleep",
                        Author = api.GetAuthors("Stephen", "King", db),
                        Categories = WebShopAPI.GetCategory("Horror", db),
                        Price = 200,
                        Stock = 1
                    },
                    new Book
                    {
                        Title = "I Robot",
                        Author = api.GetAuthors("Isaac", "Asimov", db),
                        Categories = WebShopAPI.GetCategory("Science Fiction", db),
                        Price = 150,
                        Stock = 4
                    },
                    #endregion Books from Marcus

                    #region Books from Lee Child

                new Book
                {
                    Title = "Killing Floor",
                    Author = api.GetAuthors("Lee", "Child", db),
                    Categories = WebShopAPI.GetCategory("Thriller", db),
                    Price = 200,
                    Stock = 4
                },
                     new Book
                     {
                         Title = "Die Trying",
                         Author = api.GetAuthors("Lee", "Child", db),
                         Categories = WebShopAPI.GetCategory("Thriller", db),
                         Price = 200,
                         Stock = 4
                     },
                      new Book
                      {
                          Title = "Tripwire",
                          Author = api.GetAuthors("Lee", "Child", db),
                          Categories = WebShopAPI.GetCategory("Thriller", db),
                          Price = 200,
                          Stock = 4
                      },
                       new Book
                       {
                           Title = "Running Blind",
                           Author = api.GetAuthors("Lee", "Child", db),
                           Categories = WebShopAPI.GetCategory("Thriller", db),
                           Price = 200,
                           Stock = 4
                       },
                        new Book
                        {
                            Title = "Echo Burning",
                            Author = api.GetAuthors("Lee", "Child", db),
                            Categories = WebShopAPI.GetCategory("Thriller", db),
                            Price = 200,
                            Stock = 4
                        },
                         new Book
                         {
                             Title = "Without Fail",
                             Author = api.GetAuthors("Lee", "Child", db),
                             Categories = WebShopAPI.GetCategory("Thriller", db),
                             Price = 200,
                             Stock = 4
                         },
                          new Book
                          {
                              Title = "Persuader",
                              Author = api.GetAuthors("Lee", "Child", db),
                              Categories = WebShopAPI.GetCategory("Thriller", db),
                              Price = 200,
                              Stock = 4
                          },
                           new Book
                           {
                               Title = "The Enemy",
                               Author = api.GetAuthors("Lee", "Child", db),
                               Categories = WebShopAPI.GetCategory("Thriller", db),
                               Price = 200,
                               Stock = 4
                           },
                            new Book
                            {
                                Title = "One Shot",
                                Author = api.GetAuthors("Lee", "Child", db),
                                Categories = WebShopAPI.GetCategory("Thriller", db),
                                Price = 200,
                                Stock = 4
                            },
                             new Book
                             {
                                 Title = "The Hard Way",
                                 Author = api.GetAuthors("Lee", "Child", db),
                                 Categories = WebShopAPI.GetCategory("Thriller", db),
                                 Price = 200,
                                 Stock = 4
                             },
                              new Book
                              {
                                  Title = "Bad Luck And Trouble",
                                  Author = api.GetAuthors("Lee", "Child", db),
                                  Categories = WebShopAPI.GetCategory("Thriller", db),
                                  Price = 200,
                                  Stock = 4
                              },
                               new Book
                               {
                                   Title = "Nothing To Lose",
                                   Author = api.GetAuthors("Lee", "Child", db),
                                   Categories = WebShopAPI.GetCategory("Thriller", db),
                                   Price = 200,
                                   Stock = 4
                               },
                                new Book
                                {
                                    Title = "Gone Tomorrow",
                                    Author = api.GetAuthors("Lee", "Child", db),
                                    Categories = WebShopAPI.GetCategory("Thriller", db),
                                    Price = 200,
                                    Stock = 4
                                },
                                 new Book
                                 {
                                     Title = "61 Hours",
                                     Author = api.GetAuthors("Lee", "Child", db),
                                     Categories = WebShopAPI.GetCategory("Thriller", db),
                                     Price = 200,
                                     Stock = 4
                                 },
                                  new Book
                                  {
                                      Title = "Worth Dying For",
                                      Author = api.GetAuthors("Lee", "Child", db),
                                      Categories = WebShopAPI.GetCategory("Thriller", db),
                                      Price = 200,
                                      Stock = 4
                                  },
                                   new Book
                                   {
                                       Title = "The Affair",
                                       Author = api.GetAuthors("Lee", "Child", db),
                                       Categories = WebShopAPI.GetCategory("Thriller", db),
                                       Price = 200,
                                       Stock = 4
                                   },
                                    new Book
                                    {
                                        Title = "A Wanted Man",
                                        Author = api.GetAuthors("Lee", "Child", db),
                                        Categories = WebShopAPI.GetCategory("Thriller", db),
                                        Price = 200,
                                        Stock = 4
                                    },
                                     new Book
                                     {
                                         Title = "Never Go Back",
                                         Author = api.GetAuthors("Lee", "Child", db),
                                         Categories = WebShopAPI.GetCategory("Thriller", db),
                                         Price = 200,
                                         Stock = 4
                                     },
                                      new Book
                                      {
                                          Title = "Personal",
                                          Author = api.GetAuthors("Lee", "Child", db),
                                          Categories = WebShopAPI.GetCategory("Thriller", db),
                                          Price = 200,
                                          Stock = 4
                                      },
                                       new Book
                                       {
                                           Title = "Make Me",
                                           Author = api.GetAuthors("Lee", "Child", db),
                                           Categories = WebShopAPI.GetCategory("Thriller", db),
                                           Price = 200,
                                           Stock = 4
                                       },
                                        new Book
                                        {
                                            Title = "Night School",
                                            Author = api.GetAuthors("Lee", "Child", db),
                                            Categories = WebShopAPI.GetCategory("Thriller", db),
                                            Price = 200,
                                            Stock = 4
                                        },
                                         new Book
                                         {
                                             Title = "The Midnight Line",
                                             Author = api.GetAuthors("Lee", "Child", db),
                                             Categories = WebShopAPI.GetCategory("Thriller", db),
                                             Price = 200,
                                             Stock = 4
                                         },
                                          new Book
                                          {
                                              Title = "Past Tense",
                                              Author = api.GetAuthors("Lee", "Child", db),
                                              Categories = WebShopAPI.GetCategory("Thriller", db),
                                              Price = 200,
                                              Stock = 4
                                          },
                                           new Book
                                           {
                                               Title = "Blue Moon",
                                               Author = api.GetAuthors("Lee", "Child", db),
                                               Categories = WebShopAPI.GetCategory("Thriller", db),
                                               Price = 200,
                                               Stock = 4
                                           },
                                            new Book
                                            {
                                                Title = "The Sentinel",
                                                Author = api.GetAuthors("Lee", "Child", db),
                                                Categories = WebShopAPI.GetCategory("Thriller", db),
                                                Price = 200,
                                                Stock = 4,
                                            }
                                            #endregion Books from Lee Child
            );
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
