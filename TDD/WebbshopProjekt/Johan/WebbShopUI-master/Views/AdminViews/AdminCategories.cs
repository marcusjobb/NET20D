using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopUI.Views.AdminViews
{
    class AdminCategories
    {
        public int AdminCategoriesMenu()
        {
            Console.Clear();
            Console.WriteLine("Category options!");
            Console.WriteLine("");
            Console.WriteLine("1. Add a category");
            Console.WriteLine("2. Update a category");
            Console.WriteLine("3. Delete a category");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;
        }

        public string CategoryName()
        {
            Console.Write("Please type in the name of the category: ");
            string name = Console.ReadLine();

            return name;
        }

        public int CategoryID()
        {
            Console.Write("Please type in the ID of the category: ");
            int.TryParse(Console.ReadLine(), out int categoryId);

            return categoryId;
        }




    }
}
