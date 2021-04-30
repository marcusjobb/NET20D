using Microsoft.EntityFrameworkCore;
using webshopAPI.Models;

namespace webshopAPI.Db
{
    public class Database : DbContext
    {
        /// <summary>
        /// Database name
        /// </summary>
        private const string DatabaseName = "WebbshopBennyChristensen";

        /// <summary>
        /// Table Users in the database
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Table Books in the database
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Table SoldBooks in the database
        /// </summary>
        public DbSet<SoldBook> SoldBooks { get; set; }

        /// <summary>
        /// Table BookCategories in the database
        /// </summary>
        public DbSet<BookCategory> BookCategories { get; set; }

        /// <summary>
        /// The server connectionstring
        /// </summary>
        /// <param name="optionsBuilder">Instance of the context builder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName};trusted_connection=true;");
        }
    }
}