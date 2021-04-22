using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbShopAPI.Model
{
    public class SoldBook
    {
        /// <summary>
        /// ID of the book
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Title of the book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Author of the book
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Category of the book that is also linked to the Category table
        /// </summary>
        [ForeignKey("BookCategory")]
        public int CategoryID { get; set; }
        /// <summary>
        /// Price of the book
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Date that you purchased the book
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        [ForeignKey("User")]
        ///User ID linked to the book
        public int UserID { get; set; }
}
}
