using BookWebShop;
using BookWebShopFrontend.View.SoldBooks;
using System;
using System.Threading;

namespace BookWebShopFrontend.Controller
{
    public class SoldBooksController
    {
        /// <summary>
        /// Class for soldbooks and controller for admin user.
        /// </summary>

        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Method for the soldbooks menu for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        public void SoldBooksMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                AdminSoldBooksMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(adminId);
                            SoldBooks(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 2:
                            Console.Clear();
                            api.Ping(adminId);
                            MoneyEarned(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 3:
                            Console.Clear();
                            api.Ping(adminId);
                            BestCustomer(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 0:
                            Console.Clear();
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        /// <summary>
        /// Method for checking what customer is the best customer for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void BestCustomer(int adminId)
        {
            try
            {
                var user = api.BestCustomer(adminId);
                if (user != null)
                {
                    Console.WriteLine($"The best customer is {user.Name}");
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            catch { Console.WriteLine("Something went wrong."); }
        }

        /// <summary>
        /// Method for checking what the total money earned is for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void MoneyEarned(int adminId)
        {
            try
            {
                var money = api.MoneyEarned(adminId);
                Console.WriteLine($"Total money earned is {money}kr");
            }
            catch { Console.WriteLine("Something went wrong."); }
        }

        /// <summary>
        /// Method for checking all the soldbooks for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void SoldBooks(int adminId)
        {
            if (api.SoldItems(adminId) != null)
            {
                try
                {
                    Console.WriteLine($"{"Id:",-4}{"Title:",-20}{"Purchasedate:",-20}\n");
                    foreach (var soldBook in api.SoldItems(adminId))
                    {
                        Console.WriteLine($"{soldBook.Id + ".",-4}{soldBook.Title,-20}{soldBook.PurchaseDate,-20:d}");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Something went wrong."); }
        }
    }
}