using System;
using System.Windows.Forms;
// Removed: using System.Data.SqlClient;
using Microsoft.Data.SqlClient; // Ensure only one SqlClient namespace is used

namespace OnlineShop.DATABASE
{
    internal class DBConn
    {
        private SqlConnection conn; // Use Microsoft.Data.SqlClient.SqlConnection
<<<<<<< HEAD
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Woots\source\repos\arondesu\OnlineShop\DATABASE\appliance_db.mdf"";Integrated Security=True";
=======
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ADMIN\source\repos\OnlineShop\DATABASE\appliance_db.mdf"";Integrated Security=True";
>>>>>>> 2ef51e8f9fbfe646900b42cb9b806ef220d6a954

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
