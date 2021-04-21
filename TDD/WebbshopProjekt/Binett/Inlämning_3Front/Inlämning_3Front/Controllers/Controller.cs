using Inlämning_3Front.Views;
using Inlämning_API;
using Inlämning_API.Models;
using System;
using System.Threading;

namespace Inlämning_3Front.Controllers
{
    public class Controller
    {
        private readonly WebbShopAPI api = new();
        private readonly View view = new();
        private static readonly AdminController admin = new();
        private static readonly BookController bookController = new();

        /// <summary>
        /// Index, first menu at startup,
        /// Gives you the ability to browse book, register, and login
        /// </summary>
        public void Index()
        {
            while (true)
            {
                var view = new View();
                var user = new User();
                view.StartMenu();

                var input = Console.ReadKey().KeyChar;
                switch (char.ToLower(input))
                {
                    case '1':
                        bookController.BookMenu(user);
                        break;

                    case '2':
                        Register();
                        break;

                    case '3':
                        Login();
                        break;

                    case 'e':
                        Environment.Exit(0);
                        break;

                    default:
                        MessageView.WrongInput();
                        Thread.Sleep(1500);
                        break;
                }
            }
        }

        /// <summary>
        /// AdminMenu, if logged in as admin this menu controls whether you wanna logout
        /// or go back to admin menu or book menu, you need to logout to go back to Index
        /// </summary>
        /// <param name="user"></param>
        public void AdminMenu(User user)
        {
            view.AdminMenu();
            var adminchoice = Console.ReadKey().KeyChar;
            switch (adminchoice)
            {
                case '1':
                    bookController.BookMenu(user);
                    break;

                case '2':
                    admin.AdminMenu(user);
                    break;

                case '3':
                    Logout(user);
                    break;

                default:
                    MessageView.WrongInput();
                    break;
            }
        }

        /// <summary>
        /// Menu, if logged in as user this menu controls whether you wanna logout
        /// or go back to book menu, you need to logout to go back to Index
        /// </summary>
        /// <param name="user"></param>
        public void Menu(User user)
        {
            if (user.IsAdmin)
            {
                AdminMenu(user);
            }
            view.Menu();
            var input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    bookController.BookMenu(user);
                    break;

                case '2':
                    Logout(user);
                    break;

                default:
                    MessageView.WrongInput();
                    break;
            }
        }

        /// <summary>
        /// Registers a new user to be able to buy books
        /// </summary>
        public void Register()
        {
            view.AskForName();
            var name = Console.ReadLine();
            view.AskforPassWord();
            var password = Console.ReadLine();
            view.VerifyPassWord();
            var verifyPassword = Console.ReadLine();
            var successOrNot = api.Register(name, password, verifyPassword);
            if (successOrNot == true)
            {
                var user = api.Login(name, password);
                Menu(user);
            }
            else
            {
                MessageView.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Logout 
        /// </summary>
        /// <param name="user"></param>
        private void Logout(User user)
        {
            api.LogOut(user.ID);
            Index();
        }

        /// <summary>
        /// Login controls which menu
        /// </summary>
        public void Login()
        {
            view.AskForName();
            var userName = Console.ReadLine();
            view.AskforPassWord();
            var passWord = Console.ReadLine();
            var user = api.Login(userName, passWord);
            if (user != null)
            {
                if (!user.IsAdmin && user.ID > 0)
                {
                    MessageView.LoggedinAs(user);
                    bookController.BookMenu(user);
                }
                if (user.IsAdmin)
                {
                    admin.AdminMenu(user);
                }
                else
                {
                    MessageView.NoUserMatch();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}