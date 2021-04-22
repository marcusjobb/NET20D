using Microsoft.EntityFrameworkCore;
using WebbShopAPI.Models;

namespace WebbShopAPI.Database
{
    public class MyContext : DbContext
    {
        private const string DatabaseName = "WebbShopJosefineRönnqvist";
        public DbSet<User> Models { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName};
                                        Trusted_Connection = true;");
        }
    }
}
