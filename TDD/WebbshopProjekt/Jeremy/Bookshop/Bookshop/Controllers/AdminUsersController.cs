using Bookshop.Helpers;
using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Controllers
{
    class AdminUsersController
    {
        Layout layout = new Layout();
        MenuController menuController = new MenuController();

        /// <summary>
        /// Handles the logic for the index page.
        /// </summary>
        public void Index()
        {
            PingHelper.CheckPing();

            layout.ClearMenu();
            layout.ClearMainContent();

            int option = menuController.Menu(Views.AdminUsers.Index.menuOptions, false);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Find user                    
                    FindUser();
                    break;
                case 3:  // Home
                    AdminHomeController adminHomeController = new AdminHomeController();
                    adminHomeController.Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for the add user page.
        /// </summary>
        public void AddUser()
        {
            PingHelper.CheckPing();

            layout.ClearMainContent();
            layout.ClearMenu();

            List<string> userInput = new List<string>();

            Views.AdminUsers.AddUser.PrintAddUserPage();

            int option = menuController.Menu(Views.AdminUsers.AddUser.menuOptions, true);
            switch (option)
            {
                case 0: // List users
                    ListUsers();
                    break;
                case 1: // Find user
                    FindUser();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }

            userInput = Views.AdminUsers.AddUser.UseAddUserPage();
            Views.AdminUsers.AddUser.Confirm();
            option = menuController.MessageWindow();
            switch (option)
            {
                case 0: // Create user and go to Index
                    bool isCreated = false;
                    if (userInput[1] == string.Empty)
                    {
                        isCreated = GlobalVariables.Api.AddUser(
                            GlobalVariables.User.Id, userInput[0]);
                    }
                    else
                    {
                        isCreated = GlobalVariables.Api.AddUser(
                            GlobalVariables.User.Id, userInput[0], userInput[1]);
                    }

                    if (isCreated == true)
                    {
                        layout.ClearMainContent();
                        Views.AdminUsers.AddUser.UserSuccessfullyCreated();
                    }
                    else
                    {
                        layout.ClearMainContent();
                        Views.AdminUsers.AddUser.UserDoesAlreadyExist();
                    }
                    Index();
                    break;
                case 1: // Index
                    Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for the list users page.
        /// </summary>
        public void ListUsers()
        {
            PingHelper.CheckPing();

            layout.ClearMainContent();
            layout.ClearMenu();

            List<Webbutik.Models.User> listOfUsers = GlobalVariables.Api.ListUsers(
                GlobalVariables.User.Id);
            Views.AdminUsers.ListUsers.ListAllUsers(listOfUsers);

            int option = menuController.Menu(Views.AdminUsers.ListUsers.menuOptions, true);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // Find user
                    FindUser();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MainContentMenu(listOfUsers);
            UserInfo(option, listOfUsers);
        }

        /// <summary>
        /// Handles the logic for the user infor page.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="users"></param>
        public void UserInfo(int userId, List<Webbutik.Models.User> users)
        {
            PingHelper.CheckPing();

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.UserInfo.PrintUserInfo(userId, users);

            int option = menuController.Menu(Views.AdminUsers.UserInfo.menuOptions, false);
            switch (option)
            {
                case 0: // Activate user
                    ActivateUser(userId);
                    break;
                case 1: // Inactivate user
                    InactivateUser(userId);
                    break;
                case 2: // Promote user
                    PromoteUser(userId);
                    break;
                case 3: // Demote user
                    DemoteUser(userId);
                    break;
                case 4: // Back
                    ListUsers();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for the find user page.
        /// </summary>
        public void FindUser()
        {
            PingHelper.CheckPing();

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.FindUser.PrintFindUserPage();

            int option = menuController.Menu(Views.AdminUsers.FindUser.menuOptions, true);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }

            string userInput = Views.AdminUsers.FindUser.UseFindUserPage();
            List<Webbutik.Models.User> users = GlobalVariables.Api.FindUser(
                GlobalVariables.User.Id, userInput);

            Views.AdminUsers.FindUser.PrintResult(users);

            option = menuController.Menu(Views.AdminUsers.FindUser.menuOptions, true);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MainContentMenu(users);
            UserInfo(option, users);
        }

        /// <summary>
        ///  Handles the logic for the activate user page.
        /// </summary>
        /// <param name="userId"></param>
        public void ActivateUser(int userId)
        {
            PingHelper.CheckPing();

            Menu menu = new Menu();

            layout.ClearMainContent();
            layout.ClearMenu();
            
            Views.AdminUsers.ActivateUser.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminUsers.ActivateUser.menuOptions, true);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Find user
                    FindUser();
                    break;
                case 3: // Inactivate user
                    InactivateUser(userId);
                    break;
                case 4: // Promote user
                    PromoteUser(userId);
                    break;
                case 5: // Demote user
                    DemoteUser(userId);
                    break;
                case 6: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool IsActive = GlobalVariables.Api.ActivateUser(GlobalVariables.User.Id, 
                        userId);
                    Views.AdminUsers.ActivateUser.IsUserActive(IsActive);
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for the incactivate user page.
        /// </summary>
        /// <param name="userId"></param>
        public void InactivateUser(int userId)
        {
            PingHelper.CheckPing();

            Menu menu = new Menu();
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.InactivateUser.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminUsers.InactivateUser.menuOptions, true);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Find user
                    FindUser();
                    break;
                case 3: // Activate user
                    ActivateUser(userId);
                    break;
                case 4: // Promote user
                    PromoteUser(userId);
                    break;
                case 5: // Demote user
                    DemoteUser(userId);
                    break;
                case 6: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool isInactive = GlobalVariables.Api.InactivateUser(GlobalVariables.User.Id, 
                        userId);
                    Views.AdminUsers.InactivateUser.IsUserInactive(isInactive);
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for the promote user page.
        /// </summary>
        /// <param name="userId"></param>
        public void PromoteUser(int userId)
        {
            PingHelper.CheckPing();

            Menu menu = new Menu();
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.PromoteUser.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminUsers.PromoteUser.menuOptions, true);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Find user
                    FindUser();
                    break;
                case 3: // Activate user
                    ActivateUser(userId);
                    break;
                case 4: // Inactivate user
                    InactivateUser(userId);
                    break;
                case 5: // Demote user
                    DemoteUser(userId);
                    break;
                case 6: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool isPromoted = GlobalVariables.Api.Promote(GlobalVariables.User.Id, userId);
                    Views.AdminUsers.PromoteUser.IsUserPromoted(isPromoted);
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for the demote user page.
        /// </summary>
        /// <param name="userId">The id of the user that should be demoted.</param>
        public void DemoteUser(int userId)
        {
            PingHelper.CheckPing();

            Menu menu = new Menu();

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.DemoteUser.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminUsers.DemoteUser.menuOptions, true);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Find user
                    FindUser();
                    break;
                case 3: // Activate user
                    ActivateUser(userId);
                    break;
                case 4: // Inactivate user
                    InactivateUser(userId);
                    break;
                case 5: // Promote user
                    PromoteUser(userId);
                    break;
                case 6: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool isPromoted = GlobalVariables.Api.Demote(GlobalVariables.User.Id, userId);
                    Views.AdminUsers.DemoteUser.IsUserDemoted(isPromoted);
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }
    }
}
