using Microsoft.EntityFrameworkCore;
using WebbShopAPI.Models;

namespace WebbShopAPI.Data
{
    /// <summary>
    /// Call this class to get a open connection to the database.
    /// </summary>
    public class DBContext : DbContext
    {
        private const string DatabaseName = "WebbShopNicklasEriksson";
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }

        /// <summary>
        /// Connection to the database.
        /// Change this to match you local database! I myself got more than one.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change so this works with your local database (Server=x).
            optionsBuilder.UseSqlServer(@$"Server=.\SQLEXPRESS01;Database={DatabaseName};trusted_connection=true;");
        }
    }    
}
