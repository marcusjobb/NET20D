using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebbShopAPIGustafMalmsten.Model;

namespace WebbShopAPIGustafMalmstenFrontEnd
{
    public partial class ManageUsersForm : Form
    {
        public List<User> changes = new();
        public List<int> commands = new();
        public List<User> Users;
        private int currentUserID;

        public ManageUsersForm(List <User> users, int userID)
        {
            InitializeComponent();
            Users = users;
            currentUserID = userID;
            foreach(User user in users)
            {
                OutputUser(user);
            }
            btnPromoteUser.Enabled = false;
            btnDemoteUser.Enabled = false;
            btnActivateUser.Enabled = false;
            btnDeactivateUser.Enabled = false;
        }

        public RegForm RegForm
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Outputs the User object in the listview
        /// </summary>
        /// <param name="user">The User object to output</param>
        public void OutputUser(User user)
        {
            string[] rad = {user.UserID.ToString(), user.Name, user.Password,
                    user.LastLogin.ToString(), user.SessionTimer.ToString(),
                    user.IsActive.ToString(), user.IsAdmin.ToString()};
            var listViewItem = new ListViewItem(rad);

            lstViewUsers.Items.Add(listViewItem);
        }
        /// <summary>
        /// Updates the user information at a column
        /// </summary>
        /// <param name="index">The row to edit information</param>
        /// <param name="columnNumber">The column to edit information</param>
        /// <param name="value">The information to input</param>
        public void UpdateUser(int index, int columnNumber, bool value)
        {
            foreach(ListViewItem item in lstViewUsers.Items)
            {
                if (item.Index == index)
                {
                    item.SubItems[columnNumber].Text = value.ToString();
                    break;
                }
            }
        }
        /// <summary>
        /// Register/Add a new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            RegForm reg = new()
            {
                Enabled = true
            };
            reg.txtVerifyPassword.Enabled = false;

            reg.ShowDialog();
            if (reg.DialogResult == DialogResult.OK)
            {
                int id = 0;
                if (!changes.Any() && !Users.Any())
                    id = 1;
                else
                    id = changes.Any() == true ? Math.Max(Users[^1].UserID, changes[^1].UserID) + 1 : Users[^1].UserID + 1;
                User user = new()
                {
                    UserID = id,
                    Name = reg.txtUsername.Text,
                    Password = reg.txtPassword.Text,
                    LastLogin = DateTime.Now,
                    SessionTimer = DateTime.Now,
                    IsActive = false,
                    IsAdmin = false
                };
                bool ok = true;
                foreach (User user1 in Users)
                {
                    if (user1.Name.Equals(user.Name) || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password))
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok) 
                {
                    changes.Add(user);
                    Users.Add(user);
                    OutputUser(user);
                    commands.Add(0);
                }
                reg.Enabled = false;
            }
        }
        /// <summary>
        /// Enables buttons if anything is selected in the listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPromoteUser.Enabled = true;
            btnDemoteUser.Enabled = true;
            btnActivateUser.Enabled = true;
            btnDeactivateUser.Enabled = true;
        }
        /// <summary>
        /// Promotes the selected user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPromoteUser_Click(object sender, EventArgs e)
        {
            if(lstViewUsers.SelectedItems.Count <= 0)
            {
                return;
            }
            int index = lstViewUsers.Items.IndexOf(lstViewUsers.SelectedItems[0]);
            if (Users[index].UserID == currentUserID)
            {
                return;
            }
            changes.Add(Users[index]);
            changes[^1].IsAdmin = true;
            commands.Add(1);
            UpdateUser(index, 6, true);
        }
        /// <summary>
        /// Demotes the selected user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDemoteUser_Click(object sender, EventArgs e)
        {
            if (lstViewUsers.SelectedItems.Count <= 0)
            {
                return;
            }
            int index = lstViewUsers.Items.IndexOf(lstViewUsers.SelectedItems[0]);
            if (Users[index].UserID == currentUserID)
            {
                return;
            }
            else
            {
                changes.Add(Users[index]);
                changes[^1].IsAdmin = false;
                commands.Add(2);
                UpdateUser(index, 6, false);
            }
        }
        /// <summary>
        /// Activates the selected user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnActivateUser_Click(object sender, EventArgs e)
        {
            if (lstViewUsers.SelectedItems.Count <= 0)
            {
                return;
            }
            int index = lstViewUsers.Items.IndexOf(lstViewUsers.SelectedItems[0]);
            if (Users[index].UserID == currentUserID)
            {
                return;
            }
            else
            {
                changes.Add(Users[index]);
                changes[^1].IsActive = true;
                commands.Add(3);
                UpdateUser(index, 5, true);
            }
        }
        /// <summary>
        /// Deactivates the selected user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeactivateUser_Click(object sender, EventArgs e)
        {
            if (lstViewUsers.SelectedItems.Count <= 0)
            {
                return;
            }
            int index = lstViewUsers.Items.IndexOf(lstViewUsers.SelectedItems[0]);
            if (Users[index].UserID == currentUserID)
            {
                return;
            }
            else
            {
                changes.Add(Users[index]);
                changes[^1].IsActive = false;
                commands.Add(4);
                UpdateUser(index, 5, false);
            }
        }
    }
}
