using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebbShopAPI.Models;

namespace WebbShopAPI.Database
{
    class WScontext : DbContext
    {
        private const string DatabaseName = "WebbshopCeciliaNilsson";
        public DbSet<Users> Users { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<SoldBooks> SoldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                $@"Server = LAPTOP-JDK5NA6M\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");

        }


    }
}
