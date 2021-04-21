namespace WebbShop.Views.AdminView
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WebbShop.Controllers;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="ShowMoneyEarned" />.
    /// </summary>
    public partial class ShowMoneyEarned : Form
    {
        /// <summary>
        /// Defines the SoldBooks.
        /// </summary>
        private List<SoldBook> SoldBooks = new List<SoldBook>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowMoneyEarned"/> class.
        /// </summary>
        public ShowMoneyEarned()
        {
            InitializeComponent();
            List<SoldBook> soldBooks = new ShowSoldBooks().ListBooks();
            dataGridView1.DataSource = soldBooks;
            if (soldBooks.Count != 0)
            {
                User customer = new User();
                customer = new ShowBestCustomer().BestCustomr();
                labelID.Text = "User ID: " + customer.ToString();
                labelName.Text = "Customer Name: " + customer.Name;
                labelEarnedMoney.Text = new MoneyEarned().Show().ToString() + "(kr)";
            }
        }

        /// <summary>
        /// The textBoxSelect_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBoxSelect_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The textBox1_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The ShowMoneyEarned_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void ShowMoneyEarned_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The dataGridView1_CellContentClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/>.</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// The label1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The labelEarnedMoney_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void labelEarnedMoney_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label2_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label2_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The labelID_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void labelID_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The buttonExit_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            new Logout().LogoutUser();
            Environment.Exit(0);
        }

        /// <summary>
        /// The buttonHome_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminMenu().ShowDialog();
        }
    }
}
