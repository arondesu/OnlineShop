
namespace OnlineShop
{
    partial class addInventory
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel4 = new Panel();
            RefreshBtn = new Button();
            label1 = new Label();
            cmbItemType = new ComboBox();
            cmbItemStatus = new ComboBox();
            btnClear = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtItemPrice = new TextBox();
            txtItemStock = new TextBox();
            txtItemName = new TextBox();
            txtItemId = new TextBox();
            statusLbl = new Label();
            priceLbl = new Label();
            prdctNameLbl = new Label();
            stockLbl = new Label();
            prdctlbl = new Label();
            dataGridViewInventory = new DataGridView();
            panel1 = new Panel();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventory).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(15, 26, 43);
            panel4.Controls.Add(RefreshBtn);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(cmbItemType);
            panel4.Controls.Add(cmbItemStatus);
            panel4.Controls.Add(btnClear);
            panel4.Controls.Add(btnUpdate);
            panel4.Controls.Add(btnAdd);
            panel4.Controls.Add(txtItemPrice);
            panel4.Controls.Add(txtItemStock);
            panel4.Controls.Add(txtItemName);
            panel4.Controls.Add(txtItemId);
            panel4.Controls.Add(statusLbl);
            panel4.Controls.Add(priceLbl);
            panel4.Controls.Add(prdctNameLbl);
            panel4.Controls.Add(stockLbl);
            panel4.Controls.Add(prdctlbl);
            panel4.Location = new Point(1, 445);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1029, 275);
            panel4.TabIndex = 3;
            // 
            // RefreshBtn
            // 
            RefreshBtn.BackColor = Color.FromArgb(189, 196, 212);
            RefreshBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RefreshBtn.ForeColor = Color.FromArgb(15, 26, 43);
            RefreshBtn.Location = new Point(667, 211);
            RefreshBtn.Margin = new Padding(2, 3, 2, 3);
            RefreshBtn.Name = "RefreshBtn";
            RefreshBtn.Size = new Size(132, 45);
            RefreshBtn.TabIndex = 29;
            RefreshBtn.Text = "Refresh";
            RefreshBtn.UseVisualStyleBackColor = false;
            RefreshBtn.Click += RefreshBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(111, 147);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 27);
            label1.TabIndex = 26;
            label1.Text = "Type:";
            // 
            // cmbItemType
            // 
            cmbItemType.FormattingEnabled = true;
            cmbItemType.Items.AddRange(new object[] { "Available", "Unavailabe" });
            cmbItemType.Location = new Point(203, 144);
            cmbItemType.Margin = new Padding(3, 4, 3, 4);
            cmbItemType.Name = "cmbItemType";
            cmbItemType.Size = new Size(207, 28);
            cmbItemType.TabIndex = 25;
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
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(189, 196, 212);
            btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.FromArgb(15, 26, 43);
            btnClear.Location = new Point(473, 211);
            btnClear.Margin = new Padding(2, 3, 2, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(127, 45);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(189, 196, 212);
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.FromArgb(15, 26, 43);
            btnUpdate.Location = new Point(275, 211);
            btnUpdate.Margin = new Padding(2, 3, 2, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(117, 45);
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
            btnAdd.Location = new Point(85, 211);
            btnAdd.Margin = new Padding(2, 3, 2, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(117, 45);
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
            txtItemPrice.KeyPress += txtItemPrice_KeyPress;
            // 
            // txtItemStock
            // 
            txtItemStock.Location = new Point(621, 44);
            txtItemStock.Margin = new Padding(3, 4, 3, 4);
            txtItemStock.Name = "txtItemStock";
            txtItemStock.Size = new Size(145, 27);
            txtItemStock.TabIndex = 14;
            txtItemStock.KeyPress += txtItemStock_KeyPress;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(203, 92);
            txtItemName.Margin = new Padding(3, 4, 3, 4);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(207, 27);
            txtItemName.TabIndex = 12;
            // 
            // txtItemId
            // 
            txtItemId.Location = new Point(203, 44);
            txtItemId.Margin = new Padding(3, 4, 3, 4);
            txtItemId.Name = "txtItemId";
            txtItemId.Size = new Size(207, 27);
            txtItemId.TabIndex = 11;
            // 
            // statusLbl
            // 
            statusLbl.AutoSize = true;
            statusLbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statusLbl.ForeColor = Color.White;
            statusLbl.Location = new Point(543, 147);
            statusLbl.Margin = new Padding(2, 0, 2, 0);
            statusLbl.Name = "statusLbl";
            statusLbl.Size = new Size(77, 27);
            statusLbl.TabIndex = 10;
            statusLbl.Text = "Status:";
            // 
            // priceLbl
            // 
            priceLbl.AutoSize = true;
            priceLbl.BackColor = Color.FromArgb(15, 26, 43);
            priceLbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceLbl.ForeColor = Color.White;
            priceLbl.Location = new Point(554, 95);
            priceLbl.Margin = new Padding(2, 0, 2, 0);
            priceLbl.Name = "priceLbl";
            priceLbl.Size = new Size(64, 27);
            priceLbl.TabIndex = 9;
            priceLbl.Text = "Price:";
            // 
            // prdctNameLbl
            // 
            prdctNameLbl.AutoSize = true;
            prdctNameLbl.BackColor = Color.FromArgb(15, 26, 43);
            prdctNameLbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            prdctNameLbl.ForeColor = Color.White;
            prdctNameLbl.Location = new Point(25, 95);
            prdctNameLbl.Margin = new Padding(2, 0, 2, 0);
            prdctNameLbl.Name = "prdctNameLbl";
            prdctNameLbl.Size = new Size(155, 27);
            prdctNameLbl.TabIndex = 8;
            prdctNameLbl.Text = "Product Name:";
            // 
            // stockLbl
            // 
            stockLbl.AutoSize = true;
            stockLbl.BackColor = Color.FromArgb(15, 26, 43);
            stockLbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stockLbl.ForeColor = Color.White;
            stockLbl.Location = new Point(543, 44);
            stockLbl.Margin = new Padding(2, 0, 2, 0);
            stockLbl.Name = "stockLbl";
            stockLbl.Size = new Size(71, 27);
            stockLbl.TabIndex = 5;
            stockLbl.Text = "Stock:";
            // 
            // prdctlbl
            // 
            prdctlbl.AutoSize = true;
            prdctlbl.BackColor = Color.FromArgb(15, 26, 43);
            prdctlbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            prdctlbl.ForeColor = Color.White;
            prdctlbl.Location = new Point(58, 41);
            prdctlbl.Margin = new Padding(2, 0, 2, 0);
            prdctlbl.Name = "prdctlbl";
            prdctlbl.Size = new Size(120, 27);
            prdctlbl.TabIndex = 4;
            prdctlbl.Text = "Product ID:";
            // 
            // dataGridViewInventory
            // 
            dataGridViewInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInventory.BackgroundColor = Color.FromArgb(209, 207, 201);
            dataGridViewInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewInventory.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewInventory.Dock = DockStyle.Fill;
            dataGridViewInventory.Location = new Point(0, 0);
            dataGridViewInventory.Name = "dataGridViewInventory";
            dataGridViewInventory.RowHeadersWidth = 51;
            dataGridViewInventory.Size = new Size(1029, 445);
            dataGridViewInventory.TabIndex = 4;
            dataGridViewInventory.CellContentClick += dataGridViewInventory_CellContentClick;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoScrollMinSize = new Size(0, 334);
            panel1.Controls.Add(dataGridViewInventory);
            panel1.Location = new Point(1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1029, 445);
            panel1.TabIndex = 5;
            // 
            // addInventory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel4);
            Name = "addInventory";
            Size = new Size(1029, 720);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventory).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private ComboBox cmbItemStatus;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtItemPrice;
        private TextBox txtItemStock;
        private TextBox txtItemName;
        private TextBox txtItemId;
        private Label statusLbl;
        private Label priceLbl;
        private Label prdctNameLbl;
        private Label stockLbl;
        private Label prdctlbl;
        private DataGridView dataGridViewInventory;
        private Panel panel1;
        private ComboBox cmbItemType;
        private Label label1;
        private Button RefreshBtn;
    }
}
