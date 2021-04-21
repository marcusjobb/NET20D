using Inlm3.Controllers;
using Inlm3.Helpers;
using System;
using System.Linq;

namespace Inlm3.Views
{
    /// <summary>
    /// Klass för subMenyn som hanterar visandet av böcker
    /// </summary>
    internal class SubMenyBooksCRUD
    {
        private Controller controll = new Controller();

        /// <summary>
        /// Index för den här submenyn
        /// </summary>
        public void Index(int userID)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Set Amount");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Add Category");
                Console.WriteLine("6. Add book To Category");
                Console.WriteLine("7. Update Category");
                Console.WriteLine("8. Delete Category");
                Console.WriteLine("9. Sold Items");
                Console.WriteLine("10. Main Meny");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBook(userID);
                        Helper.NextStep();
                        break;

                    case "2":
                        SetAmount(userID);
                        Helper.NextStep();
                        break;

                    case "3":
                        UpdateBook(userID);
                        Helper.NextStep();
                        break;

                    case "4":
                        DeleteBook(userID);
                        Helper.NextStep();
                        break;

                    case "5":
                        AddCategory(userID);
                        Helper.NextStep();
                        break;

                    case "6":
                        AddBookToCategory(userID);
                        Helper.NextStep();
                        break;

                    case "7":
                        UpdateCategory(userID);
                        Helper.NextStep();
                        break;

                    case "8":
                        DeleteCategory(userID);
                        Helper.NextStep();
                        break;

                    case "9":
                        SoldItems(userID);
                        Helper.NextStep();
                        break;

                    case "10":
                        keepGoing = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Lägger till en bok. Felmeddlande om något steg inte fungerar. Exempelvis om userID != adminID
        /// </summary>
        public void AddBook(int userID)
        {
            Console.WriteLine("Please write the information below to add a book");

            if (controll.AddBook(userID))
            {
                Console.WriteLine("The book was sucessfully added");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Sätter amount av böcker. Felmeddlande om något steg inte fungerar. Exempelvis om userID != adminID
        /// </summary>
        public void SetAmount(int userID)
        {
            Console.WriteLine("Please write the bookID and amount:");
            if (controll.SetAmount(userID))
            {
                Console.WriteLine("Amount sucessfully set");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Uppdaterar informationen om en bok. Felmeddlande om något steg inte fungerar. Exempelvis om userID != adminID
        /// </summary>
        public void UpdateBook(int userID)
        {
            Console.WriteLine("Please write the information below to update a book");

            if (controll.AddBook(userID))
            {
                Console.WriteLine("The book was sucessfully updated");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Raderar en bok. Felmeddlande om något steg inte fungerar. Exempelvis om userID != adminID
        /// </summary>
        public void DeleteBook(int userID)
        {
            Console.WriteLine("Please write the information below to delete a book");

            if (controll.DeleteBook(userID))
            {
                Console.WriteLine("The book was sucessfully deleted");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Lägger till en bok. Felmeddlande om något steg inte fungerar. Exempelvis om userID != adminID
        /// </summary>
        public void AddCategory(int userID)
        {
            Console.WriteLine("Please write the information below to add a category");
            if (controll.AddCategory(userID))
            {
                Console.WriteLine("The category was sucessfully added!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Lägger till en bok till en kategori. Felmeddlande om något steg inte fungerar. Exempelvis om userID != adminID
        /// </summary>
        public void AddBookToCategory(int userID)
        {
            Console.WriteLine("Please write the information below to add a book to category");
            if (controll.AddBookToCategory(userID))
            {
                Console.WriteLine("The book was sucessfully added!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Updaterar en existernade kategori. Felmeddlande om något steg inte fungerar. Exempelvis om userID != adminID
        /// </summary>
        public void UpdateCategory(int userID)
        {
            Console.WriteLine("Please enter the information below to update a category");

            if (controll.UpdateCategory(userID))
            {
                Console.WriteLine("Category was sucessfully updated!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again!");
            }
        }

        /// <summary>
        /// Raderar en kategori. Felmeddlande om något steg inte fungerar. Exempelvis om userID != adminID
        /// </summary>
        public void DeleteCategory(int userID)
        {
            Console.WriteLine("Please write the information below too delete a category");
            if (controll.DeleteCategory(userID))
            {
                Console.WriteLine("The category was sucessfully deleted!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Listar sålda böcker. Felmeddlande om något steg inte fungerar. Exempelvis om userID != adminID
        /// </summary>
        public void SoldItems(int userID)
        {
            Console.WriteLine("These are all the sold books");
            var list = controll.SoldItems(userID);

            if (list.Count() != 0)
            {
                foreach (var b in list)
                {
                    Console.WriteLine($"Title: {b.Title} Date purchased:{b.PurchasedDate}");
                }
            }
            else
            {
                Console.WriteLine("something went wrong, please try again");
            }
        }
    }
}