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
                        r.OfferedSkillTitle AS [Their Offer Back], 
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
            dgvIncoming.AutoGenerateColumns = false;
            dgvIncoming.DataSource = dt;
            dgvIncoming.Refresh();
        }

        private void BindMySkillsGrid(DataTable? dt)
        {
            dgvMySkills.DataSource = null;
            dgvMySkills.AutoGenerateColumns = false;
            dgvMySkills.DataSource = dt;
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
            if (row.Cells["colUserSkillId"]?.Value != null &&
                int.TryParse(row.Cells["colUserSkillId"].Value.ToString(), out int parsedId))
            {
                userSkillId = parsedId;
            }

            if (userSkillId <= 0)
            {
                MessageBox.Show("No valid skill selected.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string skillName = row.Cells["colSkillName"]?.Value?.ToString() ?? "this skill";

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
                    MessageBox.Show("Trade request accepted successfully!", "Request Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string regulationsText = "";

            try
            {
                object? tosObj = DatabaseHelper.ExecuteScalar("SELECT TosContent FROM tbl_tos ORDER BY TosId DESC LIMIT 1");
                if (tosObj != null)
                {
                    regulationsText = tosObj.ToString() ?? "";
                }
            }
            catch
            {
                // Fallback text if database is offline
            }

            if (string.IsNullOrWhiteSpace(regulationsText))
            {
                regulationsText = "WELCOME TO CO-LAB: UE STUDENT SKILL EXCHANGE REGULATIONS\n\n" +
                                  "1. ELIGIBILITY: You must be an officially enrolled student of the University of the East with a valid @ue.edu.ph email address.\n\n" +
                                  "2. ACADEMIC INTEGRITY: Skills exchanged must focus on tutoring, mentoring, creative skills, or technical training. Directly completing someone else's graded exam, quiz, or project is strictly forbidden.\n\n" +
                                  "3. NON-MONETARY POLICY: Co-LAB is a barter/exchange platform. Charging cash or cryptocurrency for skill sharing is prohibited.\n\n" +
                                  "4. SAFETY & CONDUCT: Respect your fellow students. For Face-to-Face exchanges, only meet in public campus areas (Libraries, Student Centers, Cafeteria).\n\n" +
                                  "5. VIOLATIONS: Violations will lead to immediate account suspension and blacklisting.";
            }

            using Form dlg = new Form
            {
                Text = "UE Student Skill Exchange - Regulations & Guidelines",
                Size = new Size(620, 500),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(24, 24, 27),
                ForeColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            TextBox txt = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(18, 24, 20),
                ForeColor = Color.FromArgb(228, 228, 231),
                Font = new Font("Segoe UI", 10F),
                Text = regulationsText,
                BorderStyle = BorderStyle.None
            };

            Panel pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 55,
                BackColor = Color.FromArgb(24, 24, 27)
            };

            Button btnOk = new Button
            {
                Text = "I Understand",
                DialogResult = DialogResult.OK,
                Size = new Size(130, 36),
                Location = new Point(dlg.ClientSize.Width - 150, 10),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.FromArgb(16, 185, 129),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
            };
            btnOk.FlatAppearance.BorderSize = 0;
            pnlBottom.Controls.Add(btnOk);

            Panel pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(16)
            };
            pnlContent.Controls.Add(txt);

            dlg.Controls.Add(pnlContent);
            dlg.Controls.Add(pnlBottom);
            dlg.ShowDialog(this);
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
