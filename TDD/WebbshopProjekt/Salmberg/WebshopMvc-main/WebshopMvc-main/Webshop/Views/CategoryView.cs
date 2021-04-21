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
    internal class CategoryView
    {
        /// <summary>
        /// Creates and prints Category object table
        /// </summary>
        /// <param name="categoryData"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> CategoryListReader(List<List<object>> categoryData)
        {
            Console.Clear();
            Console.WriteLine();
            ConsoleTableBuilder.From(categoryData)
               .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
               .WithTitle("Categories", ConsoleColor.Black, ConsoleColor.White, TextAligntment.Center)
               .WithColumn("Id", "Name")
               .ExportAndWriteLine(TableAligntment.Center);
            Prompts.ClearAndContinue();
            return categoryData;
        }
    }
}