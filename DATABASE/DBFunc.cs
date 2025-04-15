using Microsoft.Data.SqlClient; // Ensure only one SqlClient namespace is used
using System.Data;
using MySql.Data.MySqlClient;
using OnlineShop;
using OnlineShop.DATABASE;

public class DBFunc
{

    private DBConn dbConn = new DBConn();

    //use this file to improve readability

    public bool isLoginTrue(string username, string password)//transfered from LoginForm.cs func for login btn
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

    private string GenerateOrderNumber()
    {
        // Generate a unique order number (PO-YYYYMMDD-XXXX)
        return $"PO-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
    }
}
