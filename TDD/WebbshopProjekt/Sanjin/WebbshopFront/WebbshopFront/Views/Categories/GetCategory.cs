using System;
using System.Collections.Generic;
using System.Text;
using InlamningDB2;
using InlamningDB2.Models;
using WebbshopFront.Controllers;
using WebbshopFront.Helpers;

namespace WebbshopFront.Views
{   
    public static class GetCategory
    {
        public static void ShowList(List<BookCategory> list)
        {
            Console.WriteLine("Välj en kategori:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i+1}. {list[i].Name}");
            }
        }

        public static int AskForCategoryName(List<BookCategory> list)
        {
            bool isNumeric = false;
            int userInPut;
            do
            {
                Rensaren.RensaRader();
                int counter = 1;
                foreach (var item in list)
                {                 
                    Console.WriteLine($"{counter}.{item.Name}");
                    counter++;
                }
                            
                isNumeric = int.TryParse(Console.ReadLine(), out userInPut);
            } while (isNumeric == false);

            return list[userInPut - 1].Id;
        }

        internal static void ShowBook(Books books)
        {
            Console.WriteLine($"Titel, {books.Titel}, Author,{books.Author}, Price{books.Price}, Amount,{books.Amount}");
        }

        public static int ShowBooks(List<Books> books)
        {
            bool isNumeric = false;
            int userInPut;

                int counter = 1;
                Console.WriteLine("Välj en bok");
                if (books.Count>0)
                {
                    foreach (var item in books)
                    {
                        Console.WriteLine($"{counter}.{item.Titel}\t{item.Amount}St\t\t\t{item.Price}:Kr");
                        counter++;
                    }
                }
                isNumeric = int.TryParse(Console.ReadLine(), out userInPut);
            if (isNumeric == true && userInPut >0 && userInPut <= books.Count)
            {
                return books[userInPut - 1].Id;
            }
            return 0;
        }

        internal static string AskforAuthor()
        {
            Console.Write("Villken författare söker du efter? : ");
            
            return Console.ReadLine();
        }

        public static string AskforCategoryName()
        {
            Console.Write("Villken kategori söker du efter? : ");
           
            return Console.ReadLine();
        }

        public static void Pause()
        {
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }

        public static string AskforBookName()
        {
            Console.Write("Villken bok söker du efter? : ");
            
            return Console.ReadLine();
        }

        public static bool AskToBuyBook(Books book)
        {
            Console.WriteLine($"Vill du köpa {book.Titel}?");

            return Console.ReadLine().ToLower() == "j";
        }
    }
}
