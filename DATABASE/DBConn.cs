using System;
using System.Windows.Forms;
// Removed: using System.Data.SqlClient;
using Microsoft.Data.SqlClient; // Ensure only one SqlClient namespace is used


namespace OnlineShop.DATABASE
{
    internal class DBConn
    {
        private SqlConnection conn; // Use Microsoft.Data.SqlClient.SqlConnection
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Woots\source\repos\OnlineShop\DATABASE\appliance_db.mdf;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            try
            {
                conn = new SqlConnection(connectionString); // Initialize SqlConnection
                conn.Open();
                Console.WriteLine("Database connected successfully!");
                return conn; // Return the SqlConnection object
            }
            catch (Exception)
            {
                Console.WriteLine($"Database connection failed!");
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
