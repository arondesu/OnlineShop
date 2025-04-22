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
            itemdatagrid.Visible = false;
        }


        private void home_btn_Click(object sender, EventArgs e) //brief details of each item?? i need your thoughts.
        {
            inv_bg_pic.Visible = true;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
        }

        private void item_btn_Click(object sender, EventArgs e) //Items button; CRUD operations need to be applied.
        {
            LoadItemData();
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = true;
        }

        private void LoadItemData() //Loads items data into the item data grid
        {
            try
            {
                // Get connection to the database
                using SqlConnection connection = dbConn.GetConnection();
                connection.Open();
                Console.WriteLine("Database connected successfully!");

                // Test if Items table exists
                string checkTable = "SELECT COUNT(*) FROM sys.tables WHERE name = 'Items'";
                using SqlCommand cmdTable = new SqlCommand(checkTable, connection);

                int tableExists = (int)cmdTable.ExecuteScalar();
                if (tableExists == 0)
                {
                    // If table doesn't exist, offer to create it
                    DialogResult result = MessageBox.Show("Items table does not exist! Would you like to create it?",
                        "Table Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        CreateItemsTable(connection);
                        // After creating the table, refresh the connection
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                // Load items data
                string query = "SELECT * FROM Items";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    itemdatagrid.DataSource = dt;
                    itemdatagrid.AutoGenerateColumns = true;
                    itemdatagrid.Visible = true;
                    itemdatagrid.Refresh();
                    itemdatagrid.AutoResizeColumns();
                    itemdatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    DialogResult result = MessageBox.Show("No items data found. Would you like to add sample data?",
                        "Empty Table", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        // Insert sample data
                        InsertItemsSampleData(connection);
                        // Reload the data
                        LoadItemData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message + "\n\nStack Trace: " + ex.StackTrace,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to create Items table
        private void CreateItemsTable(SqlConnection connection)
        {
            try
            {
                string createTableQuery = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Items')
                    BEGIN
                        CREATE TABLE Items (
                            ProductId INT IDENTITY(1,1) PRIMARY KEY,
                            ProductName NVARCHAR(100) NOT NULL,
                            Description NVARCHAR(255),
                            Price DECIMAL(10, 2) NOT NULL,
                            Stock INT NOT NULL DEFAULT 0
                        );
                    END";

                using SqlCommand cmd = new SqlCommand(createTableQuery, connection);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Items table created successfully!",
                    "Table Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating Items table: " + ex.Message,
                    "Table Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to insert sample data into Items table
        private void InsertItemsSampleData(SqlConnection connection)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO Items (ProductName, Description, Price, Stock)
                    VALUES 
                        ('Glass Food Storage', 'High-quality glass container for food storage', 275.00, 17),
                        ('Steel Mug Rack', 'Stainless steel rack for mugs', 50.45, 10),
                        ('Mitts Potholders', 'Heat-resistant kitchen mitts', 65.00, 27),
                        ('Steel Brazier Pot', 'Durable steel cooking pot', 150.50, 40),
                        ('Descascador', 'Multipurpose peeler tool', 79.00, 26),
                        ('Cleaning Sponge', 'Heavy-duty kitchen cleaning sponge', 35.50, 197),
                        ('Silverware Set', 'Complete set of silverware', 175.50, 776),
                        ('Kitchen Scale', 'Digital kitchen scale with high precision', 499.00, 53),
                        ('Table Cloth', 'Elegant table cloth for dining', 55.50, 500)";

                using SqlCommand cmd = new SqlCommand(insertQuery, connection);
                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show($"Successfully added {rowsAffected} sample items to the Items table!",
                    "Sample Data Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding sample data to Items table: " + ex.Message,
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Helper method to insert sample data
        private void InsertSampleData(SqlConnection connection)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO Inventory (ProductName, Description, Price, InStock, Category)
                    VALUES 
                        ('Glass Food Storage', 'High-quality glass container for food storage', 275.00, 50, 'Storage'),
                        ('Steel Mug Rack', 'Stainless steel rack for mugs', 50.45, 30, 'Organization'),
                        ('Mitts Potholders', 'Heat-resistant kitchen mitts', 65.00, 40, 'Safety'),
                        ('Steel Brazier Pot', 'Durable steel cooking pot', 150.50, 25, 'Cookware'),
                        ('Descascador', 'Multipurpose peeler tool', 79.00, 35, 'Utensils'),
                        ('Cleaning Sponge', 'Heavy-duty kitchen cleaning sponge', 35.50, 100, 'Cleaning'),
                        ('Silverware Set', 'Complete set of silverware', 175.50, 20, 'Dining'),
                        ('Kitchen Scale', 'Digital kitchen scale with high precision', 499.00, 15, 'Measurement'),
                        ('Table Cloth', 'Elegant table cloth for dining', 55.50, 45, 'Dining')";

                using SqlCommand cmd = new SqlCommand(insertQuery, connection);
                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show($"Successfully added {rowsAffected} sample items to inventory!",
                    "Sample Data Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding sample data: " + ex.Message,
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Helper method to execute SQL script (you can add this method to your class)
        private void ExecuteSqlScript(SqlConnection connection)
        {
            try
            {
                // Path to your SQL script file
                string scriptPath = @"c:\Users\Woots\source\repos\OnlineShop\DATABASE\SQLQuery1.sql";

                // Read the script content
                string script = System.IO.File.ReadAllText(scriptPath);

                // Split the script by GO statements if needed
                string[] commands = script.Split(new[] { "GO", "go" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string command in commands)
                {
                    if (!string.IsNullOrWhiteSpace(command))
                    {
                        using SqlCommand cmd = new SqlCommand(command, connection);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("SQL script executed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing SQL script: " + ex.Message,
                    "Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void invBtn_Click(object sender, EventArgs e) //Inventory button; CRU operations need to be applied.
        {
            LoadInventoryData();
            //CheckInventory("someProductID"); //plan for calling from dbFunc // Replace "someProductID" with the actual product ID you want to check
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = true;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
        }
        private void bck_btn_Click_2(object sender, EventArgs e)
        {
            //Calling the MainShop form
            MainShop mn = new MainShop();
            mn.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void salesDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void homeDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void inv_bg_pic_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void itemdatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CruPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Description_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
