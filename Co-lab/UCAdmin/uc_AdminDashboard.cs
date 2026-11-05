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
        // PENDING STUDENT VERIFICATIONS
        // =====================================================
        private void LoadPendingVerifications()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT UserId, FullName, Email FROM tbl_users WHERE Role = 'Student' AND is_blacklisted = 0 ORDER BY UserId DESC LIMIT 4");

                flpPendingVerification.Controls.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    flpPendingVerification.Controls.Add(
                        CreateVerificationCard(
                            row["UserId"].ToString()!,
                            row["FullName"].ToString()!,
                            row["Email"].ToString()!));
                }
            }
            catch
            {
                // DB offline — show nothing
            }
        }

        private Panel CreateVerificationCard(string userId, string name, string email)
        {
            var card = new Panel
            {
                Width = 210,
                Height = 55,
                BackColor = Color.FromArgb(14, 160, 110),
                Margin = new Padding(4),
                Cursor = Cursors.Default
            };

            var lblName = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(6, 6),
                AutoSize = false,
                Width = 135,
                Height = 20
            };

            var lblEmail = new Label
            {
                Text = email,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.FromArgb(20, 50, 35),
                Location = new Point(6, 27),
                AutoSize = false,
                Width = 135,
                Height = 18
            };

            var btnApprove = new Button
            {
                Text = "Approve",
                Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(22, 101, 67),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(62, 28),
                Location = new Point(143, 13),
                Cursor = Cursors.Hand,
                Tag = userId
            };
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.Click += BtnApproveStudent_Click;

            card.Controls.Add(lblName);
            card.Controls.Add(lblEmail);
            card.Controls.Add(btnApprove);
            return card;
        }

        private void BtnApproveStudent_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is string userId)
            {
                var result = MessageBox.Show(
                    "Approve this student account?",
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(
                            "UPDATE tbl_users SET is_blacklisted = 0 WHERE UserId = @id",
                            new MySqlParameter("@id", userId));

                        MessageBox.Show("Student approved successfully.", "Approved",
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
                    "SELECT FullName, BanReason FROM tbl_users WHERE is_blacklisted = 1 ORDER BY UserId DESC LIMIT 4");

                flpBlacklisted.Controls.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    flpBlacklisted.Controls.Add(
                        CreateBlacklistRow(
                            row["FullName"].ToString()!,
                            row["BanReason"]?.ToString() ?? "No reason provided"));
                }

                if (dt.Rows.Count == 0)
                {
                    flpBlacklisted.Controls.Add(new Label
                    {
                        Text = "No blacklisted students.",
                        ForeColor = Color.FromArgb(20, 50, 35),
                        Font = new Font("Segoe UI", 9f),
                        AutoSize = true,
                        Margin = new Padding(6, 8, 0, 0)
                    });
                }
            }
            catch
            {
                // DB offline
            }
        }

        private Panel CreateBlacklistRow(string name, string reason)
        {
            var row = new Panel
            {
                Width = 390,
                Height = 30,
                BackColor = Color.FromArgb(14, 160, 110),
                Margin = new Padding(4, 3, 4, 0)
            };

            var lbl = new Label
            {
                Text = $"{name}  —  {reason}",
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            row.Controls.Add(lbl);
            return row;
        }

        // =====================================================
        // DECLINED STUDENTS
        // =====================================================
        private void LoadDeclinedStudents()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT UserId, FullName, Email FROM tbl_users WHERE is_blacklisted = 1 ORDER BY UserId DESC LIMIT 4");

                flpDeclined.Controls.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    flpDeclined.Controls.Add(
                        CreateDeclinedCard(
                            row["UserId"].ToString()!,
                            row["FullName"].ToString()!,
                            row["Email"].ToString()!));
                }
            }
            catch
            {
                // DB offline?
            }
        }

        private Panel CreateDeclinedCard(string userId, string name, string email)
        {
            var card = new Panel
            {
                Width = 210,
                Height = 55,
                BackColor = Color.FromArgb(14, 160, 110),
                Margin = new Padding(4),
                Cursor = Cursors.Default
            };

            var lblName = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(6, 6),
                AutoSize = false,
                Width = 135,
                Height = 20
            };

            var lblEmail = new Label
            {
                Text = email,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.FromArgb(20, 50, 35),
                Location = new Point(6, 27),
                AutoSize = false,
                Width = 135,
                Height = 18
            };

            var btnDeclined = new Button
            {
                Text = "DECLINED",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(200, 30, 30),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(62, 28),
                Location = new Point(143, 13),
                Cursor = Cursors.Default,
                Enabled = false
            };
            btnDeclined.FlatAppearance.BorderSize = 0;

            card.Controls.Add(lblName);
            card.Controls.Add(lblEmail);
            card.Controls.Add(btnDeclined);
            return card;
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
