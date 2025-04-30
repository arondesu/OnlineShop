using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OnlineShop.DATABASE; // Make sure you have the correct namespace for DBFunc

namespace OnlineShop
{
    public partial class addInventory : UserControl
    {
        private DBFunc dbFunc = new DBFunc();

        public addInventory()
        {
            InitializeComponent();

            // Set fixed size for DataGridView
            dataGridViewInventory.Width = 900;  // Set your desired width
            dataGridViewInventory.Height = 400; // Set your desired height

            // Remove Dock property if you want to keep the size fixed
            dataGridViewInventory.Dock = DockStyle.None;

            // If you use a panel for inputs, dock it to the bottom or set its size as needed
            // panelInputs.Dock = DockStyle.Bottom; // Optional, if you want the panel to stay at the bottom

            LoadInventoryData();
        }

        private void LoadInventoryData()
        {
            try
            {
                // Get all inventory data as a DataTable
                DataTable dt = dbFunc.checkInvTable(string.Empty);

                // Make sure you have a DataGridView named dataGridViewInventory in your Designer
                dataGridViewInventory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = this.dataGridViewInventory.Rows[e.RowIndex];
                txtItemId.Text = row.Cells["ProductId"].Value.ToString();
                txtItemName.Text = row.Cells["ProductName"].Value.ToString();
                cmbItemType.Text = row.Cells["Description"].Value.ToString();
                txtItemStock.Text = row.Cells["InStock"].Value.ToString();
                txtItemPrice.Text = row.Cells["PurchasePrice"].Value.ToString();
                cmbItemStatus.Text = row.Cells["Status"].Value.ToString();

                // If you store image path or byte[] in the "Image" column
                string imagePath = row.Cells["Image"].Value?.ToString();
                try
                {
                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                    {
                        AddProductForm_imageView.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        AddProductForm_imageView.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
