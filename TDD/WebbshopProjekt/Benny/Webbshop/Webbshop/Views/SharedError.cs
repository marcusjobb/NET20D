using System;
using System.Threading;
using Webbshop.Utils;
using webshopAPI;

namespace Webbshop.Views
{
    internal static class SharedError
    {
        /// <summary>
        /// Prints out failed
        /// </summary>
        public static void Failed()
        {
            SharedView.PrintWithRedText("\tMisslyckades.");
            GeneralViewHelper.WaitAndClearScreen();
        }

        /// <summary>
        /// Prints out that the user has entered wrong credentials
        /// </summary>
        /// <param name="user">takes a user to check if it is null</param>
        public static void PrintWrongCredentials(User user)
        {
            if (user == null)
            {
                SharedView.PrintWithRedText("\tFelaktigt användarnamn eller lösenord.");
                GeneralViewHelper.WaitAndClearScreen();
            }
        }

        /// <summary>
        /// Prints out that the user has entered wrong menu input
        /// </summary>
        public static void PrintWrongMenuInput()
        {
            SharedView.PrintWithRedText("\tFelaktigt menyval, försök igen.");
            GeneralViewHelper.WaitAndClearScreen();
        }

        /// <summary>
        /// Prints out success!
        /// </summary>
        public static void Success()
        {
            SharedView.PrintWithGreenText("\tLyckades!");
            GeneralViewHelper.WaitAndClearScreen();
        }

        /// <summary>
        /// Print out that there are still books in the book category 
        /// and also says how many books there are
        /// </summary>
        /// <param name="books">takes a integer with books still left in the category</param>
        internal static void BooksStillInCategory(int books)
        {
            SharedView.PrintWithRedText($"\tKan ej ta bort kategori. {books} böcker finns kvar i kategorin");
            Console.WriteLine("\tTryck enter för att fortsätta");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints out that the input was empty
        /// </summary>
        internal static void EmptyInput()
        {
            SharedView.PrintWithRedText("\tTom inmatning, vänligen ange något.");
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Prints out nothing found
        /// </summary>
        internal static void NothingFound()
        {
            SharedView.PrintWithRedText("\tInget hittades");
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Prints out wrong input (not specific a menu)
        /// </summary>
        internal static void PrintWrongInput()
        {
            SharedView.PrintWithRedText("\tFelaktig inmatning");
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Prints out that no change was made
        /// </summary>
        internal static void UnChanged()
        {
            SharedView.PrintWithRedText("\tIngen ändring har gjorts.");
            Thread.Sleep(2000);
        }
    }
}