namespace Co_LAB.UCStudents
{
    partial class uc_SkillCard
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
            lblCategoryBadge = new Label();
            lblDeliveryMode = new Label();
            lblSkillTitle = new Label();
            lblDescription = new Label();
            lblOfferedBy = new Label();
            pnlDivider = new Panel();
            btnRequestTrade = new Button();
            btnReport = new Button();
            SuspendLayout();
            // 
            // lblCategoryBadge
            // 
            lblCategoryBadge.AutoSize = true;
            lblCategoryBadge.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblCategoryBadge.ForeColor = Color.FromArgb(74, 222, 128);
            lblCategoryBadge.Location = new Point(14, 12);
            lblCategoryBadge.Name = "lblCategoryBadge";
            lblCategoryBadge.Size = new Size(55, 12);
            lblCategoryBadge.TabIndex = 0;
            lblCategoryBadge.Text = "CATEGORY";
            // 
            // lblDeliveryMode
            // 
            lblDeliveryMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDeliveryMode.AutoSize = true;
            lblDeliveryMode.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblDeliveryMode.ForeColor = Color.FromArgb(161, 161, 170);
            lblDeliveryMode.Location = new Point(215, 12);
            lblDeliveryMode.Name = "lblDeliveryMode";
            lblDeliveryMode.Size = new Size(51, 12);
            lblDeliveryMode.TabIndex = 1;
            lblDeliveryMode.Text = "🌐 Online";
            lblDeliveryMode.TextAlign = ContentAlignment.TopRight;
            // 
            // lblSkillTitle
            // 
            lblSkillTitle.AutoEllipsis = true;
            lblSkillTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSkillTitle.ForeColor = Color.White;
            lblSkillTitle.Location = new Point(12, 32);
            lblSkillTitle.Name = "lblSkillTitle";
            lblSkillTitle.Size = new Size(256, 25);
            lblSkillTitle.TabIndex = 2;
            lblSkillTitle.Text = "Skill Title Here";
            // 
            // lblDescription
            // 
            lblDescription.AutoEllipsis = true;
            lblDescription.Font = new Font("Segoe UI", 8.5F);
            lblDescription.ForeColor = Color.FromArgb(161, 161, 170);
            lblDescription.Location = new Point(14, 60);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(252, 75);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Short description explaining what the student will teach or exchange.";
            // 
            // lblOfferedBy
            // 
            lblOfferedBy.AutoEllipsis = true;
            lblOfferedBy.Font = new Font("Segoe UI Semibold", 8.5F);
            lblOfferedBy.ForeColor = Color.FromArgb(212, 212, 216);
            lblOfferedBy.Location = new Point(14, 145);
            lblOfferedBy.Name = "lblOfferedBy";
            lblOfferedBy.Size = new Size(252, 20);
            lblOfferedBy.TabIndex = 4;
            lblOfferedBy.Text = "👤 Student Name";
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.FromArgb(30, 44, 34);
            pnlDivider.Location = new Point(14, 175);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(252, 1);
            pnlDivider.TabIndex = 5;
            // 
            // btnRequestTrade
            // 
            btnRequestTrade.BackColor = Color.FromArgb(46, 125, 70);
            btnRequestTrade.Cursor = Cursors.Hand;
            btnRequestTrade.FlatAppearance.BorderSize = 0;
            btnRequestTrade.FlatStyle = FlatStyle.Flat;
            btnRequestTrade.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnRequestTrade.ForeColor = Color.White;
            btnRequestTrade.Location = new Point(14, 185);
            btnRequestTrade.Name = "btnRequestTrade";
            btnRequestTrade.Size = new Size(160, 32);
            btnRequestTrade.TabIndex = 6;
            btnRequestTrade.Text = "🤝 Request Trade";
            btnRequestTrade.UseVisualStyleBackColor = false;
            btnRequestTrade.Click += btnRequestTrade_Click;
            // 
            // btnReport
            // 
            btnReport.BackColor = Color.FromArgb(28, 38, 30);
            btnReport.Cursor = Cursors.Hand;
            btnReport.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnReport.FlatAppearance.BorderSize = 1;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 8F);
            btnReport.ForeColor = Color.FromArgb(248, 113, 113);
            btnReport.Location = new Point(184, 185);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(82, 32);
            btnReport.TabIndex = 7;
            btnReport.Text = "🚩 Report";
            btnReport.UseVisualStyleBackColor = false;
            btnReport.Click += btnReport_Click;
            // 
            // uc_SkillCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 28, 23);
            Controls.Add(btnReport);
            Controls.Add(btnRequestTrade);
            Controls.Add(pnlDivider);
            Controls.Add(lblOfferedBy);
            Controls.Add(lblDescription);
            Controls.Add(lblSkillTitle);
            Controls.Add(lblDeliveryMode);
            Controls.Add(lblCategoryBadge);
            Margin = new Padding(10);
            Name = "uc_SkillCard";
            Size = new Size(280, 250);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategoryBadge;
        private Label lblDeliveryMode;
        private Label lblSkillTitle;
        private Label lblDescription;
        private Label lblOfferedBy;
        private Panel pnlDivider;
        private Button btnRequestTrade;
        private Button btnReport;
    }
}

