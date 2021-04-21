using System.ComponentModel.DataAnnotations;

namespace WebbShopEmil.Models
{
    /// <summary>
    /// Intializing an intance of a BookCategory.
    /// </summary>
    public class BookCategory
    {
        /// <summary>
        /// Get or set Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Get or set Name.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}