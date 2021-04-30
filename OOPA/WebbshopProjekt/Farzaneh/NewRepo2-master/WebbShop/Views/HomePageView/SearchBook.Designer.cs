
namespace WebbShop.Views.HomePageView
{
    partial class SearchBook
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
            this.labelBookTitle = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.textBoxBookTitle = new System.Windows.Forms.TextBox();
            this.buttonSearchByTitle = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labelbookID = new System.Windows.Forms.Label();
            this.textBoxBookID = new System.Windows.Forms.TextBox();
            this.buttonBookID = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonBuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1018, 322);
            this.dataGridView1.TabIndex = 0;
            // 
            // labelBookTitle
            // 
            this.labelBookTitle.AutoSize = true;
            this.labelBookTitle.Location = new System.Drawing.Point(31, 27);
            this.labelBookTitle.Name = "labelBookTitle";
            this.labelBookTitle.Size = new System.Drawing.Size(90, 25);
            this.labelBookTitle.TabIndex = 1;
            this.labelBookTitle.Text = "Book Title";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(210, 27);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(113, 25);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "Book Author";
            // 
            // textBoxBookTitle
            // 
            this.textBoxBookTitle.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxBookTitle.Location = new System.Drawing.Point(31, 55);
            this.textBoxBookTitle.Name = "textBoxBookTitle";
            this.textBoxBookTitle.Size = new System.Drawing.Size(150, 31);
            this.textBoxBookTitle.TabIndex = 3;
            this.textBoxBookTitle.Text = "Keyword";
            // 
            // buttonSearchByTitle
            // 
            this.buttonSearchByTitle.Location = new System.Drawing.Point(31, 109);
            this.buttonSearchByTitle.Name = "buttonSearchByTitle";
            this.buttonSearchByTitle.Size = new System.Drawing.Size(150, 34);
            this.buttonSearchByTitle.TabIndex = 4;
            this.buttonSearchByTitle.Text = "Search by Title";
            this.buttonSearchByTitle.UseVisualStyleBackColor = true;
            this.buttonSearchByTitle.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox2.Location = new System.Drawing.Point(210, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(158, 31);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Keyword";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "Search By Author";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelbookID
            // 
            this.labelbookID.AutoSize = true;
            this.labelbookID.Location = new System.Drawing.Point(401, 27);
            this.labelbookID.Name = "labelbookID";
            this.labelbookID.Size = new System.Drawing.Size(76, 25);
            this.labelbookID.TabIndex = 7;
            this.labelbookID.Text = "Book ID";
            // 
            // textBoxBookID
            // 
            this.textBoxBookID.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxBookID.Location = new System.Drawing.Point(401, 55);
            this.textBoxBookID.Name = "textBoxBookID";
            this.textBoxBookID.Size = new System.Drawing.Size(167, 31);
            this.textBoxBookID.TabIndex = 8;
            // 
            // buttonBookID
            // 
            this.buttonBookID.Location = new System.Drawing.Point(401, 109);
            this.buttonBookID.Name = "buttonBookID";
            this.buttonBookID.Size = new System.Drawing.Size(167, 34);
            this.buttonBookID.TabIndex = 9;
            this.buttonBookID.Text = "Search By Book ID";
            this.buttonBookID.UseVisualStyleBackColor = true;
            this.buttonBookID.Click += new System.EventHandler(this.buttonBookID_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(875, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 44);
            this.button3.TabIndex = 11;
            this.button3.Text = "EXIT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(875, 13);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(133, 39);
            this.buttonHome.TabIndex = 12;
            this.buttonHome.Text = "HOME";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonBuy
            // 
            this.buttonBuy.Location = new System.Drawing.Point(875, 136);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(133, 44);
            this.buttonBuy.TabIndex = 13;
            this.buttonBuy.Text = "BUY";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // SearchBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 542);
            this.Controls.Add(this.buttonBuy);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonBookID);
            this.Controls.Add(this.textBoxBookID);
            this.Controls.Add(this.labelbookID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonSearchByTitle);
            this.Controls.Add(this.textBoxBookTitle);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelBookTitle);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SearchBook";
            this.Text = "SearchBook";
            this.Load += new System.EventHandler(this.SearchBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelBookTitle;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox textBoxBookTitle;
        private System.Windows.Forms.Button buttonSearchByTitle;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelbookID;
        private System.Windows.Forms.TextBox textBoxBookID;
        private System.Windows.Forms.Button buttonBookID;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonBuy;
    }
}