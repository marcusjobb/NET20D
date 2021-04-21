using System;
using WebbShopAPI;

namespace WebshopApiFrontend.Utility
{
    internal static class AdminMethods
    {
		static int loggedInUser = LoginMenu.LoggedInUser;
		/// <summary>
		/// Handles the passing of user inputs to AddBook
		/// </summary>
		public static void AddBookToDatebase()
        {
			var bookValues = UserInputs.AddBookInputs();
			WebbshopAPI.AddBook(loggedInUser, 
								bookValues.Item1, 
								bookValues.Item2, 
								bookValues.Item3, 
								bookValues.Item4);
		}
		/// <summary>
		/// Handles the passing of user inputs to AddCategory
		/// </summary>
		public static void AddCategoryToDatabase()
        {
			WebbshopAPI.AddCategory(loggedInUser, UserInputs.InputCategoryString());
		}
		/// <summary>
		/// Handles the passing of user inputs to AddUser
		/// </summary>
		public static void AddUserToDatabase()
        {
			var userValues = UserInputs.AddUserInputs();
			var result = WebbshopAPI.AddUser(loggedInUser, userValues.Item1, userValues.Item2);
			if(!result)
                Console.WriteLine(Errorhandeling.ErrorWithAddUser);
        }
		/// <summary>
		/// Handles the passing of user input to DeleteCategory
		/// </summary>
		public static void DeleteCategoryFromDatabase()
        {
			var result = WebbshopAPI.DeleteCategory(loggedInUser, UserInputs.InputCategoryId());
			if(!result)
                Console.WriteLine(Errorhandeling.ErrorWithId);
        }
		/// <summary>
		/// Handles the passing of Admin inputs to DeleteBook
		/// </summary>
		public static void DeleteBookFromDatabase()
        {
			var result = WebbshopAPI.DeleteBook(loggedInUser, UserInputs.InputId());
			if(!result)
                Console.WriteLine(Errorhandeling.ErrorWithId);
		}
		/// <summary>
		/// Handles the passing of Admin input to Promote
		/// </summary>
		public static void PromoteUser()
        {
			var result = WebbshopAPI.Promote(loggedInUser, UserInputs.InputId());
			if(!result)
                Console.WriteLine(Errorhandeling.ErrorWithId);
		}
		/// <summary>
		/// Handles the passing of Admin input to Demote
		/// </summary>
		public static void DemoteUser()
        {
			var result = WebbshopAPI.Demote(loggedInUser, UserInputs.InputId());
			if (!result)
				Console.WriteLine(Errorhandeling.ErrorWithId);
		}
		/// <summary>
		/// Handles the passing of Admin input to ActivateUser
		/// </summary>
		public static void ActivateUserStatus()
        {
			var result = WebbshopAPI.ActivateUser(loggedInUser, UserInputs.InputId());
            if (!result)
                Console.WriteLine(Errorhandeling.ErrorWithId);
		}
		/// <summary>
		///  Handles the passing of Admin input to InactivateUser
		/// </summary>
		public static void InactivateUserStatus()
        {
			var result = WebbshopAPI.InactivateUser(loggedInUser, UserInputs.InputId());
			if(!result)
                Console.WriteLine(Errorhandeling.ErrorWithId);
        }
		/// <summary>
		///  Handles the passing of Admin input to SetAmount
		/// </summary>
		public static void SetAmountOfBooks()
        {
			var result = WebbshopAPI.SetAmount(loggedInUser, UserInputs.InputId());
            Console.WriteLine(result);
        }
		/// <summary>
		///  Handles the passing of Admin inputs to UpdateBook
		/// </summary>
		public static void UpdateBookInDatabase()
        {
			var bookValues = UserInputs.UpdateBookInputs();
			var result = WebbshopAPI.UpdateBook(loggedInUser, 
												bookValues.Item1,
												bookValues.Item2,
												bookValues.Item3,
												bookValues.Item4);
			if(!result)
                Console.WriteLine(Errorhandeling.ErrorWithId);
		}
		/// <summary>
		///  Handles the passing of Admin inputs to AddBookToCategory
		/// </summary>
		public static void AddBookToCategoryInDatabase()
        {
			var result = WebbshopAPI.AddBookToCategory(loggedInUser, UserInputs.BookIdInputs(), UserInputs.InputCategoryId());
			if(!result)
                Console.WriteLine(Errorhandeling.ErrorWithId);
		}
		/// <summary>
		///  Handles the passing of Admin inputs to UpdateCategory
		/// </summary>
		public static void UpdateCategoryInDatabase()
        {
			var result = WebbshopAPI.UpdateCategory(loggedInUser, UserInputs.InputCategoryId(), UserInputs.InputCategoryString());
            if (!result)
                Console.WriteLine(Errorhandeling.ErrorWithId);
        }
		/// <summary>
		/// Retrieves a list of Users from the database to be displayed
		/// </summary>
        public static void ListUsersFromDatabase()
        {
			var result = WebbshopAPI.ListUsers(loggedInUser);
			result?.ForEach(u => Console.WriteLine($"Name: {u}"));
		}
		/// <summary>
		/// Handles the passing of Admin input to FindUser(keyword) then displays matches
		/// </summary>
		public static void FindUserInDatabase()
        {
			var result = WebbshopAPI.FindUser(loggedInUser, UserInputs.InputKeyword());
			result?.ForEach(item => Console.WriteLine($"id: {item.Id} Name: {item.Name}"));
        }
		/// <summary>
		/// Retrieves a list of sold books to then be displayed
		/// </summary>
		public static void SoldItemsInDatabase()
        {
			var result = WebbshopAPI.SoldItems(loggedInUser);
            result?.ForEach(i => Console.WriteLine($"Title: {i}"));
        }
		/// <summary>
		/// Retrieves the total amount from selling books to then be displayed
		/// </summary>
		public static void MoneyEarnedFromDatabase()
        {
			var result = WebbshopAPI.MoneyEarned(loggedInUser);
            if (result != default)
                Console.WriteLine(result);
        }
		/// <summary>
		/// Retrieves the best customer to then be displayed
		/// </summary>
		public static void BestCustomerInDatabase()
        {
			var result = WebbshopAPI.FindUserById(loggedInUser, WebbshopAPI.BestCustomer(loggedInUser));
			if (result != default)
				result.ForEach(u => Console.WriteLine($"Id: {u.Id}  Name: {u.Name}"));
        }
	}
}
