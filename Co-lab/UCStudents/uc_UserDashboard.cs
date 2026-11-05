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
            LoadDashboardData();
        }

        /// <summary>
        /// Loads live metrics and table data from MySQL using DatabaseHelper.
        /// When there are no records, tables remain blank without dummy data.
        /// </summary>
        public void LoadDashboardData()
        {
            lblUserName.Text = CurrentStudentName;

            int activeSkillsCount = 0;
            int pendingRequestsCount = 0;
            int acceptedTradesCount = 0;
            int outgoingRequestsCount = 0;

            DataTable? dtIncoming = null;
            DataTable? dtSkills = null;

            try
            {
                // 1. Check active skills in tbl_skills
                object? activeObj = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_skills WHERE OfferedBy = @user AND (Status = 'Active' OR Status = 'Open' OR Status IS NULL)",
                    new MySqlParameter("@user", CurrentStudentName));
                if (activeObj != null && int.TryParse(activeObj.ToString(), out int c1))
                {
                    activeSkillsCount = c1;
                }

                // 2. Check pending incoming requests in tbl_traderequests joined to tbl_skills
                object? pendingObj = DatabaseHelper.ExecuteScalar(
                    @"SELECT COUNT(*) FROM tbl_traderequests r 
                      INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                      WHERE s.OfferedBy = @user AND (r.Status = 'Pending' OR r.Status IS NULL)",
                    new MySqlParameter("@user", CurrentStudentName));
                if (pendingObj != null && int.TryParse(pendingObj.ToString(), out int c2))
                {
                    pendingRequestsCount = c2;
                }

                // 3. Check accepted trades (active) for this student
                object? acceptedObj = DatabaseHelper.ExecuteScalar(
                    @"SELECT COUNT(*) FROM tbl_traderequests r 
                      INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                      WHERE (s.OfferedBy = @user OR r.SenderName = @user) AND r.Status = 'Accepted'",
                    new MySqlParameter("@user", CurrentStudentName));
                if (acceptedObj != null && int.TryParse(acceptedObj.ToString(), out int c3))
                {
                    acceptedTradesCount = c3;
                }

                // 4. Check outgoing requests sent by this student
                object? outgoingObj = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_traderequests WHERE SenderName = @user",
                    new MySqlParameter("@user", CurrentStudentName));
                if (outgoingObj != null && int.TryParse(outgoingObj.ToString(), out int c4))
                {
                    outgoingRequestsCount = c4;
                }

                // 5. Query Incoming Trade Requests table
                dtIncoming = DatabaseHelper.ExecuteQuery(
                    @"SELECT 
                        r.RequestId, 
                        r.SenderName AS Requester, 
                        r.OfferedSkillTitle AS [Their Offer Back], 
                        r.MeetingMode AS Mode, 
                        r.Status 
                      FROM tbl_traderequests r 
                      INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                      WHERE s.OfferedBy = @user AND (r.Status = 'Pending' OR r.Status IS NULL) 
                      ORDER BY r.RequestId DESC",
                    new MySqlParameter("@user", CurrentStudentName));

                // 6. Query My Offered Skills table
                dtSkills = DatabaseHelper.ExecuteQuery(
                    @"SELECT 
                        SkillId, 
                        SkillTitle AS [Skill Offered], 
                        DesiredSkill AS [Skill Wanted], 
                        Status 
                      FROM tbl_skills 
                      WHERE OfferedBy = @user AND (Status != 'Archived' OR Status IS NULL) 
                      ORDER BY SkillId DESC",
                    new MySqlParameter("@user", CurrentStudentName));
            }
            catch
            {
                // In case database is offline or not reachable
            }

            // Update Metric Cards
            lblCard1Value.Text = activeSkillsCount.ToString();
            lblCard2Value.Text = pendingRequestsCount.ToString();
            lblCard3Value.Text = acceptedTradesCount.ToString();
            lblCard4Value.Text = outgoingRequestsCount.ToString();

            // Populate Incoming Requests DataGridView (blank schema if no data)
            if (dtIncoming != null)
            {
                BindIncomingGrid(dtIncoming);
            }
            else
            {
                DataTable emptyIncoming = new DataTable();
                emptyIncoming.Columns.Add("RequestId", typeof(int));
                emptyIncoming.Columns.Add("Requester", typeof(string));
                emptyIncoming.Columns.Add("Their Offer Back", typeof(string));
                emptyIncoming.Columns.Add("Mode", typeof(string));
                emptyIncoming.Columns.Add("Status", typeof(string));
                BindIncomingGrid(emptyIncoming);
            }

            // Populate My Offered Skills DataGridView (blank schema if no data)
            if (dtSkills != null)
            {
                BindMySkillsGrid(dtSkills);
            }
            else
            {
                DataTable emptySkills = new DataTable();
                emptySkills.Columns.Add("SkillId", typeof(int));
                emptySkills.Columns.Add("Skill Offered", typeof(string));
                emptySkills.Columns.Add("Skill Wanted", typeof(string));
                emptySkills.Columns.Add("Status", typeof(string));
                BindMySkillsGrid(emptySkills);
            }
        }

        private void BindIncomingGrid(DataTable dt)
        {
            dgvIncoming.DataSource = dt;

            if (dgvIncoming.Columns["RequestId"] is DataGridViewColumn colReqId)
                colReqId.Visible = false;

            if (dgvIncoming.Columns["Status"] is DataGridViewColumn colStatus)
                colStatus.Visible = false;

            if (dgvIncoming.Columns["Requester"] is DataGridViewColumn colReq)
            {
                colReq.HeaderText = "Requester";
                colReq.Width = 95;
            }

            if (dgvIncoming.Columns["Their Offer Back"] is DataGridViewColumn colOffer)
            {
                colOffer.HeaderText = "Their Offer Back";
                colOffer.Width = 130;
            }

            if (dgvIncoming.Columns["Mode"] is DataGridViewColumn colMode)
            {
                colMode.HeaderText = "Mode";
                colMode.Width = 70;
            }
        }

        private void BindMySkillsGrid(DataTable dt)
        {
            dgvMySkills.DataSource = dt;

            if (dgvMySkills.Columns["SkillId"] is DataGridViewColumn colSkillId)
                colSkillId.Visible = false;

            if (dgvMySkills.Columns["Skill Offered"] is DataGridViewColumn colOffered)
            {
                colOffered.HeaderText = "Skill Offered";
                colOffered.Width = 145;
            }

            if (dgvMySkills.Columns["Skill Wanted"] is DataGridViewColumn colWanted)
            {
                colWanted.HeaderText = "Skill Wanted";
                colWanted.Width = 145;
            }

            if (dgvMySkills.Columns["Status"] is DataGridViewColumn colStat)
            {
                colStat.HeaderText = "Status";
                colStat.Width = 90;
            }
        }

        // ==========================================
        // ACTION BUTTONS (ACCEPT / DECLINE / REMOVE)
        // ==========================================

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

        private void btnCloseListing_Click(object sender, EventArgs e)
        {
            if (dgvMySkills.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a skill listing to close or remove.", "Select Listing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvMySkills.SelectedRows[0];
            int skillId = 0;
            if (row.Cells["SkillId"] != null && row.Cells["SkillId"].Value != null &&
                int.TryParse(row.Cells["SkillId"].Value?.ToString(), out int parsedId))
            {
                skillId = parsedId;
            }

            if (skillId <= 0)
            {
                MessageBox.Show("No valid skill listing selected.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to close / remove this skill listing?", "Confirm Remove Listing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(
                    "UPDATE tbl_skills SET Status = 'Archived' WHERE SkillId = @id",
                    new MySqlParameter("@id", skillId));

                if (rows > 0)
                {
                    MessageBox.Show("Skill listing has been closed and removed.", "Listing Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDashboardData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not remove skill listing from database: {ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // SHORTCUT BUTTONS
        // ==========================================

        private void btnPostSkill_Click(object sender, EventArgs e)
        {
            if (FindForm() is StudentMainForm mainForm)
            {
                mainForm.NavigateToPostSkill();
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
    }
}
