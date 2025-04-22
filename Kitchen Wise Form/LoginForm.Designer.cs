namespace OnlineShop
{
    partial class KitchenWiseAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenWiseAdmin));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            Userlbl = new Label();
            Passlbl = new Label();
            Kwiselbl = new Label();
            loginBtn = new Button();
            iconPctbx = new PictureBox();
            btnShop = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnClose = new Label();
            ((System.ComponentModel.ISupportInitialize)iconPctbx).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(178, 148);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(142, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(178, 186);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(142, 23);
            textBox2.TabIndex = 1;
            // 
            // Userlbl
            // 
            Userlbl.AutoSize = true;
            Userlbl.Location = new Point(104, 151);
            Userlbl.Name = "Userlbl";
            Userlbl.Size = new Size(63, 15);
            Userlbl.TabIndex = 2;
            Userlbl.Text = "Username:";
            // 
            // Passlbl
            // 
            Passlbl.AutoSize = true;
            Passlbl.Location = new Point(104, 189);
            Passlbl.Name = "Passlbl";
            Passlbl.Size = new Size(60, 15);
            Passlbl.TabIndex = 3;
            Passlbl.Text = "Password:";
            // 
            // Kwiselbl
            // 
            Kwiselbl.AutoSize = true;
            Kwiselbl.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Kwiselbl.Location = new Point(98, 95);
            Kwiselbl.Name = "Kwiselbl";
            Kwiselbl.Size = new Size(229, 32);
            Kwiselbl.TabIndex = 4;
            Kwiselbl.Text = "Kitchen Wise Admin";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(246, 222);
            loginBtn.Margin = new Padding(3, 2, 3, 2);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(74, 27);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += button1_Click;
            // 
            // iconPctbx
            // 
            iconPctbx.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            iconPctbx.Location = new Point(195, 28);
            iconPctbx.Margin = new Padding(2);
            iconPctbx.Name = "iconPctbx";
            iconPctbx.Size = new Size(48, 42);
            iconPctbx.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPctbx.TabIndex = 6;
            iconPctbx.TabStop = false;
            // 
            // btnShop
            // 
            btnShop.Location = new Point(129, 325);
            btnShop.Name = "btnShop";
            btnShop.Size = new Size(168, 40);
            btnShop.TabIndex = 7;
            btnShop.Text = "SHOP NOW";
            btnShop.UseVisualStyleBackColor = true;
            btnShop.Click += btnShop_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 266);
            label1.Name = "label1";
            label1.Size = new Size(168, 15);
            label1.TabIndex = 8;
            label1.Text = "Don't have an admin account?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(149, 297);
            label2.Name = "label2";
            label2.Size = new Size(130, 15);
            label2.TabIndex = 9;
            label2.Text = "You can shop with ease";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 297);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 10;
            label3.Text = "----------------------";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(285, 297);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 11;
            label4.Text = "----------------------";
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.BackColor = Color.Chocolate;
            btnClose.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(381, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 32);
            btnClose.TabIndex = 12;
            btnClose.Text = "X";
            btnClose.Click += label5_Click;
            // 
            // KitchenWiseAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 377);
            Controls.Add(btnClose);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnShop);
            Controls.Add(iconPctbx);
            Controls.Add(loginBtn);
            Controls.Add(Kwiselbl);
            Controls.Add(Passlbl);
            Controls.Add(Userlbl);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "KitchenWiseAdmin";
            Text = "KitchenWise Admin";
            ((System.ComponentModel.ISupportInitialize)iconPctbx).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label Userlbl;
        private Label Passlbl;
        private Label Kwiselbl;
        private Button loginBtn;
        private PictureBox iconPctbx;
        private Button btnShop;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label btnClose;
    }
}