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
            inv_bg_pic.Visible = true;
            inv_bg_pic.BringToFront();
            addProductForm1.Visible = false;
            adminDashboardForm1.Visible = true;

            // Initialize data grids
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;

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

        public void CheckInventory(string productID) //called from dbFunc.cs
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

            // Another example of getting data from inv table
            using SqlConnection connection = dbConn.GetConnection();
            connection.Open();
            Console.WriteLine("Database connected successfully!");

            string query = "SELECT ProductId, QuantityInStock, Location FROM Inventory WHERE ProductId = @ProductId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductId", productID); // Use the method parameter 'productID' here

            try
            {
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
                    Console.WriteLine($"No inventory found for Product ID: {productID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking inventory: {ex.Message}");
            }
        }

        private void LoadInventoryData() //plan to transfer this to dbFunc.cs
        {
            try
            {
                using SqlConnection connection = dbConn.GetConnection();
                connection.Open();
                Console.WriteLine("Database connected successfully!");

                // Test if table exists
                string checkTable = "SELECT COUNT(*) FROM sys.tables WHERE name = 'inventory'";
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
           
            adminDashboardForm1.Visible = false;
            addProductForm1.Visible = true;
            addProductForm1.BringToFront();
            salesDataGrid.Visible = false;
            LoadItemData();
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = true;
        }

        private void LoadItemData() //Loads items data into the item data grid // PALIHUG KOG TRANSFER ANI SA DBFUNC KAY FUNCTION NI. TYYY
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
                        aid.ItemID = reader["item_id"].ToString();
                        aid.ItemName = reader["item_name"].ToString();
                        aid.Type = reader["item_type"].ToString();
                        aid.Stock = reader["item_stock"].ToString();
                        aid.Price = reader["item_price"].ToString();
                        aid.Status = reader["item_status"].ToString();
                        aid.Image = reader["item_image"].ToString();
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

        private void invBtn_Click(object sender, EventArgs e) //Inventory button; CRU operations need to be applied.
        {

            LoadItemData();
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = true;
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

    }
}
