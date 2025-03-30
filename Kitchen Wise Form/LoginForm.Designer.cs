namespace OnlineShop
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            itemName = new Label();
            itemNo = new Label();
            price = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // itemName
            // 
            itemName.AutoSize = true;
            itemName.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            itemName.ForeColor = Color.Black;
            itemName.Location = new Point(199, 110);
            itemName.Name = "itemName";
            itemName.Size = new Size(87, 20);
            itemName.TabIndex = 14;
            itemName.Text = "Username:";
            // 
            // itemNo
            // 
            itemNo.AutoSize = true;
            itemNo.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            itemNo.ForeColor = Color.Black;
            itemNo.Location = new Point(199, 169);
            itemNo.Name = "itemNo";
            itemNo.Size = new Size(83, 20);
            itemNo.TabIndex = 13;
            itemNo.Text = "Password:";
            // 
            // price
            // 
            price.AutoSize = true;
            price.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            price.ForeColor = Color.Black;
            price.Location = new Point(205, 55);
            price.Name = "price";
            price.Size = new Size(124, 20);
            price.TabIndex = 15;
            price.Text = "Welcome Back!";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(199, 137);
            txtUsername.Margin = new Padding(2, 2, 2, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(106, 23);
            txtUsername.TabIndex = 26;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(199, 188);
            txtPassword.Margin = new Padding(2, 2, 2, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(106, 23);
            txtPassword.TabIndex = 27;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(208, 242);
            btnLogin.Margin = new Padding(2, 2, 2, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(78, 23);
            btnLogin.TabIndex = 28;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(508, 292);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(itemNo);
            Controls.Add(itemName);
            Controls.Add(price);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginForm";
            Text = "KitchenWise";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label itemName;
        private Label itemNo;
        private Label price;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}