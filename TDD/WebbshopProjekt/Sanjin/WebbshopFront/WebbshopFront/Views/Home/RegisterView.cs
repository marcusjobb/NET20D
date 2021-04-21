using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Home
{
    class RegisterView
    {
        public static  List<string> Register()
        {
            var userInfo = new List<string>();
            Console.Write("Välj ett användarnamn: ");
            bool userNameValid = false;
            string andvandarNamn = "0";
            while (!userNameValid)
            {
                andvandarNamn = Console.ReadLine();
                if (andvandarNamn.Length <5)
                {
                    Console.WriteLine("Användarnamnet måste inehålla minst 5 tecken");
                }
                else
                {
                    userNameValid = true;
                }
            }
            Console.Write("Välj ett lösenord:  ");
            bool passWordValid = false;

            string password = "0";
            while (!passWordValid)
               
            {
                password = Console.ReadLine();
                if (password.Length < 5)
                {
                    Console.WriteLine("Lösenordet måste inehålla minst 5 tecken");
                }
                else
                {
                    passWordValid = true;
                }
            }
            Console.Write("Skriv in lösenordet igen: ");
            bool passWordVerifyValid = false;
            string passWordVerify = "0";
            while (!passWordVerifyValid)
            {
                passWordVerify = Console.ReadLine();
                if (passWordVerify != password)
                {
                    Console.WriteLine("Lösenordet matchar inte");
                }
                else
                {
                    passWordVerifyValid = true;
                }
            }

            Console.WriteLine(andvandarNamn + " Är nu registrerad välkommen!");    
            Console.ReadKey();
            userInfo.Add(andvandarNamn);
            userInfo.Add(password);
            userInfo.Add(passWordVerify);

            return userInfo;
        }
    }
}
