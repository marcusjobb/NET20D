namespace WebbShopAPI.Models
{
    public class CommonBooks : Common
    {
        /// <summary>
        /// The title of the book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The author of the book
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// The price of the book
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// The associated category the book has
        /// </summary>
        public int CategoryId { get; set; }
    }
}
