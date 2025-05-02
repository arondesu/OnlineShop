namespace OnlineShop
{
    partial class AdminDashboardForm
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
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(18, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(877, 180);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Location = new Point(18, 221);
            panel2.Name = "panel2";
            panel2.Size = new Size(877, 302);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Chocolate;
            panel3.Location = new Point(22, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(187, 129);
            panel3.TabIndex = 1;

            // 
            // panel4
            // 
            panel4.BackColor = Color.Chocolate;
            panel4.Location = new Point(238, 25);
            panel4.Name = "panel4";
            panel4.Size = new Size(187, 129);
            panel4.TabIndex = 2;

            // 
            // panel5
            // 
            panel5.BackColor = Color.Chocolate;
            panel5.Location = new Point(453, 25);
            panel5.Name = "panel5";
            panel5.Size = new Size(187, 129);
            panel5.TabIndex = 3;
            panel5.Paint += panel5_Paint;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Chocolate;
            panel6.Location = new Point(671, 25);
            panel6.Name = "panel6";
            panel6.Size = new Size(187, 129);
            panel6.TabIndex = 4;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 26, 43);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AdminDashboardForm";
            Size = new Size(914, 540);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
    }
}
