using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Inlamn2WebbShop_MLarsson.Database;
using Inlamn2WebbShop_MLarsson.Models;
using Inlamn2WebbShop_MLarsson.Views;
using Microsoft.EntityFrameworkCore;

namespace Inlamn2WebbShop_MLarsson
{
    public static class VGWebbShopAPI
    {
        /// <summary>
        /// Öpnnar en koppling till databasen, för att kunna använda i hela klassen.
        /// </summary>
        private static WebbShopContext db = new WebbShopContext();

        /// <summary>
        /// Aktiverar en inaktiverad användare.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true om lyckad, annars false</returns>
        public static bool ActivateUser(int adminId, int userId)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsActive = true;
                        db.SaveChanges();
                        if (Helper.DoesUserExist(db.Users.FirstOrDefault(u => u.Id == userId && u.IsActive)))
                        {
                            return View.ActiveInactive("active", user.Name);
                        }
                    }
                    else
                    {
                        return View.SomethingWentWrong();
                    }
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Visar den kund som köpt flest böcker.
        /// </summary>
        /// <param name="adminId"></param>
        public static User BestCustomer(int adminId)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var customer = db.Users.Include(s => s.SoldBooks).OrderByDescending(b => b.SoldBooks.Count()).FirstOrDefault();

                    View.BestCustomer(customer.SoldBooks.Count());
                    return customer;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gör en administratör till vanlig användare.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true om lyckad, annars false.</returns>
        public static bool Demote(int adminId, int userId)
        {
            try
            {
                var admin = db.Users.FirstOrDefault(a => a.Id == adminId && a.IsAdmin);
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsAdmin = false;
                        db.SaveChanges();
                        if (Helper.DoesUserExist(db.Users.FirstOrDefault(u => u.Id == userId && !u.IsAdmin)))
                        {
                            return View.DemotePromote("demote", user.Name);
                        }
                    }
                    else
                    {
                        return View.SomethingWentWrong();
                    }
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Inaktiverar en aktiv användare.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true om lyckad, annars false.</returns>
        public static bool InactivateUser(int adminId, int userId)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsActive = false;
                        db.SaveChanges();
                        if (Helper.DoesUserExist(db.Users.FirstOrDefault(u => u.Id == userId && !u.IsActive)))
                        {
                            return View.ActiveInactive("Inactive", user.Name);
                        }
                    }
                    else
                    {
                        return View.SomethingWentWrong();
                    }
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Visar totalsumman av alla sålda böcker.
        /// </summary>
        /// <param name="adminId"></param>
        public static void MoneyEarned(int adminId)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var bestBook = from b in db.SoldBooks
                                   group b by b.Title into g
                                   select new
                                   {
                                       Title = g.Key,
                                       BookSum = g.Sum(a => a.Price)
                                   };

                    var totalSum = db.SoldBooks.Sum(p => p.Price);
                    View.MoneyEarned(totalSum);
                    if (bestBook != null)
                    {
                        foreach (var book in bestBook)
                        {
                            View.MoneyEarned(book.Title, book.BookSum);
                        }
                    }
                }
            }
            catch (Exception)
            {
                View.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Gör en användare till administratör.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true om lyckad, annars false.</returns>
        public static bool Promote(int adminId, int userId)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsAdmin = true;
                        db.SaveChanges();
                        if (Helper.DoesUserExist(db.Users.FirstOrDefault(u => u.Id == userId && u.IsAdmin)))
                        {
                            return View.DemotePromote("promote", user.Name);
                        }
                    }
                    else
                    {
                        return View.SomethingWentWrong();
                    }
                }
                return View.SomethingWentWrong();
            }
            catch (Exception)
            {
                return View.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Listar alla sålda böcker.
        /// </summary>
        /// <param name="adminId"></param>
        public static void SoldItems(int adminId)
        {
            try
            {
                if (Helper.CheckIfAdmin(db.Users.FirstOrDefault(a => a.Id == adminId)))
                {
                    View.SoldItems();
                }
            }
            catch (Exception)
            {
                View.SomethingWentWrong();
            }
        }
    }
}
