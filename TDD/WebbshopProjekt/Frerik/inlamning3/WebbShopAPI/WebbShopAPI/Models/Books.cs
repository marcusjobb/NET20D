namespace WebbShopAPI.Models
{
    /// <summary>
    /// Class for managing books
    /// </summary>
    public class Books : CommonBooks
    {
        /// <summary>
        /// The amount of copies the book has
        /// </summary>
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Author} {Title}, {Price} SEK, {Amount}st, category {CategoryId}";
        }
    }
}
