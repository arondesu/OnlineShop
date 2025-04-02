using System;
<<<<<<< HEAD
using System.Data.SqlClient;
using System.Windows.Forms;
=======
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
>>>>>>> d6b6cfbfa4f9f904b26b76b11534999221329988

namespace OnlineShop.DATABASE
{
    internal class DBConn
    {
<<<<<<< HEAD
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
=======
        private MySqlConnection conn;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\arondesu\\Desktop\\New Folder\\DATABASE\\appliance_db.mdf\";Integrated Security=True";

        public MySqlConnection GetConnection()
        {
            try
            {//to be fixed
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //conn = new MySqlConnection(connectionString);
                    connection.Open();
                    MessageBox.Show("Database connected successfully!");
                }
                return conn; // Added return statement
>>>>>>> d6b6cfbfa4f9f904b26b76b11534999221329988
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed! {ex.Message}");
                throw;
            }
        }
    }
}
