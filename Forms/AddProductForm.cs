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

        // Add this event
        public event EventHandler DataChanged;

        //Items form
        public AddProductForm()
        {
            InitializeComponent();
            dbFunc = new DBFunc();

            // Subscribe to the DBFunc's DataChanged event
            dbFunc.DataChanged += DbFunc_DataChanged;

            // Initial data load
            itemListData();
        }

        private void DbFunc_DataChanged(object sender, EventArgs e)
        {
            // Ensure UI updates happen on the UI thread
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    itemListData();
                    // Propagate the change to other forms
                    DataChanged?.Invoke(this, EventArgs.Empty);
                }));
            }
            else
            {
                itemListData();
                // Propagate the change to other forms
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void itemListData()
        {
            try
            {
                using SqlConnection conn = dbConn.GetConnection();
                conn.Open();

                string query = @"SELECT i.id, i.item_id, i.item_name, i.item_type, i.Description, 
                                i.item_stock, i.item_price, i.item_image, i.date_insert, i.date_update 
                                FROM items i
                                WHERE i.date_delete IS NULL 
                                ORDER BY i.date_update DESC";

                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Add a new column for displaying actual images
                DataColumn imageCol = new DataColumn("item_image_display", typeof(Image));
                dt.Columns.Add(imageCol);

                // Loop through rows to convert path -> Thumbnail Image
                foreach (DataRow row in dt.Rows)
                {
                    string path = row["item_image"].ToString();
                    if (System.IO.File.Exists(path))
                    {
                        try
                        {
                            using (Image original = Image.FromFile(path))
                            {
                                // Create a thumbnail (e.g., 64x64 pixels)
                                Image thumb = original.GetThumbnailImage(64, 64, () => false, IntPtr.Zero);
                                row["item_image_display"] = thumb;
                            }
                        }
                        catch
                        {
                            row["item_image_display"] = null;
                        }
                    }
                    else
                    {
                        row["item_image_display"] = null;
                    }
                }

                // Configure DataGridView properties
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;

                // Set only the display column as DataSource
                dataGridView1.DataSource = dt;

                // Optional: hide the original file path column
                if (dataGridView1.Columns.Contains("item_image"))
                    dataGridView1.Columns["item_image"].Visible = false;

                // Format the image column
                if (dataGridView1.Columns.Contains("item_image_display"))
                {
                    DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dataGridView1.Columns["item_image_display"];
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    // Move the image column to the 7th position (index 6)
                    imgCol.DisplayIndex = 6;
                }

                // Configure column properties after setting DataSource
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column == null || string.IsNullOrWhiteSpace(column.Name))
                        continue;

                    string colName = column.Name.ToLowerInvariant();

                    switch (colName)
                    {
                        case "description":
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            break;

                        case "item_stock":
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DefaultCellStyle = new DataGridViewCellStyle
                            {
                                Alignment = DataGridViewContentAlignment.MiddleCenter
                            };
                            break;

                        case "item_price":
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DefaultCellStyle = new DataGridViewCellStyle
                            {
                                Format = "C2",
                                Alignment = DataGridViewContentAlignment.MiddleRight
                            };
                            break;

                        case "item_image":
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            break;
                    }
                }



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
            public string ItemStock { get; set; }
            public string ItemPrice { get; set; }
            public string ItemImage { get; set; }  // Add this property
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

            // Check if any fields are empty or contain only whitespace
            if (string.IsNullOrWhiteSpace(itemId) ||
                string.IsNullOrWhiteSpace(itemName) ||
                string.IsNullOrWhiteSpace(itemType) ||
                string.IsNullOrWhiteSpace(itemStock) ||
                string.IsNullOrWhiteSpace(itemPrice) ||
                string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fix the AddProduct call by matching the correct parameter count
            bool isAdded = dbFunc.AddProduct(itemId, itemName, itemType, description, itemStock, itemPrice, AddProductForm_imageView.ImageLocation);

            if (isAdded)
            {
                // After successful addition
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Notify subscribers about the new product
                var args = new ProductEventArgs
                {
                    ItemId = itemId,
                    ItemName = itemName,
                    ItemStock = itemStock,
                    ItemPrice = itemPrice,
                    ItemImage = AddProductForm_imageView.ImageLocation
                };
                ProductAdded?.Invoke(this, args);

                // Trigger the data changed event to update all forms
                DbFunc_DataChanged(this, EventArgs.Empty);

                // Clear fields
                dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription, AddProductForm_imageView);
                txtDescription.Items.Clear();
                txtDescription.Text = "";
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtItem_id.Text = row.Cells["item_id"].Value?.ToString() ?? "";
                txtItem_name.Text = row.Cells["item_name"].Value?.ToString() ?? "";
                txtItem_type.Text = row.Cells["item_type"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
                txtItem_stock.Text = row.Cells["item_stock"].Value?.ToString() ?? "";
                txtItem_price.Text = row.Cells["item_price"].Value?.ToString() ?? "";

                string imagePath = row.Cells["item_image"].Value?.ToString();
                AddProductForm_imageView.Image = null;
                AddProductForm_imageView.ImageLocation = null;

                if (!string.IsNullOrWhiteSpace(imagePath))
                {
                    string fileName = Path.GetFileName(imagePath);
                    string newPath = Path.Combine(@"C:\Users\Woots\source\repos\OnlineShop\pictures items", fileName);

                    string pathToUse = File.Exists(newPath) ? newPath :
                                       (File.Exists(imagePath) ? imagePath : null);

                    if (pathToUse != null)
                    {
                        try
                        {
                            using (Image originalImage = Image.FromFile(pathToUse))
                            {
                                int maxWidth = 300, maxHeight = 300;
                                double aspectRatio = (double)originalImage.Width / originalImage.Height;
                                int newWidth = aspectRatio > 1 ? maxWidth : (int)(maxHeight * aspectRatio);
                                int newHeight = aspectRatio > 1 ? (int)(maxWidth / aspectRatio) : maxHeight;

                                Bitmap resizedImage = new Bitmap(originalImage, newWidth, newHeight);
                                AddProductForm_imageView.Image = resizedImage;
                                AddProductForm_imageView.SizeMode = PictureBoxSizeMode.Zoom;
                                AddProductForm_imageView.ImageLocation = pathToUse;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Image load error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Image file not found at:\n{imagePath}\nor\n{newPath}",
                                        "Image Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string itemId = txtItem_id.Text.Trim();
            string itemName = txtItem_name.Text.Trim();
            string itemType = txtItem_type.Text.Trim();
            string itemStock = txtItem_stock.Text.Trim();
            string itemPrice = txtItem_price.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemId) ||
                string.IsNullOrWhiteSpace(itemName) ||
                string.IsNullOrWhiteSpace(itemType) ||
                string.IsNullOrWhiteSpace(itemStock) ||
                string.IsNullOrWhiteSpace(itemPrice) ||
                string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SqlConnection connection = dbConn.GetConnection();
            try
            {
                connection.Open();
                using var transaction = connection.BeginTransaction();

                try
                {
                    // Update items table
                    string updateData = @"UPDATE items 
                                SET item_id = @item_id,
                                    item_name = @item_name, 
                                    item_type = @item_type, 
                                    item_stock = @item_stock,
                                    item_price = @item_price, 
                                    Description = @description,
                                    item_image = @item_image,
                                    date_update = @date_update
                                WHERE id = @id";

                    using SqlCommand updateD = new SqlCommand(updateData, connection, transaction);

                    updateD.Parameters.AddWithValue("@item_id", itemId);
                    updateD.Parameters.AddWithValue("@item_name", itemName);
                    updateD.Parameters.AddWithValue("@item_type", itemType);
                    updateD.Parameters.AddWithValue("@item_stock", int.Parse(itemStock));
                    updateD.Parameters.AddWithValue("@item_price", float.Parse(itemPrice));
                    updateD.Parameters.AddWithValue("@description", description);
                    updateD.Parameters.AddWithValue("@item_image", AddProductForm_imageView.ImageLocation);
                    updateD.Parameters.AddWithValue("@date_update", DateTime.Today);
                    updateD.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["id"].Value);

                    updateD.ExecuteNonQuery();

                    // Update inventory table
                    string updateInventory = @"UPDATE Inventory 
                    SET InStock = @item_stock,
                        PurchasePrice = @item_price,
                        Status = CASE 
                                    WHEN @item_stock = 0 THEN 'Out of Stock'
                                    WHEN @item_stock <= 15 THEN 'Low Stock'
                                    ELSE 'Available'
                                 END
                    WHERE ProductName = @item_name";

                    using SqlCommand updateInv = new SqlCommand(updateInventory, connection, transaction);
                    updateInv.Parameters.AddWithValue("@item_stock", int.Parse(itemStock));
                    updateInv.Parameters.AddWithValue("@item_price", float.Parse(itemPrice));
                    updateInv.Parameters.AddWithValue("@item_name", itemName);

                    updateInv.ExecuteNonQuery();

                    transaction.Commit();

                    // Notify subscribers about the update
                    var args = new ProductEventArgs
                    {
                        ItemId = itemId,
                        ItemName = itemName,
                        ItemStock = itemStock,
                        ItemPrice = itemPrice,
                        ItemImage = AddProductForm_imageView.ImageLocation
                    };
                    ProductUpdated?.Invoke(this, args);

                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the data grid
                    itemListData();

                    // Clear the fields
                    dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription, AddProductForm_imageView);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error updating product: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrWhiteSpace(txtItem_id.Text))
            {
                MessageBox.Show("Please select an item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using SqlConnection conn = dbConn.GetConnection();
                try
                {
                    conn.Open();
                    string deleteQuery = @"UPDATE items 
                                    SET date_delete = GETDATE() 
                                    WHERE item_id = @itemId AND date_delete IS NULL";

                    using SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@itemId", txtItem_id.Text.Trim());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Notify subscribers that a product was deleted
                        var args = new ProductEventArgs
                        {
                            ItemId = txtItem_id.Text.Trim(),
                            ItemName = txtItem_name.Text.Trim(),
                            ItemStock = txtItem_stock.Text.Trim(),
                            ItemPrice = txtItem_price.Text.Trim(),
                            ItemImage = AddProductForm_imageView.ImageLocation
                        };

                        ProductDeleted?.Invoke(this, args);

                        // Clear fields and refresh
                        dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription, AddProductForm_imageView);
                        txtDescription.Items.Clear();
                        txtDescription.Text = "";
                        itemListData();
                    }
                    else
                    {
                        MessageBox.Show("Item not found or already deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
        }

        private void txtItem_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtItem_stock.KeyPress += txtItem_stock_KeyPress;
            // Allow only digits and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtItem_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtItem_price.KeyPress += txtItem_price_KeyPress;
            // Allow digits, decimal point, and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            // Refresh the data grid
            itemListData();
            
            // Clear all input fields
            dbFunc.clearField(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription, AddProductForm_imageView);
            
            // Clear and reset the description dropdown
            txtDescription.Items.Clear();
            txtDescription.Text = "";
            
            // Reset the image if one is loaded
            if (AddProductForm_imageView.Image != null)
            {
                AddProductForm_imageView.Image.Dispose();
                AddProductForm_imageView.Image = null;
            }
            
            // Notify subscribers that data has changed
            DataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
