using Microsoft.EntityFrameworkCore;
using WebbShopIvoNazlic.Models;

namespace WebbShopIvoNazlic.Database
{
    /// <remarks>
    /// Handles database data
    /// </remarks>
    public class BookDatabase : DbContext
    {
        public string DatabaseName { get; set; } = "WebbShopIvoNazlic";

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> BookCategories { get; set; }

        public DbSet<SoldBook> SoldBooks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ($@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
        }

    }
}
