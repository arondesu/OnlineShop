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
            btnLogin = new Button();
            iconPctbx = new PictureBox();
            btnShop = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnClose = new Label();
            ((System.ComponentModel.ISupportInitialize)iconPctbx).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(196, 218);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 27);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(196, 269);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(170, 27);
            textBox2.TabIndex = 1;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // Userlbl
            // 
            Userlbl.AutoSize = true;
            Userlbl.Location = new Point(107, 221);
            Userlbl.Name = "Userlbl";
            Userlbl.Size = new Size(78, 20);
            Userlbl.TabIndex = 2;
            Userlbl.Text = "Username:";
            // 
            // Passlbl
            // 
            Passlbl.AutoSize = true;
            Passlbl.Location = new Point(107, 269);
            Passlbl.Name = "Passlbl";
            Passlbl.Size = new Size(73, 20);
            Passlbl.TabIndex = 3;
            Passlbl.Text = "Password:";
            // 
            // Kwiselbl
            // 
            Kwiselbl.AutoSize = true;
            Kwiselbl.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Kwiselbl.Location = new Point(112, 127);
            Kwiselbl.Name = "Kwiselbl";
            Kwiselbl.Size = new Size(283, 41);
            Kwiselbl.TabIndex = 4;
            Kwiselbl.Text = "Kitchen Wise Admin";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(280, 313);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(85, 36);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button1_Click;
            // 
            // iconPctbx
            // 
            iconPctbx.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            iconPctbx.Location = new Point(215, 37);
            iconPctbx.Margin = new Padding(2, 3, 2, 3);
            iconPctbx.Name = "iconPctbx";
            iconPctbx.Size = new Size(84, 77);
            iconPctbx.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPctbx.TabIndex = 6;
            iconPctbx.TabStop = false;
            // 
            // btnShop
            // 
            btnShop.BackColor = Color.FromArgb(15, 26, 43);
            btnShop.ForeColor = Color.White;
            btnShop.Location = new Point(170, 456);
            btnShop.Margin = new Padding(3, 4, 3, 4);
            btnShop.Name = "btnShop";
            btnShop.Size = new Size(186, 41);
            btnShop.TabIndex = 7;
            btnShop.Text = "SHOP NOW";
            btnShop.UseVisualStyleBackColor = false;
            btnShop.Click += btnShop_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(170, 396);
            label2.Name = "label2";
            label2.Size = new Size(162, 20);
            label2.TabIndex = 9;
            label2.Text = "You can shop with ease";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 396);
            label3.Name = "label3";
            label3.Size = new Size(141, 20);
            label3.TabIndex = 10;
            label3.Text = "----------------------";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(326, 396);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 11;
            label4.Text = "----------------------";
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.BackColor = Color.Chocolate;
            btnClose.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(474, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(38, 41);
            btnClose.TabIndex = 12;
            btnClose.Text = "X";
            btnClose.Click += label5_Click;
            // 
            // KitchenWiseAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 530);
            Controls.Add(btnClose);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnShop);
            Controls.Add(iconPctbx);
            Controls.Add(btnLogin);
            Controls.Add(Kwiselbl);
            Controls.Add(Passlbl);
            Controls.Add(Userlbl);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Button btnLogin;
        private PictureBox iconPctbx;
        private Button btnShop;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label btnClose;
    }
}