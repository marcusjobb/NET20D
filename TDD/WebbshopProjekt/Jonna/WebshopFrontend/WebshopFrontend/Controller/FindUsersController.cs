using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class FindUsersController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that displays users from the database
        /// They are displayed nicely thanks to the ConsoleTablExt
        /// If no users are found a error message will be shown
        /// </summary>
        public static void FindUsersLogic()
        {
            string searchForUser;
            searchForUser = Console.ReadLine();
            var usersList = api.FindUser(LoginController.userId, searchForUser);
            var tableData = new List<List<object>>();
            tableData.Add(new List<object>() { "Id", "Name", "Last login" });
            int count = 0;

            foreach (var user in usersList)
            {
                tableData.Add(new List<object>() { user.Id, user.Name, user.LastLogin });
                count++;
            }
            if (count == 0)
            {
                CenterText.PrintLinesInCenter(
                "╔════════════════════════════════════════════╗",
                "║  No users matched with your search keyword ║",
                "╚════════════════════════════════════════════╝");
            }
            else
            {
                ConsoleTableBuilder.From(tableData)
                .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
                .ExportAndWriteLine(TableAligntment.Center);
            }
        }

    }
}
