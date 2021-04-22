using MyBackend;
using System;

namespace FrontEndWebShop.Controllers.AdminControllers
{
    class AdminMenuController
    {
        public static void AdminMenu()
        {
            switch (Program.choise)
            {
                case "1":
                    {
                        Console.Write("Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Price: ");
                        int price = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount: ");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.AddBook(Program.userId, title, author, price, amount);
                        break;
                    }
                case "2":
                    {
                        View.AdminMenu.ShowBooks();
                        Console.Write("Choise the book (id): ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the actual amount: ");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.SetAmount(bookId, Program.userId, amount);
                        break;
                    }
                case "3":
                    {
                        var users = WebbShopAPI.ListUsers(Program.userId);
                        Console.WriteLine("");
                        Console.WriteLine("===========================");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"ID: {user.Id}. Username: {user.Name}");
                        }
                        Console.WriteLine("===========================");
                        Console.WriteLine("");
                        Console.WriteLine("[Press any key to continue]");
                        Console.ReadKey();
                        break;
                    }
                case "4":
                    {
                        Console.Write("Search: ");
                        string keyword = Console.ReadLine();
                        var users = WebbShopAPI.FindUser(Program.userId, keyword);
                        foreach (var user in users)
                        {
                            Console.WriteLine($"{user.Id}. {user.Name}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("[Press any key to continue]");
                        Console.ReadKey();
                        break;
                    }
                case "5":
                    {
                        View.AdminMenu.ShowBooks();
                        Console.Write("Choise the book (id): ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("New title: ");
                        string title = Console.ReadLine();
                        Console.Write("New author: ");
                        string author = Console.ReadLine();
                        Console.Write("New price: ");
                        int price = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.UpdateBook(Program.userId, bookId, title, author, price);
                        Console.WriteLine("");
                        Console.WriteLine("Success");
                        Console.WriteLine("[Press any key to continue]");
                        Console.ReadKey();
                        break;
                    }
                case "6":
                    {
                        View.AdminMenu.ShowBooks();
                        Console.Write("Enter book id to delete: ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.DeleteBook(Program.userId, bookId);
                        break;
                    }
                case "7":
                    {
                        Console.Write("New category name: ");
                        string catName = Console.ReadLine();
                        WebbShopAPI.AddCategory(Program.userId, catName);
                        break;
                    }
                case "8":
                    {
                        View.AdminMenu.ShowBooks();
                        Console.Write("Choise a book (id): ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        View.AdminMenu.ShowCategories();
                        Console.Write("Choise a category to add a book: ");
                        int catId = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.AddBookToCategory(Program.userId, bookId, catId);
                        break;
                    }
                case "9":
                    {
                        View.AdminMenu.ShowCategories();
                        Console.Write("Choise a category: ");
                        int catId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("New name: ");
                        string name = Console.ReadLine();
                        WebbShopAPI.UpdateCategory(Program.userId, catId, name);
                        break;
                    }
                case "10":
                    {
                        View.AdminMenu.ShowCategories();
                        Console.Write("Choise a category: ");
                        int catId = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.DeleteCategory(Program.userId, catId);
                        break;
                    }
                case "11":
                    {
                        Console.Write("New username: ");
                        string name = Console.ReadLine();
                        Console.Write("New password: ");
                        string password = Console.ReadLine();
                        WebbShopAPI.AddUser(Program.userId, name, password);
                        break;
                    }
                case "12":
                    {
                        var users = WebbShopAPI.ListUsers(Program.userId);
                        Console.WriteLine("");
                        Console.WriteLine("===========================");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"ID: {user.Id}. Username: {user.Name}");
                        }
                        Console.WriteLine("===========================");
                        Console.Write("Choise a user to promote: ");
                        int u = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.Promote(Program.userId, u);
                        break;

                    }
                case "13":
                    {
                        var users = WebbShopAPI.ListUsers(Program.userId);
                        Console.WriteLine("");
                        Console.WriteLine("===========================");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"ID: {user.Id}. Username: {user.Name}");
                        }
                        Console.WriteLine("===========================");
                        Console.WriteLine("Choise a user to demote: ");
                        int u = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.Demote(Program.userId, u);
                        break;
                    }
                case "14":
                    {
                        var users = WebbShopAPI.ListUsers(Program.userId);
                        Console.WriteLine("");
                        Console.WriteLine("===========================");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"ID: {user.Id}. Username: {user.Name}");
                        }
                        Console.WriteLine("===========================");
                        Console.WriteLine("Choise a user to activate: ");
                        int u = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.ActivateUser(Program.userId, u);
                        break;
                    }
                case "15":
                    {
                        var users = WebbShopAPI.ListUsers(Program.userId);
                        Console.WriteLine("");
                        Console.WriteLine("===========================");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"ID: {user.Id}. Username: {user.Name}");
                        }
                        Console.WriteLine("===========================");
                        Console.WriteLine("Choise a user to inactivate: ");
                        int u = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.InactivateUser(Program.userId, u);
                        break;
                    }
            }
        }
    }
}
