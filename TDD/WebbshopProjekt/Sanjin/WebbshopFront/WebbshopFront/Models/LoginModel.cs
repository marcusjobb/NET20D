using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Models
{
    class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
