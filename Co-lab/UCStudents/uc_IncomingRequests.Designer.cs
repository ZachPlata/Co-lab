namespace Co_LAB
{
    partial class uc_IncomingRequests
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
            flpRequests = new FlowLayoutPanel();
            lblEmpty = new Label();
            SuspendLayout();
            // 
            // flpRequests
            // 
            flpRequests.AutoScroll = true;
            flpRequests.BackColor = Color.FromArgb(14, 20, 16);
            flpRequests.Dock = DockStyle.Fill;
            flpRequests.FlowDirection = FlowDirection.TopDown;
            flpRequests.Location = new Point(0, 0);
            flpRequests.Name = "flpRequests";
            flpRequests.Padding = new Padding(12, 10, 12, 20);
            flpRequests.Size = new Size(940, 600);
            flpRequests.TabIndex = 0;
            flpRequests.WrapContents = false;
            flpRequests.Resize += flpRequests_Resize;
            // 
            // lblEmpty
            // 
            lblEmpty.BackColor = Color.FromArgb(14, 20, 16);
            lblEmpty.Dock = DockStyle.Fill;
            lblEmpty.Font = new Font("Segoe UI", 10.5F);
            lblEmpty.ForeColor = Color.FromArgb(161, 161, 170);
            lblEmpty.Location = new Point(0, 0);
            lblEmpty.Name = "lblEmpty";
            lblEmpty.Size = new Size(940, 600);
            lblEmpty.TabIndex = 1;
            lblEmpty.Text = "No incoming trade requests yet.\nWhen other students propose to trade skills with you, their requests will appear here.";
            lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblEmpty.Visible = false;
            // 
            // uc_IncomingRequests
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(lblEmpty);
            Controls.Add(flpRequests);
            Name = "uc_IncomingRequests";
            Size = new Size(940, 600);
            Load += uc_IncomingRequests_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpRequests;
        private Label lblEmpty;
    }
}
