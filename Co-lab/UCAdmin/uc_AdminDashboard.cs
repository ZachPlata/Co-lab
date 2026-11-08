using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_AdminDashboard : UserControl
    {
        public uc_AdminDashboard()
        {
            InitializeComponent();
            SetupDataGrids();
        }

        private void uc_AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        // =====================================================
        // LOAD ALL DASHBOARD DATA
        // =====================================================
        public void LoadDashboard()
        {
            LoadStats();
            LoadPendingVerifications();
            LoadBlacklisted();
            LoadDeclinedStudents();
            LoadReportRecords();
        }

        // =====================================================
        // STATS: Total Registered Students & Active Skill Exchanges
        // =====================================================
        private void LoadStats()
        {
            try
            {
                object? totalStudents = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_users WHERE Role = 'Student'");
                lblTotalStudentCount.Text = totalStudents?.ToString() ?? "0";

                object? activeSkills = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_skills WHERE Status = 'Active'");
                lblActiveSkillCount.Text = activeSkills?.ToString() ?? "0";

                object? pendingSkills = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_skills WHERE Status = 'Under Review'");
                lblPendingSkillCount.Text = pendingSkills?.ToString() ?? "0";

                object? openReports = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_reports WHERE Status = 'Pending'");
                lblOpenReportsCount.Text = openReports?.ToString() ?? "0";
            }
            catch
            {
                lblTotalStudentCount.Text = "—";
                lblActiveSkillCount.Text = "—";
                lblPendingSkillCount.Text = "—";
                lblOpenReportsCount.Text = "—";
            }
        }

        // =====================================================
        // DATAGRIDVIEW SETUP & STYLING
        // =====================================================
        private void SetupDataGrids()
        {
            SetupDataGridStyle(dgv_PendingStudentVerification);
            SetupDataGridStyle(dgv_CurrentlyBlackLister);
            SetupDataGridStyle(dgv_DeclineStudent);

            // 1. Pending Student Verification DataGridView
            if (dgv_PendingStudentVerification.Columns.Count == 0)
            {
                dgv_PendingStudentVerification.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colPendingId",
                    HeaderText = "ID",
                    Visible = false
                });
                dgv_PendingStudentVerification.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colPendingName",
                    HeaderText = "Student Name",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    MinimumWidth = 100
                });
                dgv_PendingStudentVerification.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colPendingEmail",
                    HeaderText = "Email",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    MinimumWidth = 120
                });
                dgv_PendingStudentVerification.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colPendingApprove",
                    HeaderText = "Action",
                    Text = "Approve",
                    UseColumnTextForButtonValue = true,
                    Width = 70,
                    FlatStyle = FlatStyle.Flat
                });
            }
            dgv_PendingStudentVerification.CellContentClick -= dgv_PendingStudentVerification_CellContentClick;
            dgv_PendingStudentVerification.CellContentClick += dgv_PendingStudentVerification_CellContentClick;

            // 2. Currently Blacklisted DataGridView
            if (dgv_CurrentlyBlackLister.Columns.Count == 0)
            {
                dgv_CurrentlyBlackLister.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colBlacklistId",
                    HeaderText = "ID",
                    Visible = false
                });
                dgv_CurrentlyBlackLister.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colBlacklistName",
                    HeaderText = "Student Name",
                    Width = 110
                });
                dgv_CurrentlyBlackLister.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colBlacklistReason",
                    HeaderText = "Reason",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    MinimumWidth = 120
                });
                dgv_CurrentlyBlackLister.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colBlacklistUnban",
                    HeaderText = "Action",
                    Text = "Unban",
                    UseColumnTextForButtonValue = true,
                    Width = 65,
                    FlatStyle = FlatStyle.Flat
                });
            }
            dgv_CurrentlyBlackLister.CellContentClick -= dgv_CurrentlyBlackLister_CellContentClick;
            dgv_CurrentlyBlackLister.CellContentClick += dgv_CurrentlyBlackLister_CellContentClick;

            // 3. Declined Students DataGridView
            if (dgv_DeclineStudent.Columns.Count == 0)
            {
                dgv_DeclineStudent.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colDeclinedName",
                    HeaderText = "Student Name",
                    Width = 115
                });
                dgv_DeclineStudent.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colDeclinedReason",
                    HeaderText = "Reason / Notes",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    MinimumWidth = 120
                });
                dgv_DeclineStudent.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colDeclinedStatus",
                    HeaderText = "Status",
                    Width = 75
                });
            }
        }

        private void SetupDataGridStyle(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.BackgroundColor = Color.FromArgb(6, 95, 70);
            dgv.GridColor = Color.FromArgb(16, 185, 129);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(4, 75, 55);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 26;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(16, 185, 129);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 211, 153);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8.5f);
            dgv.RowTemplate.Height = 24;
        }

        // =====================================================
        // PENDING STUDENT VERIFICATIONS
        // =====================================================
        private static bool _verifiedColumnChecked = false;

        private void EnsureVerificationColumnExists()
        {
            if (_verifiedColumnChecked) return;
            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    "ALTER TABLE tbl_users ADD COLUMN IF NOT EXISTS is_verified TINYINT(1) DEFAULT 0");
                _verifiedColumnChecked = true;
            }
            catch
            {
                // Column may already exist or DB offline
            }
        }

        private void LoadPendingVerifications()
        {
            try
            {
                EnsureVerificationColumnExists();

                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT UserId, FullName, Email FROM tbl_users WHERE Role = 'Student' AND is_verified = 0 AND is_blacklisted = 0 ORDER BY UserId DESC LIMIT 10");

                dgv_PendingStudentVerification.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string userId = row["UserId"].ToString()!;
                    string fullName = row["FullName"].ToString()!;
                    string email = row["Email"].ToString()!;

                    dgv_PendingStudentVerification.Rows.Add(userId, fullName, email);
                }
            }
            catch
            {
                // DB offline — leave table empty
            }
        }

        private void dgv_PendingStudentVerification_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgv_PendingStudentVerification.Columns["colPendingApprove"]?.Index)
            {
                string userId = dgv_PendingStudentVerification.Rows[e.RowIndex].Cells["colPendingId"].Value?.ToString() ?? "";
                string fullName = dgv_PendingStudentVerification.Rows[e.RowIndex].Cells["colPendingName"].Value?.ToString() ?? "";

                var result = MessageBox.Show(
                    $"Approve and verify student account for '{fullName}'?",
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(
                            "UPDATE tbl_users SET is_verified = 1 WHERE UserId = @id",
                            new MySqlParameter("@id", userId));

                        MessageBox.Show($"Student account for '{fullName}' approved and verified successfully.", "Approved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDashboard();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =====================================================
        // CURRENTLY BLACKLISTED
        // =====================================================
        private void LoadBlacklisted()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT UserId, FullName, Email, COALESCE(BanReason, 'Blacklisted via Report') AS BanReason FROM tbl_users WHERE is_blacklisted = 1 ORDER BY UserId DESC LIMIT 10");

                dgv_CurrentlyBlackLister.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string userId = row["UserId"].ToString()!;
                    string fullName = row["FullName"].ToString()!;
                    string banReason = row["BanReason"].ToString()!;

                    dgv_CurrentlyBlackLister.Rows.Add(userId, fullName, banReason);
                }
            }
            catch
            {
                // DB offline — leave table empty
            }
        }

        private void dgv_CurrentlyBlackLister_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgv_CurrentlyBlackLister.Columns["colBlacklistUnban"]?.Index)
            {
                string userId = dgv_CurrentlyBlackLister.Rows[e.RowIndex].Cells["colBlacklistId"].Value?.ToString() ?? "";
                string fullName = dgv_CurrentlyBlackLister.Rows[e.RowIndex].Cells["colBlacklistName"].Value?.ToString() ?? "";

                var result = MessageBox.Show(
                    $"Unban student '{fullName}'?",
                    "Confirm Unban",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(
                            "UPDATE tbl_users SET is_blacklisted = 0, BanReason = NULL WHERE UserId = @id",
                            new MySqlParameter("@id", userId));

                        MessageBox.Show($"Student '{fullName}' has been unbanned.", "Unbanned",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDashboard();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =====================================================
        // DECLINED STUDENTS
        // =====================================================
        private void LoadDeclinedStudents()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT ReportedUser AS StudentName, Reason, Status FROM tbl_reports WHERE Status IN ('Dismissed', 'Declined') " +
                    "UNION ALL " +
                    "SELECT SenderName AS StudentName, CONCAT('Proposal: ', OfferedSkillTitle) AS Reason, Status FROM tbl_traderequests WHERE Status = 'Declined' " +
                    "LIMIT 10");

                dgv_DeclineStudent.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string studentName = row["StudentName"]?.ToString() ?? "";
                    string reason = row["Reason"]?.ToString() ?? "";
                    string status = row["Status"]?.ToString() ?? "";

                    dgv_DeclineStudent.Rows.Add(studentName, reason, status);
                }
            }
            catch
            {
                // DB offline — leave table empty
            }
        }

        // =====================================================
        // REPORT RECORDS TABLE
        // =====================================================
        private void LoadReportRecords()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT ReportId, ReportedUser, Reason, ReportDate, Status FROM tbl_reports ORDER BY ReportId DESC LIMIT 10");

                dgvReportRecords.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string reportId = row["ReportId"].ToString()!;
                    string reportedUser = row["ReportedUser"].ToString()!;
                    string reason = row["Reason"].ToString()!;
                    string date = Convert.ToDateTime(row["ReportDate"]).ToString("MM/dd/yyyy");
                    string status = row["Status"].ToString()!;

                    dgvReportRecords.Rows.Add(reportId, reportedUser, reason, date, status);
                }
            }
            catch
            {
                // DB offline — leave table empty
            }
        }

        // =====================================================
        // QUICK ADMIN SHORTCUTS
        // =====================================================
        private void BtnManageStudents_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is AdminMainForm form)
                form.NavigateTo("StudentAccounts");
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is AdminMainForm form)
                form.NavigateTo("SkillCategories");
        }

        private void BtnModerateListings_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is AdminMainForm form)
                form.NavigateTo("ModerateListings");
        }

        private void BtnReviewTickets_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is AdminMainForm form)
                form.NavigateTo("ReviewTickets");
        }

        private void BtnMonitorSwaps_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Monitor Swaps feature coming soon.", "Coming Soon",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExportReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export Reports feature coming soon.", "Coming Soon",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================
        // REPORT RECORDS: BLACKLIST / DISMISS BUTTONS
        // =====================================================
        private void dgvReportRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvReportRecords.Columns["colBlacklist"]?.Index)
            {
                string reportedUser = dgvReportRecords.Rows[e.RowIndex].Cells["colReportedUser"].Value?.ToString() ?? "";
                string reportId = dgvReportRecords.Rows[e.RowIndex].Cells["colReportId"].Value?.ToString() ?? "";

                var result = MessageBox.Show(
                    $"Blacklist student '{reportedUser}'?",
                    "Confirm Blacklist",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(
                            "UPDATE tbl_users SET is_blacklisted = 1, BanReason = 'Blacklisted via Report' WHERE FullName = @name",
                            new MySqlParameter("@name", reportedUser));
                        DatabaseHelper.ExecuteNonQuery(
                            "UPDATE tbl_reports SET Status = 'Reviewed' WHERE ReportId = @id",
                            new MySqlParameter("@id", reportId));

                        MessageBox.Show("Student blacklisted.", "Done",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDashboard();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == dgvReportRecords.Columns["colDismiss"]?.Index)
            {
                string reportId = dgvReportRecords.Rows[e.RowIndex].Cells["colReportId"].Value?.ToString() ?? "";

                try
                {
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE tbl_reports SET Status = 'Dismissed' WHERE ReportId = @id",
                        new MySqlParameter("@id", reportId));

                    MessageBox.Show("Report dismissed.", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDashboard();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =====================================================
        // UNUSED DESIGNER EVENT STUBS
        // =====================================================
        private void label1_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void lblReportsTitle_Click(object sender, EventArgs e)
        {

        }

        private void flpBlacklisted_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pnlStatPending_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
