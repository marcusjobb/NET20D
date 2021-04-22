using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class ListUsersController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that will display all users nicely thanks to ConsoleTablExt Nuget.
        /// If no users were displayed, a error message will be shown
        /// </summary>
        public static void ShowAllUsersLogic()
        {
            var userList = api.ListUsers(LoginController.userId);
            var tableData = new List<List<object>>();
            tableData.Add(new List<object>() { "Id", "Name", "Last login"});
            int count = 0;

            foreach (var user in userList)
            {
                tableData.Add(new List<object>() {user.Id, user.Name,  user.LastLogin});
                count++;
            }

            if(count == 0)
            {
                CenterText.PrintLinesInCenter(
                "╔═════════════════════════════════╗",
                "║  There was no users to display  ║",
                "╚═════════════════════════════════╝");
            } else { 
                ConsoleTableBuilder.From(tableData)
                .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
                .ExportAndWriteLine(TableAligntment.Center);
            }
        }
    }
}
