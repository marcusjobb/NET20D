using System.Linq;
using WebbShopAPI.Models;

namespace WebbShopJoR.Helper
{/// <summary>
/// Class to add mockdata
/// </summary>
    public class Seeder
    {
        public void AddData()
        {
            AddUsers();
            AddCategory();
            AddBooks();
        }

        private void AddBooks()
        {
            if (API.db.Books.Count() == 0)
            {
                API.db.Books.Add(new Book
                {
                    Title = "Cabal",
                    Author = "Clive Barker",
                    Price = 250,
                    Amount = 3,
                    BookCategories =
                    (from c in API.db.BookCategories where c.Name == "Horror" select c).FirstOrDefault()
                });
                API.db.Books.Add(new Book
                {
                    Title = "The Shining",
                    Author = "Stephen King",
                    Price = 200,
                    Amount = 2,
                    BookCategories =
                    (from c in API.db.BookCategories where c.Name == "Horror" select c).FirstOrDefault()
                });
                API.db.Books.Add(new Book
                {
                    Title = "Doctor Sleep",
                    Author = "Stephen King",
                    Price = 200,
                    Amount = 1,
                    BookCategories =
                    (from c in API.db.BookCategories where c.Name == "Horror" select c).FirstOrDefault()
                });
                API.db.Books.Add(new Book
                {
                    Title = "I Robot",
                    Author = "Isaac Asimov",
                    Price = 150,
                    Amount = 4,
                    BookCategories =
                    (from c in API.db.BookCategories where c.Name == "Science Fiction" select c).FirstOrDefault()
                });
                API.db.SaveChanges();
            }
        }

        private void AddCategory()
        {
            if (API.db.BookCategories.Count() == 0)
            {
                API.db.BookCategories.Add(new BookCategory { Name = "Horror" });
                API.db.BookCategories.Add(new BookCategory { Name = "Humor" });
                API.db.BookCategories.Add(new BookCategory { Name = "Science Fiction" });
                API.db.BookCategories.Add(new BookCategory { Name = "Romance" });
                API.db.SaveChanges();
            }
        }

        private void AddUsers()
        {
            if (API.db.Users.Count() == 0)
            {
                API.db.Users.Add(new User { Name = "Administrator", Password = "CodicRulez", IsAdmin = true, IsActive = true });
                API.db.Users.Add(new User { Name = "TestCustomer", Password = "Codic2021", IsAdmin = false, IsActive = true });
                API.db.SaveChanges();
            }
        }
    }
}