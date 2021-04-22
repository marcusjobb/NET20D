using System;
using WebbShopAPI;

namespace WebshopApiFrontend.Utility
{
    public static class UserInputs
    {
        public static int LoggedInUser = Models.CurrentUser.LoggedInUser;
        /// <summary>
        /// Promts person for inputs for logging in to the service
        /// </summary>
        /// <returns></returns>
        public static int UserLogin() //Change naming conventions for input methods
        {
            Console.WriteLine("Enter username: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            var password = Console.ReadLine();
            return WebbshopAPI.Login(name, password);
        }
        /// <summary>
        /// Promts a new user for inputs to register for the shop
        /// </summary>
        /// <returns></returns>
        public static bool UserRegistration()
        {
            Console.WriteLine("Enter username: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Re-enter password: ");
            var verifyPassword = Console.ReadLine();

            var registration = WebbshopAPI.Register(name, password, verifyPassword);
            if (registration)
            {
                Console.WriteLine("Registration successful! You can now login");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Promts user to enter a keyword
        /// </summary>
        /// <returns></returns>
        public static string InputKeyword()
        {
            Console.WriteLine("Enter Keyword: ");
            return Console.ReadLine();
        }
        /// <summary>
        /// Promts user to enter an Id
        /// </summary>
        /// <returns></returns>
        public static int InputId()
        {
            Console.WriteLine("Enter Id: ");
            return IntInputValidation();
        }
        /// <summary>
        /// Validates an input to secure that is was an integer
        /// </summary>
        /// <returns></returns>
        public static int IntInputValidation()
        {
            var input = Console.ReadLine();
            if (Int32.TryParse(input, out int intInput))
            {
                return intInput;
            }
            else
            {
                Console.WriteLine(Errorhandeling.NotValidDefaultValueSet);
                return 0;
            }
        }
        /// <summary>
        /// Promts Admin to enter inputs for AddBook to be returned
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string, int, int> AddBookInputs()
        {
            Console.WriteLine("Enter Book title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Author name: ");
            string author = Console.ReadLine();
            Console.WriteLine("Enter Book price: ");
            int price = IntInputValidation();
            Console.WriteLine("Enter Book amount");
            int amount = IntInputValidation();
            return Tuple.Create(title, author, price, amount);
        }
        /// <summary>
        /// Promts Admin to input a category string
        /// </summary>
        /// <returns></returns>
        public static string InputCategoryString()
        {
            Console.WriteLine("Enter Category name: ");
            return Console.ReadLine();
        }
        /// <summary>
        /// promts Admin to enter inputs for new User to be returned
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string> AddUserInputs()
        {
            Console.WriteLine("Enter Username: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter User password: ");
            string password = Console.ReadLine();
            return Tuple.Create(name, password);
        }
        /// <summary>
        /// Promts user to enter a categoryId for validation
        /// </summary>
        /// <returns></returns>
        public static int InputCategoryId()
        {
            Console.WriteLine("Enter category Id: ");
            var categoryId = IntInputValidation();
            if(categoryId!=0)
            {
                return categoryId;
            }
            return 0;
        }
        /// <summary>
        /// Promts user to enter a bookId for validation
        /// </summary>
        /// <returns></returns>
        public static int BookIdInputs()
        {
            Console.WriteLine("Enter bookId: ");
            var bookId = IntInputValidation();
            if (bookId != 0)
            {
                return bookId;
            }
            return 0;
        }
        /// <summary>
        /// Promts Admin to enter inputs to be returned
        /// </summary>
        /// <returns></returns>
        public static Tuple<int, string, string, int> UpdateBookInputs()
        {
            Console.WriteLine("Enter Book id: ");
            int bookId = InputId();
            Console.WriteLine("Enter Book title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Book author: ");
            string author = Console.ReadLine();
            Console.WriteLine("Enter Book price");
            int price = IntInputValidation();
            return Tuple.Create(bookId, title, author, price);
        }
    }
}
