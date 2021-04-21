using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebbShopAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime LastLogIn { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public List<SoldBook> SoldBooks { get; set; }
        public DateTime SessionTimer { get; set; }
    }
}
