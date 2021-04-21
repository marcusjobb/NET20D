namespace WebbShop_MikaelLarsson
{
    using WebbShop_MikaelLarsson.Views;
    using Inlamn2WebbShop_MLarsson.Controllers;
    using Microsoft.VisualBasic;
    using System;
    using System.Threading;
    using WebbShop_MikaelLarsson.Views.Admin;
    using WebbShop_MikaelLarsson.Views.UserView;
    using System.Collections.Generic;
    using Inlamn2WebbShop_MLarsson.Database;

    internal static class Program
    {
       internal static void Main()
        {
            DatabaseCreator.Create();
            Seeder.Seed();
           MenuView.MainMenu();
        }
    }
}
