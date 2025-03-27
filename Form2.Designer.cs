namespace OnlineShop
{
    partial class ShopForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopForm));
            label2 = new Label();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            txtItemName = new TextBox();
            price = new Label();
            itemName = new Label();
            itemNo = new Label();
            btnAdd = new Button();
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            shopToolStripMenuItem = new ToolStripMenuItem();
            dealsToolStripMenuItem = new ToolStripMenuItem();
            clrBtn = new Button();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            lblTotal = new Label();
            lblDiscount = new Label();
            summary = new Label();
            lblSubtotal = new Label();
            buttonCheckout = new Button();
            listBoxOrderSummary = new ListBox();
            removeBt = new Button();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Malgun Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(183, 141);
            label2.Name = "label2";
            label2.Size = new Size(252, 46);
            label2.TabIndex = 12;
            label2.Text = "Shopping Cart";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(190, 372);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(245, 27);
            txtPrice.TabIndex = 18;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(190, 305);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(245, 27);
            txtQuantity.TabIndex = 17;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(190, 241);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(245, 27);
            txtItemName.TabIndex = 16;
            // 
            // price
            // 
            price.AutoSize = true;
            price.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            price.ForeColor = Color.White;
            price.Location = new Point(42, 375);
            price.Name = "price";
            price.Size = new Size(103, 24);
            price.TabIndex = 15;
            price.Text = "Item Price:";
            // 
            // itemName
            // 
            itemName.AutoSize = true;
            itemName.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            itemName.ForeColor = Color.White;
            itemName.Location = new Point(42, 244);
            itemName.Name = "itemName";
            itemName.Size = new Size(112, 24);
            itemName.TabIndex = 14;
            itemName.Text = "Item Name:";
            // 
            // itemNo
            // 
            itemNo.AutoSize = true;
            itemNo.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            itemNo.ForeColor = Color.White;
            itemNo.Location = new Point(42, 305);
            itemNo.Name = "itemNo";
            itemNo.Size = new Size(140, 24);
            itemNo.TabIndex = 13;
            itemNo.Text = "No. of Item/s: ";
            itemNo.Click += itemNo_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(189, 196, 212);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(15, 26, 43);
            btnAdd.Location = new Point(325, 428);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 35);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, shopToolStripMenuItem, dealsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1022, 28);
            menuStrip1.TabIndex = 25;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(64, 24);
            homeToolStripMenuItem.Text = "Home";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            // 
            // shopToolStripMenuItem
            // 
            shopToolStripMenuItem.Name = "shopToolStripMenuItem";
            shopToolStripMenuItem.Size = new Size(57, 24);
            shopToolStripMenuItem.Text = "Shop";
            shopToolStripMenuItem.Click += shopToolStripMenuItem_Click;
            // 
            // dealsToolStripMenuItem
            // 
            dealsToolStripMenuItem.Name = "dealsToolStripMenuItem";
            dealsToolStripMenuItem.Size = new Size(60, 24);
            dealsToolStripMenuItem.Text = "Deals";
            dealsToolStripMenuItem.Click += dealsToolStripMenuItem_Click;
            // 
            // clrBtn
            // 
            clrBtn.BackColor = Color.FromArgb(209, 207, 201);
            clrBtn.Cursor = Cursors.Hand;
            clrBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clrBtn.ForeColor = Color.Black;
            clrBtn.Location = new Point(190, 428);
            clrBtn.Name = "clrBtn";
            clrBtn.Size = new Size(113, 35);
            clrBtn.TabIndex = 26;
            clrBtn.Text = "CLEAR";
            clrBtn.UseVisualStyleBackColor = false;
            clrBtn.Click += clrBtn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(15, 26, 43);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(clrBtn);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(itemNo);
            panel2.Controls.Add(itemName);
            panel2.Controls.Add(price);
            panel2.Controls.Add(txtPrice);
            panel2.Controls.Add(txtItemName);
            panel2.Controls.Add(txtQuantity);
            panel2.Location = new Point(0, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(492, 667);
            panel2.TabIndex = 27;
            panel2.Paint += panel2_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(26, 95);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(151, 146);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 32;
            pictureBox2.TabStop = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(15, 26, 43);
            lblTotal.Location = new Point(74, 504);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(76, 22);
            lblTotal.TabIndex = 20;
            lblTotal.Text = "TOTAL :";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiscount.ForeColor = Color.FromArgb(15, 26, 43);
            lblDiscount.Location = new Point(74, 462);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(113, 22);
            lblDiscount.TabIndex = 22;
            lblDiscount.Text = "DISCOUNT: ";
            // 
            // summary
            // 
            summary.AutoSize = true;
            summary.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            summary.ForeColor = Color.FromArgb(15, 26, 43);
            summary.Location = new Point(123, 68);
            summary.Name = "summary";
            summary.Size = new Size(297, 41);
            summary.TabIndex = 21;
            summary.Text = "ORDER SUMMARY ";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotal.ForeColor = Color.FromArgb(15, 26, 43);
            lblSubtotal.Location = new Point(74, 414);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(110, 22);
            lblSubtotal.TabIndex = 23;
            lblSubtotal.Text = "SUBTOTAL :";
            // 
            // buttonCheckout
            // 
            buttonCheckout.BackColor = Color.FromArgb(28, 46, 74);
            buttonCheckout.Cursor = Cursors.Hand;
            buttonCheckout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCheckout.ForeColor = SystemColors.ButtonHighlight;
            buttonCheckout.Location = new Point(156, 586);
            buttonCheckout.Name = "buttonCheckout";
            buttonCheckout.Size = new Size(264, 53);
            buttonCheckout.TabIndex = 19;
            buttonCheckout.Text = "CHECKOUT";
            buttonCheckout.UseVisualStyleBackColor = false;
            buttonCheckout.Click += buttonCheckout_Click;
            // 
            // listBoxOrderSummary
            // 
            listBoxOrderSummary.FormattingEnabled = true;
            listBoxOrderSummary.Location = new Point(74, 155);
            listBoxOrderSummary.Name = "listBoxOrderSummary";
            listBoxOrderSummary.Size = new Size(394, 164);
            listBoxOrderSummary.TabIndex = 24;
            // 
            // removeBt
            // 
            removeBt.BackColor = Color.Maroon;
            removeBt.Cursor = Cursors.Hand;
            removeBt.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            removeBt.ForeColor = Color.White;
            removeBt.Location = new Point(318, 338);
            removeBt.Name = "removeBt";
            removeBt.Size = new Size(150, 38);
            removeBt.TabIndex = 25;
            removeBt.Text = "REMOVE";
            removeBt.UseVisualStyleBackColor = false;
            removeBt.Click += removeBt_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(removeBt);
            panel1.Controls.Add(listBoxOrderSummary);
            panel1.Controls.Add(buttonCheckout);
            panel1.Controls.Add(lblSubtotal);
            panel1.Controls.Add(summary);
            panel1.Controls.Add(lblDiscount);
            panel1.Controls.Add(lblTotal);
            panel1.Location = new Point(489, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(533, 667);
            panel1.TabIndex = 24;
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 694);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ShopForm";
            Text = "KitchenWise";
            Load += ShopForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtItemName;
        private Label price;
        private Label itemName;
        private Label itemNo;
        private Button btnAdd;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem shopToolStripMenuItem;
        private ToolStripMenuItem dealsToolStripMenuItem;
        private Button clrBtn;
        private Panel panel2;
        private Label lblTotal;
        private Label lblDiscount;
        private Label summary;
        private Label lblSubtotal;
        private Button buttonCheckout;
        private ListBox listBoxOrderSummary;
        private Button removeBt;
        private Panel panel1;
        private PictureBox pictureBox2;
    }
}