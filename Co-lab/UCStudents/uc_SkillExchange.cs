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
        public uc_SkillExchange()
        {
            InitializeComponent();
        }

        private void uc_SkillExchange_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadMarketplaceCards("", "All Categories");
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
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT CategoryName FROM tbl_categories ORDER BY CategoryName ASC");
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
        /// <summary>
        /// Queries the database and dynamically generates cards inside the FlowLayoutPanel.
        /// Keeps ongoing listings visible on the marketplace while marking them as Ongoing and disabling trade requests.
        /// </summary>
        public void LoadMarketplaceCards(string keyword, string category)
        {
            flpMarketplace.SuspendLayout();
            flpMarketplace.Controls.Clear();

            string currentStudent = UserSession.FullName ?? "";
            string currentEmail = UserSession.Email ?? "";
            int currentUid = UserSession.UserId;

            try
            {
                // Select active and ongoing (paused) listings, together with accepted & user pending trade flags
                string query = @"
                    SELECT s.*,
                           (SELECT COUNT(*) FROM tbl_traderequests r 
                            WHERE r.TargetSkillId = s.SkillId AND r.Status = 'Accepted') AS AcceptedTradesCount,
                           (SELECT COUNT(*) FROM tbl_traderequests r 
                            WHERE r.TargetSkillId = s.SkillId 
                              AND (r.SenderEmail = @userEmail OR r.SenderName = @userName) 
                              AND r.Status IN ('Pending', 'Accepted')) AS UserRequestsCount
                    FROM tbl_skills s
                    WHERE (s.Status IN ('Active', 'Paused') OR s.Status IS NULL)";

                var parameters = new System.Collections.Generic.List<MySqlParameter>
                {
                    new MySqlParameter("@userEmail", currentEmail),
                    new MySqlParameter("@userName", currentStudent)
                };

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " AND (s.SkillTitle LIKE @kw OR s.Description LIKE @kw OR s.OfferedBy LIKE @kw)";
                    parameters.Add(new MySqlParameter("@kw", "%" + keyword.Trim() + "%"));
                }

                if (!string.IsNullOrWhiteSpace(category) && category != "All Categories")
                {
                    query += " AND s.Category = @cat";
                    parameters.Add(new MySqlParameter("@cat", category));
                }

                query += " ORDER BY s.SkillId DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());

                if (dt.Rows.Count == 0)
                {
                    ShowEmptyState("No skill listings found matching your search.");
                    lblListingCount.Text = "0 skills available";
                }
                else
                {
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
            Label lblEmpty = new Label
            {
                Text = message,
                ForeColor = Color.FromArgb(161, 161, 170),
                Font = new Font("Segoe UI", 10.5F),
                AutoSize = false,
                Size = new Size(600, 80),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(120, 100, 0, 0)
            };
            flpMarketplace.Controls.Add(lblEmpty);
        }

        private void OnRequestTradeClicked(string skillId, string title, string owner, string mode)
        {
            string currentStudent = UserSession.FullName;
            string currentEmail = UserSession.Email;

            if (!string.IsNullOrWhiteSpace(currentStudent) && string.Equals(owner, currentStudent, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("This is your own skill listing! You cannot send a trade request to yourself.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int.TryParse(skillId, out int parsedSkillId);

            // Guard: Check if the user already has an ongoing trade request for this skill
            try
            {
                string checkSql = @"SELECT Status FROM tbl_traderequests 
                                    WHERE TargetSkillId = @sid 
                                      AND (SenderEmail = @email OR SenderName = @name) 
                                      AND Status IN ('Pending', 'Accepted') 
                                    LIMIT 1";
                object? existingStatus = DatabaseHelper.ExecuteScalar(checkSql,
                    new MySqlParameter("@sid", parsedSkillId),
                    new MySqlParameter("@email", currentEmail),
                    new MySqlParameter("@name", currentStudent));

                if (existingStatus != null && existingStatus != DBNull.Value)
                {
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
                string acceptedCheckSql = "SELECT Status FROM tbl_traderequests WHERE TargetSkillId = @sid AND Status = 'Accepted' LIMIT 1";
                object? acceptedStatus = DatabaseHelper.ExecuteScalar(acceptedCheckSql, new MySqlParameter("@sid", parsedSkillId));
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
            string reason = Microsoft.VisualBasic.Interaction.InputBox(
                $"Why are you reporting this listing?\n\nListing: {title}\nPosted by: {owner}",
                "Report Listing / Student",
                "Inappropriate content or spam");

            if (!string.IsNullOrWhiteSpace(reason))
            {
                try
                {
                    string insertSql = @"INSERT INTO tbl_reports (SkillId, ReportedUser, Reason, ReportDate, Status) 
                                         VALUES (@sid, @user, @reason, NOW(), 'Pending')";
                    DatabaseHelper.ExecuteNonQuery(insertSql,
                        new MySqlParameter("@sid", skillId),
                        new MySqlParameter("@user", owner),
                        new MySqlParameter("@reason", reason.Trim())
                    );
                    MessageBox.Show("Report submitted successfully. Admin will review this listing.", "Report Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not record report: {ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
