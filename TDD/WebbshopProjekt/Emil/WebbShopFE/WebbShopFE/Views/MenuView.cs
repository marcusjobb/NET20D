using System;
using WebbShopFE.Helper;

namespace WebbShopFE.Views
{
    /// <summary>
    /// Methods that prints out all info concerning menues.
    /// </summary>
    public static class MenuView
    {
        public static void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome Admin\n");
            Console.WriteLine("1.  Add book");
            Console.WriteLine("2.  Set amount");
            Console.WriteLine("3.  Show all users");
            Console.WriteLine("4.  Search user");
            Console.WriteLine("5.  Update book");
            Console.WriteLine("6.  Delete book");
            Console.WriteLine("7.  Add category");
            Console.WriteLine("8.  Add book to category");
            Console.WriteLine("9.  Update category");
            Console.WriteLine("10. Delete category");
            Console.WriteLine("11. Add user");
            Console.WriteLine("12. Show sold items");
            Console.WriteLine("13. Money earned");
            Console.WriteLine("14. Show best customer");
            Console.WriteLine("15. Promote user");
            Console.WriteLine("16. Demote user");
            Console.WriteLine("17. Activate user");
            Console.WriteLine("18. Inactivate user");
            HelpMethods.RedTextWL("19. Go back");
        }

        public static void BookMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Search books by title");
            Console.WriteLine("2. Get avaliable books by category");
            Console.WriteLine("3. Get categories by keyword");
            Console.WriteLine("4. Buy books");
            HelpMethods.RedTextWL("5. Go back");
        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("The Book Store\n");
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Login");
            HelpMethods.RedTextWL("4. Quit");
        }

        public static void SubMenu()
        {
            Console.Clear();
            Console.WriteLine("The Book Store\n");
            Console.WriteLine("1. Books");
            HelpMethods.RedTextWL("2. Logout");
        }

        public static void SubMenuAdmin()
        {
            Console.Clear();
            Console.WriteLine("Welcome Admin\n");
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Admin menu");
            HelpMethods.RedTextWL("3. Logout");
        }
    }
}