using System;
using WebbutikFrontend.Views.Shared;
using static WebbutikFrontend.Utils.Helper;

namespace WebbutikFrontend.Controllers
{
    /// <summary>
    /// Shows the main menu and lets the user choose what to do
    /// until he or she chooses to exit the program.
    /// </summary>
    public class HomeController
    {
        public void Index()
        {
            Layout.SetUp();
            while (true)
            {
                Views.Home.Index.View();
                bool exit;
                do
                {
                    exit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            Register();
                            break;

                        case 2:
                            Login();
                            break;

                        case 3:
                            var books = new BooksController();
                            books.Index();
                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            Message.Error();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Shows a special admin menu to the <paramref name="admin"/>.
        /// </summary>
        /// <param name="adminId"></param>
        private void AdminMenu(int adminId)
        {
            while (true)
            {
                Message.Ping(adminId);
                Views.Home.AdminMenu.View();
                bool exit;
                do
                {
                    exit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            var bookMenu = new BooksController();
                            bookMenu.Index(adminId);
                            break;

                        case 2:
                            var categoryMenu = new CategoriesController();
                            categoryMenu.Index(adminId);
                            break;

                        case 3:
                            var userMenu = new UsersController();
                            userMenu.Index(adminId);
                            break;

                        case 4:
                            var soldBooksMenu = new SoldBooksController();
                            soldBooksMenu.Index(adminId);
                            break;

                        case 5:
                            API.Logout(adminId);
                            Message.Success("You are now logged out.");
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
        /// Shows a menu to a customer.
        /// </summary>
        /// <param name="userId"></param>
        private void CustomerMenu(int userId)
        {
            while (true)
            {
                Message.Ping(userId);
                Views.Home.CustomerMenu.View();
                bool exit;
                do
                {
                    exit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            var books = new BooksController();
                            books.Index(userId);
                            break;

                        case 2:
                            API.Logout(userId);
                            Message.Success("You are now logged out.");
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
        /// Lets a user login.
        /// </summary>
        /// <returns>The users id if the username
        /// and password match a user in the database,
        /// otherwise 0.</returns>
        private int Login()
        {
            int userId;
            bool exit;
            do
            {
                exit = true;
                Views.Home.Login.View();
                var username = Get.Text("username");
                var password = Get.Text("password");
                userId = API.Login(username, password);
                if (userId != 0)
                {
                    Message.Success("You are now logged in!");
                    if (API.UserIsAdmin(userId))
                    {
                        AdminMenu(userId);
                    }
                    else
                    {
                        CustomerMenu(userId);
                    }
                }
                else if (Message.TryAgain("Something went wrong."))
                {
                    exit = false;
                }
            } while (!exit);

            return userId;
        }

        /// <summary>
        /// Lets a user register to the website.
        /// </summary>
        private void Register()
        {
            bool exit;
            do
            {
                exit = true;
                Views.Home.Register.View();
                var username = Get.Text("username");
                if (username.Length != 0)
                {
                    var password = Get.Text("password");
                    var passwordVerify = Get.Text("password again");
                    if (password.Equals(passwordVerify))
                    {
                        if (API.Register(username, password, passwordVerify))
                        {
                            Message.Success($"{username} was successfully registered!");
                        }
                        else
                        {
                            Message.Error($"{username} already exists.");
                        }
                    }
                    else if (Message.TryAgain("The passwords doesn't match."))
                    {
                        exit = false;
                    }
                }
                else
                {
                    Message.Error("You have to enter a name.");
                }
            } while (!exit);
        }
    }
}
