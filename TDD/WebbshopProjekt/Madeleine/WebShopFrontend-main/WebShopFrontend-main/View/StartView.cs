using System;
using System.Collections.Generic;
using System.Text;
using WebShopAssignment;
using WebShopFrontend.Controller;

namespace WebShopFrontend.View
{
    public class StartView
    {
        public static WebShopAPI api = new WebShopAPI();
        public static void StartMenu()
        {          
            Console.WriteLine("Välkommen till bokhandeln");
            Console.WriteLine("Vänligen logga in: ");
            LoginMenu.Startup();
           
        }
    }
}
