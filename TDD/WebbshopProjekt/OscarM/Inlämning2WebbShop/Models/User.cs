using System;
using System.ComponentModel.DataAnnotations;

namespace Inlämning2WebbShop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime LastLogin { get; set; }
        public DateTime SessionTimer { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

        /// <summary>
        /// skriver ut information om en användare
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"{Name}\nSessionTimer: {SessionTimer}\nIsActive: {IsActive}\nIsAdmin: {IsAdmin}\n");
        }
    }
}