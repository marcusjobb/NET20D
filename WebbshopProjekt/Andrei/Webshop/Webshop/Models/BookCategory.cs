using System.ComponentModel.DataAnnotations;

namespace WebbShopApi.Models
{
    /// <summary>
    /// Defines the <see cref="BookCategory" />.
    /// </summary>
    public class BookCategory
    {
        /// <summary>
        /// Gets or sets the BookCategoryId.
        /// </summary>
        [Key]
        public int BookCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }
    }
}
