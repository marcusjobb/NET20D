using MoqFTW.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoqFTW.Webblogics
{
    public class Webbshop : IWebshop
    {
        public List<IItem> ItemsAvailable { get; set; }

        public bool AddItemToCart(IUser user, IItem item)
        {
            return false;
        }

        public List<IItem> GetCart(IUser user)
        {
            return new List<IItem>();
        }
    }
}
