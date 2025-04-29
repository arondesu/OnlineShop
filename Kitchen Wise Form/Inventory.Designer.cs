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
            updateInvPnl = new Panel();
            panel5 = new Panel();
            AddProductForm_imageView = new PictureBox();
            txtItem_status = new ComboBox();
            txtItem_type = new ComboBox();
            btnImport = new Button();
            btnClear = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtItem_price = new TextBox();
            txtItem_stock = new TextBox();
            txtItem_name = new TextBox();
            txtItem_id = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            itemdatagrid = new DataGridView();
            salesDataGrid = new DataGridView();
            dBFuncBindingSource = new BindingSource(components);
            homeDataGrid = new DataGridView();
            adminDashboardForm1 = new AdminDashboardForm();
            addProductForm1 = new AddProductForm();
            inv_bg_pic = new PictureBox();
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
            updateInvPnl.SuspendLayout();
            panel5.SuspendLayout();
            ((ISupportInitialize)AddProductForm_imageView).BeginInit();
            ((ISupportInitialize)itemdatagrid).BeginInit();
            ((ISupportInitialize)salesDataGrid).BeginInit();
            ((ISupportInitialize)dBFuncBindingSource).BeginInit();
            ((ISupportInitialize)homeDataGrid).BeginInit();
            ((ISupportInitialize)inv_bg_pic).BeginInit();
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
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1266, 110);
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
            label1.Location = new Point(527, 30);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(375, 46);
            label1.TabIndex = 2;
            label1.Text = "KitchenWise Inventory";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            pictureBox1.Location = new Point(86, 30);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(58, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(homePanel);
            panel2.Location = new Point(235, 110);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1030, 7424);
            panel2.TabIndex = 28;
            // 
            // homePanel
            // 
            homePanel.BackColor = Color.FromArgb(209, 207, 201);
            homePanel.Controls.Add(updateInvPnl);
            homePanel.Controls.Add(itemdatagrid);
            homePanel.Controls.Add(salesDataGrid);
            homePanel.Controls.Add(homeDataGrid);
            homePanel.Controls.Add(adminDashboardForm1);
            homePanel.Controls.Add(addProductForm1);
            homePanel.Controls.Add(inv_bg_pic);
            homePanel.Location = new Point(1, 2);
            homePanel.Margin = new Padding(3, 4, 3, 4);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1029, 758);
            homePanel.TabIndex = 0;
            // 
            // updateInvPnl
            // 
            updateInvPnl.BackColor = Color.FromArgb(15, 26, 43);
            updateInvPnl.Controls.Add(panel5);
            updateInvPnl.Controls.Add(txtItem_status);
            updateInvPnl.Controls.Add(txtItem_type);
            updateInvPnl.Controls.Add(btnImport);
            updateInvPnl.Controls.Add(btnClear);
            updateInvPnl.Controls.Add(btnUpdate);
            updateInvPnl.Controls.Add(btnAdd);
            updateInvPnl.Controls.Add(txtItem_price);
            updateInvPnl.Controls.Add(txtItem_stock);
            updateInvPnl.Controls.Add(txtItem_name);
            updateInvPnl.Controls.Add(txtItem_id);
            updateInvPnl.Controls.Add(label8);
            updateInvPnl.Controls.Add(label7);
            updateInvPnl.Controls.Add(label6);
            updateInvPnl.Controls.Add(label4);
            updateInvPnl.Controls.Add(label3);
            updateInvPnl.Controls.Add(label2);
            updateInvPnl.Location = new Point(0, 440);
            updateInvPnl.Margin = new Padding(3, 4, 3, 4);
            updateInvPnl.Name = "updateInvPnl";
            updateInvPnl.Size = new Size(1029, 299);
            updateInvPnl.TabIndex = 42;
            // 
            // panel5
            // 
            panel5.Controls.Add(AddProductForm_imageView);
            panel5.Location = new Point(831, 20);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(135, 133);
            panel5.TabIndex = 25;
            // 
            // AddProductForm_imageView
            // 
            AddProductForm_imageView.BackColor = Color.Gainsboro;
            AddProductForm_imageView.Location = new Point(0, 0);
            AddProductForm_imageView.Margin = new Padding(3, 4, 3, 4);
            AddProductForm_imageView.Name = "AddProductForm_imageView";
            AddProductForm_imageView.Size = new Size(135, 133);
            AddProductForm_imageView.TabIndex = 0;
            AddProductForm_imageView.TabStop = false;
            // 
            // txtItem_status
            // 
            txtItem_status.FormattingEnabled = true;
            txtItem_status.Items.AddRange(new object[] { "Available", "Unavailabe" });
            txtItem_status.Location = new Point(621, 144);
            txtItem_status.Margin = new Padding(3, 4, 3, 4);
            txtItem_status.Name = "txtItem_status";
            txtItem_status.Size = new Size(145, 28);
            txtItem_status.TabIndex = 24;
            // 
            // txtItem_type
            // 
            txtItem_type.FormattingEnabled = true;
            txtItem_type.Items.AddRange(new object[] { "Appliance", "Furniture" });
            txtItem_type.Location = new Point(225, 145);
            txtItem_type.Margin = new Padding(3, 4, 3, 4);
            txtItem_type.Name = "txtItem_type";
            txtItem_type.Size = new Size(145, 28);
            txtItem_type.TabIndex = 23;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(189, 196, 212);
            btnImport.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImport.ForeColor = Color.FromArgb(15, 26, 43);
            btnImport.Location = new Point(859, 160);
            btnImport.Margin = new Padding(2, 3, 2, 3);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(73, 64);
            btnImport.TabIndex = 22;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(189, 196, 212);
            btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.FromArgb(15, 26, 43);
            btnClear.Location = new Point(630, 224);
            btnClear.Margin = new Padding(2, 3, 2, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(73, 64);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(189, 196, 212);
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.FromArgb(15, 26, 43);
            btnUpdate.Location = new Point(453, 224);
            btnUpdate.Margin = new Padding(2, 3, 2, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(76, 64);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(189, 196, 212);
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(15, 26, 43);
            btnAdd.Location = new Point(268, 224);
            btnAdd.Margin = new Padding(2, 3, 2, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(73, 64);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtItem_price
            // 
            txtItem_price.Location = new Point(621, 92);
            txtItem_price.Margin = new Padding(3, 4, 3, 4);
            txtItem_price.Name = "txtItem_price";
            txtItem_price.Size = new Size(145, 27);
            txtItem_price.TabIndex = 15;
            // 
            // txtItem_stock
            // 
            txtItem_stock.Location = new Point(621, 44);
            txtItem_stock.Margin = new Padding(3, 4, 3, 4);
            txtItem_stock.Name = "txtItem_stock";
            txtItem_stock.Size = new Size(145, 27);
            txtItem_stock.TabIndex = 14;
            // 
            // txtItem_name
            // 
            txtItem_name.Location = new Point(225, 94);
            txtItem_name.Margin = new Padding(3, 4, 3, 4);
            txtItem_name.Name = "txtItem_name";
            txtItem_name.Size = new Size(145, 27);
            txtItem_name.TabIndex = 12;
            // 
            // txtItem_id
            // 
            txtItem_id.Location = new Point(225, 45);
            txtItem_id.Margin = new Padding(3, 4, 3, 4);
            txtItem_id.Name = "txtItem_id";
            txtItem_id.Size = new Size(145, 27);
            txtItem_id.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(543, 142);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(77, 27);
            label8.TabIndex = 10;
            label8.Text = "Status:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(552, 90);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(64, 27);
            label7.TabIndex = 9;
            label7.Text = "Price:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(48, 94);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(155, 27);
            label6.TabIndex = 8;
            label6.Text = "Product Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(140, 144);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 27);
            label4.TabIndex = 6;
            label4.Text = "Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(546, 42);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(71, 27);
            label3.TabIndex = 5;
            label3.Text = "Stock:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(83, 45);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 27);
            label2.TabIndex = 4;
            label2.Text = "Product ID:";
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
            itemdatagrid.Margin = new Padding(3, 2, 3, 2);
            itemdatagrid.Name = "itemdatagrid";
            itemdatagrid.RowHeadersWidth = 51;
            itemdatagrid.Size = new Size(1029, 758);
            itemdatagrid.TabIndex = 40;
            itemdatagrid.CellContentClick += itemdatagrid_CellContentClick;
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
            salesDataGrid.Location = new Point(-6, -2);
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
            homeDataGrid.Size = new Size(1029, 758);
            homeDataGrid.TabIndex = 0;
            // 
            // adminDashboardForm1
            // 
            adminDashboardForm1.BackColor = Color.FromArgb(15, 26, 43);
            adminDashboardForm1.Location = new Point(-1, -2);
            adminDashboardForm1.Margin = new Padding(3, 6, 3, 6);
            adminDashboardForm1.Name = "adminDashboardForm1";
            adminDashboardForm1.Size = new Size(1031, 742);
            adminDashboardForm1.TabIndex = 39;
            // 
            // addProductForm1
            // 
            addProductForm1.Location = new Point(-1, -2);
            addProductForm1.Margin = new Padding(3, 6, 3, 6);
            addProductForm1.Name = "addProductForm1";
            addProductForm1.Size = new Size(1031, 742);
            addProductForm1.TabIndex = 41;
            // 
            // inv_bg_pic
            // 
            inv_bg_pic.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            inv_bg_pic.Location = new Point(411, 264);
            inv_bg_pic.Margin = new Padding(3, 2, 3, 2);
            inv_bg_pic.Name = "inv_bg_pic";
            inv_bg_pic.Size = new Size(151, 176);
            inv_bg_pic.TabIndex = 3;
            inv_bg_pic.TabStop = false;
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
            panel3.Location = new Point(0, 110);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 742);
            panel3.TabIndex = 28;
            // 
            // bck_btn
            // 
            bck_btn.BackColor = Color.FromArgb(158, 147, 114);
            bck_btn.Location = new Point(49, 610);
            bck_btn.Margin = new Padding(3, 2, 3, 2);
            bck_btn.Name = "bck_btn";
            bck_btn.Size = new Size(134, 42);
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
            salesBtn.Location = new Point(49, 318);
            salesBtn.Margin = new Padding(2);
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
            home_btn.Location = new Point(49, 86);
            home_btn.Margin = new Padding(2);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(134, 42);
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
            button4.Margin = new Padding(2);
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
            item_btn.Location = new Point(49, 242);
            item_btn.Margin = new Padding(2);
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
            invBtn.Location = new Point(49, 158);
            invBtn.Margin = new Padding(2);
            invBtn.Name = "invBtn";
            invBtn.Size = new Size(134, 46);
            invBtn.TabIndex = 0;
            invBtn.Text = "Inventory";
            invBtn.UseVisualStyleBackColor = false;
            invBtn.Click += invBtn_Click;
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "InventoryForm";
            Text = " KitchenWise";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            homePanel.ResumeLayout(false);
            updateInvPnl.ResumeLayout(false);
            updateInvPnl.PerformLayout();
            panel5.ResumeLayout(false);
            ((ISupportInitialize)AddProductForm_imageView).EndInit();
            ((ISupportInitialize)itemdatagrid).EndInit();
            ((ISupportInitialize)salesDataGrid).EndInit();
            ((ISupportInitialize)dBFuncBindingSource).EndInit();
            ((ISupportInitialize)homeDataGrid).EndInit();
            ((ISupportInitialize)inv_bg_pic).EndInit();
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
        private Panel updateInvPnl;
        private Panel panel5;
        private PictureBox AddProductForm_imageView;
        private ComboBox txtItem_status;
        private ComboBox txtItem_type;
        private Button btnImport;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtItem_price;
        private TextBox txtItem_stock;
        private TextBox txtItem_name;
        private TextBox txtItem_id;
        private Label label8;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
    }
}