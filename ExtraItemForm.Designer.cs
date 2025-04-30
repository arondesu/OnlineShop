namespace OnlineShop
{
    partial class ExtraItemForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraItemForm));
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            label1 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            cashierOrderForm_payBtn = new Button();
            moreProductList = new DataGridView();
            dBFuncBindingSource = new BindingSource(components);
            panel2 = new Panel();
            bck_btn = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)moreProductList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dBFuncBindingSource).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 13);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(232, 33);
            label1.TabIndex = 3;
            label1.Text = "More Products:";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(moreProductList);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(6, 5, 6, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1113, 1797);
            panel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(cashierOrderForm_payBtn);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(714, 56);
            panel3.Margin = new Padding(6, 5, 6, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(399, 1741);
            panel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.WindowFrame;
            pictureBox1.Location = new Point(44, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(310, 258);
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // cashierOrderForm_payBtn
            // 
            cashierOrderForm_payBtn.BackColor = Color.FromArgb(7, 99, 102);
            cashierOrderForm_payBtn.FlatStyle = FlatStyle.Flat;
            cashierOrderForm_payBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cashierOrderForm_payBtn.ForeColor = Color.White;
            cashierOrderForm_payBtn.Location = new Point(98, 521);
            cashierOrderForm_payBtn.Margin = new Padding(6, 5, 6, 5);
            cashierOrderForm_payBtn.Name = "cashierOrderForm_payBtn";
            cashierOrderForm_payBtn.Size = new Size(207, 82);
            cashierOrderForm_payBtn.TabIndex = 29;
            cashierOrderForm_payBtn.Text = "BUY";
            cashierOrderForm_payBtn.UseVisualStyleBackColor = false;
            // 
            // moreProductList
            // 
            moreProductList.AutoGenerateColumns = false;
            moreProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            moreProductList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            moreProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            moreProductList.DataSource = dBFuncBindingSource;
            moreProductList.Dock = DockStyle.Left;
            moreProductList.Location = new Point(0, 56);
            moreProductList.Name = "moreProductList";
            moreProductList.RowHeadersWidth = 62;
            moreProductList.Size = new Size(710, 1741);
            moreProductList.TabIndex = 4;
            // 
            // dBFuncBindingSource
            // 
            dBFuncBindingSource.DataSource = typeof(DBFunc);
            // 
            // panel2
            // 
            panel2.BackColor = Color.Wheat;
            panel2.Controls.Add(bck_btn);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1113, 56);
            panel2.TabIndex = 6;
            // 
            // bck_btn
            // 
            bck_btn.AutoSize = true;
            bck_btn.BackColor = Color.Chocolate;
            bck_btn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bck_btn.ForeColor = SystemColors.ControlLightLight;
            bck_btn.Location = new Point(1073, 6);
            bck_btn.Margin = new Padding(4, 0, 4, 0);
            bck_btn.Name = "bck_btn";
            bck_btn.Size = new Size(36, 40);
            bck_btn.TabIndex = 4;
            bck_btn.Text = "X";
            bck_btn.Click += bck_btn_Click;
            // 
            // ExtraItemForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ExtraItemForm";
            Size = new Size(1113, 1797);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)moreProductList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dBFuncBindingSource).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Label label1;
        private Panel panel1;
        private DataGridView moreProductList;
        private BindingSource dBFuncBindingSource;
        private Button cashierOrderForm_payBtn;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Panel panel2;
        private Label bck_btn;
    }
}
