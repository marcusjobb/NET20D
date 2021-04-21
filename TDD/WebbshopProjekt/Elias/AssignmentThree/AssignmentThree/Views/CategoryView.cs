using System;

namespace AssignmentThree.Views
{
    public static class CategoryView
    {
        public static void PrintCategories()
        {
            foreach (var item in Program.API.GetCategories())
            {
                Console.WriteLine($"ID:{item.Id} {item.Name}");
            }
        }

        public static void PrintCategoryMenu()
        {
            Console.WriteLine("1. List of all categories");
            Console.WriteLine("2. List of categories matching keyword");
            Console.WriteLine("0. Return to main menu");
        }

        public static void PrintInvalidInput()
        {
            Console.WriteLine("Invalid input, please try again");
        }

        public static void PrintMatchingCategories()
        {
            Console.WriteLine("Please enter the keyword for matching categories");
            var userInput = Console.ReadLine();

            foreach (var item in Program.API.GetCategories(userInput))
            {
                Console.WriteLine($"ID:{item.Id} {item.Name}");
            }
        }
    }
}