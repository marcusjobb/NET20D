namespace PizzaTajm.Database
{
    using Microsoft.EntityFrameworkCore;
    using PizzaTajm.Models;

    /// <summary>
    /// Defines the <see cref="PizzaTajmContext" />.
    /// </summary>
    public class PizzaTajmContext : DbContext
    {
        /// <summary>
        /// Defines the DatabaseName.
        /// </summary>
        private const string DatabaseName = "PizzaTajmDB";

        /// <summary>
        /// The MyModels DBSet.
        /// </summary>
        public DbSet<Dough> Doughs { get; set; }
        public DbSet<Meat> Meats { get; set; }
        public DbSet<Vegan> Vegan { get; set; }
        public DbSet<Spice> Spices { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<VeganCheese> VeganCheeses { get; set; }

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
