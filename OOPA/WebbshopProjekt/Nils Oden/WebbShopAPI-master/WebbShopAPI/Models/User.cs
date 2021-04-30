using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShopAPI.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; } = "CodicRulez";
        public DateTime SessionTimer { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsAdmin { get; set; } = false;
    }
}