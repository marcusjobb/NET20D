using BookWebShop;
using BookWebShopFrontend.View.Categories;
using System;
using System.Linq;
using System.Threading;

namespace BookWebShopFrontend.Controller
{
    public class CategoryController
    {
        /// <summary>
        /// Class for category menus and controllers for admin and customer users.
        /// </summary>

        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Category menu for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        public void CategoryMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                GetCategories(adminId);
                AdminCategoryMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(adminId);
                            GetCategories(adminId);
                            AddCategory(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 2:
                            Console.Clear();
                            api.Ping(adminId);
                            GetCategories(adminId);
                            AddBookToCategory(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 3:
                            Console.Clear();
                            api.Ping(adminId);
                            GetCategories(adminId);
                            UpdateCategory(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 4:
                            Console.Clear();
                            api.Ping(adminId);
                            GetCategories(adminId);
                            DeleteCategory(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 0:
                            Console.Clear();
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        /// <summary>
        /// Category menu for customer user.
        /// </summary>
        /// <param name="userId"></param>
        public void CategoryMenuCustomer(int userId)
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                GetCategories(userId);
                CustomerCategoryMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(userId);
                            GetCategories(userId);
                            SearchCategory(userId);
                            Thread.Sleep(2000);
                            break;

                        case 2:
                            Console.Clear();
                            api.Ping(userId);
                            GetCategories(userId);
                            GetBooksInCategory(userId);
                            Thread.Sleep(2000);
                            break;

                        case 0:
                            Console.Clear();
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        /// <summary>
        /// Method for adding a book to a category for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void AddBookToCategory(int adminId)
        {
            Console.Write("\nEnter Id number of the category: ");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                if (api.GetAvaliableBooks() != null)
                {
                    Console.Clear();
                    try
                    {
                        Console.WriteLine($"{"Id:",-4}{"Title:",-20}{"Author:",-20}{"Price:",-7}{"Amount:",-8}\n");
                        foreach (var book in api.GetAvaliableBooks())
                        {
                            Console.WriteLine($"{book.Id + ".",-4}{book.Title,-20}{book.Author,-20}{book.Price,-7}{book.Amount,-8}");
                        }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
                Console.Write("\nEnter Id number of the book: ");
                if (int.TryParse(Console.ReadLine(), out var bookId))
                {
                    if (api.GetCategories().Where(c => c.Id == categoryId) != null && api.GetBook(bookId) != null)
                    {
                        if (api.AddBookToCategory(adminId, bookId, categoryId))
                        {
                            foreach (var category in api.GetCategories().Where(c => c.Id == categoryId))
                            {
                                foreach (var book in api.GetBook(bookId))
                                {
                                    Console.WriteLine($"Success! The book {book.Title} was added to the category {category.Name}.");
                                }
                            }
                        }
                        else { Console.WriteLine("Something went wrong."); }
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Wrong input."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        /// <summary>
        /// Method for adding a category for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void AddCategory(int adminId)
        {
            Console.Write("\nEnter category name you want to add: ");
            string categoryName = Console.ReadLine();
            if (categoryName.Length != 0)
            {
                try
                {
                    if (api.AddCategory(adminId, categoryName))
                    {
                        Console.WriteLine($"Success! {categoryName} was added as a new category");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("No input."); }
        }

        /// <summary>
        /// Method for deleting a category for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void DeleteCategory(int adminId)
        {
            Console.Write("\nEnter category Id you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                if (categoryId > 0)
                {
                    try
                    {
                        foreach (var category in api.GetCategories().Where(c => c.Id == categoryId))
                        {
                            if (api.DeleteCategory(adminId, categoryId))
                            {
                                Console.WriteLine($"Success! {category.Id}. {category.Name} was deleted!");
                            }
                            else { Console.WriteLine("Something went wrong."); }
                        }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        /// <summary>
        /// Method for checking books in a category for customer user.
        /// </summary>
        /// <param name="userId"></param>
        private void GetBooksInCategory(int userId)
        {
            Console.Write("\nEnter category Id you want to show books from: ");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                if (categoryId > 0)
                {
                    try
                    {
                        foreach (var book in api.GetBooksInCategory(categoryId))
                        {
                            Console.WriteLine($"{book.Id}. {book.Title}");
                        }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        /// <summary>
        /// Method to list categories for both admin and customer user.
        /// </summary>
        /// <param name="userId"></param>
        private void GetCategories(int userId)
        {
            try
            {
                Console.WriteLine($"{"Id:",-4}{"Category:",-20}\n");
                foreach (var category in api.GetCategories())
                {
                    Console.WriteLine($"{category.Id + ".",-4}{category.Name,-20}");
                }
            }
            catch { Console.WriteLine("Something went wrong."); }
        }

        /// <summary>
        /// Method for searching a categoryname for customer user.
        /// </summary>
        /// <param name="userId"></param>
        private void SearchCategory(int userId)
        {
            Console.Write("\nEnter category name you want to search for: ");
            string categoryName = Console.ReadLine();
            if (categoryName.Length != 0)
            {
                try
                {
                    foreach (var category in api.GetCategories(categoryName))
                    {
                        Console.WriteLine($"{category.Id}. {category.Name}");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("No input."); }
        }

        /// <summary>
        /// Method for updating a existing category for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void UpdateCategory(int adminId)
        {
            Console.Write("\nEnter category Id you want to update: ");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                if (api.GetCategories().Where(c => c.Id == categoryId) != null)
                {
                    Console.Write("Enter new categoryname: ");
                    string categoryName = Console.ReadLine();
                    if (categoryName.Length != 0)
                    {
                        if (api.UpdateCategory(adminId, categoryId, categoryName))
                        {
                            Console.WriteLine($"Success! The categoryname was updated to {categoryName}");
                        }
                        else { Console.WriteLine("Something went wrong and the categoryname was not updated."); }
                    }
                    else { Console.WriteLine("No input."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }
    }
}