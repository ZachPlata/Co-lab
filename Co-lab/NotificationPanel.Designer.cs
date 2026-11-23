namespace Co_LAB
{
    partial class NotificationPanel
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
            pnlHeader = new Panel();
            lblHeader = new Label();
            btnMarkAllRead = new Button();
            btnClose = new Button();
            flpList = new FlowLayoutPanel();
            lblEmpty = new Label();
            pnlHeader.SuspendLayout();
            flpList.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(20, 28, 23);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Controls.Add(btnMarkAllRead);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(12, 8, 12, 8);
            pnlHeader.Size = new Size(380, 44);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(74, 222, 128);
            lblHeader.Location = new Point(12, 11);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(106, 19);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "🔔 Notifications";
            // 
            // btnMarkAllRead
            // 
            btnMarkAllRead.AutoSize = true;
            btnMarkAllRead.BackColor = Color.Transparent;
            btnMarkAllRead.Cursor = Cursors.Hand;
            btnMarkAllRead.FlatAppearance.BorderSize = 0;
            btnMarkAllRead.FlatStyle = FlatStyle.Flat;
            btnMarkAllRead.Font = new Font("Segoe UI", 8F);
            btnMarkAllRead.ForeColor = Color.FromArgb(161, 161, 170);
            btnMarkAllRead.Location = new Point(230, 9);
            btnMarkAllRead.Name = "btnMarkAllRead";
            btnMarkAllRead.Size = new Size(86, 26);
            btnMarkAllRead.TabIndex = 1;
            btnMarkAllRead.Text = "Mark all read";
            btnMarkAllRead.UseVisualStyleBackColor = false;
            btnMarkAllRead.Click += btnMarkAllRead_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(161, 161, 170);
            btnClose.Location = new Point(345, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(26, 26);
            btnClose.TabIndex = 2;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // flpList
            // 
            flpList.AutoScroll = true;
            flpList.BackColor = Color.FromArgb(14, 19, 16);
            flpList.Dock = DockStyle.Fill;
            flpList.FlowDirection = FlowDirection.TopDown;
            flpList.Location = new Point(0, 44);
            flpList.Name = "flpList";
            flpList.Padding = new Padding(8);
            flpList.Size = new Size(380, 396);
            flpList.TabIndex = 1;
            flpList.WrapContents = false;
            // 
            // lblEmpty
            // 
            lblEmpty.BackColor = Color.FromArgb(14, 19, 16);
            lblEmpty.Dock = DockStyle.Fill;
            lblEmpty.Font = new Font("Segoe UI", 9.5F);
            lblEmpty.ForeColor = Color.FromArgb(140, 150, 142);
            lblEmpty.Location = new Point(0, 44);
            lblEmpty.Name = "lblEmpty";
            lblEmpty.Size = new Size(380, 396);
            lblEmpty.TabIndex = 2;
            lblEmpty.Text = "No notifications yet.\nYou're all caught up! ✨";
            lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblEmpty.Visible = false;
            // 
            // NotificationPanel
            // 
            BackColor = Color.FromArgb(16, 22, 18);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblEmpty);
            Controls.Add(flpList);
            Controls.Add(pnlHeader);
            Name = "NotificationPanel";
            Size = new Size(380, 440);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            flpList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpList;
        private Label lblHeader;
        private Button btnMarkAllRead;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblEmpty;
    }
}
