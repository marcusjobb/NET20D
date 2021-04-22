using System;
using System.ComponentModel.DataAnnotations;

namespace WebbshopProject.Models
{
    public class SoldBook
    {
        /// <summary>
        /// Gets and sets the id of the book.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the Title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets and sets the author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets and sets the price of the book.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets and sets the purchaseDate of the book.
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        
        /// <summary>
        /// Gets and sets the User id, for the buyer of
        /// the book.
        /// </summary>
        public User User { get; set; }
        
        /// <summary>
        /// Gets and sets the category of the book, 
        /// that is a category Id. 
        /// </summary>
        public BookCategory Category { get; set; }
    }
}
