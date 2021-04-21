using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Denna klassen jobbar mot dbo.BookCategory tabellen i databasen.
    /// </summary>
    public class BookCategory
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
