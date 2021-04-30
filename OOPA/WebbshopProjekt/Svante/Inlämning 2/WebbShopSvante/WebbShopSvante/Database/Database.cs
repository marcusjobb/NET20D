using Microsoft.EntityFrameworkCore;
using WebbShopAPI.Models;

namespace WebbShopAPI.Database
{
    public class EFContext : DbContext
    {
        private const string DatabaseName = "WebbShopSvante";
        public DbSet<BookGenre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName};
                                        Trusted_Connection = true;");
        }
    }
}