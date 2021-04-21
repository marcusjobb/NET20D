namespace WebbShopApi.Database
{
    using Microsoft.EntityFrameworkCore;
    using WebbShopApi.Models;

    /// <summary>
    /// Defines the <see cref="MyContext" />.
    /// </summary>
    public class MyContext : DbContext
    { 
        private const string DatabaseName = "WebbShopAndreiKozel";

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }
        public DbSet<User> Users { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
        }
    }
}
