using Inlamning2TrialRunHE;
using Inlamning2TrialRunHE.Models;
using Inlamning3HakanEriksson.Views;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Inlamning3HakanEriksson.Controllers
{
    public class HomeController
    {
        public WebbShopAPI api = new WebbShopAPI();
        /// <summary>
        /// This method is the first one called when the program is started.
        /// The user is presented with a menu to register a new user,
        /// login a user or exit the program.
        /// </summary>
        public void menuNotLoggedIn()
        {
            var userController = new UserController();
            var loginData = new List<string>();
            var user = new User();
            var view = new ViewMenues();

            ViewMenues.startMenu();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    userController.RegisterNewUser();
                    break;

                case 2:
                    userController.LoginUser();
                    break;

                case 3:
                    ViewMessages.Exitmessage();
                    Thread.Sleep(2000);
                    api.Logout(user.Id);
                    Environment.Exit(0);
                    break;
            }
        }
    }
}