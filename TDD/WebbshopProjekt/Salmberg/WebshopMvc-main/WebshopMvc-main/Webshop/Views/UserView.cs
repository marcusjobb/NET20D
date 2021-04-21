using ConsoleTableExt;
using System;
using System.Collections.Generic;
using WebshopMVC.Views.Messages;

namespace WebshopMVC.Views
{
    /// <summary>
    /// View class for creating and printing table of User objects. NuGet ConsoleTablesExt used.
    /// NuGet repository: https://github.com/minhhungit/ConsoleTableExt/
    /// </summary>
    internal class UserView
    {
        /// <summary>
        /// Creates and prints User object table
        /// </summary>
        /// <param name="userData"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> UserListReader(List<List<object>> userData)
        {
            if (userData.Count > 0)
            {
                Console.WriteLine();
                ConsoleTableBuilder.From(userData)
                   .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
                   .WithTitle("Users", ConsoleColor.Black, ConsoleColor.White, TextAligntment.Center)
                   .WithColumn("Id", "Name", "Password", "Last login", "Sessiontimer", "Is active","IsAdmin")
                   .ExportAndWriteLine(TableAligntment.Center);
                Prompts.ClearAndContinue();
            }
            return userData;
        }
    }
}