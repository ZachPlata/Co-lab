using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetupDataGrids();
        }

        private void uc_AdminDashboard_Load(object sender, EventArgs e)
        {
            uc_AdminDashboard_Resize(this, EventArgs.Empty);
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
            // 1. Pending Student Verification DataGridView
            SetupDataGridStyle(dgv_PendingStudentVerification);
            dgv_PendingStudentVerification.Columns.Clear();
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
                Width = 160
            });
            dgv_PendingStudentVerification.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPendingEmail",
                HeaderText = "Email Address",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 140
            });
            var colPendingApprove = new DataGridViewButtonColumn
            {
                Name = "colPendingApprove",
                HeaderText = "Action",
                Text = "✓ Approve",
                UseColumnTextForButtonValue = true,
                Width = 90,
                FlatStyle = FlatStyle.Flat
            };
            colPendingApprove.DefaultCellStyle.BackColor = Color.FromArgb(46, 125, 70);
            colPendingApprove.DefaultCellStyle.ForeColor = Color.White;
            dgv_PendingStudentVerification.Columns.Add(colPendingApprove);

            dgv_PendingStudentVerification.CellContentClick -= dgv_PendingStudentVerification_CellContentClick;
            dgv_PendingStudentVerification.CellContentClick += dgv_PendingStudentVerification_CellContentClick;
            dgv_PendingStudentVerification.CellFormatting += DgvApprove_CellFormatting;

            // 2. Currently Blacklisted DataGridView
            SetupDataGridStyle(dgv_CurrentlyBlackLister);
            dgv_CurrentlyBlackLister.Columns.Clear();
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
                Width = 130
            });
            dgv_CurrentlyBlackLister.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBlacklistReason",
                HeaderText = "Reason",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 130
            });
            var colBlacklistUnban = new DataGridViewButtonColumn
            {
                Name = "colBlacklistUnban",
                HeaderText = "Action",
                Text = "Unban",
                UseColumnTextForButtonValue = true,
                Width = 75,
                FlatStyle = FlatStyle.Flat
            };
            colBlacklistUnban.DefaultCellStyle.BackColor = Color.FromArgb(28, 38, 30);
            colBlacklistUnban.DefaultCellStyle.ForeColor = Color.FromArgb(74, 222, 128);
            dgv_CurrentlyBlackLister.Columns.Add(colBlacklistUnban);

            dgv_CurrentlyBlackLister.CellContentClick -= dgv_CurrentlyBlackLister_CellContentClick;
            dgv_CurrentlyBlackLister.CellContentClick += dgv_CurrentlyBlackLister_CellContentClick;

            // 3. Declined Students DataGridView
            SetupDataGridStyle(dgv_DeclineStudent);
            dgv_DeclineStudent.Columns.Clear();
            dgv_DeclineStudent.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDeclinedName",
                HeaderText = "Student Name",
                Width = 125
            });
            dgv_DeclineStudent.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDeclinedReason",
                HeaderText = "Reason / Notes",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 140
            });
            dgv_DeclineStudent.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDeclinedStatus",
                HeaderText = "Status",
                Width = 85
            });

            // 4. Report Records DataGridView
            SetupDataGridStyle(dgvReportRecords);
            dgvReportRecords.Columns.Clear();
            dgvReportRecords.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colReportId",
                HeaderText = "ID",
                Width = 55
            });
            dgvReportRecords.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colReportedStudent",
                HeaderText = "Reported Student",
                Width = 150
            });
            dgvReportRecords.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colReason",
                HeaderText = "Reason of Report",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 180
            });
            dgvReportRecords.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "Date",
                Width = 95
            });
            dgvReportRecords.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Status",
                Width = 85
            });
            var colBlacklist = new DataGridViewButtonColumn
            {
                Name = "colBlacklist",
                HeaderText = "Blacklist",
                Text = "Blacklist",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Flat
            };
            colBlacklist.DefaultCellStyle.BackColor = Color.FromArgb(45, 24, 26);
            colBlacklist.DefaultCellStyle.ForeColor = Color.FromArgb(248, 113, 113);
            dgvReportRecords.Columns.Add(colBlacklist);

            var colDismiss = new DataGridViewButtonColumn
            {
                Name = "colDismiss",
                HeaderText = "Dismiss",
                Text = "Dismiss",
                UseColumnTextForButtonValue = true,
                Width = 75,
                FlatStyle = FlatStyle.Flat
            };
            colDismiss.DefaultCellStyle.BackColor = Color.FromArgb(28, 38, 30);
            colDismiss.DefaultCellStyle.ForeColor = Color.FromArgb(200, 220, 208);
            dgvReportRecords.Columns.Add(colDismiss);

            dgvReportRecords.CellContentClick -= dgvReportRecords_CellContentClick;
            dgvReportRecords.CellContentClick += dgvReportRecords_CellContentClick;
            dgvReportRecords.CellFormatting += DgvReports_CellFormatting;
        }

        private void DgvApprove_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_PendingStudentVerification.Columns["colPendingApprove"]?.Index)
            {
                e.CellStyle!.BackColor = Color.FromArgb(34, 85, 52);
                e.CellStyle.ForeColor = Color.FromArgb(167, 243, 208);
                e.CellStyle.SelectionBackColor = Color.FromArgb(46, 115, 70);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private void DgvReports_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvReportRecords.Columns["colBlacklist"]?.Index)
            {
                e.CellStyle!.BackColor = Color.FromArgb(50, 25, 28);
                e.CellStyle.ForeColor = Color.FromArgb(248, 113, 113);
                e.CellStyle.SelectionBackColor = Color.FromArgb(70, 30, 34);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == dgvReportRecords.Columns["colDismiss"]?.Index)
            {
                e.CellStyle!.BackColor = Color.FromArgb(28, 38, 30);
                e.CellStyle.ForeColor = Color.FromArgb(200, 220, 208);
                e.CellStyle.SelectionBackColor = Color.FromArgb(42, 60, 48);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private void SetupDataGridStyle(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.BackgroundColor = Color.FromArgb(14, 20, 16);
            dgv.GridColor = Color.FromArgb(30, 44, 34);
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

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 28, 23);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(74, 222, 128);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(20, 28, 23);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(74, 222, 128);
            dgv.ColumnHeadersHeight = 32;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(18, 25, 20);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(228, 228, 231);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.RowTemplate.Height = 32;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(15, 22, 17);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(228, 228, 231);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
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
        private void BtnManageStudents_Click(object? sender, EventArgs e)
        {
            if (this.FindForm() is AdminMainForm form)
                form.NavigateTo("StudentAccounts");
        }

        private void BtnCategories_Click(object? sender, EventArgs e)
        {
            if (this.FindForm() is AdminMainForm form)
                form.NavigateTo("SkillCategories");
        }

        private void BtnModerateListings_Click(object? sender, EventArgs e)
        {
            if (this.FindForm() is AdminMainForm form)
                form.NavigateTo("ModerateListings");
        }

        private void BtnReviewTickets_Click(object? sender, EventArgs e)
        {
            if (this.FindForm() is AdminMainForm form)
                form.NavigateTo("ReviewTickets");
        }

        private void BtnMonitorSwaps_Click(object? sender, EventArgs e)
        {
            try
            {
                int total = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM tbl_traderequests") ?? 0);
                int pending = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM tbl_traderequests WHERE Status = 'Pending' OR Status IS NULL") ?? 0);
                int accepted = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM tbl_traderequests WHERE Status = 'Accepted'") ?? 0);
                int declined = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM tbl_traderequests WHERE Status = 'Declined'") ?? 0);

                MessageBox.Show(
                    $"Co-LAB Skill Exchange Swap Summary:\n\n" +
                    $"• Total Proposals: {total}\n" +
                    $"• Pending Proposals: {pending}\n" +
                    $"• Accepted Swaps: {accepted}\n" +
                    $"• Declined Proposals: {declined}",
                    "Monitor Swaps",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not fetch swap statistics: {ex.Message}", "Database Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExportReports_Click(object? sender, EventArgs e)
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT ReportId, ReportedUser, Reason, ReportDate, Status FROM tbl_reports ORDER BY ReportId DESC");

                using var sfd = new SaveFileDialog
                {
                    Title = "Export Reports to CSV",
                    Filter = "CSV Files (*.csv)|*.csv",
                    FileName = $"CoLab_Reports_{DateTime.Now:yyyyMMdd_HHmm}.csv"
                };

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    var lines = new System.Collections.Generic.List<string>
                    {
                        "ReportId,ReportedUser,Reason,ReportDate,Status"
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["ReportId"]?.ToString() ?? "";
                        string user = (row["ReportedUser"]?.ToString() ?? "").Replace("\"", "\"\"");
                        string reason = (row["Reason"]?.ToString() ?? "").Replace("\"", "\"\"");
                        string date = row["ReportDate"]?.ToString() ?? "";
                        string status = row["Status"]?.ToString() ?? "";
                        lines.Add($"{id},\"{user}\",\"{reason}\",\"{date}\",{status}");
                    }

                    System.IO.File.WriteAllLines(sfd.FileName, lines);
                    MessageBox.Show($"Exported {dt.Rows.Count} report(s) to:\n{sfd.FileName}", "Export Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting reports: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // REPORT RECORDS: BLACKLIST / DISMISS BUTTONS
        // =====================================================
        private void dgvReportRecords_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvReportRecords.Columns["colBlacklist"]?.Index)
            {
                string reportedUser = dgvReportRecords.Rows[e.RowIndex].Cells["colReportedStudent"].Value?.ToString() ?? "";
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
        // RESPONSIVE LAYOUT (MINIMIZED & MAXIMIZED MODES)
        // =====================================================
        private void uc_AdminDashboard_Resize(object? sender, EventArgs e)
        {
            int padding = 24;
            int availWidth = Math.Max(920, ClientSize.Width - (padding * 2) - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0));

            // 1. Stat cards: 4 columns
            int cardGap = 16;
            int cardWidth = (availWidth - (cardGap * 3)) / 4;
            pnlStatStudents.Location = new Point(padding, 78);
            pnlStatStudents.Width = cardWidth;

            pnlStatSkills.Location = new Point(pnlStatStudents.Right + cardGap, 78);
            pnlStatSkills.Width = cardWidth;

            pnlStatPending.Location = new Point(pnlStatSkills.Right + cardGap, 78);
            pnlStatPending.Width = cardWidth;

            pnlStatReports.Location = new Point(pnlStatPending.Right + cardGap, 78);
            pnlStatReports.Width = availWidth - (pnlStatReports.Left - padding);

            // 2. Row 2: Shortcuts & Pending Verification
            pnlShortcuts.Location = new Point(padding, 185);
            int shortcutsWidth = 350;
            pnlShortcuts.Width = shortcutsWidth;

            pnlPendingVerif.Location = new Point(pnlShortcuts.Right + cardGap, 185);
            pnlPendingVerif.Width = availWidth - shortcutsWidth - cardGap;
            dgv_PendingStudentVerification.Width = Math.Max(200, pnlPendingVerif.Width - 32);

            // 3. Row 3: Blacklisted & Declined
            int halfWidth = (availWidth - cardGap) / 2;
            pnlBlacklisted.Location = new Point(padding, 402);
            pnlBlacklisted.Width = halfWidth;
            dgv_CurrentlyBlackLister.Width = Math.Max(200, pnlBlacklisted.Width - 32);

            pnlDeclined.Location = new Point(pnlBlacklisted.Right + cardGap, 402);
            pnlDeclined.Width = availWidth - halfWidth - cardGap;
            dgv_DeclineStudent.Width = Math.Max(200, pnlDeclined.Width - 32);

            // 4. Row 4: Reports
            pnlReports.Location = new Point(padding, 629);
            pnlReports.Width = availWidth;
            dgvReportRecords.Width = Math.Max(200, pnlReports.Width - 32);

            Invalidate(true);
        }

        // =====================================================
        // ROUNDED CARD PAINTING
        // =====================================================
        private void RoundPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Control ctrl) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, ctrl.Width - 1, ctrl.Height - 1);
            using var path = CreateRoundedRectanglePath(rect, 8);
            using var borderPen = new Pen(Color.FromArgb(34, 48, 38), 1f);
            e.Graphics.DrawPath(borderPen, path);
        }

        private static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}