using InlamningDB2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InlamningDB2.Database
{
    public class MyContext: DbContext 
    {
        private const string DatabaseName = "WebbShopSanjinAjanic";
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<Books> Book { get; set; }
        public DbSet<Soldbooks> SooldBook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=true;database={DatabaseName}");
        }
    }
}
