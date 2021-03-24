namespace PizzaTajm.Models
{
    using System.ComponentModel.DataAnnotations;
    using PizzaTajm.Interfaces;

    /// <summary>
    /// Defines the <see cref="Dough" />.
    /// </summary>
    public class Dough : IStuff
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
