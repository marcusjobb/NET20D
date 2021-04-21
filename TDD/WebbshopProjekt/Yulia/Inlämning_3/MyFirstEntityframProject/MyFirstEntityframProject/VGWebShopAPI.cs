using Microsoft.Extensions.Caching.Memory;
using MyFirstEntityframProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstEntityframProject
{
    public class VGWebShopAPI
    {
        private WebShopYulia db = new WebShopYulia();

        internal List<SoldBook> SoldItems(int adminId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin == true)
            {
                var soldItems = db.SoldBooks.OrderBy(s => s.PurchasedDate).ToList();
                foreach (var item in soldItems)
                {
                    Console.WriteLine(item.Title, item.PurchasedDate);
                }
                return db.SoldBooks.ToList();
            }
            else
            {
                Console.WriteLine("You need to be logged in as administrator to use this function");
                return null;
            }
        }
        //internal int MoneyEarned(int adminId)
        //{

        //}
        //internal int BestCustomer(int adminId)
        //{

        //}
        internal bool Promote(int adminId, int userId)
        {
            return false;
        }
        internal bool Demote(int adminId, int userId)
        {
            return false;
        }
        internal bool InactivateUser(int adminId, int userId)
        {
            return false;
        }
        internal bool ActivateUser(int adminId, int userId)
        {
            return false;
        }
    }
}
