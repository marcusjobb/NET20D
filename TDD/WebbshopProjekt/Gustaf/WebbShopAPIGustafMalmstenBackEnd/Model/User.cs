using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopAPIGustafMalmsten.Model
{
    /// <summary>
    /// Represents an User, using the webbshop.
    /// </summary>
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; } 
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime SessionTimer { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}
