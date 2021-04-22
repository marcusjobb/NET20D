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
    public partial class SoldBookForm : Form
    {
        /// <summary>
        /// Outputs the information from the SoldBooks-table
        /// </summary>
        /// <param name="soldItems">The soldsbooks-information to output</param>
        public SoldBookForm(List<SoldBook> soldItems)
        {
            InitializeComponent();
            if (soldItems.Any())
            {
                foreach (SoldBook sold in soldItems)
                {
                    string[] rad = {sold.ID.ToString(), sold.Title, sold.Author,
                    sold.Price.ToString() + " SEK", sold.PurchaseDate.ToString(),
                    sold.BookCategoryID.ToString(), sold.BookCategory.BookCategoryName,
                    sold.UserID.ToString() };
                    var listViewItem = new ListViewItem(rad);

                    lstViewSoldBooks.Items.Add(listViewItem);
                }
            }
        }

    }
}
