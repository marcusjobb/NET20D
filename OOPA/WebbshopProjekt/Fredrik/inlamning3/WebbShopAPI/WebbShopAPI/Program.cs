using System;

namespace WebbShopAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            WebbShopApi api = new WebbShopApi();
            
            Console.WriteLine("Example 1 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            api.RunExample1();
            Console.WriteLine("Example 2 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            api.RunExample2();
            Console.WriteLine("Example 3 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            api.RunExample3();
        }
    }
}
