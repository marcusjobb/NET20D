namespace WebbShop.Views.AdminView
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WebbShop.Controllers;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="CategoryOptions" />.
    /// </summary>
    public partial class CategoryOptions : Form
    {
        /// <summary>
        /// Defines the ListOfCategories.
        /// </summary>
        internal List<BookCategory> ListOfCategories = new List<BookCategory>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryOptions"/> class.
        /// </summary>
        public CategoryOptions()
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
        /// The textBox1_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The textBoxAdd_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBoxAdd_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The buttonAdd_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddCategory addCategory = new AddCategory();
                addCategory.CategoryName = textBoxAdd.Text;
                if (addCategory.Add())
                {
                    MessageBox.Show("Book category is added sauccessfully");
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
        /// The textBoxNewName_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBoxNewName_TextChanged(object sender, EventArgs e)
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
                SearchCategory searchCategory = new SearchCategory();
                searchCategory.Keyword = textBoxCName.Text;
                ListOfCategories = searchCategory.Search();
                dataGridView1.DataSource = ListOfCategories;
            }
            catch
            {
                MessageBox.Show("Please enter correct value for the field");
            }
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
                DeleteCategory deleteCategory = new DeleteCategory();
                deleteCategory.CategoryId = int.Parse(textBoxDelete.Text);
                if (deleteCategory.Delete())
                {
                    MessageBox.Show("Book category is deleted sauccessfully");
                }
                else
                {
                    MessageBox.Show("Could not be deleted");
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
                UpdateCategory updateCategory = new UpdateCategory();
                updateCategory.CategoryId = int.Parse(textBoxIDUpdate.Text);
                updateCategory.NewName = textBoxNewName.Text;
                if (updateCategory.Update())
                {
                    MessageBox.Show("Book category is updated sauccessfully");
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
        /// The label2_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label2_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The buttonADD2_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonADD2_Click(object sender, EventArgs e)
        {
            try
            {
                AddToCategory addToCategory = new AddToCategory();
                addToCategory.BookID = int.Parse(textBox1.Text);
                addToCategory.CategoryName = textBoxBookID.Text;
                if (addToCategory.AddToBookToCategory())
                {
                    MessageBox.Show("Book is added to category sauccessfully");
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

        /// <summary>
        /// The CategoryOptions_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void CategoryOptions_Load(object sender, EventArgs e)
        {
        }
    }
}
