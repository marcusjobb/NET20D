
namespace WebbShop.Views.AdminView
{
    partial class ShowMoneyEarned
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
            this.labelMoneyEarned = new System.Windows.Forms.Label();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelBestCustomer = new System.Windows.Forms.Label();
            this.labelEranedMoney = new System.Windows.Forms.Label();
            this.labelCustomerID = new System.Windows.Forms.Label();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.labelEarnedMoney = new System.Windows.Forms.Label();
            this.labelSoldItem = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-5, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(910, 347);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelMoneyEarned
            // 
            this.labelMoneyEarned.AutoSize = true;
            this.labelMoneyEarned.Location = new System.Drawing.Point(24, 37);
            this.labelMoneyEarned.Name = "labelMoneyEarned";
            this.labelMoneyEarned.Size = new System.Drawing.Size(135, 25);
            this.labelMoneyEarned.TabIndex = 4;
            this.labelMoneyEarned.Text = "Money Earned :";
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(777, 19);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(112, 34);
            this.buttonHome.TabIndex = 6;
            this.buttonHome.Text = "HOME";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(777, 73);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(112, 34);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "EXIT";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelBestCustomer
            // 
            this.labelBestCustomer.AutoSize = true;
            this.labelBestCustomer.Location = new System.Drawing.Point(24, 82);
            this.labelBestCustomer.Name = "labelBestCustomer";
            this.labelBestCustomer.Size = new System.Drawing.Size(136, 25);
            this.labelBestCustomer.TabIndex = 9;
            this.labelBestCustomer.Text = "Best Customer :";
            // 
            // labelEranedMoney
            // 
            this.labelEranedMoney.AutoSize = true;
            this.labelEranedMoney.Location = new System.Drawing.Point(190, 37);
            this.labelEranedMoney.Name = "labelEranedMoney";
            this.labelEranedMoney.Size = new System.Drawing.Size(0, 25);
            this.labelEranedMoney.TabIndex = 10;
            this.labelEranedMoney.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelCustomerID
            // 
            this.labelCustomerID.AutoSize = true;
            this.labelCustomerID.Location = new System.Drawing.Point(181, 82);
            this.labelCustomerID.Name = "labelCustomerID";
            this.labelCustomerID.Size = new System.Drawing.Size(0, 25);
            this.labelCustomerID.TabIndex = 11;
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(246, 82);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(0, 25);
            this.labelCustomerName.TabIndex = 12;
            // 
            // labelEarnedMoney
            // 
            this.labelEarnedMoney.AutoSize = true;
            this.labelEarnedMoney.Location = new System.Drawing.Point(181, 37);
            this.labelEarnedMoney.Name = "labelEarnedMoney";
            this.labelEarnedMoney.Size = new System.Drawing.Size(42, 25);
            this.labelEarnedMoney.TabIndex = 13;
            this.labelEarnedMoney.Text = "0 kr";
            this.labelEarnedMoney.Click += new System.EventHandler(this.labelEarnedMoney_Click);
            // 
            // labelSoldItem
            // 
            this.labelSoldItem.AutoSize = true;
            this.labelSoldItem.Location = new System.Drawing.Point(6, 157);
            this.labelSoldItem.Name = "labelSoldItem";
            this.labelSoldItem.Size = new System.Drawing.Size(102, 25);
            this.labelSoldItem.TabIndex = 14;
            this.labelSoldItem.Text = "Sold Books";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(187, 82);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(74, 25);
            this.labelID.TabIndex = 15;
            this.labelID.Text = "User ID:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(187, 116);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(145, 25);
            this.labelName.TabIndex = 16;
            this.labelName.Text = "Customer Name:";
            // 
            // ShowMoneyEarned
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 536);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelSoldItem);
            this.Controls.Add(this.labelEarnedMoney);
            this.Controls.Add(this.labelCustomerName);
            this.Controls.Add(this.labelCustomerID);
            this.Controls.Add(this.labelEranedMoney);
            this.Controls.Add(this.labelBestCustomer);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.labelMoneyEarned);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ShowMoneyEarned";
            this.Text = "ShowMoneyEarned";
            this.Load += new System.EventHandler(this.ShowMoneyEarned_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelMoneyEarned;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelBestCustomer;
        private System.Windows.Forms.Label labelEranedMoney;
        private System.Windows.Forms.Label labelCustomerID;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.Label labelEarnedMoney;
        private System.Windows.Forms.Label labelSoldItem;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelName;
    }
}