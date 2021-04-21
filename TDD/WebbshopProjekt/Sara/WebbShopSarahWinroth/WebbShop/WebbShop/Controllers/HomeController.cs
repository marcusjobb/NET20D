namespace WebbShop.Controllers
{
    internal class HomeController
    {
        public static WebbShopApi.API api = new WebbShopApi.API();
        /// <summary>
        /// Uppdaterar databasen och anropar metoden AddData() som lägger till data i tabellerna.
        /// Sist anropas metoden som låter användaren Registrera sig eller Logga in
        /// </summary>
        public void Start()
        {
            WebbShopApi.Database.DatabaseCreator.Create();
            var seed = new WebbShopApi.Database.Seeder();
            seed.AddData();
            var userAccess = new UserAccessController();
            userAccess.UserVerification();
        }
    }
}