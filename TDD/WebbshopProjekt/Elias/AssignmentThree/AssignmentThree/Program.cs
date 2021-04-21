using AssignmentTwo;
using AssignmentTwo.Database;
using AssignmentTwo.Models;
using AssignmentThree.Controllers;

namespace AssignmentThree
{
    public static class Program
    {
        public static WebbShopAPI API = new WebbShopAPI();
        public static User User = new User();

        private static void Main(string[] args)
        {
            Seeder.Seed();
            MenuController.MainMenu();
        }
    }
}