using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineShop.DATABASE;

namespace OnlineShop
{
    public partial class LoginForm : Form
    {
        private DBConn dbConn;
        private DBFunc dbFunc;  

        public LoginForm()
        {
            InitializeComponent();
            dbConn = new DBConn();
            dbFunc = new DBFunc();
            txtPassword.PasswordChar = '*'; // Set the password character
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUsername.Text;
                string pass = txtPassword.Text;

                bool isLoginTrue = dbFunc.isLoginTrue(user, pass);

                if (isLoginTrue)
                {
                    MessageBox.Show("Login Success.");
                    this.Hide(); // Hide the current login form
                    InventoryForm inv = new InventoryForm();
                    inv.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed. Wrong Username or Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}");
            }
            
        }
    }
}
