using System.ComponentModel.DataAnnotations;

namespace Inlämning2WebbShop.Models
{

    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public BookCategory Category { get; set; }

        /// <summary>
        /// skriver ut information om boken
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Title}| Author: {Author}| Price: {Price}| Amount: {Amount}\n";
        }

    }
}
