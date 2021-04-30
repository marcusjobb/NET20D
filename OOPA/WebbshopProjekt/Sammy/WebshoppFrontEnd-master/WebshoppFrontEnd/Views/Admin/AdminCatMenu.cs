
namespace WebbshopFrontEnd.Views.Admin
{
    using Inlämning2;
    using System;
    using WebbshopFrontEnd.Controllers.AdminControllers;

    public static class AdminCatMenu
    {
        public static WebbShopAPI api = new WebbShopAPI();
        
        /// <summary>
        /// Vyn för att lägga till en kategori.
        /// </summary>
        /// <returns></returns>
        public static string AddCatMenu()
        {
            Console.Write("Ange ett namn på kategori som du vill lägga till: ");
            return Console.ReadLine();

        }

        public static (int, string) ShowAddCatToBook()
        {
            Console.Write("Ange ett sökord på bokens title som du söker: ");
            var books = api.GetBooks(Console.ReadLine());
            Console.WriteLine("Hitta följande bok/böcker");
            foreach (var b in books) { Console.WriteLine($"BokID: {b.BookId} - Titel: {b.Title}"); }
            Console.Write("Var god och ange bokens ID som du vill lägga kategori på: ");
            var bookId = int.Parse(Console.ReadLine());
            Console.Write("Ange namnet på kategori: ");
            var catName = Console.ReadLine();
            return (bookId, catName);
        }

        /// <summary>
        /// Vyn för hantering av kategori.
        /// </summary>
        /// <param name="adminId"></param>
        public static void ShowCatMenu(int adminId)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("************************");
                Console.WriteLine("*   Adminstratörsmeny  *");
                Console.WriteLine("************************\n");
                Console.WriteLine("Du har följande val");
                Console.WriteLine("[1]  Lägg till en kategori");
                Console.WriteLine("[2]  Lägg till kategori på en bok");
                Console.WriteLine("[3]  Uppdatera kategori");
                Console.WriteLine("[4]  Ta bort kartegori som saknas böcker");
                Console.WriteLine("[5]  Tillbaka till adminstratörmenyn.");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 4)
                    {
                        AdminViews.AdminMenu(adminId);
                        loop = false;
                    }
                    else { AdminChoiceController.CatMenuChoice(adminId, choice); }
                }
                catch { Message.ErrorInput(); }
            }
        }
    }
}
