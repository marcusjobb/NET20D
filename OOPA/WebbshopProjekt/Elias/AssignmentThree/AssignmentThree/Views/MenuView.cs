using System;

namespace AssignmentThree.Views
{
    public static class MenuView
    {
        public static void PrintInvalidInput()
        {
            Console.WriteLine("Invalid input, please try again");
        }

        public static void PrintMainMenu()
        {
            Console.WriteLine("1. Browse books");
            Console.WriteLine("2. Browse categories");
            Console.WriteLine("3. Buy book");
            Console.WriteLine("4. Login/Register/Logout");
            Console.WriteLine("5. Admin controls");
            Console.WriteLine("0. Exit");
        }
    }
}