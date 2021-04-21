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
    static class PromoteActivateView
    {
        public static void Show(User admin)
        {
            bool run = true;
            string choise = "";
            while (run)
            {
                TxtMessClass.Mess(Txt.PromoteActivate);
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        TxtMessClass.Mess(ActivatePromoteController.PromoteUser(admin));
                        break;
                    case "2":
                        TxtMessClass.Mess(ActivatePromoteController.DemoteUser(admin));
                        break;
                    case "3":
                        TxtMessClass.Mess(ActivatePromoteController.ActivateUser(admin));
                        break;
                    case "4":
                        TxtMessClass.Mess(ActivatePromoteController.DeactivateUser(admin));
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
