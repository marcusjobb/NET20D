using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopProject.Database
{
    class ContextFactory : IDesignTimeDbContextFactory<WebbshopDatabase>
    {
        /// <summary>
        /// A variable to keep track of the database name.
        /// </summary>
        private const string DatabaseName = "WebbshopTinaEriksson";

        /// <summary>
        /// Creates an instance of the database, and then returns it.
        /// But before the return it is going to create an instance of 
        /// the database settings.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public WebbshopDatabase CreateDbContext(params string[] args)
        {
            return new WebbshopDatabase(CreateOptions());
        }

        /// <summary>
        /// Creates the settings for the database, and then returns them.
        /// </summary>
        /// <returns></returns>
        public static DbContextOptions<WebbshopDatabase> CreateOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebbshopDatabase>();
            optionsBuilder.UseSqlServer(
                $@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true;");
            return optionsBuilder.Options;
        }
    }
}