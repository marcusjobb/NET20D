using System;

namespace BookShopFrontEnd.Utility
{
    /// <summary>
    /// Prints out asci-logotypes.
    /// Font name: Big.
    /// Website: http://patorjk.com/software/taag/#p=display&f=Big&t=Main%20Menu
    /// </summary>
    public class Logotypes
    {
        public static void AdminPanel()
        {
            Console.WriteLine($@"              _           _         _____                 _ 
     /\      | |         (_)       |  __ \               | |
    /  \   __| |_ __ ___  _ _ __   | |__) |_ _ _ __   ___| |
   / /\ \ / _` | '_ ` _ \| | '_ \  |  ___/ _` | '_ \ / _ \ |
  / ____ \ (_| | | | | | | | | | | | |  | (_| | | | |  __/ |
 /_/    \_\__,_|_| |_| |_|_|_| |_| |_|   \__,_|_| |_|\___|_|
                                                            
                                                            ");
        }


        public static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@" __          __  _                          
 \ \        / / | |                         
  \ \  /\  / /__| | ___ ___  _ __ ___   ___ 
   \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \
    \  /\  /  __/ | (_| (_) | | | | | |  __/
     \/  \/ \___|_|\___\___/|_| |_| |_|\___|
                                            
                                            ");
            Console.ResetColor();
        }

        public static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@"  __  __       _         __  __                  
 |  \/  |     (_)       |  \/  |                 
 | \  / | __ _ _ _ __   | \  / | ___ _ __  _   _ 
 | |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |
 | |  | | (_| | | | | | | |  | |  __/ | | | |_| |
 |_|  |_|\__,_|_|_| |_| |_|  |_|\___|_| |_|\__,_|
                                                 
                                                 ");
            Console.ResetColor();
        }
        public static void Login()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@"  _                 _       
 | |               (_)      
 | |     ___   __ _ _ _ __  
 | |    / _ \ / _` | | '_ \ 
 | |___| (_) | (_| | | | | |
 |______\___/ \__, |_|_| |_|
               __/ |        
              |___/         ");
            Console.ResetColor();
        }

        public static void Register()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@"  _____            _     _            
 |  __ \          (_)   | |           
 | |__) |___  __ _ _ ___| |_ ___ _ __ 
 |  _  // _ \/ _` | / __| __/ _ \ '__|
 | | \ \  __/ (_| | \__ \ ||  __/ |   
 |_|  \_\___|\__, |_|___/\__\___|_|   
              __/ |                   
             |___/                    ");
            Console.ResetColor();
        }

        public static void Logout()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@"  _                             _   
 | |                           | |  
 | |     ___   __ _  ___  _   _| |_ 
 | |    / _ \ / _` |/ _ \| | | | __|
 | |___| (_) | (_| | (_) | |_| | |_ 
 |______\___/ \__, |\___/ \__,_|\__|
               __/ |                
              |___/                 ");
            Console.ResetColor();
        }

        public static void BookStore()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@"  ____              _       _____ _                 
 |  _ \            | |     / ____| |                
 | |_) | ___   ___ | | __ | (___ | |_ ___  _ __ ___ 
 |  _ < / _ \ / _ \| |/ /  \___ \| __/ _ \| '__/ _ \
 | |_) | (_) | (_) |   <   ____) | || (_) | | |  __/
 |____/ \___/ \___/|_|\_\ |_____/ \__\___/|_|  \___|
                                                    
                                                    ");
            Console.ResetColor();
        }

        public static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@"  ______      _ _                          _ _           _   _             
 |  ____|    (_) |       /\               | (_)         | | (_)            
 | |__  __  ___| |_     /  \   _ __  _ __ | |_  ___ __ _| |_ _  ___  _ __  
 |  __| \ \/ / | __|   / /\ \ | '_ \| '_ \| | |/ __/ _` | __| |/ _ \| '_ \ 
 | |____ >  <| | |_   / ____ \| |_) | |_) | | | (_| (_| | |_| | (_) | | | |
 |______/_/\_\_|\__| /_/    \_\ .__/| .__/|_|_|\___\__,_|\__|_|\___/|_| |_|
                              | |   | |                                    
                              |_|   |_|                                    ");
            Console.ResetColor();
        }
    }
}
