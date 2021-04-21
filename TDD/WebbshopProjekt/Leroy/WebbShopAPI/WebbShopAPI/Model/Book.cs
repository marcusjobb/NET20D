using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbShopAPI.Model
{
    public class Book
    {
        /// <summary>
        /// Book ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Author of the book
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Price of the book
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// The amout of books
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Category of the book and also links to the Category table (FK)
        /// </summary>
        [ForeignKey("BookCategory")]        
        public int CategoryID { get; set; }
    }
}
