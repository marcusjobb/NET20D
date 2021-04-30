using System;
using System.ComponentModel.DataAnnotations;

namespace Inlämning2WebbShop.Models
{
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }
        public BookCategory Category { get; set; }
        public User User { get; set; }

        /// <summary>
        /// skriver ut information om en såld bok.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Title}\nAuthor: {Author}\nPrice: {Price}\nPurchased date: {PurchasedDate}\nBought by: {User.Name}\n";
        }
    }
}