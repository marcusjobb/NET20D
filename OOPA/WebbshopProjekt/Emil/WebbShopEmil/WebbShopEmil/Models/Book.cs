using System.ComponentModel.DataAnnotations;

namespace WebbShopEmil.Models
{
    /// <summary>
    /// Intializing an intance of a book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Get or set Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Get or set Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get or set Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Get or set Category.
        /// </summary>
        public BookCategory Category { get; set; }

        /// <summary>
        /// Get or set Price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Get or set Amount.
        /// </summary>
        public int Amount { get; set; }
    }
}