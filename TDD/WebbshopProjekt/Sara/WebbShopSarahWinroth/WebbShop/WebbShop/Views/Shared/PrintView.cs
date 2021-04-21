using System;

namespace WebbShop.Views.Shared
{
    public static class PrintView
    {
        /// <summary>
        /// Visar information om bok-objekt till användaren.
        /// </summary>
        public static void BookItem(string item)
        {
            Console.WriteLine(item);
            Console.WriteLine("***************************");
        }
        /// <summary>
        /// Visar information om kategori-objekt till användaren.
        /// </summary>
        public static void CategoryItem(string item)
        {
            Console.WriteLine("- " + item);
        }
        /// <summary>
        /// Visar information om objekt till användaren.
        /// </summary>
        public static void Item(string item)
        {
            Console.WriteLine(item);
        }
        /// <summary>
        /// Visar information om användar-objekt till användaren.
        /// </summary>
        public static void UserItem(string item)
        {
            Console.WriteLine(item);
            Console.WriteLine("***************************");
        }
    }
}