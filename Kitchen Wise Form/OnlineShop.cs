using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using OnlineShop.Kitchen_Wise_Form;
using System.IO;
using OnlineShop.DATABASE;

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
        private DBConn dbConn = new DBConn();

        public MainShop()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on startup
            SetupScrollablePanel(); // Call method to set up the scrollable panel

            //Initialize the dictionary first
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

            // Create a dictionary to store the buttons
            Dictionary<string, Button> addButtons = new Dictionary<string, Button>
            {
                {"Glass Food Storage", button1},
                {"Steel Mug Rack", button2},
                {"Mitts Potholders", button3},
                {"Steel Brazier Pot", button4},
                {"Descascador", button5},
                {"Cleaning Sponge", button6},
                {"Silverware Set", button7},
                {"Kitchen Scale", button8},
                {"Table Cloth", button9}
            };
            foreach (var button in addButtons.Values)
            {
                button.ForeColor = Color.White;
            }

            //THEN sync and update button states
            dbFunc.SyncQuantityLabelsAndButtons(quantityLabels, addButtons);
            
            // Now load dynamic products AFTER initializing quantityLabels
            LoadDynamicProducts();

            // Subscribe to AddProductForm events
            var addProductForm = Application.OpenForms.OfType<Form>()
                .SelectMany(f => f.Controls.OfType<AddProductForm>())
                .FirstOrDefault();
            
            if (addProductForm != null)
            {
                addProductForm.ProductAdded += OnInventoryChanged;
                addProductForm.ProductUpdated += OnInventoryChanged;
                addProductForm.ProductDeleted += OnInventoryChanged;
            }
        }

        // Replace the conflicting OnProductChanged with this simpler event handler
        private void OnInventoryChanged(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, Button> addButtons = new Dictionary<string, Button>
                {
                    {"Glass Food Storage", button1},
                    {"Steel Mug Rack", button2},
                    {"Mitts Potholders", button3},
                    {"Steel Brazier Pot", button4},
                    {"Descascador", button5},
                    {"Cleaning Sponge", button6},
                    {"Silverware Set", button7},
                    {"Kitchen Scale", button8},
                    {"Table Cloth", button9}
                };
        
                dbFunc.SyncQuantityLabelsAndButtons(quantityLabels, addButtons);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating display: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button7_Click(object sender, EventArgs e)
        {
            AddItemToCart("Silverware Set", 175.50);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddItemToCart("Kitchen Scale", 499);
        }

        private void button9_Click(object sender, EventArgs e)
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
            DialogResult result = MessageBox.Show($"Your total amount is ₱{totalAmount}.\nAre you sure you want to proceed to checkout?",
                                        "Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
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
                                "Order Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void inv_btn_Click(object sender, EventArgs e)
        {
            KitchenWiseAdmin adminForm = new KitchenWiseAdmin();
            adminForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Add this new method to load products dynamically from the database
        private void LoadDynamicProducts()
        {
            try
            {
                // Create a flow layout panel for dynamic products
                FlowLayoutPanel productPanel = new FlowLayoutPanel
                {
                    Width = 800,
                    Height = 300,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true,
                    Padding = new Padding(10),
                    Location = new Point(50, 450), // Position below existing content
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Get data from the items table
                DataTable dt = GetItemsForShop();
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    Label titleLabel = new Label
                    {
                        Text = "New Products",
                        Font = new Font("Segoe UI", 14, FontStyle.Bold),
                        ForeColor = Color.FromArgb(15, 26, 43),
                        Location = new Point(50, 420),
                        AutoSize = true
                    };
                    this.Controls.Add(titleLabel);

                    // Create a product card for each item
                    foreach (DataRow row in dt.Rows)
                    {
                        // Inside LoadDynamicProducts method
                        // Skip items that are already in the fixed product list
                        string itemName = row["item_name"].ToString();
                        if (quantityLabels != null && quantityLabels.ContainsKey(itemName))
                            continue;

                        // Create a panel for each product
                        Panel productCard = new Panel
                        {
                            Width = 180,
                            Height = 250,
                            Margin = new Padding(10),
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        
                        // Add product image
                        PictureBox productImage = new PictureBox
                        {
                            Width = 160,
                            Height = 120,
                            Top = 10,
                            Left = 10,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        
                        // Try to load the image if available
                        string imagePath = row["item_image"]?.ToString();
                        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        {
                            try
                            {
                                productImage.Image = Image.FromFile(imagePath);
                            }
                            catch
                            {
                                // Use a default image if the file can't be loaded
                                productImage.Image = null;
                            }
                        }
                        
                        // Add product details
                        Label nameLabel = new Label
                        {
                            Text = itemName,
                            Top = 140,
                            Left = 10,
                            Width = 160,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        
                        Label typeLabel = new Label
                        {
                            Text = row["item_type"].ToString(),
                            Top = 165,
                            Left = 10,
                            Width = 160,
                            Font = new Font("Segoe UI", 8),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        
                        Label priceLabel = new Label
                        {
                            Text = $"₱{Convert.ToDecimal(row["item_price"]):N2}",
                            Top = 190,
                            Left = 10,
                            Width = 160,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            TextAlign = ContentAlignment.MiddleCenter,
                            ForeColor = Color.FromArgb(15, 26, 43)
                        };
                        
                        Button addToCartButton = new Button
                        {
                            Text = "Add to Cart",
                            Top = 215,
                            Left = 40,
                            Width = 100,
                            Height = 25,
                            BackColor = Color.FromArgb(189, 196, 212),
                            ForeColor = Color.FromArgb(15, 26, 43),
                            FlatStyle = FlatStyle.Flat
                        };
                        
                        // Store the product info in the button's Tag property
                        addToCartButton.Tag = new object[] { itemName, Convert.ToDouble(row["item_price"]) };
                        addToCartButton.Click += DynamicAddToCart_Click;
                        
                        // Add controls to the product card
                        productCard.Controls.Add(productImage);
                        productCard.Controls.Add(nameLabel);
                        productCard.Controls.Add(typeLabel);
                        productCard.Controls.Add(priceLabel);
                        productCard.Controls.Add(addToCartButton);
                        
                        // Add the product card to the flow layout panel
                        productPanel.Controls.Add(productCard);
                    }
                    
                    // Only add the panel if it has products
                    if (productPanel.Controls.Count > 0)
                    {
                        this.Controls.Add(productPanel);
                    }
                    else
                    {
                        titleLabel.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dynamic products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DynamicAddToCart_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            object[] productInfo = btn.Tag as object[];
            string itemName = (string)productInfo[0];
            double itemPrice = (double)productInfo[1];
            
            // Use the existing AddItemToCart method
            AddItemToCart(itemName, itemPrice);
        }

        private DataTable GetItemsForShop()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT i.id, i.item_id, i.item_name, i.Description, 
                                   i.item_type, i.item_stock, i.item_price, i.item_image 
                                   FROM items i
                                   WHERE i.date_delete IS NULL AND i.item_stock > 0
                                   ORDER BY i.date_update DESC";
                    
                    using SqlCommand cmd = new SqlCommand(query, conn);
                    using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting items for shop: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}

