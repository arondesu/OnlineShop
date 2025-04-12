namespace OnlineShop
{
    partial class InventoryForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            panel1 = new Panel();
            button7 = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            homePanel = new Panel();
            homeDataGrid = new DataGridView();
            salesDataGrid = new DataGridView();
            dBFuncBindingSource = new BindingSource(components);
            label2 = new Label();
            panel3 = new Panel();
            button1 = new Button();
            salesBtn = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            homeBtn = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            homePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)homeDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)salesDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dBFuncBindingSource).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(15, 26, 43);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1304, 111);
            panel1.TabIndex = 27;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(82, 103, 125);
            button7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(1144, 28);
            button7.Margin = new Padding(2, 3, 2, 3);
            button7.Name = "button7";
            button7.Size = new Size(127, 48);
            button7.TabIndex = 6;
            button7.Text = "Sales";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(229, 49);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(63, 28);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 60);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(homePanel);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(235, 111);
            panel2.Margin = new Padding(2, 3, 2, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1069, 741);
            panel2.TabIndex = 28;
            // 
            // homePanel
            // 
            homePanel.BackColor = Color.FromArgb(209, 207, 201);
            homePanel.Controls.Add(homeDataGrid);
            homePanel.Controls.Add(salesDataGrid);
            homePanel.Controls.Add(label2);
            homePanel.Location = new Point(6, 0);
            homePanel.Margin = new Padding(3, 4, 3, 4);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1058, 759);
            homePanel.TabIndex = 0;
            // 
            // homeDataGrid
            // 
            homeDataGrid.BackgroundColor = Color.FromArgb(209, 207, 201);
            homeDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            homeDataGrid.Location = new Point(-6, 0);
            homeDataGrid.Margin = new Padding(3, 4, 3, 4);
            homeDataGrid.Name = "homeDataGrid";
            homeDataGrid.RowHeadersWidth = 51;
            homeDataGrid.Size = new Size(1040, 762);
            homeDataGrid.TabIndex = 0;
            // 
            // salesDataGrid
            // 
            salesDataGrid.AutoGenerateColumns = false;
            salesDataGrid.BackgroundColor = Color.FromArgb(209, 207, 201);
            salesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            salesDataGrid.DataSource = dBFuncBindingSource;
            salesDataGrid.Location = new Point(-17, -7);
            salesDataGrid.Margin = new Padding(3, 4, 3, 4);
            salesDataGrid.Name = "salesDataGrid";
            salesDataGrid.RowHeadersWidth = 51;
            salesDataGrid.Size = new Size(769, 482);
            salesDataGrid.TabIndex = 1;
            // 
            // dBFuncBindingSource
            // 
            dBFuncBindingSource.DataSource = typeof(DBFunc);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Perpetua Titling MT", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(202, 171);
            label2.Name = "label2";
            label2.Size = new Size(422, 72);
            label2.TabIndex = 2;
            label2.Text = "INVENTORY";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(15, 26, 43);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(salesBtn);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(homeBtn);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 111);
            panel3.Margin = new Padding(2, 3, 2, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 741);
            panel3.TabIndex = 28;
            panel3.Paint += panel3_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(158, 147, 114);
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(49, 666);
            button1.Name = "button1";
            button1.Size = new Size(134, 45);
            button1.TabIndex = 6;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // salesBtn
            // 
            salesBtn.BackColor = Color.FromArgb(189, 196, 212);
            salesBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            salesBtn.ForeColor = Color.FromArgb(15, 26, 43);
            salesBtn.Location = new Point(49, 442);
            salesBtn.Margin = new Padding(2, 3, 2, 3);
            salesBtn.Name = "salesBtn";
            salesBtn.Size = new Size(134, 40);
            salesBtn.TabIndex = 5;
            salesBtn.Text = "Sales";
            salesBtn.UseVisualStyleBackColor = false;
            salesBtn.Click += salesBtn_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(189, 196, 212);
            button5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.FromArgb(15, 26, 43);
            button5.Location = new Point(49, 364);
            button5.Margin = new Padding(2, 3, 2, 3);
            button5.Name = "button5";
            button5.Size = new Size(134, 43);
            button5.TabIndex = 4;
            button5.Text = "Customers";
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(189, 196, 212);
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(15, 26, 43);
            button4.Location = new Point(49, 288);
            button4.Margin = new Padding(2, 3, 2, 3);
            button4.Name = "button4";
            button4.Size = new Size(134, 44);
            button4.TabIndex = 3;
            button4.Text = "Purchases";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(189, 196, 212);
            button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(15, 26, 43);
            button3.Location = new Point(49, 209);
            button3.Margin = new Padding(2, 3, 2, 3);
            button3.Name = "button3";
            button3.Size = new Size(134, 44);
            button3.TabIndex = 2;
            button3.Text = "Products";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(189, 196, 212);
            button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(15, 26, 43);
            button2.Location = new Point(49, 127);
            button2.Margin = new Padding(2, 3, 2, 3);
            button2.Name = "button2";
            button2.Size = new Size(134, 47);
            button2.TabIndex = 1;
            button2.Text = "Category";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // homeBtn
            // 
            homeBtn.BackColor = Color.FromArgb(189, 196, 212);
            homeBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeBtn.ForeColor = Color.FromArgb(15, 26, 43);
            homeBtn.Location = new Point(49, 48);
            homeBtn.Margin = new Padding(2, 3, 2, 3);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(134, 47);
            homeBtn.TabIndex = 0;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = false;
            homeBtn.Click += homeBtn_Click;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1304, 852);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InventoryForm";
            Text = " KitchenWise";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            homePanel.ResumeLayout(false);
            homePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)homeDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)salesDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)dBFuncBindingSource).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button homeBtn;
        private Button button7;
        private Label label1;
        private PictureBox pictureBox1;
        private Button salesBtn;
        private Button button5;
        private Panel homePanel;
        private DataGridView homeDataGrid;
        private BindingSource dBFuncBindingSource;
        private DataGridView salesDataGrid;
        private Label label2;
        private Button button1;
    }
}