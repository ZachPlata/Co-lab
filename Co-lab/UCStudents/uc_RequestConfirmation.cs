using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Co_LAB.UCStudents
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_RequestConfirmation : UserControl
    {
        private string _initials = "U";

        /// <summary>
        /// True if the user confirmed acceptance of the trade offer.
        /// </summary>
        public bool IsConfirmed { get; private set; } = false;

        public uc_RequestConfirmation()
        {
            InitializeComponent();

            // Set up dark-theme styling and read-only behavior for information boxes
            ApplyReadOnlyTheme(TheyOfferTxtBox);
            ApplyReadOnlyTheme(YourOfferTxtBox);
            ApplyReadOnlyTheme(TradeModeTxtBox);
            ApplyReadOnlyTheme(txtNotes);

            // Connect button actions
            btnSendRequest.Click += BtnSendRequest_Click;
            btnCancel.Click += BtnCancel_Click;

            // Custom avatar painting with initials
            pnlAvatar.Paint += PnlAvatar_Paint;
        }

        private void ApplyReadOnlyTheme(TextBox tb)
        {
            tb.ReadOnly = true;
            tb.BackColor = Color.FromArgb(14, 20, 16);
            tb.ForeColor = Color.White;
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        private void BtnSendRequest_Click(object? sender, EventArgs e)
        {
            IsConfirmed = true;
            Form? parent = this.FindForm();
            if (parent != null)
            {
                parent.DialogResult = DialogResult.OK;
                parent.Close();
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            IsConfirmed = false;
            Form? parent = this.FindForm();
            if (parent != null)
            {
                parent.DialogResult = DialogResult.Cancel;
                parent.Close();
            }
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
        /// Loads request information into confirmation fields from incoming request data.
        /// </summary>
        public void LoadRequest(
            string requesterName,
            string requesterProgram,
            string theyOffer,
            string youOffer,
            string tradeModeAndLocation,
            string notes)
        {
            lblUserName.Text = string.IsNullOrWhiteSpace(requesterName) ? "Unknown Student" : requesterName;
            lblUserDept.Text = string.IsNullOrWhiteSpace(requesterProgram) ? "UE Student" : requesterProgram;

            _initials = ExtractInitials(lblUserName.Text);
            pnlAvatar.Invalidate();

            // They Offer (the skill the requester will provide to you)
            TheyOfferTxtBox.Text = string.IsNullOrWhiteSpace(theyOffer) ? "Not specified" : theyOffer;

            // You Offered (the skill they are requesting from your listings)
            YourOfferTxtBox.Text = string.IsNullOrWhiteSpace(youOffer) ? "Not specified" : youOffer;

            // Format & Location
            TradeModeTxtBox.Text = string.IsNullOrWhiteSpace(tradeModeAndLocation) ? "Not specified" : tradeModeAndLocation;

            // Notes / Proposal message
            txtNotes.Text = string.IsNullOrWhiteSpace(notes) ? "No additional notes provided." : notes;
        }

        /// <summary>
        /// Directly binds data from uc_IncomingRequests.TradeRequestModel.
        /// </summary>
        public void LoadRequest(uc_IncomingRequests.TradeRequestModel req)
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

            LoadRequest(
                req.RequesterName,
                req.RequesterProgram,
                req.OffersSkill,
                req.WantsSkill,
                modeAndLoc,
                req.Note
            );
        }

        private static string ExtractInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "U";
            string[] parts = fullName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1) return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();
            return $"{parts[0][0]}{parts[parts.Length - 1][0]}".ToUpper();
        }
    }
}
