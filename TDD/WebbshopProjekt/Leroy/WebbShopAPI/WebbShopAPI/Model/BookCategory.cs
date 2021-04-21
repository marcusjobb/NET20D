using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbShopAPI.Model
{
    public class BookCategory
    {
        /// <summary>
        ///Book ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }
    }
}
