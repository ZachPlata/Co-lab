using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_SkillExchange : UserControl
    {
        private System.Windows.Forms.Timer? _liveRefreshTimer;
        private string _lastMarketplaceFingerprint = "";

        public uc_SkillExchange()
        {
            InitializeComponent();
            Disposed += (s, e) =>
            {
                _liveRefreshTimer?.Stop();
                _liveRefreshTimer?.Dispose();
            };
        }

        private void uc_SkillExchange_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadMarketplaceCards("", "All Categories");

            if (!DesignMode)
            {
                _liveRefreshTimer = new System.Windows.Forms.Timer { Interval = 4000 };
                _liveRefreshTimer.Tick += (s, ev) =>
                {
                    if (Visible && !IsDisposed && Parent != null && !txtSearch.Focused)
                    {
                        CheckMarketplaceUpdates();
                    }
                };
                _liveRefreshTimer.Start();
            }
        }

        private void CheckMarketplaceUpdates()
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = @"SELECT CONCAT(
                                      COALESCE(MAX(s.SkillId), 0), ':', 
                                      COALESCE(MAX(s.Status), ''), ':', 
                                      COALESCE((SELECT COUNT(*) FROM tbl_traderequests), 0), ':', 
                                      COALESCE((SELECT MAX(RequestId) FROM tbl_traderequests), 0), ':',
                                      COALESCE((SELECT MAX(Status) FROM tbl_traderequests), '')
                                   ) FROM tbl_skills s";
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

                if (fp != _lastMarketplaceFingerprint)
                {
                    _lastMarketplaceFingerprint = fp;
                    LoadMarketplaceCards(txtSearch.Text, cmbCategory.SelectedItem?.ToString() ?? "All Categories");
                }
            }
            catch { }
        }

        /// <summary>
        /// Loads skill categories from the database or falls back to common defaults.
        /// </summary>
        public void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = "SELECT CategoryName FROM tbl_categories ORDER BY CategoryName ASC";
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "categories");
                conn.Close();

                DataTable dt = ds.Tables["categories"]!;
                foreach (DataRow row in dt.Rows)
                {
                    string? name = row["CategoryName"]?.ToString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        cmbCategory.Items.Add(name);
                    }
                }
            }
            catch
            {
                // Fallback default categories if tbl_categories is not yet created in phpMyAdmin
                cmbCategory.Items.AddRange(new object[] {
                    "Computer Science & IT",
                    "Graphic & Visual Design",
                    "Engineering & Math",
                    "Music & Arts",
                    "Language & Writing",
                    "Business & Marketing"
                });
            }

            cmbCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// Queries the database and dynamically generates cards inside the FlowLayoutPanel.
        /// Keeps ongoing listings visible on the marketplace while marking them as Ongoing and disabling trade requests.
        /// </summary>
        public void LoadMarketplaceCards(string keyword, string category)
        {
            flpMarketplace.SuspendLayout();
            for (int i = flpMarketplace.Controls.Count - 1; i >= 0; i--)
            {
                Control old = flpMarketplace.Controls[i];
                flpMarketplace.Controls.RemoveAt(i);
                old.Dispose();
            }

            string currentStudent = UserSession.FullName ?? "";
            string currentEmail = UserSession.Email ?? "";
            int currentUid = UserSession.UserId;

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();

                // Select active and ongoing (paused) listings, together with accepted & user pending trade flags
                string query = @"
                    SELECT s.*,
                           (SELECT COUNT(*) FROM tbl_traderequests r 
                            WHERE r.TargetSkillId = s.SkillId AND r.Status = 'Accepted') AS AcceptedTradesCount,
                           (SELECT COUNT(*) FROM tbl_traderequests r 
                            WHERE r.TargetSkillId = s.SkillId 
                              AND ((@userEmail != '' AND r.SenderEmail = @userEmail) OR (@userName != '' AND r.SenderName = @userName)) 
                              AND r.Status IN ('Pending', 'Accepted')) AS UserRequestsCount
                    FROM tbl_skills s
                    WHERE (s.Status IN ('Active', 'Paused') OR s.Status IS NULL)";

                cmd.Parameters.AddWithValue("@userEmail", currentEmail);
                cmd.Parameters.AddWithValue("@userName", currentStudent);

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " AND (s.SkillTitle LIKE @kw OR s.Description LIKE @kw OR s.OfferedBy LIKE @kw)";
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(category) && category != "All Categories")
                {
                    query += " AND s.Category = @cat";
                    cmd.Parameters.AddWithValue("@cat", category);
                }

                query += " ORDER BY s.SkillId DESC";

                cmd.CommandText = query;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "skills");
                conn.Close();

                DataTable dt = ds.Tables["skills"]!;

                if (dt.Rows.Count == 0)
                {
                    ShowEmptyState("No skill listings found matching your search.");
                    lblListingCount.Text = "0 skills available";
                }
                else
                {
                    lblEmpty.Visible = false;
                    lblListingCount.Text = $"{dt.Rows.Count} skill(s) listed";
                    foreach (DataRow row in dt.Rows)
                    {
                        var card = new UCStudents.uc_SkillCard();
                        card.BindData(row);

                        int acceptedCount = 0;
                        if (row["AcceptedTradesCount"] != DBNull.Value)
                        {
                            acceptedCount = Convert.ToInt32(row["AcceptedTradesCount"]);
                        }

                        int userReqCount = 0;
                        if (row["UserRequestsCount"] != DBNull.Value)
                        {
                            userReqCount = Convert.ToInt32(row["UserRequestsCount"]);
                        }

                        string skillStatus = row["Status"]?.ToString() ?? "Active";
                        bool isOwner = (!string.IsNullOrWhiteSpace(currentStudent) && string.Equals(card.OfferedBy, currentStudent, StringComparison.OrdinalIgnoreCase)) ||
                                       (currentUid > 0 && row["UserId"] != DBNull.Value && Convert.ToInt32(row["UserId"]) == currentUid);

                        // If trade is accepted or paused, show as Ongoing; if user sent pending, show as Requested; if owner, show as Your Skill
                        if (acceptedCount > 0 || string.Equals(skillStatus, "Paused", StringComparison.OrdinalIgnoreCase))
                        {
                            card.SetTradeState(UCStudents.CardTradeState.OngoingTrade);
                        }
                        else if (userReqCount > 0)
                        {
                            card.SetTradeState(UCStudents.CardTradeState.UserPending);
                        }
                        else if (isOwner)
                        {
                            card.SetTradeState(UCStudents.CardTradeState.OwnListing);
                        }
                        else
                        {
                            card.SetTradeState(UCStudents.CardTradeState.Available);
                        }

                        card.RequestTradeClicked += (s, args) =>
                        {
                            OnRequestTradeClicked(args.SkillId, args.SkillTitle, args.OfferedBy, args.DeliveryMode);
                        };
                        card.ReportClicked += (s, args) =>
                        {
                            OnReportClicked(args.SkillId, args.SkillTitle, args.OfferedBy);
                        };
                        flpMarketplace.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowEmptyState($"Could not connect to database: {ex.Message}\nMake sure MySQL is running in XAMPP.");
                lblListingCount.Text = "Database offline";
            }
            finally
            {
                flpMarketplace.ResumeLayout();
            }
        }

        private void ShowEmptyState(string message)
        {
            lblEmpty.Text = message;
            lblEmpty.Visible = true;
            lblEmpty.BringToFront();
        }

        private void OnRequestTradeClicked(string skillId, string title, string owner, string mode)
        {
            if (!UserSession.IsVerified)
            {
                MessageBox.Show("Your account is pending Admin verification. You can browse listings, and propose trades once approved.", "Pending Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string currentStudent = UserSession.FullName ?? string.Empty;
            string currentEmail = UserSession.Email ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(currentStudent) && string.Equals(owner, currentStudent, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("This is your own skill listing! You cannot send a trade request to yourself.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int.TryParse(skillId, out int parsedSkillId);

            // Guard: Check if the user already has an ongoing trade request for this skill
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                MySqlCommand checkCmd = new MySqlCommand();
                checkCmd.CommandText = @"SELECT Status FROM tbl_traderequests 
                                         WHERE TargetSkillId = @sid 
                                           AND ((@email != '' AND SenderEmail = @email) OR (@name != '' AND SenderName = @name)) 
                                           AND Status IN ('Pending', 'Accepted') 
                                         LIMIT 1";
                checkCmd.Connection = conn;
                checkCmd.Parameters.AddWithValue("@sid", parsedSkillId);
                checkCmd.Parameters.AddWithValue("@email", currentEmail);
                checkCmd.Parameters.AddWithValue("@name", currentStudent);

                object? existingStatus = null;
                using (MySqlDataReader reader = checkCmd.ExecuteReader())
                {
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        existingStatus = reader[0];
                    }
                }

                if (existingStatus != null && existingStatus != DBNull.Value)
                {
                    conn.Close();
                    MessageBox.Show(
                        $"You already have an ongoing trade request for \"{title}\" (Status: {existingStatus}).\n\n" +
                        "You cannot submit multiple requests for the same skill while one is ongoing. Please check 'Trade Requests' to view or manage it.",
                        "Trade Request Already Ongoing",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadMarketplaceCards(txtSearch.Text, cmbCategory.SelectedItem?.ToString() ?? "All Categories");
                    return;
                }

                // Guard: Check if someone else already has an Accepted ongoing trade for this skill
                MySqlCommand accCmd = new MySqlCommand();
                accCmd.CommandText = "SELECT Status FROM tbl_traderequests WHERE TargetSkillId = @sid AND Status = 'Accepted' LIMIT 1";
                accCmd.Connection = conn;
                accCmd.Parameters.AddWithValue("@sid", parsedSkillId);

                object? acceptedStatus = null;
                using (MySqlDataReader reader = accCmd.ExecuteReader())
                {
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        acceptedStatus = reader[0];
                    }
                }
                conn.Close();

                if (acceptedStatus != null && acceptedStatus != DBNull.Value)
                {
                    MessageBox.Show(
                        $"This skill listing is currently engaged in an ongoing trade with another student.\n\n" +
                        "It is no longer available for new trade proposals at this time.",
                        "Trade Already Ongoing",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadMarketplaceCards(txtSearch.Text, cmbCategory.SelectedItem?.ToString() ?? "All Categories");
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error checking existing trade status: {ex.Message}");
            }

            using Form dlg = new Form
            {
                Text = "Propose Skill Exchange",
                ClientSize = new Size(470, 545),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(20, 24, 21),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false
            };

            var uc = new Propose_skill_exchange
            {
                Dock = DockStyle.Fill
            };
            uc.InitializeTrade(parsedSkillId, title, owner, mode);
            dlg.Controls.Add(uc);
            dlg.ShowDialog(this);

            // Refresh marketplace so the card updates its button and badge state immediately
            LoadMarketplaceCards(txtSearch.Text, cmbCategory.SelectedItem?.ToString() ?? "All Categories");
        }

        private void OnReportClicked(string skillId, string title, string owner)
        {
            if (!UserSession.IsVerified)
            {
                MessageBox.Show("Your account is pending Admin verification. Reporting is enabled once your account is approved.", "Pending Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new ReportDialog(title, owner);
            if (dlg.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            string reason = dlg.ReportReason;
            try
            {
                int.TryParse(skillId, out int parsedSkillId);
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                object? ownerIdObj = null;
                if (parsedSkillId > 0)
                {
                    MySqlCommand ownerCmd = new MySqlCommand();
                    ownerCmd.CommandText = "SELECT UserId FROM tbl_skills WHERE SkillId = @sid LIMIT 1";
                    ownerCmd.Connection = conn;
                    ownerCmd.Parameters.AddWithValue("@sid", parsedSkillId);
                    using MySqlDataReader reader = ownerCmd.ExecuteReader();
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        ownerIdObj = reader[0];
                    }
                }

                object reportedUserIdParam = (ownerIdObj != null && int.TryParse(ownerIdObj.ToString(), out int parsedOwnerId) && parsedOwnerId > 0)
                    ? parsedOwnerId
                    : DBNull.Value;

                string reporter = string.IsNullOrWhiteSpace(UserSession.FullName) ? "Student Peer" : UserSession.FullName.Trim();

                MySqlCommand insertCmd = new MySqlCommand();
                insertCmd.CommandText = @"INSERT INTO tbl_reports (SkillId, ReportedUserId, ReportedUser, ReporterName, Reason, ReportDate, Status) 
                                          VALUES (@sid, @ruid, @user, @reporter, @reason, NOW(), 'Pending')";
                insertCmd.Connection = conn;
                insertCmd.Parameters.AddWithValue("@sid", parsedSkillId > 0 ? parsedSkillId : (object)DBNull.Value);
                insertCmd.Parameters.AddWithValue("@ruid", reportedUserIdParam);
                insertCmd.Parameters.AddWithValue("@user", owner);
                insertCmd.Parameters.AddWithValue("@reporter", reporter);
                insertCmd.Parameters.AddWithValue("@reason", reason);
                insertCmd.ExecuteNonQuery();
                conn.Close();

                // Notify Admin of new report
                NotificationHelper.NotifyAdminNewReport(skillId, title, owner, reason, reporter);

                MessageBox.Show("Report submitted successfully. Admin will review this listing.", "Report Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not record report: {ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMarketplaceCards(txtSearch.Text, cmbCategory.SelectedItem?.ToString() ?? "All Categories");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbCategory.SelectedIndex = 0;
            LoadMarketplaceCards("", "All Categories");
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMarketplaceCards(txtSearch.Text, cmbCategory.SelectedItem?.ToString() ?? "All Categories");
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void flpMarketplace_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
