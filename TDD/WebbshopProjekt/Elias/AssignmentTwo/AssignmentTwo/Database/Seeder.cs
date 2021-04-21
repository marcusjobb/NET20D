using System.Linq;

namespace AssignmentTwo.Database
{
    public static class Seeder
    {
        public static void Seed()
        {
            using (var db = new MyContext())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new Models.User { Name = "Administrator", Password = "CodicRulez", IsActive = true, IsAdmin = true });
                    db.Users.Add(new Models.User { Name = "TestCustomer", Password = "Codic2021", IsActive = true, IsAdmin = false });
                    db.SaveChanges();
                }

                if (db.BookCategories.Count() == 0)
                {
                    db.BookCategories.Add(new Models.BookCategory { Name = "Horror" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Humor" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Science Fiction" });
                    db.BookCategories.Add(new Models.BookCategory { Name = "Romance" });
                    db.SaveChanges();
                }
                if (db.Books.Count() == 0)
                {
                    var horror = db.BookCategories.FirstOrDefault(c => c.Name == "Horror");
                    var humor = db.BookCategories.FirstOrDefault(c => c.Name == "Humor");
                    var scienceFiction = db.BookCategories.FirstOrDefault(c => c.Name == "Science Fiction");
                    var romance = db.BookCategories.FirstOrDefault(c => c.Name == "Romance");

                    db.Books.Add(new Models.Book { Title = "Cabal (Nightbreed)", Author = "Clive Barker", Price = 250, Amount = 3, CategoryId = horror.Id });
                    db.Books.Add(new Models.Book { Title = "The Shining", Author = "Stephen King", Price = 200, Amount = 2, CategoryId = horror.Id });
                    db.Books.Add(new Models.Book { Title = "Doctor Sleep", Author = "Stephen King", Price = 200, Amount = 1, CategoryId = horror.Id });
                    db.Books.Add(new Models.Book { Title = "I Robot", Author = "Isaac Asimov", Price = 150, Amount = 4, CategoryId = scienceFiction.Id });
                    db.SaveChanges();
                }
            }
        }
    }
}