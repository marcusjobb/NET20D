using System;

namespace webshopAPI
{
    public class SoldBook
    {
        /// <summary>
        /// Constructor for SoldBooks
        /// </summary>
        /// <param name="book">Takes a book object as in parameter</param>
        /// <param name="user">Takes a user object as a in paramter</param>
        public SoldBook(Book book, User user)
        {
            this.Title = book.Title;
            this.Author = book.Author;
            this.CategoryId = book.Category.Id;
            this.Price = book.Price;
            this.PurchaseDate = DateTime.Now;
            this.UserId = user.Id;
        }

        /// <summary>
        /// Empty constuctor for SoldBook
        /// </summary>
        public SoldBook()
        {
        }

        /// <summary>
        /// Author field
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Category id field (integer)
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Id field
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Price field (integer)
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Purchasedate of type datetime
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Title field
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// User Id (type integer)
        /// </summary>
        public int UserId { get; set; }
    }
}