using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;
using WebbShop.LeeUtils;
using WebbShop.Controller;

namespace WebbShop.View
{
    static class AddEditRemoveView
    {
        /// <summary>
        /// Adds, edits or remove a user
        /// </summary>
        /// <param name="admin"></param>
        public static void Show(User admin)
        {
            bool run = true;
            string choise = "";
            while (run)
            {
                TxtMessClass.Mess(Txt.AddEditDeleteUser);
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        TxtMessClass.Mess(AdminController.AddUser(admin));
                        break;
                    case "2":
                        PromoteActivateView.Show(admin);
                        break;
                    case "3":
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
