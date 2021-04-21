namespace WebbShop.Views.HomePageView
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WebbShop.Controllers;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="SearchBook" />.
    /// </summary>
    public partial class SearchBook : Form
    {
        /// <summary>
        /// Defines the ListOfBooks.
        /// </summary>
        private List<Book> ListOfBooks = new List<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchBook"/> class.
        /// </summary>
        public SearchBook()
        {
            InitializeComponent();
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
        /// The button1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBookByTitle searchBook = new SearchBookByTitle();
                searchBook.Keyword = textBoxBookTitle.Text;
                ListOfBooks = searchBook.Search();
                dataGridView1.DataSource = ListOfBooks;
            }
            catch
            {
                MessageBox.Show("Please enter correct value");
            }
        }

        /// <summary>
        /// The SearchBook_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void SearchBook_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The button2_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SearchByAuthor searchBook = new SearchByAuthor();
                searchBook.Keyword = textBox2.Text;
                ListOfBooks = searchBook.Search();
                dataGridView1.DataSource = ListOfBooks;
            }
            catch
            {
                MessageBox.Show("Please enter correct value");
            }
        }

        /// <summary>
        /// The buttonBookID_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonBookID_Click(object sender, EventArgs e)
        {
            try
            {
                SearchByBookId searchBook = new SearchByBookId();
                searchBook.BookID = int.Parse(textBox2.Text);
                Book book = searchBook.Search();
                dataGridView1.DataSource = book;
            }
            catch
            {
                MessageBox.Show("Please enter correct value");
            }
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
        /// The button3_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// The buttonBuy_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonBuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            new purchase().ShowDialog();
        }
    }
}
