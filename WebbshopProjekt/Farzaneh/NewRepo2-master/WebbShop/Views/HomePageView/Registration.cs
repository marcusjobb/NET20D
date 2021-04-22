namespace WebbShop.Views
{
    using System;
    using System.Windows.Forms;
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="Registration" />.
    /// </summary>
    public partial class Registration : Form
    {
        /// <summary>
        /// Defines the API.
        /// </summary>
        private WebbShopAPIHelper API = new WebbShopAPIHelper();

        /// <summary>
        /// Initializes a new instance of the <see cref="Registration"/> class.
        /// </summary>
        public Registration()
        {
            InitializeComponent();
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
        /// The button1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string passwordVerify = textBox3.Text;
            bool b = API.Register(username, password, passwordVerify);
            if (b)
            {
                MessageBox.Show("Regestration has been done successfully");
            }
            else
            {
                MessageBox.Show("The username is taken, enter another name or check the passwordVerify");
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
        /// The Registration_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void Registration_Load(object sender, EventArgs e)
        {
        }
    }
}
