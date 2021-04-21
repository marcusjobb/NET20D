using System.ComponentModel.DataAnnotations;

namespace WebbShopApi.Models
{
    /// <summary>
    /// Defines the <see cref="Book" />.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the BookId.
        /// </summary>
        [Key]
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the Amount.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the BookCategoryId.
        /// </summary>
        public int BookCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the BookCategory.
        /// </summary>
        public BookCategory BookCategory { get; set; }
    }
}
