using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using OnlineShop;
using OnlineShop.DATABASE;

public class DBFunc
{

    private DBConn dbConn = new DBConn();

    /*    public bool isLoginTrue(string username, string password)
        {
            try
            {
                using MySqlConnection conn = dbConn.GetConnection();

                conn.Open();

                string query = "SELECT * FROM Login WHERE Username = @username AND Password = @password";

                using MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Login Successful!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                return false;
            }
        }*/
}
