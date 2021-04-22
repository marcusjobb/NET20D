using System;

namespace WebshopMVC.UtilsMVC
{
    /// <summary>
    /// Class for containing ASCII designs used in menu's
    /// </summary>
    public class ASCII
    {
        /// <summary>
        /// Prints Main menu ASCII
        /// </summary>
        public static void MainMenuASCII()
        {
            Console.WriteLine(@"
 __  __       _
|  \/  |     (_)
| \  / | __ _ _ _ __    _ __ ___   ___ _ __  _   _
| |\/| |/ _` | | '_ \  | '_ ` _ \ / _ \ '_ \| | | |
| |  | | (_| | | | | | | | | | | |  __/ | | | |_| |
|_|  |_|\__,_|_|_| |_| |_| |_| |_|\___|_| |_|\__,_|
");
        }

        /// <summary>
        /// Prints Book menu ASCII
        /// </summary>
        public static void BookMenuASCII()
        {
            Console.WriteLine(@"

 ____              _
|  _ \            | |
| |_) | ___   ___ | | __  _ __ ___   ___ _ __  _   _
|  _ < / _ \ / _ \| |/ / | '_ ` _ \ / _ \ '_ \| | | |
| |_) | (_) | (_) |   <  | | | | | |  __/ | | | |_| |
|____/ \___/ \___/|_|\_\ |_| |_| |_|\___|_| |_|\__,_|
");
        }

        /// <summary>
        /// Prints Category menu ASCII
        /// </summary>
        public static void CategoryMenuASCII()
        {
            Console.WriteLine(@"
  _____      _
 / ____|    | |
| |     __ _| |_ ___  __ _  ___  _ __ _   _   _ __ ___   ___ _ __  _   _
| |    / _` | __/ _ \/ _` |/ _ \| '__| | | | | '_ ` _ \ / _ \ '_ \| | | |
| |___| (_| | ||  __/ (_| | (_) | |  | |_| | | | | | | |  __/ | | | |_| |
 \_____\__,_|\__\___|\__, |\___/|_|   \__, | |_| |_| |_|\___|_| |_|\__,_|
                      __/ |            __/ |
                     |___/            |___/
");
        }

        /// <summary>
        /// Prints Admin Main menu ASCII
        /// </summary>
        public static void AdminMainMenuASCII()
        {
            Console.WriteLine(@"
             _           _
    /\      | |         (_)
   /  \   __| |_ __ ___  _ _ __    _ __ ___   ___ _ __  _   _
  / /\ \ / _` | '_ ` _ \| | '_ \  | '_ ` _ \ / _ \ '_ \| | | |
 / ____ \ (_| | | | | | | | | | | | | | | | |  __/ | | | |_| |
/_/    \_\__,_|_| |_| |_|_|_| |_| |_| |_| |_|\___|_| |_|\__,_|
");
        }

        /// <summary>
        /// Prints Admin book menu ASCII
        /// </summary>
        public static void AdminBookMenuASCII()
        {
            Console.WriteLine(@"
             _           _         _                 _
    /\      | |         (_)       | |               | |
   /  \   __| |_ __ ___  _ _ __   | |__   ___   ___ | | __  _ __ ___   ___ _ __  _   _
  / /\ \ / _` | '_ ` _ \| | '_ \  | '_ \ / _ \ / _ \| |/ / | '_ ` _ \ / _ \ '_ \| | | |
 / ____ \ (_| | | | | | | | | | | | |_) | (_) | (_) |   <  | | | | | |  __/ | | | |_| |
/_/    \_\__,_|_| |_| |_|_|_| |_| |_.__/ \___/ \___/|_|\_\ |_| |_| |_|\___|_| |_|\__,_|
");
        }

        /// <summary>
        /// Prints Admin category menu ASCII
        /// </summary>
        public static void AdminCategoryMenuASCII()
        {
            Console.WriteLine(@"
             _           _                   _
    /\      | |         (_)                 | |
   /  \   __| |_ __ ___  _ _ __     ___ __ _| |_ ___  __ _  ___  _ __ _   _   _ __ ___   ___ _ __  _   _
  / /\ \ / _` | '_ ` _ \| | '_ \   / __/ _` | __/ _ \/ _` |/ _ \| '__| | | | | '_ ` _ \ / _ \ '_ \| | | |
 / ____ \ (_| | | | | | | | | | | | (_| (_| | ||  __/ (_| | (_) | |  | |_| | | | | | | |  __/ | | | |_| |
/_/    \_\__,_|_| |_| |_|_|_| |_|  \___\__,_|\__\___|\__, |\___/|_|   \__, | |_| |_| |_|\___|_| |_|\__,_|
                                                      __/ |            __/ |
                                                     |___/            |___/
");
        }

        /// <summary>
        /// Prints Admin user menu ASCII
        /// </summary>
        public static void AdminUserMenuASCII()
        {
            Console.WriteLine(@"
             _           _
    /\      | |         (_)
   /  \   __| |_ __ ___  _ _ __    _   _ ___  ___ _ __   _ __ ___   ___ _ __  _   _
  / /\ \ / _` | '_ ` _ \| | '_ \  | | | / __|/ _ \ '__| | '_ ` _ \ / _ \ '_ \| | | |
 / ____ \ (_| | | | | | | | | | | | |_| \__ \  __/ |    | | | | | |  __/ | | | |_| |
/_/    \_\__,_|_| |_| |_|_|_| |_|  \__,_|___/\___|_|    |_| |_| |_|\___|_| |_|\__,_|
");
        }
    }
}