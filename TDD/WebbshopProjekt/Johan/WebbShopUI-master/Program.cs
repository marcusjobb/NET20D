using System;
using WebbShopAPI;
using WebbShopAPI.Database;
using WebbShopUI.Controller;
using Microsoft.EntityFrameworkCore;

namespace WebbShopUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new MenuController();
            Seeder.AddMockData();
            menu.RunProgram();
            
        }
    }
}
