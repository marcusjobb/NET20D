namespace WebbShop.Views
{
    using System;
    using System.Windows.Forms;
    using WebbShop.Controllers;
    using WebbShop.Views.AdminView;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="LogIn" />.
    /// </summary>
    public partial class LogIn : Form
    {
        /// <summary>
        /// Defines the user.
        /// </summary>
        public static User user = new User();

        /// <summary>
        /// Initializes a new instance of the <see cref="LogIn"/> class.
        /// </summary>
        public LogIn()
        {
            InitializeComponent();
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
        /// The LogIn_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void LogIn_Load(object sender, EventArgs e)
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
                user.Name = textBox1.Text;
                user.Password = textBox2.Text;

                user = new LoginUser().login(user);
                if (user.ID != 0)
                {
                    if (user.IsAdmin)
                    {
                        this.Hide();
                        new AdminMenu().ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        new HomePage().ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Correct Username and Password");
                }
            }
            catch
            {
                MessageBox.Show("Please enter Correct Values");
            }
        }

        /// <summary>
        /// The button2_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button2_Click(object sender, EventArgs e)
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
        /// The buttonRegister_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().ShowDialog();
        }
    }
}
