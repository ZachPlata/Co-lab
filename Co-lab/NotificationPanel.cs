using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class NotificationPanel : UserControl
    {
        private string _userEmail = "";
        private string _role = "Student";

        public event EventHandler<string>? NotificationActionRequested;
        public event EventHandler? CloseRequested;

        public NotificationPanel()
        {
            InitializeComponent();
        }

        private void btnMarkAllRead_Click(object? sender, EventArgs e)
        {
            NotificationHelper.MarkAllAsRead(_userEmail, _role);
            RefreshNotifications(_userEmail, _role);
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        public void RefreshNotifications(string userEmail, string role)
        {
            _userEmail = userEmail;
            _role = role;

            flpList.SuspendLayout();
            for (int i = flpList.Controls.Count - 1; i >= 0; i--)
            {
                Control old = flpList.Controls[i];
                flpList.Controls.RemoveAt(i);
                old.Dispose();
            }

            DataTable dt = NotificationHelper.GetNotifications(userEmail, role, 30);

            if (dt == null || dt.Rows.Count == 0)
            {
                lblEmpty.Visible = true;
                lblEmpty.BringToFront();
            }
            else
            {
                lblEmpty.Visible = false;
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
