using System;
using System.Collections.Generic;
using WebbShopAPI.Models;

namespace Bokhandel.View
{
    internal class AdminView
    {
        /// <summary>
        /// Show meny for administration
        /// </summary>
        /// <param name="adminId"></param>
        public static void AdminMenu()
        {
            Console.WriteLine("[1] Add book");
            Console.WriteLine("[2] Set amount");
            Console.WriteLine("[3] List users");
            Console.WriteLine("[4] Find user");
            Console.WriteLine("[5] Update book");
            Console.WriteLine("[6] Delete book");
            Console.WriteLine("[7] Add category");
            Console.WriteLine("[8] Add book to category");
            Console.WriteLine("[9] Update category");
            Console.WriteLine("[10] Delete category");
            Console.WriteLine("[11] Add user");
            Console.WriteLine("[x] Go to start");
            Console.WriteLine();
        }

        /// <summary>
        /// Show list of users
        /// </summary>
        /// <param name="users"></param>
        public static void ShowUsers(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }

        /// <summary>
        /// Show choice for updating book
        /// </summary>
        /// <param name="book"></param>
        public static void UpdateBookChoice(Book book)
        {
            Console.WriteLine($"[1] Title: {book.Title}");
            Console.WriteLine($"[2] Author: {book.Author}");
            Console.WriteLine($"[3] Price: {book.Price}");
        }

        /// <summary>
        /// Show fault message in administration
        /// </summary>
        public void AdminFail()
        {
            Console.WriteLine("Are you sure that you are admin?");
            UserFail();
        }

        /// <summary>
        /// Asking what to update
        /// </summary>
        public static void ChooseUpdate() { Console.WriteLine("Enter number for your update"); }

        /// <summary>
        /// Confirm login
        /// </summary>
        public void CouldLogin() => Console.WriteLine("You are logged in");

        /// <summary>
        /// Ask for amount
        /// </summary>
        public void EnterAmount() { Console.WriteLine("Enter amount:"); }

        /// <summary>
        /// Ask for author
        /// </summary>
        public void EnterAuthor() { Console.WriteLine("Enter author:"); }

        /// <summary>
        /// Ask for book Id
        /// </summary>
        public void EnterBookId() { Console.WriteLine("Enter book id:"); }

        /// <summary>
        /// Ask for new category
        /// </summary>
        public void EnterCategory() { Console.WriteLine("Enter new category:"); }

        /// <summary>
        /// Ask for category id
        /// </summary>
        public void EnterCategoryId() { Console.WriteLine("Enter category id:"); }

        /// <summary>
        /// Ask for password
        /// </summary>
        public void EnterPassword() { Console.WriteLine("Enter password:"); }

        /// <summary>
        /// Ask for price
        /// </summary>
        public void EnterPrice() { Console.WriteLine("Enter price:"); }

        /// <summary>
        /// Ask for title
        /// </summary>
        public void EnterTitle() { Console.WriteLine("Enter title:"); }

        /// <summary>
        /// Ask for username
        /// </summary>
        public void EnterUsername() { Console.WriteLine("Enter username:"); }

        /// <summary>
        /// Show fault message
        /// </summary>
        public void Fail() { Console.WriteLine("Something went wrong"); }

        /// <summary>
        /// Give fault message when trying to delete category
        /// </summary>
        public void FailDeleteCategory() { Console.WriteLine("Are you sure the category is empty?"); }

        /// <summary>
        /// Ask for search word
        /// </summary>
        public void FindUser() { Console.WriteLine("Enter word to search user:"); }

        /// <summary>
        /// Ask for book amount
        /// </summary>
        /// <param name="books"></param>
        public void NrOfBooks(int books) { Console.WriteLine($"Book amount: {books}"); }

        /// <summary>
        /// Show message where everything was ok
        /// </summary>
        public void Sucess() { Console.WriteLine("Everything went well"); }

        /// <summary>
        /// Show fault message for everything where you need to be logged in
        /// </summary>
        public void UserFail()
        {
            Fail();
            Console.WriteLine("Are you logged in? \nYou have to login again if you are inactive 15 minutes");
        }
    }
}