using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEnd.Helper
{
    public static class InputUser
    {

        internal static string GetCategories()
        {
            
            Console.WriteLine("please enter keyword");
            var keyword = Console.ReadLine();
            return keyword;
        }

        internal static int GetCategory()
        {
            Console.WriteLine("[GET CATEGORY]");
            Console.WriteLine("Please enter category ID");
            Console.Write(">");
            var strgenre = Console.ReadLine();
            try
            {
                int genre = Int32.Parse(strgenre);
                return genre;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strgenre}'");
                return 0;
            }

        }

        internal static int GetAvaliableBooks()
        {
            Console.WriteLine("[Get Avaliable Books]");
            Console.WriteLine("Please enter category/Genre ID");
            var strgenre = Console.ReadLine();
            try
            {
                int genre = Int32.Parse(strgenre);
                return genre;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strgenre}'");
                return 0;
            }

        }

        internal static int GetBook()
        {
            Console.WriteLine("[Get Book]");
            Console.WriteLine("Please enter Book-ID");
            var strBookId = Console.ReadLine();
            try
            {
                int id = Int32.Parse(strBookId);
                return id;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strBookId}'");
                return 0;
            }
        }

        internal static (int userId, int bookId) BuyBook()
        {
            Console.WriteLine("[Buy Book]");
            var userId = Models.User.UserId;
            Console.WriteLine("Enter book ID");
            var strBookId = Console.ReadLine();
            try
            {
                int id = Int32.Parse(strBookId);
                return (userId, id);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strBookId}'");
                return (userId, 0);
            }
        }
        //internal static (string title, string author, int price, int quantity) AddBookInput()
        //{
        //    Console.WriteLine("[ADD BOOK]");
        //    Console.WriteLine("Enter Title");
        //    Console.Write(">");
        //    var title = Console.ReadLine();

        //    Console.WriteLine("Enter Author Fullname");
        //    Console.Write(">");
        //    var author = Console.ReadLine();

        //    Console.WriteLine("Enter Price");
        //    Console.Write(">");
        //    var strPrice = Console.ReadLine();
        //    int price = 0;
        //    try
        //    {
        //        price = Int32.Parse(strPrice);
        //    }
        //    catch (FormatException)
        //    {
        //        Console.WriteLine($"Unable to parse '{strPrice}'");
        //    }

        //    Console.WriteLine("Enter Quantity");
        //    Console.Write(">");
        //    var strQuantity = Console.ReadLine();
        //    int quantity = 0;
        //    try
        //    {
        //        quantity = Int32.Parse(strQuantity);
        //    }
        //    catch (FormatException)
        //    {
        //        Console.WriteLine($"Unable to parse '{strQuantity}'");
        //    }
        //    return (title, author, price, quantity);
        //}
    }
}
