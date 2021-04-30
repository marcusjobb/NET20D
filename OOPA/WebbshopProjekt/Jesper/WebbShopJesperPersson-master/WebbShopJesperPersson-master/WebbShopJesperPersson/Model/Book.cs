using System.ComponentModel.DataAnnotations;

namespace WebbShopJesperPersson.Model
{
    public class Book

    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public BookCategory Category { get; set; }
    }
}