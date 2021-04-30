using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebbShopApi.Models;

namespace WebbShopApi.Database
{
    public class WebShopContext : DbContext
    {
        /// <summary>
        /// DbSet för User-, Books-, SoldBooks- och Categories-tabellen som skapar en länk mellan databastabellerna och programmet. 
        /// En konstruktor för databas-klassen som tar emot databasinställningarna som parameter och 
        /// en konstruktor som anropar metoden i klassen ContextFactory som skapar databasinställningarna.
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public WebShopContext(DbContextOptions<WebShopContext> options) : base(options) { }
        public WebShopContext() : base(new ContextFactory().CreateOptions()) { }
    }
}
