using LinusNestorson_WebbShop.Database;
using LinusNestorson_WebbShop.Helpers;
using LinusNestorson_WebbShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;

namespace LinusNestorson_WebbShop
{
    class Program
    {
        internal static void Main()
        {
            //var adminOptions = new AdminAPI();

            //Seeder.GenerateData();

            ////CASE 1:
            //Console.WriteLine("TEST OF NORMAL USER, PRESS [ENTER] TO GO TO NEXT METHOD");
            ////Test user logs in.
            //var userId = webbShop.Login("TestClient", "Codic2021");

            //if (userId != 0)
            //{
            //    Console.WriteLine("\nLogin succeeded");
            //}
            //else
            //{
            //    Console.WriteLine("\nLogin failed, could not find user.\nTry to run the program again with valid and active user");
            //    return;
            //}
            //Console.ReadLine();

            ////Test user looks for avaiable categories.
            //Console.WriteLine("Here are the available categories in this shop:\n");
            //foreach (var category in webbShop.GetCategories())
            //{
            //    Console.WriteLine(category.Name);
            //}

            //Console.WriteLine("\n" + webbShop.Ping(userId));
            //Console.ReadLine();
            ////Test user chose a specifik category. 
            //Console.WriteLine("Here are the books in you chosen category:\n");
            //foreach (var book in webbShop.GetCategory(1))
            //{
            //    Console.WriteLine(book.Title);
            //}
            //Console.WriteLine("\n" + webbShop.Ping(userId));
            //Console.ReadLine();
            ////Test user reads information about specific book.
            //Console.WriteLine("Info about chosen book:\n");

            //Console.WriteLine(webbShop.GetBook(3));
            //Console.WriteLine("\n" + webbShop.Ping(userId));
            //Console.ReadLine();
            ////Test user buys book.
            //bool successOrFail = webbShop.BuyBook(userId, 3);
            //if (successOrFail)
            //{
            //    Console.WriteLine("Chosen book bought!");
            //    Console.WriteLine("\n" + webbShop.Ping(userId));
            //}
            //else if (!successOrFail)
            //{
            //    Console.WriteLine("You failed to buy the book");
            //}

            //Console.ReadLine();
            ////Test user logs out.
            //webbShop.Logout(userId);

            ////CASE 2:
            //Console.WriteLine("TEST OF ADMIN USER, PRESS [ENTER] TO GO TO NEXT METHOD");
            ////Admin logs in, search for book and buys.
            //userId = webbShop.Login("Administrator", "CodicRulez");
            //if (userId != 0)
            //{
            //    Console.WriteLine("\nLogin succeeded");
            //}
            //else
            //{
            //    Console.WriteLine("\nLogin failed, could not find user.\nTry to run the program again with valid and active user");
            //    return;
            //}

            //Console.ReadLine();
            ////Admin adds book.
            //successOrFail = adminOptions.AddBook(userId, "Harry Potta", "JK Rullar", 100, 1);
            //if (successOrFail)
            //{
            //    Console.WriteLine("Book or amount of book added to database");
            //    Console.WriteLine("\n" + webbShop.Ping(userId));
            //}
            //else if (!successOrFail)
            //{
            //    Console.WriteLine("\nYou failed to add book");
            //    Console.WriteLine("\n" + webbShop.Ping(userId));
            //}
            //Console.ReadLine();
            ////Admin moves book to category.
            //successOrFail = adminOptions.AddBookToCategory(userId, 5, 3);
            //if (successOrFail)
            //{
            //    Console.WriteLine("Book was moved to new category");
            //    Console.WriteLine("\n" + webbShop.Ping(userId));
            //}
            //else if (!successOrFail)
            //{
            //    Console.WriteLine("Failed to move book to category");
            //    Console.WriteLine("\n" + webbShop.Ping(userId));
            //}
            //Console.ReadLine();
            ////Admin search database for how much money is earned.
            //var sum = adminOptions.MoneyEarned(userId);
            //Console.WriteLine($"You have earned {sum} kr");
            //Console.WriteLine("\n" + webbShop.Ping(userId));
            ////Admin logs out
            //webbShop.Logout(userId);
        }
    }
}
