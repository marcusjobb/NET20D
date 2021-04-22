using System;
using WebShopFrontend.View;
using WebShopAssignment;

namespace WebShopFrontend
{
    class Program
    {
        static void Main(string[] args)
        {
            WebShopAssignment.Helpers.Seeder.SeedUsers();
            WebShopAssignment.Helpers.Seeder.SeedBookTitles();
            WebShopAssignment.Helpers.Seeder.SeedCategories();

            StartView.StartMenu();

        }
    }
}
