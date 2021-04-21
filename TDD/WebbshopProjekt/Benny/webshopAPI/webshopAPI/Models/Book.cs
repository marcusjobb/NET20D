using System.ComponentModel.DataAnnotations;
using webshopAPI.Models;

namespace webshopAPI
{
    public class Book
    {
        /// <summary>
        /// Amount field of the books
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Author field of the Books
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// This will be a relationship between Book and BookCategory in db.
        /// </summary>
        public BookCategory Category { get; set; }

        /// <summary>
        /// The Id field of the Books
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Price field of the books
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Title field of the Books
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get the title of the book
        /// </summary>
        /// <returns>Title of the book</returns>
        public override string ToString()
        {
            return Title;
        }
    }
}