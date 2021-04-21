namespace WebbShopAPI.Database
{
    using Microsoft.EntityFrameworkCore;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="WebbShopContext" />.
    /// </summary>
    internal class WebbShopContext : DbContext
    {
        /// <summary>
        /// Defines the DatabaseName.
        /// </summary>
        private const string DatabaseName = "WebbShopFarzane";

        /// <summary>
        /// Gets or sets the Users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the Books.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the SoldBooks.
        /// </summary>
        public DbSet<SoldBook> SoldBooks { get; set; }

        /// <summary>
        /// Gets or sets the BookCategories.
        /// </summary>
        public DbSet<BookCategory> BookCategories { get; set; }

        /// <summary>
        /// To set OnConfiguring method
        /// </summary>
        /// <param name="optionsBuilder">The optionsBuilder<see cref="DbContextOptionsBuilder"/>.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName}; Trusted_Connection = true;");
        }
    }
}
