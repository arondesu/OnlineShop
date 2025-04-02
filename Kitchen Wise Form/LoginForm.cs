using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineShop.DATABASE;

namespace OnlineShop
{
    public partial class LoginForm : Form
    {
<<<<<<< HEAD
        private DBConn dbConn;

=======
        DBFunc func = new DBFunc();
>>>>>>> d6b6cfbfa4f9f904b26b76b11534999221329988
        public LoginForm()
        {
            InitializeComponent();
            dbConn = new DBConn();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
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
                            // Proceed to the next form or operation
                            InventoryForm inv = new InventoryForm();
                            inv.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
=======

            String username = txtUsername.Text;
            String password = txtPassword.Text;

            if (func.isLoginTrue(username, password))
            {
                MessageBox.Show("Login Successful!");
                this.Hide();
                InventoryForm inventoryForm = new InventoryForm();
                inventoryForm.Show();
>>>>>>> d6b6cfbfa4f9f904b26b76b11534999221329988
            }
            else
            {
<<<<<<< HEAD
                MessageBox.Show($"Error during login: {ex.Message}");
=======
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> d6b6cfbfa4f9f904b26b76b11534999221329988
            }
        }
    }
}
