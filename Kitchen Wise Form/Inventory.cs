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

        public void itemListData()
        {
            AddItemData addItemData = new AddItemData();
            List<AddItemData> listDatas = addItemData.itemListData();

            itemdatagrid.DataSource = listDatas;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LoadItemData();
            addProductForm1.BringToFront();
            adminDashboardForm1.Visible = false;
            addProductForm1.Visible = true;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
        }

        private void invBtn_Click(object sender, EventArgs e) //Inventory button; CRU operations need to be applied.
        {
            LoadInventoryData();
            itemdatagrid.BringToFront();
            updateInvPnl.BringToFront();
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;
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

        private void LoadInventoryData()
        {
            try
            {
                using SqlConnection connection = dbConn.GetConnection();
                connection.Open();
                Console.WriteLine("Database connected successfully!");

                string query = "SELECT * FROM inventory";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                itemdatagrid.DataSource = dt;
                itemdatagrid.AutoGenerateColumns = true;
                itemdatagrid.Visible = true;
                itemdatagrid.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemData() //Loads items data into the item data grid 
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
                        aid.ItemID = reader["ProductId"].ToString();
                        aid.ItemName = reader["ProductName"].ToString();
                        aid.Type = reader["Description"].ToString();
                        aid.Stock = reader["InStock"].ToString();
                        aid.Price = reader["PurchasePrice"].ToString();
                        aid.Status = reader["ValueOnHand"].ToString();
                        aid.Image = reader["Photo"].ToString();
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
 
        private void itemdatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Make sure a valid row is clicked (not header or empty area)
                if (e.RowIndex >= 0)
                {
                    // Get the selected row
                    DataGridViewRow row = itemdatagrid.Rows[e.RowIndex];

                    // Populate the textboxes with data from the selected row
                    txtItemId.Text = row.Cells["ProductId"].Value.ToString();
                    txtItemName.Text = row.Cells["ProductName"].Value.ToString();

                    // For comboboxes, find and select the matching item
                    cmbItemType.Text = row.Cells["Description"].Value.ToString();

                    txtItemStock.Text = row.Cells["InStock"].Value.ToString();
                    txtItemPrice.Text = row.Cells["PurchasePrice"].Value.ToString();

                    cmbItemStatus.Text = row.Cells["ValueOnHand"].Value.ToString();

                    // For the image, set the image location if it exists
                    string imagePath = row.Cells["Photo"].Value?.ToString();
                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                    {
                        AddProductForm_imageView.ImageLocation = imagePath;
                    }
                    else
                    {
                        AddProductForm_imageView.ImageLocation = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting row: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemdatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Call the same code as in CellContentClick
            itemdatagrid_CellContentClick(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from your input controls
                string itemName = txtItemName.Text;
                string itemType = cmbItemType.Text;
                string itemStock = txtItemStock.Text;
                string itemPrice = txtItemPrice.Text;
                string itemStatus = cmbItemStatus.Text;
                string imagePath = AddProductForm_imageView.ImageLocation;

                // Validate inputs
                if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(itemType) || 
                    string.IsNullOrEmpty(itemStock) || string.IsNullOrEmpty(itemPrice))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Connect to database
                using SqlConnection conn = dbConn.GetConnection();
                conn.Open();

                // Calculate ValueOnHand as quantity × price
                int stock = Convert.ToInt32(itemStock);
                decimal price = Convert.ToDecimal(itemPrice);
                decimal valueOnHand = stock * price;

                // Modified SQL insert command
                string insertQuery = @"INSERT INTO inventory 
                            (ProductName, Description, InStock, PurchasePrice, SalesPrice, ValueOnHand, Photo, date_insert) 
                            VALUES 
                            (@itemName, @itemType, @itemStock, @itemPrice, @itemPrice, @valueOnHand, @itemImage, @dateInsert)";

                using SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@itemType", itemType);
                cmd.Parameters.AddWithValue("@itemStock", stock);
                cmd.Parameters.AddWithValue("@itemPrice", price);
                cmd.Parameters.AddWithValue("@valueOnHand", valueOnHand);
                
                // For the image, convert file to byte array if it exists
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
                    cmd.Parameters.Add("@itemImage", SqlDbType.VarBinary, imageData.Length).Value = imageData;
                }
                else
                {
                    cmd.Parameters.Add("@itemImage", SqlDbType.VarBinary).Value = DBNull.Value;
                }
                
                cmd.Parameters.AddWithValue("@dateInsert", DateTime.Now);

                // Execute the command
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Item added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields
                    ClearInputFields();

                    // Refresh the data grid to show the newly added item
                    LoadInventoryData();
                }
                else
                {
                    MessageBox.Show("Failed to add item.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to clear input fields
        private void ClearInputFields()
        {
            // Replace these with your actual input control names
            txtItemId.Text = "";
            txtItemName.Text = "";
            cmbItemType.SelectedIndex = -1;
            txtItemStock.Text = "";
            txtItemPrice.Text = "";
            cmbItemStatus.SelectedIndex = -1;
            AddProductForm_imageView.ImageLocation = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                string imagePath = string.Empty;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    AddProductForm_imageView.ImageLocation = imagePath;
                }
            }
            catch
            {
                MessageBox.Show("Error importing image. Please try again.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtItemId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


