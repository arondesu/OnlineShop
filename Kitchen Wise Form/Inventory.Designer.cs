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
            btnClose = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            homePanel = new Panel();
            BASE = new Panel();
            addProductForm1 = new AddProductForm();
            adminDashboardForm1 = new AdminDashboardForm();
            itemdatagrid = new DataGridView();
            inv_bg_pic = new PictureBox();
            homeDataGrid = new DataGridView();
            salesDataGrid = new DataGridView();
            dBFuncBindingSource = new BindingSource(components);
            panel3 = new Panel();
            bck_btn = new Button();
            salesBtn = new Button();
            home_btn = new Button();
            button4 = new Button();
            item_btn = new Button();
            invBtn = new Button();
            addProductForm1 = new AddProductForm();
            panel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            homePanel.SuspendLayout();
            ((ISupportInitialize)itemdatagrid).BeginInit();
            ((ISupportInitialize)inv_bg_pic).BeginInit();
            ((ISupportInitialize)homeDataGrid).BeginInit();
            ((ISupportInitialize)salesDataGrid).BeginInit();
            ((ISupportInitialize)dBFuncBindingSource).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(15, 26, 43);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1266, 111);
            panel1.TabIndex = 27;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.BackColor = Color.Chocolate;
            btnClose.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(1230, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(38, 41);
            btnClose.TabIndex = 38;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(527, 31);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(375, 46);
            label1.TabIndex = 2;
            label1.Text = "KitchenWise Inventory";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            pictureBox1.Location = new Point(86, 29);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(58, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(homePanel);
            panel2.Location = new Point(235, 111);
            panel2.Margin = new Padding(2, 3, 2, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1030, 741);
            panel2.TabIndex = 28;
            // 
            // homePanel
            // 
            homePanel.BackColor = Color.FromArgb(209, 207, 201);
            homePanel.Controls.Add(addProductForm1);
            homePanel.Controls.Add(itemdatagrid);
            homePanel.Controls.Add(inv_bg_pic);
            homePanel.Controls.Add(homeDataGrid);
            homePanel.Controls.Add(salesDataGrid);
            homePanel.Location = new Point(1, 3);
            homePanel.Margin = new Padding(3, 4, 3, 4);
            homePanel.Controls.Add(adminDashboardForm1);
            homePanel.Location = new Point(1, 2);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1029, 759);
            homePanel.TabIndex = 0;
            // 
            // BASE
            // 
            BASE.Location = new Point(0, 0);
            BASE.Margin = new Padding(3, 4, 3, 4);
            BASE.Name = "BASE";
            BASE.Size = new Size(1030, 739);
            BASE.TabIndex = 42;
            // 
            // addProductForm1
            // 
            addProductForm1.Location = new Point(-3, -3);
            addProductForm1.Margin = new Padding(3, 5, 3, 5);
            addProductForm1.Name = "addProductForm1";
            addProductForm1.Size = new Size(1029, 741);
            addProductForm1.TabIndex = 41;
            // itemdatagrid
            // 
            itemdatagrid.BackgroundColor = Color.FromArgb(209, 207, 201);
            itemdatagrid.BorderStyle = BorderStyle.None;
            itemdatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemdatagrid.Dock = DockStyle.Fill;
            itemdatagrid.Location = new Point(0, 0);
            itemdatagrid.Name = "itemdatagrid";
            itemdatagrid.RowHeadersWidth = 51;
            itemdatagrid.Size = new Size(900, 569);
            itemdatagrid.TabIndex = 40;
            // 
            // adminDashboardForm1
            // 
            adminDashboardForm1.BackColor = Color.FromArgb(15, 26, 43);
            adminDashboardForm1.Location = new Point(-1, -3);
            adminDashboardForm1.Margin = new Padding(3, 5, 3, 5);
            adminDashboardForm1.Name = "adminDashboardForm1";
            adminDashboardForm1.Size = new Size(1031, 741);
            adminDashboardForm1.TabIndex = 39;
            // 
            // inv_bg_pic
            // 
            inv_bg_pic.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            inv_bg_pic.Location = new Point(411, 264);
            inv_bg_pic.Name = "inv_bg_pic";
            inv_bg_pic.Size = new Size(151, 176);
            inv_bg_pic.TabIndex = 3;
            inv_bg_pic.TabStop = false;
            // 
            // homeDataGrid
            // 
            homeDataGrid.BackgroundColor = Color.FromArgb(209, 207, 201);
            homeDataGrid.BorderStyle = BorderStyle.None;
            homeDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            homeDataGrid.Dock = DockStyle.Fill;
            homeDataGrid.Location = new Point(0, 0);
            homeDataGrid.Margin = new Padding(3, 4, 3, 4);
            homeDataGrid.Name = "homeDataGrid";
            homeDataGrid.RowHeadersWidth = 51;
            homeDataGrid.Size = new Size(1029, 759);
            homeDataGrid.TabIndex = 0;
            // 
            // salesDataGrid
            // 
            salesDataGrid.AutoGenerateColumns = false;
            salesDataGrid.BackgroundColor = Color.FromArgb(209, 207, 201);
            salesDataGrid.BorderStyle = BorderStyle.None;
            salesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            salesDataGrid.DataSource = dBFuncBindingSource;
            salesDataGrid.Location = new Point(-6, -3);
            salesDataGrid.Margin = new Padding(3, 4, 3, 4);
            salesDataGrid.Name = "salesDataGrid";
            salesDataGrid.RowHeadersWidth = 51;
            salesDataGrid.Size = new Size(1035, 740);
            salesDataGrid.TabIndex = 1;
            // 
            // dBFuncBindingSource
            // 
            dBFuncBindingSource.DataSource = typeof(DBFunc);
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
            panel3.Location = new Point(0, 111);
            panel3.Margin = new Padding(2, 3, 2, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 741);
            panel3.TabIndex = 28;
            // 
            // bck_btn
            // 
            bck_btn.BackColor = Color.FromArgb(158, 147, 114);
            bck_btn.Location = new Point(49, 611);
            bck_btn.Name = "bck_btn";
            bck_btn.Size = new Size(134, 43);
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
            salesBtn.Location = new Point(49, 319);
            salesBtn.Margin = new Padding(2, 3, 2, 3);
            salesBtn.Name = "salesBtn";
            salesBtn.Size = new Size(134, 40);
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
            home_btn.Location = new Point(49, 85);
            home_btn.Margin = new Padding(2, 3, 2, 3);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(134, 43);
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
            button4.Location = new Point(49, 388);
            button4.Margin = new Padding(2, 3, 2, 3);
            button4.Name = "button4";
            button4.Size = new Size(134, 44);
            button4.TabIndex = 3;
            button4.Text = "Sales Report";
            button4.UseVisualStyleBackColor = false;
            // 
            // item_btn
            // 
            item_btn.BackColor = Color.FromArgb(189, 196, 212);
            item_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            item_btn.ForeColor = Color.FromArgb(15, 26, 43);
            item_btn.Location = new Point(49, 241);
            item_btn.Margin = new Padding(2, 3, 2, 3);
            item_btn.Name = "item_btn";
            item_btn.Size = new Size(134, 44);
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
            invBtn.Location = new Point(49, 159);
            invBtn.Margin = new Padding(2, 3, 2, 3);
            invBtn.Name = "invBtn";
            invBtn.Size = new Size(134, 47);
            invBtn.TabIndex = 0;
            invBtn.Text = "Inventory";
            invBtn.UseVisualStyleBackColor = false;
            invBtn.Click += invBtn_Click;
            // 
            // addProductForm1
            // 
            addProductForm1.Location = new Point(-1, -2);
            addProductForm1.Name = "addProductForm1";
            addProductForm1.Size = new Size(900, 556);
            addProductForm1.TabIndex = 41;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 852);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InventoryForm";
            Text = " KitchenWise";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            homePanel.ResumeLayout(false);
            ((ISupportInitialize)itemdatagrid).EndInit();
            ((ISupportInitialize)inv_bg_pic).EndInit();
            ((ISupportInitialize)homeDataGrid).EndInit();
            ((ISupportInitialize)salesDataGrid).EndInit();
            ((ISupportInitialize)dBFuncBindingSource).EndInit();
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
        private Button bck_btn;
        private Button salesBtn;
        private PictureBox inv_bg_pic;
        private DataGridView dataItems;
        private Panel CruPnl;
        private Label btnClose;
        private AdminDashboardForm adminDashboardForm1;
        private DataGridView salesDataGrid;
        private DataGridView itemdatagrid;
        private AddProductForm addProductForm1;
    }
}