using AssignmentThree.Views;
using System;

namespace AssignmentThree.Controllers
{
    public static class CategoryController
    {
        public static void CategoryMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                CategoryView.PrintCategoryMenu();
                int.TryParse(Console.ReadLine(), out var userInput);

                switch (userInput)
                {
                    case 1:
                        CategoryView.PrintCategories();
                        break;

                    case 2:
                        CategoryView.PrintMatchingCategories();
                        break;

                    case 0:
                        keepRunning = false;
                        break;

                    default:
                        CategoryView.PrintInvalidInput();
                        break;
                }
            }
        }
    }
}