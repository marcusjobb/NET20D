using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebbShopAPIGustafMalmsten;
using WebbShopAPIGustafMalmsten.Model;
using WebbShopAPIGustafMalmstenFrontEnd;

namespace WebbShopApiGustafMalmsten
{
    public partial class Form1 : Form
    {
        public API api = new();
        public int activeUser = 0;
        public int activeBook = 0;
        public int activeBookCategory = 0;
        public List<Book> books = new();

        public Form1()
        {
            InitializeComponent();
            Init();           
        }

        public API API
        {
            get => default;
            set
            {
            }
        }

        public LoginForm LoginForm
        {
            get => default;
            set
            {
            }
        }

        public RegForm RegForm
        {
            get => default;
            set
            {
            }
        }

        public AddBookForm AddBookForm
        {
            get => default;
            set
            {
            }
        }

        public ChangeAmountForm ChangeAmountForm
        {
            get => default;
            set
            {
            }
        }

        public NewCategoryForm NewCategoryForm
        {
            get => default;
            set
            {
            }
        }

        public SoldBookForm SoldBookForm
        {
            get => default;
            set
            {
            }
        }

        public ManageUsersForm ManageUsersForm
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Initializes the form
        /// </summary>
        public void Init()
        {
            CmbBoxCategoriesUserItems();            
            CmbBoxSearchStandardItems();
            DeactivateAdminControls();
            btnLogout.Enabled = false;
            btnBuyBook.Enabled = false;
        }
        /// <summary>
        /// Puts non-empty book categoreis in the listbox
        /// </summary>
        public void CmbBoxCategoriesUserItems()
        {
            cmbBoxCategories.Items.Clear();
            List<BookCategory> categories = api.GetNonEmptyCategories();
            categories.ForEach(x => cmbBoxCategories.Items.Add(x.BookCategoryName));
        }
        /// <summary>
        /// Lets the user search for books based on author or on title
        /// </summary>
        public void CmbBoxSearchStandardItems()
        {
            cmbBoxSearch.Items.Clear();
            cmbBoxSearch.Items.Add("Author");
            cmbBoxSearch.Items.Add("Book");
            cmbBoxSearch.SelectedIndex = 0;
            btnLogout.Visible = true;
        }
        /// <summary>
        /// Outputs the information about the book
        /// </summary>
        /// <param name="index">The index of the book</param>
        public void OutputFullBookInfo(int index)
        {
            lblBookName.Text = $"Bookname: {books[index].Title}";
            lblBookID.Text = $"BookID: {books[index].ID}";
            lblAuthor.Text = $"Author: {books[index].Author}";
            lblPrice.Text = $"Price:\t{books[index].Price} SEK";
            lblAmount.Text = $"Books left: {books[index].Amount}";
        }
        /// <summary>
        /// Activates the proper buttons and controls
        /// </summary>
        public void Login()
        {
            ActivateUserControls();
            if (api.IsAdmin(activeUser))
            {
                ActivateAdminControls();
            }
        }
        /// <summary>
        /// Changes the text to say the user name
        /// </summary>
        /// <param name="username">The name to show</param>
        public void ChangeLoginText(string username)
        {
            lblLogin.Text = "You are now logged in as " + username;
        }
        /// <summary>
        /// Outputs a message that the user is logged out, and deactivates controls
        /// </summary>
        public void Logout()
        {
            lstBoxOutput.Items.Add("You are now logged out.");
            lstBoxOutput.Items.Add("Thank you for using this program");
            lblLogin.Text = "You are not logged in";
            DeactivateUserControls();
        }
        /// <summary>
        /// Activates basic user controls
        /// </summary>
        public void ActivateUserControls()
        {
            btnLogout.Enabled = true;
            btnLogin.Enabled = false;
            btnRegister.Enabled = false;
            lstBoxOutput.Items.Clear();
            btnBuyBook.Enabled = true;
        }
        /// <summary>
        /// Activates advanced admin controls
        /// </summary>
        public void ActivateAdminControls()
        {
            btnAdminAddBook.Visible = true;
            btnChangeAmount.Visible = true;
            btnDeleteBook.Visible = true;
            btnUpdateBook.Visible = true;
            btnAdminAddCategory.Visible = true;
            btnAdminRemoveCategory.Visible = true;
            btnAdminUpdateCategory.Visible = true;
            btnAdminChangeCategory.Visible = true;
            btnAdminBestCustomer.Visible = true;
            btnAdminMoneyEarned.Visible = true;
            btnAdminViewSoldBooks.Visible = true;
            btnAdminManageUsers.Visible = true;
            btnAdminAddBook.Enabled = true;
            btnChangeAmount.Enabled = true;
            btnDeleteBook.Enabled = true;
            btnUpdateBook.Enabled = true;
            btnAdminAddCategory.Enabled = true;
            btnAdminRemoveCategory.Enabled = true;
            btnAdminUpdateCategory.Enabled = true;
            btnAdminChangeCategory.Enabled = true;
            btnAdminBestCustomer.Enabled = true;
            btnAdminMoneyEarned.Enabled = true;
            btnAdminViewSoldBooks.Enabled = true;
            btnAdminManageUsers.Enabled = true;
        }
        /// <summary>
        /// Deactivates advanced admincontrols
        /// </summary>
        public void DeactivateAdminControls()
        {
            btnAdminAddBook.Enabled = false;
            btnChangeAmount.Enabled = false;
            btnDeleteBook.Enabled = false;
            btnUpdateBook.Enabled = false;
            btnAdminAddCategory.Enabled = false;
            btnAdminRemoveCategory.Enabled = false;
            btnAdminUpdateCategory.Enabled = false;
            btnAdminChangeCategory.Enabled = false;
            btnAdminBestCustomer.Enabled = false;
            btnAdminMoneyEarned.Enabled = false;
            btnAdminViewSoldBooks.Enabled = false;
            btnAdminManageUsers.Enabled = false;
            btnAdminAddBook.Visible = false;
            btnChangeAmount.Visible = false;
            btnDeleteBook.Visible = false;
            btnUpdateBook.Visible = false;
            btnAdminAddCategory.Visible = false;
            btnAdminRemoveCategory.Visible = false;
            btnAdminUpdateCategory.Visible = false;
            btnAdminChangeCategory.Visible = false;
            btnAdminBestCustomer.Visible = false;
            btnAdminMoneyEarned.Visible = false;
            btnAdminViewSoldBooks.Visible = false;
            btnAdminManageUsers.Visible = false;
        }
        /// <summary>
        /// Deactivates basic user controls
        /// </summary>
        public void DeactivateUserControls()
        {
            if (api.IsAdmin(activeUser))
            {
                DeactivateAdminControls();
            }
            btnLogout.Enabled = false;
            btnRegister.Enabled = true;
            btnBuyBook.Enabled = false;
            btnLogin.Enabled = true;
            ResetLabels();
            lstBoxOutput.Items.Clear();
        }
        /// <summary>
        /// Refreshes the list of books in the form
        /// </summary>
        public void UpdateBooks()
        {
            books = api.GetAvaialableBooks(activeBookCategory);
        }
        /// <summary>
        /// Outputs the book titles in the listbox
        /// </summary>
        public void OutputBooks()
        {
            books.ForEach(x => lstBoxOutput.Items.Add(x.Title));
            activeBook = -1;
            lstBoxOutput.SelectedIndex = -1;
            ResetLabels();
        }
        /// <summary>
        /// Resets the book information labels
        /// </summary>
        public void ResetLabels()
        {
            lblBookName.Text = "Bookname:";
            lblBookID.Text = "BookID:";
            lblAuthor.Text = "Author:";
            lblPrice.Text = "Price:";
            lblAmount.Text = "Books left:";
        }
        /// <summary>
        /// Searches for the books, and outputs the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            lstBoxOutput.Items.Clear();
            books.Clear();
            if (string.IsNullOrEmpty(txtBoxSearch.Text))
            {
                return;
            }
            if (cmbBoxSearch.Text.Equals("Author"))
            {
                books = api.GetAuthors(txtBoxSearch.Text);             
            }
            if (cmbBoxSearch.Text.Equals("Book"))
            {
                if (int.TryParse(txtBoxSearch.Text, out _))
                {
                    int id = Convert.ToInt32(txtBoxSearch.Text);
                    books.Add(api.GetBook(id));                 
                }
                else 
                {
                    books = api.GetBooks(txtBoxSearch.Text);
                }
            }
            OutputBooks();
        }
        /// <summary>
        /// Opens a form to register a new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegForm reg = new()
            {
                Enabled = true
            };
            reg.ShowDialog();
            if (reg.DialogResult == DialogResult.OK)
            {
                string usrname = reg.txtUsername.Text;
                string pass = reg.txtPassword.Text;
                string verPass = reg.txtVerifyPassword.Text;
                reg.Enabled = false;

                if (api.Register(usrname, pass, verPass) && api.Login(usrname, pass) != -1)
                {
                    activeUser = api.Login(usrname, pass);
                    Login();
                    lstBoxOutput.Items.Add("Registration successful!");
                    ChangeLoginText(usrname);                   
                }
                else
                {
                    lstBoxOutput.Items.Add("Login failed");
                }
            }
            else
            {
                return;
            }

        }
        /// <summary>
        /// Attempts to logout the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (activeUser > 0)
            {
                if (api.Logout(activeUser) != -1)
                {
                    Logout();
                    activeUser = 0;
                }                
            }
        }
        /// <summary>
        /// Opens a form to log in an user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginForm login = new()
            {
                Enabled = true
            };
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                string usrname = login.txtBoxUsername.Text;
                string pass = login.txtBoxPassword.Text;
                int usrID = api.Login(usrname, pass);

                if(usrID > 0)
                {
                    activeUser = usrID;
                    btnLogout.Enabled = true;
                    Login();
                    lstBoxOutput.Items.Add("Login successful!");
                    ChangeLoginText(usrname);
                }
            }
            else
            {
                lstBoxOutput.Items.Add("Login failed");
            }
        }
        /// <summary>
        /// Attempts to buy a selected book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuyBook_Click(object sender, EventArgs e)
        {
            if(lstBoxOutput.SelectedIndex == -1)
            {
                return;
            }
            if (!api.IsLoggedIn(activeUser))
            {
                lstBoxOutput.Items.Add("You have been logged out because of inactivity.");
                lstBoxOutput.Items.Add("Please log in again");                
                DeactivateUserControls();
            }
            if(api.BuyBook(activeUser, activeBook))
            {
                lstBoxOutput.Items.Add($"You bought the book! {api.GetBook(activeBook).Title}");
            }
            else if(api.GetBook(activeBook).Amount == 0)
            {
                lstBoxOutput.Items.Add($"Sorry, the book {api.GetBook(activeBook).Title} is out of stock.");
                lstBoxOutput.Items.Add("Please contact us in the store to make an order");
            }
            else
            {
                lstBoxOutput.Items.Add("Sorry, something went wrong. Please try again.");
            }
            
        }
        /// <summary>
        /// Updates the listbox to view books in anpther category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBoxCategories.SelectedIndex < 0)
            {
                return;
            }
            List<BookCategory> temp = api.GetBookCategories();
            foreach(BookCategory item in temp)
            {
                if (item.BookCategoryName.Equals(cmbBoxCategories.SelectedItem.ToString()))
                {
                    lstBoxOutput.Items.Clear();
                    activeBookCategory = item.BookCategoryID;
                    UpdateBooks();
                    OutputBooks();
                    return;
                }
            }
        }
        /// <summary>
        /// Updates book output information if user clicked on a book title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstBoxOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstBoxOutput.SelectedIndex;
            if (books.Any(x => x.Title.Equals(lstBoxOutput.SelectedItem)))
            {            
                OutputFullBookInfo(index);
                activeBook = books[index].ID;
                if (api.IsLoggedIn(activeUser))
                {
                    btnBuyBook.Enabled = true;
                }
                if (api.IsAdmin(activeUser))
                {
                    btnChangeAmount.Enabled = true;
                    btnUpdateBook.Enabled = true;
                }
            }
            else
            {
                activeBook = -1;
                btnBuyBook.Enabled = false;
                btnChangeAmount.Enabled = false;
                btnUpdateBook.Enabled = false;
            }
        }
        /// <summary>
        /// Adminoption: Add a new book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdminAddBook_Click(object sender, EventArgs e)
        {
            List<BookCategory> categories = api.GetBookCategories();
            AddBookForm addBook = new(categories)
            {
                Enabled = true
            };
            addBook.ShowDialog();
            if (addBook.DialogResult == DialogResult.OK)
            {

                BookCategory cat = new();
                foreach(BookCategory item in categories)
                {
                    if (item.BookCategoryName.Equals(addBook.cmbBoxCategory.SelectedItem))
                    {
                        cat = item;
                        break;
                    }
                }
                api.AddBook(adminID: activeUser, title: addBook.txtBoxTitle.Text, author: addBook.txtBoxAuthor.Text,
                    amount: Convert.ToInt32(addBook.numericAmount.Value), price: Convert.ToDouble(addBook.numericPrice.Value), 
                    categoryID: cat.BookCategoryID);
                UpdateBooks();
                CmbBoxCategoriesUserItems();
            }
            addBook.Enabled = false;
        }
        /// <summary>
        /// Adminoption: Add amount of books to a current book.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChangeAmount_Click(object sender, EventArgs e)
        {
            ChangeAmountForm amountForm = new()
            {
                Enabled = true
            };
            amountForm.ShowDialog();
            if(amountForm.DialogResult == DialogResult.OK)
            {
                api.SetAmount(activeUser, activeBook, Convert.ToInt32(amountForm.numericAmount.Value));
                UpdateBooks();
                CmbBoxCategoriesUserItems();
            }
            amountForm.Enabled = false;
        }
        /// <summary>
        /// Adminoption: Update information about a book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateBook_Click(object sender, EventArgs e)
        {
            Book book = api.GetBook(activeBook);
            List<BookCategory> categories = api.GetBookCategories();
            AddBookForm addBook = new(categories)
            {
                Enabled = true,
                Text = "Update book"
            };
            addBook.numericAmount.Value = book.Amount;
            addBook.numericAmount.Enabled = false;
            addBook.cmbBoxCategory.SelectedItem = book.BookCategory.BookCategoryName;
            addBook.cmbBoxCategory.Enabled = false;
            addBook.button1.Text = "Update book";
            addBook.ShowDialog();
            if (addBook.DialogResult == DialogResult.OK)
            {
                api.UpdateBook(adminID: activeUser, title: addBook.txtBoxTitle.Text, author: addBook.txtBoxAuthor.Text,
                    price: Convert.ToDouble(addBook.numericPrice.Value), bookID: activeBook);
                UpdateBooks();
                CmbBoxCategoriesUserItems();
            }
            addBook.Enabled = false;
        }
        /// <summary>
        /// Adminoption: Delete a book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to delete this book?", "Confirm delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(result == DialogResult.OK)
            {
                api.DeleteBook(activeUser, activeBook);
                UpdateBooks();
                CmbBoxCategoriesUserItems();
            }
        }
        /// <summary>
        /// Adminoption: Add a new category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdminAddCategory_Click(object sender, EventArgs e)
        {
            NewCategoryForm categoryForm = new()
            {
                Enabled = true
            };
            categoryForm.ShowDialog();
            if (categoryForm.DialogResult == DialogResult.OK)
            {
                string catName = categoryForm.txtBoxCategory.Text;
                api.AddCategory(activeUser, catName);
                UpdateBooks();
                CmbBoxCategoriesUserItems();
            }
            categoryForm.Enabled = false;
        }
        /// <summary>
        /// Adminoption: Remove a category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdminRemoveCategory_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to delete this category?", "Confirm delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                api.DeleteCategory(activeUser, activeBookCategory);
                UpdateBooks();
                CmbBoxCategoriesUserItems();
            }
        }
        /// <summary>
        /// Adminoption: Update a category name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdminUpdateCategory_Click(object sender, EventArgs e)
        {
            NewCategoryForm categoryForm = new()
            {
                Enabled = true,
                Text = "Update Category Name"
            };
            categoryForm.ShowDialog();
            if (categoryForm.DialogResult == DialogResult.OK)
            {
                string catName = categoryForm.txtBoxCategory.Text;
                api.UpdateCategory(activeUser, activeBookCategory,catName);
                UpdateBooks();
                CmbBoxCategoriesUserItems();
            }
            categoryForm.Enabled = false;
        }
        /// <summary>
        /// Adminoption: Change a category for a book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdminChangeCategory_Click(object sender, EventArgs e)
        {
            Book book = api.GetBook(activeBook);
            List<BookCategory> categories = api.GetBookCategories();
            AddBookForm addBook = new(categories)
            {
                Enabled = true,
                Text = "Change book category"
            };
            addBook.txtBoxTitle.Text = book.Title;
            addBook.txtBoxTitle.Enabled = false;
            addBook.txtBoxAuthor.Text = book.Author;
            addBook.txtBoxAuthor.Enabled = false;

            addBook.numericAmount.Value = book.Amount;
            addBook.numericAmount.Enabled = false;
            addBook.cmbBoxCategory.SelectedItem = book.BookCategory.BookCategoryName;
            addBook.cmbBoxCategory.Enabled = true;
            addBook.button1.Text = "Update category";
            addBook.ShowDialog();
            if (addBook.DialogResult == DialogResult.OK)
            {
                BookCategory cat = new();
                foreach (BookCategory item in categories)
                {
                    if (item.BookCategoryName.Equals(addBook.cmbBoxCategory.SelectedItem))
                    {
                        cat = item;
                        break;
                    }
                }
                api.AddBookToCategory(activeUser, bookID: book.ID, category: cat.BookCategoryID);
                UpdateBooks();
                CmbBoxCategoriesUserItems();
            }
            addBook.Enabled = false;
        }
        /// <summary>
        /// Adminoption: Shows the name of the customer that bought most amount of books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdminBestCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                User user = api.BestCustomer(activeUser);
                lstBoxOutput.Items.Clear();
                lstBoxOutput.Items.Add(user.Name + " bought most books!");
            }
            catch (ArgumentNullException)
            {
                lstBoxOutput.Items.Add("No one has bought any books yet!");
            };
        }
        /// <summary>
        /// Adminoption: Outputs the money earned from sellings books.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdminMoneyEarned_Click(object sender, EventArgs e)
        {
            double money = api.MoneyEarned(activeUser);
            lstBoxOutput.Items.Clear();
            lstBoxOutput.Items.Add($"Total earnings is  {money}  SEK");
        }
        /// <summary>
        /// Adminoption: Views all the sold books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdminViewSoldBooks_Click(object sender, EventArgs e)
        {
            List<SoldBook> soldItems = api.SoldItems(activeUser);
            SoldBookForm soldBooks = new(soldItems)
            {
                Enabled = true
            };
            soldBooks.ShowDialog();
            if (soldBooks.DialogResult == DialogResult.OK)
            { 
                soldBooks.Enabled = false; 
            }
                

        }
        /// <summary>
        /// Adminoption: Lets the Admin manage users (add new, promote, demote, activate, deactivate)
        /// and view all passwords! :) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdminManageUsers_Click(object sender, EventArgs e)
        {
            List<User> users = api.ListUsers(activeUser);
            ManageUsersForm manageUsers = new(api.ListUsers(activeUser), activeUser)
            {
                Enabled = true
            };
            manageUsers.ShowDialog();
            if (manageUsers.DialogResult == DialogResult.OK)
            {
                List<User> changedUsers = manageUsers.changes;
                foreach(User user in changedUsers)
                {
                    if (users.Any(x => x.Name.Equals(user.Name)))
                    {
                        int index = users.FindIndex(x=> x.Name.Equals(user.Name)) + 1;
                        int commandIndex = changedUsers.IndexOf(user);
                        var commands = manageUsers.commands;
                        if (commands[commandIndex] == 1)
                            api.Promote(activeUser, index);
                        else if (commands[commandIndex] == 2)
                            api.Demote(activeUser, index);
                        else if (commands[commandIndex] == 3)
                            api.ActivateUser(activeUser, index);
                        else if (commands[commandIndex] == 4)
                            api.InactivateUser(activeUser, index);
                    }
                    else
                    {
                        api.AddUser(activeUser, user.Name, user.Password);                        
                    }
                        users = api.ListUsers(activeUser);
                }
            }
            manageUsers.Enabled = false;
        }
    }
}
