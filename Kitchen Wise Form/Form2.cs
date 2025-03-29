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
    public partial class ShopForm : Form
    {
        private const double DiscountRateLow = 0.10;
        private const double DiscountRateMid = 0.15;
        private const double DiscountRateHigh = 0.20;

        private List<string> itemNames = new List<string>();
        private List<int> quantities = new List<int>();
        private List<double> prices = new List<double>();
        public ShopForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on startup
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredItem = txtItemName.Text.Trim();

            // Find the item index in the availableItems list (ignoring case sensitivity)
            int itemIndex = availableItems.FindIndex(item => item.Equals(enteredItem, StringComparison.OrdinalIgnoreCase));

            if (itemIndex == -1)  // If item is not found
            {
                MessageBox.Show("Item not found in the available menu. Please enter a valid item.",
                                "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate quantity (must be a positive integer)
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive integer for quantity.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the correct price from availablePrices
            double correctPrice = availablePrices[itemIndex];

            // Validate user-entered price
            if (!double.TryParse(txtPrice.Text, out double enteredPrice) || enteredPrice <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for price.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if entered price matches the correct price
            if (Math.Abs(enteredPrice - correctPrice) > 0.01)  // Allow small rounding differences
            {
                DialogResult result = MessageBox.Show($"The price you entered ({enteredPrice:C}) does not match the correct price ({correctPrice:C}).\n" +
                                                      "Do you want to continue with the correct price?",
                                                      "Price Mismatch Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return; // Stop execution if the user does not accept the correct price
                }
            }

            // Add item details to lists (storing the correct price)
            //itemNames.Add(availableItems[itemIndex]);
            //quantities.Add(quantity);
            //prices.Add(correctPrice);  // Use the correct price

            // Update Order Summary
            UpdateOrderSummary();

            // Clear input fields after adding item
            txtItemName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();

            // Move cursor to the first field for quick entry
            txtItemName.Focus();
        }



        private void UpdateOrderSummary()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateOrderSummary));
                return;
            }

            listBoxOrderSummary.Items.Clear();
            double subtotal = 0;

            // Ensure items are displayed in the same order as they were added
            for (int i = 0; i < itemNames.Count; i++)
            {
                double itemTotal = quantities[i] * prices[i];
                subtotal += itemTotal;
                listBoxOrderSummary.Items.Add($"{i + 1}. {itemNames[i]} - ({quantities[i]} x ₱{prices[i]:F2}) = ₱{itemTotal:F2}");
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




        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Item Name", typeof(string));
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void buttonCheckout_Click(object sender, EventArgs e)
        {
            if (itemNames.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show the total amount
            string totalAmount = lblTotal.Text.Split('₱')[1];
            DialogResult result = MessageBox.Show($"Your total amount is ₱{totalAmount}.\nWould you like to purchase more items?",
                                                  "Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Feel free to add more items!", "Continue Shopping", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thank you for your purchase! We hope to see you again soon.",
                                "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear all data for a fresh start
                itemNames.Clear();
                quantities.Clear();
                prices.Clear();
                UpdateOrderSummary();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void removeBt_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (listBoxOrderSummary.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to remove.", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected index
            int selectedIndex = listBoxOrderSummary.SelectedIndex;

            // Remove the item from all lists
            itemNames.RemoveAt(selectedIndex);
            quantities.RemoveAt(selectedIndex);
            prices.RemoveAt(selectedIndex);

            // Update the Order Summary
            UpdateOrderSummary();
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


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if MainForm is already open
            Main mainForm = Application.OpenForms.OfType<Main>().FirstOrDefault();

            if (mainForm == null)
            {
                mainForm = new Main();
                mainForm.Show();
            }
            else
            {
                mainForm.WindowState = FormWindowState.Normal;
                mainForm.Show();
                mainForm.BringToFront();
            }

            this.Hide();  // Hide the current form
        }



        private void itemNo_Click(object sender, EventArgs e)
        {

        }
        private void clrBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) &&
                string.IsNullOrWhiteSpace(txtQuantity.Text) &&
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("There is nothing to clear!", "Clear Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // If at least one field is not empty, clear all
            txtItemName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
