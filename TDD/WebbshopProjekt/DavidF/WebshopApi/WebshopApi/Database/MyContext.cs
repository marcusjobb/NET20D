using Microsoft.EntityFrameworkCore;
using WebshopApi.Models;

namespace WebshopApi.Database
{
    /// <summary>
    /// Klassen som kopplar sig till databasen
    /// </summary>
    internal class MyContext : DbContext
    {
        public string DatabaseName = "WebbShopDavidFrodin";
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Konfigurerar databasen WebbShoppDavidFrodin
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ($@"server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
        }
    }
}