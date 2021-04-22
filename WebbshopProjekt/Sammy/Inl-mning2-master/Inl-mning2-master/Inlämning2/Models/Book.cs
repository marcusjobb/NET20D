using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inlämning2.Models
{
    /// <summary>
    /// Klaasen för book.
    /// </summary>
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public List<Category> Categories { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nPrice: {Price}\nAmount: {Amount}";
        }
    }
}
