using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbShopIvoNazlic.Models
{
    /// <remarks>
    /// Sold books table
    /// </remarks>
    public class SoldBook
    {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string CategoryId { get; set; }

        public int Price { get; set; }

        public DateTime PurchasedDate { get; set; }

        [ForeignKey("UserId")]
        public User Users { get; set; }

        public override string ToString()
        {
            return $"Sold book: {Title}({Id}), by {Author}. Price: {Price}, Category: {CategoryId}";
        }

    }
}
