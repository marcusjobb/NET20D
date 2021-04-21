using Microsoft.EntityFrameworkCore;

namespace WebshopAPI.Database
{
    /// <summary>
    /// Class for creating database based on ContextFactory.cs
    /// </summary>
    public static class DatabaseCreator
    {
        /// <summary>
        /// Creates instance of ContextFactory.cs and uses the instance for migrating to database set by CreateOptions()
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