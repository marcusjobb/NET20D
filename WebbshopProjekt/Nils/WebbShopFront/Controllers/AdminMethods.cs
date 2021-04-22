using System;
using System.Collections.Generic;
using System.Text;

namespace WebbShopFront.Controllers
{
    class AdminMethods
    {
        /// <summary>
        /// Dessa två strängar har jag skapat för att göra det smidigare med att designa menyerna.
        /// </summary>
        public string spacing = "                                            ";
        public string spacing2 = "           ";

        /// <summary>
        /// Denna metod lägger till ny bok i systemet. Ifall boken redan existerar, så kommer bokens amount att öka med angiven parameter.
        /// </summary>
        public void AddBook()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Book ID: ");
            string bookInput = Console.ReadLine();
            Console.Write(spacing + "Title: ");
            string title = Console.ReadLine();
            Console.Write(spacing + "Author: ");
            string author = Console.ReadLine();
            Console.Write(spacing + "Price: ");
            string priceInput = Console.ReadLine();
            Console.Write(spacing + "Amount: ");
            string amountInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int bookID = Convert.ToInt32(bookInput);
            int price = Convert.ToInt32(priceInput);
            int amount = Convert.ToInt32(amountInput);

            var bookAdd = API.AddBook(adminID, bookID, title, author, price, amount);

            if (bookAdd == true)
            {
                Console.WriteLine(spacing + $"Added {title}.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (bookAdd == false)
            {
                Console.WriteLine(spacing + "Failed to add book.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metod bestämmer hur många böcker som ska finnas i bokaffären.
        /// </summary>
        public void SetAmount()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Book ID: ");
            string bookInput = Console.ReadLine();
            Console.Write(spacing + "Amount: ");
            string amountInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int bookID = Convert.ToInt32(bookInput);
            int amount = Convert.ToInt32(amountInput);

            var setAmount = API.SetAmount(adminID, bookID, amount);

            if (setAmount == true)
            {
                Console.WriteLine(spacing + $"Added amount by {amount}");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (setAmount == false)
            {
                Console.WriteLine(spacing + "Failed to add book.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metod listar upp alla användare.
        /// </summary>
        public void ListAllUsers()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);

            var listAll = API.ListUsers(adminID);

            Console.WriteLine("\n" + spacing + "~ Users ~\n");
            foreach (var user in listAll)
            {
                Console.WriteLine(spacing + user.Name);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metod söker efter en användare med hjälp av sökordsparameter.
        /// </summary>
        public void SearchUser()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Username: ");
            string userInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);

            var userList = API.FindUser(adminID, userInput);
            foreach (var user in userList)
            {
                Console.WriteLine(spacing + user.Name);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metod uppdaterar värden hos en redan existerande bok.
        /// </summary>
        public void UpdateBook()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Book ID: ");
            string bookInput = Console.ReadLine();
            Console.Write(spacing + "Title: ");
            string titleInput = Console.ReadLine();
            Console.Write(spacing + "Author: ");
            string authorInput = Console.ReadLine();
            Console.Write(spacing + "Price: ");
            string priceInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int bookID = Convert.ToInt32(bookInput);
            int price = Convert.ToInt32(priceInput);

            var updateBook = API.UpdateBook(adminID, bookID, titleInput, authorInput, price);

            if (updateBook == true)
            {
                Console.WriteLine(spacing + $"Updated the changes.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (updateBook == false)
            {
                Console.WriteLine(spacing + "Failed to update book.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metod raderar en bok med hjälp av ID.
        /// </summary>
        public void DeleteBook()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Book ID: ");
            string bookInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int bookID = Convert.ToInt32(bookInput);

            var deleteBook = API.DeleteBook(adminID, bookID);

            if (deleteBook == true)
            {
                Console.WriteLine(spacing + $"Deleted the book.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (deleteBook == false)
            {
                Console.WriteLine(spacing + "Failed to delete book.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metod lägger till en kategori.
        /// </summary>
        public void AddCategory()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Category name: ");
            string categoryInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);

            var addCategory = API.AddCategory(adminID, categoryInput);

            if (addCategory == true)
            {
                Console.WriteLine(spacing + $"Added category.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (addCategory == false)
            {
                Console.WriteLine(spacing + "Failed to add category.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metod lägger till en redan existerande bok till en kategori.
        /// </summary>
        public void AddBookToCategory()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Book ID: ");
            string bookInput = Console.ReadLine();
            Console.WriteLine(spacing + "Category: ");
            string categoryInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int bookID = Convert.ToInt32(bookInput);

            var bookAdd = API.AddBookToCategory(adminID, bookID, categoryInput);

            if (bookAdd == true)
            {
                Console.WriteLine(spacing + $"Added book to category.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (bookAdd == false)
            {
                Console.WriteLine(spacing + "Failed to add book to category.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metod raderar en kategori.
        /// </summary>
        public void DeleteCategory()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Category ID: ");
            string categoryInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int categoryID = Convert.ToInt32(categoryInput);

            var delCategory = API.DeleteCategory(adminID, categoryID);

            if (delCategory == true)
            {
                Console.WriteLine(spacing + $"Deleted category.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (delCategory == false)
            {
                Console.WriteLine(spacing + "Failed to delete category.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metod lägger till en användare.
        /// </summary>
        public void AddUser()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Username: ");
            string username = Console.ReadLine();
            Console.Write(spacing + "Password: ");
            string password = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);

            var addUser = API.AddUser(adminID, username, password);

            if (addUser == true)
            {
                Console.WriteLine(spacing + $"Added user.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (addUser == false)
            {
                Console.WriteLine(spacing + "Failed to add user.");
                Console.Write(spacing);
                Console.ReadLine();
            }

        }

        /// <summary>
        /// Denna metod radar upp alla böcker som har sålts till vilken person.
        /// </summary>
        public void SoldItems()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);

            var soldItems = API.SoldItems(adminID);

            foreach (var item in soldItems)
            {
                Console.WriteLine(spacing + $"{item.Title} - {item.Price}kr - User ID: {item.UserID}");
            }
        }

        /// <summary>
        /// Denna metod visar hur mycket pengar bokaffären har tjänat.
        /// </summary>
        public void MoneyEarned()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);

            var moneyEarned = API.SoldItems(adminID);
            Console.WriteLine(spacing + moneyEarned + "kr");
        }

        /// <summary>
        /// Denna metod hämtar den bästa kunden i bokaffären.
        /// </summary>
        public void BestCustomer()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);

            var bestCustomer = API.BestCustomer(adminID);
            Console.WriteLine(spacing + $"The best customer is {bestCustomer.Name} - ID: {bestCustomer.ID}");
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metod ställer in så att en vanlig användare uppgraderas till adminstatus (IsAdmin = true);
        /// </summary>
        public void Promote()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "User ID: ");
            string userInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int userID = Convert.ToInt32(userInput);

            var promoteUser = API.Promote(adminID, userID);

            if (promoteUser == true)
            {
                Console.WriteLine(spacing + $"Promoted user.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (promoteUser == false)
            {
                Console.WriteLine(spacing + "Failed to promote user.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metoden nedgraderar en användare ifrån adminstatus till vanlig user (IsAdmin = false)
        /// </summary>
        public void Demote()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "User ID: ");
            string userInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int userID = Convert.ToInt32(userInput);

            var demoteUser = API.Demote(adminID, userID);

            if (demoteUser == true)
            {
                Console.WriteLine(spacing + $"Demoted user.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (demoteUser == false)
            {
                Console.WriteLine(spacing + "Failed to demote user.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metod aktiverar en avstängd/inaktiv användare.
        /// </summary>
        public void ActivateUser()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "User ID: ");
            string userInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int userID = Convert.ToInt32(userInput);

            var activateUser = API.ActivateUser(adminID, userID);

            if (activateUser == true)
            {
                Console.WriteLine(spacing + $"Activated user.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (activateUser == false)
            {
                Console.WriteLine(spacing + "Failed to activate user.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Denna metoden inaktiverar en användare.
        /// </summary>
        public void InactivateUser()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "User ID: ");
            string userInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int userID = Convert.ToInt32(userInput);

            var inactivateUser = API.InactivateUser(adminID, userID);

            if (inactivateUser == true)
            {
                Console.WriteLine(spacing + $"Inactivated user.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (inactivateUser == false)
            {
                Console.WriteLine(spacing + "Failed to inactivate user.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }
    }
}
