using System.Linq;

namespace WebbShopEmil.Database
{
   public class Seeder
    {
        private const int Zero = 0;

        /// <summary>
        /// Creates objects to the database.
        /// </summary>
        public static void Seed()
        {
            using (var db = new WebbShopContext())
            {
                if (db.Users.Count() == Zero)
                {
                    db.Users.Add(new Models.User { Name = "Administrator", Password = "CodicRulez", IsAdmin = true, IsActive = true });
                    db.Users.Add(new Models.User { Name = "TestCustomer", Password = "Codic2021", IsAdmin = false, IsActive = true });
                    db.SaveChanges();
                }

                if (db.BookCategories.Count() == Zero)
                {
                    db.BookCategories.Add(new Models.BookCategory { Name = "Horror" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Humor" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Science Fiction" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Romance" });
                    db.SaveChanges();
                }

                if (db.Books.Count() == Zero)
                {
                    db.Books.Add(new Models.Book { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, Category = db.BookCategories.FirstOrDefault(c => c.Name == "Horror") });
                    db.Books.Add(new Models.Book { Title = "The Shinng", Author = "Stephen King", Price = 200, Amount = 2, Category = db.BookCategories.FirstOrDefault(c => c.Name == "Horror") });
                    db.Books.Add(new Models.Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, Category = db.BookCategories.FirstOrDefault(c => c.Name == "Horror") });
                    db.Books.Add(new Models.Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, Category = db.BookCategories.FirstOrDefault(c => c.Name == "Science Fiction") });
                    db.SaveChanges();
                }
            }
        }
    }
}