namespace FrontEnd.Views
{
    using System;

    public class AdminView
    {
        internal void AdminDisplay()
        {
            Console.Clear();
            Console.WriteLine("Welcome administrator!!");

            Console.WriteLine("\n*******************");
            Console.WriteLine("[1] AddBook");
            Console.WriteLine("[2] SetQuantity");
            Console.WriteLine("[3] ListUsers");
            Console.WriteLine("[4] FindUser ");
            Console.WriteLine("[5] UpdateBook ");
            Console.WriteLine("[6] DeleteBook ");
            Console.WriteLine("[7] AddCategory ");
            Console.WriteLine("[8] AddBookToCategory ");
            Console.WriteLine("[9] UpdateCategory ");
            Console.WriteLine("[10] DeleteCategory  ");
            Console.WriteLine("[11] AddUser ");
            Console.WriteLine("\n*******************");
            Console.WriteLine("[12] GetCategories");
            Console.WriteLine("[13] GetCategories");
            Console.WriteLine("[14] GetCategory");
            Console.WriteLine("[15] GetAvailableBooks");
            Console.WriteLine("[16] Get Book");
            Console.WriteLine("[17] Get Books");
            Console.WriteLine("[18] Get Authors");
            Console.WriteLine("[19] Buy Book");
            Console.WriteLine("[20] Ping");
            Console.WriteLine("[0] Quit/Logout");
            Console.WriteLine("*******************");
        }

        internal void DisplaySwitch()
        {
            var caseSwitch = Helper.Inputs.InputAdminMenuSwitch();
            switch (caseSwitch)
            {
                case 1:
                    Controllers.Admin.AddBook();
                    Console.ReadLine();
                    break;

                case 2:
                    Controllers.Admin.SetQuantity();
                    Console.ReadLine();
                    break;

                case 3:
                    Controllers.Admin.ListUser();
                    Console.ReadLine();
                    break;

                case 4:
                    Controllers.Admin.FindUser();
                    Console.ReadLine();
                    break;

                case 5:
                    Controllers.Admin.UpdateBook();
                    Console.ReadLine();
                    break;

                case 6:
                    Controllers.Admin.DeleteBook();
                    Console.ReadLine();
                    break;

                case 7:
                    Controllers.Admin.AddGenre();
                    Console.ReadLine();
                    break;

                case 8:
                    Controllers.Admin.AddBookToGenre();
                    Console.ReadLine();
                    break;

                case 9:
                    Controllers.Admin.UpdateGenre();
                    Console.ReadLine();
                    break;

                case 10:
                    Controllers.Admin.DeleteGenre();
                    Console.ReadLine();
                    break;

                case 11:
                    Controllers.Admin.AddUser();
                    Console.ReadLine();
                    break;
                case 12:
                    Controllers.User.GetCategories();
                    Console.ReadLine();
                    break;
                case 13:
                    Controllers.User.GetCategories(Helper.InputUser.GetCategories());
                    Console.ReadLine();
                    break;
                case 14:
                    Controllers.User.GetCategory();
                    Console.ReadLine();
                    break;
                case 15:
                    Controllers.User.GetAvaliableBooks();
                    Console.ReadLine();
                    break;
                case 16:
                    Controllers.User.GetBook();
                    Console.ReadLine();
                    break;
                case 17:
                    Controllers.User.GetBooks();
                    Console.ReadLine();
                    break;
                case 18:
                    Controllers.User.GetAuthors();
                    Console.ReadLine();
                    break;
                case 19:
                    Controllers.User.BuyBook();
                    Console.ReadLine();
                    break;
                case 20:
                    Controllers.User.Ping();
                    Console.ReadLine();
                    break;

                case 0:
                    Helper.Validator.SetMainMenuValuation(false);
                    Helper.Validator.SetMainMenuValuation(false);
                    Helper.Validator.SetUserMenuValuation(false);
                    Console.WriteLine("Good Bye");
                    Console.ReadLine();
                    Console.ReadLine();
                    break;

                default:

                    Console.ReadLine();
                    break;
            }
        }
    }
}