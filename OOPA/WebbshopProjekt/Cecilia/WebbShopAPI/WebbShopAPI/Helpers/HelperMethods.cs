using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI.Helpers
{
    class HelperMethods
    {
        public void SessionCheck(int userId)
        {
            using (var db = new WScontext())
            {
                var api = new WebbshopAPI();

                var user = db.Users.
                    FirstOrDefault(
                    u => u.Id == userId
                    );

                if (user != null) 
                {
                    if (DateTime.Now > user.SessionTimer.AddMinutes(15))
                    {
                        api.Logout(userId);
                    }
                    else
                    {
                        user.SessionTimer = DateTime.Now;
                        db.Users.Update(user);
                        db.SaveChanges();
                    }
                }
            } 
        }

        public bool AdminCheck(int userID)
        {
            using (var db = new WScontext())
            {
                var user = db.Users.
                    FirstOrDefault(
                    u => u.Id == userID
                    );

                if (user != null && user.IsAdmin == true && user.IsActive == true)
                {
                    return true;
                }

                return false;
            }
            
        }
    }
}
