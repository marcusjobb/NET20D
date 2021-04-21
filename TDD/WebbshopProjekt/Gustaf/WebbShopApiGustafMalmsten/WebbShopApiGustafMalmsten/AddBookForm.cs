using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebbShopAPIGustafMalmsten.Model;

namespace WebbShopAPIGustafMalmstenFrontEnd
{
    public partial class AddBookForm : Form
    {
        /// <summary>
        /// Outputs bookcategory names in the combobox
        /// </summary>
        /// <param name="bookCategories"></param>
        public AddBookForm(List<BookCategory> bookCategories)
        {
            InitializeComponent();
            foreach (BookCategory item in bookCategories) 
            {
                cmbBoxCategory.Items.Add(item.BookCategoryName);
            }
        }
    }
}
