using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.LeeUtils;
using WebbShopAPI.Model;
using WebbShop.Controller;

namespace WebbShop.View
{
    static class AdminView
    {
        /// <summary>
        /// Displays admin options reserved for admins
        /// </summary>
        /// <param name="user"></param>
        public static void Show(User admin)
        {
            bool run = true;
            string choise = "";
            while (run)
            {
                TxtMessClass.Mess(Txt.AdminOptionView);
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        TxtMessClass.Mess(AdminController.AddBook(admin));
                        break;
                    case "2":
                        TxtMessClass.Mess(AdminController.ChangeTheAmount(admin));
                        break;
                    case "3":
                        TxtMessClass.Mess(AdminController.ListUsers(admin));
                        break;
                    case "4":
                        AddEditRemoveView.Show(admin);
                        break;
                    case "5":
                        TxtMessClass.Mess(AdminController.FindUsers(admin));
                        break;
                    case "6":
                        TxtMessClass.Mess(AdminController.UpdateBook(admin));
                        break;
                    case "7":
                        TxtMessClass.Mess(AdminController.DeleteBook(admin));
                        break;
                    case "8":
                        TxtMessClass.Mess(AdminController.AddCategory(admin));
                        break;
                    case "9":
                        TxtMessClass.Mess(AdminController.AddBookToCategory(admin));
                        break;
                    case "10":
                        TxtMessClass.Mess(AdminController.UpdateCategory(admin));
                        break;
                    case "11":
                        TxtMessClass.Mess(AdminController.DeleteCategory(admin));
                        break;
                    case "12":
                        TxtMessClass.Mess(AdminController.ListAllSoldBooks(admin));
                        break;
                    case "13":
                        TxtMessClass.Mess(AdminController.ShowMoneyEarned(admin));
                        break;
                    case "14":
                        TxtMessClass.Mess(AdminController.ShowBestCustomer(admin));
                        break;
                    case "15":
                        TxtMessClass.Mess(AdminController.DeleteUser(admin));
                        break;
                    case "b":
                        run = false;
                        break;
                    case "B":
                        run = false;
                        break;
                    default:
                        TxtMessClass.Mess(Txt.WrongInputOrBack);
                        break;
                }
            }
        }
    }
}
