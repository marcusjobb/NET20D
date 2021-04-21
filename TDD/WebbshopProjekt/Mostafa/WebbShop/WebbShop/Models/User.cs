using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebbShop.Models
{
    public class User
    {
        public int ID  { get; set; }
        public string Name { get; set; }

        [DefaultValue("Codic2021")]
        public string Password { get; set; }
        public DateTime Lastlogin { get; set; }
        public DateTime SessionTimer { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
    }
}
