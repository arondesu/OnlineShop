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
            panel1.Controls.Add(button7);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1144, 83);
            panel1.TabIndex = 27;
            // 
            // button7
            // 
            button7.Location = new Point(900, 37);
            button7.Margin = new Padding(2);
            button7.Name = "button7";
            button7.Size = new Size(78, 20);
            button7.TabIndex = 6;
            button7.Text = "Sales";
            button7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 37);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(55, 21);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 45);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(homePanel);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(210, 83);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(934, 572);
            panel2.TabIndex = 28;
            // 
            // homePanel
            // 
            homePanel.BackColor = SystemColors.ControlDarkDark;
            homePanel.Controls.Add(homeDataGrid);
            homePanel.Controls.Add(salesDataGrid);
            homePanel.Controls.Add(label2);
            homePanel.Location = new Point(5, 5);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(926, 564);
            homePanel.TabIndex = 0;
            // 
            // homeDataGrid
            // 
            homeDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            homeDataGrid.Location = new Point(3, 3);
            homeDataGrid.Name = "homeDataGrid";
            homeDataGrid.Size = new Size(920, 558);
            homeDataGrid.TabIndex = 0;
            // 
            // salesDataGrid
            // 
            salesDataGrid.AutoGenerateColumns = false;
            salesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            salesDataGrid.DataSource = dBFuncBindingSource;
            salesDataGrid.Location = new Point(3, 3);
            salesDataGrid.Name = "salesDataGrid";
            salesDataGrid.Size = new Size(655, 353);
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
            label2.Location = new Point(177, 128);
            label2.Name = "label2";
            label2.Size = new Size(342, 58);
            label2.TabIndex = 2;
            label2.Text = "INVENTORY";
            // 
            // panel3
            // 
            panel3.Controls.Add(salesBtn);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(homeBtn);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 83);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(210, 572);
            panel3.TabIndex = 28;
            // 
            // salesBtn
            // 
            salesBtn.Location = new Point(65, 325);
            salesBtn.Margin = new Padding(2);
            salesBtn.Name = "salesBtn";
            salesBtn.Size = new Size(78, 20);
            salesBtn.TabIndex = 5;
            salesBtn.Text = "Sales";
            salesBtn.UseVisualStyleBackColor = true;
            salesBtn.Click += salesBtn_Click;
            // 
            // button5
            // 
            button5.Location = new Point(65, 254);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(78, 20);
            button5.TabIndex = 4;
            button5.Text = "Customers";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(65, 199);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(78, 20);
            button4.TabIndex = 3;
            button4.Text = "Purchases";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(65, 142);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(78, 20);
            button3.TabIndex = 2;
            button3.Text = "Products";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(65, 88);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(78, 20);
            button2.TabIndex = 1;
            button2.Text = "Category";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // homeBtn
            // 
            homeBtn.Location = new Point(65, 31);
            homeBtn.Margin = new Padding(2);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(78, 20);
            homeBtn.TabIndex = 0;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = true;
            homeBtn.Click += homeBtn_Click;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 655);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
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
    }
}