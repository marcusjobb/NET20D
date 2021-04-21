using System;
using System.Collections.Generic;
using System.Linq;
using webshopAPI;
using webshopAPI.Models;

namespace Webbshop.Views
{
    internal static class AdminView
    {
        /// <summary>
        /// Print the main menu option when admin logs in.
        /// </summary>
        public static void Print()
        {
            Console.Clear();
            SharedView.PrintWithDarkGreyText("Administratoralternativ");
            Console.WriteLine("\t1. Adminfunktioner");
            Console.WriteLine("\t2. Handla böcker");
            Console.WriteLine("\tX. Logga ut");
        }

        /// <summary>
        /// Prints the admin functions
        /// </summary>
        public static void PrintAdminFunctions()
        {
            Console.Clear();
            SharedView.PrintWithDarkGreyText("Administratorfunktioner\n");
            Console.WriteLine();
            SharedView.PrintWithDarkGreyText($"Användaralternativ");
            Console.WriteLine($"\t1. Lägg till användare");
            Console.WriteLine($"\t2. Lista alla användare");
            Console.WriteLine($"\t3. Sök en användare");
            Console.WriteLine();
            SharedView.PrintWithDarkGreyText($"Bokmeny - Admin");
            Console.WriteLine($"\t4. Lägg till en bok");
            Console.WriteLine($"\t5. Ta bort en bok");
            Console.WriteLine($"\t6. Sök efter en bok");
            Console.WriteLine($"\t7. Lista alla böcker");
            Console.WriteLine();
            SharedView.PrintWithDarkGreyText($"Kategorihantering - Admin");
            Console.WriteLine($"\t8. Lägg till en kategori");
            Console.WriteLine($"\t9. Ta bort en kategori");
            Console.WriteLine($"\t10. Uppdatera en kategori");
            Console.WriteLine();
            SharedView.PrintWithDarkGreyText($"Statistik - Admin");
            Console.WriteLine($"\t11. Sålda böcker");
            Console.WriteLine($"\t12. Intjänade kronor");
            Console.WriteLine($"\t13. Bästa kunden");
            Console.WriteLine();
            Console.WriteLine($"\tX. Backa ett steg");
        }

        /// <summary>
        /// prints options for adding a book and asks the user for input, 
        /// returning those options to controller for managing the book creation.
        /// </summary>
        /// <returns>returns a dictionary with neccessary things for creating a book</returns>
        internal static Dictionary<string, string> AddBook()
        {
            SharedView.PrintWithDarkGreyText("Lägg till en bok");
            var bookInformation = AskForInputToCreateBook();
            return bookInformation;
        }

        /// <summary>
        /// Prints options for add category
        /// </summary>
        internal static void AddCategory()
        {
            SharedView.PrintWithDarkGreyText("Lägg till en kategori.");
            Console.Write("\tAnge den nya kategorins namn >");
        }
        /// <summary>
        /// Asks user for username and password, and returns this
        /// </summary>
        /// <returns>Username and password for creating a user</returns>
        internal static (string userName, string password) AddUser()
        {
            Console.Clear();
            SharedView.PrintWithDarkGreyText("Lägg till en användare");
            Console.Write("\tAnge användarnamn >");
            var userName = Console.ReadLine();
            Console.Write("\tAnge lösenord >");
            var password = Console.ReadLine();
            return (userName, password);
        }

        /// <summary>
        /// Prints out the best customer.
        /// </summary>
        /// <param name="bestCustomer"></param>
        internal static void BestCustomer((User, int) bestCustomer)
        {
            Console.Clear();
            SharedView.PrintWithDarkGreyText("The best customer");
            Console.WriteLine($"{bestCustomer.Item1.Name} " +
                $"är den bästa kunden med {bestCustomer.Item2} " +
                $"köpta böcker");
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints out the options for changing the author
        /// </summary>
        internal static void ChangeAuthor()
        {
            Console.Write("Ange ny författare >");
        }

        /// <summary>
        /// Prints out the change category options
        /// </summary>
        /// <param name="book"></param>
        /// <param name="categories"></param>
        internal static void ChangeCategory(Book book, List<BookCategory> categories)
        {
            SharedView.PrintWithDarkGreyText($"Lägg till/ändra kategori för boken {book.Title}");
            Console.WriteLine();
            SharedView.ListCategories(categories);
        }

        /// <summary>
        /// Prints the options for changing price of a book
        /// </summary>
        internal static void ChangePrice()
        {
            Console.Write("Ange nytt pris >");
        }

        /// <summary>
        /// Prints the options for changing title of a book
        /// </summary>
        internal static void ChangeTitle()
        {
            Console.Write("Ange ny boktitel >");
        }

        /// <summary>
        /// Prints the options for deleting of a book
        /// </summary>
        internal static void DeleteBook(Book book)
        {
            SharedView.PrintWithDarkGreyText("Ta bort böcker");
            Console.WriteLine($"\tHur många vill du ta bort av boken {book.Title}?");
        }

        /// <summary>
        /// Prints the options for deleting of a category
        /// </summary>
        internal static void DeleteCategory()
        {
            SharedView.PrintWithDarkGreyText("Ta bort en kategori.");
            Console.WriteLine("\tVälj kategori nedan att ta bort, eller tryck x+enter för att avbryta.");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the options for earnings of sold books
        /// </summary>
        internal static void Earnings(int money)
        {
            Console.Clear();
            SharedView.PrintWithDarkGreyText("Omsättning av sålda böcker");
            Console.WriteLine($"\tOmsättning - {money}kr ");
            Console.WriteLine("\tTryck enter för att fortsätta");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints the options editing a user
        /// </summary>
        internal static void EditUser(User editUser)
        {
            Console.Clear();
            SharedView.PrintWithDarkGreyText($"Edit user {editUser.Name}");
            Console.WriteLine($"\t {editUser.Name} har administratörsrättigheter: {editUser.IsAdmin}");
            Console.WriteLine($"\t {editUser.Name} är aktiv: {editUser.IsActive}");
            Console.WriteLine();
            Console.WriteLine("\t1. Ge användaren administratorrättigheter");
            Console.WriteLine("\t2. Gör användaren till standardanvändare");
            Console.WriteLine("\t3. Aktivera användaren");
            Console.WriteLine("\t4. Inaktivera användaren");
            Console.WriteLine();
            Console.WriteLine("\tX. Backa ett steg");
        }

        /// <summary>
        /// Prints all users in a list
        /// </summary>
        /// <param name="listWithUsers">Takes a list with users</param>
        internal static void ListAllUsers(List<User> listWithUsers)
        {
            SharedView.PrintWithDarkGreyText("Lista med alla användare");

            for (int i = 0; i < listWithUsers.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {listWithUsers[i]}");
            }
        }

        /// <summary>
        /// Prints all options for searching a user.
        /// </summary>
        /// <param name="admin">Takes the admin options just for using the ping function</param>
        internal static void SearchForUser(User admin)
        {
            Console.Clear();
            WebShopApi api = new WebShopApi();
            SharedView.PrintWithDarkGreyText(api.Ping(admin.Id));
            SharedView.PrintWithDarkGreyText("Sök efter användare");
            Console.Write("\tSökord >");
        }

        /// <summary>
        /// Prints the options for setting amount of a book
        /// </summary>
        internal static void SetAmount()
        {
            SharedView.PrintWithDarkGreyText("Ändra antal tillgängliga böcker");
            Console.WriteLine("\tDu kan ange ett posivt tal för att lägga till bok eller ange " +
                "- framför för att ta bort det antalet böcker.");
            Console.WriteLine();
            Console.Write("\tAnge antal du vill lägga till eller ta bort");
        }

        /// <summary>
        /// Printing a list with sold books
        /// </summary>
        /// <param name="listWithSoldBooks">Takes a list with sold books</param>
        internal static void SoldBooks(List<SoldBook> listWithSoldBooks)
        {
            Console.Clear();
            listWithSoldBooks = listWithSoldBooks.OrderBy(b => b.Title).ToList();
            SharedView.PrintWithDarkGreyText("Lista med sålda böcker");
            foreach (var book in listWithSoldBooks)
            {
                Console.WriteLine($"{book.Title}\n{book.Price}kr\nköpt av användare med id: {book.UserId}");
                Console.WriteLine("-----------------------------------------");
            }
            Console.WriteLine("\tTryck enter för att gå vidare");
            Console.ReadKey();
        }

        /// <summary>
        /// Printing options for updating a book
        /// </summary>
        /// <param name="book">Takes a book to change</param>
        internal static void UpdateBook(Book book)
        {
            SharedView.PrintWithDarkGreyText($"Bokalternativ för {book.Title} - {book.Category.Name}");
            Console.WriteLine($"\t{book.Title} finns det {book.Amount}st av i lager.");
            Console.WriteLine($"\tBoken är skriven av {book.Author} ");
            Console.WriteLine();
            Console.WriteLine("\t1. Lägg till fler av denna bok");
            Console.WriteLine("\t2. Uppdatera bokinformation");
            Console.WriteLine("\t3. Lägg till kategori till bok");
            Console.WriteLine("\t4. Ta bort bok");
            Console.WriteLine();
            Console.WriteLine("\tX. Backa ett steg");
        }

        /// <summary>
        /// Printing options for updating specific book info
        /// </summary>
        /// <param name="book">takes a book to change</param>
        internal static void UpdateBookInfo(Book book)
        {
            SharedView.PrintWithDarkGreyText($"Uppdatera {book.Title}");
            Console.WriteLine($"\tBoken är skriven av {book.Author}.");
            Console.WriteLine($"\tDen kostar {book.Price}kr");
            try
            {
                Console.WriteLine($"\toch ligger i kategorin {book.Category.Name}");
            }
            catch
            {
                SharedView.PrintWithRedText("\tBoken ligger inte knuten till någon kategori");
            }

            Console.WriteLine();
            Console.WriteLine("\t1. Ändra titel");
            Console.WriteLine("\t2. Ändra författare");
            Console.WriteLine("\t3. Ändra pris");
            Console.WriteLine("\t4. Ändra kategori");
            Console.WriteLine();
            Console.WriteLine("\tX. Backa ett steg");
        }

        /// <summary>
        /// Prints the option for updating a category
        /// </summary>
        /// <param name="category">takes a category name for printing it´s name</param>
        internal static void UpdateCategory(string category)
        {
            SharedView.PrintWithDarkGreyText($"Uppdatera kategorinamnet för {category}.");
            Console.WriteLine("\tTryck enter för att lämna kategorin oförändrad");
            Console.WriteLine();
            Console.Write("\tAnge den nya kategorins namn >");
        }

        /// <summary>
        /// Print options for updating a category 
        /// </summary>
        internal static void UpdateCategory()
        {
            SharedView.PrintWithDarkGreyText("Uppdatera en kategori.");
            Console.WriteLine("\tVälj kategori nedan att uppdatera, eller tryck x+enter för att avbryta.");
            Console.WriteLine();
        }

        /// <summary>
        /// Asks the user for input to create a book
        /// </summary>
        /// <returns>dictionary with info to create book</returns>
        private static Dictionary<string, string> AskForInputToCreateBook()
        {
            Dictionary<string, string> askUserForThisInput = new Dictionary<string, string> {
                { "Titel", "" },
                { "Författare", "" },
                { "Pris", "" },
                { "Antal", "" }
            };

            for (int i = 0; i < askUserForThisInput.Count; i++)
            {
                var element = askUserForThisInput.ElementAt(i);
                var continueLoop = true;
                do
                {
                    Console.Clear();
                    SharedView.PrintWithDarkGreyText("Lägg till information för att skapa en bok");
                    Console.Write($"\t{element.Key} >");
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input)
                        || string.IsNullOrWhiteSpace(input))
                    {
                        SharedError.PrintWrongInput();
                        continue;
                    }

                    if (int.TryParse(input, out int number))
                    {
                        if (number > 0)
                        {
                            askUserForThisInput[element.Key] = input;
                            continueLoop = false;
                        }
                        else
                        {
                            continueLoop = true;
                            SharedError.PrintWrongInput();
                        }
                    }
                    else if (!(element.Key == "Pris" || element.Key == "Antal"))
                    {
                        askUserForThisInput[element.Key] = input;
                        continueLoop = false;
                    }
                } while (continueLoop);
            }
            return askUserForThisInput;
        }
    }
}