using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookWebShop.Models
{
    public class User
    {
        /// <summary>
        /// Class for the User model.
        /// </summary>

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime SessionTimer { get; set; } = default;

        public bool IsActive { get; set; } = true;

        public bool IsAdmin { get; set; } = false;

        public List<SoldBook> SoldBooks { get; set; }
    }
}