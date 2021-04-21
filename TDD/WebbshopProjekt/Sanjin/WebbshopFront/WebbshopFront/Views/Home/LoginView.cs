using InlamningDB2;
using System;
using System.Collections.Generic;
using System.Text;
using WebbshopFront.Models;

namespace WebbshopFront.Views.Home
{
    class LoginView
    {
        WebbShopAPI Api = new WebbShopAPI();
        public static LoginModel Login()
        {
            Console.Write("Skriv in ditt andvändarnamn: ");
            var userName = Console.ReadLine();
            Console.Write("Skriv in ditt lösenord: ");
            var passWord = Console.ReadLine();
            var loginModel = new LoginModel() { UserName = userName, Password = passWord };
           
            return loginModel;        
        }
        public static void LoginError()
        {
            Console.WriteLine("Fel användarnamn eller lösenord");
            Console.ReadKey();
        }
    }
    }

