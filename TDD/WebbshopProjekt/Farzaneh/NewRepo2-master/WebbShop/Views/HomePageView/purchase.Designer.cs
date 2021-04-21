
namespace WebbShop.Views.HomePageView
{
    partial class purchase
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelBookCategories = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.radioButtonAvailable = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.labelChoosenBook = new System.Windows.Forms.Label();
            this.textBoxChoosenBook = new System.Windows.Forms.TextBox();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 304);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(887, 254);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(184, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 33);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelBookCategories
            // 
            this.labelBookCategories.AutoSize = true;
            this.labelBookCategories.Location = new System.Drawing.Point(36, 25);
            this.labelBookCategories.Name = "labelBookCategories";
            this.labelBookCategories.Size = new System.Drawing.Size(142, 25);
            this.labelBookCategories.TabIndex = 2;
            this.labelBookCategories.Text = "Book Categories";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(184, 146);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(112, 34);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // radioButtonAvailable
            // 
            this.radioButtonAvailable.AutoSize = true;
            this.radioButtonAvailable.Location = new System.Drawing.Point(184, 99);
            this.radioButtonAvailable.Name = "radioButtonAvailable";
            this.radioButtonAvailable.Size = new System.Drawing.Size(162, 29);
            this.radioButtonAvailable.TabIndex = 4;
            this.radioButtonAvailable.TabStop = true;
            this.radioButtonAvailable.Text = "Available Books";
            this.radioButtonAvailable.UseVisualStyleBackColor = true;
            this.radioButtonAvailable.CheckedChanged += new System.EventHandler(this.radioButtonAvailable_CheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(184, 64);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(111, 29);
            this.radioButtonAll.TabIndex = 5;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All Books";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // labelChoosenBook
            // 
            this.labelChoosenBook.AutoSize = true;
            this.labelChoosenBook.Location = new System.Drawing.Point(461, 33);
            this.labelChoosenBook.Name = "labelChoosenBook";
            this.labelChoosenBook.Size = new System.Drawing.Size(128, 25);
            this.labelChoosenBook.TabIndex = 6;
            this.labelChoosenBook.Text = "Choosen Book";
            // 
            // textBoxChoosenBook
            // 
            this.textBoxChoosenBook.Location = new System.Drawing.Point(613, 33);
            this.textBoxChoosenBook.Name = "textBoxChoosenBook";
            this.textBoxChoosenBook.Size = new System.Drawing.Size(150, 31);
            this.textBoxChoosenBook.TabIndex = 7;
            this.textBoxChoosenBook.TextChanged += new System.EventHandler(this.textBoxChoosenBook_TextChanged);
            // 
            // buttonBuy
            // 
            this.buttonBuy.Location = new System.Drawing.Point(613, 85);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(112, 34);
            this.buttonBuy.TabIndex = 8;
            this.buttonBuy.Text = "Buy";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(779, 240);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(112, 34);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "EXIT";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(779, 191);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(112, 34);
            this.buttonHome.TabIndex = 10;
            this.buttonHome.Text = "HOME";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(731, 85);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(112, 34);
            this.buttonLogin.TabIndex = 11;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 567);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonBuy);
            this.Controls.Add(this.textBoxChoosenBook);
            this.Controls.Add(this.labelChoosenBook);
            this.Controls.Add(this.radioButtonAll);
            this.Controls.Add(this.radioButtonAvailable);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelBookCategories);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "purchase";
            this.Text = "Available Books";
            this.Load += new System.EventHandler(this.purchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelBookCategories;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RadioButton radioButtonAvailable;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.Label labelChoosenBook;
        private System.Windows.Forms.TextBox textBoxChoosenBook;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonLogin;
    }
}