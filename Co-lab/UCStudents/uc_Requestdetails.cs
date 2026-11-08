using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Co_LAB.UCStudents
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_Requestdetails : UserControl
    {
        private string _initials = "U";

        public uc_Requestdetails()
        {
            InitializeComponent();

            // Set up dark-theme styling and read-only behavior for information boxes
            ApplyReadOnlyTheme(textBox1);
            ApplyReadOnlyTheme(textBox2);
            ApplyReadOnlyTheme(textBox3);
            ApplyReadOnlyTheme(txtNotes);

            // Connect close button to close host Form
            btnCancel.Click += (s, e) => this.FindForm()?.Close();

            // Avatar painting
            pnlAvatar.Paint += PnlAvatar_Paint;
        }

        private void ApplyReadOnlyTheme(TextBox tb)
        {
            tb.ReadOnly = true;
            tb.BackColor = Color.FromArgb(39, 39, 45);
            tb.ForeColor = Color.White;
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        private void PnlAvatar_Paint(object? sender, PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using SolidBrush bgBrush = new SolidBrush(Color.FromArgb(16, 185, 129));
            pe.Graphics.FillEllipse(bgBrush, 0, 0, Math.Max(1, pnlAvatar.Width - 1), Math.Max(1, pnlAvatar.Height - 1));

            using StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using SolidBrush textBrush = new SolidBrush(Color.White);
            using Font font = new Font("Segoe UI", 11F, FontStyle.Bold);
            pe.Graphics.DrawString(_initials, font, textBrush, new RectangleF(0, 0, pnlAvatar.Width, pnlAvatar.Height), sf);
        }

        /// <summary>
        /// Populates the transaction details UI with information from a sent request.
        /// </summary>
        public void LoadDetails(
            string recipientName,
            string recipientDept,
            string targetSkill,
            string whatIOffered,
            string tradeModeAndLocation,
            string notes,
            string status = "PENDING")
        {
            lblUserName.Text = string.IsNullOrWhiteSpace(recipientName) ? "Unknown Student" : recipientName;
            lblUserDept.Text = string.IsNullOrWhiteSpace(recipientDept) ? "UE Student" : recipientDept;

            _initials = ExtractInitials(lblUserName.Text);
            pnlAvatar.Invalidate();

            // They Offer (Target Skill you requested)
            textBox1.Text = string.IsNullOrWhiteSpace(targetSkill) ? "Not specified" : targetSkill;

            // You Offered (Your offered skill title)
            textBox2.Text = string.IsNullOrWhiteSpace(whatIOffered) ? "Not specified" : whatIOffered;

            // Exchange Format / Trade Mode & Location
            textBox3.Text = string.IsNullOrWhiteSpace(tradeModeAndLocation) ? "Not specified" : tradeModeAndLocation;

            // Additional Notes / Message
            txtNotes.Text = string.IsNullOrWhiteSpace(notes) ? "No additional notes provided." : notes;
        }

        /// <summary>
        /// Overload that directly binds from uc_SentRequests.SentRequestModel.
        /// </summary>
        public void LoadDetails(uc_SentRequests.SentRequestModel req)
        {
            if (req == null) return;

            string modeAndLoc;
            if (!string.IsNullOrWhiteSpace(req.MeetingMode) && !string.IsNullOrWhiteSpace(req.Location))
            {
                modeAndLoc = $"{req.MeetingMode} ({req.Location})";
            }
            else if (!string.IsNullOrWhiteSpace(req.MeetingMode))
            {
                modeAndLoc = req.MeetingMode;
            }
            else if (!string.IsNullOrWhiteSpace(req.Location))
            {
                modeAndLoc = req.Location;
            }
            else
            {
                modeAndLoc = "Not specified";
            }

            LoadDetails(
                req.RecipientName,
                req.RecipientProgram,
                req.TargetSkill,
                req.WhatIOffered,
                modeAndLoc,
                req.Note,
                req.Status
            );
        }

        /// <summary>
        /// Overload that directly binds from uc_IncomingRequests.TradeRequestModel.
        /// </summary>
        public void LoadDetails(uc_IncomingRequests.TradeRequestModel req)
        {
            if (req == null) return;

            string modeAndLoc;
            if (!string.IsNullOrWhiteSpace(req.MeetingMode) && !string.IsNullOrWhiteSpace(req.Location))
            {
                modeAndLoc = $"{req.MeetingMode} ({req.Location})";
            }
            else if (!string.IsNullOrWhiteSpace(req.MeetingMode))
            {
                modeAndLoc = req.MeetingMode;
            }
            else if (!string.IsNullOrWhiteSpace(req.Location))
            {
                modeAndLoc = req.Location;
            }
            else
            {
                modeAndLoc = "Not specified";
            }

            // For incoming requests:
            // "They Offer:" is what the requester is offering (OffersSkill).
            // "You Offered:" is what the requester wants from your listings (WantsSkill).
            LoadDetails(
                req.RequesterName,
                req.RequesterProgram,
                req.OffersSkill,
                req.WantsSkill,
                modeAndLoc,
                req.Note,
                req.Status
            );
        }

        private static string ExtractInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "U";
            string[] parts = fullName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1) return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();
            return $"{parts[0][0]}{parts[parts.Length - 1][0]}".ToUpper();
        }

        private void lblHeaderTitle_Click(object sender, EventArgs e) { }
        private void lblTradeMode_Click(object sender, EventArgs e) { }
        private void uc_Requestdetails_Load(object sender, EventArgs e) { }
    }
}
