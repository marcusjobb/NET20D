using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class SearchCategoryByNameController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method That lets the user Search for a category based on its name
        /// Result is displayed nicely thanks to the ConsoleTablExt
        /// If theres no result theres an error message to be displayed
        /// </summary>
        public static void SearchCategoryByNameLogic()
        {
            string categorySearch;
            categorySearch = Console.ReadLine();
            Console.Clear();
            var catList = api.GetCategories(categorySearch);
            var tableData = new List<List<object>>();
            tableData.Add(new List<object>() { "Id", "Category name", });
            int count = 0;

            foreach (var cat in catList)
            {
                tableData.Add(new List<object>() { cat.Id, cat.Name });
                count++;
            }

            if (count == 0)
            {
                CenterText.PrintLinesInCenter(
                "╔══════════════════════════════════════════════════╗",
                "║  No categories matched with your search keyword  ║", 
                "╚══════════════════════════════════════════════════╝");
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
