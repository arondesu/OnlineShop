using Microsoft.Data.SqlClient; // Ensure only one SqlClient namespace is used
using System.Data;
using MySql.Data.MySqlClient;
using OnlineShop;
using OnlineShop.DATABASE;
using System.Windows.Forms;
using System.IO;

public class DBFunc
{
    //use this file to improve readability

    private DBConn dbConn = new DBConn();
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
    public bool checkItemID(string txtItem_id, string txtItem_name, string txtItem_type, string txtItem_stock, string txtItem_price, string txtItem_status)
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
    public bool AddProduct(string txtItem_id, string txtItem_name, string txtItem_type, string txtItem_stock, string txtItem_price, string txtItem_status)
    {
        // Check if the item ID already exists
        if (!checkItemID(txtItem_id, txtItem_name, txtItem_type, txtItem_stock, txtItem_price, txtItem_status))
        {
            // If the item ID is not unique, return false to prevent adding the product
            return false;
        }

        using SqlConnection conn = dbConn.GetConnection();
        conn.Open();

        string insertData = "INSERT INTO items (item_id, item_name, item_type, item_stock, item_price, item_status, date_insert) " +
                            "VALUES (@itemID, @itemName, @itemType, @itemStock, @itemPrice, @itemStatus, @dateInsert)";

        DateTime today = DateTime.Now;

        using (SqlCommand cmd = new SqlCommand(insertData, conn))
        {
            cmd.Parameters.AddWithValue("@itemID", txtItem_id.Trim());
            cmd.Parameters.AddWithValue("@itemName", txtItem_name.Trim());
            cmd.Parameters.AddWithValue("@itemType", txtItem_type.Trim());
            cmd.Parameters.AddWithValue("@itemStock", txtItem_stock.Trim());
            cmd.Parameters.AddWithValue("@itemPrice", txtItem_price.Trim());
            cmd.Parameters.AddWithValue("@itemStatus", txtItem_status.Trim());
            cmd.Parameters.AddWithValue("@dateInsert", today);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Product ID: " + txtItem_id.Trim() + " added successfully.", "Success Message",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
    
    //FUNCTION FOR 
    public DataTable checkInvTable(string ProductID) //to be check if working 
    {
        try
        {
            using SqlConnection connection = dbConn.GetConnection();
            connection.Open();
            Console.WriteLine("Database connected successfully!");

            // Test if table exists
            string checkTable = "SELECT COUNT(*) FROM sys.tables WHERE name = 'Inventory'";
            using SqlCommand cmdTable = new SqlCommand(checkTable, connection);

            int tableExists = (int)cmdTable.ExecuteScalar();
            if (tableExists == 0)
            {
                MessageBox.Show("Inventory table does not exist!");
            }


            //Test if data exists
            string countQuery = "SELECT COUNT(*) FROM Inventory";
            using SqlCommand cmdData = new SqlCommand(countQuery, connection);

            int rowCount = (int)cmdData.ExecuteScalar();
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
        }
        catch (Exception ex)
        {
            MessageBox.Show("Connection Error: " + ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
        return null;
    }
    //FUNCTION FOR ADDING STOCK ON ITEMS(SHOP)
    public void SyncQuantityLabels(Dictionary<string, Label> quantityLabels) //stocks label are shown
    {
        try
        {
            DataTable inventoryData = checkInvTable(null);
            if (inventoryData != null)
            {
                foreach (DataRow row in inventoryData.Rows)
                {
                    string productName = row["ProductName"].ToString();
                    int quantity = Convert.ToInt32(row["InStock"]);

                    if (quantityLabels.ContainsKey(productName))
                    {
                        quantityLabels[productName].Text = $"In Stock: {quantity}";
                    }
                }
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
            
            // Begin transaction to ensure both operations complete
            using SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                // 1. Insert into sales table
                string salesQuery = @"INSERT INTO sales (PurchaseOrderNo, PurchaseDate, Subtotal, Discount, Total) 
                                    VALUES (@OrderNo, @Date, @Subtotal, @Discount, @Total)";
                
                using SqlCommand salesCmd = new SqlCommand(salesQuery, conn, transaction);
                salesCmd.Parameters.AddWithValue("@OrderNo", GenerateOrderNumber()); //random generated numbers
                salesCmd.Parameters.AddWithValue("@Date", DateTime.Now.Date);
                salesCmd.Parameters.AddWithValue("@Subtotal", subtotal);
                salesCmd.Parameters.AddWithValue("@Discount", discount);
                salesCmd.Parameters.AddWithValue("@Total", total);
                salesCmd.ExecuteNonQuery();

                // 2. Update inventory quantities
                for (int i = 0; i < itemNames.Count; i++)
                {
                    string updateQuery = "UPDATE Inventory SET InStock = InStock - @Quantity WHERE ProductName = @ProductName";
                    using SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@Quantity", quantities[i]);
                    updateCmd.Parameters.AddWithValue("@ProductName", itemNames[i]);
                    updateCmd.ExecuteNonQuery();
                }

                // Commit the transaction
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Rollback on error
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
}
