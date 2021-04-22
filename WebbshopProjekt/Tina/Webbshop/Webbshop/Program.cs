using System;
using WebbshopProject;
using WebbshopProject.Database;
using Webbshop.Views;
using Webbshop.Controllers;

namespace Webbshop
{
    class Program
    {
        /// <summary>
        /// Creates seed to the tables in the database. 
        /// And then runs the startup menu. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WebbshopAPI.Seed();
            StartupControllers.WelcomeAndStartupMenu();
        }
    }
}
