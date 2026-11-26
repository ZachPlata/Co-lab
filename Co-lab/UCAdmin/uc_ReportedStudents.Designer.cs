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

            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlAdminBadge = new Panel();
            lblDot = new Label();
            lblAdminBadge = new Label();

            pnlReportDetails = new Panel();
            lblDetailsTitle = new Label();
            lblSelectedStudentLabel = new Label();
            txtSelectedStudent = new TextBox();
            lblSelectedReporterLabel = new Label();
            txtSelectedReporter = new TextBox();
            lblSelectedStatusLabel = new Label();
            txtSelectedStatus = new TextBox();
            lblSelectedReasonLabel = new Label();
            txtSelectedReason = new TextBox();
            btnDismiss = new Button();
            btnBlacklist = new Button();
            btnUnblacklist = new Button();
            btnClearSelection = new Button();

            panel2 = new Panel();
            panel3 = new Panel();
            lblTitle = new Label();
            lblReportsCount = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            btnClearSearch = new Button();

            dataGridViewReports = new DataGridView();
            _lblEmptyState = new Label();
            colReportId = new DataGridViewTextBoxColumn();
            colReportedStudent = new DataGridViewTextBoxColumn();
            colReporter = new DataGridViewTextBoxColumn();
            colReason = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();

            pnlFooter = new Panel();
            lblLegend = new Label();
            lblActiveFilter = new Label();

            pnlAdminBadge.SuspendLayout();
            pnlReportDetails.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).BeginInit();
            SuspendLayout();

            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(24, 18);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(394, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Reported Students & Moderation";

            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblHeaderSubtitle.Location = new Point(26, 54);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(560, 17);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Review incident reports submitted by students, dismiss invalid reports, or manage blacklists.";

            pnlAdminBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAdminBadge.BackColor = Color.FromArgb(20, 28, 23);
            pnlAdminBadge.Controls.Add(lblDot);
            pnlAdminBadge.Controls.Add(lblAdminBadge);
            pnlAdminBadge.Location = new Point(888, 20);
            pnlAdminBadge.Name = "pnlAdminBadge";
            pnlAdminBadge.Size = new Size(174, 41);
            pnlAdminBadge.TabIndex = 2;
            pnlAdminBadge.Paint += RoundPanel_Paint;

            lblDot.AutoSize = true;
            lblDot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDot.ForeColor = Color.FromArgb(34, 197, 94);
            lblDot.Location = new Point(14, 9);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(20, 20);
            lblDot.TabIndex = 0;
            lblDot.Text = "●";

            lblAdminBadge.AutoSize = true;
            lblAdminBadge.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblAdminBadge.ForeColor = Color.White;
            lblAdminBadge.Location = new Point(36, 11);
            lblAdminBadge.Name = "lblAdminBadge";
            lblAdminBadge.Size = new Size(106, 17);
            lblAdminBadge.TabIndex = 1;
            lblAdminBadge.Text = "Safety Monitor";

            pnlReportDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlReportDetails.BackColor = Color.FromArgb(20, 28, 23);
            pnlReportDetails.Controls.Add(lblDetailsTitle);
            pnlReportDetails.Controls.Add(lblSelectedStudentLabel);
            pnlReportDetails.Controls.Add(txtSelectedStudent);
            pnlReportDetails.Controls.Add(lblSelectedReporterLabel);
            pnlReportDetails.Controls.Add(txtSelectedReporter);
            pnlReportDetails.Controls.Add(lblSelectedStatusLabel);
            pnlReportDetails.Controls.Add(txtSelectedStatus);
            pnlReportDetails.Controls.Add(lblSelectedReasonLabel);
            pnlReportDetails.Controls.Add(txtSelectedReason);
            pnlReportDetails.Controls.Add(btnDismiss);
            pnlReportDetails.Controls.Add(btnBlacklist);
            pnlReportDetails.Controls.Add(btnUnblacklist);
            pnlReportDetails.Controls.Add(btnClearSelection);
            pnlReportDetails.Location = new Point(24, 88);
            pnlReportDetails.Name = "pnlReportDetails";
            pnlReportDetails.Size = new Size(330, 725);
            pnlReportDetails.TabIndex = 3;
            pnlReportDetails.Paint += RoundPanel_Paint;

            lblDetailsTitle.AutoSize = true;
            lblDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetailsTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblDetailsTitle.Location = new Point(20, 20);
            lblDetailsTitle.Name = "lblDetailsTitle";
            lblDetailsTitle.Size = new Size(130, 21);
            lblDetailsTitle.TabIndex = 0;
            lblDetailsTitle.Text = "Report Details";

            lblSelectedStudentLabel.AutoSize = true;
            lblSelectedStudentLabel.Font = new Font("Segoe UI Semibold", 9F);
            lblSelectedStudentLabel.ForeColor = Color.FromArgb(228, 228, 231);
            lblSelectedStudentLabel.Location = new Point(20, 58);
            lblSelectedStudentLabel.Name = "lblSelectedStudentLabel";
            lblSelectedStudentLabel.Size = new Size(110, 15);
            lblSelectedStudentLabel.TabIndex = 1;
            lblSelectedStudentLabel.Text = "Reported Student";

            txtSelectedStudent.BackColor = Color.FromArgb(14, 20, 16);
            txtSelectedStudent.BorderStyle = BorderStyle.FixedSingle;
            txtSelectedStudent.Font = new Font("Segoe UI", 9.5F);
            txtSelectedStudent.ForeColor = Color.White;
            txtSelectedStudent.Location = new Point(20, 78);
            txtSelectedStudent.Name = "txtSelectedStudent";
            txtSelectedStudent.PlaceholderText = "Select a report from the table";
            txtSelectedStudent.ReadOnly = true;
            txtSelectedStudent.Size = new Size(290, 24);
            txtSelectedStudent.TabIndex = 2;

            lblSelectedReporterLabel.AutoSize = true;
            lblSelectedReporterLabel.Font = new Font("Segoe UI Semibold", 9F);
            lblSelectedReporterLabel.ForeColor = Color.FromArgb(228, 228, 231);
            lblSelectedReporterLabel.Location = new Point(20, 114);
            lblSelectedReporterLabel.Name = "lblSelectedReporterLabel";
            lblSelectedReporterLabel.Size = new Size(80, 15);
            lblSelectedReporterLabel.TabIndex = 3;
            lblSelectedReporterLabel.Text = "Reported By";

            txtSelectedReporter.BackColor = Color.FromArgb(14, 20, 16);
            txtSelectedReporter.BorderStyle = BorderStyle.FixedSingle;
            txtSelectedReporter.Font = new Font("Segoe UI", 9.5F);
            txtSelectedReporter.ForeColor = Color.White;
            txtSelectedReporter.Location = new Point(20, 134);
            txtSelectedReporter.Name = "txtSelectedReporter";
            txtSelectedReporter.PlaceholderText = "-";
            txtSelectedReporter.ReadOnly = true;
            txtSelectedReporter.Size = new Size(290, 24);
            txtSelectedReporter.TabIndex = 4;

            lblSelectedStatusLabel.AutoSize = true;
            lblSelectedStatusLabel.Font = new Font("Segoe UI Semibold", 9F);
            lblSelectedStatusLabel.ForeColor = Color.FromArgb(228, 228, 231);
            lblSelectedStatusLabel.Location = new Point(20, 170);
            lblSelectedStatusLabel.Name = "lblSelectedStatusLabel";
            lblSelectedStatusLabel.Size = new Size(100, 15);
            lblSelectedStatusLabel.TabIndex = 5;
            lblSelectedStatusLabel.Text = "Status & Date";

            txtSelectedStatus.BackColor = Color.FromArgb(14, 20, 16);
            txtSelectedStatus.BorderStyle = BorderStyle.FixedSingle;
            txtSelectedStatus.Font = new Font("Segoe UI", 9.5F);
            txtSelectedStatus.ForeColor = Color.White;
            txtSelectedStatus.Location = new Point(20, 190);
            txtSelectedStatus.Name = "txtSelectedStatus";
            txtSelectedStatus.PlaceholderText = "-";
            txtSelectedStatus.ReadOnly = true;
            txtSelectedStatus.Size = new Size(290, 24);
            txtSelectedStatus.TabIndex = 6;

            lblSelectedReasonLabel.AutoSize = true;
            lblSelectedReasonLabel.Font = new Font("Segoe UI Semibold", 9F);
            lblSelectedReasonLabel.ForeColor = Color.FromArgb(228, 228, 231);
            lblSelectedReasonLabel.Location = new Point(20, 226);
            lblSelectedReasonLabel.Name = "lblSelectedReasonLabel";
            lblSelectedReasonLabel.Size = new Size(135, 15);
            lblSelectedReasonLabel.TabIndex = 7;
            lblSelectedReasonLabel.Text = "Incident Reason / Notes";

            txtSelectedReason.BackColor = Color.FromArgb(14, 20, 16);
            txtSelectedReason.BorderStyle = BorderStyle.FixedSingle;
            txtSelectedReason.Font = new Font("Segoe UI", 9.5F);
            txtSelectedReason.ForeColor = Color.White;
            txtSelectedReason.Location = new Point(20, 246);
            txtSelectedReason.Multiline = true;
            txtSelectedReason.Name = "txtSelectedReason";
            txtSelectedReason.PlaceholderText = "Incident details will appear here...";
            txtSelectedReason.ReadOnly = true;
            txtSelectedReason.ScrollBars = ScrollBars.Vertical;
            txtSelectedReason.Size = new Size(290, 120);
            txtSelectedReason.TabIndex = 8;

            btnDismiss.BackColor = Color.FromArgb(32, 44, 35);
            btnDismiss.Cursor = Cursors.Hand;
            btnDismiss.FlatAppearance.BorderSize = 0;
            btnDismiss.FlatStyle = FlatStyle.Flat;
            btnDismiss.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnDismiss.ForeColor = Color.FromArgb(120, 140, 125);
            btnDismiss.Location = new Point(20, 384);
            btnDismiss.Name = "btnDismiss";
            btnDismiss.Size = new Size(290, 42);
            btnDismiss.TabIndex = 9;
            btnDismiss.Text = "✕ Dismiss Report";
            btnDismiss.UseVisualStyleBackColor = false;
            btnDismiss.Click += btnDismiss_Click;

            btnBlacklist.BackColor = Color.FromArgb(32, 44, 35);
            btnBlacklist.Cursor = Cursors.Hand;
            btnBlacklist.FlatAppearance.BorderSize = 0;
            btnBlacklist.FlatStyle = FlatStyle.Flat;
            btnBlacklist.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnBlacklist.ForeColor = Color.FromArgb(120, 140, 125);
            btnBlacklist.Location = new Point(20, 438);
            btnBlacklist.Name = "btnBlacklist";
            btnBlacklist.Size = new Size(138, 41);
            btnBlacklist.TabIndex = 10;
            btnBlacklist.Text = "⛔ Blacklist";
            btnBlacklist.UseVisualStyleBackColor = false;
            btnBlacklist.Click += btnBlacklist_Click;

            btnUnblacklist.BackColor = Color.FromArgb(32, 44, 35);
            btnUnblacklist.Cursor = Cursors.Hand;
            btnUnblacklist.FlatAppearance.BorderSize = 0;
            btnUnblacklist.FlatStyle = FlatStyle.Flat;
            btnUnblacklist.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnUnblacklist.ForeColor = Color.FromArgb(120, 140, 125);
            btnUnblacklist.Location = new Point(172, 438);
            btnUnblacklist.Name = "btnUnblacklist";
            btnUnblacklist.Size = new Size(138, 41);
            btnUnblacklist.TabIndex = 11;
            btnUnblacklist.Text = "✓ Unblacklist";
            btnUnblacklist.UseVisualStyleBackColor = false;
            btnUnblacklist.Click += btnUnblacklist_Click;

            btnClearSelection.BackColor = Color.FromArgb(18, 25, 20);
            btnClearSelection.Cursor = Cursors.Hand;
            btnClearSelection.FlatAppearance.BorderColor = Color.FromArgb(36, 52, 40);
            btnClearSelection.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 38, 30);
            btnClearSelection.FlatStyle = FlatStyle.Flat;
            btnClearSelection.Font = new Font("Segoe UI Semibold", 8.5F);
            btnClearSelection.ForeColor = Color.FromArgb(180, 195, 185);
            btnClearSelection.Location = new Point(20, 492);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(290, 39);
            btnClearSelection.TabIndex = 12;
            btnClearSelection.Text = "↺ Clear Selection";
            btnClearSelection.UseVisualStyleBackColor = false;
            btnClearSelection.Click += btnClearSelection_Click;

            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(20, 28, 23);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(dataGridViewReports);
            panel2.Controls.Add(pnlFooter);
            panel2.Location = new Point(372, 88);
            panel2.Name = "panel2";
            panel2.Size = new Size(690, 725);
            panel2.TabIndex = 4;
            panel2.Paint += RoundPanel_Paint;

            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(18, 25, 20);
            panel3.Controls.Add(lblTitle);
            panel3.Controls.Add(lblReportsCount);
            panel3.Controls.Add(txtSearch);
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(btnRefresh);
            panel3.Controls.Add(btnClearSearch);
            panel3.Location = new Point(20, 18);
            panel3.Name = "panel3";
            panel3.Size = new Size(650, 54);
            panel3.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblTitle.Location = new Point(14, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(165, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Incident Reports Log";

            lblReportsCount.AutoSize = true;
            lblReportsCount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblReportsCount.ForeColor = Color.FromArgb(130, 175, 145);
            lblReportsCount.Location = new Point(185, 19);
            lblReportsCount.Name = "lblReportsCount";
            lblReportsCount.Size = new Size(95, 15);
            lblReportsCount.TabIndex = 1;
            lblReportsCount.Text = "0 report(s)";

            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(14, 20, 16);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(280, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search student, reporter...";
            txtSearch.Size = new Size(170, 24);
            txtSearch.TabIndex = 2;
            txtSearch.KeyDown += txtSearch_KeyDown;

            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(46, 125, 70);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(456, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(76, 30);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;

            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(28, 38, 30);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F);
            btnRefresh.ForeColor = Color.FromArgb(220, 235, 225);
            btnRefresh.Location = new Point(538, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(68, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Reload";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            btnClearSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearSearch.BackColor = Color.FromArgb(28, 38, 30);
            btnClearSearch.Cursor = Cursors.Hand;
            btnClearSearch.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnClearSearch.FlatAppearance.BorderSize = 1;
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClearSearch.ForeColor = Color.FromArgb(161, 161, 170);
            btnClearSearch.Location = new Point(612, 12);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(30, 30);
            btnClearSearch.TabIndex = 5;
            btnClearSearch.Text = "✕";
            btnClearSearch.UseVisualStyleBackColor = false;
            btnClearSearch.Click += btnClearSearch_Click;

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
            dgvHeaderStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.FromArgb(74, 222, 128);
            dgvHeaderStyle.Padding = new Padding(8, 0, 0, 0);
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(20, 28, 23);
            dgvHeaderStyle.SelectionForeColor = Color.FromArgb(74, 222, 128);
            dgvHeaderStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewReports.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dataGridViewReports.ColumnHeadersHeight = 42;
            dataGridViewReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridViewReports.Columns.AddRange(new DataGridViewColumn[] {
                colReportId,
                colReportedStudent,
                colReporter,
                colReason,
                colDate,
                colStatus
            });

            dgvRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = Color.FromArgb(18, 25, 20);
            dgvRowStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRowStyle.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyle.Padding = new Padding(8, 0, 0, 0);
            dgvRowStyle.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyle.SelectionForeColor = Color.White;
            dgvRowStyle.WrapMode = DataGridViewTriState.False;
            dataGridViewReports.DefaultCellStyle = dgvRowStyle;

            dgvRowStyleAlt.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyleAlt.BackColor = Color.FromArgb(15, 22, 17);
            dgvRowStyleAlt.Font = new Font("Segoe UI", 9.5F);
            dgvRowStyleAlt.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyleAlt.Padding = new Padding(8, 0, 0, 0);
            dgvRowStyleAlt.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyleAlt.SelectionForeColor = Color.White;
            dgvRowStyleAlt.WrapMode = DataGridViewTriState.False;
            dataGridViewReports.AlternatingRowsDefaultCellStyle = dgvRowStyleAlt;

            dataGridViewReports.Controls.Add(_lblEmptyState);
            dataGridViewReports.EnableHeadersVisualStyles = false;
            dataGridViewReports.GridColor = Color.FromArgb(30, 44, 34);
            dataGridViewReports.Location = new Point(20, 84);
            dataGridViewReports.MultiSelect = false;
            dataGridViewReports.Name = "dataGridViewReports";
            dataGridViewReports.ReadOnly = true;
            dataGridViewReports.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewReports.RowHeadersVisible = false;
            dataGridViewReports.RowTemplate.Height = 40;
            dataGridViewReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReports.Size = new Size(650, 578);
            dataGridViewReports.TabIndex = 1;

            _lblEmptyState.BackColor = Color.FromArgb(20, 28, 23);
            _lblEmptyState.Dock = DockStyle.Fill;
            _lblEmptyState.Font = new Font("Segoe UI", 10.5F, FontStyle.Italic);
            _lblEmptyState.ForeColor = Color.FromArgb(156, 163, 175);
            _lblEmptyState.Location = new Point(0, 0);
            _lblEmptyState.Name = "_lblEmptyState";
            _lblEmptyState.Size = new Size(650, 578);
            _lblEmptyState.TabIndex = 0;
            _lblEmptyState.Text = "No incident reports found.";
            _lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
            _lblEmptyState.Visible = false;

            colReportId.FillWeight = 12F;
            colReportId.HeaderText = "ID";
            colReportId.MinimumWidth = 45;
            colReportId.Name = "colReportId";
            colReportId.ReadOnly = true;

            colReportedStudent.FillWeight = 22F;
            colReportedStudent.HeaderText = "Reported Student";
            colReportedStudent.MinimumWidth = 100;
            colReportedStudent.Name = "colReportedStudent";
            colReportedStudent.ReadOnly = true;

            colReporter.FillWeight = 18F;
            colReporter.HeaderText = "Reported By";
            colReporter.MinimumWidth = 90;
            colReporter.Name = "colReporter";
            colReporter.ReadOnly = true;

            colReason.FillWeight = 28F;
            colReason.HeaderText = "Incident Reason / Notes";
            colReason.MinimumWidth = 120;
            colReason.Name = "colReason";
            colReason.ReadOnly = true;

            colDate.FillWeight = 13F;
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 75;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;

            colStatus.FillWeight = 17F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 90;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;

            pnlFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlFooter.BackColor = Color.FromArgb(18, 25, 20);
            pnlFooter.Controls.Add(lblLegend);
            pnlFooter.Controls.Add(lblActiveFilter);
            pnlFooter.Location = new Point(20, 672);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(650, 36);
            pnlFooter.TabIndex = 2;

            lblLegend.AutoSize = true;
            lblLegend.Font = new Font("Segoe UI", 8.5F);
            lblLegend.ForeColor = Color.FromArgb(130, 175, 145);
            lblLegend.Location = new Point(12, 10);
            lblLegend.Name = "lblLegend";
            lblLegend.Size = new Size(260, 15);
            lblLegend.TabIndex = 0;
            lblLegend.Text = "Click any row to review details on the left panel";

            lblActiveFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblActiveFilter.AutoSize = true;
            lblActiveFilter.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblActiveFilter.ForeColor = Color.FromArgb(74, 222, 128);
            lblActiveFilter.Location = new Point(445, 10);
            lblActiveFilter.Name = "lblActiveFilter";
            lblActiveFilter.Size = new Size(190, 15);
            lblActiveFilter.TabIndex = 1;
            lblActiveFilter.Text = "Dismiss, Blacklist, or Unblacklist";

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlReportDetails);
            Controls.Add(panel2);
            Controls.Add(pnlAdminBadge);
            Controls.Add(lblHeaderSubtitle);
            Controls.Add(lblHeaderTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uc_ReportedStudents";
            Size = new Size(1086, 843);
            Load += uc_ReportedStudents_Load;

            pnlAdminBadge.ResumeLayout(false);
            pnlAdminBadge.PerformLayout();
            pnlReportDetails.ResumeLayout(false);
            pnlReportDetails.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlAdminBadge;
        private Label lblDot;
        private Label lblAdminBadge;

        private Panel pnlReportDetails;
        private Label lblDetailsTitle;
        private Label lblSelectedStudentLabel;
        private TextBox txtSelectedStudent;
        private Label lblSelectedReporterLabel;
        private TextBox txtSelectedReporter;
        private Label lblSelectedStatusLabel;
        private TextBox txtSelectedStatus;
        private Label lblSelectedReasonLabel;
        private TextBox txtSelectedReason;
        private Button btnDismiss;
        private Button btnBlacklist;
        private Button btnUnblacklist;
        private Button btnClearSelection;

        private Panel panel2;
        private Panel panel3;
        private Label lblTitle;
        private Label lblReportsCount;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Button btnClearSearch;

        private DataGridView dataGridViewReports;
        private Label _lblEmptyState;
        private DataGridViewTextBoxColumn colReportId;
        private DataGridViewTextBoxColumn colReportedStudent;
        private DataGridViewTextBoxColumn colReporter;
        private DataGridViewTextBoxColumn colReason;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colStatus;

        private Panel pnlFooter;
        private Label lblLegend;
        private Label lblActiveFilter;
    }
}