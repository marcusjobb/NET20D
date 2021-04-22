using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Inlamn2WebbShop_MLarsson.Database
{
    /// <summary>
    /// Text och metod av Marcus Medina.
    /// En klass som talar om för vårt program att
    ///uppdatera databasen och köra alla migrationer.
    /// </summary>
    public static class DatabaseCreator
    {
        public static void Create()
        {
            var contextFactory = new ContextFactory();
            using (var dbContext = contextFactory.CreateDbContext())
            {
                //Gör att du slipper använda dig av update-database i Package Manager Console
                dbContext.Database.Migrate();
            }
        }
    }
}
