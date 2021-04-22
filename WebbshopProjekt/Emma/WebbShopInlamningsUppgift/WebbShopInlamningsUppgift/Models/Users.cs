using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShopInlamningsUppgift.Models
{
    /// <summary>
    /// Represents users in database
    /// </summary>
    public class Users
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime SessionTimer { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

    }
}
