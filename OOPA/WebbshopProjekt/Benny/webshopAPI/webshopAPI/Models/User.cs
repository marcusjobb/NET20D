using System;
using System.ComponentModel.DataAnnotations;

namespace webshopAPI
{
    public class User
    {
        /// <summary>
        /// Constructor for user
        /// </summary>
        /// <param name="name">Takes a name for the user</param>
        /// <param name="password">Takes a password for the user</param>
        /// <param name="isActive">True if user should be activated, false if not</param>
        /// <param name="isAdmin">True if user should have admin priviliges or false if not.</param>
        public User(string name, string password, bool isActive = true, bool isAdmin = false)
        {
            this.Name = name;
            this.Password = password;
            this.IsActive = isActive;
            this.IsAdmin = isAdmin;
        }

        /// <summary>
        /// Id field for user
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// IsActive field for the user, true if user is activated for use.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// IsAdmin field for the user. True if user has admin priviliges
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Last login field for user, of type Datetime
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Name field for user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Password field for user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Sessiontimer that holds the last activitytime for the user.
        /// </summary>
        public DateTime? SessionTimer { get; set; }

        /// <summary>
        /// Overrides to string for easier debugging.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}