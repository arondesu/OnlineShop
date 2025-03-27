using System.Diagnostics;

namespace OnlineShop
{
    public partial class Main : Form
    {
        private ShopForm shopForm; // Declare globally so it persists

        public Main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on startup
            SetupScrollablePanel(); // Call method to set up the scrollable panel
        }
        private void SetupScrollablePanel()
        {
            // Create a panel that enables only vertical scrolling
            Panel scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,  // Make it fill the form
                AutoScroll = true,      // Enable scrolling
                HorizontalScroll = { Enabled = false, Visible = false }, // Disable horizontal scroll
                VerticalScroll = { Enabled = true, Visible = true }      // Enable vertical scroll
            };

            // Ensure that only vertical scrolling is active
            scrollablePanel.AutoScrollMinSize = new Size(0, scrollablePanel.Height + 1);

            // Move all existing controls into the panel
            while (this.Controls.Count > 0)
            {
                Control ctrl = this.Controls[0];
                this.Controls.Remove(ctrl);
                scrollablePanel.Controls.Add(ctrl);
            }

            // Add the scrollable panel to the form
            this.Controls.Add(scrollablePanel);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

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


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dealsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if DealsForm is already open
            DealsForm dealsForm = Application.OpenForms.OfType<DealsForm>().FirstOrDefault();

            if (dealsForm == null)
            {
                dealsForm = new DealsForm();
                dealsForm.Show();
            }
            else
            {
                dealsForm.WindowState = FormWindowState.Normal;
                dealsForm.Show();
                dealsForm.BringToFront();
            }

            this.Hide();  // Hide the current form
        }


        private void label1_Click_2(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void AddItemToCart(string itemName, double itemPrice)
        {
            string quantityInput = Microsoft.VisualBasic.Interaction.InputBox(
                $"Enter quantity for {itemName}:", "Quantity Input", "1");

            if (!int.TryParse(quantityInput, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Invalid quantity. Please enter a positive number.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure ShopForm is open and reuse it
            if (shopForm == null || shopForm.IsDisposed)
            {
                this.Hide();  // Hide the current form
                shopForm = new ShopForm();
                shopForm.Show();
            }
            else
            {
                shopForm.WindowState = FormWindowState.Normal; // Restore if minimized
                shopForm.BringToFront(); // Bring it to the front
                shopForm.Show();
            }

            // Send the item to the cart in ShopForm
            shopForm.AddToCart(itemName, quantity, itemPrice);
            this.Hide();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            AddItemToCart("Glass Food Storage", 275);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddItemToCart("Steel Mug Rack", 50.45);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddItemToCart("Mitts Potholders", 65);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddItemToCart("Steel Brazier Pot", 150.50);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddItemToCart("Descascador", 79);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddItemToCart("Cleaning Sponge", 35.50);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddItemToCart("Silverware Set", 175.50);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddItemToCart("Kitchen Scale", 499);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddItemToCart("Table Cloth", 55.50);
        }
    }
}
