namespace FrontEndJesperPersson.View.AdminView
{
    using FrontEndJesperPersson.Controller;
    using System;

    internal class Business
    {
        private int Choice;
        private AdminController Controller = new AdminController();
        private bool KeepGoing;

        /// <summary>
        /// Prints out menu for Business
        /// </summary>
        /// <param name="adminId"></param>
        public void Menu(int adminId)
        {
            do
            {
                KeepGoing = true;
                ViewHelper.CreateMenu("---Verksamhetsinfo---", "Sålda böcker", "Omsättning", "Bästa kund", "Tillbaka");
                Choice = ViewHelper.InputInt();
                switch (Choice)
                {
                    case 1:
                        SoldBooks(adminId);
                        break;

                    case 2:
                        Revenue(adminId);
                        break;

                    case 3:
                        BestCustomer(adminId);
                        break;

                    case 4:
                        KeepGoing = false;
                        break;
                }
            } while (KeepGoing);
        }

        /// <summary>
        /// Prints out the bestcustommer. Errormessage if there is no best custommer.
        /// </summary>
        /// <param name="adminId"></param>
        private void BestCustomer(int adminId)
        {
            var bestCustommer = Controller.BestCustomer(adminId);
            if (bestCustommer != null)
                Console.WriteLine($"Företagets kassako är kunden {bestCustommer.Name}");
            else
                Console.WriteLine("Företaget har ingen \"bästa-kund\"");

            Controller.Ping(adminId);
            Console.ReadLine();
        }

        /// <summary>
        /// Prints out the money that been earned by selling books.
        /// </summary>
        /// <param name="adminId"></param>
        private void Revenue(int adminId)
        {
            Console.WriteLine($"Företagets har omsatt {Controller.MoneyEarned(adminId)} kr genom bokförsäljning");
            Controller.Ping(adminId);
            Console.ReadLine();
        }

        /// <summary>
        /// Prints out all sold books.
        /// </summary>
        /// <param name="adminId"></param>
        private void SoldBooks(int adminId)
        {
            Console.WriteLine("Följande böcker har sålts:");
            foreach (var book in Controller.SoldBooks(adminId))
                Console.WriteLine($"{book.Title}.");

            Controller.Ping(adminId);
            Console.ReadLine();
        }
    }
}