using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class StudentMainForm : Form
    {
        public static string CurrentStudentName { get; set; } = string.Empty;

        private System.Windows.Forms.Timer _notifTimer = null!;
        private bool _wasVerified = UserSession.IsVerified;

        public StudentMainForm()
        {
            InitializeComponent();
            this.FormClosing += StudentMainForm_FormClosing;
            pnlHeader.Resize += (s, e) => LayoutHeaderControls();
        }

        private void LayoutHeaderControls()
        {
            if (pnlHeader == null || btnNotificationBell == null || lblWelcome == null) return;

            lblWelcome.AutoEllipsis = true;
            lblWelcome.MaximumSize = new Size(280, 28);

            int rightMargin = 24;
            lblWelcome.Location = new Point(
                Math.Max(lblHeaderTitle.Right + 16, pnlHeader.ClientSize.Width - lblWelcome.Width - rightMargin),
                (pnlHeader.Height - lblWelcome.Height) / 2);

            btnNotificationBell.Location = new Point(
                Math.Max(lblHeaderTitle.Right + 16, lblWelcome.Left - btnNotificationBell.Width - 16),
                (pnlHeader.Height - btnNotificationBell.Height) / 2);

            if (_lblDbStatusPill != null)
            {
                _lblDbStatusPill.Location = new Point(lblHeaderTitle.Right + 16, (pnlHeader.Height - _lblDbStatusPill.Height) / 2);
            }
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            // Reflect current student name in header and dashboard button
            lblWelcome.Text = $"Welcome, {CurrentStudentName}";
            btn_UserDashboard.Text = $"👤 {CurrentStudentName} (Dashboard)";

            InitializeStatusBanners();
            LayoutHeaderControls();

            // Initialize notifications UI
            InitializeNotificationUI();

            // Activate User Dashboard first so students can review/add their known skills
            btn_UserDashboard.PerformClick();
        }

        private void InitializeStatusBanners()
        {
            _pnlVerificationBanner.Visible = !UserSession.IsVerified;
            _lblDbStatusPill.BringToFront();
        }

        private void InitializeNotificationUI()
        {
            _notificationPanel.NotificationActionRequested += (s, type) =>
            {
                _notificationPanel.Visible = false;
                if (type == "TradeRequest" || type == "TradeUpdate")
                {
                    NavigateToTradeRequests();
                }
                CheckNotifications();
            };
            _notificationPanel.CloseRequested += (s, e) =>
            {
                _notificationPanel.Visible = false;
            };

            // Background timer to refresh notifications live & heartbeat session
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
            HeartbeatResult hb = UserSession.Heartbeat(out string banReason);
            if (hb == HeartbeatResult.Blacklisted)
            {
                _notifTimer?.Stop();
                string msg = string.IsNullOrWhiteSpace(banReason)
                    ? "Your account has been suspended by an Administrator."
                    : $"Your account has been suspended by an Administrator.\n\nReason: {banReason}";
                MessageBox.Show(msg, "Account Suspended", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UserSession.SignedOut = true;
                UserSession.EndSession();
                Close();
                return;
            }
            if (hb == HeartbeatResult.SessionInvalid)
            {
                _notifTimer?.Stop();
                MessageBox.Show("Your session has ended because your account was signed in elsewhere or reset.",
                    "Session Ended", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UserSession.SignedOut = true;
                UserSession.Clear();
                Close();
                return;
            }

            if (_lblDbStatusPill != null)
            {
                _lblDbStatusPill.Visible = hb == HeartbeatResult.Offline;
            }

            if (_pnlVerificationBanner != null)
            {
                _pnlVerificationBanner.Visible = !UserSession.IsVerified;
                if (UserSession.IsVerified && !_wasVerified)
                {
                    _wasVerified = true;
                    if (panelContent.Controls.Count > 0 && panelContent.Controls[0] is uc_ManageSkills ms)
                        ms.LoadMyListings();
                    else if (panelContent.Controls.Count > 0 && panelContent.Controls[0] is uc_UserDashboard ud)
                        ud.LoadDashboardData();
                }
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
                _notificationPanel.RefreshNotifications(UserSession.Email, "Student");
                _notificationPanel.BringToFront();
            }
        }

        private void CheckNotifications()
        {
            try
            {
                int unread = NotificationHelper.GetUnreadCount(UserSession.Email, "Student");
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

                // Update sidebar badge for pending incoming requests
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = @"SELECT COUNT(*) FROM tbl_traderequests r 
                                    INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                                    WHERE (s.UserId = @uid OR s.OfferedBy = @user) 
                                      AND r.Status = 'Pending'";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@uid", UserSession.UserId);
                cmd.Parameters.AddWithValue("@user", UserSession.FullName);

                int incomingPending = 0;
                using MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() && reader[0] != DBNull.Value)
                {
                    incomingPending = Convert.ToInt32(reader[0]);
                }
                conn.Close();
                if (incomingPending > 0)
                {
                    btn_TradeRequests.Text = $"Trade Requests ({incomingPending})";
                }
                else
                {
                    btn_TradeRequests.Text = "Trade Requests";
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
        // NAVIGATION SHORTCUTS
        // ==========================================

        public void NavigateToSkillExchange() => btn_SkillExchange.PerformClick();
        public void NavigateToManageSkills() => btn_ManageSkills.PerformClick();
        public void NavigateToTradeRequests() => btn_TradeRequests.PerformClick();
        public void NavigateToUserDashboard() => btn_UserDashboard.PerformClick();

        // ==========================================
        // SIDEBAR BUTTON CLICK EVENTS (TRANSITIONS)
        // ==========================================

        private void LoadContentControl(UserControl control)
        {
            for (int i = panelContent.Controls.Count - 1; i >= 0; i--)
            {
                Control old = panelContent.Controls[i];
                panelContent.Controls.RemoveAt(i);
                old.Dispose();
            }

            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
            control.Show();
        }

        private void btn_SkillExchange_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(new uc_SkillExchange());
            SetActiveButton(btn_SkillExchange);
            lblHeaderTitle.Text = "Skill Exchange";
        }

        private void btn_ManageSkills_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(new uc_ManageSkills());
            SetActiveButton(btn_ManageSkills);
            lblHeaderTitle.Text = "My Listings";
        }

        private void btn_TradeRequests_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(new uc_TradeRequests());
            SetActiveButton(btn_TradeRequests);
            lblHeaderTitle.Text = "Trade Requests";
            CheckNotifications();
        }

        private void btn_UserDashboard_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            LoadContentControl(new uc_UserDashboard
            {
                CurrentStudentName = CurrentStudentName
            });
            SetActiveButton(btn_UserDashboard);
            lblHeaderTitle.Text = "Student Profile & Dashboard";
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            btn_UserDashboard.PerformClick();
        }

        private void SetActiveButton(Button activeButton)
        {
            Button[] navButtons = { btn_UserDashboard, btn_SkillExchange, btn_ManageSkills, btn_TradeRequests };
            foreach (var btn in navButtons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = Color.FromArgb(20, 28, 23);
                    btn.ForeColor = Color.FromArgb(74, 222, 128); // Emerald Green
                    pnlNavIndicator.Visible = true;
                    pnlNavIndicator.Location = new Point(0, btn.Top);
                    pnlNavIndicator.Height = btn.Height;
                }
                else
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(161, 161, 170); // Muted gray
                }
            }
        }

        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _notifTimer?.Stop();
                _notifTimer?.Dispose();
                UserSession.SignedOut = true;
                UserSession.EndSession();
                this.Close();
            }
        }

        private void StudentMainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _notifTimer?.Stop();
            _notifTimer?.Dispose();
            UserSession.EndSession();
        }
    }
}
