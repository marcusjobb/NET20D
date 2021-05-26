using MoqFTW.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoqFTW.Webblogics
{
    public class User : IUser
    {
        public int Id { get ; set ; }
        public string Name { get ; set ; }
    }
}
