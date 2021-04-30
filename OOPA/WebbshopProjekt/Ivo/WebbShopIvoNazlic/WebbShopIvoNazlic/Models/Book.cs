using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbShopIvoNazlic.Models
{
    /// <remarks>
    /// Books table
    /// </remarks>
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        [ForeignKey("CategoryId")]
        public Category BookCategory { get; set; }

        public override string ToString()
        {
            return $"Book: {Title}({Id}), by {Author}. Price: {Price}, Amount: {Amount}";
        }

    }
}
