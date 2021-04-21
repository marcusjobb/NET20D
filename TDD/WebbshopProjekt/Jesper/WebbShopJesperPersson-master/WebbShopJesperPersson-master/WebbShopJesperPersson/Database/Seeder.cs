using System.Collections.Generic;
using System.Linq;
using WebbShopJesperPersson.Model;

namespace WebbShopJesperPersson.Database
{
    public class Seeder
    {
        /// <summary>
        /// Adds mockdata to database.
        /// Adds users, category and books.
        /// </summary>
        public void Seed()
        {
            var apiHelper = new APIHelper();
            if (apiHelper.GetUser(1) == null)
            {
                SeedCatergory();
                SeedUser();
                SeedBook("Cabal Nightbreed", "Clive Barker", 250, 3, "Horror");
                SeedBook("The Shining", "Stephen King", 200, 2, "Horror");
                SeedBook("Doctor Sleep", "Stephen King", 200, 1, "Horror");
                SeedBook("I Robot", "Isaac Asimov", 150, 4, "Science Fiction");
            }
        }

        /// <summary>
        /// adds values to category table.
        /// </summary>
        private void SeedCatergory()
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Categories.Count() == 0)
                {
                    db.Categories.Add(new BookCategory { Name = "Horror" });
                    db.Categories.Add(new BookCategory { Name = "Humor" });
                    db.Categories.Add(new BookCategory { Name = "Science Fiction" });
                    db.Categories.Add(new BookCategory { Name = "Romance" });
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// adds value to Users table.
        /// </summary>
        private void SeedUser()
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User { Name = "Administrator", Password = "CodicRulez", IsAdmin = true });
                    db.Users.Add(new User { Name = "TestCustomer", Password = "Codic2021" });
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to create new books and connect a category to the book.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <param name="category"></param>
        private void SeedBook(string title, string author, double price, int amount, string category)
        {
            using (var db = new ApplicationDbContext())
            {
                var book = new Book { Title = title, Author = author, Price = price, Amount = amount };

                db.Books.Add(book);

                var bookCategory = db.Categories.FirstOrDefault(c => c.Name == category);
                if (bookCategory != null)
                {
                    if (bookCategory.Books == null) bookCategory.Books = new List<Book>();

                    bookCategory.Books.Add(book);
                }

                db.SaveChanges();
            }
        }
    }
}