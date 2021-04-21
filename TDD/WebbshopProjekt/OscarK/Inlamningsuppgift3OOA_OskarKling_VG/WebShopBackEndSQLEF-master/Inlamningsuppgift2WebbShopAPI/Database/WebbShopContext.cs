using Inlamningsuppgift2WebbShopAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift2WebbShopAPI.Database
{
    /// <summary>
    /// This class is used to setup the database
    /// This class derives from DbContext.
    /// </summary>
    public class WebbShopContext : DbContext
    {
        private const string DatabaseName = "WebbShopOskarKling";

        /// <summary>
        /// Theese properties below will mirror the tables in the database and also shows the objects entity framework will use for each row in the tables.
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }


        /// <summary>
        /// Overries the OnCondiguring method from DbContext to change sql server connection to our liking.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change sql-connection to your liking, this one is my local.
            optionsBuilder.UseSqlServer($@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = {DatabaseName}; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

        }
    }
}
