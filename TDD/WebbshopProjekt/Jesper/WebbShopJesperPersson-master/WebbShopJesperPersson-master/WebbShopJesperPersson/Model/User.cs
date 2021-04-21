using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebbShopJesperPersson.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Password { get; set; }
        public DateTime LastLogin { get; set; }

        public DateTime SessionTimer { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsAdmin { get; set; } = false;

        public List<SoldBook> SoldBooks { get; set; }
    }
}