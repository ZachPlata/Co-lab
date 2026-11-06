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
    public partial class uc_IncomingRequests : UserControl
    {
        // Internal data model matching tbl_traderequests schema
        public class TradeRequestModel
        {
            public int RequestId { get; set; }
            public string RequesterName { get; set; } = "";
            public string RequesterProgram { get; set; } = "";
            public string Initials { get; set; } = "";
            public string WantsSkill { get; set; } = "";
            public string OffersSkill { get; set; } = "";
            public DateTime RequestDateTime { get; set; }
            public string Location { get; set; } = "";
            public string Note { get; set; } = "";
            public string Status { get; set; } = "PENDING"; // PENDING, ACCEPTED, COMPLETED, DECLINED
        }

        private List<TradeRequestModel> _requests = new List<TradeRequestModel>();

        public uc_IncomingRequests()
        {
            InitializeComponent();
        }

        private void uc_IncomingRequests_Load(object sender, EventArgs e)
        {
            LoadIncomingRequests();
        }

        /// <summary>
        /// Loads real incoming trade proposals from tbl_traderequests joined to tbl_skills for this student.
        /// No fake seeded mock data.
        /// </summary>
        public void LoadIncomingRequests()
        {
            _requests.Clear();

            int uid = UserSession.UserId;
            string studentName = string.IsNullOrWhiteSpace(UserSession.FullName) ? "Zach Plata" : UserSession.FullName;

            try
            {
                string query = @"SELECT 
                                    r.RequestId, 
                                    r.SenderName AS RequesterName, 
                                    COALESCE(u.College, 'UE Student') AS RequesterProgram, 
                                    s.SkillTitle AS WantsSkill, 
                                    r.OfferedSkillTitle AS OffersSkill, 
                                    r.RequestDate AS RequestDateTime, 
                                    r.Location, 
                                    r.Message AS Note, 
                                    r.Status 
                                 FROM tbl_traderequests r 
                                 INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                                 LEFT JOIN tbl_users u ON r.SenderEmail = u.Email OR r.SenderName = u.FullName 
                                 WHERE (s.UserId = @uid OR s.OfferedBy = @user) 
                                   AND (r.Status != 'Declined') 
                                 ORDER BY r.RequestId DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@uid", uid),
                    new MySqlParameter("@user", studentName));

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var req = new TradeRequestModel
                        {
                            RequestId = Convert.ToInt32(row["RequestId"]),
                            RequesterName = row["RequesterName"]?.ToString() ?? "",
                            RequesterProgram = row["RequesterProgram"]?.ToString() ?? "UE Student",
                            WantsSkill = row["WantsSkill"]?.ToString() ?? "",
                            OffersSkill = row["OffersSkill"]?.ToString() ?? "",
                            RequestDateTime = row["RequestDateTime"] != DBNull.Value ? Convert.ToDateTime(row["RequestDateTime"]) : DateTime.Now,
                            Location = row["Location"]?.ToString() ?? "",
                            Note = row["Note"]?.ToString() ?? "",
                            Status = (row["Status"]?.ToString() ?? "Pending").ToUpper()
                        };

                        req.Initials = ExtractInitials(req.RequesterName);
                        _requests.Add(req);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading incoming requests: {ex.Message}");
            }

            RenderCards();
        }

        /// <summary>
        /// Renders all request cards inside the vertical scrollable FlowLayoutPanel.
        /// Shows empty state message if no requests exist.
        /// </summary>
        private void RenderCards()
        {
            flpRequests.SuspendLayout();
            flpRequests.Controls.Clear();

            if (_requests.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "No incoming trade requests yet.\nWhen other students propose to trade skills with you, their requests will appear here.",
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
                Panel card = CreateRequestCard(req, cardWidth);
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

        /// <summary>
        /// Creates a card panel matching the dark theme design.
        /// </summary>
        private Panel CreateRequestCard(TradeRequestModel req, int cardWidth)
        {
            Panel card = new Panel
            {
                Width = cardWidth,
                Height = 175,
                BackColor = Color.FromArgb(25, 36, 29),
                Margin = new Padding(0, 0, 0, 14),
                Padding = new Padding(16)
            };

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var pen = new Pen(Color.FromArgb(42, 60, 48), 1.5f);
                var rect = new Rectangle(1, 1, card.Width - 3, card.Height - 3);
                using var path = CreateRoundedRectanglePath(rect, 8);
                e.Graphics.DrawPath(pen, path);
            };

            // 1. Circular Avatar with initials
            Panel avatar = new Panel
            {
                Size = new Size(42, 42),
                Location = new Point(16, 16),
                BackColor = Color.Transparent
            };
            avatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(Color.FromArgb(48, 68, 54));
                using var textBrush = new SolidBrush(Color.FromArgb(200, 230, 210));
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

            // 2. Title Label: "Request from: [Name] ([Program])"
            Label lblHeader = new Label
            {
                Text = $"Request from: {req.RequesterName} ({req.RequesterProgram})",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(70, 16),
                AutoSize = true
            };
            card.Controls.Add(lblHeader);

            // 3. Status Badge (top right)
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
                    lblStatus.ForeColor = Color.FromArgb(234, 179, 8); // Amber
                    break;
                case "ACCEPTED":
                    lblStatus.ForeColor = Color.FromArgb(74, 222, 128); // Green
                    break;
                case "COMPLETED":
                    lblStatus.ForeColor = Color.FromArgb(161, 161, 170); // Muted gray
                    break;
                case "DECLINED":
                    lblStatus.ForeColor = Color.FromArgb(239, 68, 68); // Red
                    break;
                default:
                    lblStatus.ForeColor = Color.FromArgb(234, 179, 8);
                    break;
            }
            card.Controls.Add(lblStatus);

            // 4. Trade Offer Detail: Wants: "[Wants]" ⇌ Offers: "[Offers]"
            Label lblExchange = new Label
            {
                Text = $"Wants: \"{req.WantsSkill}\"  ⇌  Offers: \"{req.OffersSkill}\"",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(200, 215, 205),
                Location = new Point(70, 42),
                AutoSize = true
            };
            card.Controls.Add(lblExchange);

            // 5. Date & Location info
            string locText = string.IsNullOrWhiteSpace(req.Location) ? "" : $"  📍  {req.Location}";
            Label lblMeta = new Label
            {
                Text = $"📅 {req.RequestDateTime:ddd, MMM d, yyyy @ h:mm tt}{locText}",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(140, 160, 145),
                Location = new Point(70, 68),
                AutoSize = true
            };
            card.Controls.Add(lblMeta);

            // 6. Note / Message
            string noteText = string.IsNullOrWhiteSpace(req.Note) ? "No message provided." : $"Note: \"{req.Note}\"";
            Label lblNote = new Label
            {
                Text = noteText,
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(130, 150, 135),
                Location = new Point(70, 92),
                Size = new Size(card.Width - 90, 20),
                AutoEllipsis = true
            };
            card.Controls.Add(lblNote);

            // 7. Action Buttons (bottom row)
            int btnY = 124;
            int currentBtnX = 70;

            // Details Button
            Button btnDetails = CreateButton("Details", Color.FromArgb(32, 45, 36), Color.FromArgb(220, 235, 225), new Size(78, 28));
            btnDetails.Location = new Point(currentBtnX, btnY);
            btnDetails.Click += (s, e) => ShowRequestDetails(req);
            card.Controls.Add(btnDetails);
            currentBtnX += 86;

            // Conditional Action Buttons based on status
            switch (req.Status)
            {
                case "PENDING":
                    Button btnAccept = CreateButton("✓ Accept", Color.FromArgb(16, 185, 129), Color.White, new Size(88, 28));
                    btnAccept.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
                    btnAccept.Location = new Point(currentBtnX, btnY);
                    btnAccept.Click += (s, e) => AcceptRequest(req);
                    card.Controls.Add(btnAccept);
                    currentBtnX += 96;

                    Button btnReject = CreateButton("✗ Decline", Color.FromArgb(239, 68, 68), Color.White, new Size(88, 28));
                    btnReject.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
                    btnReject.Location = new Point(currentBtnX, btnY);
                    btnReject.Click += (s, e) => RejectRequest(req);
                    card.Controls.Add(btnReject);
                    break;

                case "ACCEPTED":
                    Button btnComplete = CreateButton("🎓 Mark Completed", Color.FromArgb(50, 75, 58), Color.White, new Size(130, 28));
                    btnComplete.Location = new Point(currentBtnX, btnY);
                    btnComplete.Click += (s, e) => MarkCompleted(req);
                    card.Controls.Add(btnComplete);
                    break;

                case "COMPLETED":
                    break;
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

        #region Actions & Handlers

        private void AcceptRequest(TradeRequestModel req)
        {
            var res = MessageBox.Show(
                $"Accept trade request from {req.RequesterName}?\n\nYou agree to exchange:\nWants: \"{req.WantsSkill}\"\nOffers: \"{req.OffersSkill}\"",
                "Accept Trade Request",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                UpdateDatabaseStatus(req.RequestId, "Accepted");
                LoadIncomingRequests();
                MessageBox.Show($"Request from {req.RequesterName} is now ACCEPTED!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RejectRequest(TradeRequestModel req)
        {
            var res = MessageBox.Show(
                $"Are you sure you want to decline this trade request from {req.RequesterName}?",
                "Decline Trade Request",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                UpdateDatabaseStatus(req.RequestId, "Declined");
                LoadIncomingRequests();
            }
        }

        private void MarkCompleted(TradeRequestModel req)
        {
            var res = MessageBox.Show(
                $"Mark trade exchange with {req.RequesterName} as COMPLETED?\n\nBoth skills will be marked fulfilled.",
                "Mark Exchange Completed",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                UpdateDatabaseStatus(req.RequestId, "Completed");
                LoadIncomingRequests();
                MessageBox.Show($"Trade with {req.RequesterName} marked as COMPLETED!", "Exchange Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateDatabaseStatus(int requestId, string newStatus)
        {
            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE tbl_traderequests SET Status = @status WHERE RequestId = @id",
                    new MySqlParameter("@status", newStatus),
                    new MySqlParameter("@id", requestId));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating request status: {ex.Message}");
            }
        }

        private void ShowRequestDetails(TradeRequestModel req)
        {
            // Details dialog placeholder: add your custom Form here
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

        #endregion
    }
}
