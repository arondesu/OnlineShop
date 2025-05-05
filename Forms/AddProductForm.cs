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
using OnlineShop.Forms;

namespace OnlineShop
{

    public partial class AddProductForm : UserControl
    {
        private DBFunc dbFunc;

        private DBConn dbConn = new DBConn();

        //Items form
        public AddProductForm()
        {
            InitializeComponent();
            dbFunc = new DBFunc();
            
            // Sync inventory data to items table
            dbFunc.SyncInventoryToItems();
            
            // Load the data
            itemListData();

            // Update the ComboBox items directly since it's already created in Designer
            txtDescription.Items.Clear();
            txtDescription.Items.AddRange(new object[] {
                "Durable and transparent container for food storage",
                "A sturdy rack designed to neatly organize mugs",
                "Heat-resistant mitts and potholders for kitchen safety",
                "A versatile and durable pot for cooking",
                "A handy peeler for effortless food preparation",
                "A multi-purpose sponge for cleaning kitchen surfaces",
                "A complete set of utensils for dining",
                "A precise scale for measuring ingredients",
                "A decorative and protective cover for tables"
            });
        }

        public void itemListData()
        {
            try
            {
                using SqlConnection conn = dbConn.GetConnection();
                conn.Open();

                // Modified query to include inventory data
                string query = @"SELECT i.id, i.item_id, i.item_name, i.item_type, i.Description, 
                                i.item_stock, i.item_price, i.item_image, i.date_insert, i.date_update 
                                FROM items i
                                WHERE i.date_delete IS NULL 
                                ORDER BY i.date_update DESC";

                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Configure DataGridView properties
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                // After setting the DataSource, adjust the Description column if it exists
                dataGridView1.DataSource = dt;

                // Format specific columns - handle the Description column specially
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Name.Contains("Description"))
                    {
                        // Set a reasonable fixed width for Description column
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView1.Columns[i].Width = 150; // Adjust this value as needed
                    }
                }
                if (dataGridView1.Columns["item_price"] != null)
                    dataGridView1.Columns["item_price"].DefaultCellStyle.Format = "C2";
                if (dataGridView1.Columns["date_insert"] != null)
                    dataGridView1.Columns["date_insert"].DefaultCellStyle.Format = "d";
                if (dataGridView1.Columns["date_update"] != null)
                    dataGridView1.Columns["date_update"].DefaultCellStyle.Format = "d";

                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading item data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        AddItemData addItemData = new AddItemData();
private List<AddItemData> listDatas;

        // Add event to notify when product is added
        // Modify the event to include product information
        public class ProductEventArgs : EventArgs
        {
            public string ItemId { get; set; }
            public string ItemName { get; set; }
            public string ItemStock { get; set; }  // Changed back to string to match the form data type
            public string ItemPrice { get; set; }  // Added price for complete data
        }

        // Keep the event declarations as string-based to match your existing code
        public event EventHandler<ProductEventArgs> ProductAdded;
        public event EventHandler<ProductEventArgs> ProductUpdated;
        public event EventHandler<ProductEventArgs> ProductDeleted;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string itemId = txtItem_id.Text.Trim();
            string itemName = txtItem_name.Text.Trim();
            string itemType = txtItem_type.Text.Trim();
            string itemStock = txtItem_stock.Text.Trim();
            string itemPrice = txtItem_price.Text.Trim();
            string description = txtDescription.Text.Trim();

            // Check if any fields are empty
            if (dbFunc.emptyFields(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fix the AddProduct call by matching the correct parameter count
            bool isAdded = dbFunc.AddProduct(itemId, itemName, itemType, description, itemStock, itemPrice, AddProductForm_imageView.ImageLocation);

            if (isAdded)
            {
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Create event args with product info - keep as strings
                var args = new ProductEventArgs
                {
                    ItemId = itemId,
                    ItemName = itemName,
                    ItemStock = itemStock,
                    ItemPrice = itemPrice
                };
                
                // Notify subscribers that a product was added
                ProductAdded?.Invoke(this, args);
                
                // Clear fields and refresh
                dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription, AddProductForm_imageView);
                txtDescription.Items.Clear();
                txtDescription.Text = "";
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
            dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription, AddProductForm_imageView);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtItem_id.Text = row.Cells["item_id"].Value?.ToString() ?? "";
                txtItem_name.Text = row.Cells["item_name"].Value?.ToString() ?? "";
                txtItem_type.Text = row.Cells["item_type"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
                txtItem_stock.Text = row.Cells["item_stock"].Value?.ToString() ?? "";
                txtItem_price.Text = row.Cells["item_price"].Value?.ToString() ?? "";

                string imagePath = row.Cells["item_image"].Value?.ToString() ?? "";
                try
                {
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        // First try the original path
                        if (File.Exists(imagePath))
                        {
                            // Load and resize the image
                            using (Image originalImage = Image.FromFile(imagePath))
                            {
                                // Create a resized version (adjust max dimensions as needed)
                                int maxWidth = 300;  // Set your desired max width
                                int maxHeight = 300; // Set your desired max height

                                // Calculate new dimensions while preserving aspect ratio
                                int newWidth, newHeight;
                                double aspectRatio = (double)originalImage.Width / originalImage.Height;

                                if (aspectRatio > 1) // Width > Height
                                {
                                    newWidth = maxWidth;
                                    newHeight = (int)(maxWidth / aspectRatio);
                                }
                                else // Height >= Width
                                {
                                    newHeight = maxHeight;
                                    newWidth = (int)(maxHeight * aspectRatio);
                                }

                                // Create resized image
                                Bitmap resizedImage = new Bitmap(originalImage, newWidth, newHeight);
                                AddProductForm_imageView.Image = resizedImage;

                                // Set SizeMode to keep the image properly displayed
                                AddProductForm_imageView.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                        else
                        {
                            // Try with corrected path if original doesn't exist
                            string fileName = Path.GetFileName(imagePath);
                            string correctedPath = Path.Combine(@"C:\Users\Woots\source\repos\OnlineShop\pictures items\", fileName);

                            if (File.Exists(correctedPath))
                            {
                                // Load and resize the image (same resizing code as above)
                                using (Image originalImage = Image.FromFile(correctedPath))
                                {
                                    int maxWidth = 300;
                                    int maxHeight = 300;

                                    int newWidth, newHeight;
                                    double aspectRatio = (double)originalImage.Width / originalImage.Height;

                                    if (aspectRatio > 1)
                                    {
                                        newWidth = maxWidth;
                                        newHeight = (int)(maxWidth / aspectRatio);
                                    }
                                    else
                                    {
                                        newHeight = maxHeight;
                                        newWidth = (int)(maxHeight * aspectRatio);
                                    }

                                    Bitmap resizedImage = new Bitmap(originalImage, newWidth, newHeight);
                                    AddProductForm_imageView.Image = resizedImage;
                                    AddProductForm_imageView.SizeMode = PictureBoxSizeMode.Zoom;
                                }
                            }
                            else
                            {
                                AddProductForm_imageView.Image = null;
                                MessageBox.Show($"Image file not found at: {imagePath}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        AddProductForm_imageView.Image = null; // Clear the image if path is empty
                    }
                }
                catch (Exception ex)
                {
                    AddProductForm_imageView.Image = null;
                    MessageBox.Show("Error loading image: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dbFunc.emptyFields(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
    
            // Check if a row is selected
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SqlConnection connection = dbConn.GetConnection();
            try
            {
                connection.Open();
                string updateData = @"UPDATE items 
                            SET item_id = @item_id,
                                item_name = @item_name, 
                                item_type = @item_type, 
                                item_stock = @item_stock,
                                item_price = @item_price, 
                                Description = @description, 
                                date_update = @date_update
                            WHERE id = @id";

                using SqlCommand updateD = new SqlCommand(updateData, connection);
                
                // Add parameters with proper type checking
                updateD.Parameters.AddWithValue("@item_id", txtItem_id.Text.Trim());
                updateD.Parameters.AddWithValue("@item_name", txtItem_name.Text.Trim());
                updateD.Parameters.AddWithValue("@item_type", txtItem_type.Text.Trim());
                updateD.Parameters.AddWithValue("@item_stock", int.Parse(txtItem_stock.Text.Trim()));
                updateD.Parameters.AddWithValue("@item_price", float.Parse(txtItem_price.Text.Trim()));
                updateD.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                updateD.Parameters.AddWithValue("@date_update", DateTime.Today);
                updateD.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["id"].Value);

                updateD.ExecuteNonQuery();

                MessageBox.Show("Product ID: " + txtItem_id.Text.Trim() + " updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription, AddProductForm_imageView);
                itemListData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtDescription_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string itemId = txtItem_id.Text.Trim();

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = dbConn.GetConnection())
                    {
                        try
                        {
                            connection.Open();
                            string deleteQuery = "DELETE FROM items WHERE item_id = @item_id";

                            using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@item_id", itemId);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription, AddProductForm_imageView);
                            itemListData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
        }
    }
}
