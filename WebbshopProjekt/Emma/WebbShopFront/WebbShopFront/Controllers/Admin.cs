using System;
using System.Linq;
using WebbShopFrontInlamning.Helpers;
using WebbShopFrontInlamning.Views;
using WebbShopInlamningsUppgift;

namespace WebbShopFrontInlamning.Controllers
{
    /// <summary>
    /// Controls the admin flow
    /// </summary>
    class Admin
    {
        private int userId;
        
        /// <summary>
        /// Runs the Admin funtionality-page
        /// </summary>
        /// <returns>integer, user id if admin, 0 if not</returns>
        public int Run()
        {
            AdminView.StartPage();
            userId = new Login().Run();
            if(userId == 0)
            {
                return 0;
            }

            var result = CheckAdmin(userId);
            if (!result)
            {
                AdminView.VerifyAdminFailed();
                return 0;
            }

            bool keepGoing = true;
            while (keepGoing)
            {
                AdminView.AdminPage();
                var input = InputHelper.ParseInput();

                switch (input)
                {
                    case 1:
                        AddBook(userId);
                        break;
                    case 2:
                        SetAmount(userId);
                        break;
                    case 3:
                        ViewAllUsers(userId);
                        break;
                    case 4:
                        FindUser(userId);
                        break;
                    case 5:
                        UpdateBook(userId);
                        break;
                    case 6:
                        DeleteBook(userId);
                        break;
                    case 7:
                        AddCategory(userId);
                        break;
                    case 8:
                        AddBookToCategory(userId);
                        break;
                    case 9:
                        UpdateCategory(userId);
                        break;
                    case 10:
                        DeleteCategory(userId);
                        break;
                    case 11:
                        AddUser(userId);
                        break;
                    case 12:
                        ViewAllSoldItems(userId);
                        break;
                    case 13:
                        ViewTotalIncome(userId);
                        break;
                    case 14:
                        ViewBestCustomer(userId);
                        break;
                    case 15:
                        PromoteUser(userId);
                        break;
                    case 16:
                        DemoteUser(userId);
                        break;
                    case 17:
                        ActivateUser(userId);
                        break;
                    case 18:
                        InactivateUser(userId);
                        break;
                    case 19:
                        keepGoing = false;
                        break;
                    default:
                        MessageViews.DisplayNonAvailableMessage();
                        break;
                }
            }
            return userId;
        }

        /// <summary>
        /// Checks an random admin functionality to see if user is admin
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>boolean true if successful, false if not</returns>
        private bool CheckAdmin(int userId)
        {
            WebbShopAPI api = new WebbShopAPI();
            //if the return value is larger than 0 the userId is valid.
            var list = api.ListUsers(userId);
            if(list.Count > 0)
            {
                return true;
            }
            return false; 
        }

        /// <summary>
        /// Allows an admin user to add a new book
        /// </summary>
        /// <param name="adminId"></param>
        private void AddBook(int adminId)
        {
            AdminView.AddBookPage();
            var title = Console.ReadLine();
            var author = Console.ReadLine();
            var price = InputHelper.ParseInput();
            var amount = InputHelper.ParseInput();

            if(title != "" && author != "" && price != 0 && amount != 0)
            {
                WebbShopAPI api = new WebbShopAPI();
                bool result = api.AddBook(adminId, title, author, price, amount);
                if (result)
                {
                    MessageViews.DisplaySuccessMessage();
                    return;
                }
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows an admin user to add a book to category
        /// </summary>
        /// <param name="adminId"></param>
        private void AddBookToCategory(int adminId)
        {
            AdminView.AddBookCategory();
            new Book().SearchBooksByTitle();
            MessageViews.DisplaySelectMessage();
            var bookId = InputHelper.ParseInput();

            new Book().ViewAllCategories();
            MessageViews.DisplaySelectMessage();
            MessageViews.DisplayReturnMessage();

            var categoryId = InputHelper.ParseInput();
            if(categoryId == 0)
            {
                return;
            }

            if(bookId != 0 && categoryId != 0)
            {
                WebbShopAPI api = new WebbShopAPI();
                var result = api.AddBookToCategory(adminId, bookId, categoryId);
                if (result)
                {
                    MessageViews.DisplaySuccessMessage();
                    return;
                }
            }
            
            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows admin user to add a new category
        /// </summary>
        /// <param name="adminId"></param>
        private void AddCategory(int adminId)
        {
            AdminView.AddCategoryPage();
            var genere = Console.ReadLine();
            if(genere != "")
            {
                WebbShopAPI api = new WebbShopAPI();
                var result = api.AddCategory(adminId, genere);
                if (result)
                {
                    MessageViews.DisplaySuccessMessage();
                    return;
                }
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows admin user to add a new user
        /// </summary>
        /// <param name="adminId"></param>
        private void AddUser(int adminId)
        {
           ManageAccountViews.AddAccount();
            var userName = Console.ReadLine();
            var password = Console.ReadLine();
            if(userName != "" && password != "")
            {
                WebbShopAPI api = new WebbShopAPI();
                var result = api.AddUser(adminId, userName, password);
                if (result)
                {
                    MessageViews.DisplaySuccessMessage();
                    return;
                }
            }
            if (userName != "" && password == "")
            {
                WebbShopAPI api = new WebbShopAPI();
                var result = api.AddUser(adminId, userName);
                if (result)
                {
                    MessageViews.DisplaySuccessMessage();
                    return;
                }
            }

            ManageAccountViews.RegisterFailed();
        }

        /// <summary>
        /// Allows admin user to activate user
        /// </summary>
        /// <param name="adminId"></param>
        private void ActivateUser(int adminId)
        {
            ViewAllUsers(adminId);
            MessageViews.DisplaySelectMessage();
            MessageViews.DisplayReturnMessage();
            var userId = InputHelper.ParseInput();
            if (userId == 0)
            {
                return;
            }

            WebbShopAPI api = new WebbShopAPI();
            bool result = api.ActivateUser(adminId, userId);
            if (result)
            {
                MessageViews.DisplaySuccessMessage();
                return;
            }
            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows admin user to demote another admin user
        /// </summary>
        /// <param name="adminId"></param>
        private void DemoteUser(int adminId)
        {
            ViewAllUsers(adminId);
            MessageViews.DisplaySelectMessage();
            MessageViews.DisplayReturnMessage();
            var userId = InputHelper.ParseInput();
            if (userId == 0)
            {
                return;
            }

            WebbShopAPI api = new WebbShopAPI();
            bool result = api.Demote(adminId, userId);
            if (result)
            {
                MessageViews.DisplaySuccessMessage();
                return;
            }
            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows admin user to inactivate user
        /// </summary>
        /// <param name="adminId"></param>
        private void InactivateUser(int adminId)
        {
            ViewAllUsers(adminId);
            MessageViews.DisplaySelectMessage();
            MessageViews.DisplayReturnMessage();
            var userId = InputHelper.ParseInput();
            if (userId == 0)
            {
                return;
            }

            WebbShopAPI api = new WebbShopAPI();
            bool result = api.InactivateUser(adminId, userId);
            if (result)
            {
                MessageViews.DisplaySuccessMessage();
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows Admin user to promote another user to admin
        /// </summary>
        /// <param name="adminId"></param>
        private void PromoteUser(int adminId)
        {
            ViewAllUsers(adminId);
            MessageViews.DisplaySelectMessage();
            MessageViews.DisplayReturnMessage();
            var userId = InputHelper.ParseInput();
            if(userId == 0)
            {
                return;
            }

            WebbShopAPI api = new WebbShopAPI();
            bool result = api.Promote(adminId, userId);
            if (result)
            {
                MessageViews.DisplaySuccessMessage();
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows admin user to set the amount of a book
        /// </summary>
        /// <param name="adminId"></param>
        private void SetAmount(int adminId)
        {
            new Book().FindAllAvailableBooks();
            AdminView.SetAmountPage();
            MessageViews.DisplayReturnMessage();

            var bookId = InputHelper.ParseInput();
            if(bookId == 0)
            {
                return;
            }

            var newAmount = InputHelper.ParseInput();

            WebbShopAPI api = new WebbShopAPI();
            bool result = api.SetAmount(adminId, bookId, newAmount);
            if (result)
            {
                MessageViews.DisplaySuccessMessage();
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows an admin user to view all users
        /// </summary>
        /// <param name="adminId"></param>
        private void ViewAllUsers(int adminId)
        {
            WebbShopAPI api = new WebbShopAPI();
            var listOfUsers = api.ListUsers(adminId);
            if(listOfUsers != null)
            {
                var sortUserList = listOfUsers.OrderBy(u => u.ID).ToList();
                AdminView.DisplayUsers(sortUserList);
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows an admin user to view all sold books
        /// </summary>
        /// <param name="adminId"></param>
        private void ViewAllSoldItems(int adminId)
        {
            WebbShopAPI api = new WebbShopAPI();
            var listOfSoldItems = api.SoldItems(adminId);
            if(listOfSoldItems != null)
            {
                AdminView.DisplaySoldItems(listOfSoldItems);
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows an admin user to see which customer bought the most books
        /// </summary>
        /// <param name="adminId"></param>
        private void ViewBestCustomer(int adminId)
        {
            WebbShopAPI api = new WebbShopAPI();
            var customerId = api.BestCustomer(adminId);
            if(customerId != 0)
            {
                AdminView.DisplayBestCustomer(customerId);
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows admin user to view the sum of all sold books
        /// </summary>
        /// <param name="adminId"></param>
        private void ViewTotalIncome(int adminId)
        {
            WebbShopAPI api = new WebbShopAPI();
            var totalIncome = api.MoneyEarned(adminId);
            if(totalIncome != 0)
            {
                AdminView.DisplayMoneyEarned(totalIncome);
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows an admin user to find another user
        /// </summary>
        /// <param name="adminId"></param>
        private void FindUser(int adminId)
        {
            AdminView.SearchPage();
            var keyword = Console.ReadLine();
            if(keyword != "")
            {
                WebbShopAPI api = new WebbShopAPI();
                var listOfUsers = api.FindUser(adminId, keyword);
                if(listOfUsers != null)
                {
                    var sortUserList = listOfUsers.OrderBy(u => u.ID).ToList();
                    AdminView.DisplayUsers(sortUserList);
                    return;
                }
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows an admin user to update an existing book
        /// </summary>
        /// <param name="adminId"></param>
        private void UpdateBook(int adminId)
        {
            new Book().FindAllAvailableBooks();
            MessageViews.DisplaySelectMessage();
            MessageViews.DisplayReturnMessage();
            
            var bookId = InputHelper.ParseInput();
            if(bookId == 0)
            {
                return;
            }

            AdminView.UpdateBookPage();
            var title = Console.ReadLine();
            var author = Console.ReadLine();
            var price = InputHelper.ParseInput();

            if(title != "" && author != "" && price != 0)
            {
                WebbShopAPI api = new WebbShopAPI();
                bool result = api.UpdateBook(adminId, bookId, title, author, price);
                if (result)
                {
                    MessageViews.DisplaySuccessMessage();
                    return;
                }
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows admin user to update an existing category
        /// </summary>
        /// <param name="adminId"></param>
        private void UpdateCategory(int adminId)
        {
            new Book().ViewAllCategories();
            MessageViews.DisplaySelectMessage();
            MessageViews.DisplayReturnMessage();
            
            var categoryId = InputHelper.ParseInput();
            if(categoryId == 0)
            {
                return;
            }

            AdminView.UpdateCategoryPage();
            var genere = Console.ReadLine();
            if(genere != "")
            {
                WebbShopAPI api = new WebbShopAPI();
                var result = api.UpdateCategory(adminId, categoryId, genere);
                if (result)
                {
                    MessageViews.DisplaySuccessMessage();
                    return;
                }
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows admin user to delete book
        /// </summary>
        /// <param name="adminId"></param>
        private void DeleteBook(int adminId)
        {
            new Book().FindAllAvailableBooks();
            MessageViews.DisplaySelectMessage();
            MessageViews.DisplayReturnMessage();

            var bookId = InputHelper.ParseInput();
            if(bookId == 0)
            {
                return;
            }

            WebbShopAPI api = new WebbShopAPI();
            bool result = api.DeleteBook(adminId, bookId);
            if (result)
            {
                MessageViews.DisplaySuccessMessage();
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows admin user to delete book category
        /// </summary>
        /// <param name="adminId"></param>
        private void DeleteCategory(int adminId)
        {
            new Book().ViewAllCategories();
            MessageViews.DisplaySelectMessage();
            MessageViews.DisplayReturnMessage();

            var categoryId = InputHelper.ParseInput();
            if (categoryId == 0)
            {
                return;
            }

            WebbShopAPI api = new WebbShopAPI();
            var result = api.DeleteCategory(adminId, categoryId);
            if (result)
            {
                MessageViews.DisplaySuccessMessage();
                return;
            }

            MessageViews.DisplayErrorMessage();
        }
    }
}
