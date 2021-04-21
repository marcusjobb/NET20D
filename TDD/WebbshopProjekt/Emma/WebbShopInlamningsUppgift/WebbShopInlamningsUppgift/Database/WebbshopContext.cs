using Microsoft.EntityFrameworkCore;
using WebbShopInlamningsUppgift.Models;

namespace WebbShopInlamningsUppgift.Database
{
    /// <summary>
    /// Database context
    /// </summary>
    public class WebbshopContext : DbContext
    {
        private const string DatabaseName = "WebbShopEmmaL";
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<SoldBooks> SoldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                $@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
        }

    }
}
