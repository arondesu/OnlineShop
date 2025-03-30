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
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on startup
        }

        //string connectionString = @"DESKTOP-2FPFFH6\\SQLEXPRESS;Database=appliance_db;Integrated Security=True;";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //String username = txtUsername.Text;
            //String password = txtPassword.Text;

            //try
            //{
            //    String query = "SELECT * FROM Login WHERE Username = @username AND Password = @password";
            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    sda.SelectCommand.Parameters.AddWithValue("@username", username);
            //    sda.SelectCommand.Parameters.AddWithValue("@password", password);

            //    DataTable dtbl = new DataTable();
            //    sda.Fill(dtbl);

            //    if (dtbl.Rows.Count == 0)
            //    {
            //        username = txtUsername.Text;
            //        password = txtPassword.Text;

            //        this.Hide();  // Hide the current form
            //        InventoryForm invenForm = new InventoryForm();
            //        invenForm.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
