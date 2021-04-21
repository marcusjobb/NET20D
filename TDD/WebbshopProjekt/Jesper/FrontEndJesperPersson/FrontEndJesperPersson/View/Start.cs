namespace FrontEndJesperPersson.View
{
    using FrontEndJesperPersson.Controller;
    using System;

    internal class Start
    {
        private static CustomerController Controller = new CustomerController();
        private static bool KeepGoing = true;
        private static int LogInTries = 3;

        /// <summary>
        /// Prints out menu when starting the program. Either registration or log in.
        /// </summary>
        public static void Menu()
        {
            while (KeepGoing)
            {
                ViewHelper.CreateMenu("*****Välkommen Till Jesper Persson Bokbutik*****", "Logga in", "Registrera dig", "Avsluta");
                var choice = ViewHelper.InputInt();
                switch (choice)
                {
                    case 1:
                        LoginUser();
                        KeepGoing = false;
                        break;

                    case 2:
                        Registration();
                        break;

                    case 3:
                        KeepGoing = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Prints out instructions for Log in. Then control flow to direct user to right menu.
        /// </summary>
        private static void LoginUser()
        {
            while (LogInTries > 0)   // if user tried 3 times and failed the program will shut down.
            {
                Console.WriteLine("Användarnamn:");
                var username = ViewHelper.InputString();
                Console.WriteLine("Lösenord:");
                var password = ViewHelper.InputString();
                var user = Controller.Login(username, password);
                if (user != null)
                {
                    if (user.IsAdmin)
                        Index.AdminMenu(user.Id);
                    else
                        Index.UserMenu(user.Id);
                    LogInTries = 0;
                }
                else
                {
                    ViewHelper.ErrorMessage("Inloggningsförsöket misslyckades");
                    LogInTries--;
                    if (LogInTries == 0) Console.WriteLine("Du har försökt för många gånger. Stänger ner programmet");
                    else Menu();
                }
            }
        }

        /// <summary>
        /// Prints out instructions to registrate a new user/customer.
        /// </summary>
        private static void Registration()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Registering av ny kund");
            Console.WriteLine("----------------------");
            Console.Write("Användarnamn: ");
            var username = ViewHelper.InputString();
            Console.Write("Lösenord: ");
            var password = ViewHelper.InputString();
            Console.Write("Upprepa lösenord: ");
            var passwordVerify = ViewHelper.InputString();
            var success = Controller.Register(username, password, passwordVerify);

            if (success) Console.WriteLine($"{username} är nyregistrerad som ny kund. Du kan nu logga in.");
            else Console.WriteLine($"{username} kan vara upptagget eller så kunde inte lösenordet verfieras. Försök igen.");

            Console.ReadLine();
        }
    }
}