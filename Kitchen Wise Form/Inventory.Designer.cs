using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OnlineShop.Kitchen_Wise_Form  // Updated namespace to match
{
    partial class InventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Remove the duplicate Dispose method definition.  
        // The `Dispose` method is already defined in the `InventoryForm` class, so the duplicate definition is unnecessary.  
        // Retain only one definition of the `Dispose` method.  

        // Removed the duplicate Dispose method definition to resolve CS0111 error.  
        // The `Dispose` method is already defined in the `InventoryForm` class, so the duplicate definition is unnecessary.  

        // The following duplicate Dispose method has been removed:  
        // protected override void Dispose(bool disposing)  
        // {  
        //     if (disposing && (components != null))  
        //     {  
        //         components.Dispose();  
        //     }  
        //     base.Dispose(disposing);  
        // }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(InventoryForm));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            homePanel = new Panel();
            inv_bg_pic = new PictureBox();
            homeDataGrid = new DataGridView();
            salesDataGrid = new DataGridView();
            dBFuncBindingSource = new BindingSource(components);
            itemdatagrid = new DataGridView();
            panel4 = new Panel();
            updBtn = new Button();
            insrtBtn = new Button();
            label6 = new Label();
            dlBtn = new Button();
            StckTxtbx = new TextBox();
            Pricelbl = new Label();
            PrcTxtbx = new TextBox();
            Description = new Label();
            DescTxtbx = new TextBox();
            PrdctNameTxtbx = new TextBox();
            PrdctName = new Label();
            PrdctIdTxtbx = new TextBox();
            prdctId = new Label();
            panel3 = new Panel();
            bck_btn = new Button();
            salesBtn = new Button();
            home_btn = new Button();
            button4 = new Button();
            item_btn = new Button();
            invBtn = new Button();
            panel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            homePanel.SuspendLayout();
            ((ISupportInitialize)inv_bg_pic).BeginInit();
            ((ISupportInitialize)homeDataGrid).BeginInit();
            ((ISupportInitialize)salesDataGrid).BeginInit();
            ((ISupportInitialize)dBFuncBindingSource).BeginInit();
            ((ISupportInitialize)itemdatagrid).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(15, 26, 43);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1397, 83);
            panel1.TabIndex = 27;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(461, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(299, 36);
            label1.TabIndex = 2;
            label1.Text = "KitchenWise Inventory";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            pictureBox1.Location = new Point(75, 22);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(homePanel);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(206, 83);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1191, 556);
            panel2.TabIndex = 28;
            // 
            // homePanel
            // 
            homePanel.BackColor = Color.FromArgb(209, 207, 201);
            homePanel.Controls.Add(inv_bg_pic);
            homePanel.Controls.Add(homeDataGrid);
            homePanel.Controls.Add(salesDataGrid);
            homePanel.Controls.Add(itemdatagrid);
            homePanel.Controls.Add(panel4);
            homePanel.Location = new Point(1, 2);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1305, 569);
            homePanel.TabIndex = 0;
            // 
            // inv_bg_pic
            // 
            inv_bg_pic.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            inv_bg_pic.Location = new Point(360, 198);
            inv_bg_pic.Margin = new Padding(3, 2, 3, 2);
            inv_bg_pic.Name = "inv_bg_pic";
            inv_bg_pic.Size = new Size(132, 132);
            inv_bg_pic.TabIndex = 3;
            inv_bg_pic.TabStop = false;
            inv_bg_pic.Click += inv_bg_pic_Click;
            // 
            // homeDataGrid
            // 
            homeDataGrid.BackgroundColor = Color.FromArgb(209, 207, 201);
            homeDataGrid.BorderStyle = BorderStyle.None;
            homeDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            homeDataGrid.Location = new Point(0, -2);
            homeDataGrid.Name = "homeDataGrid";
            homeDataGrid.RowHeadersWidth = 51;
            homeDataGrid.Size = new Size(900, 553);
            homeDataGrid.TabIndex = 0;
            homeDataGrid.CellContentClick += homeDataGrid_CellContentClick;
            // 
            // salesDataGrid
            // 
            salesDataGrid.AutoGenerateColumns = false;
            salesDataGrid.BackgroundColor = Color.FromArgb(209, 207, 201);
            salesDataGrid.BorderStyle = BorderStyle.None;
            salesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            salesDataGrid.DataSource = dBFuncBindingSource;
            salesDataGrid.Location = new Point(-5, 0);
            salesDataGrid.Name = "salesDataGrid";
            salesDataGrid.RowHeadersWidth = 51;
            salesDataGrid.Size = new Size(905, 553);
            salesDataGrid.TabIndex = 1;
            // 
            // dBFuncBindingSource
            // 
            dBFuncBindingSource.DataSource = typeof(DBFunc);
            // 
            // itemdatagrid
            // 
            itemdatagrid.BackgroundColor = Color.FromArgb(209, 207, 201);
            itemdatagrid.BorderStyle = BorderStyle.None;
            itemdatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemdatagrid.Location = new Point(-5, 0);
            itemdatagrid.Name = "itemdatagrid";
            itemdatagrid.RowHeadersWidth = 51;
            itemdatagrid.Size = new Size(905, 553);
            itemdatagrid.TabIndex = 8;
            itemdatagrid.CellContentClick += itemdatagrid_CellContentClick;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gray;
            panel4.Controls.Add(updBtn);
            panel4.Controls.Add(insrtBtn);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(dlBtn);
            panel4.Controls.Add(StckTxtbx);
            panel4.Controls.Add(Pricelbl);
            panel4.Controls.Add(PrcTxtbx);
            panel4.Controls.Add(Description);
            panel4.Controls.Add(DescTxtbx);
            panel4.Controls.Add(PrdctNameTxtbx);
            panel4.Controls.Add(PrdctName);
            panel4.Controls.Add(PrdctIdTxtbx);
            panel4.Controls.Add(prdctId);
            panel4.Location = new Point(900, -2);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(290, 557);
            panel4.TabIndex = 0;
            // 
            // updBtn
            // 
            updBtn.Location = new Point(82, 427);
            updBtn.Margin = new Padding(3, 2, 3, 2);
            updBtn.Name = "updBtn";
            updBtn.Size = new Size(122, 26);
            updBtn.TabIndex = 6;
            updBtn.Text = "Update";
            updBtn.UseVisualStyleBackColor = true;
            updBtn.Click += button2_Click;
            // 
            // insrtBtn
            // 
            insrtBtn.Location = new Point(82, 376);
            insrtBtn.Margin = new Padding(3, 2, 3, 2);
            insrtBtn.Name = "insrtBtn";
            insrtBtn.Size = new Size(122, 26);
            insrtBtn.TabIndex = 7;
            insrtBtn.Text = "Insert";
            insrtBtn.UseVisualStyleBackColor = true;
            insrtBtn.Click += button3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(121, 228);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 17;
            label6.Text = "Stock:";
            // 
            // dlBtn
            // 
            dlBtn.Location = new Point(82, 324);
            dlBtn.Margin = new Padding(3, 2, 3, 2);
            dlBtn.Name = "dlBtn";
            dlBtn.Size = new Size(122, 26);
            dlBtn.TabIndex = 5;
            dlBtn.Text = "Delete";
            dlBtn.UseVisualStyleBackColor = true;
            dlBtn.Click += button1_Click;
            // 
            // StckTxtbx
            // 
            StckTxtbx.Location = new Point(47, 246);
            StckTxtbx.Margin = new Padding(3, 2, 3, 2);
            StckTxtbx.Name = "StckTxtbx";
            StckTxtbx.Size = new Size(196, 23);
            StckTxtbx.TabIndex = 11;
            // 
            // Pricelbl
            // 
            Pricelbl.AutoSize = true;
            Pricelbl.Location = new Point(122, 178);
            Pricelbl.Name = "Pricelbl";
            Pricelbl.Size = new Size(36, 15);
            Pricelbl.TabIndex = 16;
            Pricelbl.Text = "Price:";
            // 
            // PrcTxtbx
            // 
            PrcTxtbx.Location = new Point(47, 196);
            PrcTxtbx.Margin = new Padding(3, 2, 3, 2);
            PrcTxtbx.Name = "PrcTxtbx";
            PrcTxtbx.Size = new Size(196, 23);
            PrcTxtbx.TabIndex = 10;
            // 
            // Description
            // 
            Description.AutoSize = true;
            Description.Location = new Point(107, 128);
            Description.Name = "Description";
            Description.Size = new Size(70, 15);
            Description.TabIndex = 15;
            Description.Text = "Description:";
            Description.Click += Description_Click;
            // 
            // DescTxtbx
            // 
            DescTxtbx.Location = new Point(47, 146);
            DescTxtbx.Margin = new Padding(3, 2, 3, 2);
            DescTxtbx.Name = "DescTxtbx";
            DescTxtbx.Size = new Size(196, 23);
            DescTxtbx.TabIndex = 9;
            // 
            // PrdctNameTxtbx
            // 
            PrdctNameTxtbx.Location = new Point(47, 100);
            PrdctNameTxtbx.Margin = new Padding(3, 2, 3, 2);
            PrdctNameTxtbx.Name = "PrdctNameTxtbx";
            PrdctNameTxtbx.Size = new Size(196, 23);
            PrdctNameTxtbx.TabIndex = 8;
            // 
            // PrdctName
            // 
            PrdctName.AutoSize = true;
            PrdctName.Location = new Point(97, 80);
            PrdctName.Name = "PrdctName";
            PrdctName.Size = new Size(87, 15);
            PrdctName.TabIndex = 14;
            PrdctName.Text = "Product Name:";
            // 
            // PrdctIdTxtbx
            // 
            PrdctIdTxtbx.Location = new Point(47, 50);
            PrdctIdTxtbx.Margin = new Padding(3, 2, 3, 2);
            PrdctIdTxtbx.Name = "PrdctIdTxtbx";
            PrdctIdTxtbx.Size = new Size(196, 23);
            PrdctIdTxtbx.TabIndex = 0;
            // 
            // prdctId
            // 
            prdctId.AutoSize = true;
            prdctId.Location = new Point(108, 26);
            prdctId.Name = "prdctId";
            prdctId.Size = new Size(66, 15);
            prdctId.TabIndex = 13;
            prdctId.Text = "Product ID:";
            prdctId.Click += label2_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(15, 26, 43);
            panel3.Controls.Add(bck_btn);
            panel3.Controls.Add(salesBtn);
            panel3.Controls.Add(home_btn);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(item_btn);
            panel3.Controls.Add(invBtn);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 83);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(206, 556);
            panel3.TabIndex = 28;
            panel3.Paint += panel3_Paint;
            // 
            // bck_btn
            // 
            bck_btn.BackColor = Color.FromArgb(158, 147, 114);
            bck_btn.Location = new Point(43, 458);
            bck_btn.Margin = new Padding(3, 2, 3, 2);
            bck_btn.Name = "bck_btn";
            bck_btn.Size = new Size(117, 32);
            bck_btn.TabIndex = 6;
            bck_btn.Text = "Back";
            bck_btn.UseVisualStyleBackColor = false;
            bck_btn.Click += bck_btn_Click_2;
            // 
            // salesBtn
            // 
            salesBtn.BackColor = Color.FromArgb(189, 196, 212);
            salesBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            salesBtn.ForeColor = Color.FromArgb(15, 26, 43);
            salesBtn.Location = new Point(43, 239);
            salesBtn.Margin = new Padding(2);
            salesBtn.Name = "salesBtn";
            salesBtn.Size = new Size(117, 30);
            salesBtn.TabIndex = 5;
            salesBtn.Text = "Sales";
            salesBtn.UseVisualStyleBackColor = false;
            salesBtn.Click += salesBtn_Click;
            // 
            // home_btn
            // 
            home_btn.BackColor = Color.FromArgb(189, 196, 212);
            home_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            home_btn.ForeColor = Color.FromArgb(15, 26, 43);
            home_btn.Location = new Point(43, 64);
            home_btn.Margin = new Padding(2);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(117, 32);
            home_btn.TabIndex = 4;
            home_btn.Text = "Home";
            home_btn.UseVisualStyleBackColor = false;
            home_btn.Click += home_btn_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(189, 196, 212);
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(15, 26, 43);
            button4.Location = new Point(43, 291);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(117, 33);
            button4.TabIndex = 3;
            button4.Text = "Purchases";
            button4.UseVisualStyleBackColor = false;
            // 
            // item_btn
            // 
            item_btn.BackColor = Color.FromArgb(189, 196, 212);
            item_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            item_btn.ForeColor = Color.FromArgb(15, 26, 43);
            item_btn.Location = new Point(43, 181);
            item_btn.Margin = new Padding(2);
            item_btn.Name = "item_btn";
            item_btn.Size = new Size(117, 33);
            item_btn.TabIndex = 2;
            item_btn.Text = "Items";
            item_btn.UseVisualStyleBackColor = false;
            item_btn.Click += item_btn_Click;
            // 
            // invBtn
            // 
            invBtn.BackColor = Color.FromArgb(189, 196, 212);
            invBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            invBtn.ForeColor = Color.FromArgb(15, 26, 43);
            invBtn.Location = new Point(43, 119);
            invBtn.Margin = new Padding(2);
            invBtn.Name = "invBtn";
            invBtn.Size = new Size(117, 35);
            invBtn.TabIndex = 0;
            invBtn.Text = "Inventory";
            invBtn.UseVisualStyleBackColor = false;
            invBtn.Click += invBtn_Click;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1397, 639);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "InventoryForm";
            Text = " KitchenWise";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            homePanel.ResumeLayout(false);
            ((ISupportInitialize)inv_bg_pic).EndInit();
            ((ISupportInitialize)homeDataGrid).EndInit();
            ((ISupportInitialize)salesDataGrid).EndInit();
            ((ISupportInitialize)dBFuncBindingSource).EndInit();
            ((ISupportInitialize)itemdatagrid).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button4;
        private Button item_btn;
        private Button invBtn;
        private Label label1;
        private PictureBox pictureBox1;
        private Button home_btn;
        private Panel homePanel;
        private DataGridView homeDataGrid;
        private BindingSource dBFuncBindingSource;
        private DataGridView salesDataGrid;
        private Button bck_btn;
        private Button salesBtn;
        private PictureBox inv_bg_pic;
        private DataGridView dataItems;
        private Button insrtBtn;
        private Button updBtn;
        private Button dlBtn;
        private DataGridView itemdatagrid;
        private Panel CruPnl;
        private TextBox PrdctIdTxtbx;
        private Label label6;
        private Label Pricelbl;
        private Label Description;
        private Label PrdctName;
        private Label prdctId;
        private TextBox StckTxtbx;
        private TextBox PrcTxtbx;
        private TextBox DescTxtbx;
        private TextBox PrdctNameTxtbx;
        private Panel panel4;
    }
}