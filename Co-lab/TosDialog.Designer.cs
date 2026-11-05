namespace Co_LAB
{
    partial class TosDialog
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            pnlDividerHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlFooter = new Panel();
            pnlDividerFooter = new Panel();
            btnClose = new Button();
            btnDecline = new Button();
            btnAccept = new Button();
            pnlContent = new Panel();
            txtTosContent = new TextBox();
            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(24, 24, 27);
            pnlHeader.Controls.Add(pnlDividerHeader);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(560, 70);
            pnlHeader.TabIndex = 0;
            // 
            // pnlDividerHeader
            // 
            pnlDividerHeader.BackColor = Color.FromArgb(39, 39, 42);
            pnlDividerHeader.Dock = DockStyle.Bottom;
            pnlDividerHeader.Location = new Point(0, 69);
            pnlDividerHeader.Name = "pnlDividerHeader";
            pnlDividerHeader.Size = new Size(560, 1);
            pnlDividerHeader.TabIndex = 2;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(161, 161, 170);
            lblSubtitle.Location = new Point(24, 42);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(276, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Please review the platform rules before proceeding.";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(16, 185, 129);
            lblTitle.Location = new Point(22, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(174, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Terms of Service";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(24, 24, 27);
            pnlFooter.Controls.Add(pnlDividerFooter);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Controls.Add(btnDecline);
            pnlFooter.Controls.Add(btnAccept);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 535);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(560, 65);
            pnlFooter.TabIndex = 1;
            // 
            // pnlDividerFooter
            // 
            pnlDividerFooter.BackColor = Color.FromArgb(39, 39, 42);
            pnlDividerFooter.Dock = DockStyle.Top;
            pnlDividerFooter.Location = new Point(0, 0);
            pnlDividerFooter.Name = "pnlDividerFooter";
            pnlDividerFooter.Size = new Size(560, 1);
            pnlDividerFooter.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(39, 39, 42);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.5F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(436, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Visible = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnDecline
            // 
            btnDecline.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDecline.BackColor = Color.FromArgb(39, 39, 42);
            btnDecline.Cursor = Cursors.Hand;
            btnDecline.FlatAppearance.BorderSize = 0;
            btnDecline.FlatStyle = FlatStyle.Flat;
            btnDecline.Font = new Font("Segoe UI", 9.5F);
            btnDecline.ForeColor = Color.White;
            btnDecline.Location = new Point(436, 15);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(100, 36);
            btnDecline.TabIndex = 1;
            btnDecline.Text = "Decline";
            btnDecline.UseVisualStyleBackColor = false;
            btnDecline.Click += btnDecline_Click;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.BackColor = Color.FromArgb(16, 185, 129);
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAccept.ForeColor = Color.FromArgb(15, 15, 17);
            btnAccept.Location = new Point(316, 15);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(110, 36);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(15, 15, 17);
            pnlContent.Controls.Add(txtTosContent);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 70);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(24, 20, 24, 20);
            pnlContent.Size = new Size(560, 465);
            pnlContent.TabIndex = 2;
            // 
            // txtTosContent
            // 
            txtTosContent.BackColor = Color.FromArgb(28, 28, 33);
            txtTosContent.BorderStyle = BorderStyle.None;
            txtTosContent.Dock = DockStyle.Fill;
            txtTosContent.Font = new Font("Segoe UI", 10F);
            txtTosContent.ForeColor = Color.FromArgb(244, 244, 245);
            txtTosContent.Location = new Point(24, 20);
            txtTosContent.Multiline = true;
            txtTosContent.Name = "txtTosContent";
            txtTosContent.ReadOnly = true;
            txtTosContent.ScrollBars = ScrollBars.Vertical;
            txtTosContent.Size = new Size(512, 425);
            txtTosContent.TabIndex = 0;
            // 
            // TosDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 17);
            ClientSize = new Size(560, 600);
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TosDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Terms of Service";
            Load += TosDialog_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlDividerHeader;
        private Panel pnlFooter;
        private Panel pnlDividerFooter;
        private Button btnAccept;
        private Button btnDecline;
        private Button btnClose;
        private Panel pnlContent;
        private TextBox txtTosContent;
    }
}

