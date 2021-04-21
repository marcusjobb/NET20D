using System;
using System.ComponentModel.DataAnnotations;

namespace Inlämning_API.Models
{
    /// <summary>
    ///  Initializing an instance of a BookCategories
    /// </summary>
    public class SoldBooks
    {
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Title
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Author
        /// </summary>
        [Required]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets Catgory
        /// </summary>
        public BookCategories Category { get; set; }

        /// <summary>
        /// Gets or sets Price
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets PurchasedDate
        /// </summary>
        public DateTime PurchasedDate { get; set; }

        /// <summary>
        /// Gets or sets User
        /// </summary>
        public User User { get; set; }
    }
}