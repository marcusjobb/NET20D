using Structs;
using System;
using System.Threading;

namespace Controllers
{
    internal class CoreController
    {
        private CurrentUserDetails currentUser;

        //TODO Refactor methods to user GetIntInput() methods ?
        private DataController dataController;

        private MenuController menuController;
        #region Internal Methods

        /// <summary>
        /// Constructor initializes important objects, vital for running the program.
        /// </summary>
        internal CoreController()
        {
            dataController = new DataController();
            menuController = new MenuController();
        }

        /// <summary>
        /// The start method of the program.
        /// Calls the main loop.
        /// </summary>
        internal void Start()
        {
            //LogoutUser(2);
            menuController.ClearConsole();
            menuController.Welcome();
            MainLoop();
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Gets input from user: Title, author, price and amount.
        /// Then sends that info the database to crate a book.
        /// </summary>
        private void AddABook()
        {
            string title = GetStringInput("Enter Title of the book you want to add:");
            string author = GetStringInput("Enter Author");
            int price = GetIntInput("Enter price for the book");
            int amount = GetIntInput("Enter the amount of this book");

            if (dataController.AddABook(currentUser.UserId, title, author, price, amount, out bool userIsInactive, out string errorMsg))
            {
                menuController.PrintMsg("Successfully added a book");
            }
            else
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Adds a book to category.
        /// Gets userInput-> write to databasse-> prints to console.
        /// </summary>
        private void AddBookToCategory()
        {
            GetAllBooks();
            int bookId = GetIntInput("Enter id of the book you want to add to a category");
            GetCategories();
            int catId = GetIntInput("Enter id of the category you want to add the book to");

            if (dataController.AddBookToCategory(currentUser.UserId, bookId, catId, out bool userIsInactive, out string errorMsg))
            {
                menuController.PrintMsg("Sucessfully added book to category");
            }
            else
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Adds a category to the database.
        /// Gets userinput and then creates category to database, then prints the results to the console.
        /// </summary>
        private void AddCategory()
        {
            string catName = GetStringInput("Enter the name of the category you want to add");
            if (dataController.AddCategory(currentUser.UserId, catName, out bool userIsInactive, out string errorMsg))
            {
                menuController.PrintMsg($"Successfully added {catName} as category name");
            }
            else
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Gets user input then adds the user to the database then prints to console.
        /// </summary>
        private void AddUser()
        {
            string userName = GetStringInput("Enter username for the new user");
            string password = GetStringInput("Enter password for the new user");

            if (dataController.AddUser(currentUser.UserId, userName, password, out bool userIsInactive, out string errorMsg))
            {
                menuController.PrintMsg("Successfully added user");
            }
            else
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Runs the admin menu loop. If current user is inactive the loop breaks.
        /// </summary>
        private void AdminMenu()
        {
            while (currentUser.IsUserActive)
            {
                if (menuController.AdminMenu(out int menuChoice, out bool userWantToExit, out string errorMsg))
                {
                    switch (menuChoice)
                    {
                        case 1:
                            // 1. Add a book
                            AddABook();
                            break;

                        case 2:
                            // 2. Set Book Amount
                            SetBookAmount();
                            break;

                        case 3:
                            // 3. List all Users
                            ListAllUsers();
                            break;

                        case 4:
                            // 4. Find specific user
                            GetUserByNameSearch();
                            break;

                        case 5:
                            // 5. Update a book
                            UpdateBook();
                            break;

                        case 6:
                            // 6. Delete a book
                            DeleteBook();
                            break;

                        case 7:
                            // 7. Add a category
                            AddCategory();
                            break;

                        case 8:
                            // 8. Add a book to a category
                            AddBookToCategory();
                            break;

                        case 9:
                            // 9. Update a category
                            UpdateCategory();
                            break;

                        case 10:
                            // 10. Delete a category
                            DeleteCategory();
                            break;

                        case 11:
                            // 11. Add a user
                            AddUser();
                            break;

                        case 12:
                            // 12. Show sold items
                            ShowSoldItems();
                            break;

                        case 13:
                            // 13. Show Money earned
                            ShowMoneyEarned();
                            break;

                        case 14:
                            // 14. Show best customer
                            ShowBestCustomer();
                            break;

                        case 15:
                            // 15. Promote a user to admin
                            PromoteAUser();
                            break;

                        case 16:
                            // 16. Demote a user from admin
                            DemoteAUser();
                            break;

                        case 17:
                            // 17. Activate a user (Set user active)
                            SetUserActive();
                            break;

                        case 18:
                            // 18. Deactivate a user(Set user to inactive
                            DeActivateUser();
                            break;

                        case 19:
                            // 19. Run user menu
                            UserMenu();
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    if (userWantToExit)
                    {
                        LogOutAndExit();
                    }
                    menuController.PrintMsg(errorMsg);
                }
            }
        }

        /// <summary>
        /// Prints users to console.
        /// Then gets user input by of which user to set session to deactivate. Then writes to database, then prints results to console.
        /// </summary>
        private void DeActivateUser()
        {
            ListAllUsers();
            int setDeActivateUserId = GetIntInput("Enter id on which user you want to set session to active");
            if (dataController.SetUserInactive(currentUser.UserId, setDeActivateUserId, out bool userIsInactive, out string errorMsg))
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintMsg("User successfully Deactivated session on user!");
            }
            else
            {
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Deletes a book.
        /// Gets user input. Then deletes book from database. Then prints results to console
        /// </summary>
        private void DeleteBook()
        {
            GetAllBooks();
            int bookId = GetIntInput("Enter the ID of the book you want to delete");
            if (dataController.DeleteBook(currentUser.UserId, bookId, out bool userIsInactive, out string errorMsg))
            {
                menuController.PrintMsg("Successfully deleted the book");
            }
            else
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Gets userinput about which category to delete, then deletes in database, then prints results to console
        /// </summary>
        private void DeleteCategory()
        {
            GetCategories();
            int catId = GetIntInput("Enter the id of the category you want to delete");
            if (dataController.DeleteCategor(currentUser.UserId, catId, out bool userIsInactive, out string errorMsg))
            {
                menuController.PrintMsg("Successfully deleted category");
            }
            else
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Prints users to console.
        /// Then gets user input whih user to demote from admin. Then write that do the database. Then prints results to console.
        /// </summary>
        private void DemoteAUser()
        {
            ListAllUsers();
            int demoteUserId = GetIntInput("Enter id on which user you want to demote admin");
            if (dataController.DemoteAUser(currentUser.UserId, demoteUserId, out bool userIsInactive, out string errorMsg))
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintMsg("User successfully got Demoted!!");
            }
            else
            {
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Exits the program and clears the console
        /// </summary>
        private void ExitProgram()
        {
            menuController.PrintMsg("Exiting Program");
            Thread.Sleep(2000);
            menuController.ClearConsole();
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints all books from the database to the console.
        /// </summary>
        private void GetAllBooks()
        {
            string results = dataController.GetAllBooks(currentUser.UserId, out bool userIsInactive, out string errorMsg2);
            if (userIsInactive)
            {
                currentUser.IsUserActive = false;
                return;
            }
            else
            {
                menuController.PrintResults(results);
            }
        }

        /// <summary>
        /// Get user input then prints out available books by category id input.
        /// </summary>
        private void GetAvailableBooksInCatById()
        {
            GetCategories();
            if (menuController.GetSearchIntInput("Enter Id of the category you want to list all available books from",
            out int userInput, out bool userWantToExit, out string errorMsg))
            {
                string results = dataController.GetBooksAvailableByCategoryId(userInput,
                currentUser.UserId,
                out bool userIsInactive,
                out string errorMsg2);

                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintResults(results);
            }
            else
            {
                if (errorMsg != "")
                {
                    menuController.PrintMsg(errorMsg);
                }

                if (userWantToExit)
                {
                    LogOutAndExit();
                }
            }
        }

        /// <summary>
        /// Gets userinput and prints out matching books by book title or authur to the console.
        /// </summary>
        private void GetBookBySearchName()
        {
            if (menuController.GetSearchStringInput("Enter Title or author of book you want to search for",
            out string userInput, out bool userWantToExit, out string errorMsg))
            {
                string results = dataController.GetBookByName(userInput,
                currentUser.UserId,
                out bool userIsInactive,
                out string errorMsg2);

                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintResults(results);
            }
            else
            {
                if (errorMsg != "")
                {
                    menuController.PrintMsg(errorMsg);
                }

                if (userWantToExit)
                {
                    LogOutAndExit();
                }
            }
        }

        /// <summary>
        /// Gets user input of Author name search. Then prints out the books by that author to the console.
        /// </summary>
        private void GetBooksByAuthorNameSearch()
        {
            if (menuController.GetSearchStringInput("Enter the name of the Author you want to search for and their books will show",
            out string userInput, out bool userWantToExit, out string errorMsg))
            {
                string results = dataController.GetBooksByAuthorNameSearch(userInput,
                currentUser.UserId,
                out bool userIsInactive,
                out string errorMsg2);

                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintResults(results);
            }
            else
            {
                if (errorMsg != "")
                {
                    menuController.PrintMsg(errorMsg);
                }

                if (userWantToExit)
                {
                    LogOutAndExit();
                }
            }
        }

        /// <summary>
        /// First prints out all categories then gets user input of which books are in categories.
        /// Then prints the results to the console
        /// </summary>
        private void GetBooksInCategoryById()
        {
            GetCategories();
            if (menuController.GetSearchIntInput("Enter Id of the category you want to list all books from",
            out int userInput, out bool userWantToExit, out string errorMsg))
            {
                string results = dataController.GetBooksByCategoryId(userInput,
                currentUser.UserId,
                out bool userIsInactive,
                out string errorMsg2);

                if (userIsInactive)
                {
                    //No need for local Logout User method call here. Since WebbShopAPI Ping method already logs user out if user is not active
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintResults(results);
            }
            else
            {
                if (errorMsg != "")
                {
                    menuController.PrintMsg(errorMsg);
                }

                if (userWantToExit)
                {
                    LogOutAndExit();
                }
            }
        }

        /// <summary>
        /// Gets and Prints all categories from database to the console
        /// </summary>
        private void GetCategories()
        {
            string categories = dataController.GetCategories(currentUser.UserId, out bool userIsInactive, out string errorMsg2);
            if (userIsInactive)
            {
                currentUser.IsUserActive = false;
                return;
            }
            else
            {
                menuController.PrintResults(categories);
            }
        }

        /// <summary>
        /// Prints all books to console and then gets user input of which information about a book to show.
        /// Then shows this information to the console
        /// </summary>
        private void GetInfoOfBookById()
        {
            GetAllBooks();
            if (menuController.GetSearchIntInput("Enter Id of the book you want information about",
            out int userInput, out bool userWantToExit, out string errorMsg))
            {
                string results = dataController.GetInfoOfBookById(userInput,
                currentUser.UserId,
                out bool userIsInactive,
                out string errorMsg2);

                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintResults(results);
            }
            else
            {
                if (errorMsg != "")
                {
                    menuController.PrintMsg(errorMsg);
                }

                if (userWantToExit)
                {
                    LogOutAndExit();
                }
            }
        }

        /// <summary>
        /// Calls menuctontroller for input and shows the parameter to the console.
        /// If input is that user want to exit. It will logout user and exit the program
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private int GetIntInput(string msg)
        {
            if (menuController.GetSearchIntInput(msg,
            out int userInput, out bool userWantToExit, out string errorMsg))
            {
                return userInput;
            }
            else
            {
                if (errorMsg != "")
                {
                    menuController.PrintMsg(errorMsg);
                }

                if (userWantToExit)
                {
                    LogOutAndExit();
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets user input of which category to search for. Then prints the results to the console.
        /// </summary>
        private void GetSpecificCategory()
        {
            if (menuController.GetSearchStringInput("Enter name of category to search for",
            out string userInput, out bool userWantToExit, out string errorMsg))
            {
                string results = dataController.GetSpecificCategory(userInput,
                currentUser.UserId,
                out bool userIsInactive,
                out string errorMsg2);

                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintResults(results);
            }
            else
            {
                if (errorMsg != "")
                {
                    menuController.PrintMsg(errorMsg);
                }

                if (userWantToExit)
                {
                    LogOutAndExit();
                }
            }
        }

        /// <summary>
        /// Calls menuctontroller for input and shows the parameter to the console
        /// If input is that user want to exit. It will logout user and exit the program
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private string GetStringInput(string msg)
        {
            if (menuController.GetSearchStringInput(msg,
            out string userInput, out bool userWantToExit, out string errorMsg))
            {
                return userInput;
            }
            else
            {
                if (errorMsg != "")
                {
                    menuController.PrintMsg(errorMsg);
                }

                if (userWantToExit)
                {
                    LogOutAndExit();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets userinput and then retrives data about the user from database and prints then to console
        /// </summary>
        private void GetUserByNameSearch()
        {
            string userName = GetStringInput("Enter the name of the user you want to find");
            string result = dataController.GetUserByNameSearch(currentUser.UserId, userName, out bool userIsInactive, out string errorMsg);
            if (userIsInactive)
            {
                currentUser.IsUserActive = false;
                return;
            }
            else
            {
                if (errorMsg == string.Empty)
                {
                    menuController.PrintResults(result);
                }
                else
                {
                    menuController.ErrorPrint(errorMsg);
                }
            }
        }

        /// <summary>
        /// Gets list from database of all users and prints it out to the console
        /// </summary>
        private void ListAllUsers()
        {
            string allUsers = dataController.GetAllUsers(currentUser.UserId, out bool userIsInactive, out string errorMsg);
            if (userIsInactive)
            {
                currentUser.IsUserActive = false;
                return;
            }
            else
            {
                if (errorMsg == string.Empty)
                {
                    menuController.PrintResults(allUsers);
                }
                else
                {
                    menuController.ErrorPrint(errorMsg);
                }
            }
        }

        /// <summary>
        /// Calls Login Menu for user. And saves user details into currentUser if sucessfull.
        /// </summary>
        /// <returns>True if sucessful login, else false</returns>
        private bool LoginUser()
        {
            // LoginDetails loginUserDetails = menuController.LoginMenu();
            if (menuController.LoginMenu(out LoginDetails loginUserDetails, out bool userWantToLogout, out bool newUser))
            {
                if (newUser)
                {
                    if (dataController.RegisterUser(loginUserDetails, out string registerErrorMsg))
                    {
                        menuController.PrintMsg($"{loginUserDetails.UserName} Registered. Logging in...");

                        if (dataController.LoginUser(loginUserDetails, out int userId, out string loginErrorMsg))
                        {
                            SaveCurrentUser(loginUserDetails, userId);

                            menuController.PrintMsg($"Welcome {currentUser.UserName}");
                            return true;
                        }
                        else
                        {
                            menuController.ErrorPrint(loginErrorMsg);
                            return false;
                        }
                    }
                    else
                    {
                        menuController.ErrorPrint(registerErrorMsg);
                        return false;
                    }
                }
                else
                {
                    if (dataController.LoginUser(loginUserDetails, out int userId, out string loginErrorMsg))
                    {
                        SaveCurrentUser(loginUserDetails, userId);
                        menuController.ClearConsole();
                        menuController.PrintMsg($"Login sucessful!\nWelcome {currentUser.UserName}");
                        return true;
                    }
                    else
                    {
                        menuController.ErrorPrint(loginErrorMsg);
                        return false;
                    }
                }
            }
            else
            {
                ExitProgram();
                return false;
            }
        }

        /// <summary>
        /// Logs user out from the database and local.
        /// Then shuts the program down
        /// </summary>
        private void LogOutAndExit()
        {
            LogoutUser(currentUser.UserId);
            ExitProgram();
        }

        /// <summary>
        /// Logs user out if user is not admin
        /// </summary>
        private void LogOutIfUserIsNotAdmin()
        {
            if (!currentUser.IsUserAdmin)
            {
                LogoutUser(currentUser.UserId);
            }
        }

        /// <summary>
        /// Logs out the user from the database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>True if sucesss, else false</returns>
        private bool LogoutUser(int userId)
        {
            menuController.PrintMsg($"Logging out {currentUser.UserName}");
            Thread.Sleep(1000);
            if (dataController.LogOutUser(userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Main loop for the program. If this one ends , the program will exit.
        /// </summary>
        private void MainLoop()
        {
            while (true)
            {
                if (LoginUser())
                {
                    //User is now logged in
                    if (currentUser.IsUserAdmin)
                    {
                        // Admin Menu
                        AdminMenu();
                    }
                    else
                    {
                        // User Menu
                        UserMenu();
                    }
                }
                else
                {
                    if (!menuController.TryAgain())
                    {
                        break;
                    }
                }
            }

            ExitProgram();
        }
        /// <summary>
        /// Prints users to console.
        /// Then gets userinput wich user to promote to admin. Then write that to database. Then prints results to console.
        /// </summary>
        private void PromoteAUser()
        {
            ListAllUsers();
            int promoteUserId = GetIntInput("Enter id on which user you want to Promote admin");
            if (dataController.PromoteUser(currentUser.UserId, promoteUserId, out bool userIsInactive, out string errorMsg))
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintMsg("User successfully got promoted");
            }
            else
            {
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Saves current user temporary in the program for easier navigation.
        /// </summary>
        /// <param name="details"></param>
        /// <param name="userId"></param>
        private void SaveCurrentUser(LoginDetails details, int userId)
        {
            currentUser = new CurrentUserDetails(details.UserName, details.Password, userId, dataController.IsUserAdmin(userId), true);
        }

        /// <summary>
        /// Gets user input and set the amount to the database. Also prints results to the console.
        /// </summary>
        private void SetBookAmount()
        {
            GetAllBooks();
            int bookId = GetIntInput("Enter Id of which book you want to set amount on");
            int amount = GetIntInput("Enter Amount");

            if (dataController.SetBookAmount(currentUser.UserId, bookId, amount, out bool userIsInactive, out string errorMsg))
            {
                menuController.PrintMsg("Successfully changed the amount");
            }
            else
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Prints users to console.
        /// Then gets user input by of which user to set session to active. Then writes to database, then prints results to console.
        /// </summary>
        private void SetUserActive()
        {
            ListAllUsers();
            int setActiveUserId = GetIntInput("Enter id on which user you want to set session to active");
            if (dataController.SetUserActive(currentUser.UserId, setActiveUserId, out bool userIsInactive, out string errorMsg))
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                menuController.PrintMsg("User successfully activated session on user!");
            }
            else
            {
                menuController.PrintMsg(errorMsg);
            }
        }
        /// <summary>
        /// Gets the best customer from database and prints it to console.
        /// </summary>
        private void ShowBestCustomer()
        {
            string bestCustomer = dataController.GetBestCustomer(currentUser.UserId, out bool userIsInactive, out string errorMsg);
            if (userIsInactive)
            {
                currentUser.IsUserActive = true;
                return;
            }
            else
            {
                menuController.PrintMsg(bestCustomer);
            }
        }

        /// <summary>
        /// Gets money earned from database then prints it to console
        /// </summary>
        private void ShowMoneyEarned()
        {
            string moneyEarned = dataController.GetMoneyEarned(currentUser.UserId, out bool userIsInactive, out string errorMsg);
            if (userIsInactive)
            {
                currentUser.IsUserActive = true;
                return;
            }
            else
            {
                menuController.PrintMsg(moneyEarned);
            }
        }

        /// <summary>
        /// Prints sold items to the console from the database.(sold books)
        /// </summary>
        private void ShowSoldItems()
        {
            string soldItems = dataController.GetSoldItems(currentUser.UserId, out bool userIsInactive, out string errorMsg);
            if (userIsInactive)
            {
                currentUser.IsUserActive = true;
                return;
            }
            else
            {
                menuController.PrintMsg(soldItems);
            }
        }
        /// <summary>
        /// Updates a book in the database.
        /// Gets input from user and updates book in database.
        /// Then prints results to console.
        /// </summary>
        private void UpdateBook()
        {
            GetAllBooks();
            //Can add to not update any data if input is left blank/string.empty/""
            int bookId = GetIntInput("Enter the ID of the book you want to update");
            string titleName = GetStringInput("Enter a new name for the book");
            string authorName = GetStringInput("Enter new author for the book");
            int price = GetIntInput("Enter new price for the book");

            if (dataController.UpdateBook(currentUser.UserId, bookId, titleName, authorName, price, out bool userIsInactive, out string errorMsg))
            {
                menuController.PrintMsg("Successfully updated book");
            }
            else
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }
                menuController.PrintMsg(errorMsg);
            }
        }

        /// <summary>
        /// Gets userinput, updates category in database, prints results to console
        /// </summary>
        private void UpdateCategory()
        {
            GetCategories();
            int catId = GetIntInput("Enter id of the category you want to update");
            string catName = GetStringInput("Now enter the new name for the category");

            if (dataController.UpdateCategory(currentUser.UserId, catId, catName, out bool userIsInactive, out string errorMsg))
            {
                menuController.PrintMsg("Sucessfully updated category");
            }
            else
            {
                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }
                menuController.PrintMsg(errorMsg);
            }
        }
        /// <summary>
        /// Simulates user buying a book without currency.
        /// Gets the user input of the book and database then changes the amount of that book by -1.
        /// </summary>
        private void UserBuysBook()
        {
            //No currency implemented yet. Only sets the book amount-- in the database.
            GetAllBooks();
            if (menuController.GetSearchIntInput("Enter Id of which book you want to buy",
            out int userInput, out bool userWantToExit, out string errorMsg))
            {
                bool successfulBuy = dataController.UserBuysBook(userInput,
                currentUser.UserId,
                out bool userIsInactive,
                out string errorMsg2);

                if (userIsInactive)
                {
                    currentUser.IsUserActive = false;
                    return;
                }

                if (successfulBuy)
                {
                    menuController.PrintResults("You successfully bought the book");
                }
                else
                {
                    menuController.PrintResults("Could not buy book..");
                }
            }
            else
            {
                if (errorMsg != "")
                {
                    menuController.PrintMsg(errorMsg);
                }

                if (userWantToExit)
                {
                    LogOutAndExit();
                }
            }
        }

        /// <summary>
        /// Runs the loop of the user menu. Takes in user input and calls methods accordingly
        /// </summary>
        private void UserMenu()
        {
            while (currentUser.IsUserActive)
            {
                if (menuController.UserMenu(out int menuChoice, out bool userWantToExit, out string errorMsg))
                {
                    switch (menuChoice)
                    {
                        case 1:
                            // 1. Show all categories
                            GetCategories();
                            break;

                        case 2:
                            // 2. Search for a specific category
                            GetSpecificCategory();
                            break;

                        case 3:
                            // 3. List all books in category by category id
                            GetBooksInCategoryById();
                            break;

                        case 4:
                            // 4. Show avaible books in category
                            GetAvailableBooksInCatById();
                            break;

                        case 5:
                            // 5. Information about a book
                            GetInfoOfBookById();
                            break;

                        case 6:
                            // 6. Search for books by name
                            GetBookBySearchName();
                            break;

                        case 7:
                            // 7. Search for authors by name
                            GetBooksByAuthorNameSearch();
                            break;

                        case 8:
                            // 8. Buy a book.
                            UserBuysBook();
                            break;

                        case 9:
                            LogOutIfUserIsNotAdmin();
                            return;

                        default:
                            break;
                    }
                }
                else
                {
                    if (userWantToExit)
                    {
                        LogOutAndExit();
                    }
                    menuController.PrintMsg(errorMsg);
                }
            }
        }
    }

    #endregion Private Methods
}