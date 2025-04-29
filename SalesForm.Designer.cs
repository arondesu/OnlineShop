namespace OnlineShop
{
    partial class SalesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesForm));
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            cashierOrderForm_payBtn = new Button();
            label13 = new Label();
            cashierOrderForm_amount = new TextBox();
            label11 = new Label();
            cashierOrderForm_change = new Label();
            cashierOrderForm_orderPrice = new Label();
            label10 = new Label();
            printPreviewDialog1 = new PrintPreviewDialog();
            panel3 = new Panel();
            cashierOrderForm_receiptBtn = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            label1 = new Label();
            cashierOrderForm_menuTable = new DataGridView();
            panel1 = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cashierOrderForm_menuTable).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cashierOrderForm_payBtn
            // 
            cashierOrderForm_payBtn.BackColor = Color.FromArgb(7, 99, 102);
            cashierOrderForm_payBtn.FlatStyle = FlatStyle.Flat;
            cashierOrderForm_payBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cashierOrderForm_payBtn.ForeColor = Color.White;
            cashierOrderForm_payBtn.Location = new Point(444, 48);
            cashierOrderForm_payBtn.Margin = new Padding(4, 3, 4, 3);
            cashierOrderForm_payBtn.Name = "cashierOrderForm_payBtn";
            cashierOrderForm_payBtn.Size = new Size(145, 49);
            cashierOrderForm_payBtn.TabIndex = 29;
            cashierOrderForm_payBtn.Text = "PAY";
            cashierOrderForm_payBtn.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(28, 109);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(92, 17);
            label13.TabIndex = 25;
            label13.Text = "Change ($):";
            // 
            // cashierOrderForm_amount
            // 
            cashierOrderForm_amount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cashierOrderForm_amount.Location = new Point(144, 59);
            cashierOrderForm_amount.Margin = new Padding(4, 3, 4, 3);
            cashierOrderForm_amount.Name = "cashierOrderForm_amount";
            cashierOrderForm_amount.Size = new Size(47, 26);
            cashierOrderForm_amount.TabIndex = 28;

            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(28, 64);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(92, 17);
            label11.TabIndex = 27;
            label11.Text = "Amount ($):";

            // 
            // cashierOrderForm_change
            // 
            cashierOrderForm_change.AutoSize = true;
            cashierOrderForm_change.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cashierOrderForm_change.Location = new Point(144, 109);
            cashierOrderForm_change.Margin = new Padding(4, 0, 4, 0);
            cashierOrderForm_change.Name = "cashierOrderForm_change";
            cashierOrderForm_change.Size = new Size(17, 17);
            cashierOrderForm_change.TabIndex = 26;
            cashierOrderForm_change.Text = "0";

            // 
            // cashierOrderForm_orderPrice
            // 
            cashierOrderForm_orderPrice.AutoSize = true;
            cashierOrderForm_orderPrice.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cashierOrderForm_orderPrice.Location = new Point(144, 25);
            cashierOrderForm_orderPrice.Margin = new Padding(4, 0, 4, 0);
            cashierOrderForm_orderPrice.Name = "cashierOrderForm_orderPrice";
            cashierOrderForm_orderPrice.Size = new Size(17, 17);
            cashierOrderForm_orderPrice.TabIndex = 26;
            cashierOrderForm_orderPrice.Text = "0";

            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(28, 25);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(75, 17);
            label10.TabIndex = 25;
            label10.Text = "Price ($):";

            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(cashierOrderForm_receiptBtn);
            panel3.Controls.Add(cashierOrderForm_payBtn);
            panel3.Controls.Add(cashierOrderForm_change);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(cashierOrderForm_amount);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(cashierOrderForm_orderPrice);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(4, 407);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(888, 146);
            panel3.TabIndex = 5;
            // 
            // cashierOrderForm_receiptBtn
            // 
            cashierOrderForm_receiptBtn.BackColor = Color.FromArgb(7, 99, 102);
            cashierOrderForm_receiptBtn.FlatStyle = FlatStyle.Flat;
            cashierOrderForm_receiptBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cashierOrderForm_receiptBtn.ForeColor = Color.White;
            cashierOrderForm_receiptBtn.Location = new Point(597, 48);
            cashierOrderForm_receiptBtn.Margin = new Padding(4, 3, 4, 3);
            cashierOrderForm_receiptBtn.Name = "cashierOrderForm_receiptBtn";
            cashierOrderForm_receiptBtn.Size = new Size(145, 49);
            cashierOrderForm_receiptBtn.TabIndex = 30;
            cashierOrderForm_receiptBtn.Text = "RECEIPT";
            cashierOrderForm_receiptBtn.UseVisualStyleBackColor = false;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 22);
            label1.TabIndex = 3;
            label1.Text = "Menu";
            // 
            // cashierOrderForm_menuTable
            // 
            cashierOrderForm_menuTable.AllowUserToAddRows = false;
            cashierOrderForm_menuTable.AllowUserToDeleteRows = false;
            cashierOrderForm_menuTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cashierOrderForm_menuTable.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(7, 99, 102);
            dataGridViewCellStyle7.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            cashierOrderForm_menuTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            cashierOrderForm_menuTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cashierOrderForm_menuTable.EnableHeadersVisualStyles = false;
            cashierOrderForm_menuTable.Location = new Point(4, 49);
            cashierOrderForm_menuTable.Margin = new Padding(4, 3, 4, 3);
            cashierOrderForm_menuTable.Name = "cashierOrderForm_menuTable";
            cashierOrderForm_menuTable.ReadOnly = true;
            cashierOrderForm_menuTable.RowHeadersVisible = false;
            cashierOrderForm_menuTable.Size = new Size(884, 346);
            cashierOrderForm_menuTable.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cashierOrderForm_menuTable);
            panel1.Location = new Point(4, 3);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(892, 398);
            panel1.TabIndex = 3;
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "SaleForm";
            Size = new Size(900, 556);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cashierOrderForm_menuTable).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button cashierOrderForm_payBtn;
        private Label label13;
        private TextBox cashierOrderForm_amount;
        private Label label11;
        private Label cashierOrderForm_change;
        private Label cashierOrderForm_orderPrice;
        private Label label10;
        private PrintPreviewDialog printPreviewDialog1;
        private Panel panel3;
        private Button cashierOrderForm_receiptBtn;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Label label1;
        private DataGridView cashierOrderForm_menuTable;
        private Panel panel1;
    }
}
