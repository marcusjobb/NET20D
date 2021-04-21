using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.View;
using System.Threading;

namespace WebbShopAPI.View
{
    static class ViewClass
    {
        /// <summary>
        /// This is the entry om the application
        /// </summary>
        public static void Run()
        {
            bool running = true;
            while (running)
            {
                string choise = MenuOne.Show();
                if (choise == "B" || choise == "b") running = false;
            }

        }
    }
}
