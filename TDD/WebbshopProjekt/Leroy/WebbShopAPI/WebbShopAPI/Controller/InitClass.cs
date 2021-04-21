using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Database;
using WebbShopAPI.Model;
using WebbShopAPI.Utils;


namespace WebbShopAPI.Controller
{
    static class InitClass
    {
        const string adminName = "Administrator";
        const string adminPassword = "CodicRulez";
        /// <summary>
        /// Initializes the Database and populates tables
        /// </summary>
        /// <returns></returns>
        public static bool StartInitializingDatabase()
        {
            //This initializes the Database and populates it
            Console.WriteLine("Starting Sequence");
            return StartSequence.InitializeDB();  
        }

        /// <summary>
        /// Runs All the API functions in a sweep
        /// </summary>
        /// <returns></returns>
        public static bool StartAPITest()

        {
            //Loggin in with admin
            var admin = WebbShopAPIClass.LogIn(adminName, adminPassword);
            //Retrieving admin obj
            using (var db = new WebbShopLeeContext())
            {
                try
                {
                    admin = db.Users.FirstOrDefault(_ => _.ID == admin.ID);
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            //Writing time om loging out (Right now this funktion does not work propperly)
            Console.WriteLine(WebbShopAPIClass.LogOut(admin));

            //Writing categories
            var categories = WebbShopAPIClass.GetCategories();
            foreach (BookCategory c in categories)
            {
                Console.WriteLine(c.Name);
            }

            Console.WriteLine("Getting category with keyword Sci");
            //Writing categories using a keyword
            categories = WebbShopAPIClass.GetCategories("Sci");
            foreach (BookCategory c in categories)
            {
                Console.WriteLine(c.Name);
            }

            Console.WriteLine("Getting books in the category Horror");
            //Get list of books in a ccategory
            try
            {
                var booksOne = WebbShopAPIClass.GetCategory(WebbShopAPIClass.GetCategories("Horror")[0]);

                foreach (Book b in booksOne)
                {
                    Console.WriteLine(b.Title);
                }
            }
            catch (Exception e)
            {
                e.ToString();
                Console.WriteLine("No book was found");
            }
            Console.WriteLine("Getting available books in the category Horror");
            //Get list of books in a ccategory
            try
            {
                var books = WebbShopAPIClass.GetAvailableBooks(WebbShopAPIClass.GetCategories("Horror")[0]);

                foreach (Book b in books)
                {
                    Console.WriteLine(b.Title);
                }
            }
            catch (Exception e)
            {
                string a = e.ToString();
                Console.WriteLine("No book was found");
            }

            Console.WriteLine("Getting information about the first book in the category horror");
            try
            {
                Console.WriteLine(PrintText.GetInformationAboutBook((WebbShopAPIClass.GetBook(WebbShopAPIClass.GetCategory(WebbShopAPIClass.GetCategories("Horror")[0])[0]))));
            }
            catch(Exception e)
            {
                string a = e.ToString();
                Console.WriteLine("No book was found");
            }

            var author = WebbShopAPIClass.GetAuthor("King");
            foreach (Book book in author)
            {
                Console.WriteLine(book.Title);
            }



            //This is where you buy the first book of the Horror category
            try
            {
                List<Book> availableBooks = new List<Book>();
                List<BookCategory> listOfCat = WebbShopAPIClass.GetCategories("Horror");
                if (listOfCat != null && listOfCat.Count > 0)
                availableBooks = WebbShopAPIClass.GetCategory(listOfCat[0]);
                if (availableBooks != null && availableBooks.Count > 0)
                if (WebbShopAPIClass.BuyBook(admin, availableBooks[0]))
                {
                    Console.WriteLine("Book was purchased");
                }
                else
                {
                    Console.WriteLine("Book was NOT purchased");
                }
            }
            catch (Exception e)
            {
                string a = e.ToString();
            }

            //Ping a user
            Console.WriteLine(WebbShopAPIClass.Ping(admin));

            //Create a new user
            
            Console.WriteLine("Create a new user.");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Verify your password: ");
            string verifyPassword = Console.ReadLine();

            if (WebbShopAPIClass.Register(name, password, verifyPassword))
            {
                Console.WriteLine($"User {name} was successfully created.");
                return true;
            }
            else
            {
                Console.WriteLine($"User {name} was NOT created.");
            }
            
            return false;
        }

        /// <summary>
        /// Runs the admin functions
        /// </summary>
        /// <returns></returns>
        public static bool StartAdminTest()
        {
            Console.WriteLine("Starting admin test");
            User admin = null;
            using (var db = new WebbShopLeeContext())
            {
                try
                {
                    Console.WriteLine("Getting admin...");
                    admin = db.Users.FirstOrDefault(_ => _.IsAdmin == true);
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            if (admin != null)
            {
                //Add new books or add more books to you shop
                var book = new Book { Title = "Harry Potter", Author = "J.K. Rowling", Price = 175, Amount = 1 };
                if (WebbShopAPIClass.AddBook(admin, WebbShopAPIClass.GetBook(book.Title), book.Title, "J.K. Rowling", 175, 5))
                {
                    {
                        Console.WriteLine($"The book {book.Title} was added to your shop.");
                    }
                }
                else
                {
                    Console.WriteLine("No book was added");
                }

                //Set amount
                book = WebbShopAPIClass.GetBook(book.Title);
                int newAmount = 5;
                if (WebbShopAPIClass.SetAmount(admin, book, newAmount))
                {
                    Console.WriteLine($"The new amount of {book.Title} is {newAmount}.");
                }
                else
                {
                    Console.WriteLine("No amount was changed.");
                }

                //Listing all Users
                var users = WebbShopAPIClass.ListUsers(admin);
                Console.WriteLine("Listing ALL users");
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }

                //Listing users based on a keyword
                string keyword = "lee";
                users = WebbShopAPIClass.FindUsers(admin, keyword);
                Console.WriteLine($"Listing users containing {keyword}");
                if (users.Count == 0 || users == null)
                    Console.WriteLine("No users found");
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }

                //Update a book
                Book book2 = new Book { Title = "Harry P", Author = "J.K.R.", Price = 50 };
                if (WebbShopAPIClass.UpdateBook(admin, book, book2.Title, book2.Author, book2.Price))
                {
                    Console.WriteLine($"The book was updated");
                }
                else
                {
                    Console.WriteLine("This book was not updated");
                }

                //Delete a book
                book = WebbShopAPIClass.GetBook(book2.Title);
                if (WebbShopAPIClass.DeleteBook(admin, WebbShopAPIClass.GetBook(book.Title)))
                {
                    Console.WriteLine($"The book {book.Title} is removed");
                }
                else
                {
                    Console.WriteLine("The book was not removed");
                }

                //Add a category
                string actionCategory = "Action";
                if (WebbShopAPIClass.AddCategory(admin, actionCategory))
                {
                    Console.WriteLine($"The category {actionCategory} was added");
                }
                else
                {
                    Console.WriteLine("This category was not added.");
                }

                //Add book too category
                try
                {
                    BookCategory u = WebbShopAPIClass.GetCategories(actionCategory)[0];
                    if ((!WebbShopAPI.WebbShopAPIClass.AddBookToCategory(admin, book, u)))
                    {
                        Console.WriteLine($"The book {book.Title} is added to the category {actionCategory}");
                    }

                    else
                    {
                        Console.WriteLine("No book was added to a category");

                    }
                }
                catch (Exception e)
                {

                    string b = e.ToString();
                    Console.WriteLine($"Adding book to category");
                }


                //Updating Category
                string fantasyCategory = "Fantasy";
                try
                {

                    if (WebbShopAPIClass.UpdateCategory(admin, WebbShopAPIClass.GetCategories(actionCategory)[0], fantasyCategory))
                    {
                        Console.WriteLine("Category is updated");
                    }
                    else
                    {
                        Console.WriteLine("No category was updated");
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                }

                //Delete category
                try
                {
                    if (WebbShopAPIClass.DeleteCategory(admin, WebbShopAPIClass.GetCategories(fantasyCategory)[0]))
                    {
                        Console.WriteLine($"Category {fantasyCategory} is deleted.");
                    }
                    else
                    {
                        Console.WriteLine("No category was deleted");
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                }

                //Add new user
                
                Console.WriteLine("Add new user.");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                if (WebbShopAPIClass.AddUser(admin, name, password))
                {
                    Console.WriteLine($"The user {name} was created");
                }
                else
                {
                    Console.WriteLine("No user was created");
                }
                

                //Show list of sold Items
                Console.WriteLine("Sold Items");
                var booksSold = WebbShopAPIClass.SoldItems(admin);
                foreach (SoldBook sold in booksSold)
                {
                    Console.WriteLine(sold.Title);
                }

                //Show Earnings
                string earning = WebbShopAPIClass.MoneyEarned(admin).ToString();
                Console.WriteLine($"Earnings: {earning}");

                //Show Best customer
                string bestCustomer = WebbShopAPIClass.BestCustomer(admin).Name;
                Console.WriteLine($"Best customer: {bestCustomer}");

                //Promote user
                Console.WriteLine("Promoting user");

                List<User> promoted = WebbShopAPIClass.FindUsers(admin, "TestCustomer");
                if (promoted != null && promoted.Count > 0)
                {
                    if (WebbShopAPIClass.Promote(admin, promoted[0]))
                    {
                        Console.WriteLine($"User {promoted[0].Name} promoted");
                    }

                    if (WebbShopAPIClass.Promote(admin, promoted[0]))
                    {
                        Console.WriteLine($"User {promoted[0].Name} promoted");
                    }

                    //Demote user
                    Console.WriteLine("Demoting user");

                    if (WebbShopAPIClass.Demote(admin, promoted[0]))
                    {
                        Console.WriteLine($"User {promoted[0].Name} promoted");
                    }



                    //Deactivate user
                    Console.WriteLine("Deactivate user");
                    if (WebbShopAPIClass.Demote(admin, promoted[0]))
                    {
                        Console.WriteLine($"User {promoted[0].Name} Deactivated");
                    }

                    //Activate user
                    
                    Console.WriteLine("Deactivate user");
                    if (WebbShopAPIClass.Promote(admin, promoted[0]))
                    {
                        Console.WriteLine($"User {promoted[0].Name} Activated");
                    }
                }

                else
                {
                    Console.WriteLine("You dont have any admin to use the admin functions");
                }
            }
            return false;
        }
    }
}
