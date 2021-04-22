using ConsoleTableExt;
using System;
using System.Collections.Generic;
using WebshopMVC.Views.Messages;

namespace WebshopMVC.Views
{
    /// <summary>
    /// View class for creating and printing table of Book objects. NuGet ConsoleTablesExt used.
    /// NuGet repository: https://github.com/minhhungit/ConsoleTableExt/
    /// </summary>
    internal class BookView
    {
        /// <summary>
        /// Creates and prints Book object table
        /// </summary>
        /// <param name="bookData"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> BookListReader(List<List<object>> bookData)
        {
            Console.Clear();
            Console.WriteLine();
            ConsoleTableBuilder.From(bookData)
               .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
               .WithTitle("Books", ConsoleColor.Black, ConsoleColor.White, TextAligntment.Center)
               .WithColumn("Id", "Title", "Author", "Price", "Amount", "Category Id")
               .ExportAndWriteLine(TableAligntment.Center);
            Prompts.ClearAndContinue();
            return bookData;
        }
    }
}