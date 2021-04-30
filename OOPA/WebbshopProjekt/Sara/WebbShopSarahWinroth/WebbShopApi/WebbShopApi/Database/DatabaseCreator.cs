using Microsoft.EntityFrameworkCore;

namespace WebbShopApi.Database
{
    public static class DatabaseCreator
    {
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