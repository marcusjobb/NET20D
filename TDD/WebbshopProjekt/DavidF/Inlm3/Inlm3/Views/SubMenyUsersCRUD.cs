using Inlm3.Controllers;
using Inlm3.Helpers;
using System;
using System.Linq;

namespace Inlm3.Views

{    /// <summary>
     /// Klass för subMenyn som hanterar visandet av Users
     /// </summary>
    internal class SubMenyUsersCRUD
    {
        private Controller controll = new Controller();

        /// <summary>
        /// undex för denna subMeny
        /// </summary>
        public void Index(int userID)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("1. List Users");
                Console.WriteLine("2. Find User");
                Console.WriteLine("3. Add User");
                Console.WriteLine("4. Best Customer");
                Console.WriteLine("5. Promote");
                Console.WriteLine("6. Demote");
                Console.WriteLine("7. Activate User");
                Console.WriteLine("8. Inactivate User");
                Console.WriteLine("9. Money Earned");
                Console.WriteLine("10. Register ");
                Console.WriteLine("11. Main Meny ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ListUsers(userID);
                        Helper.NextStep();
                        break;

                    case "2":
                        FindUser(userID);
                        Helper.NextStep();
                        break;

                    case "3":
                        AddUser(userID);
                        Helper.NextStep();
                        break;

                    case "4":
                        BestCustomer(userID);
                        Helper.NextStep();
                        break;

                    case "5":
                        Promote(userID);
                        Helper.NextStep();
                        break;

                    case "6":
                        Demote(userID);
                        Helper.NextStep();
                        break;

                    case "7":
                        ActivateUser(userID);
                        Helper.NextStep();
                        break;

                    case "8":
                        InactivateUser(userID);
                        Helper.NextStep();
                        break;

                    case "9":
                        MoneyEarned(userID);
                        Helper.NextStep();
                        break;

                    case "10":
                        Register(userID);
                        Helper.NextStep();
                        break;

                    case "11":
                        keepGoing = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Listar alla användare
        /// </summary>
        public void ListUsers(int userID)
        {
            Console.WriteLine("These are all the users:");
            var list = controll.ListUsers(userID);

            if (list.Count() != 0)
            {
                foreach (var u in list)
                {
                    Console.WriteLine($"Name: {u.Name} ID:{u.ID}");
                }
            }
            else
            {
                Console.WriteLine("something went wrong, please try again");
            }
        }

        /// <summary>
        /// Listar användare baserat på sökning
        /// </summary>
        public void FindUser(int userID)
        {
            Console.WriteLine("Please enter the information below to find users");
            var list = controll.FindUser(userID);

            if (list.Count() != 0)
            {
                foreach (var u in list)
                {
                    Console.WriteLine($"Name: {u.Name} ID:{u.ID}");
                }
            }
            else
            {
                Console.WriteLine("something went wrong, please try again");
            }
        }

        /// <summary>
        /// Lägger till en användare
        /// </summary>
        public void AddUser(int userID)
        {
            Console.WriteLine("Please enter the information below to add a user");
            if (controll.AddUser(userID))
            {
                Console.WriteLine("User was sucessfully added! ");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Visar totalt antal kr av sålda böcker
        /// </summary>
        public void MoneyEarned(int userID)
        {
            Console.WriteLine("This is the total money earned by selling books: ");
            if (controll.MoneyEarned(userID) != 0)
            {
                Console.WriteLine($"Money earned: {controll.MoneyEarned(userID)}");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Visar ID: av den bästa kunden
        /// </summary>
        public void BestCustomer(int userID)
        {
            int customerID = controll.BestCustomer(userID);

            if (customerID != 0)
            {
                Console.WriteLine($"The best customer has the ID: {customerID} ");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Visar om en användare blivit admin
        /// </summary>
        public void Promote(int userID)
        {
            if (controll.Promote(userID))
            {
                Console.WriteLine("The user has been promoted to Admin");
            }
            else
            {
                Console.WriteLine("Someting went wrong, please try again");
            }
        }

        /// <summary>
        /// Visar om en användare blivit en simpel user igen
        /// </summary>
        public void Demote(int userID)
        {
            if (controll.Demote(userID))
            {
                Console.WriteLine("The user has been demoted from Admin");
            }
            else
            {
                Console.WriteLine("Someting went wrong, please try again");
            }
        }

        /// <summary>
        /// Visar om en användare blivit aktiverad
        /// </summary>
        public void ActivateUser(int userID)
        {
            if (controll.ActivateUser(userID))
            {
                Console.WriteLine("The user has been activated");
            }
            else
            {
                Console.WriteLine("Someting went wrong, please try again");
            }
        }

        /// <summary>
        /// Visar om en användare blivit inaktiverad
        /// </summary>
        public void InactivateUser(int userID)
        {
            if (controll.InactivateUser(userID))
            {
                Console.WriteLine("The user has been inactivated");
            }
            else
            {
                Console.WriteLine("Someting went wrong, please try again");
            }
        }

        /// <summary>
        /// Registrerar en användare
        /// </summary>
        public void Register(int userID)
        {
            if (controll.Register(userID))
            {
                Console.WriteLine("The user was sucessfully created!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }
    }
}