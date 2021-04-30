using System;

namespace FrontEnd.Controllers
{

    public static class Admin
    {
    
        public static void AddBook()
        {
            var input = Helper.InputAdmin.AddBookInput();
            var addSucces = WebbShopAPI.WebbShopApi.AddBook(Models.User.UserId, input.title, input.author, input.price, input.quantity);
            Helper.LoginUserAdmin.SetSessionTimer();
            if(addSucces)
            {
                Console.WriteLine($"Title: {input.title} Author: {input.author} Price: {input.price} Qty: {input.quantity}" +
                $"n\nHave been added to Svantes Webbshop");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            Console.ReadLine();
        }

        public static void SetQuantity()
        {
            var input = Helper.InputAdmin.SetQuantity();
            WebbShopAPI.WebbShopApi.SetQuantity(Models.User.UserId, input.bookId, input.quantity);
            Helper.LoginUserAdmin.SetSessionTimer();
            Console.WriteLine($" BookID {input.bookId} = Qty {input.quantity} ");
        }
        public static void ListUser()
        {
            var printListUsers = WebbShopAPI.WebbShopApi.ListUsers(Models.User.UserId);
            Helper.LoginUserAdmin.SetSessionTimer();
            foreach (var user in printListUsers)
            {
                Console.WriteLine($"ID:{user.Id} Name: {user.Name} Password: {user.Password}");
            }

        }
        public static void FindUser()
        {
            var user =WebbShopAPI.WebbShopApi.FindUsers(Models.User.UserId, Console.ReadLine());
            Helper.LoginUserAdmin.SetSessionTimer();
            foreach (var u in user)
            {
                Console.WriteLine($"ID: {u.Id} Name: {u.Name} Password: {u.Password}");
            }
        }
        public static void UpdateBook()
        {
            var input = Helper.InputAdmin.UpdateBook();
            WebbShopAPI.WebbShopApi.UpdateBook(input.userId, input.bookId, input.title, input.author, input.price);
            Helper.LoginUserAdmin.SetSessionTimer();
            Console.WriteLine($"BookID: {input.bookId} Title: {input.title} Author: {input.author} Price: {input.price}");
        }
        public static void DeleteBook()
        {
            var input = Helper.InputAdmin.DeleteBook();
            WebbShopAPI.WebbShopApi.DeleteBook(input.userId, input.bookId);
            Helper.LoginUserAdmin.SetSessionTimer();
        }

        internal static void UpdateGenre()
        {
            var (userId, genreId, name) = Helper.InputAdmin.UpdateGenre();
            var updateSucces = WebbShopAPI.WebbShopApi.UpdateGenre(userId, genreId, name);
            Helper.LoginUserAdmin.SetSessionTimer();
            if(updateSucces)
            {
                Console.WriteLine("Update succesful");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        internal static void AddUser()
        {
            var (userId, name, password) = Helper.InputAdmin.AddUserInput();
            var addSucces = WebbShopAPI.WebbShopApi.AddUser(userId,name,password);
            if (addSucces)
            {
                Console.WriteLine($"Name {name} have been added.");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        internal static void DeleteGenre()
        {
            var (userId, genreId) = Helper.InputAdmin.DeleteGenre();
            var deleteSucces = WebbShopAPI.WebbShopApi.DeleteCategory(userId, genreId);
            Helper.LoginUserAdmin.SetSessionTimer();
            if (deleteSucces)
            {
                Console.WriteLine("Delete succesful");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        internal static void AddBookToGenre()
        {
            var input = Helper.InputAdmin.AddBookToGenre();
            var addSucces = WebbShopAPI.WebbShopApi.AddBookToCategory(input.userId, input.bookId, input.genreId);
            Helper.LoginUserAdmin.SetSessionTimer();
            if(addSucces)
            {
                Console.WriteLine("book succesfylly added to genre");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public static void AddGenre()
        {
            var input = Helper.InputAdmin.AddGenre();
            var addSucces = WebbShopAPI.WebbShopApi.AddCategory(input.userId, input.name);
            Helper.LoginUserAdmin.SetSessionTimer();
            if (addSucces) 
            {
                Console.WriteLine($"New Genre = {input.name}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadLine();
            }
        }
    }
}