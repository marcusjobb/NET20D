using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShop.Models
{
    public class SoldBook
    {
        /// <summary>
        /// Gets and sets the id of the <see cref="SoldBook"/>.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the title of the <see cref="SoldBook"/>.
        /// </summary>
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Gets and sets the author of the <see cref="SoldBook"/>.
        /// </summary>
        [MaxLength(50)]
        public string Author { get; set; }

        /// <summary>
        /// Gets and sets the <see cref="BookCategory"/>
        /// of the <see cref="SoldBook"/>.
        /// </summary>
        public BookCategory Category { get; set; }

        /// <summary>
        /// Gets and sets the price of the <see cref="SoldBook"/>.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets and sets the time when the <see cref="SoldBook"/>
        /// was purchased.
        /// </summary>
        public DateTime PurchasedDate { get; set; }

        /// <summary>
        /// Gets and sets the <see cref="User"/> who purchased
        /// the <see cref="SoldBook"/>.
        /// </summary>
        public User User { get; set; }
    }
}
