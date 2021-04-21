
namespace WebbShopApiGustafMalmsten
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.cmbBoxSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnBuyBook = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lstBoxOutput = new System.Windows.Forms.ListBox();
            this.cmbBoxCategories = new System.Windows.Forms.ComboBox();
            this.lblBookID = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblBookName = new System.Windows.Forms.Label();
            this.btnAdminAddBook = new System.Windows.Forms.Button();
            this.btnChangeAmount = new System.Windows.Forms.Button();
            this.btnUpdateBook = new System.Windows.Forms.Button();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnAdminAddCategory = new System.Windows.Forms.Button();
            this.btnAdminRemoveCategory = new System.Windows.Forms.Button();
            this.btnAdminUpdateCategory = new System.Windows.Forms.Button();
            this.btnAdminChangeCategory = new System.Windows.Forms.Button();
            this.btnAdminBestCustomer = new System.Windows.Forms.Button();
            this.btnAdminViewSoldBooks = new System.Windows.Forms.Button();
            this.btnAdminMoneyEarned = new System.Windows.Forms.Button();
            this.btnAdminManageUsers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(547, 102);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(139, 89);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(547, 197);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(139, 89);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(547, 292);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(139, 89);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // cmbBoxSearch
            // 
            this.cmbBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxSearch.FormattingEnabled = true;
            this.cmbBoxSearch.Location = new System.Drawing.Point(837, 55);
            this.cmbBoxSearch.Name = "cmbBoxSearch";
            this.cmbBoxSearch.Size = new System.Drawing.Size(180, 23);
            this.cmbBoxSearch.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Location = new System.Drawing.Point(692, 102);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(180, 32);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search!";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(505, 55);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(326, 23);
            this.txtBoxSearch.TabIndex = 9;
            // 
            // btnBuyBook
            // 
            this.btnBuyBook.Location = new System.Drawing.Point(28, 392);
            this.btnBuyBook.Name = "btnBuyBook";
            this.btnBuyBook.Size = new System.Drawing.Size(139, 89);
            this.btnBuyBook.TabIndex = 11;
            this.btnBuyBook.Text = "Buy book!";
            this.btnBuyBook.UseVisualStyleBackColor = true;
            this.btnBuyBook.Click += new System.EventHandler(this.BtnBuyBook_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(28, 34);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(120, 15);
            this.lblLogin.TabIndex = 12;
            this.lblLogin.Text = "You are not logged in";
            // 
            // lstBoxOutput
            // 
            this.lstBoxOutput.FormattingEnabled = true;
            this.lstBoxOutput.ItemHeight = 15;
            this.lstBoxOutput.Location = new System.Drawing.Point(28, 52);
            this.lstBoxOutput.Name = "lstBoxOutput";
            this.lstBoxOutput.Size = new System.Drawing.Size(263, 319);
            this.lstBoxOutput.TabIndex = 13;
            this.lstBoxOutput.SelectedIndexChanged += new System.EventHandler(this.LstBoxOutput_SelectedIndexChanged);
            // 
            // cmbBoxCategories
            // 
            this.cmbBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxCategories.FormattingEnabled = true;
            this.cmbBoxCategories.Location = new System.Drawing.Point(297, 55);
            this.cmbBoxCategories.Name = "cmbBoxCategories";
            this.cmbBoxCategories.Size = new System.Drawing.Size(202, 23);
            this.cmbBoxCategories.TabIndex = 14;
            this.cmbBoxCategories.SelectedIndexChanged += new System.EventHandler(this.CmbBoxCategories_SelectedIndexChanged);
            // 
            // lblBookID
            // 
            this.lblBookID.AutoSize = true;
            this.lblBookID.Location = new System.Drawing.Point(297, 113);
            this.lblBookID.Name = "lblBookID";
            this.lblBookID.Size = new System.Drawing.Size(48, 15);
            this.lblBookID.TabIndex = 15;
            this.lblBookID.Text = "BookID:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(297, 139);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(47, 15);
            this.lblAuthor.TabIndex = 16;
            this.lblAuthor.Text = "Author:";
            this.lblAuthor.UseMnemonic = false;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(297, 169);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 15);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "Price:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(297, 195);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(62, 15);
            this.lblAmount.TabIndex = 18;
            this.lblAmount.Text = "Books left:";
            // 
            // lblBookName
            // 
            this.lblBookName.AutoSize = true;
            this.lblBookName.Location = new System.Drawing.Point(297, 85);
            this.lblBookName.Name = "lblBookName";
            this.lblBookName.Size = new System.Drawing.Size(67, 15);
            this.lblBookName.TabIndex = 19;
            this.lblBookName.Text = "Bookname:";
            // 
            // btnAdminAddBook
            // 
            this.btnAdminAddBook.Location = new System.Drawing.Point(173, 392);
            this.btnAdminAddBook.Name = "btnAdminAddBook";
            this.btnAdminAddBook.Size = new System.Drawing.Size(143, 89);
            this.btnAdminAddBook.TabIndex = 20;
            this.btnAdminAddBook.Text = "Add book";
            this.btnAdminAddBook.UseVisualStyleBackColor = true;
            this.btnAdminAddBook.Click += new System.EventHandler(this.BtnAdminAddBook_Click);
            // 
            // btnChangeAmount
            // 
            this.btnChangeAmount.Location = new System.Drawing.Point(297, 213);
            this.btnChangeAmount.Name = "btnChangeAmount";
            this.btnChangeAmount.Size = new System.Drawing.Size(111, 23);
            this.btnChangeAmount.TabIndex = 21;
            this.btnChangeAmount.Text = "Change amount";
            this.btnChangeAmount.UseVisualStyleBackColor = true;
            this.btnChangeAmount.Click += new System.EventHandler(this.BtnChangeAmount_Click);
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Location = new System.Drawing.Point(297, 242);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(111, 23);
            this.btnUpdateBook.TabIndex = 22;
            this.btnUpdateBook.Text = "Update book";
            this.btnUpdateBook.UseVisualStyleBackColor = true;
            this.btnUpdateBook.Click += new System.EventHandler(this.BtnUpdateBook_Click);
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(322, 392);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(162, 89);
            this.btnDeleteBook.TabIndex = 23;
            this.btnDeleteBook.Text = "Delete Book";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            this.btnDeleteBook.Click += new System.EventHandler(this.BtnDeleteBook_Click);
            // 
            // btnAdminAddCategory
            // 
            this.btnAdminAddCategory.Location = new System.Drawing.Point(417, 213);
            this.btnAdminAddCategory.Name = "btnAdminAddCategory";
            this.btnAdminAddCategory.Size = new System.Drawing.Size(114, 23);
            this.btnAdminAddCategory.TabIndex = 24;
            this.btnAdminAddCategory.Text = "Add Category";
            this.btnAdminAddCategory.UseVisualStyleBackColor = true;
            this.btnAdminAddCategory.Click += new System.EventHandler(this.BtnAdminAddCategory_Click);
            // 
            // btnAdminRemoveCategory
            // 
            this.btnAdminRemoveCategory.Location = new System.Drawing.Point(417, 271);
            this.btnAdminRemoveCategory.Name = "btnAdminRemoveCategory";
            this.btnAdminRemoveCategory.Size = new System.Drawing.Size(114, 23);
            this.btnAdminRemoveCategory.TabIndex = 25;
            this.btnAdminRemoveCategory.Text = "Remove Category";
            this.btnAdminRemoveCategory.UseVisualStyleBackColor = true;
            this.btnAdminRemoveCategory.Click += new System.EventHandler(this.BtnAdminRemoveCategory_Click);
            // 
            // btnAdminUpdateCategory
            // 
            this.btnAdminUpdateCategory.Location = new System.Drawing.Point(417, 242);
            this.btnAdminUpdateCategory.Name = "btnAdminUpdateCategory";
            this.btnAdminUpdateCategory.Size = new System.Drawing.Size(114, 23);
            this.btnAdminUpdateCategory.TabIndex = 26;
            this.btnAdminUpdateCategory.Text = "Update Category";
            this.btnAdminUpdateCategory.UseVisualStyleBackColor = true;
            this.btnAdminUpdateCategory.Click += new System.EventHandler(this.BtnAdminUpdateCategory_Click);
            // 
            // btnAdminChangeCategory
            // 
            this.btnAdminChangeCategory.Location = new System.Drawing.Point(297, 272);
            this.btnAdminChangeCategory.Name = "btnAdminChangeCategory";
            this.btnAdminChangeCategory.Size = new System.Drawing.Size(111, 23);
            this.btnAdminChangeCategory.TabIndex = 27;
            this.btnAdminChangeCategory.Text = "Change category";
            this.btnAdminChangeCategory.UseVisualStyleBackColor = true;
            this.btnAdminChangeCategory.Click += new System.EventHandler(this.BtnAdminChangeCategory_Click);
            // 
            // btnAdminBestCustomer
            // 
            this.btnAdminBestCustomer.Location = new System.Drawing.Point(297, 301);
            this.btnAdminBestCustomer.Name = "btnAdminBestCustomer";
            this.btnAdminBestCustomer.Size = new System.Drawing.Size(234, 27);
            this.btnAdminBestCustomer.TabIndex = 28;
            this.btnAdminBestCustomer.Text = "View best customer";
            this.btnAdminBestCustomer.UseVisualStyleBackColor = true;
            this.btnAdminBestCustomer.Click += new System.EventHandler(this.BtnAdminBestCustomer_Click);
            // 
            // btnAdminViewSoldBooks
            // 
            this.btnAdminViewSoldBooks.Location = new System.Drawing.Point(297, 334);
            this.btnAdminViewSoldBooks.Name = "btnAdminViewSoldBooks";
            this.btnAdminViewSoldBooks.Size = new System.Drawing.Size(234, 23);
            this.btnAdminViewSoldBooks.TabIndex = 29;
            this.btnAdminViewSoldBooks.Text = "View Sold Books";
            this.btnAdminViewSoldBooks.UseVisualStyleBackColor = true;
            this.btnAdminViewSoldBooks.Click += new System.EventHandler(this.BtnAdminViewSoldBooks_Click);
            // 
            // btnAdminMoneyEarned
            // 
            this.btnAdminMoneyEarned.Location = new System.Drawing.Point(297, 363);
            this.btnAdminMoneyEarned.Name = "btnAdminMoneyEarned";
            this.btnAdminMoneyEarned.Size = new System.Drawing.Size(234, 23);
            this.btnAdminMoneyEarned.TabIndex = 30;
            this.btnAdminMoneyEarned.Text = "Money earned";
            this.btnAdminMoneyEarned.UseVisualStyleBackColor = true;
            this.btnAdminMoneyEarned.Click += new System.EventHandler(this.BtnAdminMoneyEarned_Click);
            // 
            // btnAdminManageUsers
            // 
            this.btnAdminManageUsers.Location = new System.Drawing.Point(490, 392);
            this.btnAdminManageUsers.Name = "btnAdminManageUsers";
            this.btnAdminManageUsers.Size = new System.Drawing.Size(169, 89);
            this.btnAdminManageUsers.TabIndex = 31;
            this.btnAdminManageUsers.Text = "Manage Users";
            this.btnAdminManageUsers.UseVisualStyleBackColor = true;
            this.btnAdminManageUsers.Click += new System.EventHandler(this.BtnAdminManageUsers_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 493);
            this.Controls.Add(this.btnAdminManageUsers);
            this.Controls.Add(this.btnAdminMoneyEarned);
            this.Controls.Add(this.btnAdminViewSoldBooks);
            this.Controls.Add(this.btnAdminBestCustomer);
            this.Controls.Add(this.btnAdminChangeCategory);
            this.Controls.Add(this.btnAdminUpdateCategory);
            this.Controls.Add(this.btnAdminRemoveCategory);
            this.Controls.Add(this.btnAdminAddCategory);
            this.Controls.Add(this.btnDeleteBook);
            this.Controls.Add(this.btnUpdateBook);
            this.Controls.Add(this.btnChangeAmount);
            this.Controls.Add(this.btnAdminAddBook);
            this.Controls.Add(this.lblBookName);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblBookID);
            this.Controls.Add(this.cmbBoxCategories);
            this.Controls.Add(this.lstBoxOutput);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.btnBuyBook);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbBoxSearch);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cmbBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Button btnBuyBook;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.ListBox lstBoxOutput;
        private System.Windows.Forms.ComboBox cmbBoxCategories;
        private System.Windows.Forms.Label lblBookID;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblBookName;
        private System.Windows.Forms.Button btnAdminAddBook;
        private System.Windows.Forms.Button btnChangeAmount;
        private System.Windows.Forms.Button btnUpdateBook;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnAdminAddCategory;
        private System.Windows.Forms.Button btnAdminRemoveCategory;
        public System.Windows.Forms.Button btnAdminUpdateCategory;
        private System.Windows.Forms.Button btnAdminChangeCategory;
        private System.Windows.Forms.Button btnAdminBestCustomer;
        private System.Windows.Forms.Button btnAdminViewSoldBooks;
        private System.Windows.Forms.Button btnAdminMoneyEarned;
        private System.Windows.Forms.Button btnAdminManageUsers;
    }
}

