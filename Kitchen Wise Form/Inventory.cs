using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; // For image processing
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using OnlineShop.DATABASE;
using System.IO; // Add this missing namespace


namespace OnlineShop.Kitchen_Wise_Form
{
    public partial class InventoryForm : Form
    {
        private DBConn dbConn;
        private System.Windows.Forms.DataGridView itemDataGrid;
        private DBFunc dbFunc;

        public InventoryForm()
        {
            InitializeComponent();
            dbConn = new DBConn();
            dbFunc = new DBFunc();
            this.StartPosition = FormStartPosition.CenterScreen;

            // If itemDataGrid doesn't exist in the designer, create it programmatically
            if (itemDataGrid == null)
            {
                itemDataGrid = new DataGridView();
                itemDataGrid.Dock = DockStyle.Fill;
                itemDataGrid.Visible = false;
                this.Controls.Add(itemDataGrid);
            }
            else
            {
                itemDataGrid.Visible = false;
            }
        }

        public void itemListData()
        {
            AddItemData addItemData = new AddItemData();
            List<AddItemData> listDatas = addItemData.itemListData();

            itemdatagrid.DataSource = listDatas;
        }

        private void LoadSalesData()
        {
            try
            {
                using SqlConnection connection = dbConn.GetConnection();
                connection.Open();
                Console.WriteLine("Database connected successfully!");

                string query = "SELECT * FROM Sales";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                salesDataGrid.DataSource = dt;
                salesDataGrid.AutoGenerateColumns = true;
                salesDataGrid.Visible = true;
                salesDataGrid.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salesBtn_Click(object sender, EventArgs e) //transactions should be here
        {
            LoadSalesData();
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = true;
            salesDataGrid.BringToFront();
        }

        private void home_btn_Click(object sender, EventArgs e) //brief details of each item?? i need your thoughts.
        {
            adminDashboardForm1.BringToFront();
            adminDashboardForm1.Visible = true;
            addProductForm1.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
        }

        private void item_btn_Click(object sender, EventArgs e) //Items button; CRUD operations need to be applied.
        {
            LoadItemData();
            addProductForm1.BringToFront();
            adminDashboardForm1.Visible = false;
            addProductForm1.Visible = true;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
        }

        private void invBtn_Click(object sender, EventArgs e) //Inventory button; CRU operations need to be applied.
        {
            LoadInventoryData();
            itemdatagrid.BringToFront();
            updateInvPnl.BringToFront();
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;
        }


        private void bck_btn_Click_2(object sender, EventArgs e)
        {
            //Calling the MainShop form
            MainShop mn = new MainShop();
            mn.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadInventoryData()
        {
            try
            {
                using SqlConnection connection = dbConn.GetConnection();
                connection.Open();
                Console.WriteLine("Database connected successfully!");

                string query = "SELECT * FROM inventory";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // First set the DataSource
                itemdatagrid.DataSource = dt;
                itemdatagrid.AutoGenerateColumns = true;

                // Then configure the image column
                if (itemdatagrid.Columns.Contains("Photo"))
                {
                    // Get the index of the Photo column
                    int photoColumnIndex = itemdatagrid.Columns["Photo"].Index;

                    // Configure the existing column instead of replacing it
                    DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)itemdatagrid.Columns[photoColumnIndex];
                    imageColumn.HeaderText = "Product Image";
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageColumn.Width = 100; // Set a fixed width

                    // No need to remove and re-add the column
                }

                itemdatagrid.Visible = true;
                itemdatagrid.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemData() //Loads items data into the item data grid 
        {
            try
            {
                //for temporary testing
                using SqlConnection conn = dbConn.GetConnection();
                conn.Open();

                string SelectItem = "SELECT * FROM items WHERE date_delete IS NULL";

                using (SqlCommand cmd = new SqlCommand(SelectItem, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AddItemData aid = new AddItemData();

                        aid.ID = (int)reader["id"];
                        aid.ItemID = reader["ProductId"].ToString();
                        aid.ItemName = reader["ProductName"].ToString();
                        aid.Type = reader["Description"].ToString();
                        aid.Stock = reader["InStock"].ToString();
                        aid.Price = reader["PurchasePrice"].ToString();
                        aid.Status = reader["Status"].ToString();
                        aid.Image = reader["Photo"].ToString();
                        aid.DateInsert = reader["date_insert"].ToString();
                        aid.DateUpdate = reader["date_update"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                using SqlConnection conn = dbConn.GetConnection();
                conn.Close();
            }
        }

        private void itemdatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Make sure a valid row is clicked (not header or empty area)
                if (e.RowIndex >= 0)
                {
                    // Get the selected row
                    DataGridViewRow row = itemdatagrid.Rows[e.RowIndex];

                    // Populate the textboxes with data from the selected row
                    txtItemId.Text = row.Cells["ProductId"].Value.ToString();
                    txtItemName.Text = row.Cells["ProductName"].Value.ToString();

                    // For comboboxes, find and select the matching item
                    cmbItemType.Text = row.Cells["Description"].Value.ToString();

                    txtItemStock.Text = row.Cells["InStock"].Value.ToString();
                    txtItemPrice.Text = row.Cells["PurchasePrice"].Value.ToString();

                    cmbItemStatus.Text = row.Cells["Status"].Value.ToString();

                    // For the image, load from byte array if present
                    var imageCellValue = row.Cells["Photo"].Value;
                    if (imageCellValue != DBNull.Value && imageCellValue != null)
                    {
                        byte[] imageBytes = (byte[])imageCellValue;
                        if (imageBytes.Length > 0)
                        {
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                AddProductForm_imageView.Image = Image.FromStream(ms);
                            }
                            AddProductForm_imageView.ImageLocation = null;
                            AddProductForm_imageView.Tag = null;
                        }
                        else
                        {
                            AddProductForm_imageView.Image = null;
                            AddProductForm_imageView.ImageLocation = "";
                            AddProductForm_imageView.Tag = null;
                        }
                    }
                    else
                    {
                        AddProductForm_imageView.Image = null;
                        AddProductForm_imageView.ImageLocation = "";
                        AddProductForm_imageView.Tag = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting row: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemdatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Call the same code as in CellContentClick
            itemdatagrid_CellContentClick(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from your input controls
                string itemName = txtItemName.Text;
                string itemType = cmbItemType.Text;
                string itemStock = txtItemStock.Text;
                string itemPrice = txtItemPrice.Text;
                string itemStatus = cmbItemStatus.Text;
                string imagePath = AddProductForm_imageView.Tag as string ?? AddProductForm_imageView.ImageLocation;

                // Validate inputs
                if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(itemType) ||
                    string.IsNullOrEmpty(itemStock) || string.IsNullOrEmpty(itemPrice))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate that the item exists in the shop's inventory
                List<string> validItems = new List<string> {
                    "Glass Food Storage", "Steel Mug Rack", "Mitts Potholders",
                    "Steel Brazier Pot", "Descascador", "Cleaning Sponge",
                    "Silverware Set", "Kitchen Scale", "Table Cloth"
                };

                if (!validItems.Contains(itemName))
                {
                    MessageBox.Show("Invalid item name. Please enter a valid item from the shop inventory.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate image is selected
                if (string.IsNullOrEmpty(imagePath))
                {
                    MessageBox.Show("Please select an image for the product.",
                        "Image Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Final validation that image matches product
                if (!IsMatchingProductImage(itemName, imagePath))
                {
                    // The IsMatchingProductImage method already shows a dialog, so we don't need to show another message here
                    return;
                }

                // Connect to database
                using SqlConnection conn = dbConn.GetConnection();
                conn.Open();

                // Modified SQL insert command
                string insertQuery = @"INSERT INTO inventory 
                            (ProductName, Description, InStock, PurchasePrice, Status, Photo, date_insert) 
                            VALUES 
                            (@itemName, @itemType, @itemStock, @itemPrice, @itemStatus, @itemImage, @dateInsert)";

                using SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@itemType", itemType);
                cmd.Parameters.AddWithValue("@itemStock", Convert.ToInt32(itemStock));
                cmd.Parameters.AddWithValue("@itemPrice", Convert.ToDecimal(itemPrice));

                // Simply pass the status string directly
                cmd.Parameters.AddWithValue("@itemStatus", itemStatus);

                // For the image, convert file to byte array if it exists
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
                    cmd.Parameters.Add("@itemImage", SqlDbType.VarBinary, imageData.Length).Value = imageData;
                }
                else
                {
                    cmd.Parameters.Add("@itemImage", SqlDbType.VarBinary).Value = DBNull.Value;
                }

                cmd.Parameters.AddWithValue("@dateInsert", DateTime.Now);

                // Execute the command
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Item added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields
                    ClearInputFields();

                    // Refresh the data grid to show the newly added item
                    LoadInventoryData();
                }
                else
                {
                    MessageBox.Show("Failed to add item.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            txtItemId.Text = "";
            txtItemName.Text = "";
            cmbItemType.SelectedIndex = -1;
            txtItemStock.Text = "";
            txtItemPrice.Text = "";
            cmbItemStatus.SelectedIndex = -1;
            AddProductForm_imageView.Image = null;
            AddProductForm_imageView.ImageLocation = "";
            AddProductForm_imageView.Tag = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if an item is selected
                if (string.IsNullOrEmpty(txtItemId.Text))
                {
                    MessageBox.Show("Please select an item to update.", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get values from your input controls
                string itemId = txtItemId.Text;
                string itemName = txtItemName.Text;
                string itemType = cmbItemType.Text;
                string itemStock = txtItemStock.Text;
                string itemPrice = txtItemPrice.Text;
                string itemStatus = cmbItemStatus.Text;
                string imagePath = AddProductForm_imageView.Tag as string ?? AddProductForm_imageView.ImageLocation;

                // Validate inputs
                if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(itemType) ||
                    string.IsNullOrEmpty(itemStock) || string.IsNullOrEmpty(itemPrice) ||
                    string.IsNullOrEmpty(itemStatus) || cmbItemStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill in all required fields, including selecting a status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate that the item exists in the shop's inventory
                List<string> validItems = new List<string> {
                    "Glass Food Storage", "Steel Mug Rack", "Mitts Potholders",
                    "Steel Brazier Pot", "Descascador", "Cleaning Sponge",
                    "Silverware Set", "Kitchen Scale", "Table Cloth"
                };

                if (!validItems.Contains(itemName))
                {
                    MessageBox.Show("Invalid item name. Please enter a valid item from the shop inventory.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate image is selected
                if (string.IsNullOrEmpty(imagePath))
                {
                    MessageBox.Show("Please select an image for the product.",
                        "Image Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Strict image validation - no prompting, just validation
                if (!ValidateProductImage(itemName, imagePath))
                {
                    MessageBox.Show(
                        "The selected image does not match the product '" + itemName + "'.\n\n" +
                        "Please select an appropriate image that clearly represents this product.",
                        "Image Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // Connect to database
                using SqlConnection conn = dbConn.GetConnection();
                conn.Open();

                // SQL update command
                string updateQuery = @"UPDATE inventory SET
                    ProductName = @itemName,
                    Description = @itemType,
                    InStock = @itemStock,
                    PurchasePrice = @itemPrice,
                    Status = @itemStatus,
                    Photo = @itemImage
                WHERE ProductId = @productId";

                using SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@itemType", itemType);
                cmd.Parameters.AddWithValue("@itemStock", Convert.ToInt32(itemStock));
                cmd.Parameters.AddWithValue("@itemPrice", Convert.ToDecimal(itemPrice));
                cmd.Parameters.AddWithValue("@itemStatus", itemStatus);

                // For the image, convert file to byte array if it exists
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
                    cmd.Parameters.Add("@itemImage", SqlDbType.VarBinary, imageData.Length).Value = imageData;
                }
                else
                {
                    cmd.Parameters.Add("@itemImage", SqlDbType.VarBinary).Value = DBNull.Value;
                }

                cmd.Parameters.AddWithValue("@dateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@productId", Convert.ToInt32(itemId));

                // Execute the command
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Item updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields
                    ClearInputFields();

                    // Refresh the data grid to show the updated item
                    LoadInventoryData();
                }
                else
                {
                    MessageBox.Show("Failed to update item. Item may not exist.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating item: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Implement clear functionality
            ClearInputFields();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = dialog.FileName;

                    // Validate the image file
                    if (!IsValidImage(imagePath))
                    {
                        MessageBox.Show("The selected file is not a valid image or is corrupted.",
                            "Invalid Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validate that the image matches the selected product
                    string productName = txtItemName.Text;
                    if (!string.IsNullOrEmpty(productName) && !IsMatchingProductImage(productName, imagePath))
                    {
                        // The IsMatchingProductImage method already shows a dialog, so we don't need to show another message here
                        return;
                    }

                    // Load the original image
                    using (Image originalImage = Image.FromFile(imagePath))
                    {
                        // Get the dimensions of your PictureBox
                        int targetWidth = AddProductForm_imageView.Width;
                        int targetHeight = AddProductForm_imageView.Height;

                        // Calculate dimensions while maintaining aspect ratio
                        Size newSize = CalculateResizedDimensions(originalImage.Width, originalImage.Height, targetWidth, targetHeight);

                        // Create a new bitmap with the calculated size
                        using (Bitmap resizedImage = new Bitmap(originalImage, newSize))
                        {
                            // Create a unique filename to avoid caching issues
                            string tempFileName = "temp_" + Guid.NewGuid().ToString() + Path.GetExtension(imagePath);
                            string tempImagePath = Path.Combine(Path.GetTempPath(), tempFileName);

                            // Save the resized image
                            resizedImage.Save(tempImagePath);

                            // Set the image location to the temporary file
                            AddProductForm_imageView.SizeMode = PictureBoxSizeMode.Zoom;
                            AddProductForm_imageView.ImageLocation = tempImagePath;

                            // Store the temporary path for database storage
                            AddProductForm_imageView.Tag = tempImagePath;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing image: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to validate an image file
        private bool IsValidImage(string imagePath)
        {
            try
            {
                // Check if the file exists
                if (!File.Exists(imagePath))
                    return false;

                // Check file size (reject if too large, e.g., > 5MB)
                FileInfo fileInfo = new FileInfo(imagePath);
                if (fileInfo.Length > 5 * 1024 * 1024) // 5MB
                    return false;

                // Try to load the image to verify it's a valid image format
                using (Image img = Image.FromFile(imagePath))
                {
                    // Additional validation if needed
                    if (img.Width <= 0 || img.Height <= 0)
                        return false;

                    return true;
                }
            }
            catch
            {
                // If any exception occurs during validation, consider it invalid
                return false;
            }
        }

        // Helper method to calculate dimensions while maintaining aspect ratio
        private Size CalculateResizedDimensions(int originalWidth, int originalHeight, int targetWidth, int targetHeight)
        {
            float ratioX = (float)targetWidth / originalWidth;
            float ratioY = (float)targetHeight / originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            return new Size(newWidth, newHeight);
        }

        private void txtItemId_TextChanged(object sender, EventArgs e)
        {

        }

        // Add this method after CalculateResizedDimensions
        // Helper method to check if an image matches a product
        private bool IsMatchingProductImage(string productName, string imagePath)
        {
            try
            {
                // Get the filename without extension
                string fileName = Path.GetFileNameWithoutExtension(imagePath).ToLower();

                // Convert product name to lowercase for case-insensitive comparison
                string product = productName.ToLower();

                // Define keywords for each product
                Dictionary<string, List<string>> productKeywords = new Dictionary<string, List<string>>
                {
                    { "glass food storage", new List<string> { "glass", "container", "storage", "food" } },
                    { "steel mug rack", new List<string> { "mug", "rack", "cup", "holder" } },
                    { "mitts potholders", new List<string> { "mitt", "potholder", "glove" } },
                    { "steel brazier pot", new List<string> { "pot", "brazier", "steel" } },
                    { "descascador", new List<string> { "peeler", "descascador" } },
                    { "cleaning sponge", new List<string> { "sponge", "clean", "scrub" } },
                    { "silverware set", new List<string> { "silverware", "cutlery", "fork", "knife", "spoon" } },
                    { "kitchen scale", new List<string> { "scale", "weight", "kitchen" } },
                    { "table cloth", new List<string> { "cloth", "table", "cover" } }
                };

                // Check if we have keywords for this product
                if (productKeywords.ContainsKey(product))
                {
                    // Check if filename contains any of the keywords
                    foreach (string keyword in productKeywords[product])
                    {
                        if (fileName.Contains(keyword))
                            return true;
                    }

                    // If no keywords match, ask the user
                    DialogResult result = MessageBox.Show(
                        $"The selected image doesn't appear to match '{productName}'.\n\n" +
                        "Are you sure this is the correct image for this product?",
                        "Image Validation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    return result == DialogResult.Yes;
                }

                // If we don't have keywords for this product, allow any image
                return true;
            }
            catch
            {
                // If any error occurs, ask the user
                DialogResult result = MessageBox.Show(
                    "Could not validate if this image matches the product.\n\n" +
                    "Are you sure this is the correct image?",
                    "Image Validation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                return result == DialogResult.Yes;
            }
        }
        // Add the missing ValidateProductImage method to resolve the CS0103 error.
        private bool ValidateProductImage(string productName, string imagePath)
        {
            try
            {
                // Get the filename without extension
                string fileName = Path.GetFileNameWithoutExtension(imagePath).ToLower();

                // Convert product name to lowercase for case-insensitive comparison
                string product = productName.ToLower();

                // Define keywords for each product
                Dictionary<string, List<string>> productKeywords = new Dictionary<string, List<string>>
                {
                    { "glass food storage", new List<string> { "glass", "container", "storage", "food" } },
                    { "steel mug rack", new List<string> { "mug", "rack", "cup", "holder" } },
                    { "mitts potholders", new List<string> { "mitt", "potholder", "glove" } },
                    { "steel brazier pot", new List<string> { "pot", "brazier", "steel" } },
                    { "descascador", new List<string> { "peeler", "descascador" } },
                    { "cleaning sponge", new List<string> { "sponge", "clean", "scrub" } },
                    { "silverware set", new List<string> { "silverware", "cutlery", "fork", "knife", "spoon" } },
                    { "kitchen scale", new List<string> { "scale", "weight", "kitchen" } },
                    { "table cloth", new List<string> { "cloth", "table", "cover" } }
                };

                // Check if we have keywords for this product
                if (productKeywords.ContainsKey(product))
                {
                    // Check if filename contains any of the keywords
                    foreach (string keyword in productKeywords[product])
                    {
                        if (fileName.Contains(keyword))
                            return true;
                    }

                    // If no keywords match, ask the user
                    DialogResult result = MessageBox.Show(
                        $"The selected image doesn't appear to match '{productName}'.\n\n" +
                        "Are you sure this is the correct image for this product?",
                        "Image Validation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    return result == DialogResult.Yes;
                }

                // If we don't have keywords for this product, allow any image
                return true;
            }
            catch
            {
                // If any error occurs, ask the user
                DialogResult result = MessageBox.Show(
                    "Could not validate if this image matches the product.\n\n" +
                    "Are you sure this is the correct image?",
                    "Image Validation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                return result == DialogResult.Yes;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}


