using Microsoft.EntityFrameworkCore;
using WebbShopAPI.Models;

namespace WebbShopAPI.Database
{
    /// <summary>
    /// Manages sessions with the database.
    /// </summary>
    class WebbShopAPIContext : DbContext
    {
        /// <summary>
        /// The database to connect to
        /// </summary>
        private const string DatabaseName = "WebbShopFredrikHoffmann";

        /// <summary>
        /// Collection of all users entities
        /// </summary>
        public DbSet<Users> Users { get; set; }
        /// <summary>
        /// Collection of all books entities
        /// </summary>
        public DbSet<Books> Books { get; set; }
        /// <summary>
        /// Collection of all book category entities
        /// </summary>
        public DbSet<BookCategory> BookCategories { get; set; }
        /// <summary>
        /// Collection of all soldbooks entities
        /// </summary>
        public DbSet<SoldBooks> SoldBooks { get; set; }
        /// <summary>
        /// Collection of all customer entities
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Allows you to configure the database connection.
        /// <para>Is called each time the context is created.</para>
        /// </summary>
        /// <param name="dbcob">Allows to modify or create options such as connection string or unique ids</param>
        protected override void OnConfiguring(DbContextOptionsBuilder dbcob)
        {
            dbcob.UseSqlServer(
                $@"Server=.\SQLEXPRESS;Database={DatabaseName};trusted_connection=true"
            );
        }
    }
}
