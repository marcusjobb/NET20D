using System;
using System.ComponentModel.DataAnnotations;

namespace WebshopApi.Models
{
    /// <summary>
    /// Klasse som är modell till User
    /// </summary>
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime SessionTimer { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}