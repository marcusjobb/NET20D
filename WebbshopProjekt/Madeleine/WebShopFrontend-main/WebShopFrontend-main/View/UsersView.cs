using System;
using System.Collections.Generic;
using System.Text;
using WebShopAssignment;

namespace WebShopFrontend.View
{
    public class UsersView
    {
        public static WebShopAPI api = new WebShopAPI();
        public static void NewUser(string name, string password)
        {

            Console.WriteLine("Användaren finns inte. Vill du registrera dig?");
            Console.WriteLine("Ja/Nej: ");
            string answer = Console.ReadLine().ToLower();
            if (answer == "nej" || answer == "n")
            {
                Console.WriteLine("Tack för besöket!");

            }
            else if (answer == "ja" || answer == "j")
            {
                Console.WriteLine("Skriv lösenordet igen: ");
                string verify = Console.ReadLine();
                api.Register(name, password, verify);
            }
            else
            {
                Messages.WrongInput();
            }
        }

        public static void UserMenu(int userId)
        {
            bool keepGoing = true;

            while (keepGoing)
            {

                Console.WriteLine("Välkommen!");
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine("1. Få en lista över alla kategorier");
                Console.WriteLine("2. Sök efter kategori");
                Console.WriteLine("3. Få en lista på böcker i lager");
                Console.WriteLine("4. Sök efter bok");
                Console.WriteLine("5. Sök efter böcker av en författare");
                Console.WriteLine("6. Logga ut");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 6)
                    {
                        Console.WriteLine("Du loggas nu ut.");
                        api.Logout(userId);
                        keepGoing = false;
                    }
                    else
                    {
                        Controller.UserController.UserMenu.UserChoiceOfMenu(userId, choice);

                    }

                }
                catch
                {
                    Messages.WrongInput();
                }
            }

        }
    }
}
