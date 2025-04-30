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
            btnClose = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            homePanel = new Panel();
            adminDashboardForm1 = new AdminDashboardForm();
            itemdatagrid = new DataGridView();
            salesDataGrid = new DataGridView();
            dBFuncBindingSource = new BindingSource(components);
            homeDataGrid = new DataGridView();
            reports_grid = new DataGridView();
            addProductForm1 = new AddProductForm();
            inv_bg_pic = new PictureBox();
            addInventory1 = new addInventory();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            salesIcon = new PictureBox();
            itemIcon = new PictureBox();
            InventoryIcon = new PictureBox();
            homeIcon = new PictureBox();
            print_btn = new Button();
            bck_btn = new Button();
            salesBtn = new Button();
            home_btn = new Button();
            report_btn = new Button();
            item_btn = new Button();
            invBtn = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            homePanel.SuspendLayout();
            ((ISupportInitialize)itemdatagrid).BeginInit();
            ((ISupportInitialize)salesDataGrid).BeginInit();
            ((ISupportInitialize)dBFuncBindingSource).BeginInit();
            ((ISupportInitialize)homeDataGrid).BeginInit();
            ((ISupportInitialize)reports_grid).BeginInit();
            ((ISupportInitialize)inv_bg_pic).BeginInit();
            panel3.SuspendLayout();
            ((ISupportInitialize)pictureBox2).BeginInit();
            ((ISupportInitialize)salesIcon).BeginInit();
            ((ISupportInitialize)itemIcon).BeginInit();
            ((ISupportInitialize)InventoryIcon).BeginInit();
            ((ISupportInitialize)homeIcon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(15, 26, 43);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1265, 111);
            panel1.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(527, 31);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(435, 53);
            label1.TabIndex = 2;
            label1.Text = "KitchenWise Database";
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.BackColor = Color.Chocolate;
            btnClose.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(1224, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(38, 41);
            btnClose.TabIndex = 38;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            pictureBox1.Location = new Point(77, 12);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(94, 93);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(homePanel);
            panel2.Location = new Point(235, 111);
            panel2.Margin = new Padding(2, 3, 2, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1030, 720);
            panel2.TabIndex = 28;
            // 
            // homePanel
            // 
            homePanel.BackColor = Color.FromArgb(209, 207, 201);
            homePanel.Controls.Add(adminDashboardForm1);
            homePanel.Controls.Add(itemdatagrid);
            homePanel.Controls.Add(salesDataGrid);
            homePanel.Controls.Add(homeDataGrid);
            homePanel.Controls.Add(reports_grid);
            homePanel.Controls.Add(addProductForm1);
            homePanel.Controls.Add(inv_bg_pic);
            homePanel.Controls.Add(addInventory1);
            homePanel.Location = new Point(1, 0);
            homePanel.Margin = new Padding(3, 4, 3, 4);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1029, 720);
            homePanel.TabIndex = 0;
            // 
            // adminDashboardForm1
            // 
            adminDashboardForm1.BackColor = Color.FromArgb(15, 26, 43);
            adminDashboardForm1.Location = new Point(-6, -3);
            adminDashboardForm1.Margin = new Padding(3, 5, 3, 5);
            adminDashboardForm1.Name = "adminDashboardForm1";
            adminDashboardForm1.Size = new Size(1035, 740);
            adminDashboardForm1.TabIndex = 39;
            // 
            // itemdatagrid
            // 
            itemdatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            itemdatagrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            itemdatagrid.BackgroundColor = Color.FromArgb(209, 207, 201);
            itemdatagrid.BorderStyle = BorderStyle.None;
            itemdatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemdatagrid.Dock = DockStyle.Fill;
            itemdatagrid.Location = new Point(0, 0);
            itemdatagrid.Name = "itemdatagrid";
            itemdatagrid.RowHeadersWidth = 51;
            itemdatagrid.Size = new Size(1029, 720);
            itemdatagrid.TabIndex = 40;
            // 
            // salesDataGrid
            // 
            salesDataGrid.AutoGenerateColumns = false;
            salesDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            salesDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
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
            homeDataGrid.Size = new Size(1029, 720);
            homeDataGrid.TabIndex = 0;
            // 
            // reports_grid
            // 
            reports_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reports_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            reports_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reports_grid.Location = new Point(5, 7);
            reports_grid.Margin = new Padding(3, 4, 3, 4);
            reports_grid.Name = "reports_grid";
            reports_grid.RowHeadersWidth = 51;
            reports_grid.Size = new Size(1021, 709);
            reports_grid.TabIndex = 42;
            // 
            // addProductForm1
            // 
            addProductForm1.Location = new Point(-1, -3);
            addProductForm1.Margin = new Padding(3, 5, 3, 5);
            addProductForm1.Name = "addProductForm1";
            addProductForm1.Size = new Size(1031, 741);
            addProductForm1.TabIndex = 41;
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
            // addInventory1
            // 
            addInventory1.Location = new Point(122, 31);
            addInventory1.Name = "addInventory1";
            addInventory1.Size = new Size(1286, 900);
            addInventory1.TabIndex = 43;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(15, 26, 43);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(salesIcon);
            panel3.Controls.Add(itemIcon);
            panel3.Controls.Add(InventoryIcon);
            panel3.Controls.Add(homeIcon);
            panel3.Controls.Add(print_btn);
            panel3.Controls.Add(bck_btn);
            panel3.Controls.Add(salesBtn);
            panel3.Controls.Add(home_btn);
            panel3.Controls.Add(report_btn);
            panel3.Controls.Add(item_btn);
            panel3.Controls.Add(invBtn);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 111);
            panel3.Margin = new Padding(2, 3, 2, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 720);
            panel3.TabIndex = 28;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 373);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(79, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // salesIcon
            // 
            salesIcon.Image = (Image)resources.GetObject("salesIcon.Image");
            salesIcon.Location = new Point(7, 303);
            salesIcon.Name = "salesIcon";
            salesIcon.Size = new Size(79, 64);
            salesIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            salesIcon.TabIndex = 11;
            salesIcon.TabStop = false;
            // 
            // itemIcon
            // 
            itemIcon.Image = (Image)resources.GetObject("itemIcon.Image");
            itemIcon.Location = new Point(7, 233);
            itemIcon.Name = "itemIcon";
            itemIcon.Size = new Size(79, 64);
            itemIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            itemIcon.TabIndex = 10;
            itemIcon.TabStop = false;
            itemIcon.Click += itemIcon_Click;
            // 
            // InventoryIcon
            // 
            InventoryIcon.Image = (Image)resources.GetObject("InventoryIcon.Image");
            InventoryIcon.Location = new Point(7, 163);
            InventoryIcon.Name = "InventoryIcon";
            InventoryIcon.Size = new Size(79, 64);
            InventoryIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            InventoryIcon.TabIndex = 9;
            InventoryIcon.TabStop = false;
            // 
            // homeIcon
            // 
            homeIcon.Image = Properties.Resources._6;
            homeIcon.Location = new Point(12, 87);
            homeIcon.Name = "homeIcon";
            homeIcon.Size = new Size(74, 54);
            homeIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            homeIcon.TabIndex = 8;
            homeIcon.TabStop = false;
            // 
            // print_btn
            // 
            print_btn.BackColor = Color.FromArgb(58, 135, 24);
            print_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            print_btn.ForeColor = Color.White;
            print_btn.Location = new Point(87, 468);
            print_btn.Margin = new Padding(2, 3, 2, 3);
            print_btn.Name = "print_btn";
            print_btn.Size = new Size(134, 41);
            print_btn.TabIndex = 7;
            print_btn.Text = "Print";
            print_btn.UseVisualStyleBackColor = false;
            print_btn.Click += print_btn_Click;
            // 
            // bck_btn
            // 
            bck_btn.BackColor = Color.FromArgb(158, 147, 114);
            bck_btn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bck_btn.ForeColor = Color.White;
            bck_btn.Location = new Point(49, 651);
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
            salesBtn.Location = new Point(84, 313);
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
            home_btn.Location = new Point(91, 98);
            home_btn.Margin = new Padding(2, 3, 2, 3);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(134, 43);
            home_btn.TabIndex = 4;
            home_btn.Text = "Home";
            home_btn.UseVisualStyleBackColor = false;
            home_btn.Click += home_btn_Click;
            // 
            // report_btn
            // 
            report_btn.BackColor = Color.FromArgb(189, 196, 212);
            report_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            report_btn.ForeColor = Color.FromArgb(15, 26, 43);
            report_btn.Location = new Point(87, 376);
            report_btn.Margin = new Padding(2, 3, 2, 3);
            report_btn.Name = "report_btn";
            report_btn.Size = new Size(134, 44);
            report_btn.TabIndex = 3;
            report_btn.Text = "Reports";
            report_btn.UseVisualStyleBackColor = false;
            report_btn.Click += report_btn_Click;
            // 
            // item_btn
            // 
            item_btn.BackColor = Color.FromArgb(189, 196, 212);
            item_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            item_btn.ForeColor = Color.FromArgb(15, 26, 43);
            item_btn.Location = new Point(86, 244);
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
            invBtn.Location = new Point(86, 163);
            invBtn.Margin = new Padding(2, 3, 2, 3);
            invBtn.Name = "invBtn";
            invBtn.Size = new Size(134, 47);
            invBtn.TabIndex = 0;
            invBtn.Text = "Inventory";
            invBtn.UseVisualStyleBackColor = false;
            invBtn.Click += invBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(84, 32);
            label2.Name = "label2";
            label2.Size = new Size(68, 28);
            label2.TabIndex = 13;
            label2.Text = "Home";
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1265, 831);
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
            ((ISupportInitialize)salesDataGrid).EndInit();
            ((ISupportInitialize)dBFuncBindingSource).EndInit();
            ((ISupportInitialize)homeDataGrid).EndInit();
            ((ISupportInitialize)reports_grid).EndInit();
            ((ISupportInitialize)inv_bg_pic).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((ISupportInitialize)pictureBox2).EndInit();
            ((ISupportInitialize)salesIcon).EndInit();
            ((ISupportInitialize)itemIcon).EndInit();
            ((ISupportInitialize)InventoryIcon).EndInit();
            ((ISupportInitialize)homeIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button report_btn;
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
        private DataGridView reports_grid;
        private Button print_btn;
        private addInventory addInventory1;
        private PictureBox homeIcon;
        private PictureBox InventoryIcon;
        private PictureBox itemIcon;
        private PictureBox pictureBox2;
        private PictureBox salesIcon;
        private Label label2;
    }
}