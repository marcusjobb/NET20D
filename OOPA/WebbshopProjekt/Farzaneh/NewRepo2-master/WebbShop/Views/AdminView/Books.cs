namespace WebbShop.Views.AdminView
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WebbShop.Controllers;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="Books" />.
    /// </summary>
    public partial class Books : Form
    {
        //private List<Book> ListOfBooks { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Books"/> class.
        /// </summary>
        public Books()
        {
            InitializeComponent();
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
        /// The labelID_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void labelID_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The textBoxAuthor_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBoxAuthor_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The buttonSearch_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBookByTitle searchBook = new SearchBookByTitle();
                searchBook.Keyword = textBoxSearch.Text;
                List<Book> ListOfBooks = searchBook.Search();
                dataGridView1.DataSource = ListOfBooks;
            }
            catch
            {
                MessageBox.Show("Please enter correct value for the field");
            }
        }

        /// <summary>
        /// The buttonDelete_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteBook deleteBook = new DeleteBook();
                deleteBook.BookId = Convert.ToInt32(textBoxID.Text);
                if (deleteBook.Delete())
                {
                    MessageBox.Show("The book is deleted successfully");
                }
                else
                {
                    MessageBox.Show("Could not be delete ");
                }
            }
            catch
            {
                MessageBox.Show("Please enter correct value for the field");
            }
        }

        /// <summary>
        /// The buttonadd_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonadd_Click(object sender, EventArgs e)
        {
            try
            {
                AddBook addBook = new AddBook();
                addBook.book.Title = textBoxTitle1.Text;
                addBook.book.Author = textBoxAuthor.Text;
                addBook.book.Price = int.Parse(textBoxPrice.Text);
                addBook.book.Amount = int.Parse(textBoxAmount.Text);

                if (addBook.Add())
                {
                    MessageBox.Show("The book is added successfully");
                }
                else
                {
                    MessageBox.Show("Could not be added");
                }
            }
            catch
            {
                MessageBox.Show("Please enter correct value for the field");
            }
        }

        /// <summary>
        /// The buttonUpdate_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBook updateBook = new UpdateBook();
                updateBook.book.Id = int.Parse(textBoxID2.Text);
                updateBook.book.Title = textBoxTitle2.Text;
                updateBook.book.Author = textBoxAuthor2.Text;
                updateBook.book.Price = int.Parse(textBoxPrice2.Text);

                if (updateBook.Update())
                {
                    MessageBox.Show("The book is updated successfully");
                }
                else
                {
                    MessageBox.Show("Could not be updated");
                }
            }
            catch
            {
                MessageBox.Show("Please enter correct value for the field");
            }
        }

        /// <summary>
        /// The Books_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void Books_Load(object sender, EventArgs e)
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
