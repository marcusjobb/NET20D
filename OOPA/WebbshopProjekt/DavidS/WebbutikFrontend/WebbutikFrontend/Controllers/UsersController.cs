using WebbShop.Models;
using WebbutikFrontend.Views.Shared;
using static WebbutikFrontend.Utils.Helper;

namespace WebbutikFrontend.Controllers
{
    public class UsersController
    {
        /// <summary>
        /// Shows a special user menu to the <paramref name="adminId"/>.
        /// </summary>
        /// <param name="adminId"></param>
        public void Index(int adminId)
        {
            while (true)
            {
                Message.Ping(adminId);
                Views.UserMenu.Index.View();
                bool exit;
                do
                {
                    exit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            AddUser(adminId);
                            break;

                        case 2:
                            SearchUser(adminId);
                            break;

                        case 3:
                            ListAllUsers(adminId);
                            break;

                        case 4:
                            return;

                        default:
                            Message.Error();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> add a new
        /// <see cref="User"/> to the database.
        /// </summary>
        /// <param name="adminId"></param>
        private void AddUser(int adminId)
        {
            Views.UserMenu.AddUser.View();
            var username = Get.Text("username");
            if (username.Length != 0)
            {
                var password = Get.Text("password");
                if (API.AddUser(adminId, username, password))
                {
                    Message.Success($"{username} was successfully added!");
                }
                else
                {
                    Message.Error("There already exists a user with that name and password!");
                }
            }
            else
            {
                Message.Error("You have to enter a name.");
            }
        }

        /// <summary>
        /// Lets an <paramref name="adminId"/> list all users
        /// in the database and select a specific one.
        /// </summary>
        /// <param name="adminId"></param>
        private void ListAllUsers(int adminId)
        {
            var users = API.ListUsers(adminId);
            var ctr = Display.Users(users);
            bool exit;
            do
            {
                exit = true;
                var choice = Get.Choice();
                if (choice > 0 && choice < ctr)
                {
                    var user = users[choice - 1];
                    SelectedUser(adminId, user);
                }
                else if (choice != ctr)
                {
                    Message.Error();
                    exit = false;
                }
            } while (!exit);
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> search for a
        /// <see cref="User"/> base on the username then lists
        /// all the users that match. The admin are then able to
        /// select a specific user to modify.
        /// </summary>
        /// <param name="adminId"></param>
        private void SearchUser(int adminId)
        {
            var username = Get.Text("username", "\n\t");
            var users = API.FindUser(adminId, username);
            if (users.Count > 0)
            {
                var ctr = Display.Users(users);
                bool exit;
                do
                {
                    exit = true;
                    var choice = Get.Choice();
                    if (choice > 0 && choice < ctr)
                    {
                        var user = users[choice - 1];
                        SelectedUser(adminId, user);
                    }
                    else if (choice != ctr)
                    {
                        Message.Error();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                Message.Error("There are no users available that match your search.");
            }
        }

        /// <summary>
        /// Shows a special menu for the <paramref name="adminId"/> with
        /// choices regarding the specified <paramref name="user"/>
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="user"></param>
        private void SelectedUser(int adminId, User user)
        {
            while (true)
            {
                Message.Ping(adminId);
                Views.Users.SelectedUser.View(user);
                bool exit;
                do
                {
                    exit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            if (API.Promote(adminId, user.Id))
                            {
                                Message.Success($"{user.Name} was successfully promoted!");
                            }
                            else
                            {
                                Message.Error("Something went wrong.");
                            }
                            break;

                        case 2:
                            if (API.Demote(adminId, user.Id))
                            {
                                Message.Success($"{user.Name} was successfully demoted!");
                            }
                            else
                            {
                                Message.Error("Something went wrong.");
                            }
                            break;

                        case 3:
                            if (API.ActivateUser(adminId, user.Id))
                            {
                                Message.Success($"{user.Name} was successfully activated!");
                            }
                            else
                            {
                                Message.Error("Something went wrong.");
                            }
                            break;

                        case 4:
                            if (API.InactivateUser(adminId, user.Id))
                            {
                                Message.Success($"{user.Name} was successfully inactivated!");
                            }
                            else
                            {
                                Message.Error("Something went wrong.");
                            }
                            break;

                        case 5:
                            return;

                        default:
                            Message.Error();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }
    }
}
