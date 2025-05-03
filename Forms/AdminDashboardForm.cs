using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineShop.DATABASE;
using Microsoft.Data.SqlClient;
using OnlineShop.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;

namespace OnlineShop
{
    public partial class AdminDashboardForm : UserControl
    {
        private DBConn dbConn;

        public AdminDashboardForm()
        {
            InitializeComponent();
            dbConn = new DBConn();
            LoadTotalStock();
            LoadTotalOrders();
            LoadRevenue();
            LoadDailyRevenue();  
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ItemsInStock_TextChanged(object sender, EventArgs e)
        {
            LoadTotalStock();
        }

        //loads total no. of items in stock
        private void LoadTotalStock()
        {
            try
            {
                using (SqlConnection conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT SUM(InStock) as TotalStock FROM inventory";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        int totalStock = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                        ItemsInStock.Text = totalStock.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading total stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void totalOrders_TextChanged(object sender, EventArgs e)
        {
            LoadTotalOrders();
        }

        //loads total no. of orders
        private void LoadTotalOrders()
        {
            try
            {
                using (SqlConnection conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(PurchaseOrderId) as TotalOrder FROM sales";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        int totalOrder = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                        totalOrders.Text = totalOrder.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading total orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //loads total revenue
        private void stonks_txt_TextChanged(object sender, EventArgs e)
        {
            LoadRevenue();
        }

        private void LoadRevenue()
        {
            try
            {
                using (SqlConnection conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT SUM(TotalSales) as TotalRevenue FROM Reports";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal totalRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        stonks_txt.Text = totalRevenue.ToString("C");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading revenue: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Daily_TextChanged(object sender, EventArgs e)
        {
            LoadDailyRevenue();
        }

        private void LoadDailyRevenue()
        {
            try
            {
                using (SqlConnection conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT ISNULL(SUM(TotalSales), 0) as DailyRevenue 
                        FROM Reports 
                        WHERE CAST(ReportDate AS DATE) = CAST(GETDATE() AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal dailyRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        daily_revenue.Text = dailyRevenue.ToString("C");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading daily revenue: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //chart comes in here
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            UpdateMonthlySalesChart();
        }

        private void UpdateMonthlySalesChart()
        {
            try
            {
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

                    var plotModel = new PlotModel { Title = "Daily Sales for Current Month" };
                    
                    // Configure axes
                    plotModel.Axes.Add(new OxyPlot.Axes.DateTimeAxis { 
                        Position = OxyPlot.Axes.AxisPosition.Bottom,
                        Title = "Date",
                        StringFormat = "MM/dd"
                    });
                    
                    plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { 
                        Position = OxyPlot.Axes.AxisPosition.Left,
                        Title = "Sales Amount (₱)"
                    });

                    var lineSeries = new LineSeries
                    {
                        Title = "Daily Sales",
                        MarkerType = MarkerType.Circle,
                        MarkerSize = 4,
                        MarkerStroke = OxyColors.Blue,
                        TrackerFormatString = "{2:MM/dd/yyyy}\nSales: {4:C}"
                    };

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(0);
                            decimal sales = reader.GetDecimal(1);
                            
                            // Convert DateTime to OxyPlot's DateTimeAxis format
                            double dateValue = DateTimeAxis.ToDouble(date);
                            lineSeries.Points.Add(new DataPoint(dateValue, (double)sales));
                        }
                    }

                    plotModel.Series.Add(lineSeries);

                    // Create and configure the plot view
                    var plotView = new PlotView
                    {
                        Model = plotModel,
                        Dock = DockStyle.Fill,
                        BackColor = panel2.BackColor
                    };

                    // Clear existing controls and add the new plot
                    panel2.Controls.Clear();
                    panel2.Controls.Add(plotView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating sales chart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
