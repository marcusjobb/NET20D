using System;
using System.ComponentModel.DataAnnotations;

namespace WebbshopProject.Models
{
    public class User
    {
        /// <summary>
        /// Gets and sets the id of the user
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets and sets the Name of the user
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets and sets the Password of the user
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets and sets the time of the last login
        /// of the user.
        /// </summary>
        public DateTime? LastLogin { get; set; }
        /// <summary>
        /// Gets and sets the sessionTimer of the user 
        /// </summary>
        public DateTime SessionTimer { get; set; }

        /// <summary>
        /// Gets and sets if the user is active or not.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets and sets if the user is admin or not.
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
