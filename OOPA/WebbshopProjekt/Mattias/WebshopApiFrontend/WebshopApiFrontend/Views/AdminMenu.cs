using System;

namespace WebshopApiFrontend.Utility
{
    static class AdminMenu
    {
        public static int loggedInUser = Models.CurrentUser.LoggedInUser;
        /// <summary>
        /// Admin menu with all admin specific methods and functions
        /// </summary>
        public static void AdminPanel()
        {
            bool activeSeassion = true;
            do
            {
                Console.WriteLine("\n**************************************\n" +
                                    "* 1. Edit/Remove/Add\n" +
                                    "* 2. Update\n" +
                                    "* 3. Search\n" +
                                    "* 0. Return\n" +
                                    "**************************************\n");
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string menuChoice = Console.ReadLine();
                Console.ResetColor();

                switch (menuChoice)
                {
                    case "1":
                        EditRemoveAdd();
                        break;
                    case "2":
                        Update();
                        break;
                    case "3":
                        Search();
                        break;
                    case "0":
                        activeSeassion = false;
                        break;
                }
            } while (activeSeassion);
        }
        /// <summary>
        /// Editremoveadd section in menu, containing methods with relevant purpose
        /// </summary>
        public static void EditRemoveAdd()
        {
            bool activeSeassion = true;
            do
            {
                Console.WriteLine("\n**************************************\n" +
                                    "* 1. Addbook\n" +
                                    "* 2. AddCategory\n" +
                                    "* 3. AddUser\n" +
                                    "* 4. DeleteCategory\n" +
                                    "* 5. DeleteBook\n" +
                                    "* 6. Promote\n" +
                                    "* 7. Demote\n" +
                                    "* 8. ActivateUser\n" +
                                    "* 9. InactivateUser\n" +
                                    "* 0. Return\n" +
                                    "**************************************\n");
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string menuChoice = Console.ReadLine();
                Console.ResetColor();

                switch (menuChoice)
                {
                    case "1":
                        AdminMethods.AddBookToDatebase();
                        break;
                    case "2":
                        AdminMethods.AddCategoryToDatabase();
                        break;
                    case "3":
                        AdminMethods.AddUserToDatabase();
                        break;
                    case "4":
                        AdminMethods.DeleteCategoryFromDatabase();
                        break;
                    case "5":
                        AdminMethods.DeleteBookFromDatabase();
                        break;
                    case "6":
                        AdminMethods.PromoteUser();
                        break;
                    case "7":
                        AdminMethods.DemoteUser();
                        break;
                    case "8":
                        AdminMethods.ActivateUserStatus();
                        break;
                    case "9":
                        AdminMethods.InactivateUserStatus();
                        break;
                    case "0":
                        activeSeassion = false;
                        break;
                }
            } while (activeSeassion);
        }
        /// <summary>
        /// update section , contains methods with relevant purpose
        /// </summary>
        public static void Update()
        {
            bool activeSeassion = true;
            do
            {
                Console.WriteLine("\n**************************************\n" +
                                    "* 1. SetAmount\n" +
                                    "* 2. UpdateBook\n" +
                                    "* 3. AddBookToCategory\n" +
                                    "* 4. UpdateCategory\n" +
                                    "* 0. Return\n" +
                                    "**************************************\n");
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string menuChoice = Console.ReadLine();
                Console.ResetColor();

                switch (menuChoice)
                {
                    case "1":
                        AdminMethods.SetAmountOfBooks();
                        break;
                    case "2":
                        AdminMethods.UpdateBookInDatabase();
                        break;
                    case "3":
                        AdminMethods.AddBookToCategoryInDatabase();
                        break;
                    case "4":
                        AdminMethods.UpdateCategoryInDatabase();
                        break;
                    case "0":
                        activeSeassion = false;
                        break;
                }
            } while (activeSeassion);
        }
        /// <summary>
        /// search section, contains methods with relevant purpose
        /// </summary>
        public static void Search()
        {
            bool activeSeassion = true;
            do
            {
                Console.WriteLine("\n**************************************\n" +
                                    "* 1. ListUsers\n" +
                                    "* 2. FindUser\n" +
                                    "* 3. SoldItems\n" +
                                    "* 4. MoneyEarned\n" +
                                    "* 5. BestCustomer\n" +
                                    "* 0. Return\n" +
                                    "**************************************\n");
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string menuChoice = Console.ReadLine();
                Console.ResetColor();

                switch (menuChoice)
                {
                    case "1":
                        AdminMethods.ListUsersFromDatabase();
                        break;
                    case "2":
                        AdminMethods.FindUserInDatabase();
                        break;
                    case "3":
                        AdminMethods.SoldItemsInDatabase();
                        break;
                    case "4":
                        AdminMethods.MoneyEarnedFromDatabase();
                        break;
                    case "5":
                        AdminMethods.BestCustomerInDatabase();
                        break;
                    case "0":
                        activeSeassion = false;
                        break;
                }
            } while (activeSeassion);
        }
    }
}
