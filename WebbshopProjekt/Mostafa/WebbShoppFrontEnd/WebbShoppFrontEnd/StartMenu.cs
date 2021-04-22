using System;
using System.Collections.Generic;
using System.Text;
using WebbShoppFrontEnd;

namespace WebbShoppFrontEnd
{
    public class StartMenu
    {
        ProgrammingClass pc = new ProgrammingClass();
        

        public void Menu()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Logout");
            Console.WriteLine("3. Getcategories");
            Console.WriteLine("4. GetCategory");
            Console.WriteLine("5. GetAvailableBooks");
            Console.WriteLine("6. GetBook");
            Console.WriteLine("7. GetBooks");
            Console.WriteLine("8. GetAuthors");
            Console.WriteLine("9. BuyBook");
            Console.WriteLine("10. Ping");
            Console.WriteLine("11. Register");
            Console.WriteLine("12. AddBook");
            Console.WriteLine("13. ListOfUsers");
            Console.WriteLine("14. FindUser");
            Console.WriteLine("15. UpdateBook");
            Console.WriteLine("16. DeleteBook");
            Console.WriteLine("17. AddCategory");
            Console.WriteLine("18. AddBookToCategory");
            Console.WriteLine("19. UpdateCategory");
            Console.WriteLine("20. DeleteCategory");
            Console.WriteLine("21. AddUser");

            while (true)
            {
                try
                {

                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        pc.LogIn();
                    }
                    else if (choice == 2)
                    {
                        pc.LogOut();
                    }
                    else if (choice == 3)
                    {
                        pc.GetCategories();
                    }
                    else if (choice == 4)
                    {
                        pc.GetCategory();
                    }
                    else if (choice == 5)
                    {
                        pc.GetAvailableBooks();

                    }
                    else if (choice == 6)
                    {
                        pc.GetBook();
                    }
                    else if (choice == 7)
                    {
                        pc.GetBooks();
                    }
                    else if (choice == 8)
                    {
                        pc.GetAuthors();
                    }
                    else if (choice == 9)
                    {
                        pc.BuyBook();
                    }
                    else if (choice == 10)
                    {
                        pc.Ping();
                    }
                    else if (choice == 11)
                    {
                        pc.Register();
                    }
                    else if (choice == 12)
                    {
                        pc.AddBook();
                    }
                    else if (choice == 13)
                    {
                        pc.ListOfUsers();
                    }
                    else if (choice == 14)
                    {
                        pc.FindUser();
                    }
                    else if (choice == 15)
                    {
                        pc.UpdateBook();
                    }
                    else if (choice == 16)
                    {
                        pc.DeleteBook();
                    }
                    else if (choice == 17)
                    {
                        pc.AddCategory();
                    }
                    else if (choice == 18)
                    {
                        pc.AddBookToCategory();
                    }
                    else if (choice == 19)
                    {
                        pc.UpdateCategory();
                    }
                    else if (choice == 20)
                    {
                        pc.DeleteCategory();
                    }
                    else if (choice == 21)
                    {
                        pc.AddUser();
                    }



                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


        }

    }
}
