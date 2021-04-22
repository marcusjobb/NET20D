using System.ComponentModel.DataAnnotations;

namespace Inlämning_API.Models
{
    /// <summary>
    /// Initializing an instance of a book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Titel
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets Price
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets Category
        /// </summary>

        public BookCategories Category { get; set; } 
    }
}