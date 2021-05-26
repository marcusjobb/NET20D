using MoqFTW.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoqFTW.Webblogics
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
