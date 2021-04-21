using BookWebbshop.View;
using System;
using WebbShopAPI;

namespace BookWebbshop
{
    class Program
    {
        static void Main(string[] args)
        {

            var front = new StoreView();

            front.Store();

        }
    }
}
