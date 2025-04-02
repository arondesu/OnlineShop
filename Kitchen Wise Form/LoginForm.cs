using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineShop.DATABASE;

namespace OnlineShop
{
    public partial class LoginForm : Form
    {
        private DBConn dbConn;

        public LoginForm()
        {
            InitializeComponent();
            dbConn = new DBConn();
            txtPassword.PasswordChar = '*'; // Set the password character
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = dbConn.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM Login WHERE Username = @username AND Password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        int userCount = (int)cmd.ExecuteScalar();
                        if (userCount > 0)
                        {
                            MessageBox.Show("Login successful!");
                            this.Hide(); // Hide the current login form
                            InventoryForm inv = new InventoryForm();
                            inv.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}");
            }
        }
    }
}
