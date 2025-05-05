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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel4 = new Panel();
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
            cmbItemType = new ComboBox();
            label1 = new Label();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventory).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(15, 26, 43);
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
            panel4.Location = new Point(1, 334);
            panel4.Name = "panel4";
            panel4.Size = new Size(900, 206);
            panel4.TabIndex = 3;
            // 
            // cmbItemStatus
            // 
            cmbItemStatus.FormattingEnabled = true;
            cmbItemStatus.Items.AddRange(new object[] { "Available", "Unavailabe" });
            cmbItemStatus.Location = new Point(543, 108);
            cmbItemStatus.Name = "cmbItemStatus";
            cmbItemStatus.Size = new Size(127, 23);
            cmbItemStatus.TabIndex = 24;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(189, 196, 212);
            btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.FromArgb(15, 26, 43);
            btnClear.Location = new Point(559, 158);
            btnClear.Margin = new Padding(2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(111, 34);
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
            btnUpdate.Location = new Point(368, 158);
            btnUpdate.Margin = new Padding(2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(102, 34);
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
            btnAdd.Location = new Point(178, 158);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(102, 34);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtItemPrice
            // 
            txtItemPrice.Location = new Point(543, 69);
            txtItemPrice.Name = "txtItemPrice";
            txtItemPrice.Size = new Size(127, 23);
            txtItemPrice.TabIndex = 15;
            // 
            // txtItemStock
            // 
            txtItemStock.Location = new Point(543, 33);
            txtItemStock.Name = "txtItemStock";
            txtItemStock.Size = new Size(127, 23);
            txtItemStock.TabIndex = 14;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(178, 69);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(182, 23);
            txtItemName.TabIndex = 12;
            // 
            // txtItemId
            // 
            txtItemId.Location = new Point(178, 33);
            txtItemId.Name = "txtItemId";
            txtItemId.Size = new Size(182, 23);
            txtItemId.TabIndex = 11;
            // 
            // statusLbl
            // 
            statusLbl.AutoSize = true;
            statusLbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statusLbl.ForeColor = Color.White;
            statusLbl.Location = new Point(475, 110);
            statusLbl.Margin = new Padding(2, 0, 2, 0);
            statusLbl.Name = "statusLbl";
            statusLbl.Size = new Size(63, 21);
            statusLbl.TabIndex = 10;
            statusLbl.Text = "Status:";
            // 
            // priceLbl
            // 
            priceLbl.AutoSize = true;
            priceLbl.BackColor = Color.FromArgb(15, 26, 43);
            priceLbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceLbl.ForeColor = Color.White;
            priceLbl.Location = new Point(485, 71);
            priceLbl.Margin = new Padding(2, 0, 2, 0);
            priceLbl.Name = "priceLbl";
            priceLbl.Size = new Size(53, 21);
            priceLbl.TabIndex = 9;
            priceLbl.Text = "Price:";
            // 
            // prdctNameLbl
            // 
            prdctNameLbl.AutoSize = true;
            prdctNameLbl.BackColor = Color.FromArgb(15, 26, 43);
            prdctNameLbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            prdctNameLbl.ForeColor = Color.White;
            prdctNameLbl.Location = new Point(22, 71);
            prdctNameLbl.Margin = new Padding(2, 0, 2, 0);
            prdctNameLbl.Name = "prdctNameLbl";
            prdctNameLbl.Size = new Size(126, 21);
            prdctNameLbl.TabIndex = 8;
            prdctNameLbl.Text = "Product Name:";
            // 
            // stockLbl
            // 
            stockLbl.AutoSize = true;
            stockLbl.BackColor = Color.FromArgb(15, 26, 43);
            stockLbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stockLbl.ForeColor = Color.White;
            stockLbl.Location = new Point(475, 33);
            stockLbl.Margin = new Padding(2, 0, 2, 0);
            stockLbl.Name = "stockLbl";
            stockLbl.Size = new Size(57, 21);
            stockLbl.TabIndex = 5;
            stockLbl.Text = "Stock:";
            // 
            // prdctlbl
            // 
            prdctlbl.AutoSize = true;
            prdctlbl.BackColor = Color.FromArgb(15, 26, 43);
            prdctlbl.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            prdctlbl.ForeColor = Color.White;
            prdctlbl.Location = new Point(51, 31);
            prdctlbl.Margin = new Padding(2, 0, 2, 0);
            prdctlbl.Name = "prdctlbl";
            prdctlbl.Size = new Size(97, 21);
            prdctlbl.TabIndex = 4;
            prdctlbl.Text = "Product ID:";
            // 
            // dataGridViewInventory
            // 
            dataGridViewInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInventory.BackgroundColor = Color.FromArgb(209, 207, 201);
            dataGridViewInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewInventory.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewInventory.Location = new Point(-1, 0);
            dataGridViewInventory.Margin = new Padding(3, 2, 3, 2);
            dataGridViewInventory.Name = "dataGridViewInventory";
            dataGridViewInventory.RowHeadersWidth = 51;
            dataGridViewInventory.Size = new Size(900, 346);
            dataGridViewInventory.TabIndex = 4;
            dataGridViewInventory.CellContentClick += dataGridViewInventory_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridViewInventory);
            panel1.Location = new Point(1, -1);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 334);
            panel1.TabIndex = 5;
            // 
            // cmbItemType
            // 
            cmbItemType.FormattingEnabled = true;
            cmbItemType.Items.AddRange(new object[] { "Available", "Unavailabe" });
            cmbItemType.Location = new Point(178, 108);
            cmbItemType.Name = "cmbItemType";
            cmbItemType.Size = new Size(182, 23);
            cmbItemType.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(97, 110);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(51, 21);
            label1.TabIndex = 26;
            label1.Text = "Type:";
            // 
            // addInventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel4);
            Margin = new Padding(3, 2, 3, 2);
            Name = "addInventory";
            Size = new Size(900, 540);
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
    }
}
