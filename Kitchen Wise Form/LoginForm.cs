using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on startup
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();  // Hide the current form
            InventoryForm mainForm = new InventoryForm();
            mainForm.Show();

        }
    }
}
