using Models;
using System;
using System.Collections.Generic;

namespace MVCLive.Controllers
{
    internal class Home
    {
        internal void Start()
        {
            var view = new Views.HomeView();
            while (true)
            {
                view.Display();
                view.DisplayMenu();
                var input = GetInput();
                if (input == "0") return;
            }

            /*
             *  Böcker --> Controller ------> View: List
             *                        |-----> View: Add
             *                        |-----> View: Update
             *                        |-----> View: Delete & Verify
             *                        |-----> View: Details
             *
             *  ------------------------------------------------------------
             *  FLUX:  --> Controller -----> Databas <-----> Vy -----> CRUDL
             *                                   |-----------|
             *                |--------------------------|
             */
        }

        private List<User> Users = new List<User>();

        private string GetInput()
        {
            var input = Console.ReadLine().Trim();
            if (input == "1") new Views.Users().List(Users);
            if (input == "2")
            {
                var newUser = new Views.Users().Add(Users);
                Users.Add(newUser);
            }
            return input;
        }
    }
}