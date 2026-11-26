using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_ReportedStudents : UserControl
    {
        private class Report
        {
            public int ReportId { get; set; }
            public int? ReportedUserId { get; set; }
            public string Student { get; set; } = string.Empty;
            public string Reporter { get; set; } = string.Empty;
            public string Reason { get; set; } = string.Empty;
            public DateTime Date { get; set; }
            public bool IsBlacklisted { get; set; }
            public string Status { get; set; } = "Pending";
        }

        private System.Windows.Forms.Timer? _liveRefreshTimer;
        private string _lastReportsFingerprint = "";
        private Report? _selectedReport;

        public uc_ReportedStudents()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            dataGridViewReports.SelectionChanged += DataGridViewReports_SelectionChanged;
            dataGridViewReports.CellFormatting += DataGridViewReports_CellFormatting;

            Disposed += (s, e) =>
            {
                _liveRefreshTimer?.Stop();
                _liveRefreshTimer?.Dispose();
            };
        }

        private void ShowGridMessage(string message)
        {
            _lblEmptyState.Text = message;
            _lblEmptyState.Visible = true;
            _lblEmptyState.BringToFront();
        }

        private void HideGridMessage()
        {
            _lblEmptyState.Visible = false;
        }

        private void uc_ReportedStudents_Load(object? sender, EventArgs e)
        {
            ResetSelection();
            LoadReports();

            if (!DesignMode)
            {
                _liveRefreshTimer = new System.Windows.Forms.Timer { Interval = 4000 };
                _liveRefreshTimer.Tick += (s, ev) =>
                {
                    if (Visible && !IsDisposed && Parent != null && !txtSearch.Focused)
                    {
                        CheckReportUpdates();
                    }
                };
                _liveRefreshTimer.Start();
            }
        }

        private void CheckReportUpdates()
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "SELECT CONCAT(COALESCE(COUNT(*), 0), ':', COALESCE(MAX(ReportId), 0), ':', COALESCE(MAX(Status), '')) FROM tbl_reports";
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

                if (fp != _lastReportsFingerprint)
                {
                    _lastReportsFingerprint = fp;
                    LoadReports(txtSearch.Text);
                }
            }
            catch
            {
            }
        }

        public void LoadReports(string keyword = "")
        {
            int? previousReportId = _selectedReport?.ReportId;
            dataGridViewReports.Rows.Clear();
            string trimmedKw = keyword.Trim().ToLowerInvariant();

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();

                string query = @"
                    SELECT r.ReportId, r.ReportedUser,
                           COALESCE(
                               r.ReportedUserId,
                               s.UserId,
                               CASE
                                   WHEN (SELECT COUNT(*) FROM tbl_users u2 WHERE u2.FullName = r.ReportedUser) = 1
                                   THEN (SELECT u2.UserId FROM tbl_users u2 WHERE u2.FullName = r.ReportedUser LIMIT 1)
                                   ELSE NULL
                               END
                           ) AS ResolvedUserId,
                           COALESCE(NULLIF(r.ReporterName, ''), 'Student Peer') AS Reporter,
                           r.Reason, r.ReportDate, r.Status,
                           COALESCE(u.is_blacklisted, 0) AS is_blacklisted
                    FROM tbl_reports r
                    LEFT JOIN tbl_skills s ON r.SkillId = s.SkillId
                    LEFT JOIN tbl_users u ON u.UserId = COALESCE(
                        r.ReportedUserId,
                        s.UserId,
                        CASE
                            WHEN (SELECT COUNT(*) FROM tbl_users u2 WHERE u2.FullName = r.ReportedUser) = 1
                            THEN (SELECT u2.UserId FROM tbl_users u2 WHERE u2.FullName = r.ReportedUser LIMIT 1)
                            ELSE NULL
                        END
                    )
                    WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(trimmedKw))
                {
                    query += " AND (r.ReportedUser LIKE @kw OR r.ReporterName LIKE @kw OR r.Reason LIKE @kw OR r.Status LIKE @kw)";
                    cmd.Parameters.AddWithValue("@kw", "%" + trimmedKw + "%");
                }

                query += " ORDER BY r.ReportId DESC";

                cmd.CommandText = query;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "reports");
                conn.Close();

                DataTable dt = ds.Tables["reports"]!;

                if (dt != null && dt.Rows.Count > 0)
                {
                    HideGridMessage();
                    foreach (DataRow row in dt.Rows)
                    {
                        var report = new Report
                        {
                            ReportId = Convert.ToInt32(row["ReportId"]),
                            ReportedUserId = row["ResolvedUserId"] != DBNull.Value ? Convert.ToInt32(row["ResolvedUserId"]) : null,
                            Student = row["ReportedUser"]?.ToString() ?? "Unknown Student",
                            Reporter = row["Reporter"]?.ToString() ?? "Student Peer",
                            Reason = row["Reason"]?.ToString() ?? "No reason specified",
                            Date = row["ReportDate"] != DBNull.Value ? Convert.ToDateTime(row["ReportDate"]) : DateTime.Now,
                            IsBlacklisted = row["is_blacklisted"] != DBNull.Value && Convert.ToInt32(row["is_blacklisted"]) == 1,
                            Status = row["Status"]?.ToString() ?? "Pending"
                        };

                        AddReportRow(report);
                    }

                    bool restored = false;
                    if (previousReportId.HasValue)
                    {
                        foreach (DataGridViewRow gridRow in dataGridViewReports.Rows)
                        {
                            if (gridRow.Tag is Report r && r.ReportId == previousReportId.Value)
                            {
                                gridRow.Selected = true;
                                restored = true;
                                break;
                            }
                        }
                    }

                    if (!restored)
                    {
                        dataGridViewReports.ClearSelection();
                        ResetSelection();
                    }
                }
                else
                {
                    ResetSelection();
                    ShowGridMessage("No incident reports found.");
                }
            }
            catch
            {
                ResetSelection();
                ShowGridMessage("⚠️ Database offline — could not load incident reports.");
            }

            lblReportsCount.Text = $"{dataGridViewReports.Rows.Count} report(s)";
        }

        private void AddReportRow(Report report)
        {
            string statusDisplay = report.IsBlacklisted ? "Blacklisted" : report.Status;
            int rowIdx = dataGridViewReports.Rows.Add(
                $"#{report.ReportId}",
                report.Student,
                report.Reporter,
                report.Reason,
                report.Date.ToString("MM/dd/yyyy"),
                statusDisplay);

            dataGridViewReports.Rows[rowIdx].Tag = report;
        }

        private void DataGridViewReports_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridViewReports.SelectedRows.Count == 0)
            {
                ResetSelection();
                return;
            }

            var row = dataGridViewReports.SelectedRows[0];
            if (row.Tag is Report report)
            {
                _selectedReport = report;
                txtSelectedStudent.Text = report.Student;
                txtSelectedReporter.Text = report.Reporter;
                string accountState = report.IsBlacklisted ? "Blacklisted" : report.Status;
                txtSelectedStatus.Text = $"#{report.ReportId} • {accountState} • {report.Date:MM/dd/yyyy}";
                txtSelectedReason.Text = report.Reason;
                UpdateActionButtons();
            }
        }

        private void DataGridViewReports_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridViewReports.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                string val = e.Value.ToString() ?? "";
                if (val == "Blacklisted")
                {
                    e.CellStyle!.ForeColor = Color.FromArgb(248, 113, 113);
                }
                else if (val == "Pending")
                {
                    e.CellStyle!.ForeColor = Color.FromArgb(251, 191, 36);
                }
                else
                {
                    e.CellStyle!.ForeColor = Color.FromArgb(74, 222, 128);
                }
            }
        }

        private void ResetSelection()
        {
            _selectedReport = null;
            txtSelectedStudent.Text = string.Empty;
            txtSelectedReporter.Text = string.Empty;
            txtSelectedStatus.Text = string.Empty;
            txtSelectedReason.Text = string.Empty;
            UpdateActionButtons();
        }

        private void UpdateActionButtons()
        {
            bool hasSelection = _selectedReport != null;

            bool canDismiss = hasSelection &&
                              !_selectedReport!.IsBlacklisted &&
                              string.Equals(_selectedReport.Status, "Pending", StringComparison.OrdinalIgnoreCase);
            btnDismiss.Enabled = canDismiss;
            btnDismiss.BackColor = canDismiss ? Color.FromArgb(48, 62, 52) : Color.FromArgb(32, 44, 35);
            btnDismiss.ForeColor = canDismiss ? Color.White : Color.FromArgb(120, 140, 125);

            bool canBlacklist = hasSelection && !_selectedReport!.IsBlacklisted;
            btnBlacklist.Enabled = canBlacklist;
            btnBlacklist.BackColor = canBlacklist ? Color.FromArgb(185, 38, 38) : Color.FromArgb(32, 44, 35);
            btnBlacklist.ForeColor = canBlacklist ? Color.White : Color.FromArgb(120, 140, 125);

            bool canUnblacklist = hasSelection && _selectedReport!.IsBlacklisted;
            btnUnblacklist.Enabled = canUnblacklist;
            btnUnblacklist.BackColor = canUnblacklist ? Color.FromArgb(46, 125, 70) : Color.FromArgb(32, 44, 35);
            btnUnblacklist.ForeColor = canUnblacklist ? Color.White : Color.FromArgb(120, 140, 125);
        }

        private int ResolveTargetUserId(Report report)
        {
            int targetUserId = report.ReportedUserId ?? 0;
            if (targetUserId > 0 || string.IsNullOrWhiteSpace(report.Student))
            {
                return targetUserId;
            }

            try
            {
                using MySqlConnection lookupConn = DatabaseHelper.GetConnection();
                MySqlCommand lookupCmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                lookupConn.Open();
                lookupCmd.CommandText = "SELECT UserId FROM tbl_users WHERE FullName = @name";
                lookupCmd.Connection = lookupConn;
                lookupCmd.Parameters.AddWithValue("@name", report.Student);
                da.SelectCommand = lookupCmd;
                da.Fill(ds, "matches");
                lookupConn.Close();

                DataTable matches = ds.Tables["matches"]!;
                if (matches.Rows.Count == 1)
                {
                    targetUserId = Convert.ToInt32(matches.Rows[0]["UserId"]);
                    report.ReportedUserId = targetUserId;
                }
                else if (matches.Rows.Count > 1)
                {
                    MessageBox.Show(
                        $"Multiple user accounts match '{report.Student}'. Cannot update blacklist status without a unique UserId.",
                        "Ambiguous Account",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return -1;
                }
            }
            catch
            {
                MessageBox.Show("Database is offline. Cannot update blacklist status right now.", "Database Offline", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            return targetUserId;
        }

        private void btnDismiss_Click(object? sender, EventArgs e)
        {
            if (_selectedReport == null) return;

            var confirm = MessageBox.Show(
                $"Dismiss report #{_selectedReport.ReportId} against '{_selectedReport.Student}'?",
                "Confirm Dismiss",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using MySqlCommand cmd = new MySqlCommand(
                    "UPDATE tbl_reports SET Status = 'Dismissed' WHERE ReportId = @id", conn);
                cmd.Parameters.AddWithValue("@id", _selectedReport.ReportId);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"Report #{_selectedReport.ReportId} has been dismissed.", "Report Dismissed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReports(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not dismiss report: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBlacklist_Click(object? sender, EventArgs e)
        {
            if (_selectedReport == null) return;

            int targetUserId = ResolveTargetUserId(_selectedReport);
            if (targetUserId < 0) return;

            if (targetUserId == 0)
            {
                MessageBox.Show(
                    $"Could not find a unique user account for '{_selectedReport.Student}'.",
                    "User Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (ModerationHelper.IsAdminUser(targetUserId))
            {
                MessageBox.Show(
                    "Admin accounts are protected and cannot be blacklisted.",
                    "Action Blocked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Blacklist student '{_selectedReport.Student}'?\n\nThis will immediately terminate their session, pause active listings, and decline pending trade requests.",
                "Confirm Blacklist",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                ModerationHelper.BlacklistStudent(
                    targetUserId,
                    $"Blacklisted via Report #{_selectedReport.ReportId}: {_selectedReport.Reason}",
                    _selectedReport.ReportId);

                MessageBox.Show($"Student '{_selectedReport.Student}' has been blacklisted.", "Disciplinary Action Updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReports(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not blacklist student: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnblacklist_Click(object? sender, EventArgs e)
        {
            if (_selectedReport == null) return;

            int targetUserId = ResolveTargetUserId(_selectedReport);
            if (targetUserId < 0) return;

            if (targetUserId == 0)
            {
                MessageBox.Show(
                    $"Could not find a unique user account for '{_selectedReport.Student}'.",
                    "User Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show(
                $"Lift blacklist for student '{_selectedReport.Student}' and restore their account access?\n\nNote: Previously paused listings will remain Paused for manual review.",
                "Confirm Unblacklist",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using MySqlTransaction tx = conn.BeginTransaction();

                using (MySqlCommand userCmd = new MySqlCommand(
                    "UPDATE tbl_users SET is_blacklisted = 0, BanReason = NULL WHERE UserId = @uid", conn, tx))
                {
                    userCmd.Parameters.AddWithValue("@uid", targetUserId);
                    userCmd.ExecuteNonQuery();
                }

                using (MySqlCommand reportCmd = new MySqlCommand(
                    "UPDATE tbl_reports SET Status = 'Dismissed' WHERE ReportId = @id", conn, tx))
                {
                    reportCmd.Parameters.AddWithValue("@id", _selectedReport.ReportId);
                    reportCmd.ExecuteNonQuery();
                }

                tx.Commit();
                conn.Close();

                MessageBox.Show($"Student '{_selectedReport.Student}' has been removed from the blacklist.", "Disciplinary Action Updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReports(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not unblacklist student: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSelection_Click(object? sender, EventArgs e)
        {
            dataGridViewReports.ClearSelection();
            ResetSelection();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadReports(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadReports(txtSearch.Text.Trim());
        }

        private void btnClearSearch_Click(object? sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadReports();
        }

        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadReports(txtSearch.Text.Trim());
            }
        }

        private void RoundPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Control ctrl) return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, ctrl.Width - 1, ctrl.Height - 1);
            using var path = CreateRoundedRectanglePath(rect, 8);
            using var borderPen = new Pen(Color.FromArgb(34, 48, 38), 1f);
            e.Graphics.DrawPath(borderPen, path);
        }

        private static System.Drawing.Drawing2D.GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
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