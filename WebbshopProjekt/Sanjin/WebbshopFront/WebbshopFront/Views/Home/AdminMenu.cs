using System;
using System.Collections.Generic;
using System.Text;
using WebbshopFront.Controllers;
using InlamningDB2;
using WebbshopFront.Helpers;
namespace WebbshopFront.Views.Home
{
   class AdminMenu
    {
        public void AdminStuff(int userId)
        {
            var api = new WebbShopAPI();
            api.Ping(userId);
            var adminController = new AdminController();
            Helpers.WelcomLogs.AdminStartLog();
            Console.ResetColor();
            Console.WriteLine("1. Lägg till en bok");
            Console.WriteLine("2. Ändra antal böcker");
            Console.WriteLine("3. Skriv ut andvändare");
            Console.WriteLine("4. Sök efter en andvändare");
            Console.WriteLine("5. Updatera en bok");
            Console.WriteLine("6. Ta bort en bok");
            Console.WriteLine("7. Lägg till en ny kategori");
            Console.WriteLine("8. Lägg till kategori för bok");
            Console.WriteLine("9. Updatera en kategori");
            Console.WriteLine("10. Radera en kategori");
            Console.WriteLine("11. Lägg till en användare");
            Console.WriteLine("99. Exit");
            Int32.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    Helpers.WelcomLogs.AdminStartLog();
                    Console.SetCursorPosition(0, 6);
                    adminController.Addbook(userId);
                    break;
                case 2:
                    Console.SetCursorPosition(0, 6);
                    adminController.SetAmount(userId);
                    break;
                case 3:
                    Console.SetCursorPosition(0, 6);
                    adminController.ListUser(userId);
                    break;
                case 4:
                    Console.SetCursorPosition(0, 6);
                    adminController.FindUser(userId);
                    break;
                case 5:
                    Console.SetCursorPosition(0, 6);
                    adminController.Updatebook(userId);
                    break;
                case 6:
                    Console.SetCursorPosition(0, 6);
                    adminController.Deletebook(userId);
                    break;
                case 7:
                    Console.SetCursorPosition(0, 6);
                    adminController.AddCategory(userId);
                    break;
                case 8: 
                    Console.SetCursorPosition(0, 6);
                    adminController.AddBookToCategory(userId);
                    break;
                case 9:
                    Console.SetCursorPosition(0, 6);
                    adminController.UpdateCategory(userId);
                    break;
                case 10: 
                    Console.SetCursorPosition(0, 6);
                    adminController.DeleteCategory(userId);
                    break;
                case 11:
                    Console.SetCursorPosition(0, 6);
                    adminController.AddUser(userId);
                    break;
                case 99:
                    break;
                default:
                    break;
            }
        }
    }
}
