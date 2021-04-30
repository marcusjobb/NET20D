using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class ShowAllCategoriesController
    {
        //Fetch api
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();

        /// <summary>
        /// Controller for API method Show all categories
        /// All categories are added into a list thats displayed nicely thanks to the nuget ConsoleTableXt
        /// https://github.com/minhhungit/ConsoleTableExt/
        /// If there wont be any categories in the database, you get an error message
        /// </summary>
        public static void ShowAllCategoriesLogic()
        {
            var catList = api.GetCategories();
            var tableData = new List<List<object>>();
            tableData.Add(new List<object>() { "Id", "Category name",});
            int count = 0;

            foreach (var cat in catList)
            {
                tableData.Add(new List<object>() {cat.Id, cat.Name});
                count++;
            }

            if (count == 0)
            {
                CenterText.PrintLinesInCenter(
                "╔══════════════════════════════════════╗",
                "║  There was no Categories to display  ║",
                "╚══════════════════════════════════════╝");
            }
            else
            {
                ConsoleTableBuilder.From(tableData)
                .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
                .ExportAndWriteLine();
                Console.WriteLine();
            }
        }

    }
}
