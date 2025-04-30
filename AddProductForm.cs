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

        private DBConn dbConn = new DBConn();

        public AddProductForm()
        {
            InitializeComponent();
            dbFunc = new DBFunc();
            itemListData();
        }

        public void itemListData()
        {
            AddItemData addItemData = new AddItemData();
            List<AddItemData> listDatas = addItemData.itemListData();

            dataGridView1.DataSource = listDatas;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string itemId = txtItem_id.Text.Trim();
            string itemName = txtItem_name.Text.Trim();
            string itemType = txtItem_type.Text.Trim();
            string itemStock = txtItem_stock.Text.Trim();
            string itemPrice = txtItem_price.Text.Trim();
            string itemStatus = txtItem_status.Text.Trim();

            // Check if any fields are empty
            if (dbFunc.emptyFields(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicate Item ID

            // Attempt to add the product
            bool isAdded = dbFunc.AddProduct(itemId, itemName, itemType, itemStock, itemPrice, itemStatus, AddProductForm_imageView.ImageLocation);
            if (isAdded)
            {
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status, AddProductForm_imageView);
                itemListData();
            }
            else
            {
                MessageBox.Show("Failed to add product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status, AddProductForm_imageView);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtItem_id.Text = row.Cells[1].Value.ToString();
                txtItem_name.Text = row.Cells[2].Value.ToString();
                txtItem_type.Text = row.Cells[3].Value.ToString();
                txtItem_stock.Text = row.Cells[4].Value.ToString();
                txtItem_price.Text = row.Cells[5].Value.ToString();
                txtItem_status.Text = row.Cells[6].Value.ToString();

                string imagePath = row.Cells[7].Value.ToString();
                try
                {
                    if (imagePath != null)
                    {
                        AddProductForm_imageView.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        AddProductForm_imageView.Image = null; // Clear the image if path is empty
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dbFunc.emptyFields(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using SqlConnection connection = dbConn.GetConnection();
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string updateData = "UPDATE items SET item_id = @item_id, " +
                        "item_name = @item_name, item_type = @item_type, item_stock = @item_stock, " +
                        "item_price = @item_price, item_status = @item_status, date_update = @date_update";
                    DateTime today = DateTime.Today;

                    using (SqlCommand updateD = new SqlCommand(updateData, connection))
                    {
                        updateD.Parameters.AddWithValue("@item_id", txtItem_id.Text.Trim());
                        updateD.Parameters.AddWithValue("@item_name", txtItem_name.Text.Trim());
                        updateD.Parameters.AddWithValue("@item_type", txtItem_type.Text.Trim());
                        updateD.Parameters.AddWithValue("@item_stock", txtItem_stock.Text.Trim());
                        updateD.Parameters.AddWithValue("@item_price", txtItem_price.Text.Trim());
                        updateD.Parameters.AddWithValue("@item_status", txtItem_status.Text.Trim());
                        updateD.Parameters.AddWithValue("@date_update", today);
                        updateD.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                        updateD.ExecuteNonQuery();
                        dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status, AddProductForm_imageView);

                        MessageBox.Show("Product ID: " + txtItem_id.Text.Trim() + " updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status, AddProductForm_imageView);
                        itemListData();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using SqlConnection connection = dbConn.GetConnection();

            if (dbFunc.emptyFields(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to delete product id: ?" + txtItem_id.Text.Trim(), "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (check == DialogResult.Yes)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        try
                        {
                            connection.Open();
                            string deleteData = "UPDATE items SET date_delete = @date_delete WHERE id = @id";
                            DateTime today = DateTime.Today;
                            using (SqlCommand deleteD = new SqlCommand(deleteData, connection))
                            {
                                deleteD.Parameters.AddWithValue("@date_delete", today);
                                deleteD.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                                deleteD.ExecuteNonQuery();
                                dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status, AddProductForm_imageView);
                                MessageBox.Show("Product ID: " + txtItem_id.Text.Trim() + " deleted successfully!", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                itemListData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
