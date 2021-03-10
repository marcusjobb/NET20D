// ----------------------------------------------------------------------
// Awesome code by Marcus Medina (for educational purposes)
// © 2021, Codic Education, http://codic.se
// ----------------------------------------------------------------------
namespace EntityFramework01.Database
{
    using EntityFramework01.Models;
    using Microsoft.EntityFrameworkCore;

    // I Package Manager Console
    // install-package Microsoft.EntityFrameworkCore.SqlServer
    // install-package Microsoft.EntityFrameworkCore.tools

    /// <summary>Definition of <see cref="Filmdatabas" />.</summary>
    internal class Filmdatabas : DbContext
    {
        private const string DatabaseName = "Filmdatabas";

        public DbSet<Film> Filmer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true");
        }
    }
}
