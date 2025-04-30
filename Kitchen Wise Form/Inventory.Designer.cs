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
            pictureBox3 = new PictureBox();
            itemlbl = new Label();
            label3 = new Label();
            saleslbl = new Label();
            inventorylbl = new Label();
            homelbl = new Label();
            pictureBox2 = new PictureBox();
            salesIcon = new PictureBox();
            itemIcon = new PictureBox();
            InventoryIcon = new PictureBox();
            homeIcon = new PictureBox();
            print_btn = new Button();
            bck_btn = new Button();
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
            ((ISupportInitialize)pictureBox3).BeginInit();
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
            label1.Location = new Point(521, 34);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(435, 53);
            label1.TabIndex = 2;
            label1.Text = "KitchenWise Database";
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.BackColor = Color.FromArgb(138, 3, 34);
            btnClose.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(1232, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(38, 41);
            btnClose.TabIndex = 38;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            pictureBox1.Location = new Point(60, 13);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(82, 84);
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
            adminDashboardForm1.Location = new Point(-5, -2);
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
            reports_grid.BackgroundColor = Color.FromArgb(209, 207, 201);
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
            addInventory1.Location = new Point(-1, 5);
            addInventory1.Name = "addInventory1";
            addInventory1.Size = new Size(1031, 711);
            addInventory1.TabIndex = 43;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(15, 26, 43);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(itemlbl);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(saleslbl);
            panel3.Controls.Add(inventorylbl);
            panel3.Controls.Add(homelbl);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(salesIcon);
            panel3.Controls.Add(itemIcon);
            panel3.Controls.Add(InventoryIcon);
            panel3.Controls.Add(homeIcon);
            panel3.Controls.Add(print_btn);
            panel3.Controls.Add(bck_btn);
            panel3.Dock = DockStyle.Left;
            panel3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            panel3.ForeColor = Color.White;
            panel3.Location = new Point(0, 111);
            panel3.Margin = new Padding(2, 3, 2, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 720);
            panel3.TabIndex = 28;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(17, 443);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(74, 55);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // itemlbl
            // 
            itemlbl.AutoSize = true;
            itemlbl.Location = new Point(105, 249);
            itemlbl.Name = "itemlbl";
            itemlbl.Size = new Size(73, 31);
            itemlbl.TabIndex = 18;
            itemlbl.Text = "Items";
            itemlbl.Click += label4_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(105, 386);
            label3.Name = "label3";
            label3.Size = new Size(97, 31);
            label3.TabIndex = 17;
            label3.Text = "Reports";
            label3.Click += label3_Click_1;
            // 
            // saleslbl
            // 
            saleslbl.AutoSize = true;
            saleslbl.Location = new Point(105, 318);
            saleslbl.Name = "saleslbl";
            saleslbl.Size = new Size(68, 31);
            saleslbl.TabIndex = 16;
            saleslbl.Text = "Sales";
            saleslbl.Click += label4_Click;
            // 
            // inventorylbl
            // 
            inventorylbl.AutoSize = true;
            inventorylbl.Location = new Point(91, 178);
            inventorylbl.Name = "inventorylbl";
            inventorylbl.Size = new Size(118, 31);
            inventorylbl.TabIndex = 14;
            inventorylbl.Text = "Inventory";
            inventorylbl.Click += label2_Click_1;
            // 
            // homelbl
            // 
            homelbl.AutoSize = true;
            homelbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homelbl.ForeColor = Color.White;
            homelbl.Location = new Point(94, 100);
            homelbl.Name = "homelbl";
            homelbl.Size = new Size(79, 31);
            homelbl.TabIndex = 13;
            homelbl.Text = "Home";
            homelbl.Click += label2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 373);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(79, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // salesIcon
            // 
            salesIcon.Image = (Image)resources.GetObject("salesIcon.Image");
            salesIcon.Location = new Point(15, 303);
            salesIcon.Name = "salesIcon";
            salesIcon.Size = new Size(79, 64);
            salesIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            salesIcon.TabIndex = 11;
            salesIcon.TabStop = false;
            // 
            // itemIcon
            // 
            itemIcon.Image = (Image)resources.GetObject("itemIcon.Image");
            itemIcon.Location = new Point(15, 233);
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
            InventoryIcon.Location = new Point(15, 163);
            InventoryIcon.Name = "InventoryIcon";
            InventoryIcon.Size = new Size(79, 64);
            InventoryIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            InventoryIcon.TabIndex = 9;
            InventoryIcon.TabStop = false;
            // 
            // homeIcon
            // 
            homeIcon.Image = Properties.Resources._6;
            homeIcon.Location = new Point(20, 87);
            homeIcon.Name = "homeIcon";
            homeIcon.Size = new Size(74, 54);
            homeIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            homeIcon.TabIndex = 8;
            homeIcon.TabStop = false;
            // 
            // print_btn
            // 
            print_btn.BackColor = Color.FromArgb(58, 135, 24);
            print_btn.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold);
            print_btn.ForeColor = Color.White;
            print_btn.Location = new Point(101, 454);
            print_btn.Margin = new Padding(2, 3, 2, 3);
            print_btn.Name = "print_btn";
            print_btn.Size = new Size(108, 44);
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
            ((ISupportInitialize)pictureBox3).EndInit();
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
        private Label label1;
        private PictureBox pictureBox1;
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
        private Label homelbl;
        private Label inventorylbl;
        private Label label3;
        private Label saleslbl;
        private Label itemlbl;
        private PictureBox pictureBox3;
    }
}