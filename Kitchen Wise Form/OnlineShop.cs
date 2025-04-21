using System.Diagnostics;
using Microsoft.Data.SqlClient;
using OnlineShop.Kitchen_Wise_Form;

//testing the changes 5:32 PM

namespace OnlineShop
{
    public partial class MainShop : Form
    {
        private const double DiscountRateLow = 0.10;
        private const double DiscountRateMid = 0.15;
        private const double DiscountRateHigh = 0.20;

        private List<string> itemNames = new List<string>();
        private List<int> quantities = new List<int>();
        private List<double> prices = new List<double>();

        private Dictionary<string, Label> quantityLabels;
        private DBFunc dbFunc = new DBFunc();

        public MainShop()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on startup
            SetupScrollablePanel(); // Call method to set up the scrollable panel

            // Initialize the dictionary with your labels
            quantityLabels = new Dictionary<string, Label>
            {
                {"Glass Food Storage", gfoodstore_qty},
                {"Steel Mug Rack", smugrack_qty},
                {"Mitts Potholders", mpothold_qty},
                {"Steel Brazier Pot", sbrazier_qty},
                {"Descascador", descascador_qty},
                {"Cleaning Sponge", cspong_qty},
                {"Silverware Set", sware_qty},
                {"Kitchen Scale", kscale_qty},
                {"Table Cloth", tcloth_qty}
            };

            // Sync the labels with inventory
            dbFunc.SyncQuantityLabels(quantityLabels);
        }

        private List<string> availableItems = new List<string>
            {
                    "Glass Food Storage",
                    "Steel Mug Rack",
                    "Mitts Potholders",
                    "Steel Brazier Pot",
                    "Descascador",
                    "Cleaning Sponge",
                    "Silverware Set",
                    "Kitchen Scale",
                    "Table Cloth",
                    "glass food storage",
                    "steel mug rack",
                    "mitts potholders",
                    "steel brazier pot",
                    "descascador",
                    "cleaning sponge",
                    "silverware set",
                    "kitchen scale",
                    "table cloth"
            };
        private List<double> availablePrices = new List<double>
            {
                    275,
                    50.45,
                    65,
                    150.50,
                    79,
                    35.50,
                    175.50,
                    499,
                    55.50
            };
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

        private void AddItemToCart(string itemName, double itemPrice)
        {
            string quantityInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter quantity for {itemName}:", "Quantity Input", "1");
            if (!int.TryParse(quantityInput, out int quantity) || quantity <= 0)
            {
                return;
            }

            AddToCart(itemName, quantity, itemPrice);
        }

        public void AddToCart(string itemName, int quantity, double itemPrice)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddToCart(itemName, quantity, itemPrice)));
                return;
            }

            // Check if the item already exists in the list
            int index = itemNames.IndexOf(itemName);
            if (index != -1)
            {
                // If the item exists, update the quantity
                quantities[index] += quantity;
            }
            else
            {
                // If the item is new, add it in order
                itemNames.Add(itemName);
                quantities.Add(quantity);
                prices.Add(itemPrice);
            }

            // Refresh the order summary
            UpdateOrderSummary();
        }

        private void UpdateOrderSummary()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateOrderSummary));
                return;
            }

            lstboxOrderList.Items.Clear();
            double subtotal = 0;

            // Ensure items are displayed in the same order as they were added
            for (int i = 0; i < itemNames.Count; i++)
            {
                double itemTotal = quantities[i] * prices[i];
                subtotal += itemTotal;
                lstboxOrderList.Items.Add($"{i + 1}. {itemNames[i]} - ({quantities[i]} x ₱{prices[i]:F2}) = ₱{itemTotal:F2}");
            }

            // Apply discount logic
            double discount = 0;
            if (subtotal > 500) discount = subtotal * DiscountRateHigh;
            else if (subtotal > 200) discount = subtotal * DiscountRateMid;
            else if (subtotal > 100) discount = subtotal * DiscountRateLow;

            double total = subtotal - discount;

            // Update labels
            lblSubtotal.Text = $"Subtotal: ₱{subtotal:F2}";
            lblDiscount.Text = $"Discount: ₱{discount:F2}";
            lblTotal.Text = $"Total: ₱{total:F2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddItemToCart("Glass Food Storage", 275.00);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddItemToCart("Steel Mug Rack", 50.45);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddItemToCart("Mitts Potholders", 65);
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

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (lstboxOrderList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to decrease the quantity.", "Decrease Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected index
            int selectedIndex = lstboxOrderList.SelectedIndex;

            // Decrease the quantity of the selected item
            if (quantities[selectedIndex] > 1)
            {
                quantities[selectedIndex]--;
                MessageBox.Show("Item succesfully decreased.", "Quantity Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If the quantity is 1, remove the item from the cart
                itemNames.RemoveAt(selectedIndex);
                quantities.RemoveAt(selectedIndex);
                prices.RemoveAt(selectedIndex);
                MessageBox.Show("Item succesfully removed.", "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            // Update the Order Summary
            UpdateOrderSummary();
        }

        private void buttonCheckout_Click(object sender, EventArgs e)
        {
            if (itemNames.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show the total amount and ask if they want to add more items
            string totalAmount = lblTotal.Text.Split('₱')[1];
            DialogResult result = MessageBox.Show($"Your total amount is ₱{totalAmount}.\nWould you like to add more items?",
                                        "Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Continue shopping! Add more items to your cart.",
                               "Continue Shopping", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Parse the amounts from labels
                decimal subtotal = decimal.Parse(lblSubtotal.Text.Split('₱')[1]);
                decimal discount = decimal.Parse(lblDiscount.Text.Split('₱')[1]);
                decimal total = decimal.Parse(lblTotal.Text.Split('₱')[1]);

                // Process the checkout
                dbFunc.ProcessCheckout(subtotal, discount, total, itemNames, quantities);

                MessageBox.Show("Thank you for your purchase! We hope to see you again soon.",
                                "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear all data for a fresh start
                itemNames.Clear();
                quantities.Clear();
                prices.Clear();

                UpdateOrderSummary();
                RefreshQuantities(); // Refresh the quantity labels
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during checkout: {ex.Message}", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeBt_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (lstboxOrderList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to remove.", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected index
            int selectedIndex = lstboxOrderList.SelectedIndex;

            // Remove the item from all lists
            itemNames.RemoveAt(selectedIndex);
            quantities.RemoveAt(selectedIndex);
            prices.RemoveAt(selectedIndex);

            MessageBox.Show("Item succesfully removed.", "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Update the Order Summary
            UpdateOrderSummary();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (lstboxOrderList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to increase the quantity.", "Increase Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected index
            int selectedIndex = lstboxOrderList.SelectedIndex;

            // Increase the quantity of the selected item
            quantities[selectedIndex]++;

            MessageBox.Show("Item succesfully increased.", "Quantity Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Update the Order Summary
            UpdateOrderSummary();

        }

        private void RefreshQuantities()
        {
            dbFunc.SyncQuantityLabels(quantityLabels);
        }

        private void inv_btn_Click(object sender, EventArgs e)
        {
            KitchenWiseAdmin adminForm = new KitchenWiseAdmin();
            adminForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
