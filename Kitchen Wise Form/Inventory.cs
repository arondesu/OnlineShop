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
    public partial class InventoryForm : Form
    {

        static InventoryForm _obj;
        public static InventoryForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new InventoryForm();
                }
                return _obj;
            }
        }
        public InventoryForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on startup
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if MainShop is already open
            MainShop mainShop = Application.OpenForms.OfType<MainShop>().FirstOrDefault();

            if (mainShop == null)
            {
                mainShop = new MainShop();
                mainShop.Show();
            }
            else
            {
                mainShop.WindowState = FormWindowState.Normal;
                mainShop.Show();
                mainShop.BringToFront();
            }
        }
    }
}
