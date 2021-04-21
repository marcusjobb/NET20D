using Microsoft.EntityFrameworkCore;
using WebbShopEmil.Models;

namespace WebbShopEmil.Database
{
    /// <summary>
    /// Defines the webbshop context.
    /// </summary>
    public class WebbShopContext : DbContext
    {
        /// <summary>
        /// Datebasename.
        /// </summary>
        public string DatabaseName { get; set; } = "WebbShopEmilÖrjes";

        /// <summary>
        /// The Models DBset.
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }

        /// <summary>
        /// Makes connection to database.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
        }
    }
}