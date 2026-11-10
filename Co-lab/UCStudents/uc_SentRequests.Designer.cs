namespace Co_LAB
{
    partial class uc_SentRequests
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
            // uc_SentRequests
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(flpRequests);
            Name = "uc_SentRequests";
            Size = new Size(940, 600);
            Load += uc_SentRequests_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpRequests;
    }
}
