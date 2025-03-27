namespace OnlineShop
{
    partial class DealsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DealsForm));
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            shopToolStripMenuItem = new ToolStripMenuItem();
            dealsToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            itemName = new Label();
            label1 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            Deals = new Label();
            panel3 = new Panel();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, shopToolStripMenuItem, dealsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(878, 28);
            menuStrip1.TabIndex = 26;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Malgun Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(71, 106);
            label2.Name = "label2";
            label2.Size = new Size(0, 38);
            label2.TabIndex = 27;
            label2.Click += label2_Click;
            // 
            // itemName
            // 
            itemName.AutoSize = true;
            itemName.Font = new Font("Segoe UI Emoji", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            itemName.ForeColor = Color.FromArgb(15, 26, 43);
            itemName.Location = new Point(44, 58);
            itemName.Name = "itemName";
            itemName.Size = new Size(476, 33);
            itemName.TabIndex = 27;
            itemName.Text = "Orders over ₱100 ------------- 10% off";
            itemName.Click += itemName_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(15, 26, 43);
            label1.Location = new Point(44, 144);
            label1.Name = "label1";
            label1.Size = new Size(476, 33);
            label1.TabIndex = 28;
            label1.Text = "Orders over ₱200 ------------- 15% off";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(15, 26, 43);
            label3.Location = new Point(44, 228);
            label3.Name = "label3";
            label3.Size = new Size(476, 33);
            label3.TabIndex = 29;
            label3.Text = "Orders over ₱500 ------------- 20% off";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(itemName);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(161, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(578, 333);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 196, 212);
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(0, 166);
            panel2.Name = "panel2";
            panel2.Size = new Size(880, 458);
            panel2.TabIndex = 27;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(34, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(92, 83);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 31;
            pictureBox2.TabStop = false;
            // 
            // Deals
            // 
            Deals.AutoSize = true;
            Deals.Font = new Font("Malgun Gothic", 19.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Deals.ForeColor = Color.White;
            Deals.Location = new Point(161, 41);
            Deals.Name = "Deals";
            Deals.Size = new Size(607, 45);
            Deals.TabIndex = 13;
            Deals.Text = "Exclusive Discounts on Your Purchase!";
            Deals.Click += Deals_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(15, 26, 43);
            panel3.Controls.Add(Deals);
            panel3.Controls.Add(pictureBox2);
            panel3.Location = new Point(0, 31);
            panel3.Name = "panel3";
            panel3.Size = new Size(880, 135);
            panel3.TabIndex = 28;
            // 
            // DealsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 624);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DealsForm";
            Text = " KitchenWise";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem shopToolStripMenuItem;
        private ToolStripMenuItem dealsToolStripMenuItem;
        private Label label2;
        private Label itemName;
        private Label label1;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label Deals;
        private Panel panel3;
    }
}