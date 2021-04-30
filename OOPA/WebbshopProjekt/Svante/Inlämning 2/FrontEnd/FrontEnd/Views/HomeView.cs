using System;

namespace FrontEnd.Views
{
    public class HomeView
    {
        internal void Display()
        {
            Console.Clear();
            Console.WriteLine(@"
            :::       ::::::::::::::::       ::::::::  :::::::: ::::    :::: ::::::::::
            :+:       :+::+:       :+:      :+:    :+::+:    :+:+:+:+: :+:+:+:+:
            +:+       +:++:+       +:+      +:+       +:+    +:++:+ +:+:+ +:++:+
            +#+  +:+  +#++#++:++#  +#+      +#+       +#+    +:++#+  +:+  +#++#++:++#
            +#+ +#+#+ +#++#+       +#+      +#+       +#+    +#++#+       +#++#+
             #+#+# #+#+# #+#       #+#      #+#    #+##+#    #+##+#       #+##+#
              ###   ###  ############################  ######## ###       #############
            ");
            Console.WriteLine("\n\t Login or Register");
            Console.WriteLine("*******************");
            Console.WriteLine("[1] Login");
            Console.WriteLine("[2] Register");
            Console.WriteLine("[0] Quit/Logout");
            Console.WriteLine("*******************");
        }

        internal void DisplaySwitch()
        {
            var caseSwitch = Helper.Inputs.InputMainMenuSwitch();
            switch (caseSwitch)
            {
                case 1:
                    Models.User.UserId = Helper.LoginUserAdmin.Login();
                    if (Models.User.UserId > 0)
                    {
                        if (WebbShopAPI.WebbShopApi.AccesFrontEnd(Models.User.UserId))
                        {
                            Helper.Validator.SetMainMenuValuation(false);
                            Helper.Validator.SetAdminMenuValuation(true);
                        }
                        else
                        {
                            Helper.Validator.SetMainMenuValuation(false);
                            Helper.Validator.SetUserMenuValuation(true);
                        }
                    }

                    break;

                case 2:
                    var regInput = Helper.Inputs.InputRegister();
                    WebbShopAPI.WebbShopApi.Register(regInput.userName, regInput.password, regInput.passwordVerify);

                    break;

                case 0:

                    Helper.Validator.SetMainMenuValuation(false);
                    Helper.Validator.SetMainMenuValuation(false);
                    Helper.Validator.SetUserMenuValuation(false);
                    Console.WriteLine("Good Bye");
                    Console.ReadLine();
                    break;

                case 4:
                    Console.WriteLine("your input is not a number");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadLine();
                    break;
            }
        }
    }
}