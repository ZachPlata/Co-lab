using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public class NotificationPanel : UserControl
    {
        private FlowLayoutPanel flpList = null!;
        private Label lblHeader = null!;
        private Button btnMarkAllRead = null!;
        private Button btnClose = null!;
        private Panel pnlHeader = null!;

        private string _userEmail = "";
        private string _role = "Student";

        public event EventHandler<string>? NotificationActionRequested;
        public event EventHandler? CloseRequested;

        public NotificationPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            BackColor = Color.FromArgb(16, 22, 18);
            BorderStyle = BorderStyle.FixedSingle;
            Size = new Size(380, 440);

            // Header panel
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 44,
                BackColor = Color.FromArgb(20, 28, 23),
                Padding = new Padding(12, 8, 12, 8)
            };

            lblHeader = new Label
            {
                Text = "🔔 Notifications",
                Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(74, 222, 128),
                AutoSize = true,
                Location = new Point(12, 11)
            };

            btnMarkAllRead = new Button
            {
                Text = "Mark all read",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(161, 161, 170),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                AutoSize = true,
                Location = new Point(230, 9),
                Height = 26
            };
            btnMarkAllRead.FlatAppearance.BorderSize = 0;
            btnMarkAllRead.Click += (s, e) =>
            {
                NotificationHelper.MarkAllAsRead(_userEmail, _role);
                RefreshNotifications(_userEmail, _role);
            };

            btnClose = new Button
            {
                Text = "✕",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(161, 161, 170),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Size = new Size(26, 26),
                Location = new Point(345, 9)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => CloseRequested?.Invoke(this, EventArgs.Empty);

            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Controls.Add(btnMarkAllRead);
            pnlHeader.Controls.Add(btnClose);

            // Flow layout list
            flpList = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(8, 8, 8, 8),
                BackColor = Color.FromArgb(14, 19, 16)
            };

            Controls.Add(flpList);
            Controls.Add(pnlHeader);

            ResumeLayout(false);
        }

        public void RefreshNotifications(string userEmail, string role)
        {
            _userEmail = userEmail;
            _role = role;

            flpList.SuspendLayout();
            flpList.Controls.Clear();

            DataTable dt = NotificationHelper.GetNotifications(userEmail, role, 30);

            if (dt == null || dt.Rows.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "No notifications yet.\nYou're all caught up! ✨",
                    ForeColor = Color.FromArgb(140, 150, 142),
                    Font = new Font("Segoe UI", 9.5F),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(350, 120),
                    Margin = new Padding(0, 80, 0, 0)
                };
                flpList.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    int notifId = Convert.ToInt32(row["NotificationId"]);
                    string title = row["Title"]?.ToString() ?? "Notification";
                    string message = row["Message"]?.ToString() ?? "";
                    string type = row["Type"]?.ToString() ?? "Info";
                    bool isRead = row["IsRead"] != DBNull.Value && Convert.ToInt32(row["IsRead"]) == 1;
                    DateTime created = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now;

                    Panel card = CreateNotificationCard(notifId, title, message, type, isRead, created);
                    flpList.Controls.Add(card);
                }
            }

            flpList.ResumeLayout();
        }

        private Panel CreateNotificationCard(int notifId, string title, string message, string type, bool isRead, DateTime date)
        {
            Panel card = new Panel
            {
                Width = 345,
                Height = 85,
                Margin = new Padding(0, 0, 0, 8),
                BackColor = isRead ? Color.FromArgb(20, 26, 22) : Color.FromArgb(28, 42, 32),
                Cursor = Cursors.Hand,
                Padding = new Padding(10, 8, 10, 8)
            };

            // Left indicator strip for unread
            if (!isRead)
            {
                Panel strip = new Panel
                {
                    Width = 4,
                    Height = card.Height,
                    Dock = DockStyle.Left,
                    BackColor = Color.FromArgb(74, 222, 128)
                };
                card.Controls.Add(strip);
            }

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = isRead ? Color.FromArgb(212, 212, 216) : Color.White,
                Location = new Point(!isRead ? 14 : 10, 6),
                AutoSize = true
            };

            Label lblMsg = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(161, 161, 170),
                Location = new Point(!isRead ? 14 : 10, 26),
                Size = new Size(315, 34),
                AutoEllipsis = true
            };

            Label lblTime = new Label
            {
                Text = FormatTimeAgo(date),
                Font = new Font("Segoe UI", 7F),
                ForeColor = Color.FromArgb(120, 130, 122),
                Location = new Point(!isRead ? 14 : 10, 63),
                AutoSize = true
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblMsg);
            card.Controls.Add(lblTime);

            Action clickHandler = () =>
            {
                NotificationHelper.MarkAsRead(notifId);
                NotificationActionRequested?.Invoke(this, type);
            };

            card.Click += (s, e) => clickHandler();
            lblTitle.Click += (s, e) => clickHandler();
            lblMsg.Click += (s, e) => clickHandler();
            lblTime.Click += (s, e) => clickHandler();

            return card;
        }

        private static string FormatTimeAgo(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalMinutes < 1) return "Just now";
            if (span.TotalMinutes < 60) return $"{(int)span.TotalMinutes}m ago";
            if (span.TotalHours < 24) return $"{(int)span.TotalHours}h ago";
            if (span.TotalDays < 7) return $"{(int)span.TotalDays}d ago";
            return dt.ToString("MMM dd, yyyy");
        }
    }
}
