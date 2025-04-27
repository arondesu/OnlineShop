namespace OnlineShop
{
    partial class AddProductForm
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
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            panel4 = new Panel();
            panel2 = new Panel();
            AddProductForm_imageView = new PictureBox();
            txtItem_status = new ComboBox();
            txtItem_type = new ComboBox();
            btnImport = new Button();
            btnClear = new Button();
            btnDelete = new Button();
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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AddProductForm_imageView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(16, 20);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(999, 402);
            panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 50);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(992, 348);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(7, 8);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(228, 36);
            label1.TabIndex = 3;
            label1.Text = "Data of Products";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(panel2);
            panel4.Controls.Add(txtItem_status);
            panel4.Controls.Add(txtItem_type);
            panel4.Controls.Add(btnImport);
            panel4.Controls.Add(btnClear);
            panel4.Controls.Add(btnDelete);
            panel4.Controls.Add(btnUpdate);
            panel4.Controls.Add(btnAdd);
            panel4.Controls.Add(txtItem_price);
            panel4.Controls.Add(txtItem_stock);
            panel4.Controls.Add(txtItem_name);
            panel4.Controls.Add(txtItem_id);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(16, 444);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(999, 274);
            panel4.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(AddProductForm_imageView);
            panel2.Location = new Point(831, 20);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(135, 134);
            panel2.TabIndex = 25;
            // 
            // AddProductForm_imageView
            // 
            AddProductForm_imageView.BackColor = Color.Gainsboro;
            AddProductForm_imageView.Location = new Point(0, 0);
            AddProductForm_imageView.Margin = new Padding(3, 4, 3, 4);
            AddProductForm_imageView.Name = "AddProductForm_imageView";
            AddProductForm_imageView.Size = new Size(135, 134);
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
            txtItem_type.Location = new Point(175, 144);
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
            btnImport.Margin = new Padding(2, 2, 2, 2);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(73, 64);
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
            btnClear.Location = new Point(675, 194);
            btnClear.Margin = new Padding(2, 2, 2, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(73, 64);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(189, 196, 212);
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.FromArgb(15, 26, 43);
            btnDelete.Location = new Point(491, 194);
            btnDelete.Margin = new Padding(2, 2, 2, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(73, 64);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(189, 196, 212);
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.FromArgb(15, 26, 43);
            btnUpdate.Location = new Point(324, 194);
            btnUpdate.Margin = new Padding(2, 2, 2, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(77, 64);
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
            btnAdd.Location = new Point(175, 194);
            btnAdd.Margin = new Padding(2, 2, 2, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(73, 64);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
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
            txtItem_name.Location = new Point(175, 92);
            txtItem_name.Margin = new Padding(3, 4, 3, 4);
            txtItem_name.Name = "txtItem_name";
            txtItem_name.Size = new Size(145, 27);
            txtItem_name.TabIndex = 12;
            // 
            // txtItem_id
            // 
            txtItem_id.Location = new Point(175, 44);
            txtItem_id.Margin = new Padding(3, 4, 3, 4);
            txtItem_id.Name = "txtItem_id";
            txtItem_id.Size = new Size(145, 27);
            txtItem_id.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(543, 146);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(77, 27);
            label8.TabIndex = 10;
            label8.Text = "Status:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(554, 94);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(64, 27);
            label7.TabIndex = 9;
            label7.Text = "Price:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(25, 94);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(155, 27);
            label6.TabIndex = 8;
            label6.Text = "Product Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(111, 146);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 27);
            label4.TabIndex = 6;
            label4.Text = "Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(550, 46);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(71, 27);
            label3.TabIndex = 5;
            label3.Text = "Stock:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(58, 42);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 27);
            label2.TabIndex = 4;
            label2.Text = "Product ID:";
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel4);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddProductForm";
            Size = new Size(1029, 742);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AddProductForm_imageView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Label label1;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
        private Label label8;
        private TextBox txtItem_price;
        private TextBox txtItem_stock;
        private TextBox txtItem_name;
        private TextBox txtItem_id;
        private Button btnImport;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private ComboBox txtItem_type;
        private ComboBox txtItem_status;
        private Panel panel2;
        private PictureBox AddProductForm_imageView;
        private DataGridView dataGridView1;
    }
}
