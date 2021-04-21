using BookShopFrontEnd.Views;
using System;
using WebbShopAPI;

namespace BookShopFrontEnd
{
    public class Start
    {
        /// <summary>
        /// Starts the application.
        /// The seeds is the categories, authors and books.
        /// The mockdata is 3 users that logs in and buys books and logs back out again.
        /// </summary>
        public static void Application()
        {
               //////////////////////////////////////////////////////////////////
              /// Uncomment this to plant seeds and mockdata to the database .//
             //////////////////////////////////////////////////////////////////
            //Tests.PlantSeedsAndMockData();
            Controllers.MenuController.StartUpMenu();
        }
    }
}
