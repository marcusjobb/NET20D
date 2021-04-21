using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebshopAPI.Database
{
    /// <summary>
    /// Class containing functions for setting up Context and optionsBuilder
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<EFContext>
    {
        /// <summary>
        /// Database name field
        /// </summary>
        private const string DatabaseName = "WebshopViktorSalmberg";

        /// <summary>
        /// Creates object of Context for use in DatabaseCreator.cs
        /// </summary>
        /// <param name="args"></param>
        /// <returns>EFContext(CreateOptions)</returns>
        public EFContext CreateDbContext(params string[] args)
        {
            return new EFContext(CreateOptions());
        }

        /// <summary>
        /// Creates optionsBuilder for use in Context constructor in ContextFactory.cs. Sets ConnectionString.
        /// </summary>
        /// <returns>DbContextOptions</returns>
        public DbContextOptions<EFContext> CreateOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
            optionsBuilder.UseSqlServer($@"Server =
.\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
            return optionsBuilder.Options;
        }
    }
}