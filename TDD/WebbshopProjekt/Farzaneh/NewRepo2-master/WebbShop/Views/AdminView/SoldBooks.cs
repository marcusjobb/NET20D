namespace WebbShop.Views
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WebbShop.Controllers;
    using WebbShop.Views.AdminView;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="SoldBooks" />.
    /// </summary>
    public partial class SoldBooks : Form
    {
        /// <summary>
        /// Defines the ListOfSoldBooks.
        /// </summary>
        private List<SoldBook> ListOfSoldBooks = new List<SoldBook>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SoldBooks"/> class.
        /// </summary>
        public SoldBooks()
        {
            InitializeComponent();
            ListOfSoldBooks = new ShowSoldBooks().ListBooks();
            dataGridView1.DataSource = ListOfSoldBooks;
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
        /// The button2_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminMenu().ShowDialog();
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
        /// The SoldBooks_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void SoldBooks_Load(object sender, EventArgs e)
        {
        }
    }
}
