using System.ComponentModel.DataAnnotations;

namespace Inlämning_API.Models
{
    /// <summary>
    ///  Initializing an instance of a BookCategories
    /// </summary>
    public class BookCategories
    {
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}