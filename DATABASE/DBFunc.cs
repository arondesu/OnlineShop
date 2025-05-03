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
    public bool emptyFields(TextBox txtItem_id, TextBox txtItem_name, ComboBox txtItem_type, TextBox txtItem_stock, TextBox txtItem_price, ComboBox txtItem_status)
    {
        try
        {

            if (txtItem_id.Text == "" ||
            txtItem_name.Text == "" ||
            txtItem_type.SelectedIndex == -1 ||
            txtItem_stock.Text == "" ||
            txtItem_price.Text == "" ||
            txtItem_status.SelectedIndex == -1)
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
    public bool checkItemID(string txtItem_id, string txtItem_name, string txtItem_type, string txtItem_stock, string txtItem_price, string txtItem_status, string AddProductForm_imageView)
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
    public bool AddProduct(string txtItem_id, string txtItem_name, string txtItem_type, string txtItem_stock, string txtItem_price, string txtItem_status, string AddProductForm_imageView)
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
        if (!checkItemID(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status, AddProductForm_imageView))
        {
            return false; // Prevent adding duplicate product
        }

        using SqlConnection conn = dbConn.GetConnection();
        conn.Open();

        string insertData = "INSERT INTO items (item_id, item_name, item_type, item_stock, item_price, item_status, item_image, date_insert) " +
                            "VALUES (@itemID, @itemName, @itemType, @itemStock, @itemPrice, @itemStatus, @itemImage, @dateInsert)";

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
            cmd.Parameters.AddWithValue("@itemStock", itemStock); // Use parsed integer
            cmd.Parameters.AddWithValue("@itemPrice", itemPrice); // Use parsed decimal
            cmd.Parameters.AddWithValue("@itemStatus", txtItem_status.Trim());
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


    //FUNCTION FOR ADDING STOCK ON ITEMS(SHOP)
    public void SyncQuantityLabels(Dictionary<string, Label> quantityLabels) //stocks label are shown
    {
        try
        {
            DataTable inventoryData = checkInvTable(string.Empty);
            if (inventoryData != null && inventoryData.Rows.Count > 0)
            {
                foreach (DataRow row in inventoryData.Rows)
                {
                    // Debug information to see what columns are available
                    Console.WriteLine("Available columns: " + string.Join(", ", inventoryData.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));

                    // Use the correct column names from your items table
                    string productName = row["ProductName"]?.ToString();

                    if (!string.IsNullOrEmpty(productName) && quantityLabels.ContainsKey(productName) && quantityLabels[productName] != null)
                    {
                        if (int.TryParse(row["InStock"]?.ToString(), out int quantity))
                        {
                            quantityLabels[productName].Text = $"In Stock: {quantity}";
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
            MessageBox.Show("Error syncing quantity labels: " + ex.Message, "Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string salesQuery = @"INSERT INTO sales (PurchaseOrderNo, Subtotal, Discount, Total) 
                                 VALUES (@OrderNo, @Subtotal, @Discount, @Total)";

                using SqlCommand salesCmd = new SqlCommand(salesQuery, conn, transaction);
                salesCmd.Parameters.AddWithValue("@OrderNo", GenerateOrderNumber());
                salesCmd.Parameters.AddWithValue("@Subtotal", subtotal);
                salesCmd.Parameters.AddWithValue("@Discount", discount);
                salesCmd.Parameters.AddWithValue("@Total", total);
                salesCmd.ExecuteNonQuery();

                // 2. Update inventory quantities + insert into Reports
                for (int i = 0; i < itemNames.Count; i++)
                {
                    // 2a. Update inventory
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
    public void InsertReport(string productName, int quantitySold, decimal unitPrice)
    {
        decimal totalSales = quantitySold * unitPrice;

        using SqlConnection conn = dbConn.GetConnection();
        conn.Open();

        string query = @"INSERT INTO Reports (ProductName, QuantitySold, TotalSales, ReportDate)
                     VALUES (@productName, @quantitySold, @totalSales, @reportDate)";

        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@productName", productName);
        cmd.Parameters.AddWithValue("@quantitySold", quantitySold);
        cmd.Parameters.AddWithValue("@totalSales", totalSales);
        cmd.Parameters.AddWithValue("@reportDate", DateTime.Now);
        cmd.ExecuteNonQuery();

        conn.Close();
    }


}
