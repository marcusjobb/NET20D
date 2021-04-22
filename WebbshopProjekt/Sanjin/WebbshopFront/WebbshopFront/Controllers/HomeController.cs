using InlamningDB2;
using System;
using System.Collections.Generic;
using System.Text;
using WebbshopFront.Views.Home;

namespace WebbshopFront.Controllers
{
    class HomeController
    {
        WebbShopAPI Api = new WebbShopAPI();
        public int Login()
        {
            var loginModel = LoginView.Login();
            var result = Api.Login(loginModel.UserName, loginModel.Password);
            if (result ==0)
            {
                LoginView.LoginError();     
            }
         
            return result;
        }

        public  void Register()
        {
            var userInfo = Views.Home.RegisterView.Register();
            var result = Api.Register(userInfo[0], userInfo[1], userInfo[2]);
        }

        internal void Logout(int userId)
        {
            Api.Logout(userId);
        }
    }
}
