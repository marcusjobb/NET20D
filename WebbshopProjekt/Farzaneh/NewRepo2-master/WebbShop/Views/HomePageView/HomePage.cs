namespace WebbShop.Views
{
    using System;
    using System.Windows.Forms;
    using WebbShop.Controllers;
    using WebbShop.Views.HomePageView;

    /// <summary>
    /// Defines the <see cref="HomePage" />.
    /// </summary>
    public partial class HomePage : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        public HomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The HomePage_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void HomePage_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The button3_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            new Logout().LogoutUser();
            Environment.Exit(0);
        }

        /// <summary>
        /// The button1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LogIn().ShowDialog();
        }

        /// <summary>
        /// The button2_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().ShowDialog();
        }

        /// <summary>
        /// The button5_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new purchase().ShowDialog();
        }

        /// <summary>
        /// The button6_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SearchBook().ShowDialog();
        }

        /// <summary>
        /// The buttonLogout_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (new Logout().LogoutUser())
            {
                MessageBox.Show("User Logout successfully");
                this.Hide();
                new LogIn().ShowDialog();
            }
            else
            {
                MessageBox.Show("Could not Logout");
            }
        }
    }
}
