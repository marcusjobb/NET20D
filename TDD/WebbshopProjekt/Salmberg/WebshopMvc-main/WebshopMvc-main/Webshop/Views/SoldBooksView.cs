using ConsoleTableExt;
using System;
using System.Collections.Generic;
using WebshopMVC.Views.Messages;

namespace WebshopMVC.Views
{
    /// <summary>
    /// View class for creating and printing table of Category objects. NuGet ConsoleTablesExt used.
    /// NuGet repository: https://github.com/minhhungit/ConsoleTableExt/
    /// </summary>
    internal class SoldBooksView
    {
        /// <summary>
        /// Creates and prints SoldBook object table
        /// </summary>
        /// <param name="soldBooksData"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> SoldBooksListReader(List<List<object>> soldBooksData)
        {
            Console.Clear();
            Console.WriteLine();
            ConsoleTableBuilder.From(soldBooksData)
               .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
               .WithTitle("Sold books", ConsoleColor.Black, ConsoleColor.White, TextAligntment.Center)
               .WithColumn("Id", "Title", "Author", "Price", "Amount", "Category Id")
               .ExportAndWriteLine(TableAligntment.Center);
            Prompts.ClearAndContinue();
            return soldBooksData;
        }
    }
}