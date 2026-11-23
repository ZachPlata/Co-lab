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
        private System.Windows.Forms.Timer? _liveRefreshTimer;
        private string _lastAdminDashboardFingerprint = "";

        public uc_AdminDashboard()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            Disposed += (s, e) =>
            {
                _liveRefreshTimer?.Stop();
                _liveRefreshTimer?.Dispose();
            };
        }

        private void uc_AdminDashboard_Load(object sender, EventArgs e)
        {
            uc_AdminDashboard_Resize(this, EventArgs.Empty);
            LoadDashboard();

            if (!DesignMode)
            {
                _liveRefreshTimer = new System.Windows.Forms.Timer { Interval = 4000 };
                _liveRefreshTimer.Tick += (s, ev) =>
                {
                    if (Visible && !IsDisposed && Parent != null)
                    {
                        CheckDashboardUpdates();
                    }
                };
                _liveRefreshTimer.Start();
            }
        }

        private void CheckDashboardUpdates()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = @"SELECT CONCAT(
                                      COALESCE((SELECT COUNT(*) FROM tbl_users), 0), ':', 
                                      COALESCE((SELECT COUNT(*) FROM tbl_skills), 0), ':', 
                                      COALESCE((SELECT COUNT(*) FROM tbl_reports), 0), ':', 
                                      COALESCE((SELECT MAX(ReportId) FROM tbl_reports), 0), ':',
                                      COALESCE((SELECT MAX(Status) FROM tbl_reports), '')
                                   )";
                cmd.Connection = conn;

                string fp = "";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        fp = reader[0].ToString() ?? "";
                    }
                }
                conn.Close();

                if (fp != _lastAdminDashboardFingerprint)
                {
                    _lastAdminDashboardFingerprint = fp;
                    LoadDashboard();
                }
            }
            catch { }
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
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                conn.Open();

                MySqlCommand c1 = new MySqlCommand("SELECT COUNT(*) FROM tbl_users WHERE Role = 'Student'", conn);
                using (MySqlDataReader r1 = c1.ExecuteReader())
                {
                    lblTotalStudentCount.Text = r1.Read() && r1[0] != DBNull.Value ? r1[0].ToString() : "0";
                }

                MySqlCommand c2 = new MySqlCommand("SELECT COUNT(*) FROM tbl_skills WHERE Status = 'Active'", conn);
                using (MySqlDataReader r2 = c2.ExecuteReader())
                {
                    lblActiveSkillCount.Text = r2.Read() && r2[0] != DBNull.Value ? r2[0].ToString() : "0";
                }

                MySqlCommand c3 = new MySqlCommand("SELECT COUNT(*) FROM tbl_skills WHERE Status = 'Under Review'", conn);
                using (MySqlDataReader r3 = c3.ExecuteReader())
                {
                    lblPendingSkillCount.Text = r3.Read() && r3[0] != DBNull.Value ? r3[0].ToString() : "0";
                }

                MySqlCommand c4 = new MySqlCommand("SELECT COUNT(*) FROM tbl_reports WHERE Status = 'Pending'", conn);
                using (MySqlDataReader r4 = c4.ExecuteReader())
                {
                    lblOpenReportsCount.Text = r4.Read() && r4[0] != DBNull.Value ? r4[0].ToString() : "0";
                }

                conn.Close();
            }
            catch
            {
                lblTotalStudentCount.Text = "—";
                lblActiveSkillCount.Text = "—";
                lblPendingSkillCount.Text = "—";
                lblOpenReportsCount.Text = "—";
            }
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

        // =====================================================
        // PENDING STUDENT VERIFICATIONS
        // =====================================================
        private static bool _verifiedColumnChecked = false;

        private void EnsureVerificationColumnExists()
        {
            if (_verifiedColumnChecked) return;
            try
            {
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "ALTER TABLE tbl_users ADD COLUMN IF NOT EXISTS is_verified TINYINT(1) DEFAULT 0";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
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

                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = "SELECT UserId, FullName, Email FROM tbl_users WHERE Role = 'Student' AND is_verified = 0 AND is_blacklisted = 0 ORDER BY UserId DESC LIMIT 10";
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "pending");
                conn.Close();

                DataTable dt = ds.Tables["pending"]!;
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
                        using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                        MySqlCommand cmd = new MySqlCommand();
                        conn.Open();
                        cmd.CommandText = "UPDATE tbl_users SET is_verified = 1 WHERE UserId = @id";
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                        conn.Close();

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
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = "SELECT UserId, FullName, Email, COALESCE(BanReason, 'Blacklisted via Report') AS BanReason FROM tbl_users WHERE is_blacklisted = 1 ORDER BY UserId DESC LIMIT 10";
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "blacklisted");
                conn.Close();

                DataTable dt = ds.Tables["blacklisted"]!;
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
                        using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                        MySqlCommand cmd = new MySqlCommand();
                        conn.Open();
                        cmd.CommandText = "UPDATE tbl_users SET is_blacklisted = 0, BanReason = NULL WHERE UserId = @id";
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                        conn.Close();

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
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText =
                    "SELECT 'Dismissed Report' AS RecordType, ReportedUser AS StudentName, Reason, Status FROM tbl_reports WHERE Status IN ('Dismissed', 'Declined') " +
                    "UNION ALL " +
                    "SELECT 'Declined Proposal' AS RecordType, SenderName AS StudentName, CONCAT('Proposal: ', OfferedSkillTitle) AS Reason, Status FROM tbl_traderequests WHERE Status = 'Declined' " +
                    "LIMIT 10";
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "declined");
                conn.Close();

                DataTable dt = ds.Tables["declined"]!;
                dgv_DeclineStudent.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string recordType = row["RecordType"]?.ToString() ?? "";
                    string studentName = row["StudentName"]?.ToString() ?? "";
                    string reason = row["Reason"]?.ToString() ?? "";
                    string status = row["Status"]?.ToString() ?? "";

                    dgv_DeclineStudent.Rows.Add(recordType, studentName, reason, status);
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
        private static bool _reportedUserIdColumnChecked = false;

        private void EnsureReportedUserIdColumnExists()
        {
            if (_reportedUserIdColumnChecked) return;
            try
            {
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                conn.Open();
                MySqlCommand checkCmd = new MySqlCommand();
                checkCmd.CommandText = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS 
                                         WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'tbl_reports' AND COLUMN_NAME = 'ReportedUserId'";
                checkCmd.Connection = conn;

                int exists = 0;
                using (MySqlDataReader reader = checkCmd.ExecuteReader())
                {
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        exists = Convert.ToInt32(reader[0]);
                    }
                }

                if (exists == 0)
                {
                    MySqlCommand alterCmd = new MySqlCommand();
                    alterCmd.CommandText = "ALTER TABLE tbl_reports ADD COLUMN ReportedUserId INT DEFAULT NULL";
                    alterCmd.Connection = conn;
                    alterCmd.ExecuteNonQuery();
                }

                conn.Close();
                _reportedUserIdColumnChecked = true;
            }
            catch
            {
                // Column may already exist or DB offline
            }
        }

        private void LoadReportRecords()
        {
            try
            {
                EnsureReportedUserIdColumnExists();

                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = @"SELECT r.ReportId,
                                           COALESCE(
                                               r.ReportedUserId,
                                               s.UserId,
                                               CASE
                                                   WHEN (SELECT COUNT(*) FROM tbl_users u WHERE u.FullName = r.ReportedUser) = 1
                                                   THEN (SELECT u.UserId FROM tbl_users u WHERE u.FullName = r.ReportedUser LIMIT 1)
                                                   ELSE 0
                                               END
                                           ) AS ResolvedUserId,
                                           r.ReportedUser, r.Reason, r.ReportDate, r.Status
                                    FROM tbl_reports r
                                    LEFT JOIN tbl_skills s ON r.SkillId = s.SkillId
                                    ORDER BY r.ReportId DESC LIMIT 10";
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "reports");
                conn.Close();

                DataTable dt = ds.Tables["reports"]!;

                dgvReportRecords.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string reportId = row["ReportId"].ToString()!;
                    string resolvedUserId = row["ResolvedUserId"]?.ToString() ?? "0";
                    string reportedUser = row["ReportedUser"].ToString()!;
                    string reason = row["Reason"].ToString()!;
                    string date = Convert.ToDateTime(row["ReportDate"]).ToString("MM/dd/yyyy");
                    string status = row["Status"].ToString()!;

                    dgvReportRecords.Rows.Add(reportId, resolvedUserId, reportedUser, reason, date, status);
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
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                conn.Open();

                int total = 0, pending = 0, accepted = 0, declined = 0;

                using (MySqlDataReader r = new MySqlCommand("SELECT COUNT(*) FROM tbl_traderequests", conn).ExecuteReader())
                {
                    if (r.Read() && r[0] != DBNull.Value) int.TryParse(r[0].ToString(), out total);
                }
                using (MySqlDataReader r = new MySqlCommand("SELECT COUNT(*) FROM tbl_traderequests WHERE Status = 'Pending' OR Status IS NULL", conn).ExecuteReader())
                {
                    if (r.Read() && r[0] != DBNull.Value) int.TryParse(r[0].ToString(), out pending);
                }
                using (MySqlDataReader r = new MySqlCommand("SELECT COUNT(*) FROM tbl_traderequests WHERE Status = 'Accepted'", conn).ExecuteReader())
                {
                    if (r.Read() && r[0] != DBNull.Value) int.TryParse(r[0].ToString(), out accepted);
                }
                using (MySqlDataReader r = new MySqlCommand("SELECT COUNT(*) FROM tbl_traderequests WHERE Status = 'Declined'", conn).ExecuteReader())
                {
                    if (r.Read() && r[0] != DBNull.Value) int.TryParse(r[0].ToString(), out declined);
                }

                conn.Close();

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
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = "SELECT ReportId, ReportedUser, Reason, ReportDate, Status FROM tbl_reports ORDER BY ReportId DESC";
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "reports");
                conn.Close();

                DataTable dt = ds.Tables["reports"]!;

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
                int.TryParse(dgvReportRecords.Rows[e.RowIndex].Cells["colReportedUserId"].Value?.ToString(), out int resolvedUserId);

                if (resolvedUserId <= 0 && !string.IsNullOrWhiteSpace(reportedUser))
                {
                    try
                    {
                        using MySqlConnection lookupConn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                        MySqlCommand lookupCmd = new MySqlCommand();
                        DataSet ds = new DataSet();
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        lookupConn.Open();
                        lookupCmd.CommandText = "SELECT UserId FROM tbl_users WHERE FullName = @name";
                        lookupCmd.Connection = lookupConn;
                        lookupCmd.Parameters.AddWithValue("@name", reportedUser);
                        da.SelectCommand = lookupCmd;
                        da.Fill(ds, "matches");
                        lookupConn.Close();

                        DataTable matches = ds.Tables["matches"]!;
                        if (matches.Rows.Count == 1)
                        {
                            resolvedUserId = Convert.ToInt32(matches.Rows[0]["UserId"]);
                        }
                        else if (matches.Rows.Count > 1)
                        {
                            MessageBox.Show(
                                $"Multiple user accounts match the name '{reportedUser}'. Cannot safely blacklist without a specific UserId.",
                                "Ambiguous Account",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch { }
                }

                if (resolvedUserId <= 0)
                {
                    MessageBox.Show(
                        $"Could not identify a unique user ID for '{reportedUser}'.",
                        "User Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    $"Blacklist student '{reportedUser}'?",
                    "Confirm Blacklist",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                        conn.Open();

                        MySqlCommand userCmd = new MySqlCommand();
                        userCmd.CommandText = "UPDATE tbl_users SET is_blacklisted = 1, BanReason = 'Blacklisted via Report' WHERE UserId = @uid";
                        userCmd.Connection = conn;
                        userCmd.Parameters.AddWithValue("@uid", resolvedUserId);
                        userCmd.ExecuteNonQuery();

                        MySqlCommand repCmd = new MySqlCommand();
                        repCmd.CommandText = "UPDATE tbl_reports SET Status = 'Reviewed' WHERE ReportId = @id";
                        repCmd.Connection = conn;
                        repCmd.Parameters.AddWithValue("@id", reportId);
                        repCmd.ExecuteNonQuery();

                        conn.Close();

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
                    using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                    MySqlCommand cmd = new MySqlCommand();
                    conn.Open();
                    cmd.CommandText = "UPDATE tbl_reports SET Status = 'Dismissed' WHERE ReportId = @id";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", reportId);
                    cmd.ExecuteNonQuery();
                    conn.Close();

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
            int rowGap = 24;
            int availWidth = Math.Max(920, ClientSize.Width - (padding * 2) - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0));

            pnlAdminBadge.Location = new Point(padding + availWidth - pnlAdminBadge.Width, 18);

            // 1. Stat cards: 4 columns
            int cardGap = 16;
            int cardWidth = (availWidth - (cardGap * 3)) / 4;
            int row1Y = 82;
            pnlStatStudents.Location = new Point(padding, row1Y);
            pnlStatStudents.Width = cardWidth;

            pnlStatSkills.Location = new Point(pnlStatStudents.Right + cardGap, row1Y);
            pnlStatSkills.Width = cardWidth;

            pnlStatPending.Location = new Point(pnlStatSkills.Right + cardGap, row1Y);
            pnlStatPending.Width = cardWidth;

            pnlStatReports.Location = new Point(pnlStatPending.Right + cardGap, row1Y);
            pnlStatReports.Width = availWidth - (pnlStatReports.Left - padding);

            // 2. Row 2: Shortcuts & Pending Verification
            int row2Y = pnlStatStudents.Bottom + rowGap;
            pnlShortcuts.Location = new Point(padding, row2Y);
            int shortcutsWidth = 350;
            pnlShortcuts.Width = shortcutsWidth;

            pnlPendingVerif.Location = new Point(pnlShortcuts.Right + cardGap, row2Y);
            pnlPendingVerif.Width = availWidth - shortcutsWidth - cardGap;
            dgv_PendingStudentVerification.Width = Math.Max(200, pnlPendingVerif.Width - 32);

            // 3. Row 3: Blacklisted & Declined
            int row3Y = pnlShortcuts.Bottom + rowGap;
            int halfWidth = (availWidth - cardGap) / 2;
            pnlBlacklisted.Location = new Point(padding, row3Y);
            pnlBlacklisted.Width = halfWidth;
            dgv_CurrentlyBlackLister.Width = Math.Max(200, pnlBlacklisted.Width - 32);

            pnlDeclined.Location = new Point(pnlBlacklisted.Right + cardGap, row3Y);
            pnlDeclined.Width = availWidth - halfWidth - cardGap;
            dgv_DeclineStudent.Width = Math.Max(200, pnlDeclined.Width - 32);

            // 4. Row 4: Reports
            int row4Y = pnlBlacklisted.Bottom + rowGap;
            pnlReports.Location = new Point(padding, row4Y);
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