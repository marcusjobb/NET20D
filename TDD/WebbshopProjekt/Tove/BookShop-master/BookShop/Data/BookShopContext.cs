using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
        private const string DatabaseName = "WebbShopTove";
        public DbSet<User> Users { get; set;}
        public DbSet<BookCategory> BookCategories { get; set;}
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server= .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
        }
    }
}
