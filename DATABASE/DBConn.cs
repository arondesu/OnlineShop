using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop.DATABASE
{
    internal class DBConn
    {
        private SqlConnection conn; // Change MySqlConnection to SqlConnection
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\VS Repos\DATABASE\appliance_db.mdf"";Integrated Security=True";

        public SqlConnection GetConnection() // Change return type to SqlConnection
        {
            try
            {
                conn = new SqlConnection(connectionString); // Initialize SqlConnection
                conn.Open();
                MessageBox.Show("Database connected successfully!");
                return conn; // Return the SqlConnection object
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed! {ex.Message}");
                throw;
            }
        }
    }
}
