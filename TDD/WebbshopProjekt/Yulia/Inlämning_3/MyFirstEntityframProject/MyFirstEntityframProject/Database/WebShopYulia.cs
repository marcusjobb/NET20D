using Microsoft.EntityFrameworkCore;

namespace MyFirstEntityframProject.Database
{
    public class WebShopYulia : DbContext
    {
       private const string DatabaseName = "WebShopYulia";
       
        //Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }
           

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ($@"Server=.\SQLEXPRESS; Database={DatabaseName}; Trusted_Connection = true;");

        }
       
    }
}
