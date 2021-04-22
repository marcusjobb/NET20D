using Inlämning2WebbShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämning2WebbShop.Database
{
    public class WebbShopContext : DbContext
    {
        private const string DatabaseName = "WebbShopOscarMöller";

        /// <summary>
        /// skapar en tabell av Book
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// skapar en tabell av BookCategory
        /// </summary>
        public DbSet<BookCategory> Categories { get; set; }

        /// <summary>
        /// skapar en tabell av SoldBook
        /// </summary>
        public DbSet<SoldBook> SoldBooks { get; set; }

        /// <summary>
        /// skapar en tabell av User
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// konfigurerar databasen
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName}; Trusted_Connection = true;");
        }
    }
}