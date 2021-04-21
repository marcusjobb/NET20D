using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.LeeUtils;
using WebbShopAPI.Model;
using WebbShop.Controller;
using System.Threading;

namespace WebbShop.View
{
    static class LogInView
    {

        /// <summary>
        /// Displays the log in view
        /// </summary>
        public static void Show()
        {
            Thread.Sleep(500);
            Console.Clear();
            bool run = true;
            string choise = "";
            while (run)
            {
                TxtMessClass.Mess(Txt.Welcome);
                TxtMessClass.Mess(Txt.WelcomeVies);
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        LogInController.LogInScreen();
                        run = false;
                        break;
                    case "2":
                        if (LogInController.Registration())
                        {
                            LogInController.LogInScreen();
                            run = false;
                        }
                        else
                        {
                            TxtMessClass.Mess(Txt.Nothing);
                            run = false;
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
                        ;
                }
            }
        }
    }
}
