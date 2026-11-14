using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class StudentMainForm : Form
    {
        public static string CurrentStudentName { get; set; } = "Juan Dela Cruz";

        private Button btnNotificationBell = null!;
        private NotificationPanel _notificationPanel = null!;
        private System.Windows.Forms.Timer _notifTimer = null!;

        public StudentMainForm()
        {
            InitializeComponent();
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            // Reflect current student name in header and dashboard button
            lblWelcome.Text = $"Welcome, {CurrentStudentName}";
            btn_UserDashboard.Text = $"👤 {CurrentStudentName} (Dashboard)";

            // Initialize notifications UI
            InitializeNotificationUI();

            // Activate User Dashboard first so students can review/add their known skills
            btn_UserDashboard.PerformClick();
        }

        private void InitializeNotificationUI()
        {
            // Notification Bell button
            btnNotificationBell = new Button
            {
                Text = "🔔 0",
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(24, 34, 27),
                ForeColor = Color.FromArgb(74, 222, 128),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Size = new Size(82, 32),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(lblWelcome.Left - 95, 27)
            };
            btnNotificationBell.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 70);
            btnNotificationBell.FlatAppearance.BorderSize = 1;
            btnNotificationBell.Click += BtnNotificationBell_Click;

            pnlHeader.Controls.Add(btnNotificationBell);
            btnNotificationBell.BringToFront();

            // Notification dropdown panel
            _notificationPanel = new NotificationPanel
            {
                Visible = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(Width - 400, pnlHeader.Bottom + 2),
                Size = new Size(380, 440)
            };
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

            Controls.Add(_notificationPanel);
            _notificationPanel.BringToFront();

            // Background timer to refresh notifications live
            _notifTimer = new System.Windows.Forms.Timer
            {
                Interval = 5000 // Every 5 seconds
            };
            _notifTimer.Tick += (s, e) => CheckNotifications();
            _notifTimer.Start();

            // Initial sync & check
            NotificationHelper.SyncExistingPendingNotifications();
            CheckNotifications();
        }

        private void BtnNotificationBell_Click(object? sender, EventArgs e)
        {
            _notificationPanel.Location = new Point(Width - 400, pnlHeader.Bottom + 2);
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
                string query = @"SELECT COUNT(*) FROM tbl_traderequests r 
                                 INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                                 WHERE (s.UserId = @uid OR s.OfferedBy = @user) 
                                   AND r.Status = 'Pending'";
                object? countObj = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@uid", UserSession.UserId),
                    new MySqlParameter("@user", UserSession.FullName));

                int incomingPending = countObj != null && countObj != DBNull.Value ? Convert.ToInt32(countObj) : 0;
                if (incomingPending > 0)
                {
                    btn_TradeRequests.Text = $"Trade Requests ({incomingPending})";
                }
                else
                {
                    btn_TradeRequests.Text = "Trade Requests";
                }
            }
            catch { }
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

        private void btn_SkillExchange_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            uc_SkillExchange frm = new uc_SkillExchange();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_SkillExchange);
            lblHeaderTitle.Text = "Skill Exchange";
        }

        private void btn_ManageSkills_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            uc_ManageSkills frm = new uc_ManageSkills();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_ManageSkills);
            lblHeaderTitle.Text = "My Listings";
        }

        private void btn_TradeRequests_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            uc_TradeRequests frm = new uc_TradeRequests();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_TradeRequests);
            lblHeaderTitle.Text = "Trade Requests";
            CheckNotifications();
        }

        private void btn_UserDashboard_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            uc_UserDashboard frm = new uc_UserDashboard
            {
                CurrentStudentName = CurrentStudentName,
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Clear();
            panelContent.Controls.Add(frm);
            frm.Show();
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
                UserSession.Clear();
                this.Close();
            }
        }
    }
}
