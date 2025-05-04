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
using OnlineShop.Forms;

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

            // Subscribe to inventory changes
            if (addInventory1 != null)
            {
                addInventory1.InventoryChanged += OnInventoryChanged;
            }

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

                string query = @"
                    SELECT 
                        PurchaseOrderNo,
                        Subtotal,
                        Discount,
                        Total,
                        PurchaseDate
                    FROM Sales
                    ORDER BY PurchaseDate DESC";

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
            addInventory1.BringToFront();
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
            addInventory1.Visible = true;
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

        private void LoadItemData()
        {
            try
            {
                using SqlConnection conn = dbConn.GetConnection();
                conn.Open();

                // Only select needed columns and format the query for better readability
                string selectItem = @"
                    SELECT 
                        id,
                        item_id,
                        item_name,
                        item_type,
                        item_stock,
                        item_price,
                        item_image,
                        date_insert,
                        date_update
                    FROM items 
                    WHERE date_delete IS NULL 
                    ORDER BY date_update DESC";

                using (SqlCommand cmd = new SqlCommand(selectItem, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Configure DataGridView before setting DataSource
                    itemDataGrid.AutoGenerateColumns = true;
                    itemDataGrid.AllowUserToAddRows = false;
                    itemDataGrid.AllowUserToDeleteRows = false;
                    itemDataGrid.ReadOnly = true;
                    itemDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    itemDataGrid.MultiSelect = false;
                    itemDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Set the DataSource
                    itemDataGrid.DataSource = dt;

                    // Format specific columns
                    if (itemDataGrid.Columns["date_insert"] != null)
                        itemDataGrid.Columns["date_insert"].DefaultCellStyle.Format = "g";
                    if (itemDataGrid.Columns["date_update"] != null)
                        itemDataGrid.Columns["date_update"].DefaultCellStyle.Format = "g";
                    if (itemDataGrid.Columns["item_price"] != null)
                        itemDataGrid.Columns["item_price"].DefaultCellStyle.Format = "C2";

                    itemDataGrid.Visible = true;
                    itemDataGrid.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading item data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            r.ProductName,
            r.QuantitySold,
            r.TotalSales,
            r.StocksAdded,
            r.ReportDate
            FROM Reports r
            ORDER BY r.ReportDate DESC";

            using SqlConnection conn = dbConn.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgv.DataSource = dt;
        }

        public void RefreshReportsGrid()
        {
            string query = "SELECT ReportDate, ProductName, QuantitySold, StocksAdded, TotalSales FROM Reports ORDER BY ReportDate DESC";

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
                    using Document document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30); // Changed to landscape for graph
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

                    // Add Sales Graph
                    document.NewPage();
                    Font graphTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    Paragraph graphTitle = new Paragraph("Daily Sales Graph", graphTitleFont);
                    graphTitle.Alignment = Element.ALIGN_CENTER;
                    document.Add(graphTitle);
                    document.Add(new Paragraph("\n"));

                    // Create the graph image
                    var plotModel = CreateSalesPlotModel();
                    var pngExporter = new OxyPlot.WindowsForms.PngExporter { Width = 800, Height = 400 };
                    using (var stream = new MemoryStream())
                    {
                        pngExporter.Export(plotModel, stream);
                        var chartImage = iTextSharp.text.Image.GetInstance(stream.ToArray());
                        chartImage.ScaleToFit(document.PageSize.Width - 50, document.PageSize.Height - 100);
                        chartImage.Alignment = Element.ALIGN_CENTER;
                        document.Add(chartImage);
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

        private OxyPlot.PlotModel CreateSalesPlotModel()
        {
            var plotModel = new OxyPlot.PlotModel { Title = "Daily Sales for Current Month" };
            
            plotModel.Axes.Add(new OxyPlot.Axes.DateTimeAxis { 
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Title = "Date",
                StringFormat = "MM/dd"
            });
            
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { 
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Sales Amount (₱)",
                LabelFormatter = value => string.Format("₱{0:N2}", value)  // Changed to use LabelFormatter instead of StringFormat
            });
        
            var lineSeries = new OxyPlot.Series.LineSeries
            {
                Title = "Daily Sales",
                MarkerType = OxyPlot.MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyPlot.OxyColors.Blue,
                TrackerFormatString = "Date: {2:MM/dd/yyyy}\nSales: ₱{4:N2}"  // Updated tracker format
            };
        
            using (SqlConnection conn = dbConn.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        CAST(ReportDate AS DATE) as SaleDate,
                        SUM(TotalSales) as DailySales
                    FROM Reports
                    WHERE ReportDate >= DATEADD(MONTH, -1, GETDATE())
                    GROUP BY CAST(ReportDate AS DATE)
                    ORDER BY SaleDate";
        
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        decimal sales = reader.GetDecimal(1);
                        double dateValue = OxyPlot.Axes.DateTimeAxis.ToDouble(date);
                        lineSeries.Points.Add(new OxyPlot.DataPoint(dateValue, (double)sales));
                    }
                }
            }
        
            plotModel.Series.Add(lineSeries);
            return plotModel;
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

        private void InventoryIcon_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void itemIcon_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.BringToFront();
            adminDashboardForm1.Visible = true;
            reports_grid.Visible = false;
            addProductForm1.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            LoadInventoryData();
            addInventory1.BringToFront();
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
            addInventory1.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            LoadItemData();
            addProductForm1.BringToFront();
            adminDashboardForm1.Visible = false;
            addProductForm1.Visible = true;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            LoadSalesData();
            inv_bg_pic.Visible = false;
            homeDataGrid.Visible = false;
            salesDataGrid.Visible = true;
            salesDataGrid.BringToFront();
        }

        //reports section
        private void label3_Click_1(object sender, EventArgs e)
        {
            reports_grid.BringToFront();
            RefreshReportsGrid();
            reports_grid.Visible = true;
            reports_grid.Columns["ReportDate"].DefaultCellStyle.Format = "g"; // short datetime
            adminDashboardForm1.Visible = false;
            addProductForm1.Visible = false;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            LoadItemData();
            addProductForm1.BringToFront();
            adminDashboardForm1.Visible = false;
            addProductForm1.Visible = true;
            salesDataGrid.Visible = false;
            itemdatagrid.Visible = false;
        }

        private void adminDashboardForm1_Load(object sender, EventArgs e)
        {

        }

        // Add handler for inventory changes
        private void OnInventoryChanged(object sender, EventArgs e)
        {
        // Refresh inventory data when changes occur
        LoadInventoryData();
        }
    }
}
