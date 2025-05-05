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

using OnlineShop.DATABASE; // Make sure you have the correct namespace for DBFunc

namespace OnlineShop
{
    public partial class addInventory : UserControl
    {
        private DBFunc dbFunc = new DBFunc();
        private string imagePath = string.Empty;
        // Remove the txtQuantityReturned field declaration

        public addInventory()
        {
            InitializeComponent();

            // Create ComboBox controls programmatically if they don't exist
            if (cmbItemType == null)
            {
                cmbItemType = new ComboBox();
                cmbItemType.Name = "cmbItemType";
                cmbItemType.Location = new Point(200, 100); // Adjust as needed
                cmbItemType.Size = new Size(200, 25); // Adjust as needed
                this.Controls.Add(cmbItemType);
            }

            if (cmbItemStatus == null)
            {
                cmbItemStatus = new ComboBox();
                cmbItemStatus.Name = "cmbItemStatus";
                cmbItemStatus.Location = new Point(200, 150); // Adjust as needed
                cmbItemStatus.Size = new Size(200, 25); // Adjust as needed
                this.Controls.Add(cmbItemStatus);
            }

            // Remove QuantityReturned TextBox and Label creation

            // Set fixed size for DataGridView
            dataGridViewInventory.Width = 900;  // Set your desired width
            dataGridViewInventory.Height = 400; // Set your desired height

            // Remove Dock property if you want to keep the size fixed
            dataGridViewInventory.Dock = DockStyle.None;

            // If you use a panel for inputs, dock it to the bottom or set its size as needed
            // panelInputs.Dock = DockStyle.Bottom; // Optional, if you want the panel to stay at the bottom

            LoadInventoryData();

            // Initialize the combo boxes
            InitializeComboBoxes();

            // Add event handler for cell click
            dataGridViewInventory.CellClick += dataGridViewInventory_CellClick;
        }

        private void InitializeComboBoxes()
        {
            // Initialize item type combo box with actual descriptions
            cmbItemType.Items.Clear();
            cmbItemType.Items.AddRange(new string[] {
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

            // Initialize item status combo box
            cmbItemStatus.Items.Clear();
            cmbItemStatus.Items.AddRange(new string[] {
                "Available",
                "Low Stock",
                "Out of Stock"
            });
        }

        public void LoadInventoryData()
        {
            try
            {   //Hides the column of Description and PurchasePrice
                DataTable dt = dbFunc.checkInvTable(string.Empty);
                dataGridViewInventory.DataSource = dt;

                // Hide the Description and PurchasePrice columns
                if (dataGridViewInventory.Columns["Description"] != null)
                {
                    dataGridViewInventory.Columns["Description"].Visible = false;
                }
                if (dataGridViewInventory.Columns["PurchasePrice"] != null)
                {
                    dataGridViewInventory.Columns["PurchasePrice"].Visible = false;
                }
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

                // Debug: Print the number of columns
                int columnCount = dataGridViewInventory.Columns.Count;

                // Safely access cells based on available columns
                if (columnCount > 0) txtItemId.Text = row.Cells[0].Value?.ToString() ?? "";
                if (columnCount > 1) txtItemName.Text = row.Cells[1].Value?.ToString() ?? "";
                if (columnCount > 2) cmbItemType.Text = row.Cells[2].Value?.ToString() ?? "";

                // Fix the swapped indexes - PurchasePrice is at index 3, InStock is at index 4
                if (columnCount > 3) txtItemPrice.Text = row.Cells[3].Value?.ToString() ?? ""; 
                if (columnCount > 4) txtItemStock.Text = row.Cells[4].Value?.ToString() ?? ""; 

                // Get status from the row (assuming it's at index 5)
                if (columnCount > 5) cmbItemStatus.Text = row.Cells[5].Value?.ToString() ?? "Available";
                
                // Remove QuantityReturned code
            }
        }

        private void dataGridViewInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This can be the same as CellClick or left empty if not needed
            dataGridViewInventory_CellClick(sender, e);
        }

        // Add event to notify when inventory changes
        public event EventHandler InventoryChanged;

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

                // Check if product ID already exists
                using (SqlConnection conn = dbFunc.dbConn.GetConnection())
                {
                    conn.Open();

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
                    string insertItemQuery = @"INSERT INTO items 
                                        (item_name, item_type, Description, item_stock, item_price, date_insert) 
                                        VALUES 
                                        (@ItemName, @ItemType, @Description, @Stock, @Price, GETDATE())";

                    using (SqlCommand itemCmd = new SqlCommand(insertItemQuery, conn))
                    {
                        itemCmd.Parameters.AddWithValue("@ItemName", txtItemName.Text.Trim());  // Using ProductName as ItemName
                        itemCmd.Parameters.AddWithValue("@ItemType", cmbItemType.Text.Trim());
                        itemCmd.Parameters.AddWithValue("@Description", cmbItemType.Text.Trim());  // Using same Description
                        itemCmd.Parameters.AddWithValue("@Stock", stock);  // Using InStock value
                        itemCmd.Parameters.AddWithValue("@Price", price);  // Using PurchasePrice value

                        itemCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Inventory item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Update the ID textbox with the new ID
                    txtItemId.Text = newInventoryId.ToString();

                    // Refresh the data grid
                    LoadInventoryData();

                    // Notify subscribers that inventory has changed
                    InventoryChanged?.Invoke(this, EventArgs.Empty);

                    // Clear the form
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

                        // Just refresh inventory data
                        LoadInventoryData();

                        // Notify subscribers that inventory has changed
                        InventoryChanged?.Invoke(this, EventArgs.Empty);

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

        private void btnClear_Click(object sender, EventArgs e)
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
    }
}
