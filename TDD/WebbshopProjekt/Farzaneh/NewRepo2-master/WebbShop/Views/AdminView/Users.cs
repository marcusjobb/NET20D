namespace WebbShop.Views
{
    using System;
    using System.Windows.Forms;
    using WebbShop.Controllers;
    using WebbShop.Views.AdminView;

    /// <summary>
    /// Defines the <see cref="Users" />.
    /// </summary>
    public partial class Users : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Users"/> class.
        /// </summary>
        public Users()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The button4_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateUser activateUser = new ActivateUser();
                activateUser.UserId = Convert.ToInt32(textBox4.Text);

                if (!activateUser.Active())
                {
                    MessageBox.Show("can not activate User");
                }
                else
                {
                    MessageBox.Show("User was activated");
                }
            }
            catch
            {
                MessageBox.Show("Please enter value");
            }
        }

        /// <summary>
        /// The button7_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DemoteUser demoteUser = new DemoteUser();
                demoteUser.UserId = Convert.ToInt32(textBox4.Text);
                if (!demoteUser.Demote())
                {
                    MessageBox.Show("can not demote User");
                }
                else
                {
                    MessageBox.Show("User was demoted");
                }
            }
            catch
            {
                MessageBox.Show("Please enter value");
            }
        }

        /// <summary>
        /// The Users_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void Users_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The button6_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                PromoteUser promoteUser = new PromoteUser();
                promoteUser.UserId = Convert.ToInt32(textBox4.Text);
                if (!promoteUser.Promote())
                {
                    MessageBox.Show("can not promote User");
                }
                else
                {
                    MessageBox.Show("User was promoted");
                }
            }
            catch
            {
                MessageBox.Show("Please enter value");
            }
        }

        /// <summary>
        /// The button1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ShowUsers().ListAllUsers();
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
                SearchUser search = new SearchUser();
                search.Name = textBox3.Text;
                dataGridView1.DataSource = search.Search();
            }
            catch
            {
                MessageBox.Show("Please enter correct value for the field");
            }
        }

        /// <summary>
        /// The textBox2_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The button3_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                AddUser addUser = new AddUser();
                addUser.Name = textBox1.Text;
                addUser.Password = textBox2.Text;
                if (addUser.add())
                {
                    MessageBox.Show(" User is added successfuly");
                }
                else
                {
                    MessageBox.Show("User can not be added, Check the name ");
                }
            }
            catch
            {
                MessageBox.Show("Please enter correct value for the field");
            }
        }

        /// <summary>
        /// The button5_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                InactivateUser inactivateUser = new InactivateUser();
                inactivateUser.UserId = Convert.ToInt32(textBox4.Text);
                if (!inactivateUser.Inactive())
                {
                    MessageBox.Show("can not inactivate User");
                }
                else
                {
                    MessageBox.Show("User was inactivated");
                }
            }
            catch
            {
                MessageBox.Show("Please enter value");
            }
        }

        /// <summary>
        /// The label4_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label4_Click(object sender, EventArgs e)
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
            textBox4.Text = selectedRow.Cells[0].Value.ToString();
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
        /// The textBox1_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
