    
namespace WebbshopFrontEnd.Controllers.AdminControllers
{
    using Inlämning2;

    public static class AdminUserController
    {
        public static WebbShopAPI api = new WebbShopAPI();

        public static void ListAllUsers(int adminId)
        {
            api.Ping(adminId);

            var users = api.ListUsers(adminId);

        }

    }
}
