namespace WebbShop_MikaelLarsson.Views.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Inlamn2WebbShop_MLarsson.Models;
    using WebbShop_MikaelLarsson.Controllers;

    /// <summary>
    /// Klass för att skriva ut user-relaterat text från adminmenyn
    /// </summary>
    internal static class AdminUserView
    {
        /// <summary>
        /// Visar information om en användare.
        /// </summary>
        /// <param name="user"></param>
        public static void ListUser(User user)
        {
            if (user != null)
            {
                Console.WriteLine("\nUSER: ");
                try
                {
                    Console.WriteLine($"ID: {user.Id} - {user.Name}");
                    if (user.SoldBooks != null)
                    {
                        Console.Write("Books bought: ");
                        foreach (var soldBook in user.SoldBooks.OrderBy(o => o.Title))
                        {
                            Console.Write($"{soldBook.Title}, ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception)
                {
                    MessageView.SomethingWentWrong();
                }
            }
            else
            {
                MessageView.Error();
            }
        }

        /// <summary>
        /// Listar alla användare i en användarlista, inklusive admin.
        /// </summary>
        /// <param name="userList"></param>
        public static void ListUsers(List<User> userList)
        {
            Console.WriteLine();
            try
            {
                if (userList != null)
                {
                    foreach (var user in userList.OrderBy(o => o.Id))
                    {
                        Console.WriteLine("USER: ");
                        Console.WriteLine(user);
                        if (user.SoldBooks != null)
                        {
                            Console.Write("Books bought: ");
                            foreach (var soldBook in user.SoldBooks.OrderBy(o => o.Title))
                            {
                                Console.WriteLine($"{soldBook.Title}, ");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                if(userList==null || userList.Count==0)
                {
                    MessageView.Error();
                }
            }
            catch (Exception)
            {
                MessageView.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Input för att lägga till ny person
        /// </summary>
        /// <returns>string tuples</returns>
        internal static (string, string) AddUser()
        {
            Console.WriteLine("\nADD NEW PERSON");
            Console.Write("Enter new username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            return (username, password);
        }

        /// <summary>
        /// Text för att hitta användare.
        /// </summary>
        internal static void SearchUser()
        {
            Console.Write("Enter one or many letters to find a matching username:  ");
        }

        /// <summary>
        /// text för att visa vad admin valt för handling.
        /// </summary>
        internal static int UserDoWhat(string doWhat)
        {
            Console.WriteLine($"\n{doWhat.ToUpper()} A USER");
            GetUserId();
            return ControlHelper.TryParseReadLine();
        }

        /// <summary>
        /// Text för att hämta userId
        /// </summary>
        private static void GetUserId()
        {
            Console.Write("Enter a user ID: ");
        }
    }
}
