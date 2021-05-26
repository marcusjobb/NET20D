using System;
using System.Collections.Generic;
using System.Text;

namespace MoqFTW.Interfaces
{
    public interface IWebshop
    {
        public List<IItem> ItemsAvailable { get; set; }
        public bool AddItemToCart(IUser user, IItem item);
        public List<IItem> GetCart(IUser user);
    }
}
