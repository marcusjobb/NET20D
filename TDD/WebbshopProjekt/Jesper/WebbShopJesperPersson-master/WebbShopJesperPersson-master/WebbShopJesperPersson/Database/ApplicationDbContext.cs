using Microsoft.EntityFrameworkCore;
using WebbShopJesperPersson.Model;

namespace WebbShopJesperPersson.Database
{
    public class ApplicationDbContext : DbContext
    {
        public string DatabaseName { get; set; } = "WebbshopJP";

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }

        /// <summary>
        /// Open up the connection with database.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"Server= .\SQLEXPRESS;Database={DatabaseName};Trusted_Connection=True;");
        }
    }
}