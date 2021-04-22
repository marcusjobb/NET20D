using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopAPI.Models
{
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }



        [ForeignKey ("CategoryId")]
        public BookCategory Category { get; set; }
        [Required]
        public int? CategoryId { get; set; }

        [ForeignKey ("UserId")]
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}
