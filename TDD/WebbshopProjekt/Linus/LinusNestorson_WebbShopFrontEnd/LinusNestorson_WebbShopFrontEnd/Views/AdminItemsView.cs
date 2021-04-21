using System;

namespace LinusNestorson_WebbShopFrontEnd.Views
{
    class AdminItemsView
    {

        /// <summary>
        /// Admin menu with alternatives for the items.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void AdminSecondMenu(int adminId)
        {
            Console.WriteLine("Welcome to Linus Bookstore");
            while (true)
            {
                Console.WriteLine("\nWhat do you want to do? Confirm your choice by pressing [Enter]");
                Console.WriteLine("1. Add book\n2. Set Amount\n3. Update book\n4. Delete Book\n5. Add category\n6. Add book to category");
                Console.Write("7. Update Category\n8. Delete Category\n9. Go back\n>");
                int choice;
                bool input = int.TryParse(Console.ReadLine(), out choice);
                if (input)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            AdminOptions.AddBook(adminId);
                            continue;
                        case 2:
                            Console.Clear();
                            AdminOptions.SetAmount(adminId);
                            continue;
                        case 3:
                            Console.Clear();
                            AdminOptions.UpdateBook(adminId);
                            continue;
                        case 4:
                            Console.Clear();
                            AdminOptions.DeleteBook(adminId);
                            continue;
                        case 5:
                            Console.Clear();
                            AdminOptions.AddCategory(adminId);
                            continue;
                        case 6:
                            Console.Clear();
                            AdminOptions.AddBookToCategory(adminId);
                            continue;
                        case 7:
                            Console.Clear();
                            AdminOptions.UpdateCategory(adminId);
                            continue;
                        case 8:
                            Console.Clear();
                            AdminOptions.DeleteCategory(adminId);
                            continue;
                        case 9:
                            Console.Clear();
                            break;


                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a valid number");
                            continue;
                    }
                    break;
                }
                else if (!input)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter valid input");
                }
            }
        }
    }
}