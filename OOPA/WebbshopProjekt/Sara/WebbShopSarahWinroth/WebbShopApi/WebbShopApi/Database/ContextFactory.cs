using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebbShopApi.Database
{
    internal class ContextFactory : IDesignTimeDbContextFactory<WebShopContext>
    {
        private const string DatabaseName = "WebbShopSarahWinroth";
        /// <summary>
        /// Skapar först en instans av databasinställningarna (CreateOptions()) och en instans av databasen som metoden returnerar.
        /// </summary>
        public WebShopContext CreateDbContext(params string[] args)
        {
            return new WebShopContext(CreateOptions());
        }
        /// <summary>
        /// Skapar databasinställningarna åt databasen
        /// </summary>
        public DbContextOptions<WebShopContext> CreateOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebShopContext>();
            optionsBuilder.UseSqlServer($@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
            return optionsBuilder.Options;
        }
    }
}