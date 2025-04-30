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
            btnShop = new Button();
            label2 = new Label();
            label4 = new Label();
            btnClose = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label1 = new Label();
            iconPctbx = new PictureBox();
            loginIcon = new PictureBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPctbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loginIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(624, 228);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(211, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(624, 283);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(211, 27);
            textBox2.TabIndex = 1;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // Userlbl
            // 
            Userlbl.AutoSize = true;
            Userlbl.Font = new Font("Segoe UI", 10F);
            Userlbl.Location = new Point(520, 231);
            Userlbl.Name = "Userlbl";
            Userlbl.Size = new Size(91, 23);
            Userlbl.TabIndex = 2;
            Userlbl.Text = "Username:";
            // 
            // Passlbl
            // 
            Passlbl.AutoSize = true;
            Passlbl.Font = new Font("Segoe UI", 10F);
            Passlbl.Location = new Point(525, 286);
            Passlbl.Name = "Passlbl";
            Passlbl.Size = new Size(84, 23);
            Passlbl.TabIndex = 3;
            Passlbl.Text = "Password:";
            // 
            // Kwiselbl
            // 
            Kwiselbl.AutoSize = true;
            Kwiselbl.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Kwiselbl.Location = new Point(569, 145);
            Kwiselbl.Name = "Kwiselbl";
            Kwiselbl.Size = new Size(293, 41);
            Kwiselbl.TabIndex = 4;
            Kwiselbl.Text = "Kitchen Wise Admin";
            Kwiselbl.Click += Kwiselbl_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(82, 103, 125);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(624, 347);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(211, 43);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // btnShop
            // 
            btnShop.BackColor = Color.FromArgb(28, 46, 74);
            btnShop.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShop.ForeColor = Color.White;
            btnShop.Location = new Point(624, 498);
            btnShop.Margin = new Padding(3, 4, 3, 4);
            btnShop.Name = "btnShop";
            btnShop.Size = new Size(211, 53);
            btnShop.TabIndex = 7;
            btnShop.Text = "SHOP NOW";
            btnShop.UseVisualStyleBackColor = false;
            btnShop.Click += btnShop_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(644, 445);
            label2.Name = "label2";
            label2.Size = new Size(162, 20);
            label2.TabIndex = 9;
            label2.Text = "You can shop with ease";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(805, 445);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 11;
            label4.Text = "----------------";
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.BackColor = Color.FromArgb(138, 3, 34);
            btnClose.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(913, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(38, 41);
            btnClose.TabIndex = 12;
            btnClose.Text = "X";
            btnClose.Click += label5_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(15, 26, 43);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(iconPctbx);
            panel1.Controls.Add(loginIcon);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(463, 583);
            panel1.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(248, 34);
            label5.Name = "label5";
            label5.Size = new Size(145, 50);
            label5.TabIndex = 17;
            label5.Text = "Admin!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(75, 38);
            label1.Name = "label1";
            label1.Size = new Size(207, 46);
            label1.TabIndex = 16;
            label1.Text = "Welcome ";
            label1.Click += label1_Click;
            // 
            // iconPctbx
            // 
            iconPctbx.BackColor = Color.FromArgb(235, 238, 240);
            iconPctbx.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            iconPctbx.Location = new Point(248, 330);
            iconPctbx.Margin = new Padding(2, 3, 2, 3);
            iconPctbx.Name = "iconPctbx";
            iconPctbx.Size = new Size(42, 44);
            iconPctbx.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPctbx.TabIndex = 6;
            iconPctbx.TabStop = false;
            iconPctbx.Click += iconPctbx_Click;
            // 
            // loginIcon
            // 
            loginIcon.Image = (Image)resources.GetObject("loginIcon.Image");
            loginIcon.Location = new Point(32, 97);
            loginIcon.Margin = new Padding(2, 3, 2, 3);
            loginIcon.Name = "loginIcon";
            loginIcon.Size = new Size(418, 473);
            loginIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            loginIcon.TabIndex = 15;
            loginIcon.TabStop = false;
            loginIcon.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(664, 34);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(533, 445);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 16;
            label3.Text = "----------------";
            // 
            // KitchenWiseAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(206, 212, 218);
            ClientSize = new Size(948, 582);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(btnClose);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(btnShop);
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
            Load += KitchenWiseAdmin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPctbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)loginIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Button btnShop;
        private Label label2;
        private Label label4;
        private Label btnClose;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox loginIcon;
        private PictureBox iconPctbx;
        private Label label1;
        private Label label3;
        private Label label5;
    }
}