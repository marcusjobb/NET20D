using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShop.Models
{
    public class User
    {
        /// <summary>
        /// Gets and sets the id of the <see cref="User"/>.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the name of the <see cref="User"/>.
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the password of the <see cref="User"/>.
        /// </summary>
        [MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// Gets and sets the time the <see cref="User"/> last logged in.
        /// </summary>
        public DateTime LastLogIn { get; set; }

        /// <summary>
        /// Gets and sets the time for the session timer
        /// of the <see cref="User"/>.
        /// </summary>
        public DateTime SessionTimer { get; set; }

        /// <summary>
        /// Gets and sets if the <see cref="User"/> is active or not.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets and sets if the <see cref="User"/> is admin or not.
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
