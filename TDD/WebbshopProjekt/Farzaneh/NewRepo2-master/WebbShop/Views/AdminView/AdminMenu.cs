namespace WebbShop.Views.AdminView
{
    using System;
    using System.Windows.Forms;
    using WebbShop.Controllers;

    /// <summary>
    /// Defines the <see cref="AdminMenu" />.
    /// </summary>
    public partial class AdminMenu : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminMenu"/> class.
        /// </summary>
        public AdminMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows book menu
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Books().ShowDialog();
        }

        /// <summary>
        /// Shows all sold books
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SoldBooks().ShowDialog();
        }

        /// <summary>
        /// The AdminMenu_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void AdminMenu_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Shows User menu
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Users().ShowDialog();
        }

        /// <summary>
        /// Shows category menu
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CategoryOptions().ShowDialog();
        }

        /// <summary>
        /// Shows moneyEarned menu
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ShowMoneyEarned().ShowDialog();
        }

        /// <summary>
        /// The button7_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button7_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Exit the program
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonexit_Click(object sender, EventArgs e)
        {
            new Logout().LogoutUser();
            Environment.Exit(0);
        }

        /// <summary>
        /// Logout the user
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (new Logout().LogoutUser())
            {
                MessageBox.Show("User Logout successfully");
                this.Hide();
                new HomePage().ShowDialog();
            }
            else
            {
                MessageBox.Show("Could not Logout");
            }
        }

        /// <summary>
        /// Shows home menu
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HomePage().ShowDialog();
        }
    }
}
