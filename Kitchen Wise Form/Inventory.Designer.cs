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
            cmbItemStatus = new ComboBox();
            cmbItemType = new ComboBox();
            btnImport = new Button();
            btnClear = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtItemPrice = new TextBox();
            txtItemStock = new TextBox();
            txtItemName = new TextBox();
            txtItemId = new TextBox();
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
            reports_grid = new DataGridView();
            adminDashboardForm1 = new AdminDashboardForm();
            addProductForm1 = new AddProductForm();
            inv_bg_pic = new PictureBox();
            panel3 = new Panel();
            bck_btn = new Button();
            salesBtn = new Button();
            home_btn = new Button();
            report_btn = new Button();
            item_btn = new Button();
            invBtn = new Button();
            print_btn = new Button();
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
            panel1.Size = new Size(1583, 138);
            panel1.TabIndex = 27;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.BackColor = Color.Chocolate;
            btnClose.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(1537, 5);
            btnClose.Margin = new Padding(4, 0, 4, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(38, 41);
            btnClose.TabIndex = 38;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(504, 30);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(405, 49);
            label1.TabIndex = 2;
            label1.Text = "KitchenWise Database";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            pictureBox1.Location = new Point(107, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(82, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(homePanel);
            panel2.Location = new Point(294, 138);
            panel2.Name = "panel2";
            panel2.Size = new Size(1287, 927);
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
            homePanel.Controls.Add(itemdatagrid);
            homePanel.Controls.Add(salesDataGrid);
            homePanel.Controls.Add(homeDataGrid);
            homePanel.Location = new Point(1, 3);
            homePanel.Margin = new Padding(4, 5, 4, 5);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1286, 948);
            homePanel.TabIndex = 0;
            // 
            // updateInvPnl
            // 
            updateInvPnl.BackColor = Color.FromArgb(15, 26, 43);
            updateInvPnl.Controls.Add(panel5);
            updateInvPnl.Controls.Add(cmbItemStatus);
            updateInvPnl.Controls.Add(cmbItemType);
            updateInvPnl.Controls.Add(btnImport);
            updateInvPnl.Controls.Add(btnClear);
            updateInvPnl.Controls.Add(btnUpdate);
            updateInvPnl.Controls.Add(btnAdd);
            updateInvPnl.Controls.Add(txtItemPrice);
            updateInvPnl.Controls.Add(txtItemStock);
            updateInvPnl.Controls.Add(txtItemName);
            updateInvPnl.Controls.Add(txtItemId);
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
            // cmbItemStatus
            // 
            cmbItemStatus.FormattingEnabled = true;
            cmbItemStatus.Items.AddRange(new object[] { "Available", "Unavailabe" });
            cmbItemStatus.Location = new Point(621, 144);
            cmbItemStatus.Margin = new Padding(3, 4, 3, 4);
            cmbItemStatus.Name = "cmbItemStatus";
            cmbItemStatus.Size = new Size(145, 28);
            cmbItemStatus.TabIndex = 24;
            // 
            // cmbItemType
            // 
            cmbItemType.FormattingEnabled = true;
            cmbItemType.Items.AddRange(new object[] { "Appliance", "Furniture" });
            cmbItemType.Location = new Point(225, 145);
            cmbItemType.Margin = new Padding(3, 4, 3, 4);
            cmbItemType.Name = "cmbItemType";
            cmbItemType.Size = new Size(145, 28);
            cmbItemType.TabIndex = 23;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(189, 196, 212);
            btnImport.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImport.ForeColor = Color.FromArgb(15, 26, 43);
            btnImport.Location = new Point(831, 174);
            btnImport.Margin = new Padding(2, 3, 2, 3);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(135, 50);
            btnImport.TabIndex = 22;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(189, 196, 212);
            btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.FromArgb(15, 26, 43);
            btnClear.Location = new Point(594, 218);
            btnClear.Margin = new Padding(2, 3, 2, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(108, 47);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(189, 196, 212);
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.FromArgb(15, 26, 43);
            btnUpdate.Location = new Point(411, 218);
            btnUpdate.Margin = new Padding(2, 3, 2, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(135, 47);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(189, 196, 212);
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(15, 26, 43);
            btnAdd.Location = new Point(225, 218);
            btnAdd.Margin = new Padding(2, 3, 2, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 47);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtItemPrice
            // 
            txtItemPrice.Location = new Point(621, 92);
            txtItemPrice.Margin = new Padding(3, 4, 3, 4);
            txtItemPrice.Name = "txtItemPrice";
            txtItemPrice.Size = new Size(145, 27);
            txtItemPrice.TabIndex = 15;
            // 
            // txtItemStock
            // 
            txtItemStock.Location = new Point(621, 44);
            txtItemStock.Margin = new Padding(3, 4, 3, 4);
            txtItemStock.Name = "txtItemStock";
            txtItemStock.Size = new Size(145, 27);
            txtItemStock.TabIndex = 14;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(225, 94);
            txtItemName.Margin = new Padding(3, 4, 3, 4);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(145, 27);
            txtItemName.TabIndex = 12;
            // 
            adminDashboardForm1.BackColor = Color.FromArgb(15, 26, 43);
            adminDashboardForm1.Location = new Point(-1, -3);
            adminDashboardForm1.Margin = new Padding(4, 7, 4, 7);
            adminDashboardForm1.Name = "adminDashboardForm1";
            adminDashboardForm1.Size = new Size(1289, 927);
            adminDashboardForm1.TabIndex = 39;
            // 
            txtItemId.Location = new Point(225, 45);
            txtItemId.Margin = new Padding(3, 4, 3, 4);
            txtItemId.Name = "txtItemId";
            txtItemId.Size = new Size(145, 27);
            txtItemId.TabIndex = 11;
            txtItemId.TextChanged += txtItemId_TextChanged;
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
            itemdatagrid.Size = new Size(1286, 948);
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
            homeDataGrid.Size = new Size(1286, 948);
            homeDataGrid.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(15, 26, 43);
            panel3.Controls.Add(print_btn);
            panel3.Controls.Add(bck_btn);
            panel3.Controls.Add(salesBtn);
            panel3.Controls.Add(home_btn);
            panel3.Controls.Add(report_btn);
            panel3.Controls.Add(item_btn);
            panel3.Controls.Add(invBtn);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 138);
            panel3.Name = "panel3";
            panel3.Size = new Size(294, 927);
            panel3.TabIndex = 28;
            // 
            // bck_btn
            // 
            bck_btn.BackColor = Color.FromArgb(158, 147, 114);
            bck_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bck_btn.ForeColor = Color.White;
            bck_btn.Location = new Point(49, 665);
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
            salesBtn.Location = new Point(61, 398);
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
            home_btn.Location = new Point(61, 107);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(134, 42);
            home_btn.TabIndex = 4;
            home_btn.Text = "Home";
            home_btn.UseVisualStyleBackColor = false;
            home_btn.Click += home_btn_Click;
            // 
            // report_btn
            // 
            button4.BackColor = Color.FromArgb(189, 196, 212);
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(15, 26, 43);
            button4.Location = new Point(61, 485);
            button4.Name = "button4";
            button4.Size = new Size(167, 55);
            button4.TabIndex = 3;
            button4.Text = "Sales Report";
            button4.UseVisualStyleBackColor = false;
            // 
            // item_btn
            // 
            item_btn.BackColor = Color.FromArgb(189, 196, 212);
            item_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            item_btn.ForeColor = Color.FromArgb(15, 26, 43);
            item_btn.Location = new Point(61, 302);
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
            invBtn.Location = new Point(61, 198);
            invBtn.Name = "invBtn";
            invBtn.Size = new Size(134, 46);
            invBtn.TabIndex = 0;
            invBtn.Text = "Inventory";
            invBtn.UseVisualStyleBackColor = false;
            invBtn.Click += invBtn_Click;
            // 
            // print_btn
            // 
            print_btn.BackColor = Color.LimeGreen;
            print_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            print_btn.ForeColor = Color.Black;
            print_btn.Location = new Point(53, 345);
            print_btn.Margin = new Padding(2);
            print_btn.Name = "print_btn";
            print_btn.Size = new Size(97, 36);
            print_btn.TabIndex = 7;
            print_btn.Text = "PRINT";
            print_btn.UseVisualStyleBackColor = false;
            print_btn.Click += print_btn_Click;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1583, 1065);
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
            panel3.ResumeLayout(false);
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
    }
}