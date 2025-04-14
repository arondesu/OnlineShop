using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Ensure only one SqlClient namespace is used
using OnlineShop.DATABASE;

namespace OnlineShop
{
    public partial class InventoryForm : Form
    {
        private DBConn dbConn;
        private DBFunc dbFunc;

        public InventoryForm()
        {
            InitializeComponent();
            dbConn = new DBConn();
            dbFunc = new DBFunc();
            this.StartPosition = FormStartPosition.CenterScreen;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;
        }

        /*public void CheckInventory(string productID) //called from dbFunc.cs
        {
            // Call the checkInvTable method
            DataTable inventoryTable = dbFunc.checkInvTable(productID);

            // Check if the DataTable is not null and has rows
            if (inventoryTable != null && inventoryTable.Rows.Count > 0)
            {
                Console.WriteLine("Inventory data retrieved successfully.");
                // Process the DataTable as needed
            }
            else
            {
                Console.WriteLine("No inventory data found or an error occurred.");
            }

        //another example of getting data from inv table
        using SqlConnection connection = dbConn.GetConnection();
                connection.Open();
                Console.WriteLine("Database connected successfully!");

        string query = "SELECT ProductId, QuantityInStock, Location FROM Inventory WHERE ProductId = @ProductId";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductId", productId);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product ID: {reader["ProductId"]}");
                        Console.WriteLine($"Quantity: {reader["QuantityInStock"]}");
                        Console.WriteLine($"Location: {reader["Location"]}");
                        Console.WriteLine("---------------------");
                    }
                }
                else
                {
                    Console.WriteLine($"No inventory found for Product ID: {productId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking inventory: {ex.Message}");
            }

        }*/

        private void LoadInventoryData() //plan to transfer this to dbFunc.cs
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
                    return;
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
                    homeDataGrid.DataSource = dt;
                    homeDataGrid.AutoGenerateColumns = true;
                    homeDataGrid.Visible = true;
                    homeDataGrid.Refresh();
                    homeDataGrid.AutoResizeColumns();
                    homeDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                salesDataGrid.AutoResizeColumns();
                salesDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void homeBtn_Click(object sender, EventArgs e) //Items button
        {
            LoadInventoryData();
            //CheckInventory("someProductID"); //plan for calling from dbFunc // Replace "someProductID" with the actual product ID you want to check
            homeDataGrid.Visible = true;
            salesDataGrid.Visible = false;
        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if MainShop is already open
            MainShop mainShop = Application.OpenForms.OfType<MainShop>().FirstOrDefault();

            if (mainShop == null)
            {
                mainShop = new MainShop();
                mainShop.Show();
            }
            else
            {
                mainShop.WindowState = FormWindowState.Normal;
                mainShop.Show();
                mainShop.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void salesBtn_Click(object sender, EventArgs e)
        {
            LoadSalesData();
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = true;
        }

        private void homePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //Calling the MainShop form
            MainShop mn = new MainShop();
            mn.Show();
            this.Hide();
        }
    }
}
