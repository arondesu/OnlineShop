namespace OnlineShop
{
    partial class AdminDashboardForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            panel1 = new Panel();
            panel6 = new Panel();
            dailyRevenue = new TextBox();
            daily_revenue = new TextBox();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            revenue_txt = new TextBox();
            stonks_txt = new TextBox();
            revenue_icon = new PictureBox();
            panel4 = new Panel();
            totalOrder_txt = new TextBox();
            totalOrders = new TextBox();
            totalOrder = new PictureBox();
            panel3 = new Panel();
            stocks_txt = new TextBox();
            ItemsInStock = new TextBox();
            InventoryIcon = new PictureBox();
            panel2 = new Panel();
            GraphPnl = new Panel();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)revenue_icon).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)totalOrder).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InventoryIcon).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(21, 29);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1002, 240);
            panel1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Chocolate;
            panel6.Controls.Add(dailyRevenue);
            panel6.Controls.Add(daily_revenue);
            panel6.Controls.Add(pictureBox1);
            panel6.Location = new Point(767, 33);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(214, 172);
            panel6.TabIndex = 4;
            // 
            // dailyRevenue
            // 
            dailyRevenue.BackColor = Color.Chocolate;
            dailyRevenue.BorderStyle = BorderStyle.None;
            dailyRevenue.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dailyRevenue.Location = new Point(42, 75);
            dailyRevenue.Margin = new Padding(3, 4, 3, 4);
            dailyRevenue.Name = "dailyRevenue";
            dailyRevenue.Size = new Size(127, 22);
            dailyRevenue.TabIndex = 15;
            dailyRevenue.Text = "Daily Revenue";
            dailyRevenue.TextAlign = HorizontalAlignment.Center;
            // 
            // daily_revenue
            // 
            daily_revenue.BackColor = Color.Chocolate;
            daily_revenue.BorderStyle = BorderStyle.None;
            daily_revenue.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            daily_revenue.Location = new Point(3, 15);
            daily_revenue.Margin = new Padding(3, 4, 3, 4);
            daily_revenue.Name = "daily_revenue";
            daily_revenue.Size = new Size(207, 49);
            daily_revenue.TabIndex = 15;
            daily_revenue.Text = "DAILY";
            daily_revenue.TextAlign = HorizontalAlignment.Center;
            daily_revenue.TextChanged += Daily_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(80, 105);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 67);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Chocolate;
            panel5.Controls.Add(revenue_txt);
            panel5.Controls.Add(stonks_txt);
            panel5.Controls.Add(revenue_icon);
            panel5.Location = new Point(518, 33);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(214, 172);
            panel5.TabIndex = 3;
            panel5.Paint += panel5_Paint;
            // 
            // revenue_txt
            // 
            revenue_txt.BackColor = Color.Chocolate;
            revenue_txt.BorderStyle = BorderStyle.None;
            revenue_txt.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            revenue_txt.Location = new Point(58, 75);
            revenue_txt.Margin = new Padding(3, 4, 3, 4);
            revenue_txt.Name = "revenue_txt";
            revenue_txt.Size = new Size(97, 22);
            revenue_txt.TabIndex = 14;
            revenue_txt.Text = "Total Revenue";
            revenue_txt.TextAlign = HorizontalAlignment.Center;
            // 
            // stonks_txt
            // 
            stonks_txt.BackColor = Color.Chocolate;
            stonks_txt.BorderStyle = BorderStyle.None;
            stonks_txt.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stonks_txt.Location = new Point(3, 15);
            stonks_txt.Margin = new Padding(3, 4, 3, 4);
            stonks_txt.Name = "stonks_txt";
            stonks_txt.Size = new Size(207, 49);
            stonks_txt.TabIndex = 14;
            stonks_txt.Text = "MONEY";
            stonks_txt.TextAlign = HorizontalAlignment.Center;
            stonks_txt.TextChanged += stonks_txt_TextChanged;
            // 
            // revenue_icon
            // 
            revenue_icon.Image = (Image)resources.GetObject("revenue_icon.Image");
            revenue_icon.Location = new Point(74, 105);
            revenue_icon.Margin = new Padding(3, 4, 3, 4);
            revenue_icon.Name = "revenue_icon";
            revenue_icon.Size = new Size(59, 67);
            revenue_icon.SizeMode = PictureBoxSizeMode.StretchImage;
            revenue_icon.TabIndex = 0;
            revenue_icon.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Chocolate;
            panel4.Controls.Add(totalOrder_txt);
            panel4.Controls.Add(totalOrders);
            panel4.Controls.Add(totalOrder);
            panel4.Location = new Point(272, 33);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(214, 172);
            panel4.TabIndex = 2;
            // 
            // totalOrder_txt
            // 
            totalOrder_txt.BackColor = Color.Chocolate;
            totalOrder_txt.BorderStyle = BorderStyle.None;
            totalOrder_txt.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            totalOrder_txt.Location = new Point(62, 75);
            totalOrder_txt.Margin = new Padding(3, 4, 3, 4);
            totalOrder_txt.Name = "totalOrder_txt";
            totalOrder_txt.Size = new Size(97, 22);
            totalOrder_txt.TabIndex = 13;
            totalOrder_txt.Text = "Total Orders";
            totalOrder_txt.TextAlign = HorizontalAlignment.Center;
            // 
            // totalOrders
            // 
            totalOrders.BackColor = Color.Chocolate;
            totalOrders.BorderStyle = BorderStyle.None;
            totalOrders.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalOrders.Location = new Point(3, 15);
            totalOrders.Margin = new Padding(3, 4, 3, 4);
            totalOrders.Name = "totalOrders";
            totalOrders.Size = new Size(207, 49);
            totalOrders.TabIndex = 13;
            totalOrders.Text = "ORDERS";
            totalOrders.TextAlign = HorizontalAlignment.Center;
            totalOrders.TextChanged += totalOrders_TextChanged;
            // 
            // totalOrder
            // 
            totalOrder.Image = (Image)resources.GetObject("totalOrder.Image");
            totalOrder.Location = new Point(79, 109);
            totalOrder.Margin = new Padding(3, 4, 3, 4);
            totalOrder.Name = "totalOrder";
            totalOrder.Size = new Size(59, 63);
            totalOrder.SizeMode = PictureBoxSizeMode.StretchImage;
            totalOrder.TabIndex = 0;
            totalOrder.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Chocolate;
            panel3.Controls.Add(stocks_txt);
            panel3.Controls.Add(ItemsInStock);
            panel3.Controls.Add(InventoryIcon);
            panel3.Location = new Point(25, 33);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(214, 172);
            panel3.TabIndex = 1;
            // 
            // stocks_txt
            // 
            stocks_txt.BackColor = Color.Chocolate;
            stocks_txt.BorderStyle = BorderStyle.None;
            stocks_txt.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stocks_txt.Location = new Point(62, 75);
            stocks_txt.Margin = new Padding(3, 4, 3, 4);
            stocks_txt.Name = "stocks_txt";
            stocks_txt.Size = new Size(97, 22);
            stocks_txt.TabIndex = 12;
            stocks_txt.Text = "Items in Stock";
            stocks_txt.TextAlign = HorizontalAlignment.Center;
            stocks_txt.TextChanged += textBox1_TextChanged;
            // 
            // ItemsInStock
            // 
            ItemsInStock.BackColor = Color.Chocolate;
            ItemsInStock.BorderStyle = BorderStyle.None;
            ItemsInStock.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ItemsInStock.Location = new Point(3, 15);
            ItemsInStock.Margin = new Padding(3, 4, 3, 4);
            ItemsInStock.Name = "ItemsInStock";
            ItemsInStock.Size = new Size(207, 49);
            ItemsInStock.TabIndex = 11;
            ItemsInStock.Text = "STOCKS";
            ItemsInStock.TextAlign = HorizontalAlignment.Center;
            ItemsInStock.TextChanged += ItemsInStock_TextChanged;
            // 
            // InventoryIcon
            // 
            InventoryIcon.BackgroundImageLayout = ImageLayout.None;
            InventoryIcon.Image = (Image)resources.GetObject("InventoryIcon.Image");
            InventoryIcon.Location = new Point(80, 109);
            InventoryIcon.Name = "InventoryIcon";
            InventoryIcon.Size = new Size(59, 63);
            InventoryIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            InventoryIcon.TabIndex = 10;
            InventoryIcon.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(GraphPnl);
            panel2.Location = new Point(21, 295);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1002, 403);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // GraphPnl
            // 
            GraphPnl.BackColor = Color.DimGray;
            GraphPnl.Location = new Point(0, 0);
            GraphPnl.Margin = new Padding(3, 4, 3, 4);
            GraphPnl.Name = "GraphPnl";
            GraphPnl.Size = new Size(1002, 403);
            GraphPnl.TabIndex = 2;
            GraphPnl.Paint += GraphPnl_Paint;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 26, 43);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminDashboardForm";
            Size = new Size(1045, 720);
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)revenue_icon).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)totalOrder).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)InventoryIcon).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private PictureBox InventoryIcon;
        private TextBox ItemsInStock;
        private TextBox stocks_txt;
        private TextBox totalOrder_txt;
        private TextBox totalOrders;
        private PictureBox totalOrder;
        private PictureBox revenue_icon;
        private TextBox revenue_txt;
        private TextBox stonks_txt;
        private PictureBox pictureBox1;
        private TextBox dailyRevenue;
        private TextBox daily_revenue;
        private Panel panel2;
        private Panel GraphPnl;
    }
}
