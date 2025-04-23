using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineShop.DATABASE;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OnlineShop
{

    public partial class AddProductForm : UserControl
    {
        private DBFunc dbFunc;

        public AddProductForm()
        {
            InitializeComponent();
            dbFunc = new DBFunc();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string itemId = txtItem_id.Text.Trim();
            string itemName = txtItem_name.Text.Trim();
            string itemType = txtItem_type.Text.Trim();
            string itemStock = txtItem_stock.Text.Trim();
            string itemPrice = txtItem_price.Text.Trim();
            string itemStatus = txtItem_status.Text.Trim();

            if (dbFunc.checkItemID(itemId, itemName, itemType, itemStock, itemPrice, itemStatus))
            {
                MessageBox.Show("Please enter an item ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            bool isAdded = dbFunc.checkItemID(itemId, itemName, itemType, itemStock, itemPrice, itemStatus);

            if (isAdded)
            {
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Check if any of the text fields are empty
            if (dbFunc.emptyFields(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Item ID already exists. Please enter a different ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        //FUNCTION FOR ADDING ITEM PIC.
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                string imagePath = string.Empty;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    AddProductForm_imageView.ImageLocation = imagePath;
                }
            }
            catch
            {
                MessageBox.Show("Error importing image. Please try again.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
