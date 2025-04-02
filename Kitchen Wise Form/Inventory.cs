using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnlineShop
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            homeDataGrid.Visible = false; 
            salesDataGrid.Visible = false;
        }

        private void LoadInventoryData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\arondesu\Desktop\New Folder\DATABASE\appliance_db.mdf"";Integrated Security=True"))
                {
                    connection.Open();
                    Console.WriteLine("Database connected successfully!");

                    // Test if table exists
                    string checkTable = "SELECT COUNT(*) FROM sys.tables WHERE name = 'Inventory'";
                    using (SqlCommand cmd = new SqlCommand(checkTable, connection))
                    {
                        int tableExists = (int)cmd.ExecuteScalar();
                        if (tableExists == 0)
                        {
                            Console.WriteLine("Inventory table does not exist!");
                            return;
                        }
                    }

                    // Test if data exists
                    string countQuery = "SELECT COUNT(*) FROM Inventory";
                    using (SqlCommand cmd = new SqlCommand(countQuery, connection))
                    {
                        int rowCount = (int)cmd.ExecuteScalar();
                        Console.WriteLine($"Number of rows in Inventory: {rowCount}");
                    }

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
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\arondesu\Desktop\New Folder\DATABASE\appliance_db.mdf"";Integrated Security=True"))
                {
                    connection.Open();
                    string query = "SELECT * FROM Sales";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    salesDataGrid.DataSource = dt;
                    salesDataGrid.AutoGenerateColumns = true;
                    salesDataGrid.ReadOnly = true;
                    salesDataGrid.AllowUserToAddRows = false;
                    salesDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void homeBtn_Click(object sender, EventArgs e)
        {
            LoadInventoryData(); // Refresh data when home button is clicked
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
    }
}
