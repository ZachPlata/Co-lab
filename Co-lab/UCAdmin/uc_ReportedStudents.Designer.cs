namespace Co_LAB
{
    partial class uc_ReportedStudents
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel1 = new Panel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(64, 64, 64);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Location = new Point(0, 64);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1086, 238);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.FromArgb(64, 64, 64);
            flowLayoutPanel2.Location = new Point(0, 329);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1086, 238);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 97);
            panel1.TabIndex = 0;
            // 
            // uc_ReportedStudents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uc_ReportedStudents";
            Size = new Size(1086, 843);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}
