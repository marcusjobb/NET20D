using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebbShop.Data;
using WebbShop.Models;

namespace WebbShop
{
    public class WebbShopApi
    {
        public WebbContext context = new WebbContext();

        /// <summary>
        /// User login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

            if (user != null && user.IsActive==true)
            {
                user.Lastlogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
                return user.ID;
            }
            return 0;
        }

        /// <summary>
        /// User logout
        /// </summary>
        /// <param name="id"></param>
        public void LogOut(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == id && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            if (user != null )
            {
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
            }
           
        }

        /// <summary>
        /// List all categories
        /// </summary>
        /// <returns></returns>
        public List<BookCategory> GetCategories()
        {


            return context.BookCategories.ToList();
        }

        /// <summary>
        /// List the categori by name
        /// </summary>
        /// <returns></returns>
        public List<BookCategory> GetCategories(string namn)
        {

            return context.BookCategories.Where(x => x.Name == namn).ToList();
        }

        /// <summary>
        /// List of books by categoryID
        /// </summary>
        /// <param name="_categoryID"></param>
        /// <returns></returns>
        public List<Book> GetCategory(int _categoryID)
        {


            return context.Books.Where(x => x.CategoryID == _categoryID).ToList();
        }

        /// <summary>
        /// List the bok where amount is more then 0
        /// </summary>
        /// <param name="_Catergoryid"></param>
        /// <returns></returns>
        public List<Book> GetAvailableBooks(int _Catergoryid)
        {

            return context.Books.Where(x => x.Ammount > 0 && x.CategoryID==_Catergoryid).ToList();
        }

        /// <summary>
        /// Show information about book 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetBook(int id)
        {
            try
            {
                
                var book = context.Books.FirstOrDefault(x => x.ID == id);
                if (book != null)
                {
                   Console.WriteLine($"Title: {book.Title} Author: {book.Author} Amount: {book.Ammount} Price: {book.Price}:- CategoryID: {book.CategoryID}");
                }
                
                if (book == null)
                {
                    Console.WriteLine("The book is not exist");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return id;
        }

        /// <summary>
        /// List of books by price
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Book> GetBooks(int price)
        {
           
            return context.Books.Where(b => b.Price >= price).ToList();
           
           
        }

        /// <summary>
        /// List a book by author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public List<Book> GetAuthors(string author)
        {
            return context.Books.Where(a => a.Author == author).ToList();
        }

        /// <summary>
        /// Buy a book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public bool BuyBook(int userId, int bookID)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == userId);
            var book = context.Books.FirstOrDefault(b => b.ID == bookID);

            if (user != null && user.IsActive == true && user.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                context.SoldBooks.Add(new SoldBook
                {
                    Title = book.Title,
                    Author = book.Author,
                    CategoryID = book.CategoryID,
                    Price = book.Price,
                    PurchasedDate = DateTime.Now,
                    UserID = user.ID

                });
                context.SaveChanges();
                return true;
            }

            if (book.Ammount < 1)
            {
                return false;
            }
            return false;
        }


        /// <summary>
        /// Keep the user online
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Ping(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == id);

            if (user != null)
            {
                if (user.SessionTimer > DateTime.Now.AddMinutes(-15))
                {
                    user.SessionTimer = DateTime.Now;
                    context.Update(user);
                    context.SaveChanges();
                    Console.WriteLine("Pong");
                }

            }
            
            Console.WriteLine("Empty");
            return string.Empty;
            
        }

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordverify"></param>
        /// <returns></returns>
        public bool Register(string name, string password, string passwordverify)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.Name == name);

                if (user == null && password!=string.Empty && passwordverify!=string.Empty)
                {
                    context.Users.Add(new User { Name = name, Password = password, IsActive=true, IsAdmin=false });
                    context.SaveChanges();
                    return true;
                }

                if (user != null || string.IsNullOrEmpty(passwordverify))
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Adding book
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddBook(int adminID,string title, string author, int price, int amount)
        {

            try
            {

                var user = context.Users.FirstOrDefault(u => u.ID == adminID);
                var book = context.Books.FirstOrDefault(b => b.Title == title);

                if (user.IsAdmin == true && user != null && user.SessionTimer>DateTime.Now.AddMinutes(-15))
                {
                   
                    if (book == null)
                    {
                        context.Books.Add(new Book
                        {
                            Title = title,
                            Author = author,
                            Price = price,
                            Ammount = amount
                        });

                        context.SaveChanges();
                        return true;
                    }

                    if (book != null)
                    {
                        book.Ammount += amount;
                        context.Update(book);
                        context.SaveChanges();
                        return true;
                    }

                    }

                if (user.IsAdmin == false)
                {
                    
                    return false;
                }


            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;

        }

      
        /// <summary>
        /// Set amount of available book
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="BookID"></param>
        public void SetAmount(int adminID, int BookID, int amount)
        {
            try
            {
            var admin = context.Users.FirstOrDefault(u => u.ID == adminID);
            var book = context.Books.FirstOrDefault(b => b.ID == BookID);

                if(admin.IsAdmin==true && admin != null && admin.SessionTimer > DateTime.Now.AddMinutes(-15))
               {
                    
                if (book != null)
                {
                    book.Ammount = amount;
                    
                    context.SaveChanges();
                    Console.WriteLine($"The amount of this book is now {amount}");
                }

               }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Show list of users
        /// </summary>
        /// <param name="adminid"></param>
        /// <returns></returns>
        public List<User> ListUsers(int adminid)
        {
            var admin = context.Users.FirstOrDefault(u=> u.ID==adminid);
            List<string> emmpty = new List<string>();
            if (admin.IsAdmin == true && admin.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
             
                return context.Users.ToList();
            }
            return new List<User>();
        }

        /// <summary>
        /// Find a user 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<User> FindUser(int adminId, string name)
        {
            var admin = context.Users.FirstOrDefault(u => u.ID == adminId);
            
            if (admin.IsAdmin == true && admin.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
              
                return context.Users.Where(u => u.Name == name).ToList();
            }


            return new List<User>();
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <returns></returns>
        public bool UpdateBook(int adminid, int id, string title, string author, int price)
        {
            

            try
            {
               var admin = context.Users.FirstOrDefault(u => u.ID == adminid);
               var book = context.Books.FirstOrDefault(b => b.ID == id);

                if (admin.IsAdmin == true && admin != null && admin.SessionTimer > DateTime.Now.AddMinutes(-15))
                {
                  
                    if (book != null)
                    {
                        book.Title = title;
                        book.Author = author;
                        book.Price = price;
                        context.Update(book);
                        context.SaveChanges();
                        return true;
                    }
                }

            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }


        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBook(int adminid, int id)
        {
            try
            {
                var admin = context.Users.FirstOrDefault(u => u.ID == adminid);
                var book = context.Books.FirstOrDefault(b => b.ID == id);


                if (admin.IsAdmin == true && admin != null && admin.SessionTimer > DateTime.Now.AddMinutes(-15))
                {
                    
                    if (book.Ammount > 0)
                    {
                        book.Ammount -= 1;
                        context.Update(book);
                        context.SaveChanges();

                        return true;

                    }

                    if (book.Ammount == 0)
                    {
                        context.Remove(book);
                        context.SaveChanges();
                        return true;
                    }


                }

            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        /// <summary>
        /// Adding category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddCategory(int id, string name)
        {
            var admin = context.Users.FirstOrDefault(u => u.ID == id);
            var category = context.BookCategories.FirstOrDefault(c => c.Name == name);

            if(admin != null && admin.IsAdmin == true && admin.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                

                if (category == null)
                {
                    context.BookCategories.Add(new BookCategory { Name = name });
                    context.SaveChanges();
                    return true;
                }

                if (category != null)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Add category to book
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="bookid"></param>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public bool AddBookToCategory(int adminid, int bookid, int categoryid)
        {
            try
            {
                var admin = context.Users.FirstOrDefault(a => a.ID == adminid);
                var book = context.Books.FirstOrDefault(b => b.ID == bookid);

                if(admin != null && admin.IsAdmin==true && admin.SessionTimer > DateTime.Now.AddMinutes(-15)) 
                { 
                
                if (book.CategoryID == null)
                {
                    book.CategoryID = categoryid;
                    context.Update(book);
                    context.SaveChanges();
                    return true;
                }

                else if (book.CategoryID != null)
                {
                    return false;
                }
                  }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
            
            return false;
        }


        /// <summary>
        /// Update the category
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="categoryID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UpdateCategory(int adminID, int categoryID, string name)
        {
            try
            {
                var admin = context.Users.FirstOrDefault(a => a.ID == adminID);
                var category = context.BookCategories.FirstOrDefault(c => c.ID == categoryID);


                if (admin.IsAdmin == true && admin != null && admin.SessionTimer > DateTime.Now.AddMinutes(-15))
                {
                    
                    if (category != null)
                    {
                        category.Name = name;
                        context.Update(category);
                        context.SaveChanges();
                        return true;
                    }

                    if (category == null)
                    {
                        return false;
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
         

            return false;
        }


        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public bool DeleteCategory(int adminId, int categoryID)
        {

            try
            {


                var admin = context.Users.FirstOrDefault(a => a.ID == adminId);
                var category = context.BookCategories.FirstOrDefault(c => c.ID == categoryID);

                if(admin!= null && admin.IsAdmin == true && admin.SessionTimer > DateTime.Now.AddMinutes(-15))
                {
                    

                    if (category != null)
                    {
                        return false;
                    }
                }
               

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }


        /// <summary>
        /// Add a user
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AddUser(int adminid, string name, string password)
        {


            try
            {
             var admin = context.Users.FirstOrDefault(u=> u.ID==adminid);
             var user = context.Users.FirstOrDefault(u => u.Name == name);

                if (admin.IsAdmin==true && admin != null && admin.SessionTimer > DateTime.Now.AddMinutes(-15))
                {
                    
                    
                  if(user==null && password != string.Empty)
                    {
                        context.Users.Add(new User { Name = name, Password = password, IsActive = true, IsAdmin = false });
                        context.SaveChanges();
                        return true;
                    }

                    else if(user!=null || string.IsNullOrEmpty(password))
                    {
                        return false;
                    }

                }
                
                
                

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
         return false;
               
            
        }

    }
}