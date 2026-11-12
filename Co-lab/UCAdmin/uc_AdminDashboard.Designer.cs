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
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlAdminBadge = new Panel();
            lblDot = new Label();
            lblAdminText = new Label();

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
            label2 = new Label();
            lblShortcutsSub = new Label();
            btnManageStudents = new Button();
            btnCategories = new Button();
            btnModerateListings = new Button();
            btnReviewTickets = new Button();
            btnMonitorSwaps = new Button();
            btnExportReports = new Button();

            pnlPendingVerif = new Panel();
            lblPendingVerifTitle = new Label();
            dgv_PendingStudentVerification = new DataGridView();

            pnlBlacklisted = new Panel();
            lblBlacklistedTitle = new Label();
            dgv_CurrentlyBlackLister = new DataGridView();

            pnlDeclined = new Panel();
            lblDeclinedTitle = new Label();
            dgv_DeclineStudent = new DataGridView();

            pnlReports = new Panel();
            lblReportsTitle = new Label();
            dgvReportRecords = new DataGridView();

            pnlAdminBadge.SuspendLayout();
            pnlStatStudents.SuspendLayout();
            pnlStatSkills.SuspendLayout();
            pnlStatPending.SuspendLayout();
            pnlStatReports.SuspendLayout();
            pnlShortcuts.SuspendLayout();
            pnlPendingVerif.SuspendLayout();
            pnlBlacklisted.SuspendLayout();
            pnlDeclined.SuspendLayout();
            pnlReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_PendingStudentVerification).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_CurrentlyBlackLister).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_DeclineStudent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReportRecords).BeginInit();
            SuspendLayout();

            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(24, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(318, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Admin System Dashboard";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblHeaderSubtitle.Location = new Point(26, 48);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(430, 15);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Platform statistics, student verifications, safety moderation, and quick shortcuts";

            // 
            // pnlAdminBadge
            // 
            pnlAdminBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAdminBadge.BackColor = Color.FromArgb(20, 28, 23);
            pnlAdminBadge.Controls.Add(lblDot);
            pnlAdminBadge.Controls.Add(lblAdminText);
            pnlAdminBadge.Location = new Point(730, 18);
            pnlAdminBadge.Name = "pnlAdminBadge";
            pnlAdminBadge.Size = new Size(196, 36);
            pnlAdminBadge.TabIndex = 2;
            pnlAdminBadge.Paint += RoundPanel_Paint;

            // 
            // lblDot
            // 
            lblDot.AutoSize = true;
            lblDot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDot.ForeColor = Color.FromArgb(34, 197, 94);
            lblDot.Location = new Point(14, 7);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(16, 20);
            lblDot.TabIndex = 0;
            lblDot.Text = "●";

            // 
            // lblAdminText
            // 
            lblAdminText.AutoSize = true;
            lblAdminText.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAdminText.ForeColor = Color.White;
            lblAdminText.Location = new Point(34, 10);
            lblAdminText.Name = "lblAdminText";
            lblAdminText.Size = new Size(147, 15);
            lblAdminText.TabIndex = 1;
            lblAdminText.Text = "Logged In: Admin System";

            // 
            // pnlStatStudents
            // 
            pnlStatStudents.BackColor = Color.FromArgb(20, 28, 23);
            pnlStatStudents.Controls.Add(lblStatStudentsTitle);
            pnlStatStudents.Controls.Add(lblTotalStudentCount);
            pnlStatStudents.Location = new Point(24, 78);
            pnlStatStudents.Name = "pnlStatStudents";
            pnlStatStudents.Size = new Size(215, 95);
            pnlStatStudents.TabIndex = 3;
            pnlStatStudents.Paint += RoundPanel_Paint;

            // 
            // lblStatStudentsTitle
            // 
            lblStatStudentsTitle.Dock = DockStyle.Top;
            lblStatStudentsTitle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            lblStatStudentsTitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblStatStudentsTitle.Location = new Point(0, 0);
            lblStatStudentsTitle.Name = "lblStatStudentsTitle";
            lblStatStudentsTitle.Padding = new Padding(0, 12, 0, 0);
            lblStatStudentsTitle.Size = new Size(215, 34);
            lblStatStudentsTitle.TabIndex = 0;
            lblStatStudentsTitle.Text = "TOTAL REGISTERED STUDENTS";
            lblStatStudentsTitle.TextAlign = ContentAlignment.TopCenter;

            // 
            // lblTotalStudentCount
            // 
            lblTotalStudentCount.Dock = DockStyle.Fill;
            lblTotalStudentCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalStudentCount.ForeColor = Color.White;
            lblTotalStudentCount.Location = new Point(0, 34);
            lblTotalStudentCount.Name = "lblTotalStudentCount";
            lblTotalStudentCount.Size = new Size(215, 61);
            lblTotalStudentCount.TabIndex = 1;
            lblTotalStudentCount.Text = "0";
            lblTotalStudentCount.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlStatSkills
            // 
            pnlStatSkills.BackColor = Color.FromArgb(20, 28, 23);
            pnlStatSkills.Controls.Add(lblStatSkillsTitle);
            pnlStatSkills.Controls.Add(lblActiveSkillCount);
            pnlStatSkills.Location = new Point(259, 78);
            pnlStatSkills.Name = "pnlStatSkills";
            pnlStatSkills.Size = new Size(215, 95);
            pnlStatSkills.TabIndex = 4;
            pnlStatSkills.Paint += RoundPanel_Paint;

            // 
            // lblStatSkillsTitle
            // 
            lblStatSkillsTitle.Dock = DockStyle.Top;
            lblStatSkillsTitle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            lblStatSkillsTitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblStatSkillsTitle.Location = new Point(0, 0);
            lblStatSkillsTitle.Name = "lblStatSkillsTitle";
            lblStatSkillsTitle.Padding = new Padding(0, 12, 0, 0);
            lblStatSkillsTitle.Size = new Size(215, 34);
            lblStatSkillsTitle.TabIndex = 0;
            lblStatSkillsTitle.Text = "ACTIVE SKILL EXCHANGES";
            lblStatSkillsTitle.TextAlign = ContentAlignment.TopCenter;

            // 
            // lblActiveSkillCount
            // 
            lblActiveSkillCount.Dock = DockStyle.Fill;
            lblActiveSkillCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblActiveSkillCount.ForeColor = Color.FromArgb(74, 222, 128);
            lblActiveSkillCount.Location = new Point(0, 34);
            lblActiveSkillCount.Name = "lblActiveSkillCount";
            lblActiveSkillCount.Size = new Size(215, 61);
            lblActiveSkillCount.TabIndex = 1;
            lblActiveSkillCount.Text = "0";
            lblActiveSkillCount.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlStatPending
            // 
            pnlStatPending.BackColor = Color.FromArgb(20, 28, 23);
            pnlStatPending.Controls.Add(lblStatPendingTitle);
            pnlStatPending.Controls.Add(lblPendingSkillCount);
            pnlStatPending.Location = new Point(494, 78);
            pnlStatPending.Name = "pnlStatPending";
            pnlStatPending.Size = new Size(215, 95);
            pnlStatPending.TabIndex = 5;
            pnlStatPending.Paint += RoundPanel_Paint;

            // 
            // lblStatPendingTitle
            // 
            lblStatPendingTitle.Dock = DockStyle.Top;
            lblStatPendingTitle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            lblStatPendingTitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblStatPendingTitle.Location = new Point(0, 0);
            lblStatPendingTitle.Name = "lblStatPendingTitle";
            lblStatPendingTitle.Padding = new Padding(0, 12, 0, 0);
            lblStatPendingTitle.Size = new Size(215, 34);
            lblStatPendingTitle.TabIndex = 0;
            lblStatPendingTitle.Text = "PENDING SKILLS REVIEW";
            lblStatPendingTitle.TextAlign = ContentAlignment.TopCenter;

            // 
            // lblPendingSkillCount
            // 
            lblPendingSkillCount.Dock = DockStyle.Fill;
            lblPendingSkillCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPendingSkillCount.ForeColor = Color.FromArgb(250, 204, 21);
            lblPendingSkillCount.Location = new Point(0, 34);
            lblPendingSkillCount.Name = "lblPendingSkillCount";
            lblPendingSkillCount.Size = new Size(215, 61);
            lblPendingSkillCount.TabIndex = 1;
            lblPendingSkillCount.Text = "0";
            lblPendingSkillCount.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlStatReports
            // 
            pnlStatReports.BackColor = Color.FromArgb(20, 28, 23);
            pnlStatReports.Controls.Add(lblStatReportsTitle);
            pnlStatReports.Controls.Add(lblOpenReportsCount);
            pnlStatReports.Location = new Point(729, 78);
            pnlStatReports.Name = "pnlStatReports";
            pnlStatReports.Size = new Size(215, 95);
            pnlStatReports.TabIndex = 6;
            pnlStatReports.Paint += RoundPanel_Paint;

            // 
            // lblStatReportsTitle
            // 
            lblStatReportsTitle.Dock = DockStyle.Top;
            lblStatReportsTitle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            lblStatReportsTitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblStatReportsTitle.Location = new Point(0, 0);
            lblStatReportsTitle.Name = "lblStatReportsTitle";
            lblStatReportsTitle.Padding = new Padding(0, 12, 0, 0);
            lblStatReportsTitle.Size = new Size(215, 34);
            lblStatReportsTitle.TabIndex = 0;
            lblStatReportsTitle.Text = "OPEN INCIDENT REPORTS";
            lblStatReportsTitle.TextAlign = ContentAlignment.TopCenter;

            // 
            // lblOpenReportsCount
            // 
            lblOpenReportsCount.Dock = DockStyle.Fill;
            lblOpenReportsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblOpenReportsCount.ForeColor = Color.FromArgb(248, 113, 113);
            lblOpenReportsCount.Location = new Point(0, 34);
            lblOpenReportsCount.Name = "lblOpenReportsCount";
            lblOpenReportsCount.Size = new Size(215, 61);
            lblOpenReportsCount.TabIndex = 1;
            lblOpenReportsCount.Text = "0";
            lblOpenReportsCount.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlShortcuts
            // 
            pnlShortcuts.BackColor = Color.FromArgb(20, 28, 23);
            pnlShortcuts.Controls.Add(btnExportReports);
            pnlShortcuts.Controls.Add(btnMonitorSwaps);
            pnlShortcuts.Controls.Add(btnReviewTickets);
            pnlShortcuts.Controls.Add(btnModerateListings);
            pnlShortcuts.Controls.Add(btnCategories);
            pnlShortcuts.Controls.Add(btnManageStudents);
            pnlShortcuts.Controls.Add(lblShortcutsSub);
            pnlShortcuts.Controls.Add(label2);
            pnlShortcuts.Location = new Point(24, 185);
            pnlShortcuts.Name = "pnlShortcuts";
            pnlShortcuts.Size = new Size(350, 205);
            pnlShortcuts.TabIndex = 7;
            pnlShortcuts.Paint += RoundPanel_Paint;

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(74, 222, 128);
            label2.Location = new Point(16, 12);
            label2.Name = "label2";
            label2.Size = new Size(183, 21);
            label2.TabIndex = 0;
            label2.Text = "⚡ Quick Admin Shortcuts";

            // 
            // lblShortcutsSub
            // 
            lblShortcutsSub.AutoSize = true;
            lblShortcutsSub.Font = new Font("Segoe UI", 8.25F);
            lblShortcutsSub.ForeColor = Color.FromArgb(130, 175, 145);
            lblShortcutsSub.Location = new Point(18, 34);
            lblShortcutsSub.Name = "lblShortcutsSub";
            lblShortcutsSub.Size = new Size(207, 13);
            lblShortcutsSub.TabIndex = 1;
            lblShortcutsSub.Text = "One-click shortcuts to administration tools";

            // 
            // btnManageStudents
            // 
            FormatShortcutBtn(btnManageStudents, "👤 Students", new Point(18, 58), new Size(150, 36));
            btnManageStudents.Click += BtnManageStudents_Click;

            // 
            // btnCategories
            // 
            FormatShortcutBtn(btnCategories, "🏷️ Categories", new Point(178, 58), new Size(154, 36));
            btnCategories.Click += BtnCategories_Click;

            // 
            // btnModerateListings
            // 
            FormatShortcutBtn(btnModerateListings, "🛡️ Listings", new Point(18, 102), new Size(150, 36));
            btnModerateListings.Click += BtnModerateListings_Click;

            // 
            // btnReviewTickets
            // 
            FormatShortcutBtn(btnReviewTickets, "🚩 Reports", new Point(178, 102), new Size(154, 36));
            btnReviewTickets.Click += BtnReviewTickets_Click;

            // 
            // btnMonitorSwaps
            // 
            FormatShortcutBtn(btnMonitorSwaps, "🔄 Swaps Log", new Point(18, 146), new Size(150, 36));
            btnMonitorSwaps.Click += BtnMonitorSwaps_Click;

            // 
            // btnExportReports
            // 
            FormatShortcutBtn(btnExportReports, "📊 Export CSV", new Point(178, 146), new Size(154, 36));
            btnExportReports.Click += BtnExportReports_Click;

            // 
            // pnlPendingVerif
            // 
            pnlPendingVerif.BackColor = Color.FromArgb(20, 28, 23);
            pnlPendingVerif.Controls.Add(dgv_PendingStudentVerification);
            pnlPendingVerif.Controls.Add(lblPendingVerifTitle);
            pnlPendingVerif.Location = new Point(390, 185);
            pnlPendingVerif.Name = "pnlPendingVerif";
            pnlPendingVerif.Size = new Size(554, 205);
            pnlPendingVerif.TabIndex = 8;
            pnlPendingVerif.Paint += RoundPanel_Paint;

            // 
            // lblPendingVerifTitle
            // 
            lblPendingVerifTitle.AutoSize = true;
            lblPendingVerifTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblPendingVerifTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblPendingVerifTitle.Location = new Point(16, 12);
            lblPendingVerifTitle.Name = "lblPendingVerifTitle";
            lblPendingVerifTitle.Size = new Size(229, 21);
            lblPendingVerifTitle.TabIndex = 0;
            lblPendingVerifTitle.Text = "⏳ Pending Student Verification";

            // 
            // dgv_PendingStudentVerification
            // 
            dgv_PendingStudentVerification.Location = new Point(16, 42);
            dgv_PendingStudentVerification.Name = "dgv_PendingStudentVerification";
            dgv_PendingStudentVerification.Size = new Size(522, 145);
            dgv_PendingStudentVerification.TabIndex = 1;

            // 
            // pnlBlacklisted
            // 
            pnlBlacklisted.BackColor = Color.FromArgb(20, 28, 23);
            pnlBlacklisted.Controls.Add(dgv_CurrentlyBlackLister);
            pnlBlacklisted.Controls.Add(lblBlacklistedTitle);
            pnlBlacklisted.Location = new Point(24, 402);
            pnlBlacklisted.Name = "pnlBlacklisted";
            pnlBlacklisted.Size = new Size(440, 215);
            pnlBlacklisted.TabIndex = 9;
            pnlBlacklisted.Paint += RoundPanel_Paint;

            // 
            // lblBlacklistedTitle
            // 
            lblBlacklistedTitle.AutoSize = true;
            lblBlacklistedTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblBlacklistedTitle.ForeColor = Color.FromArgb(248, 113, 113);
            lblBlacklistedTitle.Location = new Point(16, 12);
            lblBlacklistedTitle.Name = "lblBlacklistedTitle";
            lblBlacklistedTitle.Size = new Size(244, 21);
            lblBlacklistedTitle.TabIndex = 0;
            lblBlacklistedTitle.Text = "🚫 Currently Blacklisted Students";

            // 
            // dgv_CurrentlyBlackLister
            // 
            dgv_CurrentlyBlackLister.Location = new Point(16, 42);
            dgv_CurrentlyBlackLister.Name = "dgv_CurrentlyBlackLister";
            dgv_CurrentlyBlackLister.Size = new Size(408, 155);
            dgv_CurrentlyBlackLister.TabIndex = 1;

            // 
            // pnlDeclined
            // 
            pnlDeclined.BackColor = Color.FromArgb(20, 28, 23);
            pnlDeclined.Controls.Add(dgv_DeclineStudent);
            pnlDeclined.Controls.Add(lblDeclinedTitle);
            pnlDeclined.Location = new Point(480, 402);
            pnlDeclined.Name = "pnlDeclined";
            pnlDeclined.Size = new Size(464, 215);
            pnlDeclined.TabIndex = 10;
            pnlDeclined.Paint += RoundPanel_Paint;

            // 
            // lblDeclinedTitle
            // 
            lblDeclinedTitle.AutoSize = true;
            lblDeclinedTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblDeclinedTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblDeclinedTitle.Location = new Point(16, 12);
            lblDeclinedTitle.Name = "lblDeclinedTitle";
            lblDeclinedTitle.Size = new Size(281, 21);
            lblDeclinedTitle.TabIndex = 0;
            lblDeclinedTitle.Text = "❌ Declined Students / Dismissed Reports";

            // 
            // dgv_DeclineStudent
            // 
            dgv_DeclineStudent.Location = new Point(16, 42);
            dgv_DeclineStudent.Name = "dgv_DeclineStudent";
            dgv_DeclineStudent.Size = new Size(432, 155);
            dgv_DeclineStudent.TabIndex = 1;

            // 
            // pnlReports
            // 
            pnlReports.BackColor = Color.FromArgb(20, 28, 23);
            pnlReports.Controls.Add(dgvReportRecords);
            pnlReports.Controls.Add(lblReportsTitle);
            pnlReports.Location = new Point(24, 629);
            pnlReports.Name = "pnlReports";
            pnlReports.Size = new Size(920, 255);
            pnlReports.TabIndex = 11;
            pnlReports.Paint += RoundPanel_Paint;

            // 
            // lblReportsTitle
            // 
            lblReportsTitle.AutoSize = true;
            lblReportsTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblReportsTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblReportsTitle.Location = new Point(16, 12);
            lblReportsTitle.Name = "lblReportsTitle";
            lblReportsTitle.Size = new Size(276, 21);
            lblReportsTitle.TabIndex = 0;
            lblReportsTitle.Text = "🚩 Report Records & Moderation Actions";

            // 
            // dgvReportRecords
            // 
            dgvReportRecords.Location = new Point(16, 42);
            dgvReportRecords.Name = "dgvReportRecords";
            dgvReportRecords.Size = new Size(888, 195);
            dgvReportRecords.TabIndex = 1;

            // 
            // uc_AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(920, 900);
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlReports);
            Controls.Add(pnlDeclined);
            Controls.Add(pnlBlacklisted);
            Controls.Add(pnlPendingVerif);
            Controls.Add(pnlShortcuts);
            Controls.Add(pnlStatReports);
            Controls.Add(pnlStatPending);
            Controls.Add(pnlStatSkills);
            Controls.Add(pnlStatStudents);
            Controls.Add(pnlAdminBadge);
            Controls.Add(lblHeaderSubtitle);
            Controls.Add(lblHeaderTitle);
            Name = "uc_AdminDashboard";
            Size = new Size(960, 910);
            Load += uc_AdminDashboard_Load;
            Resize += uc_AdminDashboard_Resize;

            pnlAdminBadge.ResumeLayout(false);
            pnlAdminBadge.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)dgv_PendingStudentVerification).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_CurrentlyBlackLister).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_DeclineStudent).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReportRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private static void FormatShortcutBtn(Button btn, string text, Point loc, Size sz)
        {
            btn.Text = text;
            btn.Location = loc;
            btn.Size = sz;
            btn.BackColor = Color.FromArgb(28, 38, 30);
            btn.ForeColor = Color.FromArgb(220, 235, 225);
            btn.Font = new Font("Segoe UI Semibold", 8.5F);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 65, 48);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        #endregion

        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlAdminBadge;
        private Label lblDot;
        private Label lblAdminText;

        // Stat tiles
        private Panel pnlStatStudents;
        private Label lblStatStudentsTitle;
        private Label lblTotalStudentCount;

        private Panel pnlStatSkills;
        private Label lblStatSkillsTitle;
        private Label lblActiveSkillCount;

        private Panel pnlStatPending;
        private Label lblStatPendingTitle;
        private Label lblPendingSkillCount;

        private Panel pnlStatReports;
        private Label lblStatReportsTitle;
        private Label lblOpenReportsCount;

        // Quick shortcuts
        private Panel pnlShortcuts;
        private Label label2;
        private Label lblShortcutsSub;
        private Button btnManageStudents;
        private Button btnCategories;
        private Button btnModerateListings;
        private Button btnReviewTickets;
        private Button btnMonitorSwaps;
        private Button btnExportReports;

        // Pending verification
        private Panel pnlPendingVerif;
        private Label lblPendingVerifTitle;
        private DataGridView dgv_PendingStudentVerification;

        // Blacklisted
        private Panel pnlBlacklisted;
        private Label lblBlacklistedTitle;
        private DataGridView dgv_CurrentlyBlackLister;

        // Declined
        private Panel pnlDeclined;
        private Label lblDeclinedTitle;
        private DataGridView dgv_DeclineStudent;

        // Report records
        private Panel pnlReports;
        private Label lblReportsTitle;
        private DataGridView dgvReportRecords;
    }
}