using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Models;

namespace WebbShopAPI.Database
{
    public class EFContext : DbContext
    {
        private const string DatabaseName = "WebbShopJohanJangerud";
        public DbSet<User> Users { get; set; }

        public DbSet<BookCategory> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<SoldBook> SoldBooks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName};Trusted_Connection = true;");

        }

    }
}
