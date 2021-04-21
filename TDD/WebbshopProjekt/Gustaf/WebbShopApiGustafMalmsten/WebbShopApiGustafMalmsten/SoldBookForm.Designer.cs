
namespace WebbShopAPIGustafMalmstenFrontEnd
{
    partial class SoldBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstViewSoldBooks = new System.Windows.Forms.ListView();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.Title = new System.Windows.Forms.ColumnHeader();
            this.Author = new System.Windows.Forms.ColumnHeader();
            this.Price = new System.Windows.Forms.ColumnHeader();
            this.Purchasedate = new System.Windows.Forms.ColumnHeader();
            this.BookCategoryID = new System.Windows.Forms.ColumnHeader();
            this.BookCategory = new System.Windows.Forms.ColumnHeader();
            this.UserID = new System.Windows.Forms.ColumnHeader();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstViewSoldBooks
            // 
            this.lstViewSoldBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.Author,
            this.Price,
            this.Purchasedate,
            this.BookCategoryID,
            this.BookCategory,
            this.UserID});
            this.lstViewSoldBooks.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstViewSoldBooks.FullRowSelect = true;
            this.lstViewSoldBooks.GridLines = true;
            this.lstViewSoldBooks.HideSelection = false;
            this.lstViewSoldBooks.Location = new System.Drawing.Point(12, 23);
            this.lstViewSoldBooks.Name = "lstViewSoldBooks";
            this.lstViewSoldBooks.Size = new System.Drawing.Size(1023, 388);
            this.lstViewSoldBooks.TabIndex = 0;
            this.lstViewSoldBooks.UseCompatibleStateImageBehavior = false;
            this.lstViewSoldBooks.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 40;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 200;
            // 
            // Author
            // 
            this.Author.Text = "Author";
            this.Author.Width = 160;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 90;
            // 
            // Purchasedate
            // 
            this.Purchasedate.Text = "Purchase date";
            this.Purchasedate.Width = 200;
            // 
            // BookCategoryID
            // 
            this.BookCategoryID.Text = "Book Category ID";
            this.BookCategoryID.Width = 105;
            // 
            // BookCategory
            // 
            this.BookCategory.Text = "Book Category";
            this.BookCategory.Width = 160;
            // 
            // UserID
            // 
            this.UserID.Text = "User ID";
            this.UserID.Width = 50;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExit.Location = new System.Drawing.Point(295, 417);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(403, 54);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // SoldBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 483);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lstViewSoldBooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SoldBookForm";
            this.Text = "SoldBookForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstViewSoldBooks;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Purchasedate;
        private System.Windows.Forms.ColumnHeader BookCategoryID;
        private System.Windows.Forms.ColumnHeader BookCategory;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ColumnHeader Author;
    }
}