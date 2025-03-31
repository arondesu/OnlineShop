using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace OnlineShop.DATABASE
{
    internal class DBConn
    {
        private MySqlConnection conn;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\arondesu\\Desktop\\New Folder\\DATABASE\\appliance_db.mdf\";Integrated Security=True";

        public MySqlConnection GetConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //conn = new MySqlConnection(connectionString);
                    connection.Open();
                    MessageBox.Show("Database connected successfully!");
                }
                return conn; // Added return statement
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed! {ex.Message}");
                throw;
            }
        }
    }
}
