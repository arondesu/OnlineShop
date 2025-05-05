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

            if (txtItem_id.Text == "" ||
            txtItem_name.Text == "" ||
            txtItem_type.SelectedIndex == -1 ||
            txtItem_stock.Text == "" ||
            txtItem_price.Text == "" ||
            txtDescription.SelectedIndex == -1)
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

    //FUNCTION FOR CHECKING DUPLICATE ID
    public bool checkItemID(string txtItem_id, string txtItem_name, string txtItem_type, string txtItem_stock, string txtItem_price, string txtDescription, string AddProductForm_imageView)
    {
        try
        {
            using SqlConnection conn = dbConn.GetConnection();
            conn.Open();

            // Checking if the item ID already exists
            string IDSelection = "SELECT * FROM items WHERE item_id = @item_ID";

            using (SqlCommand selectItemID = new SqlCommand(IDSelection, conn))
            {
                selectItemID.Parameters.AddWithValue("@item_ID", txtItem_id.Trim());

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectItemID))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count >= 1)
                    {
                        MessageBox.Show($"Product ID: {txtItem_id.Trim()} already exists. Please use a unique ID.",
                            "Duplicate ID Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; // Exit early to prevent further processing
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
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

        string insertData = "INSERT INTO items (item_id, item_name, item_type, Description, item_stock, item_price, item_image, date_insert) " +
                           "VALUES (@itemID, @itemName, @itemType, @Description, @itemStock, @itemPrice, @itemImage, @dateInsert)";

        DateTime today = DateTime.Now;

        string path = Path.Combine(@"C:\Users\Woots\source\repos\OnlineShop\pictures items\" + txtItem_id.Trim());
        string directoryPath = Path.GetDirectoryName(path) ?? string.Empty;

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        if (string.IsNullOrEmpty(AddProductForm_imageView))
        {
            MessageBox.Show("Please select an image for the product.", "Image Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        File.Copy(AddProductForm_imageView, path, true);

        using (SqlCommand cmd = new SqlCommand(insertData, conn))
        {
            cmd.Parameters.AddWithValue("@itemID", txtItem_id.Trim());
            cmd.Parameters.AddWithValue("@itemName", txtItem_name.Trim());
            cmd.Parameters.AddWithValue("@itemType", txtItem_type.Trim());
            cmd.Parameters.AddWithValue("@Description", txtDescription.Trim());
            cmd.Parameters.AddWithValue("@itemStock", itemStock); // Use parsed integer
            cmd.Parameters.AddWithValue("@itemPrice", itemPrice); // Use parsed decimal
            cmd.Parameters.AddWithValue("@itemImage", path);
            cmd.Parameters.AddWithValue("@dateInsert", today);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product ID: " + txtItem_id.Trim() + " added successfully.", "Success Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }


    //FUNCTION FOR 
    public DataTable checkInvTable(string ProductID) //to be checked if working 
    {
        try
        {
            using SqlConnection connection = dbConn.GetConnection();
            connection.Open();

            // Test if table exists
            string checkTable = "SELECT COUNT(*) FROM sys.tables WHERE name = 'inventory'";
            using SqlCommand cmdTable = new SqlCommand(checkTable, connection);

            int tableExists = Convert.ToInt32(cmdTable.ExecuteScalar());

            if (tableExists == 0)
            {
                MessageBox.Show("Inventory table does not exist!");
                return new DataTable(); // Return an empty DataTable instead of null
            }

            // Test if data exists
            string countQuery = "SELECT COUNT(*) FROM inventory";
            using SqlCommand cmdData = new SqlCommand(countQuery, connection);

            int rowCount = Convert.ToInt32(cmdData.ExecuteScalar());
            Console.WriteLine($"Number of rows in Inventory: {rowCount}");

            // Original data loading code
            string query = "SELECT * FROM Inventory";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                MessageBox.Show("No data found in the Inventory table.");
                return new DataTable(); // Return an empty DataTable if no rows exist
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Connection Error: " + ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new DataTable(); // Return an empty DataTable in case of an exception
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
            
            // First, get all inventory items that aren't in the items table
            string query = @"
                SELECT i.* 
                FROM Inventory i
                LEFT JOIN items it ON i.ProductName = it.item_name
                WHERE it.item_name IS NULL";
                
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable inventoryItems = new DataTable();
            adapter.Fill(inventoryItems);
            
            if (inventoryItems.Rows.Count == 0)
            {
                return true; // No items to sync
            }
            
            // For each inventory item not in items table, add it
            foreach (DataRow row in inventoryItems.Rows)
            {
                string insertQuery = @"
                    INSERT INTO items (item_id, item_name, item_type, item_stock, item_price, Description, date_insert, date_update)
                    VALUES (@itemId, @itemName, @itemType, @itemStock, @itemPrice, @description, @dateInsert, @dateInsert)";
                    
                using SqlCommand cmd = new SqlCommand(insertQuery, conn);
                
                // Generate a unique item_id
                string itemId = "ITM" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(100, 999);
                
                cmd.Parameters.AddWithValue("@itemId", itemId);
                cmd.Parameters.AddWithValue("@itemName", row["ProductName"]);
                cmd.Parameters.AddWithValue("@itemType", "Kitchen Item"); // Default value since inventory doesn't have item_type
                cmd.Parameters.AddWithValue("@itemStock", row["InStock"]);
                cmd.Parameters.AddWithValue("@itemPrice", row["PurchasePrice"]);
                cmd.Parameters.AddWithValue("@description", row["Description"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@dateInsert", DateTime.Now);
                
                cmd.ExecuteNonQuery();
            }
            
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error syncing inventory to items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}



