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
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyleAlt = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvButtonColStyle = new DataGridViewCellStyle();

            panel1 = new Panel();
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlAdminBadge = new Panel();
            lblDot = new Label();
            lblAdminBadge = new Label();

            panel2 = new Panel();
            panel3 = new Panel();
            lblTitle = new Label();
            lblReportsCount = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            btnClearSearch = new Button();

            dataGridViewReports = new DataGridView();
            colReportId = new DataGridViewTextBoxColumn();
            colReportedStudent = new DataGridViewTextBoxColumn();
            colReporter = new DataGridViewTextBoxColumn();
            colReason = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colBlacklist = new DataGridViewButtonColumn();

            pnlFooter = new Panel();
            lblLegend = new Label();
            lblActiveFilter = new Label();

            panel1.SuspendLayout();
            pnlAdminBadge.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).BeginInit();
            SuspendLayout();

            // 
            // panel1 (Header Banner Card)
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(20, 28, 23);
            panel1.Controls.Add(lblHeaderTitle);
            panel1.Controls.Add(lblHeaderSubtitle);
            panel1.Controls.Add(pnlAdminBadge);
            panel1.Location = new Point(32, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1020, 92);
            panel1.TabIndex = 0;
            panel1.Paint += RoundPanel_Paint;

            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(24, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(365, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Reported Students & Moderation";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblHeaderSubtitle.Location = new Point(26, 50);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(618, 17);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Review incident reports submitted by students, assess policy violations, and enforce account restrictions.";

            // 
            // pnlAdminBadge
            // 
            pnlAdminBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAdminBadge.BackColor = Color.FromArgb(28, 38, 31);
            pnlAdminBadge.Controls.Add(lblDot);
            pnlAdminBadge.Controls.Add(lblAdminBadge);
            pnlAdminBadge.Location = new Point(835, 24);
            pnlAdminBadge.Name = "pnlAdminBadge";
            pnlAdminBadge.Size = new Size(160, 42);
            pnlAdminBadge.TabIndex = 2;
            pnlAdminBadge.Paint += RoundPanel_Paint;

            // 
            // lblDot
            // 
            lblDot.AutoSize = true;
            lblDot.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDot.ForeColor = Color.FromArgb(34, 197, 94);
            lblDot.Location = new Point(12, 10);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(21, 21);
            lblDot.TabIndex = 0;
            lblDot.Text = "●";

            // 
            // lblAdminBadge
            // 
            lblAdminBadge.AutoSize = true;
            lblAdminBadge.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblAdminBadge.ForeColor = Color.White;
            lblAdminBadge.Location = new Point(35, 12);
            lblAdminBadge.Name = "lblAdminBadge";
            lblAdminBadge.Size = new Size(106, 17);
            lblAdminBadge.TabIndex = 1;
            lblAdminBadge.Text = "Safety Monitor";

            // 
            // panel2 (Main Content Card)
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(20, 28, 23);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(dataGridViewReports);
            panel2.Controls.Add(pnlFooter);
            panel2.Location = new Point(32, 134);
            panel2.Name = "panel2";
            panel2.Size = new Size(1020, 680);
            panel2.TabIndex = 1;
            panel2.Paint += RoundPanel_Paint;

            // 
            // panel3 (Search & Action Toolbar)
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(18, 25, 20);
            panel3.Controls.Add(lblTitle);
            panel3.Controls.Add(lblReportsCount);
            panel3.Controls.Add(txtSearch);
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(btnRefresh);
            panel3.Controls.Add(btnClearSearch);
            panel3.Location = new Point(24, 20);
            panel3.Name = "panel3";
            panel3.Size = new Size(972, 54);
            panel3.TabIndex = 0;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblTitle.Location = new Point(16, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Incident Reports Log";

            // 
            // lblReportsCount
            // 
            lblReportsCount.AutoSize = true;
            lblReportsCount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblReportsCount.ForeColor = Color.FromArgb(130, 175, 145);
            lblReportsCount.Location = new Point(208, 19);
            lblReportsCount.Name = "lblReportsCount";
            lblReportsCount.Size = new Size(95, 15);
            lblReportsCount.TabIndex = 1;
            lblReportsCount.Text = "0 reports loaded";

            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(14, 20, 16);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(505, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search student, reporter...";
            txtSearch.Size = new Size(215, 24);
            txtSearch.TabIndex = 2;
            txtSearch.KeyDown += txtSearch_KeyDown;

            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(46, 125, 70);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(728, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(92, 30);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;

            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(28, 38, 30);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F);
            btnRefresh.ForeColor = Color.FromArgb(220, 235, 225);
            btnRefresh.Location = new Point(828, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(88, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "↺ Reload";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            // 
            // btnClearSearch
            // 
            btnClearSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearSearch.BackColor = Color.FromArgb(28, 38, 30);
            btnClearSearch.Cursor = Cursors.Hand;
            btnClearSearch.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnClearSearch.FlatAppearance.BorderSize = 1;
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClearSearch.ForeColor = Color.FromArgb(161, 161, 170);
            btnClearSearch.Location = new Point(924, 12);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(36, 30);
            btnClearSearch.TabIndex = 5;
            btnClearSearch.Text = "✕";
            btnClearSearch.UseVisualStyleBackColor = false;
            btnClearSearch.Click += btnClearSearch_Click;

            // 
            // dataGridViewReports
            // 
            dataGridViewReports.AllowUserToAddRows = false;
            dataGridViewReports.AllowUserToDeleteRows = false;
            dataGridViewReports.AllowUserToResizeRows = false;
            dataGridViewReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReports.BackgroundColor = Color.FromArgb(14, 20, 16);
            dataGridViewReports.BorderStyle = BorderStyle.None;
            dataGridViewReports.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewReports.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(20, 28, 23);
            dgvHeaderStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.FromArgb(74, 222, 128);
            dgvHeaderStyle.Padding = new Padding(10, 0, 0, 0);
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(20, 28, 23);
            dgvHeaderStyle.SelectionForeColor = Color.FromArgb(74, 222, 128);
            dgvHeaderStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewReports.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dataGridViewReports.ColumnHeadersHeight = 44;
            dataGridViewReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridViewReports.Columns.AddRange(new DataGridViewColumn[] {
                colReportId,
                colReportedStudent,
                colReporter,
                colReason,
                colDate,
                colBlacklist
            });

            dgvRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = Color.FromArgb(18, 25, 20);
            dgvRowStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRowStyle.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyle.Padding = new Padding(10, 0, 0, 0);
            dgvRowStyle.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyle.SelectionForeColor = Color.White;
            dgvRowStyle.WrapMode = DataGridViewTriState.False;
            dataGridViewReports.DefaultCellStyle = dgvRowStyle;

            dgvRowStyleAlt.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyleAlt.BackColor = Color.FromArgb(15, 22, 17);
            dgvRowStyleAlt.Font = new Font("Segoe UI", 9.5F);
            dgvRowStyleAlt.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyleAlt.Padding = new Padding(10, 0, 0, 0);
            dgvRowStyleAlt.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyleAlt.SelectionForeColor = Color.White;
            dgvRowStyleAlt.WrapMode = DataGridViewTriState.False;
            dataGridViewReports.AlternatingRowsDefaultCellStyle = dgvRowStyleAlt;

            dataGridViewReports.EnableHeadersVisualStyles = false;
            dataGridViewReports.GridColor = Color.FromArgb(30, 44, 34);
            dataGridViewReports.Location = new Point(24, 88);
            dataGridViewReports.MultiSelect = false;
            dataGridViewReports.Name = "dataGridViewReports";
            dataGridViewReports.ReadOnly = true;
            dataGridViewReports.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewReports.RowHeadersVisible = false;
            dataGridViewReports.RowTemplate.Height = 42;
            dataGridViewReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReports.Size = new Size(972, 515);
            dataGridViewReports.TabIndex = 1;

            // 
            // colReportId
            // 
            colReportId.FillWeight = 12F;
            colReportId.HeaderText = "Report ID";
            colReportId.MinimumWidth = 6;
            colReportId.Name = "colReportId";
            colReportId.ReadOnly = true;
            colReportId.Width = 85;

            // 
            // colReportedStudent
            // 
            colReportedStudent.FillWeight = 22F;
            colReportedStudent.HeaderText = "Reported Student";
            colReportedStudent.MinimumWidth = 6;
            colReportedStudent.Name = "colReportedStudent";
            colReportedStudent.ReadOnly = true;
            colReportedStudent.Width = 160;

            // 
            // colReporter
            // 
            colReporter.FillWeight = 20F;
            colReporter.HeaderText = "Reported By";
            colReporter.MinimumWidth = 6;
            colReporter.Name = "colReporter";
            colReporter.ReadOnly = true;
            colReporter.Width = 150;

            // 
            // colReason
            // 
            colReason.FillWeight = 28F;
            colReason.HeaderText = "Incident Reason / Notes";
            colReason.MinimumWidth = 6;
            colReason.Name = "colReason";
            colReason.ReadOnly = true;
            colReason.Width = 220;

            // 
            // colDate
            // 
            colDate.FillWeight = 14F;
            colDate.HeaderText = "Date Filed";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 110;

            // 
            // colBlacklist
            // 
            dgvButtonColStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvButtonColStyle.BackColor = Color.FromArgb(50, 25, 28);
            dgvButtonColStyle.ForeColor = Color.FromArgb(248, 113, 113);
            dgvButtonColStyle.SelectionBackColor = Color.FromArgb(70, 30, 34);
            dgvButtonColStyle.SelectionForeColor = Color.White;
            colBlacklist.DefaultCellStyle = dgvButtonColStyle;
            colBlacklist.FillWeight = 16F;
            colBlacklist.FlatStyle = FlatStyle.Flat;
            colBlacklist.HeaderText = "Action";
            colBlacklist.MinimumWidth = 6;
            colBlacklist.Name = "colBlacklist";
            colBlacklist.ReadOnly = true;
            colBlacklist.Text = "Blacklist";
            colBlacklist.UseColumnTextForButtonValue = false;
            colBlacklist.Width = 115;

            // 
            // pnlFooter (Policy Info & Guidance)
            // 
            pnlFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlFooter.BackColor = Color.FromArgb(18, 25, 20);
            pnlFooter.Controls.Add(lblLegend);
            pnlFooter.Controls.Add(lblActiveFilter);
            pnlFooter.Location = new Point(24, 618);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(972, 44);
            pnlFooter.TabIndex = 2;

            // 
            // lblLegend
            // 
            lblLegend.AutoSize = true;
            lblLegend.Font = new Font("Segoe UI", 9F);
            lblLegend.ForeColor = Color.FromArgb(130, 175, 145);
            lblLegend.Location = new Point(16, 14);
            lblLegend.Name = "lblLegend";
            lblLegend.Size = new Size(590, 15);
            lblLegend.TabIndex = 0;
            lblLegend.Text = "🛡️ Policy Notice: Blacklisting a student immediately restricts their account login and revokes their active listings.";

            // 
            // lblActiveFilter
            // 
            lblActiveFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblActiveFilter.AutoSize = true;
            lblActiveFilter.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblActiveFilter.ForeColor = Color.FromArgb(74, 222, 128);
            lblActiveFilter.Location = new Point(738, 14);
            lblActiveFilter.Name = "lblActiveFilter";
            lblActiveFilter.Size = new Size(220, 15);
            lblActiveFilter.TabIndex = 1;
            lblActiveFilter.Text = "Click Action to enforce or lift a ban";

            // 
            // uc_ReportedStudents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uc_ReportedStudents";
            Size = new Size(1086, 843);
            Load += uc_ReportedStudents_Load;

            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlAdminBadge.ResumeLayout(false);
            pnlAdminBadge.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // Header Card
        private Panel panel1;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlAdminBadge;
        private Label lblDot;
        private Label lblAdminBadge;

        // Content Card
        private Panel panel2;
        private Panel panel3;
        private Label lblTitle;
        private Label lblReportsCount;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Button btnClearSearch;

        // Data Table
        private DataGridView dataGridViewReports;
        private DataGridViewTextBoxColumn colReportId;
        private DataGridViewTextBoxColumn colReportedStudent;
        private DataGridViewTextBoxColumn colReporter;
        private DataGridViewTextBoxColumn colReason;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewButtonColumn colBlacklist;

        // Footer
        private Panel pnlFooter;
        private Label lblLegend;
        private Label lblActiveFilter;
    }
}
