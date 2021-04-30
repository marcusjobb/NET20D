using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik;

namespace Bookshop.Controllers
{
    class MenuController
    {
        Menu menu = new Menu();

        /// <summary>
        /// Handles the logic for the menu.
        /// </summary>
        /// <param name="options">The options for the menu.</param>
        /// <returns>The selected option.</returns>
        public int Menu(List<string> options, bool useRightArrow)
        {
            int selectedOption = 0;
            ConsoleKeyInfo pressedKey;

            do
            {
                Console.CursorTop = 9;

                menu.PrintMenu(options, selectedOption);

                pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        selectedOption++;

                        if (selectedOption > options.Count - 1)
                        {
                            selectedOption = 0;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        selectedOption--;

                        if (selectedOption < 0)
                        {
                            selectedOption = options.Count - 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (useRightArrow == true)
                        {
                            selectedOption = 99;
                        }
                        break;
                }

                if (selectedOption == 99)
                {
                    return selectedOption;
                }
            } while (pressedKey.Key != ConsoleKey.Enter);

            return selectedOption;
        }

        /// <summary>
        /// Handels the logic for the message window.
        /// </summary>
        /// <returns>The selected option.</returns>
        public int MessageWindow()
        {
            int selectedOption = 0;
            ConsoleKeyInfo pressedKey;

            do
            {
                Console.CursorLeft = 45;

                menu.PrintMessageBox(selectedOption);

                pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        selectedOption = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        selectedOption = 1;
                        break;
                }
            } while (pressedKey.Key != ConsoleKey.Enter);

            return selectedOption;
        }

        /// <summary>
        /// Handles the logic for the main-content menu.
        /// </summary>
        /// <param name="options">The options for the menu.</param>
        /// <returns>The selected option.</returns>
        public int MainContentMenu(List<Webbutik.Models.Book> options)
        {
            int selectedOption = 0;
            int id = 0;

            ConsoleKeyInfo pressedKey;

            do
            {
                Console.CursorTop = 9;

                menu.PrintBookList(options, selectedOption);
                id = options[selectedOption].Id;

                pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        selectedOption++;

                        if (selectedOption > options.Count - 1)
                        {
                            selectedOption = 0;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        selectedOption--;

                        if (selectedOption < 0)
                        {
                            selectedOption = options.Count - 1;
                        }
                        break;
                }
            } while (pressedKey.Key != ConsoleKey.Enter);

            return id;
        }

        /// <summary>
        /// Handles the logic for the main-content menu.
        /// </summary>
        /// <param name="options">The options for the menu.</param>
        /// <returns>The selected option.</returns>
        public int MainContentMenu(List<Webbutik.Models.BookCategory> options)
        {
            int selectedOption = 0;
            int id = 0;

            ConsoleKeyInfo pressedKey;

            do
            {
                Console.CursorTop = 9;

                menu.PrintCategoryList(options, selectedOption);
                id = options[selectedOption].Id;

                pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        selectedOption++;

                        if (selectedOption > options.Count - 1)
                        {
                            selectedOption = 0;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        selectedOption--;

                        if (selectedOption < 0)
                        {
                            selectedOption = options.Count - 1;
                        }
                        break;
                }
            } while (pressedKey.Key != ConsoleKey.Enter);

            return id;
        }

        /// <summary>
        /// Handles the logic for the main-content menu.
        /// </summary>
        /// <param name="options">The options for the menu.</param>
        /// <returns>The selected option.</returns>
        public int MainContentMenu(List<Webbutik.Models.User> options)
        {
            int selectedOption = 0;
            int id = 0;

            ConsoleKeyInfo pressedKey;

            do
            {
                Console.CursorTop = 9;

                menu.PrintUserList(options, selectedOption);
                id = options[selectedOption].Id;

                pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        selectedOption++;

                        if (selectedOption > options.Count - 1)
                        {
                            selectedOption = 0;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        selectedOption--;

                        if (selectedOption < 0)
                        {
                            selectedOption = options.Count - 1;
                        }
                        break;
                }
            } while (pressedKey.Key != ConsoleKey.Enter);

            return id;
        }
    }
}
