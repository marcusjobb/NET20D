using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Webbutik.Models
{
    public class User
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The time of the last login.
        /// </summary>
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// The time of the session.
        /// </summary>
        public DateTime SessionTimer { get; set; }

        /// <summary>
        /// Set the user to active or inactive.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Set the user as admin or normal user.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// The purchased books.
        /// </summary>
        public List<SoldBook> SoldBooks { get; set; }
    }
}
