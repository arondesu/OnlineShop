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
            LoadInventoryData(); // Load data when form starts
        }

        private void LoadInventoryData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\VS Repos\DATABASE\appliance_db.mdf"";Integrated Security=True"))
                {
                    connection.Open();
                    string query = "SELECT * FROM Inventory";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            LoadInventoryData(); // Refresh data when home button is clicked
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
    }
}
