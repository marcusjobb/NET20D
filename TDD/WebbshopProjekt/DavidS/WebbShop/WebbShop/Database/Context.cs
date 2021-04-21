using Microsoft.EntityFrameworkCore;
using WebbShop.Models;

namespace WebbShop.Database
{
    public class Context : DbContext
    {
        /// <summary>
        /// The name of the database.
        /// </summary>
        private const string DatabaseName = "WebbShopDavidStröm";

        /// <summary>
        /// Gets and sets the table for the users in the database.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets and sets the table for the book categories in the database.
        /// </summary>
        public DbSet<BookCategory> BookCategories { get; set; }

        /// <summary>
        /// Gets and sets the table for the books in the database.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets and sets the table for the sold books in the database.
        /// </summary>
        public DbSet<SoldBook> SoldBooks { get; set; }

        /// <summary>
        /// The connection to the server.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLExpress;" +
                $"Database={DatabaseName};" +
                "trusted_connection=true");
        }
    }
}
