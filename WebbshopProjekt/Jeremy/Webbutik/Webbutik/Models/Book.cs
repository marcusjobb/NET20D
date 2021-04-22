using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Webbutik.Models
{
    public class Book
    {
        /// <summary>
        /// The Id of the book.
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
        /// The available amount of the book.
        /// </summary>
        public int Amount { get; set; }
        
        /// <summary>
        /// The id of the books author.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// The author of the book.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// The id of the books category.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The category of the book.
        /// </summary>
        public BookCategory Category { get; set; }
    }
}
