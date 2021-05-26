using System;
using System.Collections.Generic;
using System.Text;

namespace MoqFTW.Interfaces
{
    public interface IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
