using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbShopAPI.Model
{
    public class User
    {
        /// <summary>
        /// ID of user
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Name of user
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Password of user
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Last log in
        /// </summary>
        public DateTime LastLogIn { get; set; }
        /// <summary>
        /// Last time an action was made
        /// </summary>
        public DateTime SesionTimer { get; set; }
        /// <summary>
        /// Returns true if you are an admin
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Returns true if you are active
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
