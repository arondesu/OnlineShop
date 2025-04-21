using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineShop.DATABASE;
using OnlineShop.Kitchen_Wise_Form;

namespace OnlineShop
{
    public partial class KitchenWiseAdmin : Form
    {
        private DBFunc dbFunc;

        public KitchenWiseAdmin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on startup
            dbFunc = new DBFunc();
            
            // Set password character to hide the password input
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string username = textBox1.Text.Trim();
                string password = textBox2.Text.Trim();

                // Validate input
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Login Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Attempt login
                if (dbFunc.isLoginTrue(username, password))
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InventoryForm inventoryForm = new InventoryForm();
                    inventoryForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DATABASE ERROR: " + ex.Message, "Connection Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Password textbox - you might want to set PasswordChar property in the designer
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Username textbox
        }

        private void Userlbl_Click(object sender, EventArgs e)
        {
            // Username label click event
        }

        private void Passlbl_Click(object sender, EventArgs e)
        {
            // Password label click event
        }
    }
}
