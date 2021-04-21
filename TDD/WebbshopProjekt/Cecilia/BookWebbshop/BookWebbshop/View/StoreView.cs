using BookWebbshop.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using WebbShopAPI;

namespace BookWebbshop.View
{
    class StoreView
    {
        public void Store()
        {
            var con = new StoreController();
            bool run = true;
            int userID = 0;

            while (run)
            {
                Console.WriteLine("\n------------------------------" +
                "\n BokShoppen" +
                "\n1. Se alla kategorier" +
                "\n2. Sök efter kategori" +
                "\n3. Sök böcker av författare" +
                "\n4. Köp bok" +
                "\n5. Registrera" +
                "\n6. Logga in" +
                "\n7. Logga ut" +
                "\n8. Adminsida" +
                "\n9. Avsluta"+
                "\n------------------------------");

                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        con.ListCategories(userID);
                        break;

                    case 2:
                        con.SearchCategories(userID);
                        break;

                    case 3:
                        con.SearchBooksByAuthor(userID);
                        break;

                    case 4:
                        con.BookPurchase(userID);
                        break;

                    case 5:
                        con.RegisterUser();
                        break;

                    case 6:
                        userID = con.LogInUser();
                        break;

                    case 7:
                        userID = con.LogOutUser(userID);
                        break;

                    case 8:
                        Admin();
                        break;

                    case 9:
                        con.LogOutUser(userID);
                        run = false;
                        break;
                }
            }
        }

        private void Admin()
        {
            var adm = new AdminController();
            var api = new WebbshopAPI();

            int admin = adm.LogInAdmin();
            bool aRun = true;

            if (admin > 0)
            {
                while (aRun)
                {
                    Console.WriteLine("\n------------------------------" +
                    "\n BokShoppen - Admin" +
                    "\n------------------------------" +
                    "\n1. Se alla användare" +
                    "\n2. Lägg till användare" +
                    "\n3. Sök användare" +
                    "\n------------------------------" +
                    "\n4. Lägg till bok" +
                    "\n5. Lägg till Kategori" +
                    "\n6. Lägg till bok i kategori" +
                    "\n------------------------------" +
                    "\n7. Uppdatera bok" +
                    "\n8. Uppdatera en boks antal" +
                    "\n9. Uppdatera kategori" +
                    "\n------------------------------" +
                    "\n10. Ta bort bok" +
                    "\n11. Ta bort kategori" +
                    "\n------------------------------" +
                    "\n12. Avsluta och logga ut" +
                    "\n------------------------------");

                    int ainput = Convert.ToInt32(Console.ReadLine());

                    switch (ainput)
                    {
                        case 1:
                            api.ListUsers(admin);
                            break;

                        case 2:
                            adm.AddUser(admin);
                            break;

                        case 3:
                            adm.SearchUser(admin);
                            break;

                        case 4:
                            adm.AddBook(admin);
                            break;

                        case 5:
                            adm.AddCategory(admin);
                            break;

                        case 6:
                            adm.AddBookToCategory(admin);
                            break;

                        case 7:
                            adm.UpdateBook(admin);
                            break;

                        case 8:
                            adm.UpdateBookAmount(admin);
                            break;

                        case 9:
                            adm.UpdateCategory(admin);
                            break;

                        case 10:
                            adm.DeleteBook(admin);
                            break;

                        case 11:
                            adm.DeleteCategory(admin);
                            break;

                        case 12:
                            aRun = false;
                            api.Logout(admin);
                            break;
                    }
                }

            }
            
        }
    }
}
