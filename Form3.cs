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
    public partial class DealsForm : Form
    {
        public DealsForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on startup
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dealsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if MainForm is already open
            Main mainForm = Application.OpenForms.OfType<Main>().FirstOrDefault();

            if (mainForm != null) // If MainForm exists
            {
                mainForm.WindowState = FormWindowState.Normal; // Restore if minimized
                mainForm.Show();  // Show the existing MainForm
                mainForm.BringToFront(); // Bring it to the front
            }
            else
            {
                // If MainForm was closed, create a new one
                mainForm = new Main();
                mainForm.Show();
            }
            this.Hide();
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if ShopForm is already open
            ShopForm shopForm = Application.OpenForms.OfType<ShopForm>().FirstOrDefault();

            if (shopForm == null)
            {
                shopForm = new ShopForm();
                shopForm.Show();
            }
            else
            {
                shopForm.WindowState = FormWindowState.Normal;
                shopForm.Show();
                shopForm.BringToFront();
            }

            this.Hide();  // Hide the current form
        }


        private void itemName_Click(object sender, EventArgs e)
        {

        }

        private void Deals_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
