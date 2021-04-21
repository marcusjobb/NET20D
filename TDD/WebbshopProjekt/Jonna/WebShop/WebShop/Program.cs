using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebShop.Database;
using WebShop.Models;

namespace WebShop
{
    using static DatabaseSeeder;
    using static WebShopApi;
    using static Controllers.BookCategoryController;
    using static Controllers.BookController;
    public class Program

        
    {
        public static void Main(string[] args)
        {
            
            /*
            ----------------------------------------------------------------------------------
             ____                      _ 
            / ___|    ___    ___    __| |
            \___ \   / _ \  / _ \  / _` |
             ___) | |  __/ |  __/ | (_| |
            |____/   \___|  \___|  \__,_|

             ____            _             _                          
            |  _ \    __ _  | |_    __ _  | |__     __ _   ___    ___ 
            | | | |  / _` | | __|  / _` | | '_ \   / _` | / __|  / _ \
            | |_| | | (_| | | |_  | (_| | | |_) | | (_| | \__ \ |  __/
            |____/   \__,_|  \__|  \__,_| |_.__/   \__,_| |___/  \___|
            ----------------------------------------------------------------------------------
                                                                          
            */
            //Step 1. Run database seeder to fill database with categories, books and users
            //RUN ME FIRST TO SEED THE DATABASE
            //DatabaseSeeder.SeedDatabase();

            /*
            ----------------------------------------------------------------------------------
             _   _                     
            | | | |  ___    ___   _ __ 
            | | | | / __|  / _ \ | '__|
            | |_| | \__ \ |  __/ | |   
             \___/  |___/  \___| |_|   
            ----------------------------------------------------------------------------------

            */

            //Login - Username , password
            //Login("Administrator", "CodicRulez");

            //Logout - UserId
            //Logout(1);

            //GetCategories - UserId(To get ping)
            //var test = GetCategories(1);
            //foreach (var cat in test)
            //{
            //    Console.WriteLine(cat.Name);
            //}

            //GetCategories - UserId(to get ping), Keyword for category search
            //var test = GetCategories(1, "ror");
            //foreach (var cat in test)
            //{
            //    Console.WriteLine(cat.Name);
            //}

            //GetCategory - UserId(to get ping), CategoryId
            //GetCategory(1, 1);

            //GetAvailableBooks - UserId(To get ping), categoryId
            //GetAvailableBooks(1,1);

            //GetBook - UserId(To get ping), bookId
            //GetBook(1, 1);

            //GetBooks - userId(To get ping), search keyword
            //var test = GetBooks(1, "bot");
            //foreach (var book in test)
            //{
            //    Console.WriteLine(book.Title);
            //}

            //GetAuthors - userId(to get ping), author search keyword
            //var test = GetAuthors(1, "Stephen");
            //foreach (var book in test)
            //{
            //    Console.WriteLine(book.Title);
            //}

            //BuyBook Method - Userid, BookId
            //BuyBook(1, 1);

            //Ping - userId, to update SessionTimer if you have been active for last 15 minutes
            //Ping(1);

            //Register - Name, Password, Password verify
            //Password must match to get registered
            //Register("Name", "Password", "Password");

            /*
            ----------------------------------------------------------------------------------
                 _          _               _         
                / \      __| |  _ __ ___   (_)  _ __  
               / _ \    / _` | | '_ ` _ \  | | | '_ \ 
              / ___ \  | (_| | | | | | | | | | | | | |
             /_/   \_\  \__,_| |_| |_| |_| |_| |_| |_|
            ----------------------------------------------------------------------------------                           
             */

            //AddBook - Admin id, Book title, Book author, price, ammount
            //AddBook(1, "Title", "Author", 250, 5);

            //SetAmount - Admin id, Book id, Amount of books to add
            //SetAmount(1, 1, 5);

            //ListUsers - Admin id 
            //var test = ListUsers(1);
            //foreach (var user in test)
            //{
            //    Console.WriteLine(user.Name);
            //}

            //FindUser - Admin id, Username search keyword
            //var test = FindUser(1, "admin");
            //foreach (var user in test)
            //{
            //    Console.WriteLine(user.Name);
            //}

            //UpdateBook - Admin id, BookId, Book Title, Author, Price
            //UpdateBook(1, 1, "Book Title", "Book Author", 200);

            //DeleteBook - AdminId, BookId
            //DeleteBook(1, 1);

            //AddCategory - AdminId, Category name
            //AddCategory(1, "My new category name");

            //AddBookToCategory - Admin Id, Book id, Category id
            //AddBookToCategory(1, 1, 1);

            //UpdateCategory - Admin id, Category id, Name 
            //UpdateCategory(1, 1, "Updated category name");

            //DeleteCategory - Admin id, Category id 
            //DeleteCategory(1,1);

            //AddUser - AdminId, Username, password
            //AddUser(1,"MyUserName","MyPassword");

            /*
            ----------------------------------------------------------------------------------   
            _____               _ 
            | ____|  _ __     __| |
            |  _|   | '_ \   / _` |
            | |___  | | | | | (_| |
            |_____| |_| |_|  \__,_|
            ----------------------------------------------------------------------------------   
                        
            */

        }
    }
}