using AssignmentThree.Views;
using System;

namespace AssignmentThree.Controllers
{
    public static class AdminController
    {
        private static void AddBook()
        {
            BookView.PrintMatchingBooks();
            BookView.PrintBookInfo();

            var (bookId, bookTitle, bookAuthor, bookPrice, bookAmount) = AdminView.PrintAddBook();

            var result = Program.API.AddBook(Program.User.Id, bookId, bookTitle, bookAuthor, bookPrice, bookAmount);

            AdminView.PrintResult(result);
        }

        private static void AddBookToCategory()
        {
            CategoryView.PrintCategories();
            BookView.PrintBooksInCategory();

            var (bookId, categoryId) = AdminView.PrintAddBookToCategory();

            var result = Program.API.AddBookToCategory(Program.User.Id, bookId, categoryId);

            AdminView.PrintResult(result);
        }

        private static void AddCategory()
        {
            AdminView.PrintAddCategory();
            var newCategory = Console.ReadLine();

            var result = Program.API.AddCategory(Program.User.Id, newCategory);

            AdminView.PrintResult(result);
        }

        private static void AddUser()
        {
            var (username, password) = AdminView.PrintAddUser();

            var result = Program.API.AddUser(Program.User.Id, username, password);

            AdminView.PrintResult(result);
        }

        public static void AdminMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                if (Program.User.Id == 1)
                {
                    AdminView.PrintAdminMenu();
                    int.TryParse(Console.ReadLine(), out var userInput);

                    switch (userInput)
                    {
                        case 1:
                            AddBook();
                            break;

                        case 2:
                            SetAmount();
                            break;

                        case 3:
                            AdminView.PrintListUsers();
                            break;

                        case 4:
                            AdminView.PrintFindUser();
                            break;

                        case 5:
                            UpdateBook();
                            break;

                        case 6:
                            DeleteBook();
                            break;

                        case 7:
                            AddCategory();
                            break;

                        case 8:
                            AddBookToCategory();
                            break;

                        case 9:
                            UpdateCategory();
                            break;

                        case 10:
                            DeleteCategory();
                            break;

                        case 11:
                            AddUser();
                            break;

                        case 0:
                            keepRunning = false;
                            break;

                        default:
                            AdminView.PrintInvalidInput();
                            break;
                    }
                }
                else
                {
                    AdminView.PrintAdminMenuError();
                    keepRunning = false;
                }
            }
        }

        private static void DeleteBook()
        {
            BookView.PrintMatchingBooks();
            AdminView.PrintDeleteBook();
            int.TryParse(Console.ReadLine(), out var bookId);

            var result = Program.API.DeleteBook(Program.User.Id, bookId);

            AdminView.PrintResult(result);
        }

        private static void DeleteCategory()
        {
            CategoryView.PrintCategories();
            AdminView.PrintDeleteCategory();
            int.TryParse(Console.ReadLine(), out var categoryId);

            var result = Program.API.DeleteCategory(Program.User.Id, categoryId);

            AdminView.PrintResult(result);
        }

        private static void SetAmount()
        {
            BookView.PrintMatchingBooks();

            var (bookId, bookAmount) = AdminView.PrintSetAmount();

            Program.API.SetAmount(Program.User.Id, bookId, bookAmount);
        }

        private static void UpdateBook()
        {
            BookView.PrintMatchingBooks();
            BookView.PrintBookInfo();

            var (bookId, bookTitle, bookAuthor, bookPrice) = AdminView.PrintUpdateBook();

            var result = Program.API.UpdateBook(Program.User.Id, bookId, bookTitle, bookAuthor, bookPrice);

            AdminView.PrintResult(result);
        }

        private static void UpdateCategory()
        {
            CategoryView.PrintCategories();

            var (categoryId, categoryName) = AdminView.PrintUpdateCategory();

            var result = Program.API.UpdateCategory(Program.User.Id, categoryId, categoryName);

            AdminView.PrintResult(result);
        }
    }
}