namespace Co_LAB
{
    partial class uc_TradeRequests
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            pnlTabIndicator = new Panel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(24, 24, 27);
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(950, 600);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(28, 28, 33);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9.5F);
            button1.ForeColor = Color.FromArgb(16, 185, 129);
            button1.Location = new Point(5, 0);
            button1.Name = "button1";
            button1.Size = new Size(175, 29);
            button1.TabIndex = 1;
            button1.Text = "Incoming Requests";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 9.5F);
            button2.ForeColor = Color.FromArgb(161, 161, 170);
            button2.Location = new Point(184, 0);
            button2.Name = "button2";
            button2.Size = new Size(160, 29);
            button2.TabIndex = 2;
            button2.Text = "Sent Requests";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pnlTabIndicator
            // 
            pnlTabIndicator.BackColor = Color.FromArgb(16, 185, 129);
            pnlTabIndicator.Location = new Point(5, 29);
            pnlTabIndicator.Name = "pnlTabIndicator";
            pnlTabIndicator.Size = new Size(175, 3);
            pnlTabIndicator.TabIndex = 3;
            // 
            // uc_TradeRequests
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(pnlTabIndicator);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            ForeColor = SystemColors.Window;
            Name = "uc_TradeRequests";
            Size = new Size(950, 632);
            Load += uc_TradeRequests_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button button2;
        private Panel pnlTabIndicator;
    }
}
