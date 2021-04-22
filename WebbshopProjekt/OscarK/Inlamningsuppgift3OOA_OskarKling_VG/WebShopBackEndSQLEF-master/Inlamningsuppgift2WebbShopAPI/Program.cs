using System;
using System.Collections.Generic;
using Inlamningsuppgift2WebbShopAPI.Database;
using Inlamningsuppgift2WebbShopAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Inlamningsuppgift2WebbShopAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the web backend simulation");

            WebbShopAPI webapi = new WebbShopAPI();

            Seeder.SeedDatabase();

            //Login
            //int? loggedInUserId = webapi.Login("Oskar", "Steven");

            //Logout
            //webapi.Logout(4);

            //Get All Categories
            //var list = webapi.GetCategories();
            //foreach (BookCategory s in list)
            //{
            //    Console.WriteLine(s.Category);
            //}

            //Get specific category by keyword
            //var list = webapi.GetCategories("Romance");
            //foreach (BookCategory c in list)
            //{
            //    Console.WriteLine($"ID: {c.Id} - Category: {c.Category}");
            //}

            //Get books by category Id
            //var list = webapi.GetCategory(1);
            //foreach (Book b in list)
            //{
            //    Console.WriteLine(b.Title);
            //}

            //Get all avaible books where amount > 0 by category id
            //var list = webapi.GetAvailableBooks(1);
            //foreach (Book b in list)
            //{
            //    Console.WriteLine(b.Title);
            //}

            //Gets a book. containing book information.
            //var book = webapi.GetBook(3);
            //Console.WriteLine($@"
            //Title:{book.Title}
            //Author: {book.Author}
            //Price: {book.Price}
            //Amount in stock: {book.Amount}
            //Category: {book.Category.Category}");

            //Gets a list of books by keyword search for author or title of the book
            //var list = webapi.GetBooks("");
            //Console.WriteLine("Nr of books: " + list.Count);
            //foreach (Book b in list)
            //{
            //    Console.WriteLine($@"
            //    Title: {b.Title}
            //    Author: {b.Author}
            //    Price: {b.Price}
            //    Amount in stock: {b.Amount}
            //    Category: {b.Category.Category}
            //    ");
            //}

            //Gets a list of books by Author. I think Method should be named GetBooksByAuthor. But I follow the guidelines in the assignment.
            //var list = webapi.GetAuthors("Stephen King");
            //foreach(Book b in list)
            //{
            //    Console.WriteLine($@"
            //    Title: {b.Title}
            //    Author: {b.Author}
            //    Price: {b.Price}
            //    Amount in stock: {b.Amount}
            //    Category: {b.Category.Category}
            //    ");
            //}

            //Buys a book
            //bool answer = webapi.BuyBook(4, 7);
            //Console.WriteLine(answer);

            //Register a new user
            //bool IsRegisterSuccess = webapi.Register("Oskar", "Steven", "Steven");
            //Console.WriteLine(IsRegisterSuccess);

            //Add a Book
            //bool bookAddedSuccess = webapi.AddBook(2, "The adventures of a coder", "Oskar Kling", 300, 50);
            //Console.WriteLine(bookAddedSuccess);

            //Set amount on a book
            //bool setAmountSucessful = webapi.SetAmount(2, 6, 2);
            //Console.WriteLine(setAmountSucessful);

            //Get list of users
            //var list = webapi.ListUsers(2);
            //Console.WriteLine($"Nr of users: {list.Count}");
            //foreach(User u in list)
            //{
            //    Console.WriteLine($@"Name: {u.Name}");
            //}

            //Find User with matching keyword
            //var list = webapi.FindUser(2, "Osk");
            //foreach(User u in list)
            //{
            //    Console.WriteLine(u.Name);
            //}

            //Update a book
            //bool updateSuccessful = webapi.UpdateBook(2, 5, "Undaventure Yourself", "Oskar King", 499);
            //Console.WriteLine(updateSuccessful);

            //Delete a book
            //bool deleteABookSucessfull = webapi.DeleteBook(2, 6);
            //Console.WriteLine(deleteABookSucessfull);

            //Add a category
            //bool addedCatSucessfull = webapi.AddCategory(2, "Ostakatekorin");
            //Console.WriteLine(addedCatSucessfull);

            //Add book to category
            //bool addBookCatSuccessful = webapi.AddBookToCategory(2, 7, 5);
            //Console.WriteLine(addBookCatSuccessful);

            //Update a category
            //bool categoryUpdateSucess = webapi.UpdateCategory(2, 5, "Dramatized");
            //Console.WriteLine(categoryUpdateSucess);

            //Deletes a category
            //bool catDelSuccess = webapi.DeleteCategory(2, 6);
            //Console.WriteLine(catDelSuccess);

            //Add User from admin
            //bool addUsrSuccess = webapi.AddUser(2, "MR Bean", "");
            //Console.WriteLine(addUsrSuccess);

            // VG

            //Get List of sold books
            //var list = webapi.SoldItems(2);
            //foreach (SoldBook s in list)
            //{
            //    Console.WriteLine(s.Title);
            //}

            //Get Money earned
            //Console.WriteLine("money earned: " + webapi.MoneyEarned(2));

            // Gets the best customer in form of a user object
            //User bestcust = webapi.BestCustomer(2);
            //Console.WriteLine(bestcust.Name);

            //Promote user to admin
            //bool didUserGetAdmin = webapi.Promote(2, 4);
            //Console.WriteLine(didUserGetAdmin);

            //Demotes a user from admin position
            //bool didUserGetDemoted = webapi.Demote(2, 4);
            //Console.WriteLine(didUserGetDemoted);

            //webapi.RunWebApi();
            //var list = webapi.ListUserss(2);
            //Console.WriteLine($"Nr of users: {list.Count}");
            //foreach (User u in list)
            //{
            //    Console.WriteLine($@"Name: {u.Name}");
            //}

            //Testing Ping with Timer library
            Console.WriteLine("waiting 10 sec");
            Task.Delay(10000).Wait();
            //Console.WriteLine(webapi.ActivateUser(2, 6));
            Task.Delay(10000).Wait();
            Console.WriteLine("end");


        }
    }
}
