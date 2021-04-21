using MyFirstEntityframProject.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämning_3_WebbShop.Views
{
    public class AdminView
    {
        public void AddBook(bool book)
        {
            if (book == true)
            {
                Console.WriteLine("The book details have been updated.");
            }
            else
            {
                Console.WriteLine("Error. You need to be logged in as administrator to use this function");
            }
        }
        public void SetAmount(bool updateBook)
        {
            if (updateBook == true)
            {
                Console.WriteLine("The book details have been updated.");

            }
            else
            {
                Console.WriteLine("Error. You need to be logged in as administrator to use this function");

            }
        }
        public void ListUsers(List<User> users)
        {
            if (users != null)
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name}, {user.Password}");
                }
            }
            else
            {
                Console.WriteLine("{There seem to be no users registered in the webshop.");
            }


        }
        public void FindUser(List<User> users)
        {
            if (users != null)
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name}, {user.Password}");
                }
            }
            else
            {
                Console.WriteLine("Error.There seem to be no users registered in the webshop.");
            }
        }

        public void UpdateBookDetails(bool bookUpdated)
        {
            if (bookUpdated == true)
            {
                Console.WriteLine("Book details are now registered in the webshop.");
            }
            else
            {
                Console.WriteLine($"The book could not be found in the webshop. Please enter correct [bookId] and try again.");
            }
        }
        public void DeleteBook(bool bookDeleted)
        {
            if (bookDeleted == true)
            {
                Console.WriteLine("Book is now deleted from the webshop.");
            }
            else
            {
                Console.WriteLine("The book you are trying to delete is no longer in stock");
            }
           
        }
        public void AddCategory(bool categoryAdded)
        {
            if (categoryAdded == true)
            {
                Console.WriteLine("A new category is now added to the catalogue.");
            }
            else
            {
                Console.WriteLine("The category you are trying to add already exists in the catalogue");
            }
      
        }
        public void AddBookToCategory(bool bookAdded)
        {
            if (bookAdded == true)
            {
                Console.WriteLine("The book has been successfully added to the category.");
            }
            else
            {
                Console.WriteLine("Error. Either book or category does not exist. Create book and category in the catalogue first.");
            }
            
        }
        public void UpdateCategory(bool categoryUpdated)
        {
            if (categoryUpdated == true)
            {
                Console.WriteLine("Category is now updated in the webshop.");
            }
            else
            {
                Console.WriteLine("The category with Id could not be found in the webshop. Please enter correct [categoryId].");
            }

        }
        public void DeleteCategory(bool categoryDeleted)
        {
            if (categoryDeleted == true)
            {
                Console.WriteLine("Category was deleted from the webshop.");
            }
            else
            {
                Console.WriteLine("The category you are trying to delete is no longer in stock.");
            }
        }
        public void AddUser(bool addedUser)
        {
            if (addedUser == true)
            {
                Console.WriteLine("User has been successfully added to the customer database.");
            }
            else
            {
                Console.WriteLine("User with this username already exists.");
            }
        }

    }
}
