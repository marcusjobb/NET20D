using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopProject.Database
{
    public static class DatabaseCreator
    {
        /// <summary>
        /// Creates an instace of the ContextFactory class, and calls
        /// fot the method that creates an method for it. When that is
        /// done, it is going to call for the update-database method that
        /// is built in to the class.
        /// </summary>
        public static void Create()
        {
            var contextFactory = new ContextFactory();
            using (var dbContext = contextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
