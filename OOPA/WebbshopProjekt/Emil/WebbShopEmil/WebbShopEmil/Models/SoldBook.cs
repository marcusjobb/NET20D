using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShopEmil.Models
{
    // <summary>
    /// Intializing an intance of a book.
    /// </summary>
    public class SoldBook
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
        /// Get or set CategoryId.
        /// </summary>
        public BookCategory CategoryId { get; set; }

        /// <summary>
        /// Get or set Price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Get or set PurchasedDate.
        /// </summary>
        public DateTime PurchasedDate { get; set; }

        /// <summary>
        /// Get or set User.
        /// </summary>
        public User User { get; set; }
    }
}