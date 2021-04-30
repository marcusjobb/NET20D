using System;
using System.Threading;
using WebbShop.View;
using WebbShopAPI.Database;

namespace WebbShop
{
    class Program
    {
        static void Main(string[] args)
        {
            if (SeederClass.FillUserTable())
                if (SeederClass.FillCategoryTable())
                    if (SeederClass.FillBooksTable())
                    {
                        Console.WriteLine("Done initializing...");
                        Thread.Sleep(1500);
                    }
            LogInView.Show();
        }
    }
}
