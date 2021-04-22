using System;
using System.Collections.Generic;
using System.Text;
using WebbshopFront.Views.Home;

namespace WebbshopFront.Controllers
{
    class Menu
    {
        HomeController home = new HomeController();
        CategoriesAndBookController catCon = new CategoriesAndBookController();
        public int UserID { get; set; }
        public void Start()
        {
            var view = new Views.StartMenu();
            view.Show();
            var input = Console.ReadLine();
            int.TryParse(input, out var choice); 
        }
    }
}
