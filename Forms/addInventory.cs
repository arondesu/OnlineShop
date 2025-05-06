using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Data.SqlClient;
using OnlineShop.DATABASE;

namespace OnlineShop
{
    public partial class addInventory : UserControl
    {
        private DBFunc dbFunc = new DBFunc();
        private string imagePath = string.Empty;
        // Add this event
        public event EventHandler DataChanged;
        // Remove the txtQuantityReturned field declaration

        public addInventory()
        {
            InitializeComponent();

            // These controls should already be defined in the designer, so no need to create them programmatically.
            // Removed redundant ComboBox creation.

            // Set fixed size for DataGridView
            dataGridViewInventory.Width = 900;
            dataGridViewInventory.Height = 400;
            dataGridViewInventory.Dock = DockStyle.None;

            LoadInventoryData();
            InitializeComboBoxes();

            dataGridViewInventory.CellClick += dataGridViewInventory_CellClick;
        }

        private void InitializeComboBoxes()
        {
            cmbItemType.Items.Clear();
            cmbItemType.Items.AddRange(new[]
            {
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

            cmbItemStatus.Items.Clear();
            cmbItemStatus.Items.AddRange(new[]
            {
                "Available",
                "Low Stock",
                "Out of Stock"
            });
        }

        private void dataGridViewInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewInventory.Rows[e.RowIndex];

            txtItemId.Text = row.Cells.Count > 0 && row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
            txtItemName.Text = row.Cells.Count > 1 && row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "";
            cmbItemType.Text = row.Cells.Count > 2 && row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : "";

            if (row.Cells.Count > 3 && decimal.TryParse(row.Cells[3].Value?.ToString(), out var price))
                txtItemPrice.Text = price.ToString("F2");
            else
                txtItemPrice.Text = "";

            if (row.Cells.Count > 4 && int.TryParse(row.Cells[4].Value?.ToString(), out var stock))
                txtItemStock.Text = stock.ToString();
            else
                txtItemStock.Text = "";

            cmbItemStatus.Text = row.Cells.Count > 5 && row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : "Available";
        }

        public void LoadInventoryData()
        {
            try
            {
                DataTable dt = dbFunc.checkInvTable(string.Empty);
                dataGridViewInventory.DataSource = null;  // Clear existing data
                dataGridViewInventory.DataSource = dt;    // Set new data

                // Hide the Description and PurchasePrice columns
                if (dataGridViewInventory.Columns["Description"] != null)
                {
                    dataGridViewInventory.Columns["Description"].Visible = false;
                }
                if (dataGridViewInventory.Columns["PurchasePrice"] != null)
                {
                    dataGridViewInventory.Columns["PurchasePrice"].Visible = false;
                }
                for (int i = 0; i < dataGridViewInventory.Columns.Count; i++)
                {
                    if (dataGridViewInventory.Columns[i].Name.Contains("Description"))
                    {
                        // Set a reasonable fixed width for Description column
                        dataGridViewInventory.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridViewInventory.Columns[i].Width = 150; // Adjust this value as needed
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This can be the same as CellClick or left empty if not needed
            dataGridViewInventory_CellClick(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(txtItemId.Text) ||
                    string.IsNullOrWhiteSpace(txtItemName.Text) ||
                    string.IsNullOrWhiteSpace(cmbItemType.Text) ||
                    string.IsNullOrWhiteSpace(txtItemStock.Text) ||
                    string.IsNullOrWhiteSpace(txtItemPrice.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate numeric fields
                if (!int.TryParse(txtItemStock.Text, out int stock))
                {
                    MessageBox.Show("Stock must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtItemPrice.Text, out decimal price))
                {
                    MessageBox.Show("Price must be a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Remove QuantityReturned validation

                // Automatically determine status based on stock level
                string status;
                if (stock == 0)
                {
                    status = "Out of Stock";
                }
                else if (stock <= 10) // You can adjust this threshold as needed
                {
                    status = "Low Stock";
                }
                else
                {
                    status = "Available";
                }

                // Update the status ComboBox to show the calculated status
                cmbItemStatus.Text = status;

                // Check for duplicate product name
                using (SqlConnection conn = dbFunc.dbConn.GetConnection())
                {
                    conn.Open();

                    string checkNameQuery = "SELECT COUNT(*) FROM Inventory WHERE ProductName = @ProductName";
                    using (SqlCommand cmd = new SqlCommand(checkNameQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", txtItemName.Text.Trim());
                        int nameCount = (int)cmd.ExecuteScalar();
                        if (nameCount > 0)
                        {
                            MessageBox.Show("A product with this name already exists. Please use a different name.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert new inventory item without specifying ProductId
                    string insertQuery = @"INSERT INTO Inventory 
                                    (ProductName, Description, InStock, PurchasePrice, Status) 
                                    VALUES 
                                    (@ProductName, @Description, @InStock, @PurchasePrice, @Status);
                                    SELECT SCOPE_IDENTITY();";

                    int newInventoryId;
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", txtItemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", cmbItemType.Text.Trim());
                        cmd.Parameters.AddWithValue("@InStock", stock);
                        cmd.Parameters.AddWithValue("@PurchasePrice", price);
                        cmd.Parameters.AddWithValue("@Status", status);

                        // Get the newly generated ID
                        newInventoryId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Now insert into items table using the same ID
                    // In the btnAdd_Click method, modify the items table insertion part
                    string insertItemQuery = @"INSERT INTO items 
                    (item_id, item_name, item_type, Description, item_stock, item_price, date_insert) 
                    VALUES 
                    (@ItemId, @ItemName, @ItemType, @Description, @Stock, @Price, GETDATE())";

                    using (SqlCommand itemCmd = new SqlCommand(insertItemQuery, conn))
                    {
                        itemCmd.Parameters.AddWithValue("@ItemId", newInventoryId);  // Use the ID from Inventory table
                        itemCmd.Parameters.AddWithValue("@ItemName", txtItemName.Text.Trim());
                        itemCmd.Parameters.AddWithValue("@ItemType", cmbItemType.Text.Trim());
                        itemCmd.Parameters.AddWithValue("@Description", cmbItemType.Text.Trim());
                        itemCmd.Parameters.AddWithValue("@Stock", stock);
                        itemCmd.Parameters.AddWithValue("@Price", price);

                        itemCmd.ExecuteNonQuery();
                    }

                    // After successful addition
                    MessageBox.Show("Inventory item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh both grids
                    LoadInventoryData();
                    DataChanged?.Invoke(this, EventArgs.Empty);
                    // Update the ID textbox with the new ID
                    txtItemId.Text = newInventoryId.ToString();
                    // Clear the form fields
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding inventory item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(txtItemId.Text) ||
                    string.IsNullOrWhiteSpace(txtItemName.Text) ||
                    string.IsNullOrWhiteSpace(cmbItemType.Text) ||
                    string.IsNullOrWhiteSpace(txtItemStock.Text) ||
                    string.IsNullOrWhiteSpace(txtItemPrice.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate numeric fields
                if (!int.TryParse(txtItemStock.Text, out int stock))
                {
                    MessageBox.Show("Stock must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtItemPrice.Text, out decimal price))
                {
                    MessageBox.Show("Price must be a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Remove QuantityReturned validation

                // Automatically determine status based on stock level
                string status;
                if (stock == 0)
                {
                    status = "Out of Stock";
                }
                else if (stock <= 10) // You can adjust this threshold as needed
                {
                    status = "Low Stock";
                }
                else
                {
                    status = "Available";
                }

                // Update the status ComboBox to show the calculated status
                cmbItemStatus.Text = status;

                // Check if product ID exists
                using (SqlConnection conn = dbFunc.dbConn.GetConnection())
                {
                    conn.Open();

                    // Check if product exists
                    string checkExistsQuery = "SELECT COUNT(*) FROM Inventory WHERE ProductId = @ProductId";
                    int count = 0;

                    using (SqlCommand cmd = new SqlCommand(checkExistsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", txtItemId.Text.Trim());
                        count = (int)cmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Product ID does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Get current stock level before update
                    string getCurrentStockQuery = "SELECT InStock FROM Inventory WHERE ProductId = @ProductId";
                    int currentStock = 0;

                    using (SqlCommand cmd = new SqlCommand(getCurrentStockQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", txtItemId.Text.Trim());
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            currentStock = Convert.ToInt32(result);
                        }
                    }

                    // Calculate quantity change
                    int quantityChange = stock - currentStock;

                    if (quantityChange != 0) // Only create report if there's a change in quantity
                    {
                        // Insert into Reports table for tracking quantity changes
                        string reportQuery = @"INSERT INTO Reports 
                                        (ProductName, QuantitySold, StocksAdded, TotalSales, ReportDate)
                                        VALUES 
                                        (@ProductName, @QuantitySold, @StocksAdded, 0, GETDATE())";

                        using (SqlCommand reportCmd = new SqlCommand(reportQuery, conn))
                        {
                            reportCmd.Parameters.AddWithValue("@ProductName", txtItemName.Text.Trim());
                            reportCmd.Parameters.AddWithValue("@QuantitySold", quantityChange < 0 ? Math.Abs(quantityChange) : 0);
                            reportCmd.Parameters.AddWithValue("@StocksAdded", quantityChange > 0 ? quantityChange : 0);
                            reportCmd.ExecuteNonQuery();
                        }
                    }

                    // Update inventory item without QuantityReturned
                    string updateQuery = @"UPDATE Inventory 
                                        SET ProductName = @ProductName, 
                                            Description = @Description, 
                                            InStock = @InStock, 
                                            PurchasePrice = @PurchasePrice, 
                                            Status = @Status
                                        WHERE ProductId = @ProductId";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", txtItemId.Text.Trim());
                        cmd.Parameters.AddWithValue("@ProductName", txtItemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", cmbItemType.Text.Trim());
                        cmd.Parameters.AddWithValue("@InStock", stock);
                        cmd.Parameters.AddWithValue("@PurchasePrice", price);
                        cmd.Parameters.AddWithValue("@Status", status);

                        cmd.ExecuteNonQuery();

                        // Also update the items table to keep in sync
                        string updateItemQuery = @"UPDATE items 
                                               SET item_name = @ItemName,
                                                   item_type = @ItemType,
                                                   Description = @Description,
                                                   item_stock = @Stock,
                                                   item_price = @Price
                                               WHERE item_id = @ItemId";

                        using (SqlCommand itemCmd = new SqlCommand(updateItemQuery, conn))
                        {
                            itemCmd.Parameters.AddWithValue("@ItemId", txtItemId.Text.Trim());
                            itemCmd.Parameters.AddWithValue("@ItemName", txtItemName.Text.Trim());
                            itemCmd.Parameters.AddWithValue("@ItemType", cmbItemType.Text.Trim());
                            itemCmd.Parameters.AddWithValue("@Description", cmbItemType.Text.Trim());
                            itemCmd.Parameters.AddWithValue("@Stock", stock);
                            itemCmd.Parameters.AddWithValue("@Price", price);

                            itemCmd.ExecuteNonQuery();
                        }

                        string message = quantityChange > 0
                            ? $"Inventory item updated successfully!\nQuantity Added: {quantityChange}"
                            : quantityChange < 0
                                ? $"Inventory item updated successfully!\nQuantity Deducted: {Math.Abs(quantityChange)}"
                                : "Inventory item updated successfully!";

                        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh both grids and notify subscribers
                        LoadInventoryData();
                        DataChanged?.Invoke(this, EventArgs.Empty);

                        // Clear the form
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating inventory item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that an item is selected
                if (string.IsNullOrWhiteSpace(txtItemId.Text))
                {
                    MessageBox.Show("Please select an item to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item? This action cannot be undone.",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = dbFunc.dbConn.GetConnection())
                    {
                        conn.Open();

                        // Delete from Inventory table
                        string deleteInventoryQuery = "DELETE FROM Inventory WHERE ProductId = @ProductId";
                        using (SqlCommand cmd = new SqlCommand(deleteInventoryQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", txtItemId.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        // Delete from items table
                        string deleteItemQuery = "DELETE FROM items WHERE item_id = @ItemId";
                        using (SqlCommand cmd = new SqlCommand(deleteItemQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ItemId", txtItemId.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the data grid and notify subscribers
                        LoadInventoryData();
                        DataChanged?.Invoke(this, EventArgs.Empty);

                        // Clear the form
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtItemId.Clear();
            txtItemName.Clear();
            txtItemStock.Clear();
            txtItemPrice.Clear();
            // Remove txtQuantityReturned.Clear() line
            cmbItemType.SelectedIndex = -1;
            cmbItemStatus.SelectedIndex = -1;
            imagePath = string.Empty;
        }

        private void stockLbl_Click(object sender, EventArgs e)
        {

        }

        private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtItemPrice.KeyPress += txtItemPrice_KeyPress;
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

        private void txtItemStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtItemStock.KeyPress += txtItemStock_KeyPress;
            // Allow only digits and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            // Refresh the inventory data grid
            LoadInventoryData();
            
            // Clear all form fields
            ClearForm();
            
            // Notify any subscribers that data has changed
            DataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
