using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI.Controllers
{
    /// <summary>
    /// Helper for managing any users
    /// </summary>
    public static class UsersController
    {
        /// <summary>
        /// Validate common method params, this are repeatedly used throughout other methods.
        /// </summary>
        /// <param name="adminid">The administrator to verify</param>
        /// <param name="user">The user object to verify</param>
        /// <returns></returns>
        private static bool ValidateUserParamInput(int adminid, Users userid)
        {
            if (!ValidateAdminOnline(adminid) || userid == null)
                return false;
            return true;
        }

        /// <summary>
        /// Run common validation and ping for 
        /// </summary>
        /// <param name="adminid">The administrator to verify</param>
        /// <returns>True if it is possible to ping the account and if the account is an administrator</returns>
        private static bool ValidateAdminOnline(int adminid)
        {
            return Ping(adminid) && IsAdmin(adminid);
        }

        /// <summary>
        /// A super simple non-secure, non-encrypted, non-modern, not to be trusted, worse than ever method to sign in to a system.
        /// </summary>
        /// <param name="username">The username you wish to use</param>
        /// <param name="password">The associated password for that username</param>
        /// <returns>The user id of the login, if the login fails, you'll receive either one of these fail codes:
        /// <list type="bullet">
        /// <item>
        /// -1 The user was not found
        /// </item>
        /// <item>
        /// -2 The user is inactive (it must be enabled by an administrator first)
        /// </item>
        /// </list>
        /// </returns>
        public static int Login(string username, string password)
        {
            using var db = new WebbShopAPIContext();
            var user = db.Users.FirstOrDefault(
                    u => u.Name == username && u.Password == password && u.IsActive
                );

            if(user != null)
            {
                if (!user.IsActive)
                    return -2; //fail code -2 = is inactive

                user.LastLogin      = DateTime.Now;
                user.SessionTimer   = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return user.Id;
            }
            return -1;
        }

        /// <summary>
        /// Activate user allows you to activate a user account if you know the users id.
        /// </summary>        
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static bool ActivateUser(int adminid, int uid)
        {
            var user = Get(uid);
            if (!ValidateUserParamInput(adminid, user))
                return false;

            using var db = new WebbShopAPIContext();
            user.IsActive = true;
            db.Users.Update(user);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Disable a user, making it impossible to sign in.
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="uid">The target user id to affect</param>
        /// <returns>False if any of the criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The target user id is less than 1
        /// </item>
        /// <item>
        /// The target user id doesn't exist
        /// </item>
        /// </list>
        /// </returns>
        public static bool DisableUser(int adminid, int uid)
        {
            var user = Get(uid);
            if (!ValidateUserParamInput(adminid, user))
                return false;

            using var db = new WebbShopAPIContext();
            user.IsActive = false;
            db.Users.Update(user);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Promote a regular user to administrator status
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="uid">The target user to set status for</param>
        /// <returns>False if any of the criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The target user id is less than 1
        /// </item>
        /// <item>
        /// The target user id doesn't exist
        /// </item>
        /// </list>
        /// </returns>
        public static bool Promote(int adminid, int uid)
        {
            var user = Get(uid);
            if (!ValidateUserParamInput(adminid, user))
                return false;

            using var db = new WebbShopAPIContext();
            user.IsAdmin = true;
            db.Users.Update(user);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Demotes an administrator to regular user.
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="uid">The target user to set status for</param>
        /// <returns>False if any of these criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The uid provided is not an expected uid (less than 1)
        /// </item>
        /// <item>
        /// The administrator is attempting to demote her-/himself
        /// </item>
        /// <item>
        /// The target user doesn't exist
        /// </item>
        /// </list></returns>
        public static bool Demote(int adminid, int uid)
        {
            var user = Get(uid);
            if (!ValidateUserParamInput(adminid, user))
                return false;

            using var db = new WebbShopAPIContext();
            user.IsAdmin = false;
            db.Users.Update(user);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="name">The desired username</param>
        /// <param name="password">The password to associate with this username</param>
        /// <returns>False if any of these criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The name is null or empty (not set (""))
        /// </item>
        /// <item>
        /// The password is null or empty (not set (""))
        /// </item>
        /// <item>
        /// The username is already taken
        /// </item>
        /// </list>
        /// </returns>
        public static bool AddUser(int adminid, string name, string password)
        {
            if (!ValidateAdminOnline(adminid) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || Exists(name))
                return false;

            using var db = new WebbShopAPIContext();
            db.Users.Add(new Users() { Name = name, Password = password });
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Create a new user via an object of that person.
        /// </summary>
        /// <param name="admin">Administrator object to use</param>
        /// <param name="newUser">The new user to be created</param>
        /// <returns>False if any of these criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The name is null or empty (not set (""))
        /// </item>
        /// <item>
        /// The password is null or empty (not set (""))
        /// </item>
        /// <item>
        /// The username is already taken
        /// </item>
        /// </list>
        /// </returns>
        public static bool AddUser(Users admin, Users newUser)
        {
            return AddUser(admin.Id, newUser.Name, newUser.Password);
        }

        /// <summary>
        /// Get the whole user information
        /// </summary>
        /// <param name="id">The users identification number</param>
        /// <returns></returns>
        public static Users Get(int id)
        {
            using var db = new WebbShopAPIContext();
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Get the whole user information
        /// </summary>
        /// <param name="id">The users identification number</param>
        /// <returns></returns>
        public static Users Get(string name)
        {
            using var db = new WebbShopAPIContext();
            return db.Users.FirstOrDefault(u => u.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Check if a user has a valid session or not
        /// </summary>
        /// <param name="id">The user id for the person you'd want to validate</param>
        /// <returns>Yes or no</returns>
        public static bool ValidSession(int id)
        {
            using var db = new WebbShopAPIContext();
            return db.Users.FirstOrDefault(u => u.Id == id).SessionTimer > DateTime.Now.AddMinutes(-15);
        }

        /// <summary>
        /// Prolong the current session of the user, requires that:
        /// <list type="number">
        /// <item>A user must exist</item>
        /// <item>A user already has an active session</item>
        /// </list>
        /// </summary>
        /// <param name="id">The users identification number</param>
        /// <returns>States 
        /// <list type="table">
        /// <item>
        /// 1 means that nothing is wrong and the session has been extended
        /// </item>
        /// <item>
        /// -1 means that the user was not found
        /// </item>
        /// <item>
        /// -2 means that the session has already been invalidated and the user must login anew.
        /// </item>
        /// </list>
        /// </returns>
        public static bool Ping(int id)
        {
            var user = Get(id);
            if (user == null || !ValidSession(id))
                return false;

            using var db = new WebbShopAPIContext();

            user.SessionTimer = DateTime.Now;
            db.Users.Update(user);
            db.SaveChanges();
            return true;            
        }

        /// <summary>
        /// Check if user is administrator
        /// </summary>
        /// <param name="id">The user you'd like to validate if is a admin</param>
        /// <returns>Yes or no</returns>
        public static bool IsAdmin(int id)
        {
            if (id < 1)
                return false;
            using var db = new WebbShopAPIContext();
            if(db.Users.FirstOrDefault(u => u.Id == id && u.IsAdmin) != null)
                return true;
            return false;
        }

        /// <summary>
        /// Check if the user exists, and then return that user.
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <param name="keyword">The keyword to search for in the users name</param>
        /// <returns>Null for no result or a users object</returns>
        public static Users FindUser(int adminid, string keyword)
        {
            if (!ValidateAdminOnline(adminid))
                return null;
            using var db = new WebbShopAPIContext();
            return db.Users.FirstOrDefault(u => u.Name.ToLower().Contains(keyword.ToLower()));
        }

        /// <summary>
        /// Check if the name is taken
        /// </summary>
        /// <param name="name">The desired username</param>
        /// <returns>Yes or no</returns>
        public static bool Exists (string name)
        {
            if (string.IsNullOrEmpty(name))
                return true;
            using var db = new WebbShopAPIContext();
            return db.Users.FirstOrDefault(u => u.Name.ToLower() == name.ToLower()) != null;
        }

        /// <summary>
        /// List all users
        /// </summary>
        /// <param name="adminid">Administator performing the task</param>
        /// <returns>A list of all users ever</returns>
        public static List<Users> ListUsers(int adminid)
        {
            if (!ValidateAdminOnline(adminid))
                return null;
            using var db = new WebbShopAPIContext();
            return db.Users.ToList();
        }

        /// <summary>
        /// Invalidate the current session, forcing the user to sign in again
        /// </summary>
        /// <param name="id">The user to sign out</param>
        /// <returns>Yes or no, the only situation where a user can't be signed out is if the user doesn't exist</returns>
        public static bool Logout(int id)
        {
            if (id < 1)
                return false;
            using var db = new WebbShopAPIContext();
            var user = db.Users.FirstOrDefault(
                u => u.Id == id
            );

            if (user == null)
                return false;

            user.SessionTimer = DateTime.MinValue;
            db.Users.Update(user);
            db.SaveChanges();
            return true;
        }
    }
}
