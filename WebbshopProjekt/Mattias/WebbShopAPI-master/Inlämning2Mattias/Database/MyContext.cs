using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbShopAPI.Models
{
    public class MyContext : DbContext
    {
        private const string DatabaseName = "WebbshopMattias";
        public DbSet<User> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookCategory> Category { get; set; }
        public DbSet<SoldBooks> SoldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"Server=.\SQLEXPRESS;Database={DatabaseName};trusted_connection=true;");
        }
    }
}
