using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebbShopAPI.Database;
using WebbShopAPI.Model;

namespace WebbShopAPI.Controller
{
    static class StartSequence
    {
        /// <summary>
        /// Initioalizes the database
        /// </summary>
        /// <returns></returns>
        public static bool InitializeDB()
        {
            User u = new User();
            Console.WriteLine("Populating tables");
            using (var db = new WebbShopLeeContext())
            {
                db.Users.Where(_ => _.ID != 0);
                {
                    Console.WriteLine("Checking user count");
                    SeederClass.FillUserTable();
                    SeederClass.FillCategoryTable();
                    SeederClass.FillBooksTable();
                    return true;
                }
            //return false;
            }
        }
    }
}
