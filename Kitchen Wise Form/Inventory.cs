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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Font = iTextSharp.text.Font;

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

        private void report_btn_Click(object sender, EventArgs e)
        {
            reports_grid.BringToFront();
            RefreshReportsGrid();
            reports_grid.Columns["ReportDate"].DefaultCellStyle.Format = "g"; // short datetime
            adminDashboardForm1.Visible = false;
            addProductForm1.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;

        }
        public void LoadReportData(DataGridView dgv)
        {
            string query = @"
            SELECT 
            i.ProductName,
            ISNULL(SUM(s.Total) / NULLIF(i.PurchasePrice, 0), 0) AS QuantitySold,
            ISNULL(SUM(s.Total), 0) AS TotalSales,
            GETDATE() AS ReportDate
            FROM Inventory i
            LEFT JOIN Sales s ON i.ProductName = s.PurchaseOrderNo -- replace this with actual matching column
            GROUP BY i.ProductName, i.PurchasePrice
            ORDER BY ReportDate DESC";

            using SqlConnection conn = dbConn.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgv.DataSource = dt;
        }

        public void RefreshReportsGrid()
        {
            string query = "SELECT ReportDate, ProductName, QuantitySold, TotalSales FROM Reports ORDER BY ReportDate DESC";

            using SqlConnection conn = dbConn.GetConnection();
            using SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            reports_grid.DataSource = dt;
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Load the data first
                LoadSalesData();
                LoadReportData(reports_grid);

                // Check if there's data to print
                if ((salesDataGrid.Rows.Count == 0 || salesDataGrid.Columns.Count == 0) &&
                    (reports_grid.Rows.Count == 0 || reports_grid.Columns.Count == 0))
                {
                    MessageBox.Show("No data available to generate PDF report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generate automatic filename with current date
                string fileName = $"REPORT FOR KITCHEN WISE_{DateTime.Now:yyyy-MM-dd}.pdf";

                using SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.FilterIndex = 1;
                saveDialog.DefaultExt = "pdf";
                saveDialog.FileName = fileName;  // Set the default filename

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create);
                    using Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    document.Open();

                    // Add a header
                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    Paragraph header = new Paragraph("Kitchen Wise Sales and Inventory Report", headerFont);
                    header.Alignment = Element.ALIGN_CENTER;
                    document.Add(header);
                    document.Add(new Paragraph("\n")); // Add some space

                    // Add date
                    Font dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    Paragraph date = new Paragraph($"Report Generated: {DateTime.Now:g}", dateFont);
                    date.Alignment = Element.ALIGN_RIGHT;
                    document.Add(date);
                    document.Add(new Paragraph("\n"));

                    // Add Sales Data if available
                    if (salesDataGrid.Rows.Count > 0 && salesDataGrid.Columns.Count > 0)
                    {
                        AddSectionToPdf(document, "Sales Data", salesDataGrid);
                    }

                    // Add Reports Data if available
                    if (reports_grid.Rows.Count > 0 && reports_grid.Columns.Count > 0)
                    {
                        document.NewPage();
                        AddSectionToPdf(document, "Reports Data", reports_grid);
                    }

                    document.Close();
                    MessageBox.Show("PDF generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddSectionToPdf(Document document, string title, DataGridView grid)
        {
            try
            {
                // Check if grid has columns
                if (grid.Columns.Count == 0)
                {
                    throw new Exception("DataGridView has no columns");
                }

                // Add section title
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                Paragraph sectionTitle = new Paragraph(title, titleFont);
                sectionTitle.SpacingAfter = 20f;
                document.Add(sectionTitle);

                // Create table with column count check
                PdfPTable pdfTable = new PdfPTable(grid.Columns.Count);
                pdfTable.WidthPercentage = 100;

                // Add headers
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.Padding = 5;
                    pdfTable.AddCell(cell);
                }

                // Add data rows
                Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow) // Skip the new row placeholder
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", cellFont));
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfCell.Padding = 4;
                            pdfTable.AddCell(pdfCell);
                        }
                    }
                }

                document.Add(pdfTable);
                document.Add(new Paragraph("\n"));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding section to PDF: {ex.Message}");
            }
        }
    }
}
