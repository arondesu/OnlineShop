using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace OnlineShop
{
    public partial class LoginForm : Form
    {
        DBFunc func = new DBFunc();
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtPassword.UseSystemPasswordChar = true;    // This will use the system's default password character
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            String username = txtUsername.Text;
            String password = txtPassword.Text;

            if (func.isLoginTrue(username, password))
            {
                MessageBox.Show("Login Successful!");
                this.Hide();
                InventoryForm inventoryForm = new InventoryForm();
                inventoryForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
