namespace EFLinq.Database
{
    using EFLinq.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="EFLinqContext" />.
    /// </summary>
    public class EFLinqContext : DbContext
    {
        /// <summary>
        /// Defines the DatabaseName.
        /// </summary>
        private const string DatabaseName = "EFLinqDB";

        /// <summary>
        /// The MyModels DBSet.
        /// </summary>
        public DbSet<Person> People { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<House> Home { get; set; }

        /// <summary>
        /// The OnConfiguring method.
        /// </summary>
        /// <param name="optionsBuilder">The optionsBuilder<see cref="DbContextOptionsBuilder"/>.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName}; Trusted_Connection = true;");
        }
    }
}
