using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Webbutik.Models
{
    public class SoldBook
    {
        /// <summary>
        /// The id or the sold book.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The price of the book.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// The date and time of the purchase.
        /// </summary>
        public DateTime PurchasedDate { get; set; }

        /// <summary>
        /// The id of the books category.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// The books category.
        /// </summary>
        public BookCategory Category { get; set; }

        /// <summary>
        /// The id of the user who purchased the book.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The user who purchased the book.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The id of the books author.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// The author of the book.
        /// </summary>
        public Author Author { get; set; }
    }
}
