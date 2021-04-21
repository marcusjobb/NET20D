namespace WebbShopAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="SoldBook" />.
    /// </summary>
    internal class SoldBook
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the PurchasedDate.
        /// </summary>
        public DateTime PurchasedDate { get; set; }

        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public int UserId { get; set; }
    }
}
