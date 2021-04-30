using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inlamn2WebbShop_MLarsson.Database
{
    /// <summary>
    /// Text och metod av Marcus Medina.
    /// Den här klassen baserar sig på interfacet IDesignTimeDbContextFactory, man använder
    ///detta interface just för att arbeta med DBContext kodmässigt.Den blir ”typad” till vår databasklass.
    ///Detta för att den generiska delen av interfacet, då anpassar sig interfacet till vår databas-klass.
    ///I klassen skapar vi en variabel för att hålla koll på databasnamnet. Inget märkvärdigt där, det är precis
    ///som det vi gjort i databasklassen innan.
    /// </summary>
    class ContextFactory : IDesignTimeDbContextFactory<WebbShopContext>
    {
        private const string DatabaseName = "WebbShopMikaelLarsson";

        /// <summary>
        /// Text och metod av Marcus Medina.
        /// Metoden CreateDBContext skapar en instans av databasen och returnerar det. Innan den gör det
        /// kommer den dock att skapa en instans av Databasinställningarna.Den här metoden behövs egentligen
        ///inte och koden kan flyttas in i CreateDbContext() men då kan vi inte anropa den från Constructorn i vår
        ///databasklass.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>En instans av databasen.</returns>
        public WebbShopContext CreateDbContext(params string[] args)
        {
            return new WebbShopContext(CreateOptions());
        }

        /// <summary>
        /// Text och metod av Marcus Medina.
        /// CreateOptions() är en enkel metod som bara skapar databasinställningar för vår databas. Har vi fler
        /// konfigurationsinställningar så kan vi lägga dem i den här lilla metoden med.Det enda metoden gör att
        ///att skapa inställningarna och returnera dem.
        /// </summary>
        /// <returns>Inställningar för att ansluta till databasen</returns>
        public DbContextOptions<WebbShopContext> CreateOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebbShopContext>();
            optionsBuilder.UseSqlServer($@"Server =.\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
            return optionsBuilder.Options;
        }

    }
}
