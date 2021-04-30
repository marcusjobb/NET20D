using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopAPIGustafMalmsten.Model
{
    /// <summary>
    /// A copy of a book is moved here when it is sold.
    /// </summary>
    public class SoldBook
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; }  

        public int BookCategoryID { get; set; }
        public BookCategory BookCategory { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
