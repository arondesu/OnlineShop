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
            ((System.ComponentModel.ISupportInitialize)iconPctbx).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(296, 185);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(211, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(296, 253);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(211, 27);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // Userlbl
            // 
            Userlbl.AutoSize = true;
            Userlbl.Location = new Point(211, 190);
            Userlbl.Name = "Userlbl";
            Userlbl.Size = new Size(78, 20);
            Userlbl.TabIndex = 2;
            Userlbl.Text = "Username:";
            Userlbl.Click += Userlbl_Click;
            // 
            // Passlbl
            // 
            Passlbl.AutoSize = true;
            Passlbl.Location = new Point(211, 257);
            Passlbl.Name = "Passlbl";
            Passlbl.Size = new Size(73, 20);
            Passlbl.TabIndex = 3;
            Passlbl.Text = "Password:";
            Passlbl.Click += Passlbl_Click;
            // 
            // Kwiselbl
            // 
            Kwiselbl.AutoSize = true;
            Kwiselbl.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Kwiselbl.Location = new Point(261, 83);
            Kwiselbl.Name = "Kwiselbl";
            Kwiselbl.Size = new Size(275, 41);
            Kwiselbl.TabIndex = 4;
            Kwiselbl.Text = "KitchenWise Admin";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(333, 317);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(134, 36);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += button1_Click;
            // 
            // iconPctbx
            // 
            iconPctbx.Image = Properties.Resources._1486504353_cart_ecommerce_shop_commerce_supermarket_trolley_shopping_81310;
            iconPctbx.Location = new Point(185, 77);
            iconPctbx.Margin = new Padding(2, 3, 2, 3);
            iconPctbx.Name = "iconPctbx";
            iconPctbx.Size = new Size(55, 56);
            iconPctbx.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPctbx.TabIndex = 6;
            iconPctbx.TabStop = false;
            // 
            // KitchenWiseAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(iconPctbx);
            Controls.Add(loginBtn);
            Controls.Add(Kwiselbl);
            Controls.Add(Passlbl);
            Controls.Add(Userlbl);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
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
        private Button loginBtn;
        private PictureBox iconPctbx;
    }
}