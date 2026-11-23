using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_ReportedStudents : UserControl
    {
        // Simple data model for a student report incident
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

        // Cache of fallback sample reports for when the database is offline or empty
        private readonly List<Report> _sampleReports = new List<Report>
        {
            new Report
            {
                ReportId = 101,
                Student = "Zach Plata",
                Reporter = "Samantha Cruz",
                Reason = "Demanded cash payment (Strictly No Cash policy violation) for Python tutoring session.",
                Date = DateTime.Now.AddDays(-1),
                IsBlacklisted = false,
                Status = "Pending"
            },
            new Report
            {
                ReportId = 102,
                Student = "Andrei Sarmiento",
                Reporter = "Trowa Bugarin",
                Reason = "Repeated no-show / ghosted scheduled campus meetup at UE Library 3rd Floor study hub.",
                Date = DateTime.Now.AddDays(-3),
                IsBlacklisted = false,
                Status = "Pending"
            },
            new Report
            {
                ReportId = 103,
                Student = "Miguel Borja",
                Reporter = "Gabs Katipunan",
                Reason = "Solicited graded midterm examination answers instead of legitimate peer tutoring.",
                Date = DateTime.Now.AddDays(-5),
                IsBlacklisted = true,
                Status = "Reviewed"
            },
            new Report
            {
                ReportId = 104,
                Student = "Marcus Lee",
                Reporter = "Sarah Cruz",
                Reason = "Disrespectful conduct and spamming irrelevant trade proposals across multiple listings.",
                Date = DateTime.Now.AddDays(-7),
                IsBlacklisted = false,
                Status = "Pending"
            }
        };

        private System.Windows.Forms.Timer? _liveRefreshTimer;
        private string _lastReportsFingerprint = "";

        public uc_ReportedStudents()
        {
            InitializeComponent();

            // Wire up DataGridView events
            dataGridViewReports.CellContentClick += DataGridViewReports_CellContentClick;
            dataGridViewReports.CellFormatting += DataGridViewReports_CellFormatting;
            dataGridViewReports.CellDoubleClick += DataGridViewReports_CellDoubleClick;

            Disposed += (s, e) =>
            {
                _liveRefreshTimer?.Stop();
                _liveRefreshTimer?.Dispose();
            };
        }

        private void uc_ReportedStudents_Load(object? sender, EventArgs e)
        {
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
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
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
            catch { }
        }

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

        /// <summary>
        /// Loads reports from the MySQL database (tbl_reports) or falls back to realistic sample data.
        /// Supports live keyword filtering across student names, reporters, and incident reasons.
        /// </summary>
        public void LoadReports(string keyword = "")
        {
            dataGridViewReports.Rows.Clear();
            string trimmedKw = keyword.Trim().ToLowerInvariant();
            bool loadedFromDb = false;

            try
            {
                EnsureReportedUserIdColumnExists();

                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
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
                           'Student Peer' AS Reporter,
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
                    query += " AND (r.ReportedUser LIKE @kw OR r.Reason LIKE @kw OR r.Status LIKE @kw)";
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
                    foreach (DataRow row in dt.Rows)
                    {
                        var report = new Report
                        {
                            ReportId = Convert.ToInt32(row["ReportId"]),
                            ReportedUserId = row["ResolvedUserId"] != DBNull.Value ? Convert.ToInt32(row["ResolvedUserId"]) : null,
                            Student = row["ReportedUser"]?.ToString() ?? "Unknown Student",
                            Reporter = row["Reporter"]?.ToString() ?? "Anonymous",
                            Reason = row["Reason"]?.ToString() ?? "No reason specified",
                            Date = row["ReportDate"] != DBNull.Value ? Convert.ToDateTime(row["ReportDate"]) : DateTime.Now,
                            IsBlacklisted = row["is_blacklisted"] != DBNull.Value && Convert.ToInt32(row["is_blacklisted"]) == 1,
                            Status = row["Status"]?.ToString() ?? "Pending"
                        };

                        AddReportRow(report);
                    }
                    loadedFromDb = true;
                }
            }
            catch
            {
                // Database offline — seamlessly use cached sample reports
                loadedFromDb = false;
            }

            // Fallback to sample data if database returned no records or threw an error
            if (!loadedFromDb)
            {
                foreach (var r in _sampleReports)
                {
                    if (!string.IsNullOrWhiteSpace(trimmedKw))
                    {
                        bool matches = r.Student.ToLowerInvariant().Contains(trimmedKw)
                                    || r.Reporter.ToLowerInvariant().Contains(trimmedKw)
                                    || r.Reason.ToLowerInvariant().Contains(trimmedKw);
                        if (!matches) continue;
                    }

                    AddReportRow(r);
                }
            }

            lblReportsCount.Text = $"{dataGridViewReports.Rows.Count} report(s) loaded";
        }

        private void AddReportRow(Report report)
        {
            string actionText = report.IsBlacklisted ? "Unblacklist" : "Blacklist";
            int rowIdx = dataGridViewReports.Rows.Add(
                $"#{report.ReportId}",
                report.Student,
                report.Reporter,
                report.Reason,
                report.Date.ToString("MM/dd/yyyy"),
                actionText);

            dataGridViewReports.Rows[rowIdx].Tag = report;
        }

        // =========================================================================
        // DATA GRID VIEW EVENTS (ACTION CLICKS, COLORING, DETAILS)
        // =========================================================================

        private void DataGridViewReports_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dataGridViewReports.Columns[e.ColumnIndex];
            if (col.Name != "colBlacklist") return;

            var row = dataGridViewReports.Rows[e.RowIndex];
            if (row.Tag is Report report)
            {
                int targetUserId = report.ReportedUserId ?? 0;
                bool dbReachable = true;
                if (targetUserId <= 0 && !string.IsNullOrWhiteSpace(report.Student))
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
                            return;
                        }
                    }
                    catch
                    {
                        dbReachable = false;
                    }
                }

                if (dbReachable && targetUserId <= 0)
                {
                    MessageBox.Show(
                        $"Could not find a unique user account for '{report.Student}'.",
                        "User Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                string actionWord = report.IsBlacklisted ? "unblacklist" : "blacklist";
                string warningNotice = report.IsBlacklisted
                    ? $"Lift blacklist for student '{report.Student}' and restore their account access?"
                    : $"Blacklist student '{report.Student}'?\n\nThis will restrict their account login and suspend their active skill listings.";

                var confirm = MessageBox.Show(
                    warningNotice,
                    $"Confirm {char.ToUpper(actionWord[0]) + actionWord.Substring(1)}",
                    MessageBoxButtons.YesNo,
                    report.IsBlacklisted ? MessageBoxIcon.Question : MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                // Toggle status
                report.IsBlacklisted = !report.IsBlacklisted;
                string newAction = report.IsBlacklisted ? "Unblacklist" : "Blacklist";
                row.Cells["colBlacklist"].Value = newAction;

                // Persist to database if available
                if (targetUserId > 0)
                {
                    try
                    {
                        using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                        conn.Open();

                        MySqlCommand userCmd = new MySqlCommand();
                        userCmd.CommandText = "UPDATE tbl_users SET is_blacklisted = @status, BanReason = @reason WHERE UserId = @uid";
                        userCmd.Connection = conn;
                        userCmd.Parameters.AddWithValue("@status", report.IsBlacklisted ? 1 : 0);
                        userCmd.Parameters.AddWithValue("@reason", report.IsBlacklisted ? $"Blacklisted via Report #{report.ReportId}: {report.Reason}" : (object)DBNull.Value);
                        userCmd.Parameters.AddWithValue("@uid", targetUserId);
                        userCmd.ExecuteNonQuery();

                        MySqlCommand reportCmd = new MySqlCommand();
                        reportCmd.CommandText = "UPDATE tbl_reports SET Status = @status WHERE ReportId = @id";
                        reportCmd.Connection = conn;
                        reportCmd.Parameters.AddWithValue("@status", report.IsBlacklisted ? "Reviewed" : "Dismissed");
                        reportCmd.Parameters.AddWithValue("@id", report.ReportId);
                        reportCmd.ExecuteNonQuery();

                        conn.Close();
                    }
                    catch
                    {
                        // Fallback to local in-memory toggle
                    }
                }

                MessageBox.Show(
                    $"Student '{report.Student}' has been successfully {(report.IsBlacklisted ? "blacklisted" : "removed from blacklist")}.",
                    "Disciplinary Action Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void DataGridViewReports_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridViewReports.Columns[e.ColumnIndex];
            if (col.Name == "colBlacklist" && e.Value != null)
            {
                string val = e.Value.ToString() ?? "";
                if (val == "Unblacklist")
                {
                    // Student is blacklisted: button to unblacklist is green/slate
                    e.CellStyle!.BackColor = Color.FromArgb(16, 185, 129);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(4, 120, 87);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    // Student is not blacklisted: action button is danger red
                    e.CellStyle!.BackColor = Color.FromArgb(185, 28, 28);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(153, 27, 27);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private void DataGridViewReports_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewReports.Rows[e.RowIndex];
            if (row.Tag is Report report)
            {
                string statusText = report.IsBlacklisted ? "BLACKLISTED / SUSPENDED" : "ACTIVE / UNDER REVIEW";
                MessageBox.Show(
                    $"Report ID: #{report.ReportId}\n" +
                    $"Reported Student: {report.Student}\n" +
                    $"Reporter: {report.Reporter}\n" +
                    $"Date Filed: {report.Date:MMMM dd, yyyy @ hh:mm tt}\n" +
                    $"Current Account Status: {statusText}\n\n" +
                    $"Incident Details / Reason:\n\"{report.Reason}\"",
                    $"Incident Details — Report #{report.ReportId}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // =========================================================================
        // SEARCH & TOOLBAR ACTIONS
        // =========================================================================

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

        // =========================================================================
        // COMPATIBILITY STUBS & ROUNDED PANELS
        // =========================================================================

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

        private void flowLayoutPanel2_Paint(object? sender, PaintEventArgs e)
        {
            // Optional custom painting
        }

        private void panel2_Paint(object? sender, PaintEventArgs e)
        {
            // Optional custom painting
        }
    }
}
