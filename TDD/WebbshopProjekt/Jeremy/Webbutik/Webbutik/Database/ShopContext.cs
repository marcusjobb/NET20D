using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Webbutik.Models;

namespace Webbutik.Database
{
    class ShopContext : DbContext
    {
        /// <summary>
        /// The database name.
        /// </summary>
        private const string DatabaseName = "WebbShopJeremyMatthiessen";

        /// <summary>
        /// The BookCategory table.
        /// </summary>
        public DbSet<BookCategory> BookCategories { get; set; }
        
        /// <summary>
        /// The Author table.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// The User table.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// The Book table.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// The SoldBook table.
        /// </summary>
        public DbSet<SoldBook> SoldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Data Source=(localdb)\MSSQLLocalDB;
                Database={DatabaseName};Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoldBook>().HasOne(c => c.Category).WithMany(c => c.SoldBooks)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
