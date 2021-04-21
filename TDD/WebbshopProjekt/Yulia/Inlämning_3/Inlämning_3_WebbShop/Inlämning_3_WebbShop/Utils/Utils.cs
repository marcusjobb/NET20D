using Inlämning_3_WebbShop.Views;
using MyFirstEntityframProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämning_3_WebbShop.Utils
{
    public class Utils
    {
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to WebShopYulia");
                Console.WriteLine("");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Register as a new user");
                Console.WriteLine("3. Browse book catalogue");
                Console.WriteLine("4. Log out");
                Console.WriteLine("5. Log in as administrator");
                Console.WriteLine("e. Exit program");
                Console.WriteLine("");
                var choice = Console.ReadLine();
                if (choice.ToLower().Trim() == "e")
                {
                    break;
                }
                else if (choice == "1")
                {
                    LogIn();
                }
                else if (choice == "2")
                {
                    RegisterNewUser();
                }
                else if (choice == "3")
                {
                    BrowseCatalogue();
                }
                else if (choice == "4")
                {
                    LogOut();
                }
                else if (choice == "5")
                {
                    AdminMenu();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again!");
                }
            }
        }
        public void LogIn()
        {
            var api = new WebShopAPI();
            var uView = new UserView();
            uView.LogIn(api.Login("Yulia", "Lucia2011"));            
        }
        public void RegisterNewUser()
        {
            var api = new WebShopAPI();
            var uView = new UserView();
            uView.Register(api.Register("Lucia", "Yulia2021", "Yulia2021"));
        }
        public void LogOut()
        {
            var api = new WebShopAPI();
            api.Logout(2);
            Console.WriteLine("You have successfully logged out.");
        }
        public void BrowseCatalogue()
        {
            var api = new WebShopAPI();
            var uView = new UserView();

            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("Here are some options:");
                Console.WriteLine("1. List of all book categories");
                Console.WriteLine("2. List of categories matching search keyword");
                Console.WriteLine("3. List of books in category");
                Console.WriteLine("4. List of books currently in stock");
                Console.WriteLine("5. Book information, search by Id");
                Console.WriteLine("6. List of matching books, title by keyword");
                Console.WriteLine("7. List of matching books, author by keyword");
                Console.WriteLine("8. Buy book");
                Console.WriteLine("e. Go back");

                var input = Console.ReadLine();
                Console.WriteLine();
                if (int.TryParse(input, out int chc))
                {
                    switch (chc)
                    {
                        case 1:
                            var allCategories = api.GetCategories();
                            uView.GetCategories(allCategories); //klar
                            break;
                        case 2:
                            var category = api.GetCategories("y");
                            uView.GetCategories(category); //klar
                            break;
                        case 3:
                            var categoryById = api.GetCategory(3);
                            uView.GetCategories(categoryById); //klar
                            break;
                        case 4:
                            var allBooks = api.GetAvailableBooks();
                            uView.GetAvailableBooks(allBooks); //klar
                            break;
                        case 5:
                            var bookById = api.GetBook(3);
                            uView.GetAvailableBooks(bookById); //klar
                            break;
                        case 6:
                            var booksByKeyword = api.GetBooks("peac");
                            uView.GetAvailableBooks(booksByKeyword); //klar
                            break;
                        case 7:
                            var booksByAuthor = api.GetBooks("tol");
                            uView.GetAvailableBooks(booksByAuthor); //klar
                            break;
                        case 8:
                            var soldBook = api.BuyBook(api.Login("Lucia", "Yulia2021"), 5);
                            uView.BuyBook(soldBook);//klar logged in user
                            break;
                        default:
                            Console.WriteLine("Invalid choice. try again!");
                            break;
                    }

                }
                else if (input.ToLower().Trim() == "e")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. try again!");
                }
            }
        }
        public void AdminMenu()
        {
            var api = new WebShopAPI();
            var aView = new AdminView();
            api.Login("Administrator", "CodicRulez"); //log in for admin menu 
            
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("Here are some options:");
                Console.WriteLine("1. Add a new book to the catalogue of available books");
                Console.WriteLine("2. Update amount of book items in stock");
                Console.WriteLine("3. List of users");
                Console.WriteLine("4. Find user");
                Console.WriteLine("5. Update book information");
                Console.WriteLine("6. Delete book");
                Console.WriteLine("7. Add a new category");
                Console.WriteLine("8. Add book to category");
                Console.WriteLine("9. Update category");
                Console.WriteLine("10. Delete category");
                Console.WriteLine("11. Add user");
                Console.WriteLine("e. Go back");

                var input = Console.ReadLine();
                Console.WriteLine();
                if (int.TryParse(input, out int chc))
                {
                    switch (chc)
                    {
                        case 1:
                            var newBook = api.AddBook(1, 5, "Peace and War", "Leo Tolstoy", 185, 3);
                            aView.AddBook(newBook); //klar   
                            break;

                        case 2:
                            var updateBook = api.SetAmount(1, 9);
                            aView.SetAmount(updateBook); //klar   
                            break;
                        case 3:
                            var listOfUsers = api.ListUsers(1);
                            aView.ListUsers(listOfUsers); //klar
                            break;
                        case 4:
                            var user = api.FindUser(1,"Te");
                            aView.FindUser(user); //klar
                            break;
                        case 5:
                            var bookUpdated = api.UpdateBook(1, 3, "Masha and the Bear", "Oleg Kusuvkov", 150, 2);
                            aView.UpdateBookDetails(bookUpdated); //klar
                            break;
                        case 6:
                            var bookDeleted= api.DeleteBook(1,3);
                            aView.DeleteBook(bookDeleted); //klar
                            break;
                        case 7:
                            var newCategory = api.AddCategory(1, "Poesi");
                            aView.AddCategory(newCategory); //klar
                            break;
                        case 8:
                            var bookToCategory = api.AddBookToCategory(1, 5, 5);
                            aView.AddBookToCategory(bookToCategory);//klar logged in user
                            break;
                        case 9:
                            var categoryUpdated = api.UpdateCategory(1,6,"Comedy");
                            aView.UpdateCategory(categoryUpdated);//klar logged in user
                            break;
                        case 10:
                            var categoryDeleted = api.DeleteCategory(1, 4);
                            aView.DeleteCategory(categoryDeleted); //klar
                            break;
                        case 11:
                            var addedUser = api.AddUser(1, "Lucia", "Yulia2021");
                            aView.AddUser(addedUser);//klar logged in user
                            break;

                        default:
                            Console.WriteLine("Invalid choice. try again!");
                            break;
                    }

                }
                else if (input.ToLower().Trim() == "e")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. try again!");
                }
            }
            
        }
        
    }
}

