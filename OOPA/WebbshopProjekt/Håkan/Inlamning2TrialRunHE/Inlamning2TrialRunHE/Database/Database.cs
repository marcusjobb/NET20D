using Inlamning2TrialRunHE.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlamning2TrialRunHE.Db
{
    public class Database : DbContext
    {
        private const string DatabaseName = "WebbshopHakanEriksson";

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;
                                        Database={DatabaseName};
                                        trusted_connection=true;");
        }
    }
}
