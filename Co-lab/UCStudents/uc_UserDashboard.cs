using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_UserDashboard : UserControl
    {
        /// <summary>
        /// Current student's full name matching tbl_users.FullName, tbl_skills.OfferedBy, and tbl_traderequests.SenderName
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrentStudentName { get; set; } = "Juan Dela Cruz";

        public uc_UserDashboard()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void uc_UserDashboard_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            uc_UserDashboard_Resize(this, EventArgs.Empty);

            if (!string.IsNullOrWhiteSpace(UserSession.FullName))
            {
                CurrentStudentName = UserSession.FullName;
            }

            if (cmbProficiency.Items.Count > 0 && cmbProficiency.SelectedIndex < 0)
            {
                cmbProficiency.SelectedIndex = 1; // Intermediate
            }

            if (cmbCategory.Items.Count > 0 && cmbCategory.SelectedIndex < 0)
            {
                cmbCategory.SelectedIndex = 0;
            }

            LoadDashboardData();
        }

        /// <summary>
        /// Loads live metrics and table data from MySQL using DatabaseHelper.
        /// When there are no records, tables remain blank without dummy data.
        /// </summary>
        public void LoadDashboardData()
        {
            lblUserName.Text = CurrentStudentName;

            // Load Known Skills (Bio Inventory) independently so metrics errors never block it
            LoadKnownSkills();

            // Load Other Metrics & Trade Requests
            LoadTradeMetrics();
        }

        /// <summary>
        /// Loads the student's known skills directly from tbl_user_skills into dgvMySkills and updates Card 1.
        /// </summary>
        public void LoadKnownSkills()
        {
            int uid = UserSession.UserId;
            string studentName = string.IsNullOrWhiteSpace(UserSession.FullName) ? CurrentStudentName : UserSession.FullName;

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    @"SELECT UserSkillId, SkillName, Category, ProficiencyLevel 
                      FROM tbl_user_skills 
                      WHERE UserId = @uid OR UserId = (SELECT UserId FROM tbl_users WHERE FullName = @name LIMIT 1) 
                      ORDER BY UserSkillId DESC",
                    new MySqlParameter("@uid", uid),
                    new MySqlParameter("@name", studentName));

                BindMySkillsGrid(dt);

                int count = (dt != null) ? dt.Rows.Count : 0;
                lblCard1Value.Text = count.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading known skills: {ex.Message}");
                BindMySkillsGrid(null);
            }
        }

        private void LoadTradeMetrics()
        {
            int pendingRequestsCount = 0;
            int acceptedTradesCount = 0;
            int outgoingRequestsCount = 0;
            DataTable? dtIncoming = null;

            int uid = UserSession.UserId;
            string studentName = string.IsNullOrWhiteSpace(UserSession.FullName) ? CurrentStudentName : UserSession.FullName;

            try
            {
                // 1. Pending Incoming Requests (targeted at this student's skills)
                object? pObj = DatabaseHelper.ExecuteScalar(
                    @"SELECT COUNT(*) 
                      FROM tbl_traderequests r 
                      INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                      WHERE (s.UserId = @uid OR s.OfferedBy = @name) 
                        AND (r.Status = 'Pending' OR r.Status IS NULL)",
                    new MySqlParameter("@uid", uid),
                    new MySqlParameter("@name", studentName));
                if (pObj != null && int.TryParse(pObj.ToString(), out int c2))
                {
                    pendingRequestsCount = c2;
                }

                // 2. Accepted Trades (where this student is either owner or requester)
                object? aObj = DatabaseHelper.ExecuteScalar(
                    @"SELECT COUNT(*) 
                      FROM tbl_traderequests r 
                      INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                      WHERE (s.UserId = @uid OR s.OfferedBy = @name OR r.SenderName = @name) 
                        AND r.Status = 'Accepted'",
                    new MySqlParameter("@uid", uid),
                    new MySqlParameter("@name", studentName));
                if (aObj != null && int.TryParse(aObj.ToString(), out int c3))
                {
                    acceptedTradesCount = c3;
                }

                // 3. Outgoing Requests (sent by this student)
                object? oObj = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_traderequests WHERE SenderName = @name",
                    new MySqlParameter("@name", studentName));
                if (oObj != null && int.TryParse(oObj.ToString(), out int c4))
                {
                    outgoingRequestsCount = c4;
                }

                // 4. Query Incoming Requests for dgvIncoming
                dtIncoming = DatabaseHelper.ExecuteQuery(
                    @"SELECT 
                        r.RequestId, 
                        r.SenderName AS Requester, 
                        r.OfferedSkillTitle AS `Their Offer Back`, 
                        r.MeetingMode AS Mode, 
                        r.Status 
                      FROM tbl_traderequests r 
                      INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                      WHERE (s.UserId = @uid OR s.OfferedBy = @name) 
                        AND (r.Status = 'Pending' OR r.Status IS NULL) 
                      ORDER BY r.RequestId DESC",
                    new MySqlParameter("@uid", uid),
                    new MySqlParameter("@name", studentName));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading trade metrics: {ex.Message}");
            }

            lblCard2Value.Text = pendingRequestsCount.ToString();
            lblCard3Value.Text = acceptedTradesCount.ToString();
            lblCard4Value.Text = outgoingRequestsCount.ToString();

            BindIncomingGrid(dtIncoming);
        }

        private void BindIncomingGrid(DataTable? dt)
        {
            dgvIncoming.DataSource = null;
            dgvIncoming.AutoGenerateColumns = true;
            dgvIncoming.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncoming.DataSource = dt;
            if (dgvIncoming.Columns["RequestId"] is DataGridViewColumn colReq)
            {
                colReq.Visible = false;
            }
            dgvIncoming.Refresh();
        }

        private void BindMySkillsGrid(DataTable? dt)
        {
            dgvMySkills.DataSource = null;
            dgvMySkills.AutoGenerateColumns = true;
            dgvMySkills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMySkills.DataSource = dt;
            if (dgvMySkills.Columns["UserSkillId"] is DataGridViewColumn colId)
            {
                colId.Visible = false;
            }
            if (dgvMySkills.Columns["SkillName"] is DataGridViewColumn colName)
            {
                colName.HeaderText = "Skill Name";
            }
            if (dgvMySkills.Columns["ProficiencyLevel"] is DataGridViewColumn colProf)
            {
                colProf.HeaderText = "Proficiency";
            }
            dgvMySkills.Refresh();
        }

        // ==========================================
        // ACTION BUTTONS (ACCEPT / DECLINE / KNOWN SKILLS CRUD)
        // ==========================================

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            string skillName = txtSkillName.Text.Trim();
            if (string.IsNullOrWhiteSpace(skillName))
            {
                MessageBox.Show("Please enter a skill name that you know (e.g. C# Programming, Guitar, Calculus).", "Missing Skill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSkillName.Focus();
                return;
            }

            int uid = UserSession.UserId;
            if (uid <= 0)
            {
                object? idObj = DatabaseHelper.ExecuteScalar(
                    "SELECT UserId FROM tbl_users WHERE FullName = @name LIMIT 1",
                    new MySqlParameter("@name", CurrentStudentName));
                if (idObj != null && int.TryParse(idObj.ToString(), out int parsedUid))
                {
                    uid = parsedUid;
                    UserSession.UserId = parsedUid;
                }
            }

            if (uid <= 0)
            {
                MessageBox.Show("User session is not valid. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string category = cmbCategory.SelectedItem?.ToString() ?? "Computer Science & IT";
            string level = cmbProficiency.SelectedItem?.ToString() ?? "Intermediate";

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO tbl_user_skills (UserId, SkillName, Category, ProficiencyLevel) VALUES (@uid, @name, @cat, @level)",
                    new MySqlParameter("@uid", uid),
                    new MySqlParameter("@name", skillName),
                    new MySqlParameter("@cat", category),
                    new MySqlParameter("@level", level));

                if (rows > 0)
                {
                    txtSkillName.Clear();
                    LoadDashboardData();
                    MessageBox.Show($"'{skillName}' has been added to your profile inventory!\n\nWhen you're ready to offer it in the marketplace, visit 'My Listings'.", "Skill Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not add skill to database: {ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteSkill_Click(object sender, EventArgs e)
        {
            if (dgvMySkills.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a skill from your profile list to remove.", "Select Skill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvMySkills.SelectedRows[0];
            int userSkillId = 0;
            var idCell = row.DataGridView?.Columns.Contains("UserSkillId") == true ? row.Cells["UserSkillId"] :
                         (row.DataGridView?.Columns.Contains("colUserSkillId") == true ? row.Cells["colUserSkillId"] : null);
            if (idCell?.Value != null &&
                int.TryParse(idCell.Value.ToString(), out int parsedId))
            {
                userSkillId = parsedId;
            }

            if (userSkillId <= 0)
            {
                MessageBox.Show("No valid skill selected.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var nameCell = row.DataGridView?.Columns.Contains("SkillName") == true ? row.Cells["SkillName"] :
                           (row.DataGridView?.Columns.Contains("colSkillName") == true ? row.Cells["colSkillName"] : null);
            string skillName = nameCell?.Value?.ToString() ?? "this skill";

            if (MessageBox.Show($"Are you sure you want to remove '{skillName}' from your profile bio?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM tbl_user_skills WHERE UserSkillId = @id",
                    new MySqlParameter("@id", userSkillId));

                if (rows > 0)
                {
                    MessageBox.Show($"'{skillName}' removed from profile.", "Skill Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDashboardData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not remove skill from database: {ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOfferInMarket_Click(object sender, EventArgs e)
        {
            if (FindForm() is StudentMainForm mainForm)
            {
                mainForm.NavigateToManageSkills();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dgvIncoming.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an incoming request from the table to accept.", "Select Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvIncoming.SelectedRows[0];
            int reqId = 0;
            if (row.Cells["RequestId"] != null && row.Cells["RequestId"].Value != null &&
                int.TryParse(row.Cells["RequestId"].Value?.ToString(), out int parsedId))
            {
                reqId = parsedId;
            }

            if (reqId <= 0)
            {
                MessageBox.Show("No valid request selected.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(
                    "UPDATE tbl_traderequests SET Status = 'Accepted' WHERE RequestId = @id",
                    new MySqlParameter("@id", reqId));

                if (rows > 0)
                {
                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(
                            @"UPDATE tbl_skills SET Status = 'Paused' 
                              WHERE SkillId = (SELECT TargetSkillId FROM tbl_traderequests WHERE RequestId = @id)",
                            new MySqlParameter("@id", reqId));
                    }
                    catch { }

                    MessageBox.Show("Trade request accepted successfully! The listing has been marked ongoing and paused on the marketplace.", "Request Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDashboardData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not update trade request in database: {ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (dgvIncoming.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an incoming request from the table to decline.", "Select Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvIncoming.SelectedRows[0];
            int reqId = 0;
            if (row.Cells["RequestId"] != null && row.Cells["RequestId"].Value != null &&
                int.TryParse(row.Cells["RequestId"].Value?.ToString(), out int parsedId))
            {
                reqId = parsedId;
            }

            if (reqId <= 0)
            {
                MessageBox.Show("No valid request selected.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to decline this trade request?", "Confirm Decline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(
                    "UPDATE tbl_traderequests SET Status = 'Declined' WHERE RequestId = @id",
                    new MySqlParameter("@id", reqId));

                if (rows > 0)
                {
                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(
                            @"UPDATE tbl_skills s
                              SET s.Status = 'Active'
                              WHERE s.SkillId = (SELECT TargetSkillId FROM tbl_traderequests WHERE RequestId = @id)
                                AND s.Status = 'Paused'
                                AND NOT EXISTS (
                                    SELECT 1 FROM tbl_traderequests r2 
                                    WHERE r2.TargetSkillId = s.SkillId AND r2.Status = 'Accepted'
                                )",
                            new MySqlParameter("@id", reqId));
                    }
                    catch { }

                    MessageBox.Show("Trade request declined.", "Request Declined", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDashboardData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not update trade request in database: {ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        // ==========================================
        // SHORTCUT BUTTONS
        // ==========================================

        private void btnPostSkill_Click(object sender, EventArgs e)
        {
            if (FindForm() is StudentMainForm mainForm)
            {
                mainForm.NavigateToManageSkills();
            }
        }

        private void btnBrowseMarketplace_Click(object sender, EventArgs e)
        {
            if (FindForm() is StudentMainForm mainForm)
            {
                mainForm.NavigateToSkillExchange();
            }
        }

        private void btnTradeHistory_Click(object sender, EventArgs e)
        {
            if (FindForm() is StudentMainForm mainForm)
            {
                mainForm.NavigateToTradeRequests();
            }
        }

        private void btnReadRegulations_Click(object sender, EventArgs e)
        {
            using var dlg = new TosDialog(readOnlyMode: true);
            dlg.ShowDialog(this);
        }

        // ==========================================
        // RESPONSIVE LAYOUT (MINIMIZED & MAXIMIZED MODES)
        // ==========================================
        private void uc_UserDashboard_Resize(object? sender, EventArgs e)
        {
            int padding = 24;
            int availWidth = Math.Max(902, ClientSize.Width - (padding * 2) - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0));

            // 1. Stat cards: 4 columns
            int cardGap = 16;
            int cardWidth = (availWidth - (cardGap * 3)) / 4;
            pnlCard1.Location = new Point(padding, 77);
            pnlCard1.Width = cardWidth;

            pnlCard2.Location = new Point(pnlCard1.Right + cardGap, 77);
            pnlCard2.Width = cardWidth;

            pnlCard3.Location = new Point(pnlCard2.Right + cardGap, 77);
            pnlCard3.Width = cardWidth;

            pnlCard4.Location = new Point(pnlCard3.Right + cardGap, 77);
            pnlCard4.Width = availWidth - (pnlCard4.Left - padding);

            // 2. Row 2: Shortcuts
            pnlShortcuts.Location = new Point(padding, 209);
            pnlShortcuts.Width = availWidth;

            int shortcutBtnGap = 16;
            int shortcutBtnWidth = Math.Max(160, (pnlShortcuts.Width - 40 - (shortcutBtnGap * 3)) / 4);
            btnPostSkill.Location = new Point(20, 41);
            btnPostSkill.Width = shortcutBtnWidth;

            btnBrowseMarketplace.Location = new Point(btnPostSkill.Right + shortcutBtnGap, 41);
            btnBrowseMarketplace.Width = shortcutBtnWidth;

            btnReadRegulations.Location = new Point(btnBrowseMarketplace.Right + shortcutBtnGap, 41);
            btnReadRegulations.Width = shortcutBtnWidth;

            btnTradeHistory.Location = new Point(btnReadRegulations.Right + shortcutBtnGap, 41);
            btnTradeHistory.Width = Math.Max(160, pnlShortcuts.Width - 20 - btnTradeHistory.Left);

            // 3. Row 3: Incoming & My Skills
            int halfWidth = (availWidth - cardGap) / 2;
            pnlIncoming.Location = new Point(padding, 312);
            pnlIncoming.Width = halfWidth;

            btnAccept.Left = pnlIncoming.Width - 14 - btnAccept.Width;
            btnDecline.Left = pnlIncoming.Width - 14 - btnDecline.Width;
            dgvIncoming.Width = Math.Max(200, btnAccept.Left - 24);

            pnlMySkills.Location = new Point(pnlIncoming.Right + cardGap, 312);
            pnlMySkills.Width = availWidth - halfWidth - cardGap;

            int rightWidth = 154;
            int leftWidth = Math.Max(150, pnlMySkills.Width - 14 - 10 - rightWidth - 14);
            txtSkillName.Width = leftWidth;
            cmbCategory.Width = leftWidth;
            cmbProficiency.Left = txtSkillName.Right + 10;
            cmbProficiency.Width = rightWidth;
            btnAddSkill.Left = cmbCategory.Right + 10;
            btnAddSkill.Width = rightWidth;

            dgvMySkills.Width = Math.Max(200, pnlMySkills.Width - 28);
            btnOfferInMarket.Left = pnlMySkills.Width - 14 - btnOfferInMarket.Width;
            btnDeleteSkill.Left = 14;

            Invalidate(true);
        }

        // ==========================================
        // CUSTOM ROUNDED CORNERS & CARD DRAWING
        // ==========================================

        private void RoundPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Control ctrl) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(1, 1, ctrl.Width - 3, ctrl.Height - 3);
            using var path = CreateRoundedRectanglePath(rect, 10);
            using var borderPen = new Pen(Color.FromArgb(40, 56, 45), 1.5f);

            // Draw clean subtle border around the rounded card
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

        private void dgvMySkills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblCard2Title_Click(object sender, EventArgs e)
        {

        }

        private void lblCard2Value_Click(object sender, EventArgs e)
        {

        }
    }
}
