using Inlämning2.Models;
using Microsoft.EntityFrameworkCore;


namespace Inlämning2.Database
{
    /// <summary>
    /// Klaasen för databasen och kopplingar till tabellerna.
    /// </summary>
    public class WSContext : DbContext
    {
        private const string DatabaseName = "WebbShopSammyWong";
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook>SoldBooks { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                $@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true;");
        }
    }
}
