using Microsoft.EntityFrameworkCore;
using WebbShopAPI.Models;

namespace WebbShopAPI.Database
{
    /// <summary>
    /// Denna klassen skapar upp en databas med tabeller.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        private const string DatabaseName = "WebbShopNilsOdén";
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<SoldBooks> SoldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLExpress;Database={DatabaseName}; Trusted_Connection = true;");
        }
    }
}