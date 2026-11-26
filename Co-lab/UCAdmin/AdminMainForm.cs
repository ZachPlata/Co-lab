using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class AdminMainForm : Form
    {
        private System.Windows.Forms.Timer _notifTimer = null!;

        public AdminMainForm()
        {
            InitializeComponent();
            this.FormClosing += AdminMainForm_FormClosing;
            pnlHeader.Resize += (s, e) => LayoutHeaderControls();
        }

        private void LayoutHeaderControls()
        {
            if (pnlHeader == null || btnNotificationBell == null || lblAdminProfile == null) return;

            lblAdminProfile.AutoEllipsis = true;
            lblAdminProfile.MaximumSize = new Size(280, 28);

            int rightMargin = 24;
            lblAdminProfile.Location = new Point(
                Math.Max(lblHeaderTitle.Right + 16, pnlHeader.ClientSize.Width - lblAdminProfile.Width - rightMargin),
                (pnlHeader.Height - lblAdminProfile.Height) / 2);

            btnNotificationBell.Location = new Point(
                Math.Max(lblHeaderTitle.Right + 16, lblAdminProfile.Left - btnNotificationBell.Width - 16),
                (pnlHeader.Height - btnNotificationBell.Height) / 2);

            if (_lblDbStatusPill != null)
            {
                _lblDbStatusPill.Location = new Point(lblHeaderTitle.Right + 16, (pnlHeader.Height - _lblDbStatusPill.Height) / 2);
            }
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            string adminName = string.IsNullOrWhiteSpace(UserSession.FullName) ? "Administrator" : UserSession.FullName;
            lblAdminProfile.Text = $"🛡️ {adminName}";
            _lblDbStatusPill.BringToFront();

            LayoutHeaderControls();

            // Initialize notification UI & background checking
            InitializeNotificationUI();

            btn_AdminDashboard.PerformClick();
        }

        private void InitializeNotificationUI()
        {
            _notificationPanel.NotificationActionRequested += (s, type) =>
            {
                _notificationPanel.Visible = false;
                if (type == "Report")
                {
                    btn_ReportedStudents.PerformClick();
                }
                CheckNotifications();
            };
            _notificationPanel.CloseRequested += (s, e) =>
            {
                _notificationPanel.Visible = false;
            };

            // Background timer to refresh admin notifications live & heartbeat session
            _notifTimer = new System.Windows.Forms.Timer
            {
                Interval = 5000 // Every 5 seconds
            };
            _notifTimer.Tick += (s, e) =>
            {
                HandleHeartbeatAndNotifications();
            };
            _notifTimer.Start();

            // Initial heartbeat, sync & check
            HandleHeartbeatAndNotifications();
            NotificationHelper.SyncExistingPendingNotifications();
        }

        private void HandleHeartbeatAndNotifications()
        {
            HeartbeatResult hb = UserSession.Heartbeat(out _);
            if (hb == HeartbeatResult.SessionInvalid)
            {
                _notifTimer?.Stop();
                MessageBox.Show("Your admin session has ended.", "Session Ended", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UserSession.SignedOut = true;
                UserSession.Clear();
                Close();
                return;
            }

            if (_lblDbStatusPill != null)
            {
                _lblDbStatusPill.Visible = hb == HeartbeatResult.Offline;
            }

            if (hb == HeartbeatResult.Ok)
            {
                CheckNotifications();
            }
        }

        private void BtnNotificationBell_Click(object? sender, EventArgs e)
        {
            int bellRightOnForm = pnlSidebar.Width + btnNotificationBell.Right;
            int panelX = Math.Max(8, Math.Min(bellRightOnForm - _notificationPanel.Width, ClientSize.Width - _notificationPanel.Width - 16));
            _notificationPanel.Location = new Point(panelX, pnlHeader.Bottom + 2);
            _notificationPanel.Visible = !_notificationPanel.Visible;
            if (_notificationPanel.Visible)
            {
                _notificationPanel.RefreshNotifications("", "Admin");
                _notificationPanel.BringToFront();
            }
        }

        private void CheckNotifications()
        {
            try
            {
                int unread = NotificationHelper.GetUnreadCount("", "Admin");
                if (unread > 0)
                {
                    btnNotificationBell.Text = $"🔔 {unread}";
                    btnNotificationBell.BackColor = Color.FromArgb(50, 24, 24);
                    btnNotificationBell.ForeColor = Color.FromArgb(248, 113, 113);
                    btnNotificationBell.FlatAppearance.BorderColor = Color.FromArgb(239, 68, 68);
                }
                else
                {
                    btnNotificationBell.Text = "🔔 0";
                    btnNotificationBell.BackColor = Color.FromArgb(24, 34, 27);
                    btnNotificationBell.ForeColor = Color.FromArgb(74, 222, 128);
                    btnNotificationBell.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 70);
                }

                // Also update sidebar badge for pending reports
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "SELECT COUNT(*) FROM tbl_reports WHERE Status = 'Pending'";
                cmd.Connection = conn;

                int pendingReports = 0;
                using MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() && reader[0] != DBNull.Value)
                {
                    pendingReports = Convert.ToInt32(reader[0]);
                }
                conn.Close();
                if (pendingReports > 0)
                {
                    btn_ReportedStudents.Text = $"Reports & Blacklist ({pendingReports})";
                }
                else
                {
                    btn_ReportedStudents.Text = "Reports & Blacklist";
                }
            }
            catch (MySqlException)
            {
                if (_lblDbStatusPill != null) _lblDbStatusPill.Visible = true;
            }
            catch
            {
            }
        }

        // ==========================================
        // SIDEBAR BUTTON CLICK EVENTS (TRANSITIONS)
        // ==========================================

        private void LoadContentControl(Func<UserControl> createControl)
        {
            using (LoadingOverlay.ShowOver(panelContent))
            {
                panelContent.SuspendLayout();
                for (int i = panelContent.Controls.Count - 1; i >= 0; i--)
                {
                    Control old = panelContent.Controls[i];
                    panelContent.Controls.RemoveAt(i);
                    old.Dispose();
                }

                UserControl control = createControl();
                control.Dock = DockStyle.Fill;
                panelContent.Controls.Add(control);
                control.Show();
                panelContent.ResumeLayout(true);
                panelContent.PerformLayout();
                control.Refresh();
                panelContent.Update();
            }
        }

        private void btn_AdminDashboard_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(() => new uc_AdminDashboard());
            SetActiveButton(btn_AdminDashboard);
            lblHeaderTitle.Text = "Admin Dashboard";
        }

        private void btn_StudentLists_Click(object? sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(() => new uc_StudentLists());
            SetActiveButton(btn_StudentLists);
            lblHeaderTitle.Text = "Student & User Lists";
        }

        private void btn_StudentVerification_Click(object? sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(() => new uc_StudentVerification());
            SetActiveButton(btn_StudentVerification);
            lblHeaderTitle.Text = "Student Verification";
        }

        private void btn_SkillCategories_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(() => new uc_SkillCategories());
            SetActiveButton(btn_SkillCategories);
            lblHeaderTitle.Text = "Skill Categories Creation";
        }

        private void btn_ModerateListings_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(() => new uc_ModerateListings());
            SetActiveButton(btn_ModerateListings);
            lblHeaderTitle.Text = "Moderate Skill Listings";
        }

        private void btn_ReportedStudents_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(() => new uc_ReportedStudents());
            SetActiveButton(btn_ReportedStudents);
            lblHeaderTitle.Text = "Reports & Blacklist";
            CheckNotifications();
        }

        private void SetActiveButton(Button activeButton)
        {
            Button[] navButtons = { btn_AdminDashboard, btn_StudentLists, btn_StudentVerification, btn_SkillCategories, btn_ModerateListings, btn_ReportedStudents };
            foreach (var btn in navButtons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = Color.FromArgb(20, 28, 23);
                    btn.ForeColor = Color.FromArgb(74, 222, 128); // Emerald Green
                    pnlNavIndicator.Location = new Point(0, btn.Top);
                    pnlNavIndicator.Height = btn.Height;
                    pnlNavIndicator.BringToFront();
                }
                else
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(161, 161, 170); // Muted gray
                }
            }
        }

        /// <summary>
        /// Allows child UserControls (e.g., dashboard shortcuts) to trigger sidebar navigation.
        /// </summary>
        public void NavigateTo(string destination)
        {
            switch (destination)
            {
                case "StudentAccounts":
                    btn_StudentLists.PerformClick();
                    break;
                case "SkillCategories":
                    btn_SkillCategories.PerformClick();
                    break;
                case "ModerateListings":
                    btn_ModerateListings.PerformClick();
                    break;
                case "ReviewTickets":
                    btn_ReportedStudents.PerformClick();
                    break;
                default:
                    btn_AdminDashboard.PerformClick();
                    break;
            }
        }

        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out of the Admin panel?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _notifTimer?.Stop();
                _notifTimer?.Dispose();
                UserSession.SignedOut = true;
                UserSession.EndSession();
                this.Close();
            }
        }

        private void AdminMainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _notifTimer?.Stop();
            _notifTimer?.Dispose();
            UserSession.EndSession();
        }

        private void content_adminpan_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
