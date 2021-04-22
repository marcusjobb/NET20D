using System;
using Webbshop.Helpers;
using Webbshop.Views;
using WebbshopProject;

namespace Webbshop.Controllers
{
    class CategoriesControllers
    {
        public static WebbshopAPI api = new WebbshopAPI();
        /// <summary>
        /// A menu for users who is not admin, 
        /// that contains all choices about categories.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void CategoriesChoices(int userId)
        {
            UsersControllers.Ping(userId);
            Console.Clear();
            var input = "x";
            while (input != "e")
            {
                CategoriesView.PrintMenu(userId);
                input = Console.ReadLine().ToLower();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            GetCategories();
                            break;
                        case 2:
                            SearchCategory();
                            break;
                        case 3:
                            ListBooksInCategory();
                            break;
                        default:
                            Messages.ErrorMessage("Invalid choice. " +
                                "Try again!");
                            break;
                    }
                }

                else if (input == "e")
                {
                    StartupControllers.Menu(userId);
                }

                else
                {
                    Messages.ErrorMessage("Invalid choice. try again!");
                }
            }
        }

        /// <summary>
        /// A menu for admins, that contains all the choices
        /// about catgories.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void CategoriesChoicesAdmin(int userId)
        {
            UsersControllers.Ping(userId);
            Console.Clear();
            var input = "x";
            Console.WriteLine("What do you want to do?");
            while (input != "e")
            {
                input = Console.ReadLine().ToLower();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddCategory(userId);
                            break;
                        case 2:
                            UpdateCategory(userId);
                            break;
                        case 3:
                            DeleteCategoryAdmin(userId);
                            break;
                        default:
                            Messages.ErrorMessage("Invalid choice. " +
                                "Try again!");
                            break;
                    }
                }

                else if (input == "e")
                {
                    Messages.ColorText("Going back to main menu",
                        ConsoleColor.Cyan);
                    StartupControllers.Menu(userId);
                }

                else
                {
                    Messages.ErrorMessage("Invalid choice. try again!");
                    Console.ReadKey();
                    CategoriesControllers.CategoriesChoices(userId);
                }
            }
        }

        /// <summary>
        /// Prints out all the categories existing in 
        /// the database.
        /// </summary>
        public static void GetCategories()
        {
            var listOfCategories = api.GetCategories();
            if (listOfCategories != null)
            {
                CategoriesView.PrintAllCategories(listOfCategories);
            }

            else
            {
                Messages.ErrorMessage("No categories found.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lets user search for a category, and then 
        /// prints the result from database matching search.
        /// </summary>
        public static void SearchCategory()
        {
            CategoriesView.PrintCategorySearch();
            string keyword = Console.ReadLine();
            var listOfCategories = api.GetCategories(keyword);
            if (listOfCategories != null)
            {
                if (listOfCategories.Count != 0)
                {
                    CategoriesView.
                        PrintCategoriesMatchingSearch(listOfCategories);
                }

                else
                {
                    Messages.ErrorMessage("No categories found.");
                }

            }

            else
            {
                Messages.ErrorMessage("You have to enter something.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints all categories, and lets user choose one.
        /// Then prints the books that has that category.
        /// </summary>
        public static void ListBooksInCategory()
        {
            int choosenCategory = HelperMethods.ChooseCategory();

            var listOfBooks = api.GetCategory(choosenCategory);
            if (listOfBooks.Count != 0)
            {
                CategoriesView.PrintBooksInCategory(listOfBooks);
            }

            else
            {
                Messages.ErrorMessage("There is no books in this category.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lets the user add a category to the database.
        /// Only for admins.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void AddCategory(int userId)
        {
            Console.Clear();
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                CategoriesView.AddCategoryView();
                string name = Console.ReadLine();
                bool answer = api.AddCategory(userId, name);
                if (answer)
                {
                    Messages.SuccessMessage("Category Added.");
                }

                else
                {
                    Messages.ErrorMessage("Something went wrong. Try again!");
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints all categories, and lets user select one.
        /// Then lets user change the name of the selected category.
        /// Only for admins.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void UpdateCategory(int userId)
        {
            Console.Clear();
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                int categoryChoice = HelperMethods.ChooseCategory();
                if (categoryChoice != 0)
                {
                    CategoriesView.CredentialsToUpdateCategory();
                    string nameOfCategory = Console.ReadLine();
                    bool answer = api.UpdateCategory(
                        userId,
                        categoryChoice,
                        nameOfCategory);
                    if (answer)
                    {
                        Messages.SuccessMessage("Changes were successful.");
                    }

                    else
                    {
                        Messages.ErrorMessage("You need to login first");
                    }
                }

                else
                {
                    Messages.ErrorMessage("Something went wrong!");
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints a list of categories and lets the user select one.
        /// The category then gets deleted if there is no books in it.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void DeleteCategoryAdmin(int userId)
        {
            Console.Clear();
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                int categoryChoice = HelperMethods.ChooseCategory();
                if (categoryChoice != 0)
                {
                    bool answer = api.DeleteCategory(
                   userId,
                   categoryChoice);
                    if (answer)
                    {
                        Messages.SuccessMessage("Category Deleted");
                    }

                    else
                    {
                        Messages.ErrorMessage("The category was not empty!");
                    }
                }
                else
                {
                    Messages.ErrorMessage("Something went wrong!");
                }

            }

            else
            {
                Messages.ErrorMessage("You are not authorized.");
            }

            Console.ReadKey();
        }
    }
}
