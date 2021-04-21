using System;

namespace FrontEnd.Views
{
    public class UserView
    {
        internal void UserDisplay()
        {
            Console.Clear();
            Console.WriteLine("Welcome User!!");

            Console.WriteLine("\n*******************");
            Console.WriteLine("[1] GetCategories");
            Console.WriteLine("[2] GetCategories");
            Console.WriteLine("[3] GetCategory");
            Console.WriteLine("[4] GetAvailableBooks");
            Console.WriteLine("[5] Get Book");
            Console.WriteLine("[6] Get Books");
            Console.WriteLine("[7] Get Authors");
            Console.WriteLine("[8] Buy Book");
            Console.WriteLine("[9] Ping");            
            Console.WriteLine("[0] Quit/Logout");
            Console.WriteLine("*******************");
        }

        internal void DisplaySwitch()
        {
            //cw ">" enter choice
            var caseSwitch = Helper.Inputs.InputAdminMenuSwitch();
            switch (caseSwitch)
            {
                case 1:
                    Controllers.User.GetCategories();
                    Console.ReadLine();
                    break;

                case 2:
                    Controllers.User.GetCategories(Helper.InputUser.GetCategories());
                    Console.ReadLine();
                    break;

                case 3:
                    Controllers.User.GetCategory();
                    Console.ReadLine();
                    break;

                case 4:
                    Controllers.User.GetAvaliableBooks();
                    Console.ReadLine();
                    break;

                case 5:
                    Controllers.User.GetBook();
                    Console.ReadLine();
                    break;

                case 6:
                    Controllers.User.GetBooks();
                    Console.ReadLine();
                    break;

                case 7:
                    Controllers.User.GetAuthors();
                    Console.ReadLine();
                    break;

                case 8:
                    Controllers.User.BuyBook();
                    Console.ReadLine();
                    break;

                case 9:
                    Controllers.User.Ping();
                    Console.ReadLine();
                    break;

                case 0:
                    Helper.Validator.SetMainMenuValuation(false);
                    Helper.Validator.SetMainMenuValuation(false);
                    Helper.Validator.SetUserMenuValuation(false);
                    Console.WriteLine("Good Bye");
                    break;

                default:
                    Console.ReadLine();
                    break;
            }
        }
    }
}