using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_SentRequests : UserControl
    {
        public class SentRequestModel
        {
            public int RequestId { get; set; }
            public string RecipientName { get; set; } = "";
            public string RecipientProgram { get; set; } = "";
            public string Initials { get; set; } = "";
            public string TargetSkill { get; set; } = "";
            public string WhatIOffered { get; set; } = "";
            public DateTime RequestDateTime { get; set; }
            public string MeetingMode { get; set; } = "Face-to-Face";
            public string Location { get; set; } = "";
            public string Note { get; set; } = "";
            public string Status { get; set; } = "PENDING";
        }

        private List<SentRequestModel> _requests = new List<SentRequestModel>();

        public uc_SentRequests()
        {
            InitializeComponent();
        }

        private void uc_SentRequests_Load(object sender, EventArgs e)
        {
            LoadSentRequests();
        }

        public void LoadSentRequests()
        {
            _requests.Clear();

            string studentName = string.IsNullOrWhiteSpace(UserSession.FullName) ? "Zach Plata" : UserSession.FullName;
            string studentEmail = string.IsNullOrWhiteSpace(UserSession.Email) ? "" : UserSession.Email;

            try
            {
                string query = @"SELECT 
                                    r.RequestId, 
                                    s.OfferedBy AS RecipientName, 
                                    COALESCE(u.College, 'UE Student') AS RecipientProgram, 
                                    s.SkillTitle AS TargetSkill, 
                                    r.OfferedSkillTitle AS WhatIOffered, 
                                    r.RequestDate AS RequestDateTime, 
                                    COALESCE(r.MeetingMode, 'Face-to-Face') AS MeetingMode,
                                    r.Location, 
                                    r.Message AS Note, 
                                    r.Status 
                                 FROM tbl_traderequests r 
                                 INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                                 LEFT JOIN tbl_users u ON s.UserId = u.UserId OR s.OfferedBy = u.FullName 
                                 WHERE r.SenderName = @user OR (r.SenderEmail = @email AND @email != '') 
                                 ORDER BY r.RequestId DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@user", studentName),
                    new MySqlParameter("@email", studentEmail));

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var req = new SentRequestModel
                        {
                            RequestId = Convert.ToInt32(row["RequestId"]),
                            RecipientName = row["RecipientName"]?.ToString() ?? "",
                            RecipientProgram = row["RecipientProgram"]?.ToString() ?? "UE Student",
                            TargetSkill = row["TargetSkill"]?.ToString() ?? "",
                            WhatIOffered = row["WhatIOffered"]?.ToString() ?? "",
                            RequestDateTime = row["RequestDateTime"] != DBNull.Value ? Convert.ToDateTime(row["RequestDateTime"]) : DateTime.Now,
                            MeetingMode = row["MeetingMode"]?.ToString() ?? "Face-to-Face",
                            Location = row["Location"]?.ToString() ?? "",
                            Note = row["Note"]?.ToString() ?? "",
                            Status = (row["Status"]?.ToString() ?? "Pending").ToUpper()
                        };

                        req.Initials = ExtractInitials(req.RecipientName);
                        _requests.Add(req);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading sent requests: {ex.Message}");
            }

            RenderCards();
        }

        private void RenderCards()
        {
            flpRequests.SuspendLayout();
            flpRequests.Controls.Clear();

            if (_requests.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "No sent trade proposals yet.\nBrowse the Skill Exchange marketplace and request a trade to see your sent offers here!",
                    ForeColor = Color.FromArgb(161, 161, 170),
                    Font = new Font("Segoe UI", 10.5F),
                    AutoSize = false,
                    Size = new Size(Math.Max(flpRequests.ClientSize.Width - 40, 600), 100),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(20, 80, 0, 0)
                };
                flpRequests.Controls.Add(lblEmpty);
                flpRequests.ResumeLayout(true);
                return;
            }

            int cardWidth = GetResponsiveCardWidth();

            foreach (var req in _requests)
            {
                Panel card = CreateSentCard(req, cardWidth);
                flpRequests.Controls.Add(card);
            }

            flpRequests.ResumeLayout(true);
        }

        private int GetResponsiveCardWidth()
        {
            int scrollbarAllowance = SystemInformation.VerticalScrollBarWidth + 30;
            int availableWidth = flpRequests.ClientSize.Width - scrollbarAllowance;
            return Math.Max(availableWidth, 680);
        }

        private void flpRequests_Resize(object sender, EventArgs e)
        {
            if (flpRequests.Controls.Count == 0) return;

            int newWidth = GetResponsiveCardWidth();
            foreach (Control ctrl in flpRequests.Controls)
            {
                if (ctrl is Panel pnl)
                {
                    pnl.Width = newWidth;
                }
            }
        }

        private Panel CreateSentCard(SentRequestModel req, int cardWidth)
        {
            Panel card = new Panel
            {
                Width = cardWidth,
                Height = 175,
                BackColor = Color.FromArgb(28, 28, 33),
                Margin = new Padding(0, 0, 0, 14),
                Padding = new Padding(16)
            };

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var pen = new Pen(Color.FromArgb(45, 45, 52), 1.5f);
                var rect = new Rectangle(1, 1, card.Width - 3, card.Height - 3);
                using var path = CreateRoundedRectanglePath(rect, 8);
                e.Graphics.DrawPath(pen, path);
            };

            // Avatar
            Panel avatar = new Panel
            {
                Size = new Size(42, 42),
                Location = new Point(16, 16),
                BackColor = Color.Transparent
            };
            avatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(Color.FromArgb(39, 39, 45));
                using var textBrush = new SolidBrush(Color.FromArgb(200, 210, 220));
                using var font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
                using var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.FillEllipse(brush, 0, 0, avatar.Width - 1, avatar.Height - 1);
                e.Graphics.DrawString(req.Initials, font, textBrush, new RectangleF(0, 0, avatar.Width, avatar.Height), sf);
            };
            card.Controls.Add(avatar);

            // Title
            Label lblHeader = new Label
            {
                Text = $"Proposal to: {req.RecipientName} ({req.RecipientProgram})",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(70, 16),
                AutoSize = true
            };
            card.Controls.Add(lblHeader);

            // Status Badge
            Label lblStatus = new Label
            {
                Text = req.Status,
                Font = new Font("Segoe UI Black", 8F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(card.Width - 120, 16),
                Size = new Size(100, 20)
            };

            switch (req.Status)
            {
                case "PENDING":
                    lblStatus.ForeColor = Color.FromArgb(234, 179, 8);
                    break;
                case "ACCEPTED":
                    lblStatus.ForeColor = Color.FromArgb(74, 222, 128);
                    break;
                case "COMPLETED":
                    lblStatus.ForeColor = Color.FromArgb(161, 161, 170);
                    break;
                case "DECLINED":
                    lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                    break;
                default:
                    lblStatus.ForeColor = Color.FromArgb(234, 179, 8);
                    break;
            }
            card.Controls.Add(lblStatus);

            // Details
            Label lblExchange = new Label
            {
                Text = $"You Want: \"{req.TargetSkill}\"  ⇌  You Offered: \"{req.WhatIOffered}\"",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(212, 212, 216),
                Location = new Point(70, 42),
                AutoSize = true
            };
            card.Controls.Add(lblExchange);

            // Meta
            string locText = string.IsNullOrWhiteSpace(req.Location) ? "" : $"  📍  {req.Location}";
            Label lblMeta = new Label
            {
                Text = $"📅 Sent: {req.RequestDateTime:ddd, MMM d, yyyy @ h:mm tt}{locText}",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(161, 161, 170),
                Location = new Point(70, 68),
                AutoSize = true
            };
            card.Controls.Add(lblMeta);

            // Note
            string noteText = string.IsNullOrWhiteSpace(req.Note) ? "No message provided." : $"Your note: \"{req.Note}\"";
            Label lblNote = new Label
            {
                Text = noteText,
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(140, 140, 150),
                Location = new Point(70, 92),
                Size = new Size(card.Width - 90, 20),
                AutoEllipsis = true
            };
            card.Controls.Add(lblNote);

            // Buttons
            int btnY = 124;
            int currentBtnX = 70;

            Button btnDetails = CreateButton("Details", Color.FromArgb(39, 39, 45), Color.FromArgb(228, 228, 231), new Size(78, 28));
            btnDetails.Location = new Point(currentBtnX, btnY);
            btnDetails.Click += (s, e) => ShowSentDetails(req);
            card.Controls.Add(btnDetails);
            currentBtnX += 86;

            if (req.Status == "PENDING")
            {
                Button btnCancel = CreateButton("✕ Cancel Proposal", Color.FromArgb(185, 28, 28), Color.White, new Size(130, 28));
                btnCancel.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
                btnCancel.Location = new Point(currentBtnX, btnY);
                btnCancel.Click += (s, e) => CancelProposal(req);
                card.Controls.Add(btnCancel);
            }

            return card;
        }

        private Button CreateButton(string text, Color backColor, Color foreColor, Size size)
        {
            Button btn = new Button
            {
                Text = text,
                BackColor = backColor,
                ForeColor = foreColor,
                Size = size,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 8.5F),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void CancelProposal(SentRequestModel req)
        {
            if (MessageBox.Show($"Are you sure you want to cancel this trade proposal to {req.RecipientName}?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM tbl_traderequests WHERE RequestId = @id",
                    new MySqlParameter("@id", req.RequestId));

                LoadSentRequests();
                MessageBox.Show("Your trade proposal has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling proposal: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSentDetails(SentRequestModel req)
        {
            if (req == null) return;

            using Form dlg = new Form
            {
                Text = "Transaction Details",
                ClientSize = new Size(470, 501),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(24, 24, 27)
            };

            var detailsControl = new UCStudents.uc_Requestdetails
            {
                Dock = DockStyle.Fill
            };
            detailsControl.LoadDetails(req);

            dlg.Controls.Add(detailsControl);
            dlg.ShowDialog(this);
        }

        private static string ExtractInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "U";
            string[] parts = fullName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1) return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();
            return $"{parts[0][0]}{parts[parts.Length - 1][0]}".ToUpper();
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
