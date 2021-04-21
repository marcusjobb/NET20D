using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Database
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Our database name
        /// </summary>
        private const string DatabaseName = "WebbshopJonnaWiberg";

        /// <summary>
        /// Our main database tables
        /// </summary>
        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }

        /// <summary>
        /// Letting EF know that we are using SQL express server
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName};Trusted_Connection = true;");
        }

        /// <summary>
        /// Method to help me change the name of the Book/Category many to many relations table to a custom name
        /// https://stackoverflow.com/questions/66634418/entity-framework-change-name-of-generated-many-to-many-table
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .HasMany(b => b.BookCategories)
                .WithMany(bc => bc.Books)
                .UsingEntity(j => j.ToTable("BookCategoryId"));
        }
    }
}