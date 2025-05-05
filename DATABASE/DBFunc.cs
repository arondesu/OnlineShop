using Microsoft.Data.SqlClient; // Ensure only one SqlClient namespace is used
using System.Data;
using MySql.Data.MySqlClient;
using OnlineShop;
using OnlineShop.DATABASE;
using System.Windows.Forms;
using System.IO;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System;

public class DBFunc
{
    //use this file to improve readability
    internal DBConn dbConn = new DBConn();


    //FUNCTION FOR CHECKING IF USER, PASS IS TRUE
    public bool isLoginTrue(string username, string password)
    {
        try
        {
            using SqlConnection conn = dbConn.GetConnection();

            conn.Open();

            string query = "SELECT COUNT(*) FROM Login WHERE Username = @username AND Password = @password";

            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            int userCount = Convert.ToInt32(command.ExecuteScalar());

            if (userCount > 0)
            {  
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message);
            return false;
        }
        
    }

    //FUNCTION FOR CHECKING IF ITEM IS EMPTY
    public bool emptyFields(TextBox txtItem_id, TextBox txtItem_name, ComboBox txtItem_type, TextBox txtItem_stock, TextBox txtItem_price, ComboBox txtDescription)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtItem_id.Text) ||
                string.IsNullOrWhiteSpace(txtItem_name.Text) ||
                txtItem_type.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtItem_stock.Text) ||
                string.IsNullOrWhiteSpace(txtItem_price.Text) ||
                txtDescription.SelectedIndex == -1)
            {
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message);
            return false;
        }
    }

    //FUNCTION FOR CHECKING DUPLICATE ID
    public bool checkItemID(string txtItem_id, string txtItem_name, string txtItem_type, string txtItem_stock, string txtItem_price, string txtDescription, string AddProductForm_imageView)
    {
        try
        {
            using SqlConnection conn = dbConn.GetConnection();
            conn.Open();

            // Check for duplicate item ID
            string IDSelection = "SELECT * FROM items WHERE item_id = @item_ID OR item_name = @item_name";

            using (SqlCommand selectItemID = new SqlCommand(IDSelection, conn))
            {
                selectItemID.Parameters.AddWithValue("@item_ID", txtItem_id.Trim());
                selectItemID.Parameters.AddWithValue("@item_name", txtItem_name.Trim());

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectItemID))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count >= 1)
                    {
                        string duplicateField = dataTable.Rows[0]["item_id"].ToString() == txtItem_id.Trim() ? "ID" : "name";
                        MessageBox.Show($"Product {duplicateField}: {(duplicateField == "ID" ? txtItem_id.Trim() : txtItem_name.Trim())} already exists. Please use a unique {duplicateField.ToLower()}.",
                            "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error checking item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    //FUNCTION FOR ADDING PRODUCT
    public bool AddProduct(string txtItem_id, string txtItem_name, string txtItem_type, string txtDescription, string txtItem_stock, string txtItem_price, string AddProductForm_imageView)
    {
        // Validate numeric fields
        if (!int.TryParse(txtItem_stock, out int itemStock))
        {
            MessageBox.Show("Invalid stock value. Please enter a valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (!decimal.TryParse(txtItem_price, out decimal itemPrice))
        {
            MessageBox.Show("Invalid price value. Please enter a valid decimal number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Check if the item ID already exists
        if (!checkItemID(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtDescription, AddProductForm_imageView))
        {
            return false; // Prevent adding duplicate product
        }

        using SqlConnection conn = dbConn.GetConnection();
        conn.Open();

        // Corrected query matching table columns
        string insertData = "INSERT INTO items (item_id, item_name, item_type, Description, item_stock, item_price, date_insert) " +
                           "VALUES (@itemID, @itemName, @itemType, @Description, @itemStock, @itemPrice, @dateInsert)";

        try
        {
            using SqlCommand cmd = new SqlCommand(insertData, conn);
            cmd.Parameters.AddWithValue("@itemID", txtItem_id.Trim());
            cmd.Parameters.AddWithValue("@itemName", txtItem_name.Trim());
            cmd.Parameters.AddWithValue("@itemType", txtItem_type.Trim());
            cmd.Parameters.AddWithValue("@Description", txtDescription.Trim());
            cmd.Parameters.AddWithValue("@itemStock", itemStock);
            cmd.Parameters.AddWithValue("@itemPrice", itemPrice);
            cmd.Parameters.AddWithValue("@dateInsert", DateTime.Now);

            cmd.ExecuteNonQuery();
            
            // After successfully adding the product, sync the inventory
            SyncInventoryToItems();
            
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }


    //FUNCTION FOR 
    public DataTable checkInvTable(string ProductID)
{
    try
    {
        using SqlConnection connection = dbConn.GetConnection();
        connection.Open();

        string query = "SELECT * FROM Inventory";
        using SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        return dt; // Always return the DataTable, even if empty
    }
    catch (Exception ex)
    {
        MessageBox.Show("Connection Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return new DataTable();
    }
}


    //FUNCTION FOR ADDING STOCK ON ITEMS(SHOP) WITH BUTTON CONTROL
    public void SyncQuantityLabelsAndButtons(Dictionary<string, Label> quantityLabels, Dictionary<string, Button> addButtons)
    {
        try
        {
            DataTable inventoryData = checkInvTable(string.Empty);
            if (inventoryData != null && inventoryData.Rows.Count > 0)
            {
                foreach (DataRow row in inventoryData.Rows)
                {
                    // Use the correct column names from your items table
                    string productName = row["ProductName"]?.ToString();

                    if (!string.IsNullOrEmpty(productName) && 
                        quantityLabels.ContainsKey(productName) && 
                        quantityLabels[productName] != null &&
                        addButtons.ContainsKey(productName) && 
                        addButtons[productName] != null)
                    {
                        if (int.TryParse(row["InStock"]?.ToString(), out int quantity))
                        {
                            if (quantity <= 0)
                            {
                                // No stock available
                                quantityLabels[productName].Text = "NO STOCK";
                                quantityLabels[productName].ForeColor = Color.Red;
                                addButtons[productName].Enabled = false;
                                addButtons[productName].BackColor = Color.Red;
                                addButtons[productName].Text = "X";  // Change + to X
                                addButtons[productName].ForeColor = Color.White;  // Make X white
                            }
                            else
                            {
                                // Stock available - use the specified color (158, 147, 114)
                                quantityLabels[productName].Text = $"In Stock: {quantity}";
                                quantityLabels[productName].ForeColor = SystemColors.ControlText;
                                addButtons[productName].Enabled = true;
                                addButtons[productName].BackColor = Color.FromArgb(158, 147, 114);
                                addButtons[productName].Text = "+";  // Ensure it's + when in stock
                                addButtons[productName].ForeColor = Color.White;  // Keep text color white
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No inventory data available", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error syncing quantity labels and buttons: " + ex.Message, "Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //FUNCTION FOR CHECKOUT BUTTON
    public void ProcessCheckout(decimal subtotal, decimal discount, decimal total, List<string> itemNames, List<int> quantities)
    {
        try
        {
            using SqlConnection conn = dbConn.GetConnection();
            conn.Open();

            using SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                // 1. Insert into sales table
                // In the ProcessCheckout method
                string salesQuery = @"INSERT INTO sales (PurchaseOrderNo, Subtotal, Discount, Total, PurchaseDate) 
                                     VALUES (@OrderNo, @Subtotal, @Discount, @Total, @PurchaseDate)";
                
                using SqlCommand salesCmd = new SqlCommand(salesQuery, conn, transaction);
                salesCmd.Parameters.AddWithValue("@OrderNo", GenerateOrderNumber());
                salesCmd.Parameters.AddWithValue("@Subtotal", subtotal);
                salesCmd.Parameters.AddWithValue("@Discount", discount);
                salesCmd.Parameters.AddWithValue("@Total", total);
                salesCmd.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);  // Add this line
                salesCmd.ExecuteNonQuery();

                // 2. Update inventory quantities + insert into Reports
                for (int i = 0; i < itemNames.Count; i++)
                {
                    // 2a. Update inventory
                    string updateQuery = @"UPDATE Inventory 
                                     SET InStock = InStock - @Quantity,
                                         Status = CASE 
                                                    WHEN InStock - @Quantity = 0 THEN 'Out of Stock'
                                                    WHEN InStock - @Quantity <= 15 THEN 'Low Stock'
                                                    ELSE 'Available'
                                                  END
                                     WHERE ProductName = @ProductName";
                    using SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@Quantity", quantities[i]);
                    updateCmd.Parameters.AddWithValue("@ProductName", itemNames[i]);
                    updateCmd.ExecuteNonQuery();

                    // 2b. Get product price
                    string priceQuery = "SELECT PurchasePrice FROM Inventory WHERE ProductName = @ProductName";
                    using SqlCommand priceCmd = new SqlCommand(priceQuery, conn, transaction);
                    priceCmd.Parameters.AddWithValue("@ProductName", itemNames[i]);
                    object priceResult = priceCmd.ExecuteScalar();
                    decimal price = priceResult != null ? Convert.ToDecimal(priceResult) : 0;

                    // 2c. Insert or update Reports table
                    string reportQuery = @"
                        IF EXISTS (
                            SELECT 1 FROM Reports 
                            WHERE ProductName = @ProductName AND CAST(ReportDate AS DATE) = CAST(GETDATE() AS DATE)
                        )
                        BEGIN
                            UPDATE Reports 
                            SET QuantitySold = QuantitySold + @QuantitySold,
                                TotalSales = TotalSales + @TotalSales
                            WHERE ProductName = @ProductName AND CAST(ReportDate AS DATE) = CAST(GETDATE() AS DATE)
                        END
                        ELSE
                        BEGIN
                            INSERT INTO Reports (ProductName, QuantitySold, TotalSales, ReportDate)
                            VALUES (@ProductName, @QuantitySold, @TotalSales, GETDATE())
                        END";

                    using SqlCommand reportCmd = new SqlCommand(reportQuery, conn, transaction);
                    reportCmd.Parameters.AddWithValue("@ProductName", itemNames[i]);
                    reportCmd.Parameters.AddWithValue("@QuantitySold", quantities[i]);
                    reportCmd.Parameters.AddWithValue("@TotalSales", quantities[i] * price);
                    reportCmd.ExecuteNonQuery();

                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error processing checkout: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Checkout failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
    }

    //FUNCTION FOR CUSTOM GENERATE PO NUMBER
    private string GenerateOrderNumber()
    {
        // Generate a unique order number (PO-YYYYMMDD-XXXX)
        return $"PO-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
    }
    //FUNCTION FOR CLEARING FIELDS
    public void clearField(TextBox txtItem_id, TextBox txtItem_name, ComboBox txtItem_type, TextBox txtItem_stock, TextBox txtItem_price, ComboBox txtItem_status, PictureBox AddProductForm_imageView)
    {
        txtItem_id.Clear();
        txtItem_name.Clear();
        txtItem_type.SelectedIndex = -1;
        txtItem_stock.Clear();
        txtItem_price.Clear();
        txtItem_status.SelectedIndex = -1;
        AddProductForm_imageView.ImageLocation = null;
    }

    //Function for Reports table
    public void InsertReport(string productName, int quantitySold, decimal unitPrice, int quantityReturned)
    {
        decimal totalSales = quantitySold * unitPrice;

        using SqlConnection conn = dbConn.GetConnection();
        conn.Open();

        string query = @"INSERT INTO Reports (ProductName, QuantitySold, QuantityReturned, TotalSales, ReportDate)
                     VALUES (@productName, @quantitySold, @quantityReturn, @totalSales, @reportDate)";

        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@productName", productName);
        cmd.Parameters.AddWithValue("@quantitySold", quantitySold);
        cmd.Parameters.AddWithValue("@totalSales", totalSales);
        cmd.Parameters.AddWithValue("@reportDate", DateTime.Now);
        cmd.Parameters.AddWithValue("@quantityReturn", quantityReturned); // Now using the parameter instead of hardcoded 0
        cmd.ExecuteNonQuery();

        conn.Close();
    }

    //FUNCTION FOR SYNCING INVENTORY TO ITEMS TABLE
    public bool SyncInventoryToItems()
    {
        try
        {
            using SqlConnection conn = dbConn.GetConnection();
            conn.Open();
            
            using var transaction = conn.BeginTransaction();
            try
            {
                // First, sync existing items
                string updateQuery = @"
                    UPDATE it
                    SET item_stock = i.InStock,
                        item_price = i.PurchasePrice,
                        date_update = GETDATE()
                    FROM items it
                    INNER JOIN Inventory i ON i.ProductName = it.item_name
                    WHERE it.date_delete IS NULL";
                    
                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction))
                {
                    updateCmd.ExecuteNonQuery();
                }
                
                // Get the current maximum item_id number
                string getMaxIdQuery = @"
                    SELECT ISNULL(MAX(CAST(SUBSTRING(item_id, 5, LEN(item_id) - 4) AS INT)), 0)
                    FROM items 
                    WHERE item_id LIKE 'ITM-%'";
                
                int nextId;
                using (SqlCommand maxIdCmd = new SqlCommand(getMaxIdQuery, conn, transaction))
                {
                    nextId = Convert.ToInt32(maxIdCmd.ExecuteScalar()) + 1;
                }
                
                // Then, add new items that don't exist
                string insertQuery = @"
                    INSERT INTO items (item_id, item_name, item_type, item_stock, item_price, Description, date_insert)
                    SELECT 
                        'ITM-' + RIGHT('0000' + CAST(ROW_NUMBER() OVER (ORDER BY i.ProductName) + @nextId - 1 AS VARCHAR(4)), 4),
                        i.ProductName,
                        'General',
                        i.InStock,
                        i.PurchasePrice,
                        ISNULL(i.Description, ''),
                        GETDATE()
                    FROM Inventory i
                    LEFT JOIN items it ON i.ProductName = it.item_name
                    WHERE it.item_name IS NULL";
                    
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction))
                {
                    insertCmd.Parameters.AddWithValue("@nextId", nextId);
                    insertCmd.ExecuteNonQuery();
                }
                
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error syncing inventory: " + ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error syncing inventory: " + ex.Message);
            return false;
        }
    }
}



