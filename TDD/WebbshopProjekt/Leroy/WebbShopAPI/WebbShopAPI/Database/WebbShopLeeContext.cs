using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;

namespace WebbShopAPI.Database
{
    class WebbShopLeeContext : DbContext
    {
        /// <summary>
        /// Database name
        /// </summary>
        private const string DatabaseName = "WebbShopLee10";
        /// <summary>
        /// User Table
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Books table
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// Book category table
        /// </summary>
        public DbSet<BookCategory> BookCategories { get; set; }
        /// <summary>
        /// Sold book category
        /// </summary>
        public DbSet<SoldBook> SoldBooks { get; set; }
        /// <summary>
        /// Configuratin the database and tables function
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection = true");
        }
    }
}
