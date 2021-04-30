using System;
using System.Collections.Generic;
using System.Text;
using MyFirstEntityframProject.Database;


namespace Inlämning_3_WebbShop.Views
{
    public class UserView
    {
        public int LogIn(int userId)
        {
            if (userId != 0)
            {
                Console.WriteLine("You have successfully logged int.");
                return userId;
            }
            else
            {
                Console.WriteLine($"Error: cannot log in. Please, register first and try to log in again again!");
                return 0;
            }
        }

        public string GetCategories(List<Category> category)
        {
            if (category != null)
            {
                foreach (var item in category)
                {
                    Console.WriteLine($"{item.Describe()}");
                }
            }
            return null;
        }
        public string GetAvailableBooks(List<Book> books)
        {
            if (books != null)
            {
                foreach (var item in books)
                {
                    Console.WriteLine($"{item.Describe()}");
                }
            }
            return null;
        }
        public string GetAuthors(List<Book> books)
        {
            if (books != null)
            {
                foreach (var item in books)
                {
                    Console.WriteLine($"{item.Title} by {item.Author}");
                }
            }

            return null;
        }
        public string BuyBook(bool soldBook)
        {
            if (soldBook == true)
            {
                string message = "Your purchase have successfully been registered. Thank you!";
                Console.WriteLine(message);
                return message;
            }
            else
            {
                return null;
            }
        }
        public string Ping(string ping)
        {
            if (ping == "Pong")
            {
                string message = "Pong";
                Console.WriteLine(message);
                return message;
            }
            else
            {
                return null;
            }
        }

        public void Register(bool registeredUser)
        {
            if (registeredUser == true)
            {          
                Console.WriteLine("Username was registered in the webshop.");                
            }
            else
            {
                Console.WriteLine("Error. Please check if you entered a correct password second time.");
            }

        }

    }
}
