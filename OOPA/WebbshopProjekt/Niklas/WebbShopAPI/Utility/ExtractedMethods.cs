using System.Linq;
using WebbShopAPI.Data;

namespace WebbShopAPI.Utility
{
    public class ExtractedMethods
    {       
        private DBContext context = new DBContext();

        /// <summary>
        /// Renews session timer of user.
        /// </summary>
        /// <param name="userID"></param>
        public void RenewSessionTimer(int userID)
        {
            var adminUser = context.Users.FirstOrDefault(u => u.ID == userID);
            adminUser.SessionTimer.AddMinutes(15);
            var db = new DBContext();
            db.SaveChanges();
        }               
    }
}
