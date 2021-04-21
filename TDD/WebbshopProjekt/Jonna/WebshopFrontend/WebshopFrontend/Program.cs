using System;


namespace WebshopFrontend
{
    using Views;
    using WebshopFrontend.Controller;

    class Program
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        static void Main(string[] args)
        {
            // For that extra Matrix/Fallout shop vibes
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            /*
            ----------------------------------------------------------------------------------
               _____               __                     
              / ___/___  ___  ____/ /                     
              \__ \/ _ \/ _ \/ __  /                      
             ___/ /  __/  __/ /_/ /                       
            /____/\___/\___/\__,_/    __                  
               / __ \____ _/ /_____ _/ /_  ____ _________ 
              / / / / __ `/ __/ __ `/ __ \/ __ `/ ___/ _ \
             / /_/ / /_/ / /_/ /_/ / /_/ / /_/ (__  )  __/
            /_____/\__,_/\__/\__,_/_.___/\__,_/____/\___/ 
            ----------------------------------------------------------------------------------


            //Step 1. Run database seeder to fill database with categories, books and users
            //RUN ME FIRST TO SEED THE DATABASE
            WebShop.Database.DatabaseSeeder.SeedDatabase();
            */

            /*
            ----------------------------------------------------------------------------------
                ____                                   
               / __ \__  ______                        
              / /_/ / / / / __ \                       
             / _, _/ /_/ / / / /                       
            /_/ |_|\__,_/_/ /_/                        
             _       __     __         __              
            | |     / /__  / /_  _____/ /_  ____  ____ 
            | | /| / / _ \/ __ \/ ___/ __ \/ __ \/ __ \
            | |/ |/ /  __/ /_/ (__  ) / / / /_/ / /_/ /
            |__/|__/\___/_.___/____/_/ /_/\____/ .___/ 
                                              /_/      
            ----------------------------------------------------------------------------------
            */

            // Starts application
            //Welcome.WelcomeMenu();
        }
    }
}
