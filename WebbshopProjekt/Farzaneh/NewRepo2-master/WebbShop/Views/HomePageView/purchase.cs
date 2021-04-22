namespace WebbShop.Views.HomePageView
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WebbShop.Controllers;
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="purchase" />.
    /// </summary>
    public partial class purchase : Form
    {
        /// <summary>
        /// Defines the books.
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="purchase"/> class.
        /// </summary>
        public purchase()
        {
            InitializeComponent();
            List<BookCategory> categories = WebbShopAPIHelper.GetCategories();
            comboBox1.Text = "Book Categories";
            foreach (var item in categories)
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        /// <summary>
        /// The comboBox1_SelectedIndexChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The purchase_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void purchase_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The buttonOk_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please choose a category");
            }
            else
            {
                ShowBooksInCategory bookInCategory = new ShowBooksInCategory();
                bookInCategory.CategoryName = comboBox1.SelectedItem.ToString();
                if (radioButtonAvailable.Checked)
                {
                    books = bookInCategory.DisplayAvailableBooks();
                    dataGridView1.DataSource = books;
                }
                else
                {
                    books = bookInCategory.Display();
                    dataGridView1.DataSource = books;
                }
            }
        }

        /// <summary>
        /// The radioButtonAvailable_CheckedChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void radioButtonAvailable_CheckedChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The dataGridView1_CellContentClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/>.</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBoxChoosenBook.Text = selectedRow.Cells[1].Value.ToString();
        }

        /// <summary>
        /// The buttonBuy_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonBuy_Click(object sender, EventArgs e)
        {
            BuyBook buybook = new BuyBook();
            buybook.BookTitle = textBoxChoosenBook.Text;
            if (buybook.buy())
            {
                MessageBox.Show("Purchase was done successfully");
            }
            else
            {
                MessageBox.Show("Please Login ");
            }
            textBoxChoosenBook.Clear();
        }

        /// <summary>
        /// The textBoxChoosenBook_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBoxChoosenBook_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The buttonHome_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HomePage().ShowDialog();
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
        /// The buttonLogin_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            new LogIn().ShowDialog();
        }
    }
}
