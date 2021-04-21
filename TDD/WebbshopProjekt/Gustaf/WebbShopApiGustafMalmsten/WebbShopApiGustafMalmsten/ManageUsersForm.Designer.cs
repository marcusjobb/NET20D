
namespace WebbShopAPIGustafMalmstenFrontEnd
{
    partial class ManageUsersForm
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
            this.lstViewUsers = new System.Windows.Forms.ListView();
            this.UserID = new System.Windows.Forms.ColumnHeader();
            this.UserName = new System.Windows.Forms.ColumnHeader();
            this.Password = new System.Windows.Forms.ColumnHeader();
            this.LastLogin = new System.Windows.Forms.ColumnHeader();
            this.SessionTimer = new System.Windows.Forms.ColumnHeader();
            this.IsActive = new System.Windows.Forms.ColumnHeader();
            this.IsAdmin = new System.Windows.Forms.ColumnHeader();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnPromoteUser = new System.Windows.Forms.Button();
            this.btnDemoteUser = new System.Windows.Forms.Button();
            this.btnActivateUser = new System.Windows.Forms.Button();
            this.btnDeactivateUser = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstViewUsers
            // 
            this.lstViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserID,
            this.UserName,
            this.Password,
            this.LastLogin,
            this.SessionTimer,
            this.IsActive,
            this.IsAdmin});
            this.lstViewUsers.HideSelection = false;
            this.lstViewUsers.Location = new System.Drawing.Point(22, 33);
            this.lstViewUsers.Name = "lstViewUsers";
            this.lstViewUsers.Size = new System.Drawing.Size(814, 266);
            this.lstViewUsers.TabIndex = 0;
            this.lstViewUsers.UseCompatibleStateImageBehavior = false;
            this.lstViewUsers.View = System.Windows.Forms.View.Details;
            this.lstViewUsers.SelectedIndexChanged += new System.EventHandler(this.LstViewUsers_SelectedIndexChanged);
            // 
            // UserID
            // 
            this.UserID.Text = "User ID";
            // 
            // UserName
            // 
            this.UserName.Text = "Username";
            this.UserName.Width = 150;
            // 
            // Password
            // 
            this.Password.Text = "Password";
            this.Password.Width = 100;
            // 
            // LastLogin
            // 
            this.LastLogin.Text = "Last Login";
            this.LastLogin.Width = 150;
            // 
            // SessionTimer
            // 
            this.SessionTimer.Text = "Session Timer";
            this.SessionTimer.Width = 150;
            // 
            // IsActive
            // 
            this.IsActive.Text = "Is Active?";
            this.IsActive.Width = 100;
            // 
            // IsAdmin
            // 
            this.IsAdmin.Text = "Is Admin?";
            this.IsAdmin.Width = 100;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(22, 305);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(90, 34);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnPromoteUser
            // 
            this.btnPromoteUser.Location = new System.Drawing.Point(118, 305);
            this.btnPromoteUser.Name = "btnPromoteUser";
            this.btnPromoteUser.Size = new System.Drawing.Size(87, 34);
            this.btnPromoteUser.TabIndex = 2;
            this.btnPromoteUser.Text = "Promote User";
            this.btnPromoteUser.UseVisualStyleBackColor = true;
            this.btnPromoteUser.Click += new System.EventHandler(this.BtnPromoteUser_Click);
            // 
            // btnDemoteUser
            // 
            this.btnDemoteUser.Location = new System.Drawing.Point(211, 305);
            this.btnDemoteUser.Name = "btnDemoteUser";
            this.btnDemoteUser.Size = new System.Drawing.Size(83, 34);
            this.btnDemoteUser.TabIndex = 3;
            this.btnDemoteUser.Text = "Demote User";
            this.btnDemoteUser.UseVisualStyleBackColor = true;
            this.btnDemoteUser.Click += new System.EventHandler(this.BtnDemoteUser_Click);
            // 
            // btnActivateUser
            // 
            this.btnActivateUser.Location = new System.Drawing.Point(300, 305);
            this.btnActivateUser.Name = "btnActivateUser";
            this.btnActivateUser.Size = new System.Drawing.Size(95, 34);
            this.btnActivateUser.TabIndex = 4;
            this.btnActivateUser.Text = "Activate User";
            this.btnActivateUser.UseVisualStyleBackColor = true;
            this.btnActivateUser.Click += new System.EventHandler(this.BtnActivateUser_Click);
            // 
            // btnDeactivateUser
            // 
            this.btnDeactivateUser.Location = new System.Drawing.Point(401, 305);
            this.btnDeactivateUser.Name = "btnDeactivateUser";
            this.btnDeactivateUser.Size = new System.Drawing.Size(98, 34);
            this.btnDeactivateUser.TabIndex = 5;
            this.btnDeactivateUser.Text = "Deactivate User";
            this.btnDeactivateUser.UseVisualStyleBackColor = true;
            this.btnDeactivateUser.Click += new System.EventHandler(this.BtnDeactivateUser_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(22, 373);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 34);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(174, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ManageUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeactivateUser);
            this.Controls.Add(this.btnActivateUser);
            this.Controls.Add(this.btnDemoteUser);
            this.Controls.Add(this.btnPromoteUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lstViewUsers);
            this.Name = "ManageUsersForm";
            this.Text = "Users";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstViewUsers;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.ColumnHeader LastLogin;
        private System.Windows.Forms.ColumnHeader SessionTimer;
        private System.Windows.Forms.ColumnHeader IsActive;
        private System.Windows.Forms.ColumnHeader IsAdmin;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnPromoteUser;
        private System.Windows.Forms.Button btnDemoteUser;
        private System.Windows.Forms.Button btnActivateUser;
        private System.Windows.Forms.Button btnDeactivateUser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader UserName;
    }
}