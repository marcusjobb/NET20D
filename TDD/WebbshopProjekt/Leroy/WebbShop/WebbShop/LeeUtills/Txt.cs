using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShop.LeeUtils
{
	/// <summary>
	/// Static strings to input
	/// </summary>
    public static class Txt
	{

		public static string WelcomeVies = @"
1. Login
2. Register
B/b. Exit shop";

		public static string LogInOrRegister = "Login or Register a new user";

		public static string WrongInputOrBack = "Wrong input. Hit b or B if you want to go back";

		public static string WrongInput = "Wrong input";

		public static string Welcome = "Welcome";

		public static string Login = "Log in\n";

		public static string LogingIn = "Signing in\n";

		public static string UserNotActive = "This user is not active\n";

		public static string LogOut = "User was successfully loged out";

		public static string LogOutFail = "User was not successfully loged out";

		public static string SessiontimeOver = "Session time is over";

		public static string Name = "Enter your name:";

		public static string Password = "Enter your password:";

		public static string Verify = "Verify your password:";

		public static string WelcomeUser = "Welcome ";

		public static string Keyword = "Enter a keyword";

		public static string Nothing = "Nothing was found";

		public static string ShowList = "Showing list:\n";

		public static string ChooseBook = "Choose book";

		public static string BookPurchased = "The book was successfully purchased";

		public static string NoBookPurchased = "The book was unsuccessfully purchased";

		public static string UserAlreadyExcisting = "User already excists";

		public static string UserDeleted = "User was deleted";

		public static string UserNotDeleted = "User was not deleted";

		public static string NotActive = "Sorry - your account is deactivated. Contact admin for more information.";

		public static string NoAccess = "You don't have permission to access this hidden option";

		public static string UserMenu = @"
1. Show all categories
2. Show categories matching keyword
3. Show all books in a category
4. Show all available books in a category
5. Search for a books by keyword
6. Search for books by an author
B/b. Log out";

		public static string AdminMenu = @"
1. Show all categories
2. Show categories matching keyword
3. Show all books in a category
4. Show all available books in a category
5. Search for a books by keyword
6. Search for books by an author
7. Admin menu
B/b. Log out";

		public static string CategoryMenu = @"
1. Show all categories
2. Search for a category
B/b. Go back";

		public static string ShowInfoOrBuyBook = @"
1. Show information about a book
2. Buy a book
B/b. Go back";


		public static string AdminOptionView = @"
1. Add book
2. Set amount
3. List users
4. Add, edit or delete user
5. Find users
6. Update book
7. Delete book
8. Add category
9. Add book to category
10. Update category
11. Delete category
12. Show all books sold
13. Show money earned
14. Your best customer
15. Delete user
B/b. Go back";

		public static string Category = "Type category";

		public static string BookTitle = "Type title";

		public static string BookAuthor = "Type author";
		
		public static string BookPrice = "Type price";
		
		public static string BookAmount = "Type amount";

		public static string BookAdded = "The book was successfully added";

		public static string BookNotAdded = "The book was unsuccessfully added";

		public static string CategoryAdded = "The category was successfully added";

		public static string CategoryNotAdded = "The category was unsuccessfully added";

		public static string CategoryUpdated = "The category was successfully updated";

		public static string CategoryNotUpdated = "The category was unsuccessfully updated";

		public static string CategoryDeleted = "The category was successfully deleted";

		public static string CategoryNotDeleted = "The category was unsuccessfully deleted";

		public static string BookUpdated = "The book was successfully updated";

		public static string BookNotUpdated = "The book was unsuccessfully updated";

		public static string BookDeleted = "The book was successfully deletec";

		public static string BookNotDeleted = "The book was unsuccessfully deleted";

		public static string AmountAdded = "The amount was successfully added";

		public static string AmountNotAdded = "The amount was unsuccessfully added";

		public static string UserAdded = "New user added";

		public static string UserNotAdded = "No new user added";

		public static string UserPromoted = "User was promoted";

		public static string UserNotPromoted = "User not promoted";

		public static string UserDemoted = "User demoted";

		public static string UserActivated = "User was activated";

		public static string UserNotActivated = "User not activated";

		public static string UserDeActivated = "User deactivated";

		public static string Earnings = "You have earned ";

		public static string BestCustomer = "Your best customer is ";

		public static string AddEditDeleteUser = @"
1. Add user
2. Edit user
3. Delete user
B/b. Go back";

		public static string PromoteActivate = @"
1. Promote user
2. Depromote user
3. Activate user
4. Deactivate user
B/b. Go back";
	}
}
