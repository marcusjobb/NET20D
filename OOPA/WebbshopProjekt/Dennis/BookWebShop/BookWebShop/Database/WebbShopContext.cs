using BookWebShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebShop.Database
{
    public class WebbShopContext : DbContext
    {
        /// <summary>
        /// Class to handle the Database.
        /// </summary>

        public string DatabaseName { get; set; } = "WebbShopDennisLindquist";

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<SoldBook> SoldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName};Trusted_Connection=true;");
        }
    }
}