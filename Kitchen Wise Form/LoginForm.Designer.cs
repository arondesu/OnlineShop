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
            txtUser = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // itemName
            // 
            itemName.AutoSize = true;
            itemName.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            itemName.ForeColor = Color.Black;
            itemName.Location = new Point(284, 183);
            itemName.Margin = new Padding(4, 0, 4, 0);
            itemName.Name = "itemName";
            itemName.Size = new Size(125, 30);
            itemName.TabIndex = 14;
            itemName.Text = "Username:";
            // 
            // itemNo
            // 
            itemNo.AutoSize = true;
            itemNo.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            itemNo.ForeColor = Color.Black;
            itemNo.Location = new Point(284, 281);
            itemNo.Margin = new Padding(4, 0, 4, 0);
            itemNo.Name = "itemNo";
            itemNo.Size = new Size(118, 30);
            itemNo.TabIndex = 13;
            itemNo.Text = "Password:";
            // 
            // price
            // 
            price.AutoSize = true;
            price.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            price.ForeColor = Color.Black;
            price.Location = new Point(293, 92);
            price.Margin = new Padding(4, 0, 4, 0);
            price.Name = "price";
            price.Size = new Size(175, 30);
            price.TabIndex = 15;
            price.Text = "Welcome Back!";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(284, 229);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(150, 31);
            txtUser.TabIndex = 26;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(284, 314);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(150, 31);
            txtPass.TabIndex = 27;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(297, 404);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 28;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(726, 487);
            Controls.Add(btnLogin);
            Controls.Add(txtPass);
            Controls.Add(txtUser);
            Controls.Add(itemNo);
            Controls.Add(itemName);
            Controls.Add(price);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "LoginForm";
            Text = "KitchenWise";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label itemName;
        private Label itemNo;
        private Label price;
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogin;
    }
}