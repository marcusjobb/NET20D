using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebbshopProject.Models;

namespace WebbshopProject.Database
{
    public class WebbshopDatabase : DbContext
    {
        /// <summary>
        /// A entity set for Users that can be used for CRUD (Create, Read,
        /// Update and Delete).
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// A entity set for Books that can be used for CRUD (Create, Read,
        /// Update and Delete).
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// A entity set for Soldbooks that can be used for CRUD(Create, Read,
        /// Update and Delete).
        /// </summary>
        public DbSet<SoldBook> SoldBooks { get; set; }
        /// <summary>
        /// A entity set for BookCategories that can be used for CRUD(Create, Read,
        /// Update and Delete).
        /// </summary>
        public DbSet<BookCategory> BookCategories { get; set; }

        /// <summary>
        /// A constructor to the database class that takes a parameter
        /// with database settings.
        /// </summary>
        /// <param name="options"></param>
        public WebbshopDatabase(DbContextOptions<WebbshopDatabase> 
            options) : base(options) { }

        /// <summary>
        /// A constructor to the database class without
        /// parameter.
        /// </summary>
        public WebbshopDatabase() : base(ContextFactory.
            CreateOptions()) { }
    }
}

//The DbSet class represents an entity set that can be used for create, read, update, and delete 