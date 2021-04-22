using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI;

namespace WebshopApiFrontend.Utility
{
    static class SearchMenu
    {
        /// <summary>
        /// Menu section dedicated to searching for books, authors and categories
        /// </summary>
        public static int loggedInUser = Models.CurrentUser.LoggedInUser;
        public static void ListAndSearch()
        {
            bool activeSeassion = true;
            do
            {
                Console.WriteLine("\n**************************************\n" +
                                    "* 1. GetCategories - All\n" +
                                    "* 2. GetCategories - keyword\n" +
                                    "* 3. GetCategory - categoryId\n" +
                                    "* 4. GetAvailableBooks - categoryId\n" +
                                    "* 5. GetBook - bookId\n" +
                                    "* 6. GetBooks - keyword\n" +
                                    "* 7. GetAuthors - keyword\n" +
                                    "* 0. Return\n" +
                                    "**************************************\n");
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string menuChoice = Console.ReadLine();
                Console.ResetColor();

                switch (menuChoice)
                {
                    case "1":
                        Methods.GetCateogiesFromDatabase();
                        break;
                    case "2":
                        Methods.GetCategoriesByKeywordFromDatabase();
                        break;
                    case "3":
                        Methods.GetCategoryByIdFromDatabase();
                        break;
                    case "4":
                        Methods.GetAvaliableBooksByCatIdFromDatabase();
                        break;
                    case "5":
                        Methods.GetBookByIdFromDatabase();
                        break;
                    case "6":
                        Methods.GetBooksByKeywordFromDatabase();
                        break;
                    case "7":
                        Methods.GetAuthorsByKeywordFromDatabase();
                        break;
                    case "0":
                        activeSeassion = false;
                        break;
                }
            } while (activeSeassion);
        }

        

    }
}
