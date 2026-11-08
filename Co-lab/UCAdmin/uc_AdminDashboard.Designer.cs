namespace Co_LAB
{
    partial class uc_AdminDashboard
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlStatStudents = new Panel();
            lblStatStudentsTitle = new Label();
            lblTotalStudentCount = new Label();
            pnlStatSkills = new Panel();
            lblStatSkillsTitle = new Label();
            lblActiveSkillCount = new Label();
            pnlStatPending = new Panel();
            lblStatPendingTitle = new Label();
            lblPendingSkillCount = new Label();
            pnlStatReports = new Panel();
            lblStatReportsTitle = new Label();
            lblOpenReportsCount = new Label();
            pnlShortcuts = new Panel();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            label1 = new Label();
            pnlPendingVerif = new Panel();
            flowLayoutPanel7 = new FlowLayoutPanel();
            flowLayoutPanel6 = new FlowLayoutPanel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            flpPendingVerification = new FlowLayoutPanel();
            lblPendingVerifTitle = new Label();
            pnlBlacklisted = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flpBlacklisted = new FlowLayoutPanel();
            label3 = new Label();
            lblBlacklistedTitle = new Label();
            pnlDeclined = new Panel();
            flowLayoutPanel11 = new FlowLayoutPanel();
            flowLayoutPanel10 = new FlowLayoutPanel();
            flowLayoutPanel9 = new FlowLayoutPanel();
            flpDeclined = new FlowLayoutPanel();
            button1 = new Button();
            lblDeclinedTitle = new Label();
            pnlReports = new Panel();
            dgvReportRecords = new DataGridView();
            colReportId = new DataGridViewTextBoxColumn();
            colReportedStudent = new DataGridViewTextBoxColumn();
            colReporter = new DataGridViewTextBoxColumn();
            colReason = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colBlacklist = new DataGridViewTextBoxColumn();
            lblReportsTitle = new Label();
            dgv_PendingStudentVerification = new DataGridView();
            dgv_CurrentlyBlackLister = new DataGridView();
            dgv_DeclineStudent = new DataGridView();
            pnlStatStudents.SuspendLayout();
            pnlStatSkills.SuspendLayout();
            pnlStatPending.SuspendLayout();
            pnlStatReports.SuspendLayout();
            pnlShortcuts.SuspendLayout();
            pnlPendingVerif.SuspendLayout();
            pnlBlacklisted.SuspendLayout();
            pnlDeclined.SuspendLayout();
            pnlReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportRecords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_PendingStudentVerification).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_CurrentlyBlackLister).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_DeclineStudent).BeginInit();
            SuspendLayout();
            // 
            // pnlStatStudents
            // 
            pnlStatStudents.BackColor = Color.FromArgb(6, 95, 70);
            pnlStatStudents.Controls.Add(lblStatStudentsTitle);
            pnlStatStudents.Controls.Add(lblTotalStudentCount);
            pnlStatStudents.Location = new Point(18, 15);
            pnlStatStudents.Margin = new Padding(3, 2, 3, 2);
            pnlStatStudents.Name = "pnlStatStudents";
            pnlStatStudents.Size = new Size(416, 64);
            pnlStatStudents.TabIndex = 0;
            // 
            // lblStatStudentsTitle
            // 
            lblStatStudentsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatStudentsTitle.ForeColor = Color.Black;
            lblStatStudentsTitle.Location = new Point(102, 8);
            lblStatStudentsTitle.Name = "lblStatStudentsTitle";
            lblStatStudentsTitle.Size = new Size(184, 21);
            lblStatStudentsTitle.TabIndex = 0;
            lblStatStudentsTitle.Text = "TOTAL REGISTERED STUDENT";
            lblStatStudentsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalStudentCount
            // 
            lblTotalStudentCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalStudentCount.ForeColor = Color.Black;
            lblTotalStudentCount.Location = new Point(86, 22);
            lblTotalStudentCount.Name = "lblTotalStudentCount";
            lblTotalStudentCount.Size = new Size(201, 32);
            lblTotalStudentCount.TabIndex = 1;
            lblTotalStudentCount.Text = "—";
            lblTotalStudentCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStatSkills
            // 
            pnlStatSkills.BackColor = Color.FromArgb(6, 95, 70);
            pnlStatSkills.Controls.Add(lblStatSkillsTitle);
            pnlStatSkills.Controls.Add(lblActiveSkillCount);
            pnlStatSkills.Location = new Point(446, 15);
            pnlStatSkills.Margin = new Padding(3, 2, 3, 2);
            pnlStatSkills.Name = "pnlStatSkills";
            pnlStatSkills.Size = new Size(416, 64);
            pnlStatSkills.TabIndex = 1;
            // 
            // lblStatSkillsTitle
            // 
            lblStatSkillsTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatSkillsTitle.ForeColor = Color.Black;
            lblStatSkillsTitle.Location = new Point(102, 8);
            lblStatSkillsTitle.Name = "lblStatSkillsTitle";
            lblStatSkillsTitle.Size = new Size(184, 15);
            lblStatSkillsTitle.TabIndex = 0;
            lblStatSkillsTitle.Text = "ACTIVE SKILL EXCHANGE";
            lblStatSkillsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActiveSkillCount
            // 
            lblActiveSkillCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblActiveSkillCount.ForeColor = Color.Black;
            lblActiveSkillCount.Location = new Point(94, 22);
            lblActiveSkillCount.Name = "lblActiveSkillCount";
            lblActiveSkillCount.Size = new Size(201, 32);
            lblActiveSkillCount.TabIndex = 1;
            lblActiveSkillCount.Text = "—";
            lblActiveSkillCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStatPending
            // 
            pnlStatPending.BackColor = Color.FromArgb(6, 95, 70);
            pnlStatPending.Controls.Add(lblStatPendingTitle);
            pnlStatPending.Controls.Add(lblPendingSkillCount);
            pnlStatPending.Location = new Point(18, 84);
            pnlStatPending.Margin = new Padding(3, 2, 3, 2);
            pnlStatPending.Name = "pnlStatPending";
            pnlStatPending.Size = new Size(416, 64);
            pnlStatPending.TabIndex = 2;
            pnlStatPending.Paint += pnlStatPending_Paint;
            // 
            // lblStatPendingTitle
            // 
            lblStatPendingTitle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lblStatPendingTitle.ForeColor = Color.Yellow;
            lblStatPendingTitle.Location = new Point(107, 8);
            lblStatPendingTitle.Name = "lblStatPendingTitle";
            lblStatPendingTitle.Size = new Size(184, 15);
            lblStatPendingTitle.TabIndex = 0;
            lblStatPendingTitle.Text = "PENDING SKILL FOR REVIEW";
            lblStatPendingTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPendingSkillCount
            // 
            lblPendingSkillCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblPendingSkillCount.ForeColor = Color.Black;
            lblPendingSkillCount.Location = new Point(88, 22);
            lblPendingSkillCount.Name = "lblPendingSkillCount";
            lblPendingSkillCount.Size = new Size(201, 32);
            lblPendingSkillCount.TabIndex = 1;
            lblPendingSkillCount.Text = "—";
            lblPendingSkillCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStatReports
            // 
            pnlStatReports.BackColor = Color.FromArgb(6, 95, 70);
            pnlStatReports.Controls.Add(lblStatReportsTitle);
            pnlStatReports.Controls.Add(lblOpenReportsCount);
            pnlStatReports.Location = new Point(446, 84);
            pnlStatReports.Margin = new Padding(3, 2, 3, 2);
            pnlStatReports.Name = "pnlStatReports";
            pnlStatReports.Size = new Size(416, 64);
            pnlStatReports.TabIndex = 3;
            // 
            // lblStatReportsTitle
            // 
            lblStatReportsTitle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lblStatReportsTitle.ForeColor = Color.Red;
            lblStatReportsTitle.Location = new Point(102, 8);
            lblStatReportsTitle.Name = "lblStatReportsTitle";
            lblStatReportsTitle.Size = new Size(184, 15);
            lblStatReportsTitle.TabIndex = 0;
            lblStatReportsTitle.Text = "OPEN REPORTS";
            lblStatReportsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOpenReportsCount
            // 
            lblOpenReportsCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblOpenReportsCount.ForeColor = Color.Black;
            lblOpenReportsCount.Location = new Point(95, 22);
            lblOpenReportsCount.Name = "lblOpenReportsCount";
            lblOpenReportsCount.Size = new Size(201, 32);
            lblOpenReportsCount.TabIndex = 1;
            lblOpenReportsCount.Text = "—";
            lblOpenReportsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlShortcuts
            // 
            pnlShortcuts.BackColor = Color.FromArgb(6, 95, 70);
            pnlShortcuts.Controls.Add(tableLayoutPanel6);
            pnlShortcuts.Controls.Add(tableLayoutPanel5);
            pnlShortcuts.Controls.Add(tableLayoutPanel4);
            pnlShortcuts.Controls.Add(tableLayoutPanel3);
            pnlShortcuts.Controls.Add(tableLayoutPanel2);
            pnlShortcuts.Controls.Add(tableLayoutPanel1);
            pnlShortcuts.Controls.Add(label2);
            pnlShortcuts.Controls.Add(label1);
            pnlShortcuts.Location = new Point(18, 155);
            pnlShortcuts.Margin = new Padding(3, 2, 3, 2);
            pnlShortcuts.Name = "pnlShortcuts";
            pnlShortcuts.Size = new Size(416, 112);
            pnlShortcuts.TabIndex = 4;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.BackColor = Color.FromArgb(16, 185, 129);
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Location = new Point(202, 82);
            tableLayoutPanel6.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 48.1481476F));
            tableLayoutPanel6.Size = new Size(170, 20);
            tableLayoutPanel6.TabIndex = 7;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = Color.FromArgb(16, 185, 129);
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Location = new Point(18, 82);
            tableLayoutPanel5.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 48.1481476F));
            tableLayoutPanel5.Size = new Size(170, 20);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(16, 185, 129);
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Location = new Point(202, 49);
            tableLayoutPanel4.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 48.1481476F));
            tableLayoutPanel4.Size = new Size(170, 21);
            tableLayoutPanel4.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(16, 185, 129);
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Location = new Point(18, 50);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 48.1481476F));
            tableLayoutPanel3.Size = new Size(170, 21);
            tableLayoutPanel3.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(16, 185, 129);
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Location = new Point(202, 22);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 48.1481476F));
            tableLayoutPanel2.Size = new Size(170, 20);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(16, 185, 129);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(18, 22);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 48.1481476F));
            tableLayoutPanel1.Size = new Size(170, 20);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(111, 4);
            label2.Name = "label2";
            label2.Size = new Size(181, 18);
            label2.TabIndex = 2;
            label2.Text = "Quick Admin Shortcuts";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(88, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 19);
            label1.TabIndex = 2;
            // 
            // pnlPendingVerif
            // 
            pnlPendingVerif.BackColor = Color.FromArgb(6, 95, 70);
            pnlPendingVerif.Controls.Add(dgv_PendingStudentVerification);
            pnlPendingVerif.Controls.Add(lblPendingVerifTitle);
            pnlPendingVerif.Location = new Point(446, 155);
            pnlPendingVerif.Margin = new Padding(3, 2, 3, 2);
            pnlPendingVerif.Name = "pnlPendingVerif";
            pnlPendingVerif.Size = new Size(416, 112);
            pnlPendingVerif.TabIndex = 5;
            // 
            // dgv_PendingStudentVerification
            // 
            dgv_PendingStudentVerification.BackgroundColor = Color.FromArgb(6, 95, 70);
            dgv_PendingStudentVerification.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_PendingStudentVerification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_PendingStudentVerification.DefaultCellStyle = dataGridViewCellStyle4;
            dgv_PendingStudentVerification.EnableHeadersVisualStyles = false;
            dgv_PendingStudentVerification.GridColor = SystemColors.WindowText;
            dgv_PendingStudentVerification.Location = new Point(12, 26);
            dgv_PendingStudentVerification.Margin = new Padding(3, 2, 3, 2);
            dgv_PendingStudentVerification.Name = "dgv_PendingStudentVerification";
            dgv_PendingStudentVerification.RowHeadersVisible = false;
            dgv_PendingStudentVerification.Size = new Size(392, 78);
            dgv_PendingStudentVerification.TabIndex = 1;
            // 
            // lblPendingVerifTitle
            // 
            lblPendingVerifTitle.AutoSize = true;
            lblPendingVerifTitle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lblPendingVerifTitle.ForeColor = Color.Black;
            lblPendingVerifTitle.Location = new Point(92, 4);
            lblPendingVerifTitle.Name = "lblPendingVerifTitle";
            lblPendingVerifTitle.Size = new Size(219, 18);
            lblPendingVerifTitle.TabIndex = 0;
            lblPendingVerifTitle.Text = "Pending Student Verification";
            // 
            // pnlBlacklisted
            // 
            pnlBlacklisted.BackColor = Color.FromArgb(6, 95, 70);
            pnlBlacklisted.Controls.Add(dgv_CurrentlyBlackLister);
            pnlBlacklisted.Controls.Add(lblBlacklistedTitle);
            pnlBlacklisted.Location = new Point(18, 272);
            pnlBlacklisted.Margin = new Padding(3, 2, 3, 2);
            pnlBlacklisted.Name = "pnlBlacklisted";
            pnlBlacklisted.Size = new Size(416, 118);
            pnlBlacklisted.TabIndex = 6;
            // 
            // dgv_CurrentlyBlackLister
            // 
            dgv_CurrentlyBlackLister.BackgroundColor = Color.FromArgb(6, 95, 70);
            dgv_CurrentlyBlackLister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_CurrentlyBlackLister.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_CurrentlyBlackLister.DefaultCellStyle = dataGridViewCellStyle4;
            dgv_CurrentlyBlackLister.EnableHeadersVisualStyles = false;
            dgv_CurrentlyBlackLister.GridColor = SystemColors.WindowText;
            dgv_CurrentlyBlackLister.Location = new Point(12, 26);
            dgv_CurrentlyBlackLister.Margin = new Padding(3, 2, 3, 2);
            dgv_CurrentlyBlackLister.Name = "dgv_CurrentlyBlackLister";
            dgv_CurrentlyBlackLister.RowHeadersVisible = false;
            dgv_CurrentlyBlackLister.Size = new Size(392, 84);
            dgv_CurrentlyBlackLister.TabIndex = 1;
            // 
            // lblBlacklistedTitle
            // 
            lblBlacklistedTitle.AutoSize = true;
            lblBlacklistedTitle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lblBlacklistedTitle.ForeColor = Color.Black;
            lblBlacklistedTitle.Location = new Point(114, 4);
            lblBlacklistedTitle.Name = "lblBlacklistedTitle";
            lblBlacklistedTitle.Size = new Size(163, 18);
            lblBlacklistedTitle.TabIndex = 0;
            lblBlacklistedTitle.Text = "Currently Blacklisted";
            // 
            // pnlDeclined
            // 
            pnlDeclined.Anchor = AnchorStyles.Right;
            pnlDeclined.BackColor = Color.FromArgb(6, 95, 70);
            pnlDeclined.Controls.Add(dgv_DeclineStudent);
            pnlDeclined.Controls.Add(lblDeclinedTitle);
            pnlDeclined.Location = new Point(446, 272);
            pnlDeclined.Margin = new Padding(3, 2, 3, 2);
            pnlDeclined.Name = "pnlDeclined";
            pnlDeclined.Size = new Size(416, 119);
            pnlDeclined.TabIndex = 7;
            // 
            // dgv_DeclineStudent
            // 
            dgv_DeclineStudent.BackgroundColor = Color.FromArgb(6, 95, 70);
            dgv_DeclineStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_DeclineStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_DeclineStudent.DefaultCellStyle = dataGridViewCellStyle4;
            dgv_DeclineStudent.EnableHeadersVisualStyles = false;
            dgv_DeclineStudent.GridColor = SystemColors.WindowText;
            dgv_DeclineStudent.Location = new Point(12, 26);
            dgv_DeclineStudent.Margin = new Padding(3, 2, 3, 2);
            dgv_DeclineStudent.Name = "dgv_DeclineStudent";
            dgv_DeclineStudent.RowHeadersVisible = false;
            dgv_DeclineStudent.Size = new Size(392, 85);
            dgv_DeclineStudent.TabIndex = 1;
            // 
            // lblDeclinedTitle
            // 
            lblDeclinedTitle.AutoSize = true;
            lblDeclinedTitle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lblDeclinedTitle.ForeColor = Color.Black;
            lblDeclinedTitle.Location = new Point(138, 4);
            lblDeclinedTitle.Name = "lblDeclinedTitle";
            lblDeclinedTitle.Size = new Size(126, 18);
            lblDeclinedTitle.TabIndex = 0;
            lblDeclinedTitle.Text = "Declined Students";
            // 
            // pnlReports
            // 
            pnlReports.BackColor = Color.FromArgb(6, 95, 70);
            pnlReports.Controls.Add(dgvReportRecords);
            pnlReports.Controls.Add(lblReportsTitle);
            pnlReports.Location = new Point(18, 395);
            pnlReports.Margin = new Padding(3, 2, 3, 2);
            pnlReports.Name = "pnlReports";
            pnlReports.Size = new Size(844, 200);
            pnlReports.TabIndex = 8;
            // 
            // dgvReportRecords
            // 
            dgvReportRecords.BackgroundColor = Color.FromArgb(6, 95, 70);
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(4, 120, 87);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(4, 120, 87);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvReportRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvReportRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportRecords.Columns.AddRange(new DataGridViewColumn[] { colReportId, colReportedStudent, colReporter, colReason, colDate, colBlacklist });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(16, 185, 129);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvReportRecords.DefaultCellStyle = dataGridViewCellStyle4;
            dgvReportRecords.EnableHeadersVisualStyles = false;
            dgvReportRecords.GridColor = SystemColors.WindowText;
            dgvReportRecords.Location = new Point(18, 22);
            dgvReportRecords.Margin = new Padding(3, 2, 3, 2);
            dgvReportRecords.Name = "dgvReportRecords";
            dgvReportRecords.RowHeadersVisible = false;
            dgvReportRecords.RowHeadersWidth = 51;
            dgvReportRecords.Size = new Size(780, 141);
            dgvReportRecords.TabIndex = 1;
            // 
            // colReportId
            // 
            colReportId.HeaderText = "Report ID";
            colReportId.MinimumWidth = 6;
            colReportId.Name = "colReportId";
            colReportId.Width = 140;
            // 
            // colReportedStudent
            // 
            colReportedStudent.HeaderText = "Reported Student";
            colReportedStudent.MinimumWidth = 6;
            colReportedStudent.Name = "colReportedStudent";
            colReportedStudent.Width = 140;
            // 
            // colReporter
            // 
            colReporter.HeaderText = "Reporter";
            colReporter.MinimumWidth = 6;
            colReporter.Name = "colReporter";
            colReporter.Width = 140;
            // 
            // colReason
            // 
            colReason.HeaderText = "Reason of the Report";
            colReason.MinimumWidth = 6;
            colReason.Name = "colReason";
            colReason.Width = 140;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.Width = 140;
            // 
            // colBlacklist
            // 
            colBlacklist.HeaderText = "Admin Decision";
            colBlacklist.MinimumWidth = 6;
            colBlacklist.Name = "colBlacklist";
            colBlacklist.Width = 140;
            // 
            // lblReportsTitle
            // 
            lblReportsTitle.AutoSize = true;
            lblReportsTitle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lblReportsTitle.ForeColor = Color.Black;
            lblReportsTitle.Location = new Point(360, 4);
            lblReportsTitle.Name = "lblReportsTitle";
            lblReportsTitle.Size = new Size(128, 18);
            lblReportsTitle.TabIndex = 0;
            lblReportsTitle.Text = "Report Records";
            lblReportsTitle.Click += lblReportsTitle_Click;
            // 
            // uc_AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(pnlStatStudents);
            Controls.Add(pnlStatSkills);
            Controls.Add(pnlStatPending);
            Controls.Add(pnlStatReports);
            Controls.Add(pnlShortcuts);
            Controls.Add(pnlPendingVerif);
            Controls.Add(pnlBlacklisted);
            Controls.Add(pnlDeclined);
            Controls.Add(pnlReports);
            Name = "uc_AdminDashboard";
            Size = new Size(884, 615);
            Load += uc_AdminDashboard_Load;
            pnlStatStudents.ResumeLayout(false);
            pnlStatSkills.ResumeLayout(false);
            pnlStatPending.ResumeLayout(false);
            pnlStatReports.ResumeLayout(false);
            pnlShortcuts.ResumeLayout(false);
            pnlShortcuts.PerformLayout();
            pnlPendingVerif.ResumeLayout(false);
            pnlPendingVerif.PerformLayout();
            pnlBlacklisted.ResumeLayout(false);
            pnlBlacklisted.PerformLayout();
            pnlDeclined.ResumeLayout(false);
            pnlDeclined.PerformLayout();
            pnlReports.ResumeLayout(false);
            pnlReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportRecords).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_PendingStudentVerification).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_CurrentlyBlackLister).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_DeclineStudent).EndInit();
            ResumeLayout(false);
        }

        private void ConfigShortcutButton(Button btn, string text, EventHandler handler)
        {
            btn.Text = text;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btn.ForeColor = Color.Black;
            btn.BackColor = Color.FromArgb(14, 160, 110);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Size = new Size(143, 36);
            btn.Margin = new Padding(4);
            btn.Cursor = Cursors.Hand;
            btn.Click += handler;
        }

        #endregion

        // Stat tile
        private Panel pnlStatStudents;
        private Panel pnlStatSkills;
        private Panel pnlStatPending;
        private Panel pnlStatReports;
        private Label lblStatStudentsTitle;
        private Label lblTotalStudentCount;
        private Label lblStatSkillsTitle;
        private Label lblActiveSkillCount;
        private Label lblStatPendingTitle;
        private Label lblPendingSkillCount;
        private Label lblStatReportsTitle;
        private Label lblOpenReportsCount;

        // Quick shortcuts
        private Panel pnlShortcuts;

        // Pending verification
        private Panel pnlPendingVerif;
        private Label lblPendingVerifTitle;

        // Blacklisted
        private Panel pnlBlacklisted;
        private Label lblBlacklistedTitle;

        // Declined
        private Panel pnlDeclined;
        private Label lblDeclinedTitle;

        // Report records
        private Panel pnlReports;
        private Label lblReportsTitle;
        private Label label2;
        private Label label1;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flpBlacklisted;
        private FlowLayoutPanel flowLayoutPanel7;
        private FlowLayoutPanel flowLayoutPanel6;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flpPendingVerification;
        private FlowLayoutPanel flowLayoutPanel11;
        private FlowLayoutPanel flowLayoutPanel10;
        private FlowLayoutPanel flowLayoutPanel9;
        private FlowLayoutPanel flpDeclined;
        private Button button1;
        private DataGridView dgvReportRecords;
        private DataGridViewTextBoxColumn colReportId;
        private DataGridViewTextBoxColumn colReportedStudent;
        private DataGridViewTextBoxColumn colReporter;
        private DataGridViewTextBoxColumn colReason;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colBlacklist;
        private DataGridView dgv_PendingStudentVerification;
        private DataGridView dgv_CurrentlyBlackLister;
        private DataGridView dgv_DeclineStudent;
    }
}
