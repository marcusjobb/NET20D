using Inlämning_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämning_API.Database
{
    /// <summary>
    /// Defines the StoreContext 
    /// </summary>
    public class StoreContext : DbContext
    {
        public const string DatabaseName = "WebbShopApiTobiasBinett";

        /// <summary>
        /// The Models DBSet
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategories> BookCategory { get; set; }
        public DbSet<SoldBooks> SoldBooks { get; set; }

        /// <summary>
        /// Onconfiguring method
        /// </summary>
        /// <param name="optionsBuilder">OptionBuilder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"server=.\SQLEXPRESS;Database={DatabaseName};Trusted_Connection=true");
        }
    }
}