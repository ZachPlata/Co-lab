using System;
using System.Drawing;
using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class AdminMainForm : Form
    {
        private Button btnNotificationBell = null!;
        private NotificationPanel _notificationPanel = null!;
        private System.Windows.Forms.Timer _notifTimer = null!;

        public AdminMainForm()
        {
            InitializeComponent();
            this.FormClosing += AdminMainForm_FormClosing;
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            // Initialize notification UI & background checking
            InitializeNotificationUI();

            btn_AdminDashboard.PerformClick();
        }

        private void InitializeNotificationUI()
        {
            // Notification Bell button on top header
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
                Location = new Point(lblAdminProfile.Left - 95, 38)
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

            Controls.Add(_notificationPanel);
            _notificationPanel.BringToFront();

            // Background timer to refresh admin notifications live & heartbeat session
            _notifTimer = new System.Windows.Forms.Timer
            {
                Interval = 5000 // Every 5 seconds
            };
            _notifTimer.Tick += (s, e) =>
            {
                UserSession.Heartbeat();
                CheckNotifications();
            };
            _notifTimer.Start();

            // Initial heartbeat, sync & check
            UserSession.Heartbeat();
            NotificationHelper.SyncExistingPendingNotifications();
            CheckNotifications();
        }

        private void BtnNotificationBell_Click(object? sender, EventArgs e)
        {
            _notificationPanel.Location = new Point(Width - 400, pnlHeader.Bottom + 2);
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
                string query = "SELECT COUNT(*) FROM tbl_reports WHERE Status = 'Pending'";
                object? countObj = DatabaseHelper.ExecuteScalar(query);
                int pendingReports = countObj != null && countObj != DBNull.Value ? Convert.ToInt32(countObj) : 0;
                if (pendingReports > 0)
                {
                    btn_ReportedStudents.Text = $"Reports & Blacklist ({pendingReports})";
                }
                else
                {
                    btn_ReportedStudents.Text = "Reports & Blacklist";
                }
            }
            catch { }
        }

        // ==========================================
        // SIDEBAR BUTTON CLICK EVENTS (TRANSITIONS)
        // ==========================================

        private void btn_AdminDashboard_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            uc_AdminDashboard frm = new uc_AdminDashboard();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_AdminDashboard);
            lblHeaderTitle.Text = "Admin Dashboard";
        }

        private void btn_SkillCategories_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            uc_SkillCategories frm = new uc_SkillCategories();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_SkillCategories);
            lblHeaderTitle.Text = "Skill Categories Creation";
        }

        private void btn_ModerateListings_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            uc_ModerateListings frm = new uc_ModerateListings();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_ModerateListings);
            lblHeaderTitle.Text = "Moderate Skill Listings";
        }

        private void btn_ReportedStudents_Click(object sender, EventArgs e)
        {
            _notificationPanel?.Hide();
            uc_ReportedStudents frm = new uc_ReportedStudents();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_ReportedStudents);
            lblHeaderTitle.Text = "Reports & Blacklist";
            CheckNotifications();
        }

        private void SetActiveButton(Button activeButton)
        {
            Button[] navButtons = { btn_AdminDashboard, btn_SkillCategories, btn_ModerateListings, btn_ReportedStudents };
            foreach (var btn in navButtons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = Color.FromArgb(20, 28, 23);
                    btn.ForeColor = Color.FromArgb(74, 222, 128); // Emerald Green
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

        /// <summary>
        /// Allows child UserControls (e.g., dashboard shortcuts) to trigger sidebar navigation.
        /// </summary>
        public void NavigateTo(string destination)
        {
            switch (destination)
            {
                case "StudentAccounts":
                    btn_AdminDashboard.PerformClick();
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
