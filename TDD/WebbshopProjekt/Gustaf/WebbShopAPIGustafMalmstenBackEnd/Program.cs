using Org.BouncyCastle.Math.EC.Multiplier;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WebbShopAPIGustafMalmsten
{
    class Program
    {
        internal API API
        {
            get => default;
            set
            {
            }
        }

        static void Main()
        {
            // Create the API
            API api = new();

            #region Test Example 1
            Console.WriteLine("User ID: " + api.Login("TestCustomer", "Codic2021"));
            api.GetCategories().ForEach(x => Console.WriteLine(x));

            api.GetCategory(0).ForEach(x => Console.WriteLine(x));

            var drSleep = api.GetBook("Doctor Sleep");
            Console.WriteLine("BookID: {0}", drSleep[0]);
            Console.WriteLine("Title: {0}", drSleep[1]);
            Console.WriteLine("Author: {0}", drSleep[2]);
            Console.WriteLine("Price: {0}", drSleep[3]);
            Console.WriteLine("Amount: {0}", drSleep[4]);
            api.Login("TestCustomer", "Codic2021");
            Console.WriteLine(api.BuyBook(2, 3));

            api.GetAvaialableBooks(0).ForEach(x => Console.WriteLine(x));

            #endregion

            #region Test Example 2
            int adminNumber = api.Login("Administrator", "CodicRulez");
            api.AddCategory(adminNumber, "Student Litterature");

            api.AddBookToCategory(adminNumber, 1, 5);
            foreach (Model.Book item in api.GetAvaialableBooks(5))
            {
                Console.WriteLine("Book in category Student Litterature: " + item.Title);
            }
            api.Logout(adminNumber);
            #endregion

            #region Test Example 3
            adminNumber = api.Login("Administrator", "CodicRulez");
            api.AddUser(adminNumber, "Gurra", "Burra");
            api.FindUsers(adminNumber, "Gurra").ForEach(x => Console.WriteLine(x.Name));
            #endregion

            #region Test all api methods
            Console.WriteLine("Testing all remaining API-methods\n\n");
            Console.WriteLine("Attempting to login Gurra: " + api.Login("Gurra", "Burra"));
            Console.WriteLine("Pinging user number 3: " + api.Ping(3));
            Console.WriteLine("Getting Categories containing the words \"fic\": ");
            api.GetCategories("fic").ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Get information about book with id = 2: ");
            Console.WriteLine("Get all books containg a whitespace ' '");
            api.GetBook(" ").ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            api.GetBooks(" ").ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Get all the books with an author with name \"Stephen\"");
            api.GetAuthors("Stephen").ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Userid 3 tries to buy book with id number 2: " + api.BuyBook(3, 2));
            Console.WriteLine("Add book to category 4: " + api.AddBookToCategory(adminNumber, 5, 4));
            api.SetAmount(adminNumber, 5, 10);
            Console.WriteLine("List all users");
            api.ListUsers(adminNumber).ForEach(x => { Console.WriteLine(x.Name); Console.WriteLine(x.IsActive); });
            api.FindUsers(adminNumber, "Gur");
            api.UpdateBook(adminNumber, 5, "Pelle Svanslös på nya äventyr", "Gösta Knutsson", 12.49);
            api.AddCategory(adminNumber, "Barnböcker");
            api.AddBookToCategory(adminNumber, 5, 5);
            api.UpdateCategory(adminNumber, 5, "Bra böcker");
            api.AddCategory(adminNumber, "Böcker om Java-programmering");
            api.DeleteCategory(adminNumber, 7);

            #endregion
            #region Test VG-functions
            Console.WriteLine("Money earned: " + api.MoneyEarned(adminNumber));
            Console.WriteLine("Best customer: " + api.BestCustomer(adminNumber).Name);
            Console.WriteLine("Trying to promote user Gurra: " + api.Promote(1, 3));
            Console.WriteLine("Trying to login user Gurra: " + api.Login("Gurra", "Burra"));
            Console.WriteLine("Trying to demote user Administrator: " + api.Demote(3, 1));
            Console.WriteLine("Trying to activate user TestCustomer: " + api.ActivateUser(3, 2));
            Console.WriteLine("Trying to deactivate user TestCustomer: " + api.InactivateUser(3, 2));
            Console.WriteLine("Promoting Administrator: " + api.Promote(3, 1));
            Console.WriteLine("Demoting Gurra (he made lots of trouble anyway): " + api.Demote(1, 3));

            #endregion
        }
    }
}
