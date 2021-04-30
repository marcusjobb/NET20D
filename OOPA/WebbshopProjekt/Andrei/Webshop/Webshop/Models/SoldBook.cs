using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebbShopApi.Models
{
    /// <summary>
    /// Defines the <see cref="SoldBook" />.
    /// </summary>
    public class SoldBook
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
        /// Gets or sets the BookCategoryId.
        /// </summary>
        public int BookCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the BookCategory.
        /// </summary>
        public BookCategory BookCategory { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the PurchaseDate.
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public int UserId { get; set; }
    }
}
