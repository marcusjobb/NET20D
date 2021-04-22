using AssignmentTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentTwo.Database
{
    public class MyContext : DbContext
    {
        private const string DatabaseName = "WebbShopEliasHjelm";

        public DbSet<User> Users { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<SoldBook> SoldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server = .\SQLEXPRESS; Database = {DatabaseName}; Trusted_Connection = true;");
        }
    }
}