using Microsoft.EntityFrameworkCore;
using WebshopAPI.Models;

namespace WebshopAPI.Database
{
    /// <summary>
    /// Class containing Context constructors and DBSet(s)
    /// </summary>
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }

        /// <summary>
        /// Context constructor for creating the initial context used in setting up database
        /// </summary>
        /// <param name="options"></param>
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        /// <summary>
        /// Context constructor for creating new connection to database
        /// </summary>
        public EFContext() : base(new ContextFactory().CreateOptions())
        {
        }
    }
}