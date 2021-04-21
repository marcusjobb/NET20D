using System;
using WebshopAPI;
using WebshopAPI.Models;
using WebshopAPI.Utils;
using WebshopMVC.Views.Messages;

namespace WebshopMVC.Controllers
{
    internal class UserController
    {
        public static void LogInUser()
        {
            bool isUserLoggedIn = false;
            var api = new API();
            do
            {
                Console.Clear();
                Console.Write("Enter user name:\n");
                var userName = Console.ReadLine();
                Console.Write("Enter password:\n");
                var password = Console.ReadLine();
                var result = api.Login(userName, password);
                if (result == null)
                {
                    var input = LoginMessage.Error();
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    LoginMessage.Success(userName);
                    isUserLoggedIn = true;
                }
            } while (isUserLoggedIn == false);
        }

        public static void LogOutUser(User user)
        {
            var api = new API();
            api.Logout(Startup.sessionCookie.Id);
            LogoutMessage.LoggedOut(user);
        }

        public static void RegisterNewUser()
        {
            bool isUserCreated = false;
            var api = new API();
            do
            {
                Console.Clear();
                Console.Write("Enter new user name: \n");
                var userName = Console.ReadLine();
                Console.Write("Enter new password: \n");
                var password = Console.ReadLine();
                Console.Write("Enter new password again: \n");
                var passwordVerify = Console.ReadLine();
                var result = api.Register(userName, password, passwordVerify);

                if (result == false)
                {
                    var input = RegisterMessage.Error();
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    RegisterMessage.Success(userName, password);
                    isUserCreated = true;
                }
            } while (isUserCreated == false);
        }

        public static void BuyBook(User user)
        {
            bool isBookPurchased = false;
            var api = new API();
            do
            {
                if (SessionTimer.CheckSessionTimer(user.SessionTimer) == true || user.SessionTimer == DateTime.MinValue)
                {
                    Console.Clear();
                    BuyBookMessage.UserNotLoggedIn();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Enter the Id for the book you want to buy: ");
                    int.TryParse(Console.ReadLine(), out var bookId);
                    var result = api.BuyBook(user.Id, bookId);
                    if (result == false)
                    {
                        var input = BuyBookMessage.Error();
                        if (input != "")
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        BuyBookMessage.Success();
                        isBookPurchased = true;
                    }
                }
            } while (isBookPurchased == false);
        }

        public static string SendPing(int userId)
        {
            var api = new API();
            return api.Ping(userId);
        }
    }
}