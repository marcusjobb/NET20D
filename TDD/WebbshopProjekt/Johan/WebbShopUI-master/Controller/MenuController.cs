using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI;
using WebbShopUI.Views;

namespace WebbShopUI.Controller
{
    public class MenuController
    {
        WebbShopAPInterface api = new WebbShopAPInterface();


        public void RunProgram()
        {
            bool runProgram = true;

            while(runProgram)
            {
                var adminControl = new AdminController();
                var userControl = new UserController();
                var message = new Messages();
                var login = new Login();
                var home = new Home();
                var register = new Register(); 
                var userChoice = home.HomeView();

                switch(userChoice)
                {
                    case 1:
                        var userInfo = register.NewUser();
                        var newUser = api.Register(userInfo[0], userInfo[1], userInfo[2]);
                        if(newUser == true)
                        {
                            message.SuccessMessage();
                        }
                        if(newUser == false)
                        {
                            message.FailMessage();
                        }

                        break;

                    case 2:
                        var list = login.LoginView();
                        var userId = api.Login(list[0], list[1]);
                        if(userId == 0)
                        {
                            message.FailMessage();
                        }
                        if(userId == 1)
                        {
                            message.SuccessMessage();
                            api.Ping(userId);
                            adminControl.RunAdminMenu(userId);
                        }
                        if(userId > 1)
                        {
                            message.SuccessMessage();
                            api.Ping(userId);
                            userControl.RunUserMenu(userId);
                            
                        }

                        break;

                    case 3:
                        Environment.Exit(0);
                        break;



                }


            }


        }

    }
}
