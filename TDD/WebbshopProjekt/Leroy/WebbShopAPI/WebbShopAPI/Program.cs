using System;
using WebbShopAPI.Database;
using WebbShopAPI.Controller;
using WebbShopAPI.Model;
using System.Linq;
using WebbShopAPI.Utils;
using WebbShopAPI.View;

namespace WebbShopAPI
{
    class Program
    {
        /// <summary>
        /// Main entry of the app
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (InitClass.StartInitializingDatabase())
            {
                ViewClass.Run();
            }
            else
            {
                Console.WriteLine("Something went wrong!!!");
            }
            
        }

    }
}
