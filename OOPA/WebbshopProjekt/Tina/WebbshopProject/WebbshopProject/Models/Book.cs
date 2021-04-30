using System.ComponentModel.DataAnnotations;

namespace WebbshopProject.Models
{
    public class Book
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
        /// Gets and sets the Author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets and sets the price of the book.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets and sets the amount of books.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets and sets the category of the book, 
        /// with a category Id.
        /// </summary>
        public BookCategory Category { get; set; }
    }
}
